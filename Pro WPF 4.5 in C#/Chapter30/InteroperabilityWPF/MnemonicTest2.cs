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
    public partial class MnemonicTest2 : Form
    {
        public MnemonicTest2()
        {
            InitializeComponent();
        }

        private void MnemonicTest2_Load(object sender, EventArgs e)
        {
            ElementHost host = new ElementHost();
            System.Windows.Controls.Button button = new System.Windows.Controls.Button();
            button.Content = "Alt+_A";
            host.Child = button;
            button.Click += button1_Click;
            button.PreviewKeyDown += button_preview;
            host.Location = new Point(10, 10);
            host.Size = new Size(100, 50);
            this.Controls.Add(host);
        }

        private void button_preview(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = true;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }
    }
}