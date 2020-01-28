using DemoWebApplication.Reports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Viewer(string reportName)
        {
            XtraReport report;
            if (!string.IsNullOrWhiteSpace(reportName))
            {
                try
                {
                    Type reportType = Type.GetType("DemoWebApplication.Reports." + reportName);
                    report = (XtraReport)Activator.CreateInstance(reportType);
                }
                catch
                {
                    report = new DefaultReportGenerator();
                }
            }
            else
            {
                report = new DefaultReportGenerator();
            }
            return View(report);
        }
    }
}