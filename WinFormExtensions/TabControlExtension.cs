using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormExtensions
{
    public static class TabControlExtension
    {
        public static void SetLeftTabs(this TabControl tabControl, int widthTab, int heigthTab)
        {
            tabControl.Alignment = TabAlignment.Left;
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.ItemSize = new System.Drawing.Size(widthTab, heigthTab);
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += (object sender, DrawItemEventArgs e) =>
            {
                Graphics g = e.Graphics;

                string _tabText = tabControl.TabPages[e.Index].Text;
                Font _tabFont = tabControl.TabPages[e.Index].Font;
                Brush _tabBrush = new SolidBrush(Color.Black);
                Rectangle _tabBounds = tabControl.GetTabRect(e.Index);
                //Выравнивание текста по центру
                StringFormat _stringFlags = new StringFormat();
                _stringFlags.Alignment = StringAlignment.Center;
                _stringFlags.LineAlignment = StringAlignment.Center;

                g.DrawString(_tabText, _tabFont, _tabBrush, _tabBounds, new StringFormat(_stringFlags));
            };
        }
    }
}
