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
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "CustomCarousel", Title = "CustomCarousel", SectionName = "MvcWidgets")]
    public class CustomCarouselController : Controller
    {
        [Category("String Properties")]
        public string Message { get; set; }

        [Category("Carousel")]
        public DynamicContent Carousel { get; set; }
        //public string[] ImageUrls { get; set; }

        // GET: CustomCarousel
        public ActionResult Index()
        {
            var helper = new CarouselHelper();

            var carousels = helper.RetrieveCollectionOfItem(_carouselType);
            var model = new CustomCarouselModel();
            
            model.Carousels = carousels;
            this.Carousel = carousels.FirstOrDefault();

            model.Images = helper.GetImageItemsFromCarouselID(this.Carousel);

            return View("Default", model);
        }

        private readonly Type _carouselType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Carousels.Carousel");
        
    }
}