using Microsoft.AspNetCore.Mvc;
using VuaBepFoodsWeb.ViewModels;
using static System.String;

namespace VuaBepFoodsWeb.ExtensionMethods
{
    public static class SetViewDataSEOExtensionMethod
    {
        public static void SetViewDataSEOCustom(this Controller controller, VM_ViewDataSEO model)
        {
            controller.ViewData["Title"] = model.Title;
            controller.ViewData["Keywords"] = model.Keywords;
            controller.ViewData["Description"] = model.Description;
            controller.ViewData["ImagePreview"] = IsNullOrEmpty(model.Image) ? $"https://{controller.HttpContext.Request.Host}{model.Image}" : model.Image;
        }
        public static void SetViewDataSEOCustomStaticImagePrevice(this Controller controller, VM_ViewDataSEO model)
        {
            controller.ViewData["Title"] = model.Title;
            controller.ViewData["Keywords"] = model.Keywords;
            controller.ViewData["Description"] = model.Description;
            controller.ViewData["ImagePreview"] = $"https://{controller.HttpContext.Request.Host}{model.Image}";
        }
    }
}
