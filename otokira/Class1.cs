using Microsoft.Win32;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace otokira
{
    public class Class1 : System.Web.UI.Page
    {
        public static string strOracleClient = "";

        protected const int intCommandTimeout = 20;
        public string Erfis = "";
        public Class1()
        {


            strOracleClient = "Data source=otokira;user id=otokira;password=otokira;";

        }
        #region ..: SQL Injection Cleaner :..
        /// <summary>
        /// SQL Injection Cleaner
        /// </summary>
        /// <param name="pTextBox">TextBox To Clean</param>
        public void SqlTemizle(RadTextBox pTextBox)
        {
            string[] sqlText = { "'", "=", ";", "*", "xp_" };

            pTextBox.Text = pTextBox.Text.Trim();

            for (int i = 0; i < sqlText.Length; i++)
            {
                pTextBox.Text = pTextBox.Text.Replace(sqlText[i], "");
            }
        }
        /// <summary>
        /// SQL Injection Cleaner
        /// </summary>
        /// <param name="pTextBox">TextBox To Clean</param>
        public void rbsSqlTemizle(RadNumericTextBox pTextBox)
        {
            string[] sqlText = { "'", "=", "-", ";", "*", "xp_" };

            pTextBox.Text = pTextBox.Text.Trim();

            for (int i = 0; i < sqlText.Length; i++)
            {
                pTextBox.Text = pTextBox.Text.Replace(sqlText[i], "");
            }
        }
        /// <summary>
        /// SQL Injection Cleaner
        /// </summary>
        /// <param name="pTextBox">TextBox To Clean</param>
        public void rbsSqlTemizle(RadMaskedTextBox pTextBox)
        {
            string[] sqlText = { "'", "=", "-", ";", "*", "xp_" };

            pTextBox.Text = pTextBox.Text.Trim();

            for (int i = 0; i < sqlText.Length; i++)
            {
                pTextBox.Text = pTextBox.Text.Replace(sqlText[i], "");
            }
        }
        /// <summary>
        /// SQL Injection Cleaner
        /// </summary>
        /// <param name="pTextBox">TextBox To Clean</param>
        public void rbsSqlTemizle(TextBox pTextBox)
        {
            string[] sqlText = { "'", "=", "-", ";", "*", "xp_" };

            pTextBox.Text = pTextBox.Text.Trim();

            for (int i = 0; i < sqlText.Length; i++)
            {
                pTextBox.Text = pTextBox.Text.Replace(sqlText[i], "");
            }
        }
        /// <summary>
        /// SQL Injection Cleaner
        /// </summary>
        /// <param name="pDate">DatePicker To Clean</param>
        public void rbsSqlTemizle(RadDatePicker pDate)
        {
            string[] sqlText = { "'", "=", "-", ";", "*", "xp_" };

            pDate.DateInput.Text = pDate.DateInput.Text.Trim();

            string vDate = pDate.DateInput.Text;

            for (int i = 0; i < sqlText.Length; i++)
            {
                vDate = pDate.DateInput.Text.Replace(sqlText[i], "");
            }
            pDate.DateInput.Text = vDate;
        }

        public string rbsSqlTemizle(string vText)
        {
            string vIcerik = vText;

            int vSelect = vText.ToUpper().IndexOf("SELECT");
            int vUpdate = vText.ToUpper().IndexOf("UPDATE");
            int vInsert = vText.ToUpper().IndexOf("INSERT");
            int vDelete = vText.ToUpper().IndexOf("DELETE");

            if (vSelect != -1 || vUpdate != -1 || vInsert != -1 || vDelete != -1)
                vText = "Hata!";
            return vText;
        }

        #endregion

        #region ..: rgSelectRowWithSpecifiedID :..
        public void rgSelectRowWithSpecifiedID(RadGrid pGrid, string pDataKeyName, string vIDtoSelect)
        {
            foreach (GridDataItem vItem in pGrid.Items)
            {
                string vItemKey = vItem.GetDataKeyValue(pDataKeyName).ToString();
                if (vItemKey == vIDtoSelect)
                {
                    vItem.Selected = true;
                    break;
                }
            }
        } 
        #endregion

        #region ..: MUSTERI SELECT
        public DataTable MusteriSelect(long P_MUSTERI_ID)
        {

            OracleConnection cnn;
            OracleDataAdapter adp;
            OracleCommand cmd;
            DataTable dt;

            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();
            dt = new DataTable();
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_otokira_musteri_getir";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add("P_MUSTERI_ID", OracleDbType.Int64, P_MUSTERI_ID, ParameterDirection.Input);
                cmd.Parameters.Add("AIOCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                adp = new OracleDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(dt);
                adp.Dispose();

                cnn.Close();
                dt.Dispose();

                return dt;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();
                dt.Dispose();
            }
            return dt;
        }

        #endregion

        #region ..: MUSTERI KAYDET
        public string MusteriKaydet
            (
            long P_MUSTERI_ID,
            long P_TC,
            string P_AD,
            string P_SOYAD,
            string P_ADRES,
            string P_MAIL,
            string P_EHLIYETNO,
            string P_TEL,
            string P_SIFRE,
            string P_YETKI

            )
        {

            OracleConnection cnn;

            OracleCommand cmd;


            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();

            string vSonuc = string.Empty;
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_otokira_musteri_ekle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;


                cmd.Parameters.Add("P_MUSTERI_ID", OracleDbType.Int64, P_MUSTERI_ID, ParameterDirection.Input);
                cmd.Parameters.Add("P_TC", OracleDbType.Int64, P_TC, ParameterDirection.Input);
                cmd.Parameters.Add("P_AD", OracleDbType.Varchar2, P_AD, ParameterDirection.Input);
                cmd.Parameters.Add("P_SOYAD", OracleDbType.Varchar2, P_SOYAD, ParameterDirection.Input);
                cmd.Parameters.Add("P_TEL", OracleDbType.Varchar2, P_TEL, ParameterDirection.Input);
                cmd.Parameters.Add("P_ADRES", OracleDbType.Varchar2, P_ADRES, ParameterDirection.Input);
                cmd.Parameters.Add("P_EHLIYETNO", OracleDbType.Varchar2, P_EHLIYETNO, ParameterDirection.Input);
                cmd.Parameters.Add("P_YETKI", OracleDbType.Varchar2, P_YETKI, ParameterDirection.Input);
                cmd.Parameters.Add("P_MAIL", OracleDbType.Varchar2, P_MAIL, ParameterDirection.Input);
                cmd.Parameters.Add("P_SIFRE", OracleDbType.Varchar2, P_SIFRE, ParameterDirection.Input);
                cmd.Parameters.Add(new OracleParameter("SONUC", OracleDbType.Varchar2, 255, "", ParameterDirection.Output));
                cmd.ExecuteNonQuery();
                vSonuc = cmd.Parameters["SONUC"].Value.ToString();
                cmd.Dispose();
                return vSonuc;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();

            }
            return vSonuc;
        }

        #endregion

        #region ..: PROC_ARAC_IADE_EKLE
        public string PROC_ARAC_IADE_EKLE
            (
                long p_ID,
                long p_ARAC_ID,
                long p_KM


            )
        {

            OracleConnection cnn;

            OracleCommand cmd;


            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();



            string vSonuc = string.Empty;
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.PROC_ARAC_IADE_EKLE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;


                cmd.Parameters.Add("p_ID", OracleDbType.Int64, p_ID, ParameterDirection.Input);
                cmd.Parameters.Add("p_ARAC_ID", OracleDbType.Int64, p_ARAC_ID, ParameterDirection.Input);
                cmd.Parameters.Add("p_KM", OracleDbType.Int64, p_KM, ParameterDirection.Input);


                cmd.Parameters.Add(new OracleParameter("SONUC", OracleDbType.Varchar2, 255, "", ParameterDirection.Output));
                cmd.ExecuteNonQuery();
                vSonuc = cmd.Parameters["SONUC"].Value.ToString();
                cmd.Dispose();
                return vSonuc;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();

            }
            return vSonuc;
        }

        #endregion

        #region ..: Proc_otokiralama
        public string Proc_otokiralama
            (
                long p_AracId,           
                long p_MusteriId,        
                string p_BaslangicTarihi  ,
                string p_BitisTarihi,      
                double p_Gun ,             
                long p_Ucret 

            )
        {

            OracleConnection cnn;

            OracleCommand cmd;


            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();
          
             

            string vSonuc = string.Empty;
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_otokiralama";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;


                cmd.Parameters.Add("p_AracId", OracleDbType.Int64, p_AracId, ParameterDirection.Input);
                cmd.Parameters.Add("p_MusteriId", OracleDbType.Int64, p_MusteriId, ParameterDirection.Input);
                cmd.Parameters.Add("p_BaslangicTarihi", OracleDbType.Varchar2, p_BaslangicTarihi, ParameterDirection.Input);
                cmd.Parameters.Add("p_BitisTarihi", OracleDbType.Varchar2, p_BitisTarihi, ParameterDirection.Input);
                cmd.Parameters.Add("p_Gun", OracleDbType.Double, p_Gun, ParameterDirection.Input);
                cmd.Parameters.Add("p_Ucret", OracleDbType.Int64, p_Ucret, ParameterDirection.Input);
               
                cmd.Parameters.Add(new OracleParameter("SONUC", OracleDbType.Varchar2, 255, "", ParameterDirection.Output));
                cmd.ExecuteNonQuery();
                vSonuc = cmd.Parameters["SONUC"].Value.ToString();
                cmd.Dispose();
                return vSonuc;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();

            }
            return vSonuc;
        }

        #endregion

        #region ..: MUSTERI FOTO SELECT
        public DataTable MusteriFotoSelect(long P_MUSTERI_ID)
        {

            OracleConnection cnn;
            OracleDataAdapter adp;
            OracleCommand cmd;
            DataTable dt;

            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();
            dt = new DataTable();
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_otokira_musterifotogetir";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add("P_MUSTERI_ID", OracleDbType.Int64, P_MUSTERI_ID, ParameterDirection.Input);
                cmd.Parameters.Add("AIOCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                adp = new OracleDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(dt);
                adp.Dispose();

                cnn.Close();
                dt.Dispose();

                return dt;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();
                dt.Dispose();
            }
            return dt;
        }
        #endregion

        #region ..: Guvenlik :..
        public int SecurityCheck()
        {
            int vLogin = 0;

            try
            {
                 vLogin = Int16(Session["pLogin"].ToString());

            }
            catch (Exception ex)
            {

                vLogin = 0;
                return vLogin;
            }



            return vLogin;
        }

        #endregion

        #region ..: GetMusteriId :..
        public int GetMusteriId()
        {
            int vMusteriId = 0;

            try
            {
                vMusteriId = Int16(Session["pMusteriId"].ToString());

            }
            catch (Exception ex)
            {

                vMusteriId = -1;
                return vMusteriId;
            }



            return vMusteriId;
        }

        #endregion

        #region ..: GetGetYetki :..
        public int GetGetYetki()
        {
            int vMusteriId = 0;

            try
            {
                vMusteriId = Int16(Session["pYetki"].ToString());

            }
            catch (Exception ex)
            {

                vMusteriId = -1;
                return vMusteriId;
            }



            return vMusteriId;
        }

        #endregion

        #region ..: Proc_otokira_login
        public DataTable Proc_otokira_login(string p_UserName, string p_Sifre)
        {

            OracleConnection cnn;
            OracleDataAdapter adp;
            OracleCommand cmd;
            DataTable dt;

            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();
            dt = new DataTable();
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_otokira_musteri_login";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add("p_UserName", OracleDbType.Varchar2, p_UserName, ParameterDirection.Input);
                cmd.Parameters.Add("p_Sifre", OracleDbType.Varchar2, p_Sifre, ParameterDirection.Input);
                cmd.Parameters.Add("AIOCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                adp = new OracleDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(dt);
                adp.Dispose();

                cnn.Close();
                dt.Dispose();

                return dt;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();
                dt.Dispose();
            }
            return dt;
        }
        #endregion

        #region ..: MUSTERI FOTO KAYDET
        public string MusteriFotoKaydet
            (
                long P_MUSTERI_FOTO_ID,
                long P_MUSTERI_ID,
                byte[] P_FOTO

            )
        {

            OracleConnection cnn;

            OracleCommand cmd;


            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();

            string vSonuc = string.Empty;
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_otokira_musteri_foto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;


                cmd.Parameters.Add("P_MUSTERI_FOTO_ID", OracleDbType.Int64, P_MUSTERI_FOTO_ID, ParameterDirection.Input);
                cmd.Parameters.Add("P_MUSTERI_ID", OracleDbType.Int64, P_MUSTERI_ID, ParameterDirection.Input);
                cmd.Parameters.Add("P_FOTO", OracleDbType.Blob, P_FOTO, ParameterDirection.Input);
               
                cmd.Parameters.Add(new OracleParameter("SONUC", OracleDbType.Varchar2, 255, "", ParameterDirection.Output));
                cmd.ExecuteNonQuery();
                vSonuc = cmd.Parameters["SONUC"].Value.ToString();
                cmd.Dispose();
                return vSonuc;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();

            }
            return vSonuc;
        }

        #endregion

        // araç ile ilgili klasslar
        #region ..: string To Int16 :..
        /// <summary>
        /// String To Int16 conversion. On Error returns -1
        /// </summary>
        /// <param name="pSayi"></param>
        /// <returns>Int16 / -1</returns>
        public int Int16(string pSayi)
        {
            int vSayi = -1;

            try { vSayi = Convert.ToInt16((pSayi.Trim())); }
            catch { vSayi = -1; }

            return vSayi;
        }

        #endregion

        #region ..: string To Int64 :..
        /// <summary>
        /// string To Int64 conversion. On Error returns -1
        /// </summary>
        /// <param name="pSayi">String Sayı</param>
        /// <returns>Int64 / -1</returns>
        public long Int64(string pSayi)
        {
            long vSayi = -1;

            try { vSayi = Convert.ToInt64(pSayi.Trim()); }
            catch { vSayi = -1; }

            return vSayi;
        }

        #endregion
        #region ..: GetIsDate :..
        public bool GetIsNotDate(RadDatePicker vDate)
        {

            try
            {
                DateTime Date = (DateTime)vDate.SelectedDate;

            }
            catch
            {

                return true; ;
            }
            return false;
        }
        #endregion

        #region ..: GetIsDate :..
        public bool GetIsDate(string vDate)
        {

            try
            {
                DateTime vCevir = Convert.ToDateTime(vDate);

            }
            catch
            {

                return false; ;
            }
            return true;
        }
        #endregion

        #region ..: ARAÇ SELECT
        public DataTable AracSelect(long P_ARAC_ID)
        {

            OracleConnection cnn;
            OracleDataAdapter adp;
            OracleCommand cmd;
            DataTable dt;

            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();
            dt = new DataTable();
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_otokira_arac_getir";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add("P_ARAC_ID", OracleDbType.Int64, P_ARAC_ID, ParameterDirection.Input);
                cmd.Parameters.Add("AIOCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                adp = new OracleDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(dt);
                adp.Dispose();

                cnn.Close();
                dt.Dispose();

                return dt;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();
                dt.Dispose();
            }
            return dt;
        }

        #endregion

        #region ..:Kira ARAÇ SELECT
        public DataTable KiraAracSelect(long P_ARAC_ID)
        {

            OracleConnection cnn;
            OracleDataAdapter adp;
            OracleCommand cmd;
            DataTable dt;

            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();
            dt = new DataTable();
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_Arac_Kirala";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add("P_ARAC_ID", OracleDbType.Int64, P_ARAC_ID, ParameterDirection.Input);
                cmd.Parameters.Add("AIOCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                adp = new OracleDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(dt);
                adp.Dispose();

                cnn.Close();
                dt.Dispose();

                return dt;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();
                dt.Dispose();
            }
            return dt;
        }

        #endregion

        #region ..:Proc_Arac_Iade
        public DataTable Proc_Arac_Iade(long P_MUSTERI_ID)
        {

            OracleConnection cnn;
            OracleDataAdapter adp;
            OracleCommand cmd;
            DataTable dt;

            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();
            dt = new DataTable();
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_Arac_Iade";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add("P_MUSTERI_ID", OracleDbType.Int64, P_MUSTERI_ID, ParameterDirection.Input);
                cmd.Parameters.Add("AIOCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                adp = new OracleDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(dt);
                adp.Dispose();

                cnn.Close();
                dt.Dispose();

                return dt;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();
                dt.Dispose();
            }
            return dt;
        }

        #endregion

        #region ..: ARAC KAYDET
        public string AracKaydet
            (
            long   P_ARAC_ID         ,
            string   P_SASE_NO         ,
            string P_PLAKA           ,
            long   P_MARKAMODEL      ,
            long   P_VITES           ,
            long   P_YIL             ,
            long   P_RENK            ,
            long   P_KM              ,
            long   P_BAKIM_KM_PERIYOT,
            long   P_MUSAITMI        ,
            string P_SON_MUAYENE_GUN ,
            long   P_SON_BAKIM_KM    ,
            string  P_SON_BAKIM_GUN   ,
            long   P_YAKIT           ,
            long   P_GUNLUK_UCRET
                                     
           

            )
        {

            OracleConnection cnn;

            OracleCommand cmd;


            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();

            string vSonuc = string.Empty;
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_otokira_arac_ekle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;


                cmd.Parameters.Add("P_ARAC_ID", OracleDbType.Int64, P_ARAC_ID, ParameterDirection.Input);
                cmd.Parameters.Add("P_SASE_NO", OracleDbType.Varchar2, P_SASE_NO, ParameterDirection.Input);
                cmd.Parameters.Add("P_PLAKA", OracleDbType.Varchar2, P_PLAKA, ParameterDirection.Input);
                cmd.Parameters.Add("P_MARKAMODEL", OracleDbType.Int64, P_MARKAMODEL, ParameterDirection.Input);
                cmd.Parameters.Add("P_VITES", OracleDbType.Int64, P_VITES, ParameterDirection.Input);
                cmd.Parameters.Add("P_YIL", OracleDbType.Int64, P_YIL, ParameterDirection.Input);
                cmd.Parameters.Add("P_RENK", OracleDbType.Int64, P_RENK, ParameterDirection.Input);
                cmd.Parameters.Add("P_KM", OracleDbType.Int64, P_KM, ParameterDirection.Input);
                cmd.Parameters.Add("P_BAKIM_KM_PERIYOT", OracleDbType.Int64, P_BAKIM_KM_PERIYOT, ParameterDirection.Input);
                cmd.Parameters.Add("P_MUSAITMI", OracleDbType.Int64, P_MUSAITMI, ParameterDirection.Input);
                cmd.Parameters.Add("P_SON_MUAYENE_GUN", OracleDbType.Varchar2, P_SON_MUAYENE_GUN, ParameterDirection.Input);
                cmd.Parameters.Add("P_SON_BAKIM_KM", OracleDbType.Int64, P_SON_BAKIM_KM, ParameterDirection.Input);
                cmd.Parameters.Add("P_SON_BAKIM_GUN", OracleDbType.Varchar2, P_SON_BAKIM_GUN, ParameterDirection.Input);
                cmd.Parameters.Add("P_YAKIT", OracleDbType.Int64, P_YAKIT, ParameterDirection.Input);
                cmd.Parameters.Add("P_GUNLUK_UCRET", OracleDbType.Int64, P_GUNLUK_UCRET, ParameterDirection.Input);

                cmd.Parameters.Add(new OracleParameter("SONUC", OracleDbType.Varchar2, 255, "", ParameterDirection.Output));
                cmd.ExecuteNonQuery();
                vSonuc = cmd.Parameters["SONUC"].Value.ToString();
                cmd.Dispose();
                return vSonuc;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();

            }
            return vSonuc;
        }

        #endregion

        #region ..: ARAÇ FOTO SELECT
        public DataTable AracFotoSelect(long P_ARAC_ID)
        {

            OracleConnection cnn;
            OracleDataAdapter adp;
            OracleCommand cmd;
            DataTable dt;

            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();
            dt = new DataTable();
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_otokira_aracfotogetir";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add("P_ARAC_ID", OracleDbType.Int64, P_ARAC_ID, ParameterDirection.Input);
                cmd.Parameters.Add("AIOCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                adp = new OracleDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(dt);
                adp.Dispose();

                cnn.Close();
                dt.Dispose();

                return dt;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();
                dt.Dispose();
            }
            return dt;
        }
        #endregion

        #region ..: ARAC FOTO KAYDET
        public string AracFotoKaydet
            (
                long P_ARAC_FOTO_ID,
                long P_ARAC_ID,
                byte[] P_FOTO

            )
        {

            OracleConnection cnn;

            OracleCommand cmd;


            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();

            string vSonuc = string.Empty;
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_otokira_arac_foto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;


                cmd.Parameters.Add("P_ARAC_FOTO_ID", OracleDbType.Int64, P_ARAC_FOTO_ID, ParameterDirection.Input);
                cmd.Parameters.Add("P_ARAC_ID", OracleDbType.Int64, P_ARAC_ID, ParameterDirection.Input);
                cmd.Parameters.Add("P_FOTO", OracleDbType.Blob, P_FOTO, ParameterDirection.Input);

                cmd.Parameters.Add(new OracleParameter("SONUC", OracleDbType.Varchar2, 255, "", ParameterDirection.Output));
                cmd.ExecuteNonQuery();
                vSonuc = cmd.Parameters["SONUC"].Value.ToString();
                cmd.Dispose();
                return vSonuc;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();

            }
            return vSonuc;
        }

        #endregion

        #region ..: ARAC FOTO KAYDET
        public string Proc_Sil
            (
                long P_ID,
                int P_Sorgu

            )
        {

            OracleConnection cnn;

            OracleCommand cmd;


            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();

            string vSonuc = string.Empty;
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_Sil";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;


                cmd.Parameters.Add("P_ID", OracleDbType.Int64, P_ID, ParameterDirection.Input);
                cmd.Parameters.Add("P_Sorgu", OracleDbType.Int16, P_Sorgu, ParameterDirection.Input);
                

                cmd.Parameters.Add(new OracleParameter("SONUC", OracleDbType.Varchar2, 255, "", ParameterDirection.Output));
                cmd.ExecuteNonQuery();
                vSonuc = cmd.Parameters["SONUC"].Value.ToString();
                cmd.Dispose();
                return vSonuc;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();

            }
            return vSonuc;
        }

        #endregion

        #region ..: SÖZLÜK DOLDUR
        public void dbSozlukDoldur(RadComboBox pCmbCombo, long pTabloKodu, string pFirstRow)
        {
            pCmbCombo.Items.Clear();
            pCmbCombo.DataSource = SOZLUK_DOLDUR(pTabloKodu);
            pCmbCombo.DataValueField = "ITEM_ID";
            pCmbCombo.DataTextField = "ITEM_NAME";
            pCmbCombo.DataBind();

            if (!string.IsNullOrEmpty(pFirstRow))
            {
                pCmbCombo.Items.Insert(0, new RadComboBoxItem(pFirstRow, "-1"));
                pCmbCombo.SelectedValue = "-1";

            }

        }

        public DataTable SOZLUK_DOLDUR(long PARENT_ID)
        {

            OracleConnection cnn;
            OracleDataAdapter adp;
            OracleCommand cmd;
            DataTable dt;

            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();
            dt = new DataTable();
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.SOZLUK_DOLDUR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add("PARENT_ID", OracleDbType.Int64, PARENT_ID, ParameterDirection.Input);
                cmd.Parameters.Add("AIOCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                adp = new OracleDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(dt);
                adp.Dispose();

                cnn.Close();
                dt.Dispose();

                return dt;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();
                dt.Dispose();
            }
            return dt;
        }


        #endregion

        #region ..: LOGIN
        public DataTable LOGIN(string P_MUSTERI_MAIL, string P_MUSTERI_SIFRE)
        {

            OracleConnection cnn;
            OracleDataAdapter adp;
            OracleCommand cmd;
            DataTable dt;

            cnn = new OracleConnection();
            cnn.ConnectionString = strOracleClient;

            cmd = new OracleCommand();
            dt = new DataTable();
            try
            {
                cnn.Open();
                cmd.CommandText = "OTOKIRA.Proc_otokira_musteri_login";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                cmd.Parameters.Add("P_MUSTERI_MAIL", OracleDbType.Varchar2, P_MUSTERI_MAIL, ParameterDirection.Input);
                cmd.Parameters.Add("P_MUSTERI_SIFRE", OracleDbType.Varchar2, P_MUSTERI_SIFRE, ParameterDirection.Input);
                cmd.Parameters.Add("AIOCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);
                adp = new OracleDataAdapter();

                adp.SelectCommand = cmd;

                adp.Fill(dt);
                adp.Dispose();

                cnn.Close();
                dt.Dispose();

                return dt;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cnn.Close();
                dt.Dispose();
            }
            return dt;
        }

        #endregion

















    }
}