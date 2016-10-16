using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XBAP
{
    public partial class UserNameWinForm : Form
    {
        public UserNameWinForm()
        {
            InitializeComponent();
        }

        public string UserName
        {
            get { return txtName.Text; }
        }
    }
}