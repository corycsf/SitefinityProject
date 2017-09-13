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

            //Get all Carousel items
            var carousels = helper.RetrieveCollectionOfItem(_carouselType).ToList();

            //create object to get image and sort order and cast them to their types
            var imageAndSortOrder = carousels.Select(x => new 
                {
                    Image = x.GetRelatedItems<Telerik.Sitefinity.Libraries.Model.Image>("Image").FirstOrDefault(),
                    SortOrder = Convert.ToInt32(x.GetValue("SortOrder"))
                });

            var model = new CustomCarouselModel();
            //Sort items by sortorder, select them 
            model.Images = imageAndSortOrder.OrderBy(x=> x.SortOrder).Select(x=> x.Image).ToList();

            return View("Default", model);
        }

        private readonly Type _carouselType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Carousels.Carousel");
        
    }
}