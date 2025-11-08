namespace Lab_Advanced_Command
{
    partial class AccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.clbRoles = new System.Windows.Forms.CheckedListBox();
            this.dtpDateCreated = new System.Windows.Forms.DateTimePicker();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtTell = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvAccount = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmViewRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmActivityLog = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddRole);
            this.groupBox1.Controls.Add(this.clbRoles);
            this.groupBox1.Controls.Add(this.dtpDateCreated);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.txtTell);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtFullName);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtAccountName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1194, 261);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tài khoản";
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(986, 72);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(145, 39);
            this.btnAddRole.TabIndex = 15;
            this.btnAddRole.Text = "Thêm vai trò";
            this.btnAddRole.UseVisualStyleBackColor = true;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // clbRoles
            // 
            this.clbRoles.FormattingEnabled = true;
            this.clbRoles.Items.AddRange(new object[] {
            "Administrator",
            "Kế toán",
            "Nhân viên thanh toán",
            "Nhân viên phục vụ"});
            this.clbRoles.Location = new System.Drawing.Point(640, 34);
            this.clbRoles.Name = "clbRoles";
            this.clbRoles.Size = new System.Drawing.Size(310, 123);
            this.clbRoles.TabIndex = 14;
            // 
            // dtpDateCreated
            // 
            this.dtpDateCreated.Location = new System.Drawing.Point(655, 210);
            this.dtpDateCreated.Name = "dtpDateCreated";
            this.dtpDateCreated.Size = new System.Drawing.Size(200, 22);
            this.dtpDateCreated.TabIndex = 13;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(655, 165);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(74, 20);
            this.chkActive.TabIndex = 12;
            this.chkActive.Text = "Actived";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtTell
            // 
            this.txtTell.Location = new System.Drawing.Point(143, 210);
            this.txtTell.Name = "txtTell";
            this.txtTell.Size = new System.Drawing.Size(310, 22);
            this.txtTell.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(146, 163);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(310, 22);
            this.txtEmail.TabIndex = 9;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(146, 117);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(310, 22);
            this.txtFullName.TabIndex = 10;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(146, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(310, 22);
            this.txtPassword.TabIndex = 9;
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(146, 28);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(310, 22);
            this.txtAccountName.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(544, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ngày tạo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(544, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Active?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(544, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Vai trò:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số điện thoại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Họ tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnResetPassword);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Location = new System.Drawing.Point(12, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1194, 167);
            this.panel1.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(280, 90);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(559, 22);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(157, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Tìm kiếm:";
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(755, 19);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(145, 39);
            this.btnResetPassword.TabIndex = 2;
            this.btnResetPassword.Text = "Reset mật khẩu";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(511, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(145, 39);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(280, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(145, 39);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(54, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(145, 39);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvAccount
            // 
            this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccount.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAccount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAccount.Location = new System.Drawing.Point(0, 488);
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.RowHeadersWidth = 51;
            this.dgvAccount.RowTemplate.Height = 24;
            this.dgvAccount.Size = new System.Drawing.Size(1211, 342);
            this.dgvAccount.TabIndex = 2;
            this.dgvAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccount_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmViewRoles,
            this.tsmActivityLog});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(251, 80);
            // 
            // tsmViewRoles
            // 
            this.tsmViewRoles.Name = "tsmViewRoles";
            this.tsmViewRoles.Size = new System.Drawing.Size(250, 24);
            this.tsmViewRoles.Text = "Xem danh sách các vai trò";
            this.tsmViewRoles.Click += new System.EventHandler(this.tsmViewRoles_Click);
            // 
            // tsmActivityLog
            // 
            this.tsmActivityLog.Name = "tsmActivityLog";
            this.tsmActivityLog.Size = new System.Drawing.Size(250, 24);
            this.tsmActivityLog.Text = "Xem nhật ký hoạt động";
            this.tsmActivityLog.Click += new System.EventHandler(this.tsmActivityLog_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 830);
            this.Controls.Add(this.dgvAccount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "AccountForm";
            this.Text = "AccountForm";
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateCreated;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtTell;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvAccount;
        private System.Windows.Forms.CheckedListBox clbRoles;
        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmViewRoles;
        private System.Windows.Forms.ToolStripMenuItem tsmActivityLog;
    }
}