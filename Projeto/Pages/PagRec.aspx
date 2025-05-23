<%@ Page Language="C#" ValidateRequest="false" MaintainScrollPositionOnPostback="true" EnableEventValidation="True" AutoEventWireup="true" CodeFile="PagRec.aspx.cs" Inherits="PROJETO.DataPages.PagRec" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_ComboBoxStyle.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_ButtonStyle.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_RadTextBox_textbox_default.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_RadCheckBox_checkbox_secondary.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_primary.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/PagRec.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/validationEngine.jquery.css") %>" type="text/css" media="screen" title="no title"/>
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
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/RadComboBoxHelper.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/PagRec_USER.js??sv=4.0_20250523023112") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.validationEngine-pt_BR.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.validationEngine.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/validation.js") %>"></script>
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
		function ___RadTextBox_ID_CR_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___ComboBox_LOGIN_USER_LOGIN_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___ComboBox1_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___RadTextBox_ID_VENDA_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox_VALOR_CR_onkeydown(event,vgWin)
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
		function ___Button4_OnClientClick(sender, args)
		{
			Remove(sender,true);
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
		function ___Button10_OnClientClick(sender, args)
		{
			Edit(this);
			args.set_cancel(true);
			return false;
		}
		function RadTextBox_VALOR_CR_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function DatePicker_DATA_CR_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function ComboBox_LOGIN_USER_LOGIN_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function ComboBox1_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox_ID_VENDA_Validation(field, rules, i, options) {
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
								<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Contas a Receber" />
							</div>
						</div>
						<div id="LayoutRow2" class="row c_LayoutRow2">
							<div id="LayoutCol2" class="col col-12 col-sm-6 c_LayoutCol2">
								<telerik:RadLabel id="Label_ID_CR" runat="server" CssClass="c_Label_ID_CR" Text="<%$ Resources: Label_ID_CR %>" />
								<telerik:RadTextBox id="RadTextBox_ID_CR" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_ID_CR textbox-default"
									EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="10"
									onkeydown="___RadTextBox_ID_CR_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="8" TextMode="SingleLine"
									UseTelerikMask="False" WrapperCssClass="c_RadTextBox_ID_CR_wrapper" />
							</div>
							<div id="LayoutCol4" class="col col-12 col-sm-6 c_LayoutCol4">
								<telerik:RadLabel id="Label_DATA_CR" runat="server" CssClass="c_Label_DATA_CR" Text="<%$ Resources: Label_DATA_CR %>" />
								<telerik:RadDatePicker id="DatePicker_DATA_CR" runat="server" Calendar-ClientEvents-OnDateClick="HideDatePickerValidation"
									CssClass="c_DatePicker_DATA_CR datepicker-default" ClientEvents-OnDateSelected="setDatePickerFocus" DateInput-DateFormat="dd/MM/yyyy"
									DateInput-WrapperCssClass="c_DatePicker_DATA_CR_dateInput_wrapper" DatePickerType="Date" DatePopupButton-ToolTip="Select date"
									EnableEmbeddedSkins="True" Height="32" HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900"
									PopupDirection="BottomRight" ReadOnly="False" RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="1"
									Width="261" />
							</div>
							<div id="LayoutCol3" class="col col-12 c_LayoutCol3">
								<telerik:RadLabel id="Label_LOGIN_USER_LOGIN" runat="server" CssClass="c_Label_LOGIN_USER_LOGIN"
									Text="<%$ Resources: Label_LOGIN_USER_LOGIN %>" />
								<telerik:RadComboBox id="ComboBox_LOGIN_USER_LOGIN" runat="server" disable-data-validation-onblur AllowCustomText="False"
									AutoPostBack="False" CssClass="c_ComboBox_LOGIN_USER_LOGIN combobox-primary" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
									data-validation-engine="validate[funcCall[ComboBox_LOGIN_USER_LOGIN_Validation]]" data-validation-message="Cliente não pode ser vazio!"
									EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None"
									ForeColor="#292828" LoadingMessage="<%$ Resources: ComboBox_LOGIN_USER_LOGIN %>" MarkFirstMatch="true" MaxHeight="100"
									OnClientBlur="___ComboBox_LOGIN_USER_LOGIN_OnBlur" OnClientItemsRequested="CheckComboItems"
									OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
									OnItemsRequested="___ComboBox_LOGIN_USER_LOGIN_OnItemsRequested" RenderMode="Lightweight" TabIndex="2" />
							</div>
							<div id="LayoutCol5" class="col col-12 c_LayoutCol5">
								<telerik:RadLabel id="Label_TPGTO_CR" runat="server" CssClass="c_Label_TPGTO_CR" Text="<%$ Resources: Label_TPGTO_CR %>" />
								<telerik:RadComboBox id="ComboBox1" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
									CssClass="c_ComboBox1 combobox-primary" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
									data-validation-engine="validate[funcCall[ComboBox1_Validation]]" data-validation-message="Pagamento não pode ser vazio!"
									EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None"
									ForeColor="#292828" LoadingMessage="<%$ Resources: ComboBox1 %>" MarkFirstMatch="true" MaxHeight="100" OnClientBlur="___ComboBox1_OnBlur"
									OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
									OnItemsRequested="___ComboBox1_OnItemsRequested" RenderMode="Lightweight" TabIndex="3" />
							</div>
							<div id="LayoutCol6" class="col col-12 col-sm-5 c_LayoutCol6">
								<telerik:RadLabel id="Label_ID_VENDA" runat="server" CssClass="c_Label_ID_VENDA" Text="<%$ Resources: Label_ID_VENDA %>" />
								<telerik:RadTextBox id="RadTextBox_ID_VENDA" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_ID_VENDA textbox-default"
									data-validation-engine="validate[funcCall[RadTextBox_ID_VENDA_Validation]]" data-validation-message="Venda não pode ser vazio!"
									EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="10"
									onkeydown="___RadTextBox_ID_VENDA_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="4" TextMode="SingleLine"
									UseTelerikMask="False" WrapperCssClass="c_RadTextBox_ID_VENDA_wrapper" />
							</div>
							<div id="LayoutCol8" class="col col-12 col-sm-2 c_LayoutCol8">
								<telerik:RadLabel id="Label_REC_CR" runat="server" CssClass="c_Label_REC_CR" Text="<%$ Resources: Label_REC_CR %>" />
								<telerik:RadCheckBox id="RadCheckBox_REC_CR" runat="server" AutoPostBack="True" Checked="False"
									CssClass="RadCheckBox_REC_CR c_RadCheckBox_REC_CR checkbox-secondary" RenderMode="Lightweight" TabIndex="5"
									Text="<%$ Resources: RadCheckBox_REC_CR %>" />
							</div>
							<div id="LayoutCol7" class="col col-12 col-sm-5 c_LayoutCol7">
								<telerik:RadLabel id="Label_VALOR_CR" runat="server" CssClass="c_Label_VALOR_CR" Text="<%$ Resources: Label_VALOR_CR %>" />
								<telerik:RadTextBox id="RadTextBox_VALOR_CR" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_VALOR_CR textbox-default"
									data-validation-engine="validate[funcCall[RadTextBox_VALOR_CR_Validation]]" data-validation-message="Valor não pode ser vazio!"
									EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="10"
									onkeydown="___RadTextBox_VALOR_CR_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="6" TextMode="SingleLine"
									UseTelerikMask="False" WrapperCssClass="c_RadTextBox_VALOR_CR_wrapper" />
							</div>
						</div>
						<div id="LayoutRow3" class="row c_LayoutRow3">
							<div id="LayoutCol9" class="col col-12 col-sm-6 c_LayoutCol9">
								<telerik:RadToolBar id="gToolbar" runat="server" CssClass="c_gToolbar" EnableRoundedCorners="True" EnableShadows="True"
									OnClientButtonClicking="ToolbarClickHandler" Orientation="Horizontal" RenderMode="Lightweight" Style="z-index:5999">
									<Items>
										<telerik:RadToolBarButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1 Button1" CommandArgument="Button1"
											CommandName="Button1" RenderMode="Lightweight" TabIndex="9" ToolTip="Cria novo registro">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button2" runat="server" ButtonType="SkinnedButton" CssClass="c_Button2 Button2" CommandArgument="Button2"
											CommandName="Button2" RenderMode="Lightweight" TabIndex="10" ToolTip="Grava alterações do registro atual">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button3" runat="server" ButtonType="SkinnedButton" CssClass="c_Button3 Button3" CommandArgument="Button3"
											CommandName="Button3" RenderMode="Lightweight" TabIndex="11" ToolTip="Cancela modificações no registro atual">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button4" runat="server" ButtonType="SkinnedButton" CssClass="c_Button4 Button4" CommandArgument="Button4"
											CommandName="Button4" RenderMode="Lightweight" TabIndex="12" ToolTip="Excluir registro atual">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button6" runat="server" ButtonType="SkinnedButton" CssClass="c_Button6 Button6" CommandArgument="Button6"
											CommandName="Button6" RenderMode="Lightweight" TabIndex="13" ToolTip="Mover para o registro anterior">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button7" runat="server" ButtonType="SkinnedButton" CssClass="c_Button7 Button7" CommandArgument="Button7"
											CommandName="Button7" RenderMode="Lightweight" TabIndex="14" ToolTip="Mover para o próximo registro">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button10" runat="server" ButtonType="SkinnedButton" CssClass="c_Button10 Button10" CommandArgument="Button10"
											CommandName="Button10" RenderMode="Lightweight" TabIndex="15" ToolTip="Inicia edição no registro atual">
										</telerik:RadToolBarButton>
									</Items>
								</telerik:RadToolBar>
							</div>
							<div id="LayoutCol11" class="col col-12 col-sm-6 c_LayoutCol11">
								<telerik:RadButton id="Button11" runat="server" ButtonType="SkinnedButton" CssClass="c_Button11 button-primary" CommandName="Button11"
									OnClick="___Button11_OnClick" RenderMode="Lightweight" TabIndex="7" Text="<%$ Resources: Button11 %>">
								</telerik:RadButton>
							</div>
						</div>
						<div id="LayoutRow4" class="row c_LayoutRow4">
							<div id="LayoutCol10" class="col col-12 c_LayoutCol10">
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
					setTimeout("var $j = jQuery.noConflict();$j('#DatePicker_DATA_CR_dateInput').first().focus();", 200);
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
				case "Button4":
					___Button4_OnClientClick(sender, args);
				break;
				case "Button6":
					___Button6_OnClientClick(sender, args);
				break;
				case "Button7":
					___Button7_OnClientClick(sender, args);
				break;
				case "Button10":
					___Button10_OnClientClick(sender, args);
				break;
			}
		}
		function ID_CR() { return document.getElementById('RadTextBox_ID_CR').value; }
		function DATA_CR() { return document.getElementById('DatePicker_DATA_CR').value; }
		function LOGIN_USER_LOGIN() { return $find("<%= ComboBox_LOGIN_USER_LOGIN.ClientID %>").get_value(); }
		function TPGTO_CR() { return $find("<%= ComboBox1.ClientID %>").get_value(); }
		function ID_VENDA() { return document.getElementById('RadTextBox_ID_VENDA').value; }
		function REC_CR() { return REC_CR.checked; }
		function VALOR_CR() { return document.getElementById('RadTextBox_VALOR_CR').value; }
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
						EnableDisableToolbarButtons(gToolbar.id,"Button4",!IsAjaxProcessing && __PAGECOUNT > 0 && __ALLOWREMOVE == "true" && __ISPARAMETER == "false");
						EnableDisableToolbarButtons(gToolbar.id,"Button6",!IsAjaxProcessing && __PAGESTATE == "navigation" && __PAGECOUNT > 0 && __PAGENUMBER > 1 && __ISPARAMETER == "false");
						EnableDisableToolbarButtons(gToolbar.id,"Button7",!IsAjaxProcessing && __PAGESTATE == "navigation" && __PAGECOUNT > 0 && __PAGENUMBER < __PAGECOUNT && __ISPARAMETER == "false");
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
				$j("#RadTextBox_ID_CR").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_ID_VENDA").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_VALOR_CR").bind("keydown", InitiateEditAuto);
				$j("#RadCheckBox_REC_CR").bind("change", InitiateEditAuto);
				$j("#ComboBox_LOGIN_USER_LOGIN").bind("change", InitiateEditAuto);
				$j("#ComboBox1").bind("change", InitiateEditAuto);
				$j("#DatePicker_DATA_CR").bind("change", InitiateEditAuto);
				$j("#DatePicker_DATA_CR_dateInput").bind("keydown", InitiateEditAuto);
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>

