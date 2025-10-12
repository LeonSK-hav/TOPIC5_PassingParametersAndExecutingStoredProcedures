using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace Lab_Advanced_Command
{
    public partial class AccountForm : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=Restaurant Management;Integrated Security=True";
        public AccountForm()
        {
            InitializeComponent();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            LoadAllAccounts();
            LoadAllRolesToCheckList();
        }

        private void LoadAllAccounts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetAllAccounts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvAccount.DataSource = dt;
                    dgvAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadAllAccounts: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(kw))
            {
                LoadAllAccounts();
                return;
            }

            SearchAccounts(kw);
        }


        private void SearchAccounts(string keyword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_SearchAccounts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Keyword", keyword);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAccount.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SearchAccounts: " + ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string acc = txtAccountName.Text.Trim();
            string pwd = txtPassword.Text;
            string fullname = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tell = txtTell.Text.Trim();
            DateTime dateCreated = dtpDateCreated.Value;

            if (string.IsNullOrEmpty(acc) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Vui lòng nhập AccountName và Password", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        // Save account (insert)
                        using (SqlCommand cmd = new SqlCommand("sp_SaveAccount", conn, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@AccountName", acc);
                            cmd.Parameters.AddWithValue("@Password", pwd);
                            cmd.Parameters.AddWithValue("@FullName", fullname);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Tell", tell);
                            cmd.Parameters.AddWithValue("@DateCreated", dateCreated);
                            cmd.ExecuteNonQuery();
                        }

                        // Save roles for this account
                        SaveRolesForAccount(conn, tran, acc);

                        // Optionally set Actived flag based on checked roles or checkbox - in sp_GetAllAccounts Actived is derived from RoleAccount,
                        // but if you have a direct Account.Actived column, you'd update it here as well.
                        // Commit transaction
                        tran.Commit();
                    }
                    conn.Close();
                }

                MessageBox.Show("Thêm tài khoản + vai trò thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllAccounts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string acc = txtAccountName.Text.Trim();
            if (string.IsNullOrEmpty(acc))
            {
                MessageBox.Show("Chưa chọn tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullname = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tell = txtTell.Text.Trim();
            DateTime dateCreated = dtpDateCreated.Value;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        // Save/update account
                        using (SqlCommand cmd = new SqlCommand("sp_SaveAccount", conn, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@AccountName", acc);
                            cmd.Parameters.AddWithValue("@Password", DBNull.Value); // no change
                            cmd.Parameters.AddWithValue("@FullName", fullname);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Tell", tell);
                            cmd.Parameters.AddWithValue("@DateCreated", dateCreated);
                            cmd.ExecuteNonQuery();
                        }

                        // Save roles for this account (will insert/update Actived)
                        SaveRolesForAccount(conn, tran, acc);

                        tran.Commit();
                    }
                    conn.Close();
                }

                MessageBox.Show("Cập nhật tài khoản + vai trò thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string acc = txtAccountName.Text.Trim();
            if (string.IsNullOrEmpty(acc))
            {
                MessageBox.Show("Chưa chọn tài khoản để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa tài khoản '{acc}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteAccount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountName", acc);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Xóa thành công!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllAccounts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow row = dgvAccount.Rows[e.RowIndex];

                string acc = row.Cells["AccountName"].Value?.ToString();
                txtAccountName.Text = acc ?? "";
                txtFullName.Text = row.Cells["FullName"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtTell.Text = row.Cells["Tell"].Value?.ToString() ?? "";
                txtPassword.Clear();

                // DateCreated safe handling
                if (row.Cells["DateCreated"] != null && row.Cells["DateCreated"].Value != DBNull.Value)
                {
                    DateTime dtCreated;
                    if (DateTime.TryParse(row.Cells["DateCreated"].Value.ToString(), out dtCreated))
                        dtpDateCreated.Value = dtCreated;
                    else
                        dtpDateCreated.Value = DateTime.Now;
                }
                else
                {
                    dtpDateCreated.Value = DateTime.Now;
                }

                // Load roles checked state for this account
                LoadRolesByAccount(acc);

                // Active status
                CheckAccountActiveStatus(acc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi click vào hàng: " + ex.Message);
            }
        }
        // ----------------------- Roles list (CheckedListBox) -----------------------
        private void LoadAllRolesToCheckList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetAllRoles", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind full list to CheckedListBox
                    clbRoles.DataSource = null; // 👈 reset trước
                    clbRoles.Items.Clear();
                    clbRoles.DataSource = dt;
                    clbRoles.DisplayMember = "RoleName";
                    clbRoles.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadAllRolesToCheckList: " + ex.Message);
            }
        }

        // Load checked state for a specific account (uses sp_GetRolesStatusByAccount)
        private void LoadRolesByAccount(string accountName)
        {
            if (string.IsNullOrEmpty(accountName)) return;

            try
            {
                // First uncheck all
                for (int i = 0; i < clbRoles.Items.Count; i++)
                    clbRoles.SetItemChecked(i, false);

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetRolesStatusByAccount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountName", accountName);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // dt has columns: ID, RoleName, IsChecked
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int roleId = Convert.ToInt32(dt.Rows[i]["ID"]);
                        bool isChecked = Convert.ToInt32(dt.Rows[i]["IsChecked"]) == 1;

                        // find index in clbRoles by value
                        for (int j = 0; j < clbRoles.Items.Count; j++)
                        {
                            var drv = clbRoles.Items[j] as DataRowView;
                            if (drv != null && drv["ID"] != DBNull.Value && Convert.ToInt32(drv["ID"]) == roleId)
                            {
                                clbRoles.SetItemChecked(j, isChecked);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi LoadRolesByAccount: " + ex.Message);
            }
        }


        // ----------------------- Active status -----------------------
        private void CheckAccountActiveStatus(string accountName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetAccountActiveStatus", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountName", accountName);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    conn.Close();

                    bool isActive = result != null && Convert.ToInt32(result) == 1;
                    chkActive.Checked = isActive;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CheckAccountActiveStatus: " + ex.Message);
            }
        }

        // ----------------------- Save roles helper -----------------------
        // Save all roles states for given account inside an existing open connection/transaction
        private void SaveRolesForAccount(SqlConnection conn, SqlTransaction tran, string accountName)
        {
            using (SqlCommand cmdClear = new SqlCommand("sp_SaveRolesForAccount", conn, tran))
            {
                cmdClear.CommandType = CommandType.StoredProcedure;
                cmdClear.Parameters.AddWithValue("@AccountName", accountName);
                cmdClear.Parameters.AddWithValue("@RoleID", -1);
                cmdClear.Parameters.AddWithValue("@Actived", 0);
                cmdClear.ExecuteNonQuery();
            }

            // Sau đó lưu lại các vai trò được check
            for (int i = 0; i < clbRoles.Items.Count; i++)
            {
                var drv = clbRoles.Items[i] as DataRowView;
                if (drv == null) continue;

                int roleId = Convert.ToInt32(drv["ID"]);
                bool isChecked = clbRoles.GetItemChecked(i);

                if (isChecked)
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SaveRolesForAccount", conn, tran))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountName", accountName);
                        cmd.Parameters.AddWithValue("@RoleID", roleId);
                        cmd.Parameters.AddWithValue("@Actived", 1);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        private void ClearFields()
        {
            txtAccountName.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtTell.Clear();
            txtPassword.Clear();
            chkActive.Checked = false;
            dtpDateCreated.Value = DateTime.Now;

            // Uncheck roles
            for (int i = 0; i < clbRoles.Items.Count; i++)
                clbRoles.SetItemChecked(i, false);
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            string newRole = Interaction.InputBox("Nhập tên vai trò mới:", "Thêm vai trò", "");


            // Nếu người dùng nhấn Cancel hoặc để trống => bỏ qua
            if (string.IsNullOrWhiteSpace(newRole))
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_AddRoles", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoleName", newRole.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm vai trò mới thành công!");

                // Load lại danh sách vai trò
                LoadAllRolesToCheckList();

                // Auto-check luôn vai trò vừa thêm
                int index = clbRoles.Items.IndexOf(newRole.Trim());
                if (index >= 0)
                    clbRoles.SetItemChecked(index, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm vai trò: " + ex.Message);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = txtAccountName.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Chưa chọn tài khoản để đổi mật khẩu!");
                return;
            }

            using (var frm = new frmChangePassword(username))
            {
                frm.ShowDialog();
            }
        }
    }
}
