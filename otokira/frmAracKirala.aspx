<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAracKirala.aspx.cs" Inherits="frmAracKirala" %>

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


                <telerik:AjaxSetting AjaxControlID="rdKiraBaslangic">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="pnlIslem" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="rdKiraBitis">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="pnlIslem" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Metro"></telerik:RadAjaxLoadingPanel>
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

            <table style="width: 600px;">
                <tbody>
                    <tr>

                        <td style="width: 20%;">Kira Başlangıç

                        </td>
                        <td style="width: 80%;">

                            <telerik:RadDatePicker ID="rdKiraBaslangic" AutoPostBack="true" runat="server" OnSelectedDateChanged="rdKiraBaslangic_SelectedDateChanged" RenderMode="Lightweight" Skin="Bootstrap" Width="100%"></telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>

                        <td style="width: 20%;">Kira Bitiş

                        </td>
                        <td style="width: 80%;">

                            <telerik:RadDatePicker ID="rdKiraBitis" runat="server" AutoPostBack="true" OnSelectedDateChanged="rdKiraBaslangic_SelectedDateChanged" RenderMode="Lightweight" Skin="Bootstrap" Width="100%"></telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>

                        <td style="width: 20%;">Kiralanan Gün Sayısı

                        </td>
                        <td style="width: 80%;">
                            <asp:Label ID="lblGun" runat="server" Text="" Visible="true"></asp:Label>

                        </td>
                    </tr>
                    <tr>

                        <td style="width: 20%;">Kiralama Ücreti

                        </td>
                        <td style="width: 80%;">
                            <asp:Label ID="lblUcret" runat="server" Text="" Visible="true"></asp:Label>

                        </td>
                    </tr>
                    <tr>

                        <td style="width: 20%; text-align:right;">
                            <telerik:RadButton ID="chkOnay" runat="server" AutoPostBack="false"
                                ButtonType="ToggleButton" Checked="false" CommandName="chkModuler" Height="24px"
                                ToggleType="CheckBox" Width="24px">
                                <ToggleStates>
                                    <telerik:RadButtonToggleState ImageUrl="~/images/imgCheck24e.png" IsBackgroundImage="true" Selected="true" />
                                    <telerik:RadButtonToggleState ImageUrl="~/images/imgCheck24n.png" IsBackgroundImage="true" />
                                </ToggleStates>
                            </telerik:RadButton>
                        </td>
                        <td style="width: 80%;">Araç Kiralama İşlemini Onaylıyorum
                            
                        </td>
                    </tr>
                    <tr>


                        <td style="width: 100%; text-align:right;" colspan="2">
                            <telerik:RadButton runat="server" ButtonType="StandardButton" Skin="Bootstrap" ID="btnKaydet" Text="Kaydet" OnClick="btnKaydet_Click"></telerik:RadButton>


                        </td>
                    </tr>
                </tbody>
            </table>





            <telerik:RadGrid ID="rdGridListe" runat="server" AllowFilteringByColumn="true" Skin="Bootstrap" Width="100%" Height="500px" AllowPaging="True" PagerStyle-PageSizeControlType="None" AllowCustomPaging="true" PagerStyle-PageSizes="50" AllowSorting="true"
                OnSelectedIndexChanged="rdGridListe_SelectedIndexChanged" OnNeedDataSource="rdGridListe_NeedDataSource">
                <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="true" Selecting-AllowRowSelect="true">
                    <Selecting AllowRowSelect="true" />
                    <Scrolling AllowScroll="true" UseStaticHeaders="true" />

                </ClientSettings>
                <GroupingSettings CaseSensitive="false" />
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="ARAC_ID,GUNLUK_UCRET">
                    <Columns>
                        <telerik:GridBinaryImageColumn DataField="dbARAC_FOTO" HeaderText="Resimler" AutoAdjustImageControlSize="false" AllowFiltering="false" ImageHeight="128px" ImageWidth="128px" UniqueName="colKurumLogo">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="true" Width="96px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBinaryImageColumn>
                        <telerik:GridBoundColumn DataField="MARKAMODEL1" DataType="System.String" HeaderText="Marka Model" UniqueName="colMARKAMODEL1" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VITES1" DataType="System.String" HeaderText="Vites" UniqueName="colVITES1" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="YAKIT1" DataType="System.String" HeaderText="Yakıt" UniqueName="colYAKIT" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="KM" DataType="System.String" HeaderText="Km" UniqueName="colKM" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>

                        <telerik:GridBoundColumn DataField="GUNLUK_UCRET" DataType="System.String" HeaderText="Günlük Ücret" UniqueName="colGUNLUK_UCRET" ShowFilterIcon="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100%">
                        </telerik:GridBoundColumn>

                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:Panel>
    </form>
</body>
</html>
