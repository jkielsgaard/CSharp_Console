using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// TCP Network socket to create server and client side
    /// send and receive data
    /// still under construction
    /// </summary>

    public class NetworkSocket
    {
        Crypt c = new Crypt();
        string csk = "1af56d3ef9b343cda65c8e68240b410350be26467614fea48c8c85dac636cfec76a5d6cce11345251e7be614215d1e12400f653e63ab94cdfbc2999637032c0e";

        /// <summary>
        /// This is where the request/command is send to the client
        /// </summary>
        /// <param name="ClientIP">IP Adress on the client</param>
        /// <param name="request">The request</param>
        /// <param name="AdminPassword">Admin password</param>
        /// <returns></returns>
        private string Request(string ServerIP, string request, string AdminPassword)
        {
            TcpClient ClientSocket = new TcpClient();

            try { ClientSocket.Connect(ServerIP, 9494); }
            catch (Exception ex)
            {
                return ex.ToString();
                //if (ex.ErrorCode == 10061 || ex.ErrorCode == 10060 || ex.ErrorCode == 10065) { checkConnection = false; }
                //else { log.Event("SocketException - Connection to Server >> [" + ex.ErrorCode + "] " + ex.ToString(), true); }
            }

            try
            {
                bool aWaitServer = false;
                while (aWaitServer == false) { if ("CR" == ReceiveData(ClientSocket)) { aWaitServer = true; } }
                SendData(Environment.UserName.ToUpper() + "~" + AdminPassword + "|" + request, ClientSocket);
                string Data = ReceiveData(ClientSocket);
                ClientSocket.Close();
                return Data;

            }
            catch (IOException ex)
            {
                if (ex.HResult == -2146232800) { }
                else { return ex.ToString(); } //log.Event("IOException - Send data to server >> " + ex.ToString(), true); }
            }

            return null;
        }

        /// <summary>
        /// TCP socket send function
        /// </summary>
        /// <param name="data">The data (string) needed to send to the client</param>
        /// <param name="ClientSocket">Clients socket predefined when connection to the client</param>
        private void SendData(string data, TcpClient ClientSocket)
        {
            string Encrypt = c.Encrypt(data, csk);

            NetworkStream NetworkStream = ClientSocket.GetStream();
            byte[] outStream = Encoding.ASCII.GetBytes(Encrypt + "$");
            NetworkStream.Write(outStream, 0, outStream.Length);
            NetworkStream.Flush();
        }

        /// <summary>
        /// TCP socket receive function
        /// </summary>
        /// <param name="ClientSocket" > Clients socket predefined when connection to the client</param>
        /// <returns>Client will return a message if the command was successful receive and complete the request</returns>
        private string ReceiveData(TcpClient ClientSocket)
        {
            NetworkStream NetworkStream = ClientSocket.GetStream();
            byte[] InStream = new byte[10025];
            NetworkStream.Read(InStream, 0, InStream.Length);
            string data = Encoding.ASCII.GetString(InStream);
            data = data.Substring(0, data.IndexOf("$"));

            string Decrypt = c.Decrypt(data, csk);

            return Decrypt;
        }
    }
}


/// <summary>
/// 
///  Developed by:
///  Name:   Jesper Kielsgaard
///  GID:    Z003DFRU
///  Mail:   Jesper.Kielsgaard@siemensgamesa.com
///  Phone:  30 67 79 01
/// 
///  TCPAdminRequest class is a to create a connection between CM userinterface and the CM client, so the admin send a command
///  request eg. if the admin what to opgrade som software on clients, the admin send a powershell script to the client and 
///  the client will run it
/// 
/// </summary>


//public class TCPAdminRequest
//{
//    Log log = new Log();
//    TCP_Commands com = new TCP_Commands();
//    Crypt c = new Crypt();

//    TcpClient ClientSocket;


//    string csk = "1af56d3ef9b343cda65c8e68240b410350be26467614fea48c8c85dac636cfec76a5d6cce11345251e7be614215d1e12400f653e63ab94cdfbc2999637032c0e";


//    /// <summary>
//    /// If an admin is conncetion to the client
//    /// </summary>
//    /// <param name="inClientSocket">the tdcclient network socket parameter</param>
//    public void startClient(TcpClient inClientSocket)
//    {
//        this.ClientSocket = inClientSocket;
//        Thread ctThread = new Thread(() => doWork());
//        ctThread.Start();
//    }

//    /// <summary>
//    /// When a admin is connection the client will send a accept message back and write in the log that an
//    /// admin is connected
//    /// </summary>
//    private void doWork()
//    {
//        log.Event("TCP Services - Admin Connected >> [" + ClientSocket.Client.RemoteEndPoint + "]", false);

//        try
//        {
//            SendData("CR");
//            string Data = ReceiveData();
//            string[] request = Data.Split('|');
//            log.Event("TCP Services - Admin Request >> [" + request[0].Split('~')[0] + "][" + request[2] + "]", false);
//            string Status = com.Command_Switch(request);
//            SendData(Status);

//            ClientSocket.Close();
//        }
//        catch (IOException ex) { log.Event("DoWork - IOException >> " + ex.ToString(), true); }
//        catch (Exception ex) { log.Event("DoWork - Exception >> " + ex.ToString(), true); }
//        finally
//        {
//        }
//    }

//    /// <summary>
//    /// sending data over network socket
//    /// </summary>
//    /// <param name="data">the string data that need to be send</param>
//    private void SendData(string data)
//    {
//        string Encrypt = c.Encrypt(data, csk);
//        NetworkStream NetworkStream = ClientSocket.GetStream();
//        byte[] outStream = Encoding.ASCII.GetBytes(Encrypt + "$");
//        NetworkStream.Write(outStream, 0, outStream.Length);
//        NetworkStream.Flush();
//    }

//    /// <summary>
//    /// if a client is receiving data from the connected admin
//    /// </summary>
//    /// <returns>the return string from the connected admin</returns>
//    private string ReceiveData()
//    {
//        NetworkStream NetworkStream = ClientSocket.GetStream();
//        byte[] InStream = new byte[10025];
//        NetworkStream.Read(InStream, 0, InStream.Length);
//        string data = Encoding.ASCII.GetString(InStream);
//        data = data.Substring(0, data.IndexOf("$"));
//        string Decrypt = c.Decrypt(data, csk);
//        return Decrypt;
//    }
//}


///// <summary>
///// class to control the command the client can accept
///// </summary>
//public class TCP_Commands
//{
//    Log log = new Log();
//    Active_Directory AD = new Active_Directory();
//    string[] UserCredentials;

//    /// <summary>
//    /// when receiving data from connected admin it will go through this command_switch to check
//    /// witch command the admin is requesting
//    /// </summary>
//    /// <param name="request">the request string with all the parameter into it</param>
//    /// <returns></returns>
//    public string Command_Switch(string[] request)
//    {
//        UserCredentials = request[0].Split('~');

//        if (AD.MembershipCheck(UserCredentials[0]))
//        {
//            switch (request[1].ToUpper())
//            {
//                case "POWERSHELL":
//                    RunProcess(@"C:\WINDOWS\system32\WindowsPowerShell\v1.0\powershell.exe", " -file \"" + request[2] + "\"", true);
//                    return "Request_Done";
//                case "BATCH":
//                    RunProcess(@"C:\Windows\System32\cmd.exe", "/c " + request[2], true);
//                    return "Request_Done";
//                default:
//                    return "Request_not_exist";
//            }
//        }
//        return "AccessDenied";
//    }

//    /// <summary>
//    /// not in use yet, the idea was if the function need to copy files into to the client it need to
//    /// be delete agian
//    /// </summary>
//    /// <param name="_FileName">the name on the file that need to be deleted</param>
//    private void DeleteFile(string _FileName) { File.Delete(_FileName); }

//    /// <summary>
//    /// The process that will run the script the admin is sending to request the client need to run
//    /// </summary>
//    /// <param name="_FileName">Witch program that need to run (for now that is either Powershell ps1 files or cmd bacth files)</param>
//    /// <param name="_Arguments">the argument for running a file</param>
//    /// <param name="_Hide">do the process need to be hidden</param>
//    private void RunProcess(string _FileName, string _Arguments, bool _Hide)
//    {
//        using (UserImpersonation user = new UserImpersonation(UserCredentials[0], "AD009", UserCredentials[1]))
//        {
//            ProcessStartInfo Info = new ProcessStartInfo();
//            Info.FileName = _FileName;
//            Info.Arguments = _Arguments;

//            if (_Hide) { Info.WindowStyle = ProcessWindowStyle.Hidden; }

//            Process process = new Process();
//            process.StartInfo = Info;
//            process.Start();

//            process.WaitForExit();
//        }
//    }
//}


//#region TCP services
///// <summary>
///// to make a network socket connection to the server
///// </summary>
//private void TCP_Services()
//{
//    ServerSocket = new TcpListener(IPAddress.Any, 9494);
//    TcpClient ClientSocket = default(TcpClient);
//    ServerSocket.Start();

//    while (ClientRun)
//    {
//        ClientSocket = ServerSocket.AcceptTcpClient();
//        TCPAdminRequest client = new TCPAdminRequest();
//        client.startClient(ClientSocket);
//    }
//}
//#endregion
