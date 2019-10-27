using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormExtensions
{
    public static class ButtonExtension
    {
        static FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        public static void AddOpenFileDialog(this Button button, TextBox textbox)
        {
            textbox.RightToLeft = RightToLeft.No;
            textbox.TextAlign = HorizontalAlignment.Left;
            textbox.ReadOnly = true;

            button.Click += (object sender, EventArgs e) =>
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textbox.Text = folderBrowserDialog.SelectedPath;
                    textbox.Refresh();
                }
            };
        }
        public static void AddButtonOk(this Button button, Form form)
        {
            button.Click += (object sender, EventArgs e) =>
            {
                form.DialogResult = DialogResult.OK;
            };
        }

        public static void AddButtonCancel(this Button button, Form form)
        {
            button.Click += (object sender, EventArgs e) =>
            {
                form.DialogResult = DialogResult.Cancel;
                form.Close();
            };
        }
        public static void IsModifyField(this Button button, Action isModify)
        {
            button.Click += (object sender, EventArgs e) =>
            {
                isModify();
            };
        }

    }
}
