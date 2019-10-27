using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormExtensions
{
    public static class RadioButtonExtension
    {
        public static void IsModifyField(this RadioButton radioButton, Action isModify)
        {
            radioButton.CheckedChanged += (object sender, EventArgs e) =>
            {
                isModify();
            };
        }
    }
}
