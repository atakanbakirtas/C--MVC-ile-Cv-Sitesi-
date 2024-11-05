using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CvProjesi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        CvDbEntities db=new CvDbEntities();
        public ActionResult Index()
        {
            var hakkımda=db.tbl_user.ToList();
            return View(hakkımda);
        }
    }
}