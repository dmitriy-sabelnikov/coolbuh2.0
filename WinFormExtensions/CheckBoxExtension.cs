using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormExtensions
{
    public static class CheckBoxExtension
    {
        private static ToolTip tooltip = new ToolTip();
        public static void NecessaryField(this CheckBox checkbox, int paddingWidthTooltip = 0)
        {
            checkbox.GotFocus += (object sender, EventArgs e) =>
            {
                tooltip.Show("Обов'язкове поле для заповнення", checkbox, checkbox.Width + paddingWidthTooltip, 0);
            };

            checkbox.LostFocus += (object sender, EventArgs e) =>
            {
                tooltip.Hide(checkbox);
            };
        }

        public static void IsModifyField(this CheckBox checkbox, Action isModify)
        {
            checkbox.CheckStateChanged += (object sender, EventArgs e) =>
            {
                isModify();
            };
        }
    }
}
