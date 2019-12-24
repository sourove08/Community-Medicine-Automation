using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CommunityMedicine.Manager.Interfaces;
using CommunityMedicine.Models.Models;
using Community_Medicine_Automation_App.ViewModels;
using Patient = CommunityMedicine.Models.Models.Patient;
using PatientDisease = CommunityMedicine.Models.Models.PatientDisease;
using PatientTreatment = CommunityMedicine.Models.Models.PatientTreatment;

namespace Community_Medicine_Automation_App.Controllers
{
    [Authorize]
    public class CenterController : Controller
    {
        private ICenterLoginManager _centerLoginManager;
        private IDoctorManager _doctorManager;
        private IMedicineStoreManager _medicineStoreManager;
        private IDiseaseManager _diseaseManager;
        private IPatientManager _patientManager;
        private IPatientTreatmentManager _patientTreatmentManager;

        public CenterController(ICenterLoginManager centerLoginManager,IDoctorManager doctorManager,IMedicineStoreManager medicineStoreManager,IDiseaseManager diseaseManager,IPatientManager patientManager,IPatientTreatmentManager patientTreatmentManager)
        {
            _centerLoginManager = centerLoginManager;
            _doctorManager = doctorManager;
            _medicineStoreManager=medicineStoreManager ;
            _diseaseManager= diseaseManager;
            _patientManager= patientManager;
            _patientTreatmentManager= patientTreatmentManager;
        }
        [HttpGet]
        [Authorize(Roles = "Center")]
        public ActionResult PatientRegistration()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Center")]
        public ActionResult PatientRegistration(Patient model)
        {
            if (_patientManager.Add(model))
            {
                ViewBag.message = "Patient Added Sucessfully";
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Center")]
        public ActionResult CenterLoginAuthentication()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Center")]
        public ActionResult CenterLoginAuthentication(CenterLogin model)
        {

           var centerLogins = _centerLoginManager.GetAll().ToList();
            CenterLogin centerLogin =(CenterLogin) centerLogins.FirstOrDefault(m => m.Code == model.Code && m.Password == model.Password);
                
            if (centerLogin!=null)
            {
                return RedirectToAction("CenterLoginClickView", "Center", new {centerId = centerLogin.Id});
            }

            ViewBag.message = "Sorry Login Failed!!! Please input correct Login Code and Password";
          return  View();
        }
        [HttpGet]
        [Authorize(Roles = "Center")]
        public ActionResult CenterLoginClickView(int centerId )
        {
           CenterLogin login= _centerLoginManager.GetAll().ToList().Find(m=>m.CenterId==centerId);
            return View(login);
        }

        [HttpGet]
        [Authorize(Roles = "Center")]
        public ActionResult DoctorEntry()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Center")]
        public ActionResult DoctorEntry(Doctor model,int centerId)
        {
            model.CenterId = centerId;
            try
            {
                if (ModelState.IsValid)
                {
                    _doctorManager.Add(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
            }
            return View();
        }
        [Authorize(Roles = "Center,Headoffice")]
        public ActionResult MedicineStockReport(int centerId)
        {
            MedicineStore medicineStore = _medicineStoreManager.GetAll().FirstOrDefault(m => m.CenterId == centerId);
            return View(medicineStore);
        }

        [HttpGet]
        [Authorize(Roles = "Center")]
        public ActionResult TreatmentToPatient()
        {
           SelectList aList=new SelectList(_doctorManager.GetAll().ToList(), "Id","Name");
           SelectList list=new SelectList(_diseaseManager.GetAll().ToList(),"Id","Name");
           Dictionary<int,string> doses=new Dictionary<int, string>()
           {
               {1,"Before Meal"},
               {2,"After Meal"} 
           };
            ViewBag.doctors = aList;
            ViewBag.diseases = list;
            SelectList anList=new SelectList(doses,"Key","Value");
            ViewBag.doseList = anList;
           return View();
        }
        [HttpPost]
        [Authorize(Roles = "Center")]
        public ActionResult TreatmentToPatient(PatientTreatment model,int centerId)
        {
           Patient patient =_patientManager.GetAll().FirstOrDefault(m => m.Id == model.PatientId);
            patient.ServiceGiven = model.ServiceTime;


            try
            {
                if (ModelState.IsValid)
                {
                    
                    _patientManager.Update(patient);
                    _patientTreatmentManager.Add(model);
                    ViewBag.message = "Patient treatment is given Sucessfully";
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
            }
            SelectList aList = new SelectList(_doctorManager.GetAll().ToList(), "Id", "Name");
            SelectList list = new SelectList(_diseaseManager.GetAll().ToList(), "Id", "Name");
            Dictionary<int, string> doses = new Dictionary<int, string>()
            {
                {1,"Before Meal"},
                {2,"After Meal"}
            };
            ViewBag.doctors = aList;
            ViewBag.diseases = list;
            SelectList anList = new SelectList(doses, "Key", "Value");
            ViewBag.doseList = anList;
            return View(model);
        }




        public JsonResult GetAllMedicineByDisease(int diseaseId)
        {
           var jsonData=_diseaseManager.GetAllMedicineByDisease(diseaseId).Select(p => new { p.Id, p.GenericName});
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPatientByVoterId(int voterId)
        {
            Patient patient = _patientManager.GetAll().FirstOrDefault(m => m.VoterId == voterId);
   
            Session["patientId"] = patient.Id;
            return Json(patient, JsonRequestBehavior.AllowGet);
        }

       [Authorize(Roles = "Headoffice,Center")]
        public ActionResult ShowAllHistory()
        {
            if (Session["patientId"] == null)
            {
                ViewBag.message = "Please Give Patient Voter Id";
                return View();
            }
            int patientId = (int)Session["patientId"];
            Patient patient = _patientManager.GetAll().ToList().FirstOrDefault(m => m.Id == patientId);
            var patientTreatments = from aa in _patientTreatmentManager.GetAll() where aa.PatientId == patientId orderby aa.Date select aa;
            Session["patientId"] = null;
            ShowAllHistoryViewModel model = new ShowAllHistoryViewModel();
            model.Patient = patient;
            model.PatientTreatments = patientTreatments.ToList();

            if (model.PatientTreatments.Count == 0)
            {
                ViewBag.message = "This Patient did't get any Treatment";
            }
            return View(model);
        }

        [Authorize(Roles = "Center")]
        public ActionResult MedicineStoreView(int centerId)
        {
           var store= _medicineStoreManager.GetAll().ToList().FirstOrDefault(m => m.CenterId == centerId);
            return View(store);
        }

        [HttpGet]
        [Authorize(Roles = "Center")]
        public ActionResult DeliverMedicineToPatient(int centerId)
        {
            SelectList aList=new SelectList(_patientTreatmentManager.GetAll().ToList(),"Id","TreatmentCode");
            ViewBag.treatmentList = aList;
            Session["CenterId"] = centerId;
            DeliverMedicineViewModel model=new DeliverMedicineViewModel();
            return View(model);
        }
        
        [HttpPost]
        [Authorize(Roles = "Center")]
        public ActionResult DeliverMedicineToPatient(DeliverMedicineViewModel model)
        {
            if (Session["CenterId"] == null)
            {
                ViewBag.message = "Center Id not found!! Please give Correct Center";
                return View();
            }
            int centerId = (int)Session["CenterId"];
            MedicineStore store = (MedicineStore)_medicineStoreManager.GetAll().ToList().FirstOrDefault(m => m.CenterId == centerId);
            PatientTreatment patientTreatment = _patientTreatmentManager.GetById(model.Id);
            foreach (PatientDisease disease in patientTreatment.PatientDiseases)
            {
                StoreDetail storeDetail = store.StoreDetails.ToList().FirstOrDefault(m => m.MedicineId == disease.MedicineId);
                if (storeDetail == null)
                {
                    ViewBag.message = "Medicine Id " + disease.MedicineId + " no Found in this Center Store";
                    return View();
                }
                storeDetail.Quantity = storeDetail.Quantity - disease.MedicineQuantity;
                if (storeDetail.Quantity<0)
                {
                    ViewBag.message = "Medicine Id " + disease.MedicineId + " is out of Stock!!! Please Inform Head office for Medicine";
                    return View();
                }
            }

           bool result= _medicineStoreManager.Update(store);
            if (result)
            {
                ViewBag.message = "Medicine Given Sucessfully to Patient";
            }
            SelectList aList = new SelectList(_patientTreatmentManager.GetAll().ToList(), "Id", "TreatmentCode");
            ViewBag.treatmentList = aList;
            return View();
        }

    }
    
}