<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default" %>

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
            <telerik:RadMenu RenderMode="Lightweight" ID="RadMenu1" Skin="Material" runat="server" ShowToggleHandle="true">
            <Items>
                <telerik:RadMenuItem Text="Müşteri Tanım" NavigateUrl="frmMusteri.aspx" />
               <telerik:RadMenuItem Text="Araç Tanım" NavigateUrl="frmArac.aspx" />
                <telerik:RadMenuItem Text="Araç Kiralama" NavigateUrl="frmAracKirala.aspx" />
                <telerik:RadMenuItem Text="Araç İade Etme" NavigateUrl="frmAracTeslim.aspx" />
            </Items>
        </telerik:RadMenu>
            

        </asp:Panel>
    </form>
    <p>
        <img alt="gazi" src="Images/emniyet-oto-kiralama.jpg" /></p>
</body>
</html>
