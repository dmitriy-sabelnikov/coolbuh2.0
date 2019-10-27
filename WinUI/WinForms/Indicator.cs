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
    public partial class Indicator : Form
    {
        private static Indicator indic;
        private Indicator()
        {
            InitializeComponent();
        }

        public static void Init(string title, int count)
        {
            int koef = 1;
            indic = new Indicator();
            indic.lblIndicator.Text = title;
            indic.pbIndicator.Minimum = 1* koef;
            indic.pbIndicator.Maximum = count* koef;
            indic.pbIndicator.Value = 1* koef;
            indic.pbIndicator.Step = 1* koef;
            indic.Show();
            indic.Refresh();
        }
        public static void Term()
        {
            if (indic == null) return;
            Application.DoEvents();
            indic.Dispose();
            indic = null;
        }
        public static void RefreshTitle(string title)
        {
            if (indic == null) return;
            indic.lblIndicator.Text = title;
            indic.Refresh();
            Application.DoEvents();
        }
        public static void Step()
        {
            if (indic == null) return;
            indic.pbIndicator.PerformStep();
            indic.pbIndicator.Refresh();
            indic.Refresh();
            Application.DoEvents();
        }
    }
}
