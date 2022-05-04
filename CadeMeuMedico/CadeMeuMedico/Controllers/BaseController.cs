using CadeMeuMedico.Filtros;
using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    [AutorizacaoDeAcesso]
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}