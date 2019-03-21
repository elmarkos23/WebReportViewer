using Microsoft.Reporting.WebForms;
using System;
using System.IO;
using System.Linq;
using System.Web;

namespace WebReportViewer
{
    public class GenerarPDF
    {
        public bool Generar()
        {
            ReportViewer a = new ReportViewer();
            a.LocalReport.DataSources.Clear();
            a.LocalReport.EnableExternalImages = true;
            a.ProcessingMode = ProcessingMode.Local;
            a.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/REPORTS/Report1.rdlc");
            ReportDataSource datasource = new ReportDataSource("dsDatos", clsData.getData());
            ReportDataSource datasource2 = new ReportDataSource("dsDatos2", clsData.getData2());
            string imagePath = new Uri(HttpContext.Current.Server.MapPath("~/IMAGENES/xamarin.png")).AbsoluteUri;
            string imagePath2 = new Uri(HttpContext.Current.Server.MapPath("~/IMAGENES/home.png")).AbsoluteUri;

            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("varFecha", DateTime.Now.ToString("dd/MM/yyyy"));
            parameters[1] = new ReportParameter("ImagenPath", imagePath);

            //colocar en el patch externo
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

            File.WriteAllBytes(HttpContext.Current.Server.MapPath("~/PDF/" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf"), bytes.ToArray()); // Requires System.Linq

            return true;
        }
    }
}