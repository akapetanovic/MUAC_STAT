using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MUAC_STAT
{
    public class MySqlCalculatedDataHandler
    {
        private string connString;
        private MySqlConnection MySQLconn;

        public class MySQLConnection
        {
            public static string login_name = Properties.Settings.Default.MySqlLogin;
            public static string server_name = Properties.Settings.Default.MySqlServer;
            public static string database = Properties.Settings.Default.MySqlDatabase;
            public static string table_name = Properties.Settings.Default.Calculated_Table;
        }

        public void CloseConnection()
        {
            if (MySQLconn != null)
                MySQLconn.Close();
        }
        public void Commit_One_Flight(CalculatedDataSet Data_Set_One_Flight)
        {
            //OID, ARCID, IFPLID, ADEP, ADES, EOBD, EOBT, ARCTYPE, REG, ARCADDR, F15, FLAG, TSTARTTIME, TENDTIME, TPOINTS, FLTSOURCE, FLTSTATE, LASTUPD, STATUS, CBSFLTSTATE
            string query = "INSERT INTO " + MySQLConnection.table_name +
                " (OID, ARCID_IFPLID, AORENTRYTIME, AOREXITTIME, AORENTRYPOINT, AOREXITPOINT, MULTYAOR, FPL_Time) " +
                " VALUES (" + Get_With_Quitation(Data_Set_One_Flight.OID) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.ARCID_IFPLID) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.AORENTRYTIME) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.AOREXITTIME) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.AORENTRYPOINT) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.AOREXITPOINT) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.MULTYAOR) + "," +
                              Get_With_Quitation(Data_Set_One_Flight.FPL_Time) + ")";

            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, MySQLconn);

            try
            {
                //Execute command
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private string Get_With_Quitation(string String_IN)
        {
            return "'" + String_IN + "'";
        }

        private string GetTimeAS_HHMM(DateTime Time_In)
        {
            return Time_In.Hour.ToString("00") + Time_In.Minute.ToString("00");
        }

        public void ClearTable()
        {
            string query = "DELETE FROM " + MySQLConnection.table_name;
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, MySQLconn);

            try
            {
                //Execute command
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public bool Initialise_Calculated()
        {
            // Set the connection string
            connString = "server=" + MySQLConnection.server_name +
               ";User Id=" + MySQLConnection.login_name + ";database=" + MySQLConnection.database;

            // Open up the connection
            MySQLconn = new MySqlConnection(connString);

            if (MySQLconn != null)
            {
                if (MySQLconn.State == System.Data.ConnectionState.Open)
                {
                    MySQLconn.Close();
                }

                // Set the connection string
                connString = "server=" + MySQLConnection.server_name +
                   ";User Id=" + MySQLConnection.login_name + ";database=" + MySQLConnection.database;

                // Open up the connection
                MySQLconn = new MySqlConnection(connString);

                try
                {
                    MySQLconn.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
