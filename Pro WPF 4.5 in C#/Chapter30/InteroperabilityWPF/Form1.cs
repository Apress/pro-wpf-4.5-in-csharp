using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace InteroperabilityWPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {          
          
            Window1 win = new Window1();
             win.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

    }
}