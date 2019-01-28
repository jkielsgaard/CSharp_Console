using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// SQLite samples
    /// </summary>

    public class SQLite
    {
        /// <summary>
        /// create SQLite db
        /// </summary>
        public SQLite()
        {
            if (!File.Exists("DB.sqlite"))
            {
                SQLiteConnection.CreateFile("DB.sqlite");
                ExecuteNonQuery("CREATE TABLE Reminder_Table (Ordrenr NUM PRIMARY KEY, GID TEXT, Mail TEXT, Count NUM)");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordrenr"></param>
        /// <param name="GID"></param>
        /// <param name="Mail"></param>
        /// <param name="Count"></param>
        public void Write(string ordrenr, string GID, string Mail, string Count)
        {
            ExecuteNonQuery("INSERT INTO Reminder_Table (Ordrenr, GID, Mail, Count) VALUES ('" + ordrenr + "', '" + GID + "', '" + Mail + "', '" + Count + "')");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordrenr"></param>
        /// <param name="Count"></param>
        public void WriteReminder(string ordrenr, string Count)
        {
            ExecuteNonQuery("UPDATE Reminder_Table SET Count='" + Count + "' WHERE Ordrenr='" + ordrenr + "'");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordrenr"></param>
        /// <param name="DBinfo"></param>
        /// <returns></returns>
        public string Read(string ordrenr, string DBinfo)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=DB.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM Reminder_Table WHERE Ordrenr='" + ordrenr + "'";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            string dbinfo = "";
            while (reader.Read()) { dbinfo = reader[DBinfo].ToString(); }
            m_dbConnection.Close();
            return dbinfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryString"></param>
        private static void ExecuteNonQuery(string queryString)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=DB.sqlite;Version=3;");
            using (var connection = new SQLiteConnection(m_dbConnection))
            {
                using (var command = new SQLiteCommand(queryString, connection))
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }
    }
}
