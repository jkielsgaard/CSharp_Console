using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    class CustomReverseDataLoop
    {
        public void run()
        {
            arrayint[] num = new arrayint[1444];

            num[0] = new arrayint { x = 1, y = 1 };
            num[1] = new arrayint { x = 2, y = 2 };
            num[2] = new arrayint { x = 3, y = 3 };
            num[3] = new arrayint { x = 4, y = 4 };

            int c = 0;
            foreach (arrayint i in num) { if (i != null) { Console.WriteLine(c + "-" + i.x + "" + i.y); c++; } }

            Console.WriteLine();

            for (int i = 1443; i >= 0; i--)
            {
                if (i == 0) { num[i] = new arrayint { x = 0, y = 0 }; }
                else { num[i] = num[i - 1]; }
            }

            c = 0;
            foreach (arrayint i in num) { if (i != null) { Console.WriteLine(c + "-" + i.x + "" + i.y); c++; } }

        }
    }

    public class arrayint
    {
        public int x;
        public int y;
    }
}
