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

public partial class frmArac : System.Web.UI.Page
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
            if (cls.GetGetYetki()!=1)
            {
                pnlIslem.Visible = false;
                return;
            }
            else
            {
                pnlIslem.Visible = true;    
                dbList(false);

                cls.dbSozlukDoldur(cmbMarkaModel, 1, ".. Seçiniz .."); //marka model kombosunu doldur
                cls.dbSozlukDoldur(cmbAracRenk, 5, ".. Seçiniz ..");
                cls.dbSozlukDoldur(cmbAracVites, 2, ".. Seçiniz ..");
                cls.dbSozlukDoldur(cmbAracyil, 4, ".. Seçiniz ..");
                cls.dbSozlukDoldur(cmbAracYakit, 3, ".. Seçiniz ..");
            }

        }
    }
  // bekle bakayım
    private void dbList(bool pNeed)
    {
        DataTable dt = cls.AracSelect(-1);

        rdGridListe.DataSource = dt;
        if (!pNeed) rdGridListe.DataBind();

        rgResimler.DataSource = new object[0]; //BOŞ RESİM GRİDİ GÖSTERME
        rgResimler.DataBind();


    }

    private void dbListFoto(long pAracId, bool pNeed)
    {

        DataTable dt = cls.AracFotoSelect(pAracId);

        rgResimler.DataSource = dt;
        if (!pNeed) rgResimler.DataBind();



    }
    protected void btnYeni_Click(object sender, EventArgs e)
    {
        txtBakimKmPeriyot.Text = string.Empty;
        txtKm.Text = string.Empty;
        txtPlaka.Text = string.Empty;
        txtSase.Text = string.Empty;
        txtGunluktUcret.Text = string.Empty;


        RDSonBakimGun.SelectedDate = null;
        txtSonBakimKm.Text = string.Empty;
        RDSonMuayeneGun.SelectedDate = null;

        cmbAracRenk.SelectedValue = "-1";
        cmbAracVites.SelectedValue = "-1";
        cmbAracYakit.SelectedValue = "-1";
        cmbAracyil.SelectedValue = "-1";
        cmbMarkaModel.SelectedValue = "-1";


        rdGridListe.SelectedIndexes.Clear();

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

    protected void btnKaydet_Click(object sender, EventArgs e)
    {//araç kaydetdem update click
        long vId = -1;
        if (rdGridListe.SelectedItems.Count > 0)
        {
            GridDataItem vItem = (GridDataItem)rdGridListe.SelectedItems[0];
            vId = Int64.Parse(vItem.GetDataKeyValue("ARAC_ID").ToString());
        }

        long vMARKAMODEL = cls.Int64(cmbMarkaModel.SelectedValue);
        long vYIL = cls.Int64(cmbAracyil.SelectedValue);
        long vYAKIT = cls.Int64(cmbAracYakit.SelectedValue);
        long vVITES = cls.Int64(cmbAracVites.SelectedValue);
        long vRENK = cls.Int64(cmbAracRenk.SelectedValue);




        if (vMARKAMODEL == -1 || vYIL == -1 || vYAKIT == -1 || vVITES == -1 || vRENK == -1)
        {
            HataGoster("Gerekli Değerleri Seçiniz...", false);
            return;
        }
        string vSASE_NO = txtSase.Text;
        string vPLAKA = txtPlaka.Text;
        long vKM = Int64.Parse(txtKm.Text);
        long vBAKIM_KM_PERIYOT = Int64.Parse(txtBakimKmPeriyot.Text);
        long vSON_BAKIM_KM = Int64.Parse(txtSonBakimKm.Text);
        long vMusaitmi = 0;
        long vGunlukUcret = Int64.Parse(txtGunluktUcret.Text);
        if (cls.GetIsNotDate(RDSonBakimGun) || cls.GetIsNotDate(RDSonMuayeneGun))
        {
            HataGoster("Son Bakım Gün ve Son Muayene Günü Yazınız...", false);
            return;
        }

        string vSON_BAKIM_GUN = RDSonBakimGun.SelectedDate.Value.ToShortDateString();
        string vSON_MUAYENE_GUN = RDSonMuayeneGun.SelectedDate.Value.ToShortDateString();



        string vSonuc =  cls.AracKaydet(vId, vSASE_NO,vPLAKA,vMARKAMODEL,vVITES,vYIL,vRENK,vKM,vBAKIM_KM_PERIYOT,vMusaitmi,vSON_MUAYENE_GUN,vSON_BAKIM_KM,vSON_BAKIM_GUN,vYAKIT, vGunlukUcret);
        if (vSonuc.StartsWith("INSERT") || vSonuc.StartsWith("UPDATE"))
        {
            dbList(false);
            HataGoster("Bilgiler Kaydedildi...", true);
            string vKayitId = vSonuc.Split('@')[1];
            cls.rgSelectRowWithSpecifiedID(rdGridListe, "ARAC_ID", vKayitId);
            dbListFoto(cls.Int64( vKayitId), false);
        }
        else
        {
            HataGoster(vSonuc, false);
        }


    }

    protected void rdGridListe_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        dbList(true);
    }

    protected void rdGridListe_SelectedIndexChanged(object sender, EventArgs e)
    {// gride tıkladığımızda verileri soldaki texboxlara ve comboya atama yeri GetDataKeyValue veri tabanı alanları
        if (rdGridListe.SelectedItems.Count > 0)
        {
            GridDataItem vItem = (GridDataItem)rdGridListe.SelectedItems[0];
            long vAracId = Int64.Parse(vItem.GetDataKeyValue("ARAC_ID").ToString());

            string SASE_NO = vItem.GetDataKeyValue("SASE_NO").ToString();
            string PLAKA = vItem.GetDataKeyValue("PLAKA").ToString();
            string MARKAMODEL = vItem.GetDataKeyValue("MARKAMODEL").ToString();//
            string VITES = vItem.GetDataKeyValue("VITES").ToString();   //
            string YIL = vItem.GetDataKeyValue("YIL").ToString();  //
            string RENK = vItem.GetDataKeyValue("RENK").ToString();//
            string KM = vItem.GetDataKeyValue("KM").ToString();
            string BAKIM_KM_PERIYOT = vItem.GetDataKeyValue("BAKIM_KM_PERIYOT").ToString();
            string MUSAITMI = vItem.GetDataKeyValue("MUSAITMI").ToString();
            string SON_MUAYENE_GUN = vItem.GetDataKeyValue("SON_MUAYENE_GUN").ToString();
            string SON_BAKIM_KM = vItem.GetDataKeyValue("SON_BAKIM_KM").ToString();
            string SON_BAKIM_GUN = vItem.GetDataKeyValue("SON_BAKIM_GUN").ToString();
            string YAKIT = vItem.GetDataKeyValue("YAKIT").ToString();//
            string GUNLUK_UCRET = vItem.GetDataKeyValue("GUNLUK_UCRET").ToString();

            cmbMarkaModel.SelectedValue = MARKAMODEL;
            cmbAracyil.SelectedValue = YIL;
            cmbAracYakit.SelectedValue = YAKIT;
            cmbAracVites.SelectedValue = VITES;
            cmbAracRenk.SelectedValue = RENK;

            txtSase.Text = SASE_NO;
            txtPlaka.Text = PLAKA;
            txtKm.Text = KM;
            txtBakimKmPeriyot.Text = BAKIM_KM_PERIYOT;
            txtSonBakimKm.Text = SON_BAKIM_KM;
            txtGunluktUcret.Text = GUNLUK_UCRET;

            RDSonBakimGun.SelectedDate = DateTime.Parse(SON_BAKIM_GUN);
            RDSonMuayeneGun.SelectedDate = DateTime.Parse(SON_MUAYENE_GUN);
            dbListFoto(vAracId, false);








            //   dbListFoto(vAracId, false);

            HataGoster("", false);
        }
    }

    protected void btnYeniResim_Click(object sender, EventArgs e)
    {

    }

    protected void btnResimKaydet_Click(object sender, EventArgs e)
    { //arac resim kaydetme 
        long vAracId = -1;
        if (rdGridListe.SelectedItems.Count > 0)
        {
            GridDataItem vItem = (GridDataItem)rdGridListe.SelectedItems[0];
            vAracId = Int64.Parse(vItem.GetDataKeyValue("ARAC_ID").ToString());
        }
        else
        {
            HataGoster("Arac Seçiniz...", false);
            return;
        }
        long vFotoId = -1;
        if (rgResimler.SelectedItems.Count > 0)
        {
            GridDataItem vItem = (GridDataItem)rgResimler.SelectedItems[0];
            vFotoId = Int64.Parse(vItem.GetDataKeyValue("ARAC_FOTO_ID").ToString());
        }
        if (uploadLogo.UploadedFiles.Count != 1)
        {
            HataGoster("Resim Seçiniz...", false);
            return;
        }

        UploadedFile vFile = uploadLogo.UploadedFiles[0];

        Stream stream = vFile.InputStream;
        byte[] vFileData = new byte[stream.Length];
        stream.Read(vFileData, 0, vFileData.Length);

        string vFotoSonuc = cls.AracFotoKaydet(vFotoId, vAracId, vFileData);
        if (vFotoSonuc.StartsWith("INSERT") || vFotoSonuc.StartsWith("UPDATE"))
        {
            dbListFoto(vAracId, false);
            HataGoster("Resim Bilgiler Kaydedildi...", true);

        }
        else
        {
            HataGoster(vFotoSonuc, false);
        }
    }

    protected void rgResimler_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    }

    protected void rgResimler_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void rdGridListe_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            if (e.CommandName=="btnSil")
            {
                GridDataItem vItem = (GridDataItem)e.Item;
                long vId = cls.Int64(vItem.GetDataKeyValue("ARAC_ID").ToString());
                if (vId==-1)
                {
                    HataGoster("Silinecek Kayıt Seçilemedi...", false);
                    return;
                }

                string vSonuc = cls.Proc_Sil(vId, 3);
                if (vSonuc.StartsWith("DELETE"))
                {
                    dbList(false);
                    HataGoster("Araç Kaydı Silindi...", true);

                }
            }
        }
    }

    protected void rgResimler_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            if (e.CommandName == "btnSil")
            {
                GridDataItem vItem = (GridDataItem)e.Item;
                long vId = cls.Int64(vItem.GetDataKeyValue("ARAC_FOTO_ID").ToString());
                long vAracId = cls.Int64(vItem.GetDataKeyValue("ARAC_ID").ToString());
                if (vId == -1)
                {
                    HataGoster("Silinecek Kayıt Seçilemedi...", false);
                    return;
                }

                string vSonuc = cls.Proc_Sil(vId, 4);
                if (vSonuc.StartsWith("DELETE"))
                {

                    dbListFoto(vAracId,false);
                    HataGoster("Resim Kaydı Silindi...", true);

                }
            }
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
