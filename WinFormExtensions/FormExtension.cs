using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormExtensions
{
    public static class FormExtension
    {
        public static void BaseFormStyle(this Form form, string name)
        {
            form.StartPosition = FormStartPosition.CenterParent;
            form.Text = name;
        }

        public static void SingleFormMode(this Form form, Form owner)
        {
            form.Load += (object sender, EventArgs e) =>
            {
                if (owner != null)
                {
                    owner.Visible = false;
                    form.Location = owner.Location;
                    form.Width = owner.Width;
                    form.Height = owner.Height;
                    form.MaximizeBox = owner.MaximizeBox;
                }
            };
            form.FormClosed += (object sender, FormClosedEventArgs e) =>
            {
                if (owner != null)
                {
                    owner.Visible = true;
                }
            };
        }
    }
}
