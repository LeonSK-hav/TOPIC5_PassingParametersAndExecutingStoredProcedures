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
    public partial class RolesViewForm : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=Restaurant Management;Integrated Security=True";
        private string accountName;
    
        public RolesViewForm(string account)
        {
            InitializeComponent();
            accountName = account;
        }

        private void RolesViewForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"Phân quyền cho tài khoản: {accountName}";
            LoadRolesStatus();
        }

        private void LoadRolesStatus()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetRolesStatusByAccount", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountName", accountName);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRoles.AutoGenerateColumns = false;
                dgvRoles.DataSource = dt;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            string roleName = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên vai trò mới:", "Thêm vai trò");
            if (string.IsNullOrWhiteSpace(roleName)) return;
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_AddRoles", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleName", roleName);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Thêm vai trò mới thành công!");
                LoadRolesStatus();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1️⃣ Gửi tín hiệu xóa hết role cũ trước (dùng @RoleID = -1 theo SP Fenn đã có)
                    using (SqlCommand cmdClear = new SqlCommand("sp_SaveRolesForAccount", conn))
                    {
                        cmdClear.CommandType = CommandType.StoredProcedure;
                        cmdClear.Parameters.AddWithValue("@AccountName", accountName);
                        cmdClear.Parameters.AddWithValue("@RoleID", -1);
                        cmdClear.Parameters.AddWithValue("@Actived", 0);
                        cmdClear.ExecuteNonQuery();
                    }

                    // 2️⃣ Thêm lại những role được chọn
                    foreach (DataGridViewRow row in dgvRoles.Rows)
                    {
                        bool isChecked = Convert.ToBoolean(row.Cells["IsChecked"].Value);
                        if (isChecked)
                        {
                            int roleId = Convert.ToInt32(row.Cells["ID"].Value);
                            using (SqlCommand cmd = new SqlCommand("sp_SaveRolesForAccount", conn))
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

                MessageBox.Show("Cập nhật vai trò thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRolesStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật vai trò: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
