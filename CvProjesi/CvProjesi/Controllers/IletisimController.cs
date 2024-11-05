using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProjesi.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        CvDbEntities db=new CvDbEntities();
        public ActionResult Index()
        {
            var iletisim=db.tbl_contact.ToList();
            return View(iletisim);
        }
    }
}