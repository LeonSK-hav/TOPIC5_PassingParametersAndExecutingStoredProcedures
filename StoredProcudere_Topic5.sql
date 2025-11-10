USE [Restaurant Management];
GO

CREATE OR ALTER PROCEDURE dbo.GetBillsByDateRange
    @FromDate DATETIME,
    @ToDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        ID, Name, TableID, Amount, Disscount, Tax, Status, CheckoutDate, Account
    FROM dbo.BILLS
    WHERE CheckoutDate BETWEEN @FromDate AND @ToDate
    ORDER BY CheckoutDate DESC;
END
GO


USE [Restaurant Management];
GO

SELECT SCHEMA_NAME(schema_id) AS [SchemaName], name
FROM sys.procedures
WHERE name = 'sp_GetAllAccounts';
EXEC dbo.GetBillsByDateRange '2025-09-01', '2025-10-11';

-- Xóa tất cả các stored procedures nếu tồn tại
-- 1. Drop thủ tục sp_GetAllAccounts
DROP PROCEDURE IF EXISTS sp_GetAllAccounts;

-- 2. Drop thủ tục sp_SearchAccounts
DROP PROCEDURE IF EXISTS sp_SearchAccounts;

-- 3. Drop thủ tục sp_AddAccount
DROP PROCEDURE IF EXISTS sp_AddAccount;

-- 4. Drop thủ tục sp_UpdateAccount
DROP PROCEDURE IF EXISTS sp_UpdateAccount;

-- 5. Drop thủ tục sp_ResetPassword
DROP PROCEDURE IF EXISTS sp_ResetPassword;

-- 6. Drop thủ tục sp_DeleteAccount
DROP PROCEDURE IF EXISTS sp_DeleteAccount;

-- 7. Drop thủ tục sp_GetAllRoles
DROP PROCEDURE IF EXISTS sp_GetAllRoles;

-- 8. Drop thủ tục sp_GetRolesByAccount
DROP PROCEDURE IF EXISTS sp_GetRolesByAccount;

-- 9. Drop thủ tục sp_GetRolesStatusByAccount
DROP PROCEDURE IF EXISTS sp_GetRolesStatusByAccount;

-- 10. Drop thủ tục sp_UpdateRoleForAccount
DROP PROCEDURE IF EXISTS sp_UpdateRoleForAccount;

-- 11. Drop thủ tục sp_GetAccountActiveStatus
DROP PROCEDURE IF EXISTS sp_GetAccountActiveStatus;


--------------------------------------- THỦ TỤC FORM ACCOUNTFORM----------------------------------------------
--------------------------------------------------------------------------------------------------------------
-----------------------------------------------------
-- 1️. Lấy danh sách tất cả tài khoản
-----------------------------------------------------
CREATE OR ALTER PROC sp_GetAllAccounts
AS
BEGIN
    SELECT 
        a.AccountName,
        a.FullName,
        a.Email,
        a.Tell,
        a.DateCreated,
        CASE WHEN EXISTS (
            SELECT 1 FROM RoleAccount ra 
            WHERE ra.AccountName = a.AccountName AND ra.Actived = 1
        ) THEN 1 ELSE 0 END AS Actived,
        STRING_AGG(r.RoleName, ', ') AS Roles
    FROM Account a
    LEFT JOIN RoleAccount ra ON a.AccountName = ra.AccountName
    LEFT JOIN [Role] r ON ra.RoleID = r.ID
    GROUP BY a.AccountName, a.FullName, a.Email, a.Tell, a.DateCreated
END
GO
SELECT * FROM Role;

-----------------------------------------------------
-- 2️. Tìm kiếm tài khoản theo tên / họ tên / email
-----------------------------------------------------
CREATE OR ALTER PROC sp_SearchAccounts
    @Keyword NVARCHAR(100)
AS
BEGIN
    SELECT 
        a.AccountName,
        a.FullName,
        a.Email,
        a.Tell,
        a.DateCreated,
        CASE WHEN EXISTS (
            SELECT 1 FROM RoleAccount ra 
            WHERE ra.AccountName = a.AccountName AND ra.Actived = 1
        ) THEN 1 ELSE 0 END AS Actived,
        STRING_AGG(r.RoleName, ', ') AS Roles
    FROM Account a
    LEFT JOIN RoleAccount ra ON a.AccountName = ra.AccountName
    LEFT JOIN [Role] r ON ra.RoleID = r.ID
    WHERE a.AccountName LIKE N'%' + @Keyword + N'%'
       OR a.FullName LIKE N'%' + @Keyword + N'%'
       OR a.Email LIKE N'%' + @Keyword + N'%'
    GROUP BY a.AccountName, a.FullName, a.Email, a.Tell, a.DateCreated
END
GO

-----------------------------------------------------
-- 3️. Thêm hoặc cập nhật tài khoản (gộp Add + Update)
-----------------------------------------------------
CREATE OR ALTER PROC sp_SaveAccount
    @AccountName NVARCHAR(50),
    @Password NVARCHAR(50) = NULL,
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @Tell NVARCHAR(20),
    @DateCreated DATETIME
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Account WHERE AccountName = @AccountName)
        UPDATE Account
        SET FullName = @FullName,
            Email = @Email,
            Tell = @Tell
        WHERE AccountName = @AccountName
    ELSE
        INSERT INTO Account (AccountName, Password, FullName, Email, Tell, DateCreated)
        VALUES (@AccountName, ISNULL(@Password, '123'), @FullName, @Email, @Tell, @DateCreated)
END
GO

-----------------------------------------------------
-- 4️. Xóa tài khoản
-----------------------------------------------------
CREATE OR ALTER PROC sp_DeleteAccount
    @AccountName NVARCHAR(50)
AS
BEGIN
    DELETE FROM RoleAccount WHERE AccountName = @AccountName
    DELETE FROM Account WHERE AccountName = @AccountName
END
GO

-----------------------------------------------------
-- 5️. Lấy tất cả roles
-----------------------------------------------------
CREATE OR ALTER PROCEDURE sp_GetAllRoles
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ID, RoleName FROM [Role];
END


-----------------------------------------------------
-- 6️. Lấy roles (checked) theo tài khoản
-----------------------------------------------------
CREATE OR ALTER PROC sp_GetRolesStatusByAccount
    @AccountName NVARCHAR(50)
AS
BEGIN
    SELECT 
        r.ID,
        r.RoleName,
        CASE WHEN ra.AccountName IS NULL THEN 0 ELSE 1 END AS IsChecked
    FROM [Role] r
    LEFT JOIN RoleAccount ra ON r.ID = ra.RoleID AND ra.AccountName = @AccountName
END
GO

-----------------------------------------------------
-- 7️. Lưu roles khi thêm / cập nhật
-----------------------------------------------------

CREATE OR ALTER PROC sp_SaveRolesForAccount
    @AccountName NVARCHAR(100),
    @RoleID INT,
    @Actived BIT
AS
BEGIN
    SET NOCOUNT ON;

    -- Xóa hết vai trò cũ của account (chạy 1 lần trước vòng lặp, KHÔNG phải trong mỗi lần gọi!)
    -- => nên tách việc này ra ở đầu code C#
    IF @RoleID = -1  -- tín hiệu để xóa hết vai trò cũ
    BEGIN
        DELETE FROM RoleAccount WHERE AccountName = @AccountName;
        RETURN;
    END

    -- Nếu được check, thêm mới
    IF @Actived = 1
    BEGIN
        INSERT INTO RoleAccount (AccountName, RoleID, Actived)
        VALUES (@AccountName, @RoleID, 1);
    END
END
GO


---------------------------------------------------------------------------------
-- 8. Ki?m tra xem account có ?ang ???c kích ho?t không (n?u có role active)
----------------------------------------------------------------------------------
CREATE PROC sp_GetAccountActiveStatus
    @AccountName NVARCHAR(50)
AS
BEGIN
    SELECT CASE 
        WHEN EXISTS (SELECT * FROM ROLEACCOUNT WHERE AccountName = @AccountName AND Actived = 1)
        THEN 1 ELSE 0 END
END

------------------------------------------------------------------------------------------------------------------------------------
-- 9. Thêm vai trò
------------------------------------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE sp_AddRoles
    @RoleName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Nếu bảng Role không có cột ID tự tăng, nhớ kiểm tra lại
    IF NOT EXISTS (SELECT 1 FROM [Role] WHERE RoleName = @RoleName)
    BEGIN
        INSERT INTO [Role](RoleName)
        VALUES (@RoleName);
    END
    ELSE
    BEGIN
        PRINT N'Vai trò đã tồn tại.';
    END
END

EXEC sp_AddRoles N'Nhân viên mới';
EXEC sp_GetAllRoles;
EXEC sp_AddRoles N'Boss';
SELECT * FROM [Role];


--=================================================FORM CHANGEPASSWORD=============
-----------------------------------------------------
-- 1️. Kiểm tra mật khẩu cũ
-----------------------------------------------------
CREATE OR ALTER PROCEDURE sp_CheckOldPassword
    @AccountName NVARCHAR(50),
    @OldPassword NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Account WHERE AccountName = @AccountName AND Password = @OldPassword)
        SELECT 1 AS IsValid;
    ELSE
        SELECT 0 AS IsValid;
END
GO

-----------------------------------------------------
-- 2️. Cập nhật mật khẩu mới
-----------------------------------------------------
CREATE OR ALTER PROCEDURE sp_UpdatePassword
    @AccountName NVARCHAR(50),
    @NewPassword NVARCHAR(100)
AS
BEGIN
    UPDATE Account
    SET Password = @NewPassword
    WHERE AccountName = @AccountName;
END
GO

--=================================== ACTIVITYLOGFORM===========
---------------------------------------------------
-- 1. Lấy danh sách hóa đơn theo tài khoản
---------------------------------------------------
CREATE OR ALTER PROC sp_GetBillsByAccount
    @AccountName NVARCHAR(100)
AS
BEGIN
    SELECT 
        b.ID AS BillID,
        b.Name AS BillName,
        b.CheckoutDate,
        b.Amount AS TotalAmount
    FROM Bills b
    WHERE b.Account = @AccountName
    ORDER BY b.CheckoutDate DESC;
END
GO


---------------------------------------------------
-- 2. Lấy chi tiết hóa đơn (món ăn, số lượng, giá)
---------------------------------------------------
CREATE OR ALTER PROC sp_GetBillDetails
    @BillID INT
AS
BEGIN
    SELECT 
        f.Name AS FoodName,
        f.Unit,
        f.Price,
        bd.Quantity,
        (f.Price * bd.Quantity) AS Total
    FROM BillDetails bd
    INNER JOIN Food f ON bd.FoodID = f.ID
    WHERE bd.InvoiceID = @BillID;
END
GO

DROP PROCEDURE sp_GetBillsByAccount

/* --------------- =)))))) URGHHHHHHHH ARGHHHHHHHHHHHHH THỦ TỤC LỖI

--1. L?Y DANH SÁCH T?T C? TÀI KHO?N
CREATE PROC sp_GetAllAccounts
AS
BEGIN
    SELECT 
        a.AccountName,
        a.FullName,
        a.Email,
        a.Tell,
        a.DateCreated,
        STRING_AGG(r.RoleName, ', ') AS Roles
    FROM Account a
    LEFT JOIN RoleAccount ra ON a.AccountName = ra.AccountName
    LEFT JOIN Role r ON ra.RoleID = r.ID
    GROUP BY a.AccountName, a.FullName, a.Email, a.Tell, a.DateCreated
END



SELECT SCHEMA_NAME(schema_id) AS [SchemaName], name
FROM sys.procedures
WHERE name = 'sp_SearchAccounts';
EXEC dbo.GetBillsByDateRange '2025-09-01', '2025-10-11';

-- 2. TÌM KI?M TÀI KHO?N THEO TÊN/FULLNAME/EMAIL
CREATE PROCEDURE sp_SearchAccounts
    @Keyword NVARCHAR(100)
AS
BEGIN
    SELECT 
        A.AccountName,
        A.FullName,
        A.Email,
        A.Tell,
        A.DateCreated,
        R.RoleName,
        RA.Actived
    FROM Account A
    LEFT JOIN RoleAccount RA ON A.AccountName = RA.AccountName
    LEFT JOIN Role R ON RA.RoleID = R.ID
    WHERE 
        A.AccountName LIKE N'%' + @Keyword + N'%'
        OR A.FullName LIKE N'%' + @Keyword + N'%'
        OR A.Email LIKE N'%' + @Keyword + N'%'
END

-- 3. THÊM TÀI KHO?N M?I
CREATE PROCEDURE sp_AddAccount
    @AccountName NVARCHAR(50),
    @Password NVARCHAR(50),
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @Tell NVARCHAR(20),
    @DateCreated DATETIME
AS
BEGIN
    INSERT INTO Account(AccountName, Password, FullName, Email, Tell, DateCreated)
    VALUES (@AccountName, @Password, @FullName, @Email, @Tell, @DateCreated)
END

--4. C?P NH?T THÔNG TIN TÀI KHO?N 
CREATE PROCEDURE sp_UpdateAccount
    @AccountName NVARCHAR(50),
    @FullName NVARCHAR(100),
    @Email NVARCHAR(100),
    @Tell NVARCHAR(20)
AS
BEGIN
    UPDATE Account
    SET FullName = @FullName,
        Email = @Email,
        Tell = @Tell
    WHERE AccountName = @AccountName
END

--5. RESET M?T KH?U TÀI KHO?N
CREATE PROCEDURE sp_ResetPassword
    @AccountName NVARCHAR(50),
    @NewPassword NVARCHAR(50)
AS
BEGIN
    UPDATE Account
    SET Password = @NewPassword
    WHERE AccountName = @AccountName
END

--6. XÓA TÀI KHO?N 
CREATE PROCEDURE sp_DeleteAccount
    @AccountName NVARCHAR(50)
AS
BEGIN
    DELETE FROM RoleAccount WHERE AccountName = @AccountName
    DELETE FROM Account WHERE AccountName = @AccountName
END

DROP PROCEDURE sp_GetAllRoles
-- 7. L?Y T?T C? ROLES
CREATE PROC sp_GetAllRoles
AS
BEGIN
    SELECT ID, RoleName, Path, Notes
    FROM ROLE
END

-- 8.L?Y ROLES THEO ACCOUNT 
CREATE PROC sp_GetRolesByAccount
    @AccountName NVARCHAR(100)
AS
BEGIN
    SELECT r.RoleName
    FROM Account a
    JOIN RoleAccount ra ON a.AccountName = ra.AccountName
    JOIN Role r ON ra.RoleID = r.ID
    WHERE a.AccountName = @AccountName;
END
-- 9. Check/uncheck list
CREATE PROC sp_GetRolesStatusByAccount
    @AccountName NVARCHAR(50)
AS
BEGIN
    SELECT 
        r.ID,
        r.RoleName,
        CASE WHEN ra.AccountName IS NULL THEN 0 ELSE 1 END AS IsChecked
    FROM ROLE r
    LEFT JOIN ROLEACCOUNT ra 
        ON r.ID = ra.RoleID AND ra.AccountName = @AccountName
END
--10. Khi ng??i dùng nh?n nút “Update” trong form danh sách vai trò.
CREATE PROC sp_UpdateRoleForAccount
    @AccountName NVARCHAR(50),
    @RoleID INT,
    @Actived BIT
AS
BEGIN
    IF EXISTS (SELECT * FROM ROLEACCOUNT WHERE AccountName = @AccountName AND RoleID = @RoleID)
        UPDATE ROLEACCOUNT SET Actived = @Actived WHERE AccountName = @AccountName AND RoleID = @RoleID
    ELSE
        INSERT INTO ROLEACCOUNT(RoleID, AccountName, Actived) VALUES (@RoleID, @AccountName, @Actived)
END

DROP PROCEDURE sp_GetAccountActiveStatus


