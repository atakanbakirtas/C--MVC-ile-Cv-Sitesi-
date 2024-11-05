using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProjesi.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        CvDbEntities db=new CvDbEntities();
        public ActionResult Index()
        {
            var skil=db.tbl_skill.ToList();

            return View(skil);
        }
    }
}