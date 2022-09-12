using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VuaBepFoodsWeb.ExtensionMethods;
using VuaBepFoodsWeb.Models;
using VuaBepFoodsWeb.ViewModels;

namespace VuaBepFoodsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<Config_MetaSEO> _metaSeoo;

        public HomeController(IOptions<Config_MetaSEO> metaSeoo)
        {
            _metaSeoo = metaSeoo;
        }

        public IActionResult Index()
        {
            SetViewDataSEOExtensionMethod.SetViewDataSEOCustomStaticImagePrevice(this, _metaSeoo.Value.Home);
            return View();
        }
    }
}