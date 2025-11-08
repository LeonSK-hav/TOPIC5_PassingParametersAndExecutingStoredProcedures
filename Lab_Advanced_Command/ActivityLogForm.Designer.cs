namespace Lab_Advanced_Command
{
    partial class ActivityLogForm
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
            this.lstInvoices = new System.Windows.Forms.ListBox();
            this.dgvInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.lblTotalInvoices = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lstInvoices
            // 
            this.lstInvoices.FormattingEnabled = true;
            this.lstInvoices.ItemHeight = 16;
            this.lstInvoices.Location = new System.Drawing.Point(-1, 29);
            this.lstInvoices.Name = "lstInvoices";
            this.lstInvoices.Size = new System.Drawing.Size(238, 500);
            this.lstInvoices.TabIndex = 0;
            this.lstInvoices.SelectedIndexChanged += new System.EventHandler(this.lstInvoices_SelectedIndexChanged);
            // 
            // dgvInvoiceDetails
            // 
            this.dgvInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceDetails.Location = new System.Drawing.Point(243, 29);
            this.dgvInvoiceDetails.Name = "dgvInvoiceDetails";
            this.dgvInvoiceDetails.RowHeadersWidth = 51;
            this.dgvInvoiceDetails.RowTemplate.Height = 24;
            this.dgvInvoiceDetails.Size = new System.Drawing.Size(667, 416);
            this.dgvInvoiceDetails.TabIndex = 1;
            // 
            // lblTotalInvoices
            // 
            this.lblTotalInvoices.AutoSize = true;
            this.lblTotalInvoices.Location = new System.Drawing.Point(369, 472);
            this.lblTotalInvoices.Name = "lblTotalInvoices";
            this.lblTotalInvoices.Size = new System.Drawing.Size(44, 16);
            this.lblTotalInvoices.TabIndex = 2;
            this.lblTotalInvoices.Text = "label1";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(582, 472);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(44, 16);
            this.lblTotalAmount.TabIndex = 3;
            this.lblTotalAmount.Text = "label1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(-4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(44, 16);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "label1";
            // 
            // ActivityLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 533);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotalInvoices);
            this.Controls.Add(this.dgvInvoiceDetails);
            this.Controls.Add(this.lstInvoices);
            this.Name = "ActivityLogForm";
            this.Text = "Nhật ký hoạt động";
            this.Load += new System.EventHandler(this.ActivityLogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstInvoices;
        private System.Windows.Forms.DataGridView dgvInvoiceDetails;
        private System.Windows.Forms.Label lblTotalInvoices;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTitle;
    }
}