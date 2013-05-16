<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportForm.aspx.cs" Inherits="Forwarder.ReportForm" %>
<%@ Register TagPrefix="cc1" Namespace="Stimulsoft.Report.Web" Assembly="Stimulsoft.Report.Web, Version=2013.1.1600.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Отчет</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
			<br>
			<br>
			<cc1:StiWebViewer id="StiWebViewer1" runat="server" Width="100%" Height="100%"
				ToolBarBackColor="WhiteSmoke" ImagesPath="Images/"></cc1:StiWebViewer>

    </div>
    </form>
</body>
</html>
