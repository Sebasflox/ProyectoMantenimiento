using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tienda_APPWEB.Data;


namespace Tienda_APPWEB.Controllers
{
    public class BaseController : Controller
    {
        private readonly Tienda_APPWEBContext _context;
        private Tienda_APPWEBContext context;

        public BaseController(Tienda_APPWEBContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}
