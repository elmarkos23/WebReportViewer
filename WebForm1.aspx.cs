using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebReportViewer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report1.rdlc");
                ReportDataSource datasource = new ReportDataSource("dsDatos", getData());
                ReportDataSource datasource2 = new ReportDataSource("dsDatos2", getData2());
                string imagePath = new Uri(Server.MapPath("~/xamarin.png")).AbsoluteUri;
                string imagePath2 = new Uri(Server.MapPath("~/home.png")).AbsoluteUri;

                ReportParameter[] parameters = new ReportParameter[3];
                parameters[0] = new ReportParameter("varFecha", DateTime.Now.ToString("dd/MM/yyyy"));
                parameters[1] = new ReportParameter("ImagenPath", imagePath);


                //colocar en el patch externo
                //
                parameters[2] = new ReportParameter("Imagen2", imagePath2);
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);
                ReportViewer1.LocalReport.SetParameters(parameters);

                ReportViewer1.LocalReport.Refresh();


            }
        }
        private DataTable getData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID",typeof(string));
            dt.Columns.Add("NOMBRE", typeof(string));
            dt.Rows.Add("1","MARCO AYALA 1");
            dt.Rows.Add("1", "MARCO AYALA 2");
            dt.Rows.Add("1", "MARCO AYALA 3");
            return dt;
        }

        private DataTable getData2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("APELLIDO", typeof(string));
            dt.Columns.Add("CLAVE", typeof(string));
            dt.Rows.Add("1", "AYALA","123");
            dt.Rows.Add("1", "LITUMA","456");
            dt.Rows.Add("1", "NARVAEZ","789");
            return dt;
        }
    }
}