using SitefinityWebApp.Custom.Helpers;
using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "CustomCarousel", Title = "CustomCarousel", SectionName = "MvcWidgets")]
    public class CustomCarouselController : Controller
    {
        

        [Category("String Properties")]
        public string CarouselTitle { get; set; }
                
        // GET: CustomCarousel
        public ActionResult Index()
        {
            var helper = new CarouselHelper();
            
            //Get model
            var model = helper.GetCustomCarouselModel();

            return View("Default", model);
        }

        
        
    }
}