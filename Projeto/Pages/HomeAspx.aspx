<%@ Page Language="C#" ValidateRequest="false" MaintainScrollPositionOnPostback="true" EnableEventValidation="True" AutoEventWireup="true" CodeFile="HomeAspx.aspx.cs" Inherits="PROJETO.DataPages.HomeAspx" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="..\UserControls\GMultiMedia.ascx" TagName="GMultiMedia" TagPrefix="gas" %>
<%@ Register Src="..\UserControls\SidebarEmpresa.ascx" TagName="tagSidEmp" TagPrefix="tgSidEmp" %>
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
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_ButtonStyle.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_rounded_primary.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_rounded_secondary.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/HomeAspx.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/animate.min.css") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/bootstrap5.min.css??sv=4.0_20250523023112") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/all.min.css??sv=4.0_20250523023112") %>" type="text/css" media="screen" title="no title"/>  	
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/gvbaselayout.css??sv=4.0_20250523023112") %>" type="text/css" media="screen" title="no title"/>
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		


		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.js") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.min.js??sv=4.0_20250523023112") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.global.js??sv=4.0_20250523023112") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/bootstrap5.bundle.min.js??sv=4.0_20250523023112") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/wow.min.js") %>" ></script>
		<script type="text/javascript"> new WOW().init(); </script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Page.js??sv=4.0_20250523023112") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Common.js??sv=4.0_20250523023112") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Functions.js??sv=4.0_20250523023112") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/HomeAspx_USER.js??sv=4.0_20250523023112") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mCustomScrollbar.concat.min.js??sv=4.0_20250523023112") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/LayoutController.js??sv=4.0_20250523023112") %>" ></script>

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
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
					<div id="LayoutContainer1" runat="server" class="containerDefault container-fluid c_LayoutContainer1">
						<div id="LayoutRow1" class="row c_LayoutRow1">
							<div id="LayoutCol1" class="col col-12 c_LayoutCol1">
								<div runat="server"  style="background-color:#FFFFFF;border-color:#DBD6D6;border-style:Solid" class="container-fluid">
									<asp:Repeater id="Repeater1" runat="server" ClientIDMode="Static">
										<ItemTemplate>
											<div id="GRepeaterBody1" runat="server" class="row c_GRepeaterBody1">
												<div id="GRepeaterBody1ChildLocator" runat="server" clientidmode="AutoID"></div>
												<div id="LayoutCol2" class="col col-6 c_LayoutCol2">
													<gas:GMultiMedia id="GMultiMedia1" runat="server" BorderWidth="1" CanDownloadFile="False" CanUploadFile="False" class="c_GMultiMedia1"
														EncryptedFile="False" Height="170px" ImageFit="contain" MaxFileSize="0" Responsive="true" SaveAsFile="False" SaveOnS3="False"
														SessionHandlerObjectName="FOTO1_PRODUTO36034" ShowDownloadLink="False" ShowImage="True" TabIndex="1" Visible="True" Width="100%" />
												</div>
												<div id="LayoutCol3" class="col col-6 c_LayoutCol3">
													<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" ClientIDMode="Static" Text="<%$ Resources: Label1 %>" />
													<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" ClientIDMode="Static" Text="<%$ Resources: Label2 %>" />
													<telerik:RadLabel id="Label3" runat="server" CssClass="c_Label3" ClientIDMode="Static" Text="<%$ Resources: Label3 %>" />
													<telerik:RadButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1 button-rounded-primary"
														CommandName="Button1" HasDatalistParent="true" OnClick="___Button1_OnClick" RenderMode="Lightweight" TabIndex="3"
														Text="<%$ Resources: Button1 %>">
													</telerik:RadButton>
												</div>
											</div>
										</ItemTemplate>
										<AlternatingItemTemplate>
											<div id="GRepeaterBodyAlt1" runat="server" class="row c_GRepeaterBodyAlt1">
												<div id="GRepeaterBodyAlt1ChildLocator" runat="server" clientidmode="AutoID"></div>
												<div id="LayoutCol4" class="col col-6 c_LayoutCol4">
													<gas:GMultiMedia id="GMultiMedia2" runat="server" BorderWidth="1" CanDownloadFile="False" CanUploadFile="False" class="c_GMultiMedia2"
														EncryptedFile="False" Height="170px" ImageFit="contain" MaxFileSize="0" Responsive="true" SaveAsFile="False" SaveOnS3="False"
														SessionHandlerObjectName="FOTO2_PRODUTO36034" ShowDownloadLink="False" ShowImage="True" TabIndex="2" Visible="True" Width="100%" />
												</div>
												<div id="LayoutCol5" class="col col-6 c_LayoutCol5">
													<telerik:RadLabel id="Label5" runat="server" CssClass="c_Label5" ClientIDMode="Static" Text="<%$ Resources: Label5 %>" />
													<telerik:RadLabel id="Label6" runat="server" CssClass="c_Label6" ClientIDMode="Static" Text="<%$ Resources: Label6 %>" />
													<telerik:RadLabel id="Label4" runat="server" CssClass="c_Label4" ClientIDMode="Static" Text="<%$ Resources: Label4 %>" />
													<telerik:RadButton id="Button2" runat="server" ButtonType="SkinnedButton" CssClass="c_Button2 button-rounded-secondary"
														CommandName="Button2" HasDatalistParent="true" OnClick="___Button2_OnClick" RenderMode="Lightweight" TabIndex="4"
														Text="<%$ Resources: Button2 %>">
													</telerik:RadButton>
												</div>
											</div>
										</AlternatingItemTemplate>
									</asp:Repeater>
								</div>
							</div>
						</div>
					</div>
			<GHeader:GHeader runat="server" style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" Container="LayoutContainer1" ID="gvLayoutHeader" Position="Fixed" Transition="300ms"/>
			<uc:uc runat="server" style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" Container="LayoutContainer1" ID="gvLayoutFooter" Position="Fixed" Transition="300ms"/>
			<tgSidEmp:tagSidEmp runat="server" AutoOpen="True" style="border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px" Container="LayoutContainer1" ID="gvLayoutSidebar" Mode="Full" Position="Left" Transition="300ms"/>
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
					setTimeout("var $j = jQuery.noConflict();$j('#GMultiMedia1').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>

