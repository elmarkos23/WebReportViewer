<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebReportViewer.WebForm1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Report</h1>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
              <rsweb:ReportViewer ID="ReportViewer1" runat="server" ShowToolBar="true" Height="200" BackColor="LightGreen"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
