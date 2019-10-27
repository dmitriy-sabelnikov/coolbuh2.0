using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUI
{
    public partial class Coffee : Form
    {
        private static Coffee coffee = null; 
        private Coffee()
        {
            InitializeComponent();
        }
        public static void Init(string title)
        {
            if(coffee == null)
            {
                int koefWidth = 17;
                coffee = new Coffee();
                coffee.Width = title.Length * koefWidth;
                coffee.lblTitle.Text = title;
                coffee.lblTitle.Left = coffee.Width / 2 - coffee.lblTitle.Width / 2;
                coffee.Show();
                coffee.Refresh();
            }
        }
        public static void Refresh(string title)
        {
            if (coffee == null)
                return;
            coffee.lblTitle.Text = title;
            coffee.lblTitle.Left = coffee.Width / 2 - coffee.lblTitle.Width / 2;
            coffee.Refresh();
        }

        public static void Term()
        {
            if(coffee != null)
                coffee.Dispose();
            coffee = null;
        }
    }
}
