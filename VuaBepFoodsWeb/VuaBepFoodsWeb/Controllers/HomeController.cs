using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VuaBepFoodsWeb.ExtensionMethods;
using VuaBepFoodsWeb.Lib;
using VuaBepFoodsWeb.Models;
using VuaBepFoodsWeb.ViewModels;

namespace VuaBepFoodsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<Config_MetaSEO> _metaSeoo;
        private readonly ISendMailSMTP _sendMailSMTP;

        public HomeController(IOptions<Config_MetaSEO> metaSeoo, ISendMailSMTP sendMailSMTP)
        {
            _metaSeoo = metaSeoo;
            _sendMailSMTP = sendMailSMTP;
        }

        public IActionResult Index()
        {
            SetViewDataSEOExtensionMethod.SetViewDataSEOCustomStaticImagePrevice(this, _metaSeoo.Value.Home);
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitContact(EM_Contact model)
        {
            M_JResult jResult = new M_JResult();
            if (!ModelState.IsValid)
            {
                jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(this));
                return Json(jResult);
            }
            model = CleanXSSHelper.CleanXSSObject(model);
            string content = System.IO.File.ReadAllText("wwwroot/html/email_info_contact.html");
            content = content.Replace("{{name}}", model.name);
            content = content.Replace("{{telephoneNumber}}", model.telephoneNumber);
            content = content.Replace("{{email}}", model.email);
            content = content.Replace("{{quantity}}", model.quantity.ToString());
            content = content.Replace("{{message}}", model.message);
            var res = await _sendMailSMTP.SendMail(string.Empty, "Vua Bếp Foods - Thông tin liên hệ", content);
            jResult.result = res;
            return Json(jResult);
        }
    }
}