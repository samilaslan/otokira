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

public partial class Login : System.Web.UI.Page
{
    otokira.Class1 cls = new otokira.Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
        otokira.Class1 cls = new otokira.Class1();
        if (!IsPostBack)
        {
           
               

        }
    }

    private void dbList(bool pNeed)
    {
       


    }

    #region ..: HataGoster       :..
    private void HataGoster(string pErrMsg, bool pGreen)
    {


        lblHata.Visible = !string.IsNullOrEmpty(pErrMsg);
        imgHata.Visible = !string.IsNullOrEmpty(pErrMsg);
        lblHata.ForeColor = pGreen ? System.Drawing.Color.Green : System.Drawing.Color.OrangeRed;
        imgHata.ImageUrl = pGreen ? "~/Images/ImgOk.png" : "~/Images/ImgHata.png";
        lblHata.Font.Bold = true;
        lblHata.Text = pErrMsg;
    }
    #endregion

    protected void btnGiris_Click(object sender, EventArgs e)
    {
        

        string vUser = cls.rbsSqlTemizle(txtUser.Text);
        string vPass = cls.rbsSqlTemizle(txtPass.Text);
        if (string.IsNullOrEmpty(vUser)||string.IsNullOrEmpty(vPass))
        {
            HataGoster("Kullanıcı Adı ve Şifresini Giriniz...", false);
            return;
        }
        DataTable dt = cls.Proc_otokira_login(vUser, vPass);
        if (dt.Rows.Count==0)
        {
            HataGoster("Kullanıcı Bilgisi Bulunamadı...", false);
            return;
        }
        else
        {
            Session["pLogin"] = "1";
            Session["pYetki"] = dt.Rows[0]["YETKI"].ToString();
            Session["pMusteriId"] = dt.Rows[0]["MUSTERI_ID"].ToString();
            Session["pMusteriAd"] = dt.Rows[0]["AD"].ToString();
            Session["pMusteriSAd"] = dt.Rows[0]["SOYAD"].ToString();
            Response.Redirect("~/default.aspx");

        }
    }

   

   
   

    
        
    
}
