using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Students
{
    public class Db
    {
        //local variables
        public string _server = "";
        public string _user = "";
        public string _pw = "";
        public string _db = "";
        public MySqlDataReader reader;
        public MySqlConnection conn = new MySqlConnection();

        public static Db d = new Db();

        public bool Connect()
        {
            string server_string;
            server_string = "server = " + this._server +
                          ";username = " + this._user +
                          ";password = " + this._pw +
                          ";database =" + this._db;
            this.conn.ConnectionString = server_string;

            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex) { throw ex; }
            
        }

        public void ExecuteNonReader(string sql)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.Connection = this.conn;
                comm.CommandText = sql;
                comm.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
        }

        public MySqlDataReader Execute(string sql)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.Connection = this.conn;
                comm.CommandText = sql;
                this.reader = comm.ExecuteReader();
            }
            catch (Exception ex) { throw ex; };

            return this.reader;
        }
    }
}
