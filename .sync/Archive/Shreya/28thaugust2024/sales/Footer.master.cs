using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesSahayak
{
    public partial class Footer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Request.Url.AbsolutePath;
            backtotop.HRef = path;
        }
    }
}