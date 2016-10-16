using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace InteroperabilityWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdShowWrong_Click(object sender, EventArgs e)
        {
            WPFWindowLibrary.Window1 win = new WPFWindowLibrary.Window1();
            win.Show();
        }

        private void cmdShowRight_Click(object sender, EventArgs e)
        {
            WPFWindowLibrary.Window1 win = new WPFWindowLibrary.Window1();
            ElementHost.EnableModelessKeyboardInterop(win);
            win.Show();
        }

        private void cmdShowMixedForm_Click(object sender, EventArgs e)
        {
            MixedForm form = new MixedForm();
            form.Show();
        }
    }
}