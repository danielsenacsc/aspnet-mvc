using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class TesteLayoutController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}