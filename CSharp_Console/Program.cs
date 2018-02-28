using CSharp_Console.CodeSamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp_Console
{
    class Program
    {
        /* MADE AND DOCUMENTED THE 22-02-2018 BY
         * Jesper Ahasverusen Kielsgaard
         * 
         * Main will start run method so static is not needed when testing og debugging new codes
         * Call the CodeSample file from the run method so this will be a clean code sample 
         * 
         * Remenber to document what the code due and make notes in codes
         * 
         * Make a new CS file in the "CodeSamples" folder and give it a descriptive name
         * so it's easy to see what the purpose is with it.
         * If there is a CS with that name, put the code inside that and make sure to make new
         * method in it and make it easy to manageable
         * 
         * If the CodeSample file need a dll-file (See if the DLL file is in NuGet packages) or 
         * others files as a CS-file from other developer put them into the "Files" folder and 
         * call them from there and if there is more then one file (eg. one CS-file and one dll-file) 
         * make a folder with a descriptive name to the 
         * 
         * And remenber 
         *   ___ _                              _      _          _  __ _        _    ___         _     
         *  / __| |___ __ _ _ _    __ _ _ _  __| |  __| |__ _ _ _(_)/ _(_)___ __| |  / __|___  __| |___ 
         * | (__| / -_) _` | ' \  / _` | ' \/ _` | / _| / _` | '_| |  _| / -_) _` | | (__/ _ \/ _` / -_)
         *  \___|_\___\__,_|_||_| \__,_|_||_\__,_| \__|_\__,_|_| |_|_| |_\___\__,_|  \___\___/\__,_\___|                                                                                     
         *  _      _  _                        ___         _             
         * (_)___ | || |__ _ _ __ _ __ _  _   / __|___  __| |___        //  \\
         * | (_-< | __ / _` | '_ \ '_ \ || | | (__/ _ \/ _` / -_)      _\\()//_  <-- beware of the bugs
         * |_/__/ |_||_\__,_| .__/ .__/\_, |  \___\___/\__,_\___|     / //  \\ \
         *                  |_|  |_|   |__/                            | \__/ |
         *
         */
        static void Main(string[] args) { Program p = new Program(); p.run(); }

        private void run()
        {
            #region Quick sample how to call a another CS file method
            // Make the to lines and press ctrl+k+c to out comment the code 
            // and ctrl+k+u to make is back again 
            //HalloWorld hw = new HalloWorld();
            //hw.Say();

            CustomReverseDataLoop c = new CustomReverseDataLoop();
            c.run();
            #endregion

            Console.WriteLine();
            Console.Write("Test done - Press any key to exit....");
            Console.ReadLine(); // Pause the console to user press a key
        }
    }
}
