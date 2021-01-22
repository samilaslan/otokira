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

public partial class frmAracTeslim : System.Web.UI.Page
{
    otokira.Class1 cls = new otokira.Class1();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (cls.SecurityCheck() == 0)
        {
            Response.Redirect("~/login.aspx");
        }
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
        if (!IsPostBack)
        {

            dbList(false);

        }
    }

    private void dbList(bool pNeed)
    {
        long vMusteri = cls.GetMusteriId();
        int vYetki = cls.GetGetYetki();
        vMusteri = vYetki == 1 ? -1 : vMusteri;
        DataTable dt = cls.Proc_Arac_Iade(vMusteri);

        rdGridListe.DataSource = dt;
        if (!pNeed) rdGridListe.DataBind();



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



    protected void rdGridListe_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        dbList(true);
    }

    protected void rdGridListe_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdGridListe.SelectedItems.Count > 0)
        {


        }
    }




    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        if (!chkOnay.Checked)
        {
            HataGoster("Araç İade Onay Kutusunu İşaretleyiniz...", false);
            return;
        }
        long vAracId = -1;
        long vKayitId = -1;
        long vKm = 0;
        long vKmKayit = 0;
        if (rdGridListe.SelectedItems.Count > 0)
        {
            GridDataItem vItem = (GridDataItem)rdGridListe.SelectedItems[0];
            vAracId = Int64.Parse(vItem.GetDataKeyValue("ARAC_ID").ToString());
            vKayitId = Int64.Parse(vItem.GetDataKeyValue("ID").ToString());
            vKmKayit = Int64.Parse(vItem.GetDataKeyValue("KM").ToString());
        }
        else
        {
            HataGoster("İade Edileçek Kaydı Seçiniz...", false);
            return;
        }


        vKm = cls.Int64(cls.rbsSqlTemizle(txtSonKm.Text));
        if (vKmKayit > vKm)
        {
            HataGoster("Araç Son Km'sini Hatalı Girdiniz...", false);
            return;
        }
        if (vAracId == -1)
        {
            HataGoster("Araç Seçilmedi...", false);
            return;
        }
        if (vKayitId == -1)
        {
            HataGoster("Kayıt Seçilmedi...", false);
            return;
        }


        string vSonuc = cls.PROC_ARAC_IADE_EKLE(vKayitId,vAracId,vKm);
        if (vSonuc.StartsWith("UPDATE"))
        {
            dbList(false);

            HataGoster("Araç İade Kaydı  İşlendi...", true);
            
            chkOnay.Checked = false;
            txtSonKm.Text = string.Empty;
        }
        else
        {
            HataGoster(vSonuc, false);
        }
    }


    protected void RadMenu1_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
    {
        Session["pLogin"] = "";
        Session["pYetki"] = "";
        Session["pMusteriId"] = "";
        Session["pMusteriAd"] = "";
        Session["pMusteriSAd"] = "";
        Response.Redirect("~/Login.aspx");

    }


}
