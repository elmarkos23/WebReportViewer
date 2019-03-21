using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
                ReportViewer a = new ReportViewer();
                a.LocalReport.DataSources.Clear();
                a.LocalReport.EnableExternalImages = true;
                a.ProcessingMode = ProcessingMode.Local;
                a.LocalReport.ReportPath = Server.MapPath("~/Report1.rdlc");
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
                a.LocalReport.DataSources.Add(datasource);
                a.LocalReport.DataSources.Add(datasource2);
                a.LocalReport.SetParameters(parameters);

                a.LocalReport.Refresh();





                //exportar pdf
                Warning[] warnings;
                string[] streamIds;
                string contentType;
                string encoding;
                string extension;

                //Export the RDLC Report to Byte Array.
                byte[] bytes = a.LocalReport.Render("PDF", null, out contentType, out encoding, out extension, out streamIds, out warnings);


                File.WriteAllBytes(Server.MapPath("~/"+DateTime.Now.ToString("ddMMyyyyHHmmss")+".pdf"), bytes.ToArray()); // Requires System.Linq

                ////Download the RDLC Report in Word, Excel, PDF and Image formats.
                //Response.Clear();
                //Response.Buffer = true;
                //Response.Charset = "";
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.ContentType = contentType;
                //Response.AppendHeader("Content-Disposition", "attachment; filename=RDLC." + extension);
                //Response.BinaryWrite(bytes);
                //Response.Flush();
                //Response.End();





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