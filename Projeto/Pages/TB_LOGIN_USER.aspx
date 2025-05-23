<%@ Page Language="C#" ValidateRequest="false" MaintainScrollPositionOnPostback="true" EnableEventValidation="True" AutoEventWireup="true" CodeFile="TB_LOGIN_USER.aspx.cs" Inherits="PROJETO.DataPages.TB_LOGIN_USER" Culture="auto" UICulture="auto"%>
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
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_RadTextBox_textbox_default.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/TB_LOGIN_USER.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/validationEngine.jquery.css") %>" type="text/css" media="screen" title="no title"/>
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
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/TB_LOGIN_USER_USER.js??sv=4.0_20250523015019") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.validationEngine-pt_BR.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.validationEngine.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/validation.js") %>"></script>
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
		function ___RadTextBox_LOGIN_USER_LOGIN_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___txtLoginPassword_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_LOGIN_USER_NAME_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_LOGIN_USER_ENDERECO_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_LOGIN_USER_NUM_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_LOGIN_USER_COMPL_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_LOGIN_USER_BAIRRO_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_LOGIN_USER_CIDADE_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_LOGIN_USER_CEP_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_LOGIN_USER_EMAIL_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_LOGIN_USER_CEL_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_LOGIN_USER_OBS_onkeydown(event,vgWin)
		{
			onTextChanged(event);
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
		function ___Button10_OnClientClick(sender, args)
		{
			Edit(this);
			args.set_cancel(true);
			return false;
		}
		function RadTextBox_LOGIN_USER_NAME_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox_LOGIN_USER_LOGIN_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function txtLoginPassword_Validation(field, rules, i, options) {
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
								<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Cadastro" />
							</div>
						</div>
						<div id="LayoutRow2" class="row c_LayoutRow2">
							<div id="LayoutCol2" class="col col-6 c_LayoutCol2">
								<telerik:RadLabel id="Label_LOGIN_USER_LOGIN" runat="server" CssClass="c_Label_LOGIN_USER_LOGIN"
									Text="<%$ Resources: Label_LOGIN_USER_LOGIN %>" />
								<telerik:RadTextBox id="RadTextBox_LOGIN_USER_LOGIN" runat="server" AutoPostBack="False"
									CssClass="c_RadTextBox_LOGIN_USER_LOGIN textbox-default" data-validation-engine="validate[funcCall[RadTextBox_LOGIN_USER_LOGIN_Validation]]"
									data-validation-message="Login não pode ser vazio!" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333"
									MaxLength="14" onkeydown="___RadTextBox_LOGIN_USER_LOGIN_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="1"
									TextMode="SingleLine" UseTelerikMask="False" WrapperCssClass="c_RadTextBox_LOGIN_USER_LOGIN_wrapper" />
							</div>
							<div id="LayoutCol3" class="col col-6 c_LayoutCol3">
								<telerik:RadLabel id="Label_LOGIN_USER_PASSWORD" runat="server" CssClass="c_Label_LOGIN_USER_PASSWORD"
									Text="<%$ Resources: Label_LOGIN_USER_PASSWORD %>" />
								<telerik:RadTextBox id="txtLoginPassword" runat="server" AutoPostBack="False" CssClass="c_txtLoginPassword textbox-default"
									data-validation-engine="validate[funcCall[txtLoginPassword_Validation]]" data-validation-message="Senha não pode ser vazio!"
									EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="40"
									onkeydown="___txtLoginPassword_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="2" TextMode="Password"
									UseTelerikMask="False" WrapperCssClass="c_txtLoginPassword_wrapper" />
							</div>
							<div id="LayoutCol4" class="col col-12 c_LayoutCol4">
								<telerik:RadLabel id="Label_LOGIN_USER_NAME" runat="server" CssClass="c_Label_LOGIN_USER_NAME" Text="<%$ Resources: Label_LOGIN_USER_NAME %>"
									/>
								<telerik:RadTextBox id="RadTextBox_LOGIN_USER_NAME" runat="server" AutoPostBack="False"
									CssClass="c_RadTextBox_LOGIN_USER_NAME textbox-default" data-validation-engine="validate[funcCall[RadTextBox_LOGIN_USER_NAME_Validation]]"
									data-validation-message="Nome do usuário não pode ser vazio!" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True"
									ForeColor="#333333" MaxLength="60" onkeydown="___RadTextBox_LOGIN_USER_NAME_onkeydown();" ReadOnly="False" RenderMode="Lightweight"
									TabIndex="3" TextMode="SingleLine" UseTelerikMask="False" WrapperCssClass="c_RadTextBox_LOGIN_USER_NAME_wrapper" />
							</div>
							<div id="LayoutCol5" class="col col-9 c_LayoutCol5">
								<telerik:RadLabel id="Label_LOGIN_USER_ENDERECO" runat="server" CssClass="c_Label_LOGIN_USER_ENDERECO"
									Text="<%$ Resources: Label_LOGIN_USER_ENDERECO %>" />
								<telerik:RadTextBox id="RadTextBox_LOGIN_USER_ENDERECO" runat="server" AutoPostBack="False"
									CssClass="c_RadTextBox_LOGIN_USER_ENDERECO textbox-default" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True"
									ForeColor="#333333" MaxLength="60" onkeydown="___RadTextBox_LOGIN_USER_ENDERECO_onkeydown();" ReadOnly="False" RenderMode="Lightweight"
									TabIndex="4" TextMode="SingleLine" UseTelerikMask="False" WrapperCssClass="c_RadTextBox_LOGIN_USER_ENDERECO_wrapper" />
							</div>
							<div id="LayoutCol6" class="col col-3 c_LayoutCol6">
								<telerik:RadLabel id="Label_LOGIN_USER_NUM" runat="server" CssClass="c_Label_LOGIN_USER_NUM" Text="<%$ Resources: Label_LOGIN_USER_NUM %>" />
								<telerik:RadTextBox id="RadTextBox_LOGIN_USER_NUM" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_LOGIN_USER_NUM textbox-default"
									EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="10"
									onkeydown="___RadTextBox_LOGIN_USER_NUM_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="5" TextMode="SingleLine"
									UseTelerikMask="False" WrapperCssClass="c_RadTextBox_LOGIN_USER_NUM_wrapper" />
							</div>
							<div id="LayoutCol7" class="col col-6 c_LayoutCol7">
								<telerik:RadLabel id="Label_LOGIN_USER_COMPL" runat="server" CssClass="c_Label_LOGIN_USER_COMPL"
									Text="<%$ Resources: Label_LOGIN_USER_COMPL %>" />
								<telerik:RadTextBox id="RadTextBox_LOGIN_USER_COMPL" runat="server" AutoPostBack="False"
									CssClass="c_RadTextBox_LOGIN_USER_COMPL textbox-default" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True"
									ForeColor="#333333" MaxLength="60" onkeydown="___RadTextBox_LOGIN_USER_COMPL_onkeydown();" ReadOnly="False" RenderMode="Lightweight"
									TabIndex="6" TextMode="SingleLine" UseTelerikMask="False" WrapperCssClass="c_RadTextBox_LOGIN_USER_COMPL_wrapper" />
							</div>
							<div id="LayoutCol8" class="col col-6 c_LayoutCol8">
								<telerik:RadLabel id="Label_LOGIN_USER_BAIRRO" runat="server" CssClass="c_Label_LOGIN_USER_BAIRRO"
									Text="<%$ Resources: Label_LOGIN_USER_BAIRRO %>" />
								<telerik:RadTextBox id="RadTextBox_LOGIN_USER_BAIRRO" runat="server" AutoPostBack="False"
									CssClass="c_RadTextBox_LOGIN_USER_BAIRRO textbox-default" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True"
									ForeColor="#333333" MaxLength="60" onkeydown="___RadTextBox_LOGIN_USER_BAIRRO_onkeydown();" ReadOnly="False" RenderMode="Lightweight"
									TabIndex="7" TextMode="SingleLine" UseTelerikMask="False" WrapperCssClass="c_RadTextBox_LOGIN_USER_BAIRRO_wrapper" />
							</div>
							<div id="LayoutCol9" class="col col-8 c_LayoutCol9">
								<telerik:RadLabel id="Label_LOGIN_USER_CIDADE" runat="server" CssClass="c_Label_LOGIN_USER_CIDADE"
									Text="<%$ Resources: Label_LOGIN_USER_CIDADE %>" />
								<telerik:RadTextBox id="RadTextBox_LOGIN_USER_CIDADE" runat="server" AutoPostBack="False"
									CssClass="c_RadTextBox_LOGIN_USER_CIDADE textbox-default" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True"
									ForeColor="#333333" MaxLength="60" onkeydown="___RadTextBox_LOGIN_USER_CIDADE_onkeydown();" ReadOnly="False" RenderMode="Lightweight"
									TabIndex="8" TextMode="SingleLine" UseTelerikMask="False" WrapperCssClass="c_RadTextBox_LOGIN_USER_CIDADE_wrapper" />
							</div>
							<div id="LayoutCol10" class="col col-4 c_LayoutCol10">
								<telerik:RadLabel id="Label_LOGIN_USER_CEP" runat="server" CssClass="c_Label_LOGIN_USER_CEP" Text="<%$ Resources: Label_LOGIN_USER_CEP %>" />
								<telerik:RadTextBox id="RadTextBox_LOGIN_USER_CEP" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_LOGIN_USER_CEP textbox-default"
									EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="9"
									onkeydown="___RadTextBox_LOGIN_USER_CEP_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="9" TextMode="SingleLine"
									UseTelerikMask="False" WrapperCssClass="c_RadTextBox_LOGIN_USER_CEP_wrapper" />
							</div>
							<div id="LayoutCol15" class="col col-8 c_LayoutCol15">
								<telerik:RadLabel id="Label_LOGIN_USER_EMAIL" runat="server" CssClass="c_Label_LOGIN_USER_EMAIL"
									Text="<%$ Resources: Label_LOGIN_USER_EMAIL %>" />
								<telerik:RadTextBox id="RadTextBox_LOGIN_USER_EMAIL" runat="server" AutoPostBack="False"
									CssClass="c_RadTextBox_LOGIN_USER_EMAIL textbox-default" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True"
									ForeColor="#333333" MaxLength="60" onkeydown="___RadTextBox_LOGIN_USER_EMAIL_onkeydown();" ReadOnly="False" RenderMode="Lightweight"
									TabIndex="10" TextMode="SingleLine" UseTelerikMask="False" WrapperCssClass="c_RadTextBox_LOGIN_USER_EMAIL_wrapper" />
							</div>
							<div id="LayoutCol11" class="col col-4 c_LayoutCol11">
								<telerik:RadLabel id="Label_LOGIN_USER_CEL" runat="server" CssClass="c_Label_LOGIN_USER_CEL" Text="<%$ Resources: Label_LOGIN_USER_CEL %>" />
								<telerik:RadTextBox id="RadTextBox_LOGIN_USER_CEL" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_LOGIN_USER_CEL textbox-default"
									EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="14"
									onkeydown="___RadTextBox_LOGIN_USER_CEL_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="11" TextMode="SingleLine"
									UseTelerikMask="False" WrapperCssClass="c_RadTextBox_LOGIN_USER_CEL_wrapper" />
							</div>
							<div id="LayoutCol12" class="col col-12 c_LayoutCol12">
								<telerik:RadLabel id="Label_LOGIN_USER_OBS" runat="server" CssClass="c_Label_LOGIN_USER_OBS" Text="<%$ Resources: Label_LOGIN_USER_OBS %>" />
								<telerik:RadTextBox id="RadTextBox_LOGIN_USER_OBS" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_LOGIN_USER_OBS textbox-default"
									EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0"
									onkeydown="___RadTextBox_LOGIN_USER_OBS_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="12" TextMode="MultiLine"
									UseTelerikMask="False" WrapperCssClass="c_RadTextBox_LOGIN_USER_OBS_wrapper" />
							</div>
						</div>
						<div id="LayoutRow3" class="row c_LayoutRow3">
							<div id="LayoutCol13" class="col col-12 c_LayoutCol13">
								<telerik:RadToolBar id="gToolbar" runat="server" CssClass="c_gToolbar" EnableRoundedCorners="True" EnableShadows="True"
									OnClientButtonClicking="ToolbarClickHandler" Orientation="Horizontal" RenderMode="Lightweight" Style="z-index:5999">
									<Items>
										<telerik:RadToolBarButton id="Button2" runat="server" ButtonType="SkinnedButton" CssClass="c_Button2 Button2" CommandArgument="Button2"
											CommandName="Button2" RenderMode="Lightweight" TabIndex="13" ToolTip="Grava alterações do registro atual">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button3" runat="server" ButtonType="SkinnedButton" CssClass="c_Button3 Button3" CommandArgument="Button3"
											CommandName="Button3" RenderMode="Lightweight" TabIndex="14" ToolTip="Cancela modificações no registro atual">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button10" runat="server" ButtonType="SkinnedButton" CssClass="c_Button10 Button10" CommandArgument="Button10"
											CommandName="Button10" RenderMode="Lightweight" TabIndex="15" ToolTip="Inicia edição no registro atual">
										</telerik:RadToolBarButton>
									</Items>
								</telerik:RadToolBar>
							</div>
						</div>
						<div id="LayoutRow4" class="row c_LayoutRow4">
							<div id="LayoutCol14" class="col col-12 c_LayoutCol14">
								<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
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
					setTimeout("var $j = jQuery.noConflict();$j('#RadTextBox_LOGIN_USER_LOGIN').first().focus();", 200);
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
				case "Button2":
					___Button2_OnClientClick(sender, args);
				break;
				case "Button3":
					___Button3_OnClientClick(sender, args);
				break;
				case "Button10":
					___Button10_OnClientClick(sender, args);
				break;
			}
		}
		function LOGIN_USER_LOGIN() { return document.getElementById('RadTextBox_LOGIN_USER_LOGIN').value; }
		function LOGIN_USER_PASSWORD() { return document.getElementById('txtLoginPassword').value; }
		function LOGIN_USER_NAME() { return document.getElementById('RadTextBox_LOGIN_USER_NAME').value; }
		function LOGIN_USER_ENDERECO() { return document.getElementById('RadTextBox_LOGIN_USER_ENDERECO').value; }
		function LOGIN_USER_NUM() { return document.getElementById('RadTextBox_LOGIN_USER_NUM').value; }
		function LOGIN_USER_COMPL() { return document.getElementById('RadTextBox_LOGIN_USER_COMPL').value; }
		function LOGIN_USER_BAIRRO() { return document.getElementById('RadTextBox_LOGIN_USER_BAIRRO').value; }
		function LOGIN_USER_CIDADE() { return document.getElementById('RadTextBox_LOGIN_USER_CIDADE').value; }
		function LOGIN_USER_CEP() { return document.getElementById('RadTextBox_LOGIN_USER_CEP').value; }
		function LOGIN_USER_EMAIL() { return document.getElementById('RadTextBox_LOGIN_USER_EMAIL').value; }
		function LOGIN_USER_CEL() { return document.getElementById('RadTextBox_LOGIN_USER_CEL').value; }
		function LOGIN_USER_OBS() { return document.getElementById('RadTextBox_LOGIN_USER_OBS').value; }
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
						EnableDisableToolbarButtons(gToolbar.id,"Button2",!IsAjaxProcessing && __PAGESTATE != "" && __PAGESTATE != "navigation" && (__ALLOWINSERT == "true" || __ALLOWUPDATE == "true"));
						EnableDisableToolbarButtons(gToolbar.id,"Button3",!IsAjaxProcessing && __PAGESTATE != "" && __PAGESTATE != "navigation");
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
				$j("#RadTextBox_LOGIN_USER_LOGIN").bind("keydown", InitiateEditAuto);
				$j("#txtLoginPassword").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_LOGIN_USER_NAME").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_LOGIN_USER_ENDERECO").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_LOGIN_USER_NUM").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_LOGIN_USER_COMPL").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_LOGIN_USER_BAIRRO").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_LOGIN_USER_CIDADE").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_LOGIN_USER_CEP").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_LOGIN_USER_EMAIL").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_LOGIN_USER_CEL").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_LOGIN_USER_OBS").bind("keydown", InitiateEditAuto);
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>

