using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormExtensions
{
    public static class ComboBoxExtension
    {
        public static void IsModifyField(this ComboBox combobox, Action isModify)
        {
            combobox.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                isModify();
            };
        }
    }
}
