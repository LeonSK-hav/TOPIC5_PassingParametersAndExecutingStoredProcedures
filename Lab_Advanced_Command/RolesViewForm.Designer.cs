namespace Lab_Advanced_Command
{
    partial class RolesViewForm
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
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRoles
            // 
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.RoleName,
            this.IsChecked});
            this.dgvRoles.Location = new System.Drawing.Point(2, 36);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.RowHeadersWidth = 51;
            this.dgvRoles.RowTemplate.Height = 24;
            this.dgvRoles.Size = new System.Drawing.Size(797, 398);
            this.dgvRoles.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // RoleName
            // 
            this.RoleName.DataPropertyName = "RoleName";
            this.RoleName.HeaderText = "Tên phân quyền";
            this.RoleName.MinimumWidth = 6;
            this.RoleName.Name = "RoleName";
            this.RoleName.Width = 125;
            // 
            // IsChecked
            // 
            this.IsChecked.DataPropertyName = "IsChecked";
            this.IsChecked.HeaderText = "Active";
            this.IsChecked.MinimumWidth = 6;
            this.IsChecked.Name = "IsChecked";
            this.IsChecked.Width = 125;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAddNew);
            this.panel1.Location = new System.Drawing.Point(2, 440);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 100);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(578, 28);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 45);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(322, 28);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(151, 45);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(78, 28);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(151, 45);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "Thêm mới";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(44, 16);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "label1";
            // 
            // RolesViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 541);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvRoles);
            this.Name = "RolesViewForm";
            this.Text = "Danh sách vai trò";
            this.Load += new System.EventHandler(this.RolesViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChecked;
    }
}