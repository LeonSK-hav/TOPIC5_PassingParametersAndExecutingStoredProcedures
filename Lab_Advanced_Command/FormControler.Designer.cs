namespace Lab_Advanced_Command
{
    partial class FormControler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormControler));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fOODToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oRDERSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCCOUNTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.comboBoxTheme = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fOODToolStripMenuItem,
            this.oRDERSToolStripMenuItem,
            this.aCCOUNTToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(935, 54);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fOODToolStripMenuItem
            // 
            this.fOODToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fOODToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fOODToolStripMenuItem.Image")));
            this.fOODToolStripMenuItem.Name = "fOODToolStripMenuItem";
            this.fOODToolStripMenuItem.Size = new System.Drawing.Size(147, 50);
            this.fOODToolStripMenuItem.Text = "FOOD";
            this.fOODToolStripMenuItem.Click += new System.EventHandler(this.fOODToolStripMenuItem_Click);
            // 
            // oRDERSToolStripMenuItem
            // 
            this.oRDERSToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oRDERSToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("oRDERSToolStripMenuItem.Image")));
            this.oRDERSToolStripMenuItem.Name = "oRDERSToolStripMenuItem";
            this.oRDERSToolStripMenuItem.Size = new System.Drawing.Size(179, 50);
            this.oRDERSToolStripMenuItem.Text = "ORDERS";
            this.oRDERSToolStripMenuItem.Click += new System.EventHandler(this.oRDERSToolStripMenuItem_Click);
            // 
            // aCCOUNTToolStripMenuItem
            // 
            this.aCCOUNTToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aCCOUNTToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aCCOUNTToolStripMenuItem.Image")));
            this.aCCOUNTToolStripMenuItem.Name = "aCCOUNTToolStripMenuItem";
            this.aCCOUNTToolStripMenuItem.Size = new System.Drawing.Size(207, 50);
            this.aCCOUNTToolStripMenuItem.Text = "ACCOUNT";
            this.aCCOUNTToolStripMenuItem.Click += new System.EventHandler(this.aCCOUNTToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(657, 95);
            this.label1.TabIndex = 1;
            this.label1.Text = "PLEASE CHOOSE";
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.comboBoxTheme);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Location = new System.Drawing.Point(0, 58);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(935, 509);
            this.panelHeader.TabIndex = 2;
            // 
            // comboBoxTheme
            // 
            this.comboBoxTheme.FormattingEnabled = true;
            this.comboBoxTheme.Location = new System.Drawing.Point(0, 3);
            this.comboBoxTheme.Name = "comboBoxTheme";
            this.comboBoxTheme.Size = new System.Drawing.Size(137, 24);
            this.comboBoxTheme.TabIndex = 2;
            this.comboBoxTheme.SelectedIndexChanged += new System.EventHandler(this.comboBoxTheme_SelectedIndexChanged);
            // 
            // FormControler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 568);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormControler";
            this.Text = "FormControler";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fOODToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oRDERSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCCOUNTToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.ComboBox comboBoxTheme;
    }
}