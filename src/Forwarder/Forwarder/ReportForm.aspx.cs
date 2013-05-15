using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;

namespace Forwarder
{
    public partial class ReportForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StiReport report = new StiReport();
            var ReportPath = Server.MapPath("Report.mrt");
            report.Load(ReportPath);
            StiWebViewer1.Report = report;
        }
    }
}