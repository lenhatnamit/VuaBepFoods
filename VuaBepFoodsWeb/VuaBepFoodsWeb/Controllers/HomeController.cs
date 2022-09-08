using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VuaBepFoodsWeb.ExtensionMethods;

namespace VuaBepFoodsWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            SetViewDataSEOExtensionMethod.SetViewDataSEOCustomStaticImagePrevice(this, new ViewModels.VM_ViewDataSEO());
            return View();
        }
    }
}