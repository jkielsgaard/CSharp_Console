using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    public class HalloWorld
    {
        /* Made by Jesper Ahasverusen Kielsgaard
         * Date: 22-02-2018
         * 
         * A quick sample how to call a method from another CS file
         */
        public void Say()
        {
            Console.WriteLine("Hallo World"); //JAK - Write Hallo World in the console 
            Console.ReadLine();               //JAK - Await to the user press a key
        }
    }
}
