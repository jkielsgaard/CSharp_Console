using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// A quick sample how to call a method from another CS file
    /// </summary>

    public class HalloWorld
    {
        public void Say()
        {
            Console.WriteLine("Hallo World"); //JAK - Write Hallo World in the console 
            Console.ReadLine();               //JAK - Await to the user press a key
        }
    }
}
