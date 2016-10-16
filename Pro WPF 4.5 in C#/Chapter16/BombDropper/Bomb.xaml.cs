using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BombDropper
{
    public partial class Bomb : UserControl
    {
        public Bomb()
        {
            InitializeComponent();
        }

        public bool IsFalling
        {
            get;
            set;
        }
    }
}
