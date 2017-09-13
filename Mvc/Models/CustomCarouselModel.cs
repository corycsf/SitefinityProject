using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.DynamicModules.Model;

namespace SitefinityWebApp.Mvc.Models
{
    public class CustomCarouselModel
    {
        public List<DynamicContent> Carousels { get; set; }
        public string Message { get; set; }
        public List<Telerik.Sitefinity.Libraries.Model.Image> Images { get; set; }
    }
}