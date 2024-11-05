using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProjesi.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        CvDbEntities db=new CvDbEntities();
        public ActionResult Index()
        {
            var education=db.tbl_education.ToList();
            return View(education);
        }
    }
}