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

namespace Lab_Advanced_Command
{
    public partial class frmChangePassword : Form
    {
        private string username;
        private string connectionString = "Data Source=.;Initial Catalog=Restaurant Management;Integrated Security=True";
        public frmChangePassword(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra input
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }

            // 2. Kiểm tra mật khẩu cũ
            if (!CheckOldPassword(username, txtOldPassword.Text))
            {
                MessageBox.Show("Mật khẩu cũ không đúng!");
                return;
            }

            // 3. Cập nhật mật khẩu mới
            UpdatePassword(username, txtNewPassword.Text);
            MessageBox.Show("Đổi mật khẩu thành công!");
            this.Close();
        }


        private bool CheckOldPassword(string username, string oldPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_CheckOldPassword", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@OldPassword", oldPassword);

                conn.Open();
                var result = cmd.ExecuteScalar();
                return result != null && Convert.ToInt32(result) == 1;
            }
        }

        private void UpdatePassword(string username, string newPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdatePassword", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@NewPassword", newPassword);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
