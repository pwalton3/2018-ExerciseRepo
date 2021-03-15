using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class MultiView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            //to switch views grab value from MenuEventArgs
            int index = Int32.Parse(e.Item.Value);
            //set .ActiveViewIndex
            MultiView1.ActiveViewIndex = index;

        }
    }
}