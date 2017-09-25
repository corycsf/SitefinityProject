using SitefinityWebApp.Custom.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitefinityWebApp.Templates
{
    public partial class ContentBlockTemplate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void Render(HtmlTextWriter writer)
        {
            // do not expand shortcodes in design mode
            if (this.IsDesignMode())
            {
                base.Render(writer);
                return;
            }

            // expand shortcodes, add additional codes inside the Execute method
            contentHtml.Text = ShortcodeProcessor.Execute(contentHtml.Text);

            base.Render(writer);
        }
    }
}