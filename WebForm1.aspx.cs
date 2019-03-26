using Microsoft.Reporting.WebForms;
using System;
using System.IO;
using System.Linq;
using ZXing;

namespace WebReportViewer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string strCodigo = "1911201301110302914400110010010000000041234567810";
                var barcodeWriter = new BarcodeWriter();
                barcodeWriter.Format = BarcodeFormat.CODE_39;
                barcodeWriter.Write(strCodigo).Save(Server.MapPath("~/IMAGENES/"+strCodigo+".png"));

                rvPagina.LocalReport.DataSources.Clear();
                rvPagina.LocalReport.EnableExternalImages = true;
                rvPagina.ProcessingMode = ProcessingMode.Local;
                rvPagina.LocalReport.ReportPath = Server.MapPath("~/REPORTS/Informe.rdlc");
                string imagePath = new Uri(Server.MapPath("~/IMAGENES/"+strCodigo+".png")).AbsoluteUri;

                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("varCodigo", imagePath);
                rvPagina.LocalReport.SetParameters(parameters);
                rvPagina.LocalReport.Refresh();

                
            }
        }
      
    }
}