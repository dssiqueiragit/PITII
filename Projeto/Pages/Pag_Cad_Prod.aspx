<%@ Page Language="C#" ValidateRequest="false" MaintainScrollPositionOnPostback="true" EnableEventValidation="True" AutoEventWireup="true" CodeFile="Pag_Cad_Prod.aspx.cs" Inherits="PROJETO.DataPages.Pag_Cad_Prod" Culture="auto" UICulture="auto"%>
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
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_RadTextBox_textbox_default.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Pag_Cad_Prod.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/validationEngine.jquery.css") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/animate.min.css") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/bootstrap5.min.css??sv=4.0_20250519235534") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/all.min.css??sv=4.0_20250519235534") %>" type="text/css" media="screen" title="no title"/>  	
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/gvbaselayout.css??sv=4.0_20250519235534") %>" type="text/css" media="screen" title="no title"/>
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		


		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.js") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.min.js??sv=4.0_20250519235534") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.global.js??sv=4.0_20250519235534") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/bootstrap5.bundle.min.js??sv=4.0_20250519235534") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/wow.min.js") %>" ></script>
		<script type="text/javascript"> new WOW().init(); </script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Page.js??sv=4.0_20250519235534") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Common.js??sv=4.0_20250519235534") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Functions.js??sv=4.0_20250519235534") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Pag_Cad_Prod_USER.js??sv=4.0_20250519235534") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.validationEngine-pt_BR.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.validationEngine.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/validation.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mCustomScrollbar.concat.min.js??sv=4.0_20250519235534") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/LayoutController.js??sv=4.0_20250519235534") %>" ></script>

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
		function RegisterClientValidateScript()
		{
			var $j = jQuery.noConflict();
			$j(document).ready(function() 
			{
				$j("#Form1").validationEngine()
			});
		}
		RegisterClientValidateScript();
		
	</script>
    <script type="text/javascript">
		var HasValidation = true;
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
		function ___RadTextBox_NOME_PRODUTO_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_VALOR_PRODUTO_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_OBS_PRODUTO_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___Button1_OnClientClick(sender, args)
		{
			New(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button2_OnClientClick(sender, args)
		{
			Save(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button3_OnClientClick(sender, args)
		{
			Cancel(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button5_OnClientClick(sender, args)
		{
			First(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button6_OnClientClick(sender, args)
		{
			Previous(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button7_OnClientClick(sender, args)
		{
			Next(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button8_OnClientClick(sender, args)
		{
			Last(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button10_OnClientClick(sender, args)
		{
			Edit(this);
			args.set_cancel(true);
			return false;
		}
		function RadTextBox_NOME_PRODUTO_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox_VALOR_PRODUTO_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox_OBS_PRODUTO_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
					<div id="LayoutContainer1" runat="server" class="containerDefault container-fluid c_LayoutContainer1">
						<div id="LayoutRow1" class="row c_LayoutRow1">
							<div id="LayoutCol1" class="col col-12 c_LayoutCol1">
								<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Cadastro de Produto" />
							</div>
						</div>
						<div id="LayoutRow3" class="row c_LayoutRow3">
							<div id="LayoutCol3" class="col col-12 c_LayoutCol3">
								<telerik:RadLabel id="Label_NOME_PRODUTO" runat="server" CssClass="c_Label_NOME_PRODUTO" Text="<%$ Resources: Label_NOME_PRODUTO %>" />
								<telerik:RadTextBox id="RadTextBox_NOME_PRODUTO" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_NOME_PRODUTO textbox-default"
									data-validation-engine="validate[funcCall[RadTextBox_NOME_PRODUTO_Validation]]" data-validation-message="NOME_PRODUTO não pode ser vazio!"
									EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="60"
									onkeydown="___RadTextBox_NOME_PRODUTO_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="1" TextMode="SingleLine"
									UseTelerikMask="False" WrapperCssClass="c_RadTextBox_NOME_PRODUTO_wrapper" />
							</div>
							<div id="LayoutCol4" class="col col-12 c_LayoutCol4">
								<telerik:RadLabel id="Label_VALOR_PRODUTO" runat="server" CssClass="c_Label_VALOR_PRODUTO" Text="<%$ Resources: Label_VALOR_PRODUTO %>" />
								<telerik:RadTextBox id="RadTextBox_VALOR_PRODUTO" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_VALOR_PRODUTO textbox-default"
									data-validation-engine="validate[funcCall[RadTextBox_VALOR_PRODUTO_Validation]]" data-validation-message="VALOR_PRODUTO não pode ser vazio!"
									EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="13"
									onkeydown="___RadTextBox_VALOR_PRODUTO_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="2" TextMode="SingleLine"
									UseTelerikMask="False" WrapperCssClass="c_RadTextBox_VALOR_PRODUTO_wrapper" />
							</div>
						</div>
						<div id="LayoutRow2" class="row c_LayoutRow2">
							<div id="LayoutCol5" class="col col-12 c_LayoutCol5">
								<telerik:RadLabel id="Label_FOTO1_PRODUTO" runat="server" CssClass="c_Label_FOTO1_PRODUTO" Text="<%$ Resources: Label_FOTO1_PRODUTO %>" />
								<gas:GMultiMedia id="GMultiMedia_FOTO1_PRODUTO" runat="server" BorderWidth="1" CanDownloadFile="True" CanUploadFile="True"
									class="c_GMultiMedia_FOTO1_PRODUTO" EncryptedFile="False" Height="170px" ImageFit="contain" MaxFileSize="0" Responsive="true"
									SaveAsFile="False" SaveOnS3="False" SessionHandlerObjectName="FOTO1_PRODUTO36032" ShowDownloadLink="False" ShowImage="True" TabIndex="3"
									Visible="True" Width="100%" />
							</div>
							<div id="LayoutCol6" class="col col-12 c_LayoutCol6">
								<telerik:RadLabel id="Label_FOTO2_PRODUTO" runat="server" CssClass="c_Label_FOTO2_PRODUTO" Text="<%$ Resources: Label_FOTO2_PRODUTO %>" />
								<gas:GMultiMedia id="GMultiMedia_FOTO2_PRODUTO" runat="server" BorderWidth="1" CanDownloadFile="True" CanUploadFile="True"
									class="c_GMultiMedia_FOTO2_PRODUTO" EncryptedFile="False" Height="170px" ImageFit="contain" MaxFileSize="0" Responsive="true"
									SaveAsFile="False" SaveOnS3="False" SessionHandlerObjectName="FOTO2_PRODUTO36032" ShowDownloadLink="False" ShowImage="True" TabIndex="4"
									Visible="True" Width="100%" />
							</div>
							<div id="LayoutCol7" class="col col-12 c_LayoutCol7">
								<telerik:RadLabel id="Label_OBS_PRODUTO" runat="server" CssClass="c_Label_OBS_PRODUTO" Text="<%$ Resources: Label_OBS_PRODUTO %>" />
								<telerik:RadTextBox id="RadTextBox_OBS_PRODUTO" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_OBS_PRODUTO textbox-default"
									data-validation-engine="validate[funcCall[RadTextBox_OBS_PRODUTO_Validation]]" data-validation-message="OBS_PRODUTO não pode ser vazio!"
									EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0"
									onkeydown="___RadTextBox_OBS_PRODUTO_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="5" TextMode="MultiLine"
									UseTelerikMask="False" WrapperCssClass="c_RadTextBox_OBS_PRODUTO_wrapper" />
							</div>
						</div>
						<div id="LayoutRow5" class="row c_LayoutRow5">
							<div id="LayoutCol10" class="col col-12 c_LayoutCol10">
								<telerik:RadToolBar id="gToolbar" runat="server" CssClass="c_gToolbar" EnableRoundedCorners="True" EnableShadows="True"
									OnClientButtonClicking="ToolbarClickHandler" Orientation="Horizontal" RenderMode="Lightweight" Style="z-index:5999">
									<Items>
										<telerik:RadToolBarButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1 Button1" CommandArgument="Button1"
											CommandName="Button1" RenderMode="Lightweight" TabIndex="6" ToolTip="Cria novo registro">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button2" runat="server" ButtonType="SkinnedButton" CssClass="c_Button2 Button2" CommandArgument="Button2"
											CommandName="Button2" RenderMode="Lightweight" TabIndex="7" ToolTip="Grava alterações do registro atual">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button3" runat="server" ButtonType="SkinnedButton" CssClass="c_Button3 Button3" CommandArgument="Button3"
											CommandName="Button3" RenderMode="Lightweight" TabIndex="8" ToolTip="Cancela modificações no registro atual">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button5" runat="server" ButtonType="SkinnedButton" CssClass="c_Button5 Button5" CommandArgument="Button5"
											CommandName="Button5" RenderMode="Lightweight" TabIndex="9" ToolTip="Mover para o primeiro registro">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button6" runat="server" ButtonType="SkinnedButton" CssClass="c_Button6 Button6" CommandArgument="Button6"
											CommandName="Button6" RenderMode="Lightweight" TabIndex="10" ToolTip="Mover para o registro anterior">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button7" runat="server" ButtonType="SkinnedButton" CssClass="c_Button7 Button7" CommandArgument="Button7"
											CommandName="Button7" RenderMode="Lightweight" TabIndex="11" ToolTip="Mover para o próximo registro">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button8" runat="server" ButtonType="SkinnedButton" CssClass="c_Button8 Button8" CommandArgument="Button8"
											CommandName="Button8" RenderMode="Lightweight" TabIndex="12" ToolTip="Mover para o último registro">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button10" runat="server" ButtonType="SkinnedButton" CssClass="c_Button10 Button10" CommandArgument="Button10"
											CommandName="Button10" RenderMode="Lightweight" TabIndex="13" ToolTip="Inicia edição no registro atual">
										</telerik:RadToolBarButton>
									</Items>
								</telerik:RadToolBar>
							</div>
						</div>
						<div id="LayoutRow4" class="row c_LayoutRow4">
							<div id="LayoutCol9" class="col col-12 c_LayoutCol9">
								<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
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
					setTimeout("var $j = jQuery.noConflict();$j('#RadTextBox_NOME_PRODUTO').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function ToolbarClickHandler(sender, args)
		{
			var CommandArgument = args.get_item().get_commandArgument();
			switch (CommandArgument)
			{
				case "Button1":
					___Button1_OnClientClick(sender, args);
				break;
				case "Button2":
					___Button2_OnClientClick(sender, args);
				break;
				case "Button3":
					___Button3_OnClientClick(sender, args);
				break;
				case "Button5":
					___Button5_OnClientClick(sender, args);
				break;
				case "Button6":
					___Button6_OnClientClick(sender, args);
				break;
				case "Button7":
					___Button7_OnClientClick(sender, args);
				break;
				case "Button8":
					___Button8_OnClientClick(sender, args);
				break;
				case "Button10":
					___Button10_OnClientClick(sender, args);
				break;
			}
		}
		function NOME_PRODUTO() { return document.getElementById('RadTextBox_NOME_PRODUTO').value; }
		function VALOR_PRODUTO() { return document.getElementById('RadTextBox_VALOR_PRODUTO').value; }
		function OBS_PRODUTO() { return document.getElementById('RadTextBox_OBS_PRODUTO').value; }
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
						EnableDisableToolbarButtons(gToolbar.id,"Button1",!IsAjaxProcessing && __PAGESTATE == "navigation" && __ALLOWINSERT == "true" && __ISPARAMETER == "false");
						EnableDisableToolbarButtons(gToolbar.id,"Button2",!IsAjaxProcessing && __PAGESTATE != "" && __PAGESTATE != "navigation" && (__ALLOWINSERT == "true" || __ALLOWUPDATE == "true"));
						EnableDisableToolbarButtons(gToolbar.id,"Button3",!IsAjaxProcessing && __PAGESTATE != "" && __PAGESTATE != "navigation");
						EnableDisableToolbarButtons(gToolbar.id,"Button5",!IsAjaxProcessing && __PAGESTATE == "navigation" && __PAGECOUNT > 0 && __PAGENUMBER > 1 && __ISPARAMETER == "false");
						EnableDisableToolbarButtons(gToolbar.id,"Button6",!IsAjaxProcessing && __PAGESTATE == "navigation" && __PAGECOUNT > 0 && __PAGENUMBER > 1 && __ISPARAMETER == "false");
						EnableDisableToolbarButtons(gToolbar.id,"Button7",!IsAjaxProcessing && __PAGESTATE == "navigation" && __PAGECOUNT > 0 && __PAGENUMBER < __PAGECOUNT && __ISPARAMETER == "false");
						EnableDisableToolbarButtons(gToolbar.id,"Button8",!IsAjaxProcessing && __PAGESTATE == "navigation" && __PAGECOUNT > 0 && __PAGENUMBER < __PAGECOUNT && __ISPARAMETER == "false");
						EnableDisableToolbarButtons(gToolbar.id,"Button10",!IsAjaxProcessing && __PAGESTATE == "navigation" && __PAGENUMBER > 0 && __PAGECOUNT > 0 && __ALLOWUPDATE == "true");
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
				$j("#RadTextBox_NOME_PRODUTO").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_VALOR_PRODUTO").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_OBS_PRODUTO").bind("keydown", InitiateEditAuto);
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>

