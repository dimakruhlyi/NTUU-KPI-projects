using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace ComServer
{
    public class DBComServer : IFunc, IDataLayer
    {
        public DataTable GetTable(string ConStr, string Table)
        {
            OleDbConnection cn = new OleDbConnection(ConStr);
            cn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM " + Table, cn);
            OleDbDataReader r = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(r);
            cn.Close();
            return dt;
        }

        public List<string> GetTables(string ConStr, string db)
        {
            List<string> ls = new List<string>();
            ls.Clear();
            OleDbConnection cn = new OleDbConnection(ConStr);
            cn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM sys.tables", cn);
            OleDbDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                ls.Add(r.GetString(0));
            }
            cn.Close();
            return ls;
        }

        public double Hypo(double a, double b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

        }

        public double Sum(double a, double b)
        {
            return a + b;
        }
    }
}
