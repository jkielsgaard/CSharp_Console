using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// "Old School" SQL handling
    /// </summary>

    public class SQL
    {
        string ConnectionString { get { return "Server=[SERVER];Database=[DB];Trusted_Connection=True"; } }

        /// <summary>
        /// Check connection string
        /// </summary>
        /// <returns></returns>
        public bool OpenConnecting()
        {
            try
            {
                using (SqlConnection SQLcon = new SqlConnection(ConnectionString)) { SQLcon.Open(); }
                return true;
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string SELECT(string ID, string data)
        {
            try
            {
                using (SqlConnection SQLcon = new SqlConnection(ConnectionString))
                {
                    SQLcon.Open();
                    using (SqlCommand SQLcmd = new SqlCommand("SELECT * FROM [] WHERE []='" + ID + "'", SQLcon))
                    {
                        string SQLdata = null;
                        using (SqlDataReader Reader = SQLcmd.ExecuteReader())
                        {
                            while (Reader.Read()) { SQLdata = Reader[data].ToString(); }
                            SQLdata = SQLdata.Trim();
                            return SQLdata;
                        }
                    }
                }
            }
            catch (Exception ex) { throw new Exception("SQL - SELECT - Error: " + ex); ; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Idea"></param>
        /// <param name="Description"></param>
        /// <param name="BuildType"></param>
        /// <param name="Priority"></param>
        public void INSERT(string Idea, string Description, string BuildType, string Priority)
        {
            try
            {
                using (SqlConnection SQLcon = new SqlConnection(ConnectionString))
                {
                    SQLcon.Open();
                    using (SqlCommand SQLcmd = new SqlCommand("INSERT INTO [] ([DATA]) VALUES ([VALUE])", SQLcon))
                    {
                        SQLcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw new Exception("SQL - INSERT - Error: " + ex); ; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        public void DELETE(string ID)
        {
            try
            {
                using (SqlConnection SQLcon = new SqlConnection(ConnectionString))
                {
                    SQLcon.Open();
                    using (SqlCommand SQLcmd = new SqlCommand("DELETE FROM [] WHERE ID LIKE '" + ID + "%'", SQLcon)) { SQLcmd.ExecuteNonQuery(); }
                }
            }
            catch (Exception ex) { throw new Exception("SQL - DELETE - Error: " + ex); ; }
        }
    }
}
