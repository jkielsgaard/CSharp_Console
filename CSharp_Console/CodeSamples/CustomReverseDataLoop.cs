using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    class CustomReverseDataLoop
    {
        /* Made by Jesper Ahasverusen Kielsgaard
         * Date: 02-03-2018
         * 
         * Reverse ForLoop that put data from position 2 to 3, 1 to 2 etc. beforce putting new data into position 0
         */

        public void run()
        {
            // I make 4 empty array CustomInt objects and call it num
            CustomInt[] num = new CustomInt[4]; 

            // Fill num with data
            num[0] = new CustomInt { x = 1, y = 1 };
            num[1] = new CustomInt { x = 2, y = 2 };
            num[2] = new CustomInt { x = 3, y = 3 };
            num[3] = new CustomInt { x = 4, y = 4 };

            // This is only used to print out the data to see the sequences beforce the Forloop/Change
            int c = 0;
            foreach (CustomInt i in num) { if (i != null) { Console.WriteLine(c + "-" + i.x + "" + i.y); c++; } }
            Console.WriteLine();

            // The forloop is a normal forloop i only reverse it and then it will take data from the i before the loop is on (i = i-1)
            for (int i = 4; i >= 0; i--)
            {
                if (i == 0) { num[i] = new CustomInt { x = 0, y = 0 }; }
                else { num[i] = num[i - 1]; }
            }

            // This is only used to print out the data to see the sequences after the Forloop/Change
            c = 0;
            foreach (CustomInt i in num) { if (i != null) { Console.WriteLine(c + "-" + i.x + "" + i.y); c++; } }
        }
    }

    public class CustomInt // Here a make a custom int that contian two int
    {
        public int x;
        public int y;
    }
}
