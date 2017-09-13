#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SitefinityWebApp.ResourcePackages.Bootstrap.MVC.Views.ImageGallery
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
    using Telerik.Sitefinity;
    
    #line default
    #line hidden
    
    #line 5 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
    using Telerik.Sitefinity.Frontend.Media.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 7 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
    using Telerik.Sitefinity.Frontend.Media.Mvc.Models.ImageGallery;
    
    #line default
    #line hidden
    
    #line 4 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
    using Telerik.Sitefinity.Frontend.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 6 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
    using Telerik.Sitefinity.Modules.Pages;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/MVC/Views/ImageGallery/List.ImageGallery.cshtml")]
    public partial class List_ImageGallery : System.Web.Mvc.WebViewPage<Telerik.Sitefinity.Frontend.Mvc.Models.ContentListViewModel>
    {
        public List_ImageGallery()
        {
        }
        public override void Execute()
        {
WriteLiteral("\n");

            
            #line 9 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
Write(Html.Script(ScriptRef.JQuery, "top"));

            
            #line default
            #line hidden
WriteLiteral("\n\n<div");

WriteLiteral(" class=\"sf-Gallery-thumbs-container\"");

WriteLiteral(">\n  <div");

WriteAttribute("class", Tuple.Create(" class=\"", 392), Tuple.Create("\"", 433)
, Tuple.Create(Tuple.Create("", 400), Tuple.Create("sf-Gallery-thumbs", 400), true)
            
            #line 12 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
, Tuple.Create(Tuple.Create(" ", 417), Tuple.Create<System.Object, System.Int32>(Model.CssClass
            
            #line default
            #line hidden
, 418), false)
);

WriteLiteral(">\n\n");

            
            #line 14 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
    
            
            #line default
            #line hidden
            
            #line 14 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
     for (int i = 0; i < Model.Items.Count(); i++)
    {
        var item = Model.Items.ElementAt(i);
        var thumbnailViewModel = (ThumbnailViewModel)item;
        
        var itemIndex = (Model.CurrentPage - 1) * ViewBag.ItemsPerPage + i + 1;
		var detailPageUrl = ViewBag.OpenInSamePage ? HyperLinkHelpers.GetDetailPageUrl(item, ViewBag.DetailsPageId, ViewBag.OpenInSamePage, Model.UrlKeyPrefix, itemIndex) :
            HyperLinkHelpers.GetDetailPageUrl(item, ViewBag.DetailsPageId, ViewBag.OpenInSamePage, Model.UrlKeyPrefix);


            
            #line default
            #line hidden
WriteLiteral("      <a");

WriteLiteral(" class=\"text-center\"");

WriteAttribute("href", Tuple.Create("\n             href=\"", 1003), Tuple.Create("\"", 1037)
            
            #line 24 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
, Tuple.Create(Tuple.Create("", 1023), Tuple.Create<System.Object, System.Int32>(detailPageUrl
            
            #line default
            #line hidden
, 1023), false)
);

WriteAttribute("title", Tuple.Create("\n       title=\"", 1038), Tuple.Create("\"", 1147)
            
            #line 25 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
, Tuple.Create(Tuple.Create("", 1053), Tuple.Create<System.Object, System.Int32>(string.IsNullOrEmpty(item.Fields.Description) ? item.Fields.Title : item.Fields.Description
            
            #line default
            #line hidden
, 1053), false)
);

WriteLiteral(">\n            <img");

WriteAttribute("src", Tuple.Create(" src=\"", 1166), Tuple.Create("\"", 1206)
            
            #line 26 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
, Tuple.Create(Tuple.Create("", 1172), Tuple.Create<System.Object, System.Int32>(thumbnailViewModel.ThumbnailUrl
            
            #line default
            #line hidden
, 1172), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\'", 1207), Tuple.Create("\'", 1305)
            
            #line 26 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
, Tuple.Create(Tuple.Create("", 1213), Tuple.Create<System.Object, System.Int32>(System.Text.RegularExpressions.Regex.Replace(item.Fields.AlternativeText, @"[^\w\d_-]", "")
            
            #line default
            #line hidden
, 1213), false)
);

WriteLiteral("\n                      ");

            
            #line 27 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
                 Write(Html.GetWidthAttributeIfExists(thumbnailViewModel.Width));

            
            #line default
            #line hidden
WriteLiteral("\n");

WriteLiteral("                      ");

            
            #line 28 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
                 Write(Html.GetHeightAttributeIfExists(thumbnailViewModel.Height));

            
            #line default
            #line hidden
WriteLiteral(" />\n      </a>\n");

            
            #line 30 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
      }

            
            #line default
            #line hidden
WriteLiteral("  </div>\n</div>\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(" src=\"//cdn.jsdelivr.net/jquery.slick/1.6.0/slick.min.js\"");

WriteLiteral("></script>\n");

            
            #line 34 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
 if (Model.ShowPager)
{
    
            
            #line default
            #line hidden
            
            #line 36 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
Write(Html.Action("Index", "ContentPager", new
       {
           currentPage = Model.CurrentPage,
           totalPagesCount = Model.TotalPagesCount.Value,
           redirectUrlTemplate = ViewBag.RedirectPageUrlTemplate
       }));

            
            #line default
            #line hidden
            
            #line 41 "..\..MVC\Views\ImageGallery\List.ImageGallery.cshtml"
         
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
