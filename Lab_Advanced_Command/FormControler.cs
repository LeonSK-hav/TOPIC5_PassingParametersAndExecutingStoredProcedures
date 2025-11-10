using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Advanced_Command
{
    public partial class FormControler : Form
    {
        public FormControler()
        {
            InitializeComponent();
            InitializeThemes();
        }

        private void fOODToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FoodForm();
            form.ShowDialog();
        }

        private void oRDERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OrdersForm();
            form.ShowDialog();
        }

        private void aCCOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AccountForm();
            form.ShowDialog();
        }


        private void InitializeThemes()
        {
            comboBoxTheme.Items.AddRange(new string[]
            {
                "Midnight Black",
                "Coffee Brown",
                "Deep Forest",
                "Burgundy Night",
                "Charcoal Steel",
                "Smoky Olive"
            });
            comboBoxTheme.SelectedIndex = 0;
        }

        private void comboBoxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            string theme = comboBoxTheme.SelectedItem.ToString();

            switch (theme)
            {
                case "Midnight Black":
                    ApplyTheme("#121212", "#1F1F1F", "#323232", "#FFFFFF", "#E0E0E0");
                    break;
                case "Coffee Brown":
                    ApplyTheme("#3E2723", "#5D4037", "#4E342E", "#F5F5DC", "#E0C097");
                    break;
                case "Deep Forest":
                    ApplyTheme("#1B1F1A", "#2C352D", "#3E4E3E", "#C2C5AA", "#DAD7CD");
                    break;
                case "Burgundy Night":
                    ApplyTheme("#2C0000", "#4A0E0E", "#6A1B1B", "#FFF5EE", "#EAD0D0");
                    break;
                case "Charcoal Steel":
                    ApplyTheme("#2E2E2E", "#383838", "#4B4B4B", "#EAEAEA", "#CCCCCC");
                    break;
                case "Smoky Olive":
                    ApplyTheme("#3B3A36", "#55524E", "#706C61", "#F0EDE5", "#DFD6C9");
                    break;
            }
        }
        private void ApplyTheme(string formBack, string panelBack, string buttonBack, string buttonText, string fontColor)
        {
            this.BackColor = ColorTranslator.FromHtml(formBack);
            panelHeader.BackColor = ColorTranslator.FromHtml(panelBack);

            ApplyThemeToControls(this.Controls,
                ColorTranslator.FromHtml(buttonBack),
                ColorTranslator.FromHtml(buttonText),
                ColorTranslator.FromHtml(fontColor));
        }

        private void ApplyThemeToControls(Control.ControlCollection controls, Color buttonBack, Color buttonText, Color fontColor)
        {
            foreach (Control c in controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = buttonBack;
                    btn.ForeColor = buttonText;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Transparent;
                }
                else if (c is Label lbl)
                {
                    lbl.ForeColor = fontColor;
                }

                if (c.HasChildren)
                {
                    ApplyThemeToControls(c.Controls, buttonBack, buttonText, fontColor);
                }
            }
        }

    }
}
