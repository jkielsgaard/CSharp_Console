using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// Read and write to windows regDB
    /// </summary>


    public class RegEdit
    {
        /// <summary>
        /// Write / edit regkey
        /// </summary>
        public void SetRegkey()
        {
            Microsoft.Win32.RegistryKey key1;
            key1 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\[PATH]");
            key1.SetValue("[KEY]", "[VALUE]");
            key1.Close();

            // Short sleep to ensure the key has been set
            Console.WriteLine("Please wait...");
            Console.WriteLine("");
            System.Threading.Thread.Sleep(5000);
        }

        /// <summary>
        /// Read value from a regkey
        /// </summary>
        public void GetRegkey()
        {
            string keyValue = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\[PATH]", "[KEY]", null);
        }
    }
}
