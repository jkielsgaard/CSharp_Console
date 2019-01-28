using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// Send data over COMPort, has been used for arduino projects
    /// </summary>

    public class SerialComPort
    {
        public void Send()
        {
            SerialPort COMPORT = new SerialPort("COM40");

            COMPORT.BaudRate = 9600;
            COMPORT.Open();

            while (true)
            {
                string L01 = "                          ";
                string L02 = " TEST                     ";
                string L03 = "                          ";
                string L04 = " SEND DATA TO COMPORT     ";
                string L05 = "                          ";


                string FullLine = L01 + L02 + L03 + L04 + L05 + "\n";
                COMPORT.Write(FullLine);
                System.Threading.Thread.Sleep(5000);
            }
        }
    }
}
