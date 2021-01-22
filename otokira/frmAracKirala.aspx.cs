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

public partial class frmAracKirala : System.Web.UI.Page
{
    otokira.Class1 cls = new otokira.Class1();
    protected void Page_Load(object sender, EventArgs e)
    {





      //  lblAd.Text = Session["pMusteriAd"].ToString(); // +" "+ Session["pMusteriSAd"].ToString();
        
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
        DataTable dt = cls.KiraAracSelect(-1);

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
            lblUcret.Text = string.Empty;
            lblGun.Text = string.Empty;
            KiraHesapla();

        }
    }

    protected void rdKiraBaslangic_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        KiraHesapla();
    }

    private void KiraHesapla()
    {
        HataGoster("", false);
        if (
            cls.GetIsNotDate(rdKiraBaslangic) ||
            cls.GetIsNotDate(rdKiraBitis)
           )
        {

            lblUcret.Text = string.Empty;
            lblGun.Text = string.Empty;

        }
        else
        {
            double vGun = 0;
            DateTime dtBegin = DateTime.Parse(rdKiraBaslangic.SelectedDate.Value.ToShortDateString());
            DateTime dtEnd = DateTime.Parse(rdKiraBitis.SelectedDate.Value.ToShortDateString());
            if (dtBegin > dtEnd)
            {
                lblUcret.Text = string.Empty;
                lblGun.Text = string.Empty;

                HataGoster("Kiralama Başlangıc Tarihini Hatalı Girdiniz...", false);
                return;
            }
            vGun = Math.Round((dtEnd - dtBegin).TotalDays) + 1;
            lblGun.Text = vGun.ToString();
            if (rdGridListe.SelectedItems.Count > 0)
            {
                GridDataItem vItem = (GridDataItem)rdGridListe.SelectedItems[0];
                long vUcret = cls.Int64(vItem.GetDataKeyValue("GUNLUK_UCRET").ToString());
                lblUcret.Text = (vUcret * vGun).ToString();
            }
            else
            {
                HataGoster("Kiralanacak Araç Seçilmedi...", false);
                return;
            }

        }
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        if (!chkOnay.Checked)
        {
             HataGoster("Araç Kiralama Onay Kutusunu İşaretleyiniz...", false);
            return;
        }
        long vAracId = -1;
        if (rdGridListe.SelectedItems.Count > 0)
        {
            GridDataItem vItem = (GridDataItem)rdGridListe.SelectedItems[0];
            vAracId = Int64.Parse(vItem.GetDataKeyValue("ARAC_ID").ToString());
        }
        if (vAracId == -1)
        {
            HataGoster("Araç Seçilmedi...", false);
            return;
        }
        long vMusteriId = cls.GetMusteriId();
        if (vMusteriId == -1)
        {
            HataGoster("Müşteri Bilgisi Hatalı...", false);
            return;
        }
        string vBaslangicTarihi = string.Empty;
        string vBitisTarihi = string.Empty;
        double vGun = 0;
        long vUcret = 0;
        if (
            cls.GetIsNotDate(rdKiraBaslangic) ||
            cls.GetIsNotDate(rdKiraBitis)
           )
        {
            HataGoster("Kiralama Başlangıc Bitiş Tarihlerini Giriniz...", false);
            return;


        }
        else
        {

            DateTime dtBegin = DateTime.Parse(rdKiraBaslangic.SelectedDate.Value.ToShortDateString());
            DateTime dtEnd = DateTime.Parse(rdKiraBitis.SelectedDate.Value.ToShortDateString());
            if (dtBegin > dtEnd)
            {
                lblUcret.Text = string.Empty;
                lblGun.Text = string.Empty;

                HataGoster("Kiralama Başlangıc Tarihini Hatalı Girdiniz...", false);
                return;
            }
            vBaslangicTarihi=rdKiraBaslangic.SelectedDate.Value.ToShortDateString();
            vBitisTarihi=rdKiraBitis.SelectedDate.Value.ToShortDateString();

            vGun = Math.Round((dtEnd - dtBegin).TotalDays) + 1;
            lblGun.Text = vGun.ToString();

            GridDataItem vItem = (GridDataItem)rdGridListe.SelectedItems[0];
            vUcret = cls.Int64(vItem.GetDataKeyValue("GUNLUK_UCRET").ToString());
            lblUcret.Text = (vUcret * vGun).ToString();


        }
       

        string vSonuc = cls.Proc_otokiralama(vAracId,vMusteriId,vBaslangicTarihi,vBitisTarihi,vGun,vUcret);
        if (vSonuc.StartsWith("INSERT") )
        {
            dbList(false);

            HataGoster("Kiralama Kaydı  İşlendi...", true);
            lblUcret.Text = string.Empty;
            lblGun.Text = string.Empty;
            chkOnay.Checked = false;
           
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
