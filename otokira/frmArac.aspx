<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmArac.aspx.cs" Inherits="frmArac" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>
        <script type="text/javascript">
            //Put your JavaScript code here.
        </script>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="btnYeni">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="pnlIslem" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btnKaydet">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="pnlIslem" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="rdGridListe">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="pnlIslem" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Metro"></telerik:RadAjaxLoadingPanel>
        <telerik:RadWindowManager ID="wManager" VisibleStatusbar="false" DestroyOnClose="true" runat="server" culture="tr-TR" IconUrl="~/Images/iconMain/logoMebk.png" Skin="Bootstrap">
            <Localization Cancel="Hayır" OK="Evet" />
        </telerik:RadWindowManager>

        <asp:Panel runat="server" ID="pnlIslem" Width="100%">
         <telerik:RadMenu RenderMode="Lightweight" ID="RadMenu1" Skin="Material" runat="server" ShowToggleHandle="true" OnItemClick="RadMenu1_ItemClick">
                <Items>
                    <telerik:RadMenuItem Text="Müşteri Tanım" NavigateUrl="frmMusteri.aspx" />
                    <telerik:RadMenuItem Text="Araç Tanım" NavigateUrl="frmArac.aspx" />
                    <telerik:RadMenuItem Text="Araç Kiralama" NavigateUrl="frmAracKirala.aspx" />
                     <telerik:RadMenuItem Text="Araç İade Etme" NavigateUrl="frmAracTeslim.aspx" />
                     <telerik:RadMenuItem Text="Çıkış Yapma" runat="server" OnItemClick="RadMenu1_ItemClick" />
                </Items>
            </telerik:RadMenu>
            <table style="width: 970px; border-spacing: 0px; margin: 0px; height: 40px;">
                <tr>

                    <td style="text-align: center; vertical-align: middle; width: 100%;">
                        <asp:Image ID="imgHata" runat="server" Visible="false" />
                        <asp:Label ID="lblHata" runat="server" Text="" Visible="false"></asp:Label>
                    </td>

                </tr>
            </table>
            <table>
                <tbody>
                    <tr>
                        <td style="width: 400px;">

                            <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%;">Araç Model

                                        </td>
                                        <td style="width: 80%;">
                                            <telerik:RadComboBox ID="cmbMarkaModel" runat="server" Width="100%" AutoPostBack="false" Skin="Bootstrap"></telerik:RadComboBox>

                                        </td>
                                    </tr>
                              
                                    <tr>
                                        <td style="width: 20%;">Araç Renk</td>
                                        <td style="width: 80%;">

                                            <telerik:RadComboBox ID="cmbAracRenk" runat="server" AutoPostBack="false" Skin="Bootstrap" Width="100%">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">Araç Vites</td>
                                        <td style="width: 80%;">

                                            <telerik:RadComboBox ID="cmbAracVites" runat="server" AutoPostBack="false" Skin="Bootstrap" Width="100%">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">Araç Yıl</td>
                                        <td style="width: 80%;">

                                            <telerik:RadComboBox ID="cmbAracyil" runat="server" AutoPostBack="false" Skin="Bootstrap" Width="100%">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">Araç Yakıt</td>
                                        <td style="width: 80%;">

                                            <telerik:RadComboBox ID="cmbAracYakit" runat="server" AutoPostBack="false" Skin="Bootstrap" Width="100%">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">Plaka

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtPlaka" Width="100%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">Şase No

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtSase" Width="100%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                  



                                    <tr>
                                        <td style="width: 10%;"></td>
                                        <td style="width: 90%;">
                                            <telerik:RadButton runat="server" ButtonType="StandardButton" Skin="Bootstrap" ID="btnYeni" Text="Yeni" OnClick="btnYeni_Click"></telerik:RadButton>
                                            <telerik:RadButton runat="server" ButtonType="StandardButton" Skin="Bootstrap" ID="btnKaydet" Text="Kaydet" OnClick="btnKaydet_Click"></telerik:RadButton>

                                        </td>
                                    </tr>

                                </tbody>
                            </table>
                        </td>

                        <td style="width: 400px;">
                            <table>
                                <tbody>
                                          <tr>
                            
                                        <td style="width: 20%;">GÜNLÜK ÜCRET

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtGunluktUcret" Width="100%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>






                                    <tr>
                            
                                        <td style="width: 20%;">KM

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtKm" Width="100%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">Bakım Periyot KM

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtBakimKmPeriyot" Width="50%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 20%;">Son Bakım Km

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtSonBakimKm" Width="100%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">Son Bakım Gün

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadDatePicker ID="RDSonBakimGun" runat="server" RenderMode="Lightweight" Skin="Bootstrap" Width="100%"></telerik:RadDatePicker>

                                        </td>
                                    </tr>



                                    <tr>
                                        <td style="width: 20%;">Son Muayene

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadDatePicker ID="RDSonMuayeneGun" runat="server" RenderMode="Lightweight" Skin="Bootstrap" Width="100%"></telerik:RadDatePicker>
                                        </td>
                                    </tr>

                                      </tbody>
                            </table>
                        </td>


                        <td style="width: 400px;">
                            <table style="width: 100%;">
                                <tbody>
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="rgResimler" runat="server" OnItemCommand="rgResimler_ItemCommand" Height="300px" Width="100%" AllowSorting="true" AutoGenerateColumns="False" Skin="Bootstrap" AllowFilteringByColumn="false" PageSize="25" AllowPaging="false" OnNeedDataSource="rgResimler_NeedDataSource" Culture="tr-TR" OnSelectedIndexChanged="rgResimler_SelectedIndexChanged">
                                                <ClientSettings EnablePostBackOnRowClick="True" Scrolling-UseStaticHeaders="true" EnableRowHoverStyle="true" Scrolling-AllowScroll="true" Selecting-AllowRowSelect="true">
                                                    <Selecting AllowRowSelect="true" />

                                                </ClientSettings>
                                                <AlternatingItemStyle />

                                                <MasterTableView DataKeyNames="ARAC_FOTO_ID,ARAC_ID,ARAC_FOTO">
                                                    <Columns>
                                                        <telerik:GridBinaryImageColumn DataField="ARAC_FOTO" HeaderText="Resimler" AutoAdjustImageControlSize="false" AllowFiltering="false" ImageHeight="128px" ImageWidth="128px" UniqueName="colKurumLogo">
                                                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Width="100%" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </telerik:GridBinaryImageColumn>
                                                        <telerik:GridButtonColumn ButtonType="ImageButton" HeaderText="Sil" CommandName="btnSil" ConfirmDialogType="RadWindow" ConfirmText="Resim Kaydını Silmek İstiyormusunuz..." ConfirmDialogHeight="135px" ConfirmDialogWidth="350px" ConfirmTitle="... Dikkat ..."
                                                            UniqueName="colSil" ImageUrl="~/Images/ImgDelete.png">
                                                            <HeaderStyle HorizontalAlign="Center" Width="45px" Font-Bold="true" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadAsyncUpload ID="uploadLogo" runat="server" Skin="Bootstrap" MaxFileInputsCount="1" TemporaryFolder="~/App_Data/UploadTemp" Width="100%" ChunkSize="10485760" Culture="tr-TR" InputSize="26">
                                                <FileFilters>
                                                    <telerik:FileFilter Description="PNG Resim" Extensions="PNG" />
                                                </FileFilters>
                                            </telerik:RadAsyncUpload>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadButton runat="server" ButtonType="StandardButton" Skin="Bootstrap" ID="btnYeniResim" Text="Yeni Resim" OnClick="btnYeniResim_Click"></telerik:RadButton>
                                            <telerik:RadButton runat="server" ButtonType="StandardButton" Skin="Bootstrap" ID="btnResimKaydet" Text="Resim Kaydet" OnClick="btnResimKaydet_Click"></telerik:RadButton>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
             <telerik:RadGrid ID="rdGridListe" runat="server" AllowFilteringByColumn="true" Skin="Bootstrap" Width="100%" Height="300px" AllowPaging="True" PagerStyle-PageSizeControlType="None" AllowCustomPaging="true" PagerStyle-PageSizes="50" AllowSorting="true"
                OnSelectedIndexChanged="rdGridListe_SelectedIndexChanged" OnItemCommand="rdGridListe_ItemCommand" OnNeedDataSource="rdGridListe_NeedDataSource">
                <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="true" Selecting-AllowRowSelect="true">
                    <Selecting AllowRowSelect="true" />
                    <Scrolling AllowScroll="true" UseStaticHeaders="true" />

                </ClientSettings>
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="ARAC_ID,
                                                                            SASE_NO,
                                                                            PLAKA , 
                                                                            MARKAMODEL , 
                                                                            VITES , 
                                                                            YIL, 
                                                                            RENK , 
                                                                            KM , 
                                                                            BAKIM_KM_PERIYOT , 
                                                                            MUSAITMI,
                                                                            SON_MUAYENE_GUN , 
                                                                            SON_BAKIM_KM , 
                                                                            SON_BAKIM_GUN,
                                                                            YAKIT,
                                                                            GUNLUK_UCRET">
                    <Columns>
                        <telerik:GridBoundColumn DataField="SASE_NO" DataType="System.String" HeaderText="Şase No" UniqueName="colSASE_NO" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PLAKA" DataType="System.String" HeaderText="Plaka" UniqueName="colPLAKA" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MARKAMODEL1" DataType="System.String" HeaderText="Marka Model" UniqueName="colMARKAMODEL1" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VITES1" DataType="System.String" HeaderText="Vites" UniqueName="colVITES1" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="YAKIT1" DataType="System.String" HeaderText="Yakıt" UniqueName="colYAKIT" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RENK1" DataType="System.String" HeaderText="Renk" UniqueName="colRENK1" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BAKIM_KM_PERIYOT" DataType="System.String" HeaderText="Bakım Periyot" UniqueName="colBAKIM_KM_PERIYOT" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SON_MUAYENE_GUN" DataType="System.String" HeaderText="Son Muayene" UniqueName="colSON_MUAYENE_GUN" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SON_BAKIM_KM" DataType="System.String" HeaderText="Bakım Km" UniqueName="colSON_BAKIM_KM" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SON_BAKIM_GUN" DataType="System.String" HeaderText="Bakım Gün" UniqueName="colSON_BAKIM_GUN" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="GUNLUK_UCRET" DataType="System.String" HeaderText="Günlük Ücret" UniqueName="colGUNLUK_UCRET" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="ImageButton" HeaderText="Sil" CommandName="btnSil" ConfirmDialogType="RadWindow" ConfirmText="Araç Kaydını Silmek İstiyormusunuz..." ConfirmDialogHeight="135px" ConfirmDialogWidth="350px" ConfirmTitle="... Dikkat ..."
                            UniqueName="colSil" ImageUrl="~/Images/ImgDelete.png">
                            <HeaderStyle HorizontalAlign="Center" Width="45px" Font-Bold="true" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
           
            

        </asp:Panel>
    </form>
</body>
</html>
