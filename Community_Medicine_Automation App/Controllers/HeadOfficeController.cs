using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityMedicine.Manager;
using CommunityMedicine.Manager.Interfaces;
using CommunityMedicine.Models.Databases;
using CommunityMedicine.Models.Models;
using Community_Medicine_Automation_App.ViewModels;

namespace Community_Medicine_Automation_App.Controllers
{
    [Authorize]
    public class HeadOfficeController : Controller
    {
        private IMedicineManager _medicineManager;
        private IDiseaseManager _diseaseManager;
        private ICenterManager _centerManager;
        private ICenterLoginManager _centerLoginManager;
        private IMedicineStoreManager _medicineStoreManager;
        private IPatientManager _patientManager;

        public HeadOfficeController(IMedicineManager medicineManager,IDiseaseManager diseaseManager,ICenterManager centerManager,ICenterLoginManager centerLoginManager,IMedicineStoreManager medicineStoreManager,IPatientManager patientManager)
        {
            _medicineManager=medicineManager ;
            _diseaseManager=diseaseManager;
            _centerManager=centerManager;
            _centerLoginManager=centerLoginManager;
            _medicineStoreManager=medicineStoreManager;
            _patientManager = patientManager;
        }


        [HttpGet]
        [Authorize(Roles = "Headoffice")]
        public ActionResult MedicineSetup()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Headoffice")]
        public ActionResult MedicineSetup(Medicine medicine)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _medicineManager.Add(medicine);
                    ViewBag.message = "Medicine Added Sucessfully";
                }


            }
            catch (Exception ex)
            {

                ViewBag.message = ex.Message;
            }
            return View(medicine);
        }


        [HttpGet]
        [Authorize(Roles = "Headoffice")]
        public ActionResult DiseaseSetup()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Headoffice")]
        public ActionResult DiseaseSetup(DiseaseSetupViewModel model)
        {
            List<PreferedDrug> drugs=new List<PreferedDrug>();
            List<string> subNames=new List<string>();
            List<char> demo = new List<char>();
            char[] name = model.PreferedDrugs.ToCharArray();
            int count = name.Length,dd=0;
            bool result = true;
            foreach (char ch in name)
            {
                dd++;
                if (char.IsLetterOrDigit(ch) || ch=='-')
                {
                    demo.Add(ch);
                    result = true;
                    if (dd==count)
                    {
                        string aa=new string(demo.ToArray());
                        subNames.Add(aa);
                    }
                }

              else if (result)
                {
                    string temp =new string(demo.ToArray());
                    subNames.Add(temp);
                    demo.Clear();
                    result = false;
                }
            }

            var medicines = _medicineManager.GetAll().ToList();
            string a = " ";
            foreach (string s in subNames)
            {
                Medicine medicine = (Medicine)medicines.FirstOrDefault(m=>m.GenericName.ToUpper()==s.ToUpper());
                if (medicine==null)
                {
                    a =a+s+"  ";
                    return Content(a+"Not Found !!Please Enter Correct Medicine Name");
                }
                PreferedDrug preferedDrug=new PreferedDrug();
                preferedDrug.MedicineId = medicine.Id;
                drugs.Add(preferedDrug);
            }
            Disease disease=new Disease()
            {
                Name = model.Name,
                Description = model.Description,
                TreatmentProcedure = model.TreatmentProcedure,
                PreferedDrugs = drugs
                
            };
            try
            {
                if (ModelState.IsValid)
                {
                    _diseaseManager.Add(disease);
                    ViewBag.message = "Disease Added Sucessfully";
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
            }
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "Headoffice")]
        public ActionResult CreateCenter()
        {
            SelectList alist=new SelectList(_centerManager.GetAllDistricts(),"Id","Name");
            ViewBag.allDistricts = alist;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Headoffice")]
        public ActionResult CreateCenter(Center center)
        {

           try
            {
                if (ModelState.IsValid)
                {
                    _centerManager.Add(center);
                    ViewBag.message = "Center Created Sucessfully";
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
            }
            SelectList alist = new SelectList(_centerManager.GetAllDistricts(), "Id", "Name");
            ViewBag.allDistricts = alist;
            return RedirectToAction("CreateCenterLogin",new {centerId=center.Id});
        }


        [HttpGet]
        [Authorize(Roles = "Headoffice")]
        public ActionResult CreateCenterLogin()
        {

            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Headoffice")]
        public ActionResult CreateCenterLogin(CenterLogin model)
        {
            
            _centerLoginManager.Add(model);
            ViewBag.message = "Center Login Created";
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Headoffice")]
        public ActionResult SendMedicineToCenter()
        {
            SelectList aList=new SelectList(_centerManager.GetAllDistricts(),"Id","Name");
            SelectList list=new SelectList(_medicineManager.GetAll(),"Id", "GenericName");
            ViewBag.districts = aList;
            ViewBag.medicines = list;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Headoffice")]
        public ActionResult SendMedicineToCenter(MedicineStore model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _medicineStoreManager.Add(model);
                    ViewBag.message = "Medicine Send Sucessfully to a Center";
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
            }
            SelectList aList = new SelectList(_centerManager.GetAllDistricts(), "Id", "Name");
            SelectList list = new SelectList(_medicineManager.GetAll(), "Id", "GenericName");
            ViewBag.districts = aList;
            ViewBag.medicines = list;
            return View();
        }


        public JsonResult GetThanasByDistrict(int districtId)
        {
            var jsonData = _centerManager.GetThanasByDistrict(districtId).Select(p => new { p.Id, p.Name, p.DistrictId });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCentersByThana(int thanaId)
        {
            var jsonData = _centerManager.GetCentersByThana(thanaId).Select(p => new { p.Id, p.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Authorize(Roles = "Headoffice")]
        public ActionResult MedicineStoreReport()
        {
            SelectList list = new SelectList(_centerManager.GetAll().ToList(),"Id","Name");
            ViewBag.centerStock = list;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Headoffice")]
        public ActionResult MedicineStoreReport(Center model)
        {
            return RedirectToAction("MedicineStockReport", "Center", new {centerId = model.Id});
        }
        
       
        [HttpGet]
        [Authorize(Roles = "Headoffice,Center")]
        public ActionResult PatientTreatmentReport()
        {
            SelectList list = new SelectList(_patientManager.GetAll().ToList(), "Id", "Name");
            ViewBag.patients = list;
            return View();
        }

       
        [HttpPost]
        [Authorize(Roles = "Headoffice,Center")]
        public ActionResult PatientTreatmentReport(Patient model)
        {
            Session["patientId"] = model.Id;
            return RedirectToAction("ShowAllHistory", "Center");
        }

        //public ActionResult DiseaseWiseReport()
        //{

        //    return View();
        //}
    }
}