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
        // Demonstrates how child content items can be retrieved
        public List<Telerik.Sitefinity.Libraries.Model.Image> GetImageItemsFromCarouselID(DynamicContent carousel)
        {
            var images = new List<Telerik.Sitefinity.Libraries.Model.Image>();
            if (carousel != null)
            {
                var relatedImages = carousel.GetRelatedItems<Telerik.Sitefinity.Libraries.Model.Image>("Images").ToList();

                images.AddRange(relatedImages);
            }

            return images;
        }
        public List<Telerik.Sitefinity.Libraries.Model.Image> GetImagesByAlbumFluentAPI(string libraryName)
        {
            return App.WorkWith().Images().Where(a => a.Parent.Title == libraryName && a.Status == ContentLifecycleStatus.Live).Get()?.ToList();
        }
        public DynamicModuleManager DynamicModuleManager
        {
            get
            {
                if (dynamicModuleManager == null)
                {
                    dynamicModuleManager = DynamicModuleManager.GetManager();
                }
                return dynamicModuleManager;
            }
        }
        public IQueryable<DynamicContent> RetrieveCollectionOfItem(Type contentType)
        {
            // This is how we get the collection of Carousel items
            var myCollection = DynamicModuleManager.GetDataItems(contentType);
            // At this point myCollection contains the items from type carouselType
            return myCollection.Where(x => x.Status == Telerik.Sitefinity.GenericContent.Model.ContentLifecycleStatus.Live && x.Visible);
        }
        private DynamicModuleManager dynamicModuleManager;


    }
}