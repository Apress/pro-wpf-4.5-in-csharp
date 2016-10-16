using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LayoutPanels
{
    /// <summary>
    /// Interaction logic for SimpleInkCanvas.xaml
    /// </summary>

    public partial class SimpleInkCanvas : System.Windows.Window
    {

        public SimpleInkCanvas()
        {
            InitializeComponent();

            
			foreach (InkCanvasEditingMode mode in Enum.GetValues(typeof(InkCanvasEditingMode)))
			{
                lstEditingMode.Items.Add(mode);
                lstEditingMode.SelectedItem = inkCanvas.EditingMode;
            }
        }

    }
}