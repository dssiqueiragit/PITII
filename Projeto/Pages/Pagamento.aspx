<%@ Page Language="C#" ValidateRequest="false" MaintainScrollPositionOnPostback="true" EnableEventValidation="True" AutoEventWireup="true" CodeFile="Pagamento.aspx.cs" Inherits="PROJETO.DataPages.Pagamento" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="..\UserControls\SidebarPage.ascx" TagName="tagSidebar" TagPrefix="tgSid" %>
<%@ Register Src="..\UserControls\Header.ascx" TagName="GHeader" TagPrefix="GHeader" %>
<%@ Register Src="..\UserControls\Footer.ascx" TagName="uc" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<meta name="generator" content="Gvinci Low-Code Platform" />
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_ComboBoxStyle.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_ButtonStyle.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_RadTextBox_textbox_default.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_secondary.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Pagamento.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/animate.min.css") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/bootstrap5.min.css??sv=4.0_20250523015019") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/all.min.css??sv=4.0_20250523015019") %>" type="text/css" media="screen" title="no title"/>  	
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/gvbaselayout.css??sv=4.0_20250523015019") %>" type="text/css" media="screen" title="no title"/>
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		


		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.js") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.min.js??sv=4.0_20250523015019") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.global.js??sv=4.0_20250523015019") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/bootstrap5.bundle.min.js??sv=4.0_20250523015019") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/wow.min.js") %>" ></script>
		<script type="text/javascript"> new WOW().init(); </script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Page.js??sv=4.0_20250523015019") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Common.js??sv=4.0_20250523015019") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Functions.js??sv=4.0_20250523015019") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/RadComboBoxHelper.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Pagamento_USER.js??sv=4.0_20250523015019") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mCustomScrollbar.concat.min.js??sv=4.0_20250523015019") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/LayoutController.js??sv=4.0_20250523015019") %>" ></script>

		<script type="text/javascript">
			function OnLoginSucceded()
			{
				if(getParentPage() != self && getParentPage() != null)
				{
					getParentPage().OnLoginSucceded();
				}
			}
			function TryLogin(PageToRedirect, RefreshControlsID)
			{
				TryParentLogin(PageToRedirect, RefreshControlsID, false, '<%= ResolveUrl("~/Login") %>');
			}
			currentPath = "<%= Page.Request.Path %>";
		</script>
	</telerik:RadCodeBlock>
	<script type="text/javascript">	   
		
	</script>
    <script type="text/javascript">
	</script>
	<script type="text/javascript">
		function ___Form1_OnResponseEnd(sender, args)
		{
			OnResponseEnd(sender,args);
		}
		function ___Form1_OnRequestStart(sender, args)
		{
			OnRequestStart(sender,args);
		}
		function ___RadTextBox_TOTAL_VENDA_onkeydown(event,vgWin)
		{
		}
		function ___Button13_OnClientClick(sender, args)
		{
			Save(this);
			args.set_cancel(true);
			return false;
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
					<div id="LayoutContainer1" runat="server" class="containerDefault container-fluid c_LayoutContainer1">
						<div id="LayoutRow2" class="row c_LayoutRow2">
							<div id="LayoutCol6" class="col col-12 c_LayoutCol6">
								<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="Pagamento da Venda" />
							</div>
						</div>
						<div id="LayoutRow3" class="row c_LayoutRow3">
							<div id="LayoutCol7" class="col col-12 c_LayoutCol7">
								<telerik:RadLabel id="Label_TOTAL_VENDA" runat="server" CssClass="c_Label_TOTAL_VENDA" Text="<%$ Resources: Label_TOTAL_VENDA %>" />
								<telerik:RadTextBox id="RadTextBox_TOTAL_VENDA" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_TOTAL_VENDA textbox-default"
									EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="11"
									onkeydown="___RadTextBox_TOTAL_VENDA_onkeydown();" ReadOnly="True" RenderMode="Lightweight" TextMode="SingleLine" UseTelerikMask="False"
									WrapperCssClass="c_RadTextBox_TOTAL_VENDA_wrapper" />
							</div>
						</div>
						<div id="LayoutRow1" class="row c_LayoutRow1">
							<div id="LayoutCol1" class="col col-12 c_LayoutCol1">
								<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" Text="<%$ Resources: Label2 %>" />
								<telerik:RadComboBox id="ComboBox1" runat="server" AllowCustomText="False" AutoPostBack="False" CssClass="c_ComboBox1 combobox-primary"
									CollapseAnimation-Duration="300" CollapseAnimation-Type="None" EnableEmbeddedSkins="True" EnableLoadOnDemand="True"
									EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None" ForeColor="#292828"
									LoadingMessage="<%$ Resources: ComboBox1 %>" MarkFirstMatch="true" MaxHeight="100" OnClientItemsRequesting="Combo_OnClientItemsRequesting"
									OnClientKeyPressing="Combo_HandleKeyPress" OnItemsRequested="___ComboBox1_OnItemsRequested" RenderMode="Lightweight" TabIndex="2" />
							</div>
							<div id="LayoutCol24" class="col col-12 c_LayoutCol24">
								<telerik:RadButton id="Button13" runat="server" ButtonType="SkinnedButton" CssClass="c_Button13 button-secondary" CommandName="Button13"
									OnClientClicking="___Button13_OnClientClick" RenderMode="Lightweight" TabIndex="3" Text="<%$ Resources: Button13 %>">
								</telerik:RadButton>
							</div>
						</div>
					</div>
			<GHeader:GHeader runat="server" style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" Container="LayoutContainer1" ID="gvLayoutHeader" Position="Fixed" Transition="300ms"/>
			<uc:uc runat="server" style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" Container="LayoutContainer1" ID="gvLayoutFooter" Position="Fixed" Transition="300ms"/>
			<tgSid:tagSidebar runat="server" AutoOpen="True" style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" Container="LayoutContainer1" ID="gvLayoutSidebar" Mode="Full" Position="Left" Transition="300ms"/>
			<telerik:RadAjaxLoadingPanel ID="___Form1_AjaxLoading" OnClientShowing="LayoutController.fixAjaxLoadingWidth" runat="server">
			</telerik:RadAjaxLoadingPanel>
			</telerik:RadAjaxPanel>
		</form>
		
	</body>
<telerik:RadCodeBlock ID="EndCodeBlock" runat="server">
	<script type="text/javascript">
		var $j = jQuery.noConflict();
		$j(document).ready(SetFocusFirstField());
		function SetFocusFirstField()
		{
			try
			{
				{
					window.focus();
					setTimeout("var $j = jQuery.noConflict();$j('#RadTextBox_TOTAL_VENDA').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function TOTAL_VENDA() { return document.getElementById('RadTextBox_TOTAL_VENDA').value; }
		function TIPO_PGTO_VENDA() { return $find("<%= ComboBox1.ClientID %>").get_value(); }
		function EnableButtons()
		{
				try
				{
					var __PAGESTATE = "";
					var __PAGENUMBER = 0;
					var __PAGECOUNT = 0;
					var __ISPARAMETER = "";
					var __PERMISSION = "";
					var __ALLOWINSERT = "true";
					var __ALLOWUPDATE = "true";
					var __ALLOWREMOVE = "true";
					try { __ISPARAMETER = document.getElementById("__TABLEPARAMETER").value.toLowerCase(); } catch (e) { }
					try { __PERMISSION = document.getElementById("__PERMISSION").value; } catch (e) { }
					try { __ALLOWINSERT = __PERMISSION.toString().substr(__PERMISSION.indexOf("Insert:") + 7, __PERMISSION.indexOf(";", __PERMISSION.indexOf("Insert:")) - __PERMISSION.indexOf("Insert:") - 7).toLowerCase(); } catch (e) { }
					try { __ALLOWUPDATE = __PERMISSION.toString().substr(__PERMISSION.indexOf("Edit:") + 5, __PERMISSION.indexOf(";", __PERMISSION.indexOf("Edit:")) - __PERMISSION.indexOf("Edit:") - 5).toLowerCase(); } catch (e) { }
					try { __ALLOWREMOVE = __PERMISSION.toString().substr(__PERMISSION.indexOf("Remove:") + 7, __PERMISSION.indexOf(";", __PERMISSION.indexOf("Remove:")) - __PERMISSION.indexOf("Remove:") - 7).toLowerCase(); } catch (e) { }
					try { __PAGESTATE = document.getElementById("__PAGESTATE").value.toLowerCase(); } catch (e) { }
					try { __PAGENUMBER = parseInt(document.getElementById("__PAGENUMBER").value); } catch (e) { }
					try { __PAGECOUNT = parseInt(document.getElementById("__PAGECOUNT").value); } catch (e) { }
						$find("Button13").set_enabled(!(IsAjaxProcessing || !(__PAGESTATE != "" && __PAGESTATE != "navigation" && (__ALLOWINSERT == "true" || __ALLOWUPDATE == "true"))));
					try
					{
						if (getParentPage() != null && getParentPage() != self)
						{
							getParentPage().EnableButtons();
						}
					}
					catch (ex)
					{
					}
				}
				catch (ex)
				{
				}
		}

		function LoadEditAuto() {
				$j("#RadTextBox_TOTAL_VENDA").bind("keydown", InitiateEditAuto);
				$j("#ComboBox1").bind("change", InitiateEditAuto);
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>

