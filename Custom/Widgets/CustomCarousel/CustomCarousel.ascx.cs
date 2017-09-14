using SitefinityWebApp.Custom.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitefinityWebApp.Custom.Widgets.CustomCarousel
{
    public partial class CustomCarousel : System.Web.UI.UserControl
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var helper = new CarouselHelper();
                imageRptr.DataSource = helper.GetCustomCarouselModel().Images;
                imageRptr.DataBind();

            }
        }
    }
}