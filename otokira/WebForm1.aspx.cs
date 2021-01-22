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


namespace otokira
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        otokira.Class1 cls = new otokira.Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                dbList(false);

            }
        }
        private void dbList(bool pNeed)
        {
            DataTable dt = cls.MusteriSelect(-1);

            rdGridListe.DataSource = dt;
            if (!pNeed) rdGridListe.DataBind();

            rgResimler.DataSource = new object[0];
            rgResimler.DataBind();


        }

        private void dbListFoto(long pMusteriId, bool pNeed)
        {
            DataTable dt = cls.MusteriFotoSelect(pMusteriId);

            rgResimler.DataSource = dt;
            if (!pNeed) rgResimler.DataBind();



        }
        protected void btnYeni_Click(object sender, EventArgs e)
        {
            txtAd.Text = string.Empty;
            txtAdres.Text = string.Empty;
            txtEhliyetNo.Text = string.Empty;
            txtEMail.Text = string.Empty;
            txtSoyad.Text = string.Empty;
            txtTc.Text = string.Empty;
            txtTel.Text = string.Empty;

            rdGridListe.SelectedIndexes.Clear();

        }
        #region ..: HataGoster       :..
        private void HataGoster(string pErrMsg, bool pGreen)
        {


            lblHata.Visible = !string.IsNullOrEmpty(pErrMsg);
            imgHata.Visible = !string.IsNullOrEmpty(pErrMsg);
            lblHata.ForeColor = pGreen ? System.Drawing.Color.Green : System.Drawing.Color.OrangeRed;
            imgHata.ImageUrl = pGreen ? "~/Images/iconTools/MessageOk.png" : "~/Images/iconTools/warning.png";
            lblHata.Font.Bold = true;
            lblHata.Text = pErrMsg;
        }
        #endregion

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            long vId = -1;
            if (rdGridListe.SelectedItems.Count > 0)
            {
                GridDataItem vItem = (GridDataItem)rdGridListe.SelectedItems[0];
                vId = Int64.Parse(vItem.GetDataKeyValue("MUSTERI_ID").ToString());
            }

            long vTc = Int64.Parse(txtTc.Text);
            string vAd = txtAd.Text;
            string vSoyad = txtSoyad.Text;
            string vTel = txtTel.Text;
            string vEmail = txtEMail.Text;
            string vSifre = txtSifre.Text;
            string vAdres = txtAdres.Text;
            string vEhliyet = txtEhliyetNo.Text;

            string vSonuc = cls.MusteriKaydet(vId, vTc, vAd, vSoyad, vAdres, vEmail, vEhliyet, vTel, vSifre, "-1");
            if (vSonuc.StartsWith("INSERT") || vSonuc.StartsWith("UPDATE"))
            {
                dbList(false);
                HataGoster("Bilgiler Kaydedildi...", true);
                string vKayitId = vSonuc.Split('@')[1];
                cls.rgSelectRowWithSpecifiedID(rdGridListe, "MUSTERI_ID", vKayitId);
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
        {
            if (rdGridListe.SelectedItems.Count > 0)
            {
                GridDataItem vItem = (GridDataItem)rdGridListe.SelectedItems[0];

                string TC = vItem.GetDataKeyValue("TC").ToString();
                string Ad = vItem.GetDataKeyValue("Ad").ToString();
                string Soyad = vItem.GetDataKeyValue("Soyad").ToString();
                string ADRES = vItem.GetDataKeyValue("ADRES").ToString();
                string YETKI = vItem.GetDataKeyValue("YETKI").ToString();
                string MAIL = vItem.GetDataKeyValue("MAIL").ToString();
                string EHLIYETNO = vItem.GetDataKeyValue("EHLIYETNO").ToString();
                string Tel = vItem.GetDataKeyValue("Tel").ToString();
                long vMusteriId = Int64.Parse(vItem.GetDataKeyValue("MUSTERI_ID").ToString());

                txtTc.Text = TC;
                txtAd.Text = Ad;
                txtSoyad.Text = Soyad;
                txtAdres.Text = ADRES;
                txtEMail.Text = MAIL;
                txtEhliyetNo.Text = EHLIYETNO;
                txtTel.Text = Tel;

                dbListFoto(vMusteriId, false);

                HataGoster("", false);
            }
        }

        protected void btnYeniResim_Click(object sender, EventArgs e)
        {

        }

        protected void btnResimKaydet_Click(object sender, EventArgs e)
        {
            long vMusteriId = -1;
            if (rdGridListe.SelectedItems.Count > 0)
            {
                GridDataItem vItem = (GridDataItem)rdGridListe.SelectedItems[0];
                vMusteriId = Int64.Parse(vItem.GetDataKeyValue("MUSTERI_ID").ToString());
            }
            else
            {
                HataGoster("Müşteri Seçiniz...", false);
                return;
            }
            long vFotoId = -1;
            if (rgResimler.SelectedItems.Count > 0)
            {
                GridDataItem vItem = (GridDataItem)rgResimler.SelectedItems[0];
                vFotoId = Int64.Parse(vItem.GetDataKeyValue("MUSTERI_FOTO_ID").ToString());
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

            string vFotoSonuc = cls.MusteriFotoKaydet(vFotoId, vMusteriId, vFileData);
            if (vFotoSonuc.StartsWith("INSERT") || vFotoSonuc.StartsWith("UPDATE"))
            {
                dbListFoto(vMusteriId, false);
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
    }
}