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
using System.Windows.Media.Media3D;

namespace DrawingIn3D
{
    /// <summary>
    /// Interaction logic for CubeMesh.xaml
    /// </summary>

    public partial class CubeMesh : System.Windows.Window
    {

        public CubeMesh()
        {
            InitializeComponent();
        }

        private Vector3D CalculateNormal(Point3D p0, Point3D p1, Point3D p2)
        {
            Vector3D v0 = new Vector3D(
                p1.X - p0.X, p1.Y - p0.Y, p1.Z - p0.Z);
            Vector3D v1 = new Vector3D(
                p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
            return Vector3D.CrossProduct(v0, v1);
        }

        private void cmd_Click(object sender, RoutedEventArgs e)
        {
            cubeGeometry.Geometry = (Geometry3D)((Button)sender).Tag;
        }
    }
}