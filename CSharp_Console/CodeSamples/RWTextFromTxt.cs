using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// Simple txt reader and writer
    /// </summary>

    public class RWTextFromTxt
    {
        public void Read(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string line = lines[0];
        }

        public void Write(string filePath, string[] text)
        {
            File.WriteAllLines(filePath, text);
        }
    }
}
