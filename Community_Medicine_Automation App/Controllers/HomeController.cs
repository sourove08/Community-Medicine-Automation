using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityMedicine.Manager.Interfaces;
using CommunityMedicine.Models.Models;
using Community_Medicine_Automation_App.Reports.DB;
using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.WinForms;
using LocalReport = Microsoft.Reporting.WebForms.LocalReport;
using ReportDataSource = Microsoft.Reporting.WebForms.ReportDataSource;
using Warning = Microsoft.Reporting.WebForms.Warning;

namespace Community_Medicine_Automation_App.Controllers
{
    public class HomeController : Controller
    {
        private ICenterLoginManager _centerLoginManager;
        private IDoctorManager _doctorManager;
        private IMedicineStoreManager _medicineStoreManager;
        private IDiseaseManager _diseaseManager;
        private IPatientManager _patientManager;
        private IPatientTreatmentManager _patientTreatmentManager;

        public HomeController(ICenterLoginManager centerLoginManager, IDoctorManager doctorManager, IMedicineStoreManager medicineStoreManager, IDiseaseManager diseaseManager, IPatientManager patientManager, IPatientTreatmentManager patientTreatmentManager)
        {
            _centerLoginManager = centerLoginManager;
            _doctorManager = doctorManager;
            _medicineStoreManager = medicineStoreManager;
            _diseaseManager = diseaseManager;
            _patientManager = patientManager;
            _patientTreatmentManager = patientTreatmentManager;
        }


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


    }

}