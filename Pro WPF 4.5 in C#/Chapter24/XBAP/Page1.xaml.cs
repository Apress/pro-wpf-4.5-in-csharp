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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Security.Permissions;
using System.IO.IsolatedStorage;
using System.Security;

namespace XBAP
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>

    public partial class Page1 : System.Windows.Controls.Page
    {

        public Page1()
        {
            InitializeComponent();
        }

        private void cmdWrite_Click(object sender, RoutedEventArgs e)
        {            
            System.IO.File.WriteAllText("c:\\test.txt", "This isn't allowed.");
        }               

        private void cmdWriteSafely_Click(object sender, RoutedEventArgs e)
        {
            string content = "This is a test";

            // Create a permission that represents writing to a file.
            string filePath = "c:\\highscores.txt";
            FileIOPermission permission = new FileIOPermission(
              FileIOPermissionAccess.Write, filePath);

            // Check for this permission.
            if (CheckPermission(permission))
            {
                // Write to local hard drive.
                try
                {
                    using (FileStream fs = File.Create(filePath))
                    {
                        WriteHighScores(fs, content);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                // Write to isolated storage.
                try
                {
                    IsolatedStorageFile store =
                      IsolatedStorageFile.GetUserStoreForApplication();
                    using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream(
                      "highscores.txt", FileMode.Create, store))
                    {
                        WriteHighScores(fs, content);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void cmdReadSafely_Click(object sender, RoutedEventArgs e)
        {
            string content = "";

            // Create a permission that represents writing to a file.
            string filePath = "c:\\highscores.txt";
            FileIOPermission permission = new FileIOPermission(
              FileIOPermissionAccess.Write, filePath);

            // Check for this permission.
            if (CheckPermission(permission))
            {                
                try
                {
                    using (FileStream fs = File.Open(filePath, FileMode.Open))
                    {
                        content = ReadHighScores(fs);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                // Read from isolated storage.
                try
                {
                    IsolatedStorageFile store =
                      IsolatedStorageFile.GetUserStoreForApplication();
                    using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream(
                      "highscores.txt", FileMode.Open, store))
                    {
                        content = ReadHighScores(fs);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }                
            }

            if (content != "") MessageBox.Show(content);
        }

        // A better implementation would cache this information over the lifetime of the application,
        // so the permission only needs to be evaluated once.
        private bool CheckPermission(CodeAccessPermission requestedPermission)
        {
            try
            {
                // Try to get this permission.
                requestedPermission.Demand();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void WriteHighScores(FileStream fs, string content)
        {
            StreamWriter w = new StreamWriter(fs);
            w.WriteLine(content);
            w.Close();
            fs.Close();
        }

        private string ReadHighScores(FileStream fs)
        {
            StreamReader r = new StreamReader(fs);
            string content = r.ReadToEnd();
            r.Close();
            fs.Close();
            return content;
        }
    }
}