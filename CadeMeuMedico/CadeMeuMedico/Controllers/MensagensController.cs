using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class MensagensController : Controller
    {
        public ActionResult BomDia()
        {
            return Content("Bom dia... hoje você acordou cedo!");
        }

        public ActionResult BoaTarde()
        {
            return Content("Boa tarde... não durma na mesa do trabalho!");
        }
    }
}