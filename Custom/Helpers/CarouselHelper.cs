using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Versioning;

namespace SitefinityWebApp.Custom.Helpers
{
    public class CarouselHelper
    {
        private readonly Type _carouselType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Carousels.Carousel");
        private DynamicModuleManager _dynamicModuleManager;

        public DynamicModuleManager DynamicModuleManager
        {
            get
            {
                if (_dynamicModuleManager == null)
                {
                    _dynamicModuleManager = DynamicModuleManager.GetManager();
                }
                return _dynamicModuleManager;
            }
        }
        public IQueryable<DynamicContent> RetrieveCollectionOfItem(Type contentType)
        {
            var myCollection = DynamicModuleManager.GetDataItems(contentType);
            return myCollection.Where(x => x.Status == ContentLifecycleStatus.Live && x.Visible);
        }
        public CustomCarouselModel GetCustomCarouselModel()
        {
            //Get all Carousel items
            var carousels = this.RetrieveCollectionOfItem(_carouselType).ToList();

            //create object to get image and sort order and cast them to their types
            var imageAndSortOrder = carousels.Select(x => new
            {
                Image = x.GetRelatedItems<Telerik.Sitefinity.Libraries.Model.Image>("Image").FirstOrDefault(),
                SortOrder = Convert.ToInt32(x.GetValue("SortOrder"))
            });

            return new CustomCarouselModel
            {
                //Sort items by sortorder, select them 
                Images = imageAndSortOrder.OrderBy(x => x.SortOrder).Select(x => x.Image).ToList()
            };
        }

    }
}