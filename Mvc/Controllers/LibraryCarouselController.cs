using SitefinityWebApp.Custom.Helpers;
using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "LibraryCarousel", Title = "LibraryCarousel", SectionName = "MvcWidgets")]
    public class LibraryCarouselController : Controller
    {
        [Category("String Properties")]
        public string LibraryName { get; set; }
        // GET: LibraryCarousel
        public ActionResult Index()
        {
            var model = new LibraryCarouselModel();
            if (string.IsNullOrEmpty(this.LibraryName))
            {
                model.Images = new List<Telerik.Sitefinity.Libraries.Model.Image>();
            }
            else
            {
                var helper = new CarouselHelper();
                var images = helper.GetImagesByAlbumFluentAPI(this.LibraryName);
                model.Images = images;
            }
            
            return View("Default", model);
        }
    }
}