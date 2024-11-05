using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProjesi.Controllers
{
    public class ExperController : Controller
    {
        // GET: Exper
        CvDbEntities db=new CvDbEntities();
        public ActionResult Index()
        {
            var ex=db.tbl_experience.ToList();
            return View(ex);
        }
    }
}