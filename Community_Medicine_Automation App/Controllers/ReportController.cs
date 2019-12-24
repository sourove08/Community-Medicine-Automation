using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Community_Medicine_Automation_App.Reports.DB;
using Microsoft.Reporting.WebForms;

namespace Community_Medicine_Automation_App.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private CommunityMedicineDBEntities db;
        public ReportController()
        {
            db=new CommunityMedicineDBEntities();
        }


        public FileContentResult ExportMedicineStoreReport(int Id)
        {
            var modelData = from aa in db.ReportMedicineStore() where aa.MedicineStoreCenterId == Id select aa;
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports/ExportMedicineStore"), "MedicineStockReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }

            ReportDataSource rd = new ReportDataSource("msDataSet", modelData.ToList());
            lr.DataSources.Add(rd);
            string reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                "  <OutputFormat>" + "pdf" + "</OutputFormat>" +
                "  <PageWidth>21 cm</PageWidth>" +
                "  <PageHeight>29.7 cm</PageHeight>" +
                "  <MarginTop>0.5in</MarginTop>" +
                "  <MarginLeft>1 cm</MarginLeft>" +
                "  <MarginRight>1 cm</MarginRight>" +
                "  <MarginBottom>0.5 in</MarginBottom>" +
                "</DeviceInfo>";

            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            lr.Refresh();

            return File(renderedBytes, mimeType);
        }




        public FileContentResult ExportPatientTreatmentReport(int Id)
        {
            var modelData = from aa in db.ReportPatientTreatments() where aa.PatientId == Id select aa;
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports/ExportPatientTreatment"), "PatientTreatmentsReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }

            ReportDataSource rd = new ReportDataSource("ptDataSet", modelData.ToList());
            lr.DataSources.Add(rd);

            string reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                "  <OutputFormat>" + "pdf" + "</OutputFormat>" +
                "  <PageWidth>21 cm</PageWidth>" +
                "  <PageHeight>29.7 cm</PageHeight>" +
                "  <MarginTop>0.5in</MarginTop>" +
                "  <MarginLeft>1 cm</MarginLeft>" +
                "  <MarginRight>1 cm</MarginRight>" +
                "  <MarginBottom>0.5 in</MarginBottom>" +
                "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            //lr.Refresh();

            return File(renderedBytes, mimeType);
        }



        public FileContentResult ExportReport(int Id)
        {
            var modelData = from aa in db.ReportPatientTreatments() where aa.PatientTreatmentId == Id select aa;
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports/ExportPatientTreatment"), "PatientTreatmentsReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }

            ReportDataSource rd = new ReportDataSource("ptDataSet", modelData.ToList());
            lr.DataSources.Add(rd);

            string reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                "  <OutputFormat>" + "pdf" + "</OutputFormat>" +
                "  <PageWidth>21 cm</PageWidth>" +
                "  <PageHeight>29.7 cm</PageHeight>" +
                "  <MarginTop>0.5in</MarginTop>" +
                "  <MarginLeft>1 cm</MarginLeft>" +
                "  <MarginRight>1 cm</MarginRight>" +
                "  <MarginBottom>0.5 in</MarginBottom>" +
                "</DeviceInfo>";

            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            //lr.Refresh();

            return File(renderedBytes, mimeType);
        }
    }
}