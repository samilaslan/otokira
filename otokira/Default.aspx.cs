using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.IO;

public partial class Default : System.Web.UI.Page
{
    otokira.Class1 cls = new otokira.Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (cls.SecurityCheck() == 0)
        {
            Response.Redirect("~/login.aspx");
        }
        if (!IsPostBack)
        {
            if (cls.GetGetYetki() != 1)
            {
                RadMenu1.Items[0].Visible = false;
                RadMenu1.Items[1].Visible = false;
            }
            else
            {
                RadMenu1.Items[0].Visible = true;
                RadMenu1.Items[1].Visible = true;
            }
               

        }
    }

    private void dbList(bool pNeed)
    {
       


    }

   

   
   

    
        
    
}
