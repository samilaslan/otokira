<%@ Page Title="" Language="C#" MasterPageFile="~/OtoKira.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="otokira.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <asp:Panel runat="server" ID="pnlIslem" Width="100%">
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
                                        <td style="width: 20%;">Tc

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadNumericTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtTc" Type="Number" Width="100%">
                                                <NumberFormat DecimalDigits="0" GroupSeparator="" ZeroPattern="n" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">Adı

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtAd" Width="100%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">Soyadı

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtSoyad" Width="100%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">Tel

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtTel" Width="100%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                         
                                    <tr>
                                        <td style="width: 20%;">Adres

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtAdres" Width="100%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%;">Ehliyet No

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtEhliyetNo" Width="100%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                               <tr>
                                        <td style="width: 20%;">e-Mail

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtEMail" Width="100%">
                                            </telerik:RadTextBox>
                                        </td>
                                    </tr>
                                                                 <tr>
                                        <td style="width: 20%;">Şifre

                                        </td>
                                        <td style="width: 80%;">

                                            <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtSifre" Width="100%">
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
                        <td style="width: 300px;">
                            <table style="width: 300px;">
                                <tbody>
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
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="rgResimler" runat="server" Height="200px" Width="100%" AllowSorting="true" AutoGenerateColumns="False" Skin="Bootstrap" AllowFilteringByColumn="false" PageSize="25" AllowPaging="false" OnNeedDataSource="rgResimler_NeedDataSource" Culture="tr-TR" OnSelectedIndexChanged="rgResimler_SelectedIndexChanged">
                                                <ClientSettings EnablePostBackOnRowClick="True" Scrolling-UseStaticHeaders="true" EnableRowHoverStyle="true" Scrolling-AllowScroll="true" Selecting-AllowRowSelect="true">
                                                    <Selecting AllowRowSelect="true" />

                                                </ClientSettings>
                                                <AlternatingItemStyle />

                                                <MasterTableView DataKeyNames="MUSTERI_FOTO_ID,MUSTERI_ID,MUSTERI_FOTO">
                                                    <Columns>
                                                        <telerik:GridBinaryImageColumn DataField="MUSTERI_FOTO" HeaderText="Resimler" AutoAdjustImageControlSize="false" AllowFiltering="false" ImageHeight="128px" ImageWidth="128px" UniqueName="colKurumLogo">
                                                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Width="100%" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </telerik:GridBinaryImageColumn>

                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>

            <telerik:RadGrid ID="rdGridListe" runat="server" AllowFilteringByColumn="true" Width="100%" Height="300px" AllowPaging="True" PagerStyle-PageSizeControlType="None" AllowCustomPaging="true" PagerStyle-PageSizes="50" AllowSorting="true"
                OnSelectedIndexChanged="rdGridListe_SelectedIndexChanged" OnNeedDataSource="rdGridListe_NeedDataSource">
                <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="true" Selecting-AllowRowSelect="true">
                    <Selecting AllowRowSelect="true" />
                    <Scrolling AllowScroll="true" UseStaticHeaders="true" />

                </ClientSettings>
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="MUSTERI_ID,TC,Ad,Soyad,ADRES,YETKI,MAIL,EHLIYETNO,Tel">
                    <Columns>
                        <telerik:GridBoundColumn DataField="TC" DataType="System.String" HeaderText="Kimlik No" UniqueName="colTc" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Ad" DataType="System.String" HeaderText="Ad" UniqueName="colAd" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Soyad" DataType="System.String" HeaderText="Soyad" UniqueName="colSoyad" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Tel" DataType="System.String" HeaderText="Tel" UniqueName="colTel" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="MAIL" DataType="System.String" HeaderText="e-MAil" UniqueName="coleMail" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EHLIYETNO" DataType="System.String" HeaderText="Ehliyet No" UniqueName="colEhliyet" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>


        </asp:Panel>
</asp:Content>
