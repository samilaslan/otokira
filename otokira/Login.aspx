<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login" %>

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
                <telerik:AjaxSetting AjaxControlID="btnGiris">
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
            <table style="width: 970px; border-spacing: 0px; margin: 0px; height: 40px;">
                <tr>

                    <td style="text-align: center; vertical-align: middle; width: 100%;">
                        <asp:Image ID="imgHata" runat="server" Visible="false" />
                        <asp:Label ID="lblHata" runat="server" Text="" Visible="false"></asp:Label>
                    </td>

                </tr>
            </table>
            <table style="width: 400px;">
                <tr>
                    <td style="width: 20%;">Kullanıcı Adı

                    </td>
                    <td style="width: 80%;">
                        <telerik:RadTextBox RenderMode="Lightweight" Skin="Bootstrap" runat="server" ID="txtUser" Width="100%">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%;">Şifre

                    </td>
                    <td style="width: 80%;">
                        <telerik:RadTextBox RenderMode="Lightweight" TextMode="Password" Skin="Bootstrap" runat="server" ID="txtPass" Width="100%">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="width: 100%;">
                        <telerik:RadButton runat="server" ButtonType="StandardButton" Skin="Bootstrap" ID="btnGiris" Text="Giriş" OnClick="btnGiris_Click"></telerik:RadButton>

                    </td>
                </tr>
            </table>

        </asp:Panel>
    </form>
</body>
</html>
