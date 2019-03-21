using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebReportViewer
{
    public class clsData
    {
        public static DataTable getData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("NOMBRE", typeof(string));
            dt.Rows.Add("1", "MARCO AYALA 1");
            dt.Rows.Add("1", "MARCO AYALA 2");
            dt.Rows.Add("1", "MARCO AYALA 3");
            return dt;
        }

        public static DataTable getData2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("APELLIDO", typeof(string));
            dt.Columns.Add("CLAVE", typeof(string));
            dt.Rows.Add("1", "AYALA", "123");
            dt.Rows.Add("1", "LITUMA", "456");
            dt.Rows.Add("1", "NARVAEZ", "789");
            return dt;
        }
    }
}