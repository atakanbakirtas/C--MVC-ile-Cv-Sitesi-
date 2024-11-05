using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CvProjesi.Controllers
{
    public class AdmindefaultController : Controller
    {
        CvDbEntities db = new CvDbEntities();

        public ActionResult AdminGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminGiris(tbl_admin aut)
        {
            var g_admin=db.tbl_admin.FirstOrDefault(x=>x.admin==aut.admin && x.sifre==aut.sifre);
            if (g_admin != null)
            {

                FormsAuthentication.SetAuthCookie(g_admin.admin,false);
                Session["Admin"] = g_admin.admin.ToString();
                return RedirectToAction("Index", "Admindefault");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminGiris", "Admindefault");
        }


        public ActionResult HataSayfası()
        {
            return View();
        }
        
        
        
        
        
        // GET: Admindefault
        public ActionResult Index()
        {
            return View();
        }

      
        // biografileri düzenleme kısmı 
        [Authorize]
        public ActionResult Biografiler()
        {
            var bio=db.tbl_user.ToList();
            return View(bio);
        }


        // bilgileri çekme
        [Authorize]
        public ActionResult Bilgidüzenle(int id)
        {
            var gelenid=db.tbl_user.Find(id);
            return View("Bilgidüzenle", gelenid); 
            

        }



        // bilgileri güncelleme
        [HttpPost]
        [Authorize]
        public ActionResult Bilgigüncelle(tbl_user t1)
        {
            var user = db.tbl_user.Find(t1.UserID);
            user.UserID = t1.UserID;
            user.FullName = t1.FullName;
            user.Title = t1.Title;
            user.Email = t1.Email;  
            user.PhoneNumber = t1.PhoneNumber;
            user.LinkedIn = t1.LinkedIn;
            user.GitHub = t1.GitHub;
            user.ProfileImage = t1.ProfileImage;
            user.Biography = t1.Biography;
            db.SaveChanges();
            return RedirectToAction("Biografiler");


        }



        // eğitimleri çek 
        [Authorize]
        public ActionResult Educek()

        {
            var edu=db.tbl_education.ToList();
            return View(edu);

        }


        // edu gelen id
        [Authorize]
        public ActionResult  edugüncelle(int id)
        {
            var gelen=db.tbl_education.Find(id);
            return View("edugüncelle",gelen);

        }

        // güncelleme education
        [Authorize]
        public ActionResult edugüncelle2(tbl_education e1)
        {
            var edu = db.tbl_education.Find(e1.EducationID);
            edu.UserID = 1;
            edu.SchoolName = e1.SchoolName;
            edu.Description= e1.Description;
            edu.Degree = e1.Degree;
            edu.EndDateDATE = e1.EndDateDATE;
            edu.StartDate= e1.StartDate;
            db.SaveChanges();
            return RedirectToAction("Educek");

        }


        // edussil
        [Authorize]
        public ActionResult Sil(int id)
        {
            var silinecek = db.tbl_education.Find(id);
            db.tbl_education.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Educek");
        }




        // skills
        // skil ekle 
        [HttpGet]
        [Authorize]
        public ActionResult Skilekle()
        {
            return View();

        }


        [HttpPost]
        [Authorize]
        public ActionResult Skilekle(tbl_skill t1)
        {
            db.tbl_skill.Add(t1);
            db.SaveChanges();
            return View();

        }


        // skil sayfası
        [Authorize]
        public ActionResult skilgetir()
        {
            var skills=db.tbl_skill.ToList();
            return View(skills);
        }
        // skill silme
        [Authorize]
        public ActionResult Skilsil(int id) 
        
        {
            var silinecek=db.tbl_skill.Find(id);
            db.tbl_skill.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("skilgetir");
        }





        // eğitim ekleme ksımı
        [HttpGet]
        [Authorize]
        public ActionResult Eduekle()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Eduekle(tbl_education e1)
        {
            db.tbl_education.Add(e1);
            db.SaveChanges();
            return View("Index");
        }



        // deneyim sayfası 
        [Authorize]
        public ActionResult Exper()
        {
            var expers = db.tbl_experience.ToList();
            return View(expers);

        }


        // deneyim ekle 
        [Authorize]
        [HttpGet]
        public ActionResult Experekle() 
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Experekle(tbl_experience ex)
        {
            db.tbl_experience.Add(ex);
            db.SaveChanges();
            return RedirectToAction("Exper", "Admindefault");
        }




        // exper sil
        [Authorize]

        public ActionResult Expersil(int id)
        {
            var silinicek=db.tbl_experience.Find(id);
            db.tbl_experience.Remove(silinicek);
            db.SaveChanges();
            return RedirectToAction("Exper", "Admindefault");
        }


    }
}