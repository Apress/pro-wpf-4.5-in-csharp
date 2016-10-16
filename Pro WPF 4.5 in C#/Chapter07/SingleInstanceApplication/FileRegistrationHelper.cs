using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;

namespace SingleInstanceApplication
{
    public class FileRegistrationHelper
    {
        public static void SetFileAssociation(string extension, string progID)
        {
            // Create extension subkey
            SetValue(Registry.ClassesRoot, extension, progID);

            // Create progid subkey
            string assemblyFullPath = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("/", @"\");
            StringBuilder sbShellEntry = new StringBuilder();
            sbShellEntry.AppendFormat("\"{0}\" \"%1\"", assemblyFullPath);
            SetValue(Registry.ClassesRoot, progID + @"\shell\open\command", sbShellEntry.ToString());
            StringBuilder sbDefaultIconEntry = new StringBuilder();
            sbDefaultIconEntry.AppendFormat("\"{0}\",0", assemblyFullPath);
            SetValue(Registry.ClassesRoot, progID + @"\DefaultIcon", sbDefaultIconEntry.ToString());

            // Create application subkey
            SetValue(Registry.ClassesRoot, @"Applications\" + Path.GetFileName(assemblyFullPath), "", "NoOpenWith");
        }

        private static void SetValue(RegistryKey root, string subKey, object keyValue)
        {
            SetValue(root, subKey, keyValue, null);
        }
        private static void SetValue(RegistryKey root, string subKey, object keyValue, string valueName)
        {
            bool hasSubKey = ((subKey != null) && (subKey.Length > 0));
            RegistryKey key = root;

            try
            {
                if (hasSubKey) key = root.CreateSubKey(subKey);
                key.SetValue(valueName, keyValue);
            }
            finally
            {
                if (hasSubKey && (key != null)) key.Close();
            }
        }
    }            
}
