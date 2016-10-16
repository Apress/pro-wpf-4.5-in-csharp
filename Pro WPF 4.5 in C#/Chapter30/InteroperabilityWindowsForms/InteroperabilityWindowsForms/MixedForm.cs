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
    public partial class MixedForm : Form
    {
        public MixedForm()
        {
            InitializeComponent();
        }

        private void MixedForm_Load(object sender, EventArgs e)
        {
            WPFWindowLibrary.UserControl1 control = new WPFWindowLibrary.UserControl1();

            // Create the ElementHost wrapper.
            ElementHost host = new ElementHost();
            host.Child = control;

            // Set the Location and Size explicitly, unless you are using
            // a layout container like FlowLayoutPanel or TableLayoutPanel,
            // or you are using docking.
            //host.Location = new Point(10, 10);
            host.Size = new Size(flowLayoutPanel1.Width, flowLayoutPanel1.Height);

            // Add the ElementHost to the form or another suitable container.
            flowLayoutPanel1.Controls.Add(host);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello from Windows Forms.");
        }
    }
}