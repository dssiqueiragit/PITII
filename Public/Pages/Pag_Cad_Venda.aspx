﻿<%@ page language="C#" validaterequest="false" maintainscrollpositiononpostback="true" enableeventvalidation="True" autoeventwireup="true" inherits="PROJETO.DataPages.Pag_Cad_Venda, App_Web_yx2u1ccd" culture="auto" uiculture="auto" %>
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
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Grid_grid_default.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_RadTextBox_textbox_default.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Bootstrap_Button_button_primary.css" OrderIndex="0"/>
			<telerik:StyleSheetReference Path="~/Styles/Pag_Cad_Venda.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/validationEngine.jquery.css") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/animate.min.css") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/bootstrap5.min.css??sv=4.0_20250520224510") %>" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/all.min.css??sv=4.0_20250520224510") %>" type="text/css" media="screen" title="no title"/>  	
		<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/gvbaselayout.css??sv=4.0_20250520224510") %>" type="text/css" media="screen" title="no title"/>
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		


		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.js") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.min.js??sv=4.0_20250520224510") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mask.global.js??sv=4.0_20250520224510") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/bootstrap5.bundle.min.js??sv=4.0_20250520224510") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/wow.min.js") %>" ></script>
		<script type="text/javascript"> new WOW().init(); </script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Page.js??sv=4.0_20250520224510") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Common.js??sv=4.0_20250520224510") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Functions.js??sv=4.0_20250520224510") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/RadComboBoxHelper.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/Pag_Cad_Venda_USER.js??sv=4.0_20250520224510") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.validationEngine-pt_BR.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.validationEngine.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/validation.js") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/jquery.mCustomScrollbar.concat.min.js??sv=4.0_20250520224510") %>"></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/LayoutController.js??sv=4.0_20250520224510") %>" ></script>

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
		function Grid1Created(sender, args) {
			var $j = jQuery.noConflict();
			if (($j("#Grid1ShouldDisable")[0] && $j("#Grid1ShouldDisable")[0].value == "True") || ($j("#__PAGESTATE")[0] && $j("#__PAGESTATE")[0].value == "Insert"))
				DisableGrid(sender);
		}
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
		function ___ComboBox_ID_CLIENTE_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___RadTextBox_OBS_VENDA_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___ComboBox1_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___RadTextBox_TOTAL_VENDA_onkeydown(event,vgWin)
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
		function ___Button10_OnClientClick(sender, args)
		{
			Edit(this);
			args.set_cancel(true);
			return false;
		}
		function DatePicker_DATA_VENDA_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function ComboBox_ID_CLIENTE_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function ComboBox1_Validation(field, rules, i, options) {
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
							<div id="LayoutCol1" class="col  col-12 c_LayoutCol1">
								<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Cadastro de Venda" />
							</div>
						</div>
						<div id="LayoutRow2" class="row c_LayoutRow2">
							<div id="LayoutCol3" class="col  col-12col-sm-4 c_LayoutCol3">
								<telerik:RadLabel id="Label_DATA_VENDA" runat="server" CssClass="c_Label_DATA_VENDA" Text="<%$ Resources: Label_DATA_VENDA %>" />
								<telerik:RadDatePicker id="DatePicker_DATA_VENDA" runat="server" Calendar-ClientEvents-OnDateClick="HideDatePickerValidation"
									CssClass="c_DatePicker_DATA_VENDA datepicker-default" ClientEvents-OnDateSelected="setDatePickerFocus" DateInput-DateFormat="dd/MM/yyyy"
									DateInput-WrapperCssClass="c_DatePicker_DATA_VENDA_dateInput_wrapper" DatePickerType="Date" DatePopupButton-ToolTip="Select date"
									EnableEmbeddedSkins="True" Height="32" HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900"
									PopupDirection="BottomRight" ReadOnly="False" RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="1"
									Width="166" />
							</div>
							<div id="LayoutCol4" class="col  col-12col-sm-8 c_LayoutCol4">
								<telerik:RadLabel id="Label_ID_CLIENTE" runat="server" CssClass="c_Label_ID_CLIENTE" Text="<%$ Resources: Label_ID_CLIENTE %>" />
								<telerik:RadComboBox id="ComboBox_ID_CLIENTE" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
									CssClass="c_ComboBox_ID_CLIENTE combobox-primary" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
									data-validation-engine="validate[funcCall[ComboBox_ID_CLIENTE_Validation]]" data-validation-message="Cliente não pode ser vazio!"
									EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None"
									ForeColor="#292828" LoadingMessage="<%$ Resources: ComboBox_ID_CLIENTE %>" MarkFirstMatch="true" MaxHeight="100"
									OnClientBlur="___ComboBox_ID_CLIENTE_OnBlur" OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting"
									OnClientKeyPressing="Combo_HandleKeyPress" OnItemsRequested="___ComboBox_ID_CLIENTE_OnItemsRequested" RenderMode="Lightweight" TabIndex="2" />
							</div>
						</div>
						<div id="LayoutRow3" class="row c_LayoutRow3">
							<div id="LayoutCol8" class="col  col-12 c_LayoutCol8">
								<telerik:RadGrid id="Grid1" runat="server" AllowCustomPaging="true" AllowFilteringByColumn="False" AllowPaging="True" AllowSorting="True"
									AutoGenerateColumns="false" CssClass="c_Grid1 grid-default" CleanLayoutNoRecord="True" EnableEmbeddedSkins="True"
									EnableHeaderContextMenu="False" EnableLinqExpressions="false" ExportFileName="GGrid" OnDeleteCommand="Grid_DeleteCommand" OnInit="Grid_Init"
									OnInsertCommand="Grid_InsertCommand" OnItemCommand="Grid1_ItemCommand" OnItemCreated="Grid1_ItemCreated"
									OnItemDataBound="Grid1_ItemDataBound" OnNeedDataSource="Grid_NeedDataSource" OnPreRender="Grid1_PreRender"
									OnUpdateCommand="Grid_UpdateCommand" PageSize="10" RenderMode="Lightweight" ShowFooter="False" ShowGroupPanel="False" Skin="Telerik"
									TabIndex="3" TableLayout="Fixed">
									<MasterTableView  AllowCustomPaging="true" CommandItemDisplay="Top" DataKeyNames="ID_VENDA_ITEM" EditMode="InPlace" OnPreRender="Grid1_PreRender">
										<Columns>
											<telerik:GridEditCommandColumn Exportable="false" ButtonType="ImageButton" HeaderStyle-Width="50" ItemStyle-CssClass="Grid1_EditColumn" UniqueName="Grid1_EditColumn"/>
											<telerik:GridTemplateColumn UniqueName="GridColumn_ID_PRODUTO" runat="server" AllowFiltering="True" AutoPostBackOnFilter="False"
												ConvertEmptyStringToNull="False" DataField="ID_PRODUTO" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="100%"
												FilterDelay="2000" ForceExtractValue="Always" GroupByExpression="ID_PRODUTO ID_PRODUTO Group By ID_PRODUTO"
												HeaderStyle-CssClass="c_GridColumn_ID_PRODUTO" HeaderStyle-Width="238" HeaderText="<%$ Resources: GridColumn_ID_PRODUTO %>"
												ItemStyle-CssClass="c_GridColumn_ID_PRODUTO" ItemStyle-Width="231" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True"
												SortExpression="ID_PRODUTO">
												<EditItemTemplate>
													<telerik:RadComboBox RenderMode="Lightweight" Skin="Telerik" ID="GridColumn_ID_PRODUTO_ComboBox" runat="server" MarkFirstMatch="True" AllowCustomText="False" 
														 AutoPostBack="False" EnableLoadOnDemand="True" EnableVirtualScrolling="True" MaxHeight="100"
														OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting" DropDownAutoWidth ="Enabled"
														OnClientKeyPressing="Combo_HandleKeyPress" OnItemsRequested="___Grid1_GridColumn_ID_PRODUTO_ComboBox_OnItemsRequested" ItemsPerRequest="15"
														Width="223" ClientIDMode="Static" />
												</EditItemTemplate>
												<ItemTemplate> 
													<asp:Label runat="server" ID="GridColumn_ID_PRODUTO_Label" Text='<%#PageProvider.Pag_Cad_Venda_Grid1Provider.GetGridComboText("GridColumn_ID_PRODUTO", Eval("ID_PRODUTO").ToString())%>' Value='<%#Eval("ID_PRODUTO").ToString()%>'/>
												</ItemTemplate> 
											</telerik:GridTemplateColumn>
											<telerik:GridBoundColumn UniqueName="GridColumn_QTDE_VENDA_ITEM" runat="server" AllowFiltering="True" AllowSorting="true"
												AutoPostBackOnFilter="False" ConvertEmptyStringToNull="False" DataField="QTDE_VENDA_ITEM" DataFormatString="{0:#########0}"
												EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="100%" FilterDelay="2000" FooterStyle-HorizontalAlign="Right"
												ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn_QTDE_VENDA_ITEM" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="59"
												HeaderText="<%$ Resources: GridColumn_QTDE_VENDA_ITEM %>" ItemStyle-CssClass="c_GridColumn_QTDE_VENDA_ITEM"
												ItemStyle-HorizontalAlign="Right" ItemStyle-Width="52" MaxLength="10" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
											<telerik:GridBoundColumn UniqueName="GridColumn_VALOR_VENDA_ITEM" runat="server" AllowFiltering="True" AllowSorting="true"
												AutoPostBackOnFilter="False" ConvertEmptyStringToNull="False" DataField="VALOR_VENDA_ITEM" DataFormatString="{0:#######0.00}"
												EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="100%" FilterDelay="2000" FooterStyle-HorizontalAlign="Right"
												ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn_VALOR_VENDA_ITEM" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="93"
												HeaderText="<%$ Resources: GridColumn_VALOR_VENDA_ITEM %>" ItemStyle-CssClass="c_GridColumn_VALOR_VENDA_ITEM"
												ItemStyle-HorizontalAlign="Right" ItemStyle-Width="86" MaxLength="11" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
											<telerik:GridBoundColumn UniqueName="GridColumn2" runat="server" AllowFiltering="false" AutoPostBackOnFilter="False"
												EnableHeaderContextMenu="True" Exportable="True" FilterDelay="2000" HeaderStyle-CssClass="c_GridColumn2" HeaderStyle-Width="93"
												HeaderText="<%$ Resources: GridColumn2 %>" ItemStyle-CssClass="c_GridColumn2" ItemStyle-Width="86" MaxLength="0" ReadOnly="true"
												ShowFilterIcon="True" ShowSortIcon="True" />
											<telerik:GridButtonColumn Exportable="false" HeaderStyle-Width="25"  ConfirmText="Deseja excluir o registro?"  ConfirmDialogWidth="300"  ConfirmDialogHeight="200"  ConfirmDialogType="Classic"  ConfirmTitle="Confirmação de exclusão" ButtonType="ImageButton" CommandName="Delete" UniqueName="Grid1_DeleteColumn"/>
										</Columns>
										<EditFormSettings>
											<EditColumn ButtonType="ImageButton" />
										</EditFormSettings>
										<CommandItemSettings ShowAddNewRecordButton="True" ShowRefreshButton="True" AddNewRecordText="" RefreshText="" />
									</MasterTableView>
									<PagerStyle Mode="NextPrevAndNumeric" />
									<ClientSettings EnableRowHoverStyle="true">
										<ClientEvents OnGridCreated="Grid1Created" />
									</ClientSettings>
								</telerik:RadGrid>
							</div>
							<div id="LayoutCol5" class="col  col-12 c_LayoutCol5">
								<telerik:RadLabel id="Label_OBS_VENDA" runat="server" CssClass="c_Label_OBS_VENDA" Text="<%$ Resources: Label_OBS_VENDA %>" />
								<telerik:RadTextBox id="RadTextBox_OBS_VENDA" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_OBS_VENDA textbox-default"
									EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="0"
									onkeydown="___RadTextBox_OBS_VENDA_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="4" TextMode="MultiLine"
									UseTelerikMask="False" WrapperCssClass="c_RadTextBox_OBS_VENDA_wrapper" />
							</div>
							<div id="LayoutCol10" class="col  col-12 c_LayoutCol10">
								<div id="LayoutRow5" class="row c_LayoutRow5">
									<div id="LayoutCol7" class="col  col-12col-sm-6 c_LayoutCol7">
										<telerik:RadLabel id="Label_ENTREGA_VENDA" runat="server" CssClass="c_Label_ENTREGA_VENDA" Text="<%$ Resources: Label_ENTREGA_VENDA %>" />
										<telerik:RadComboBox id="ComboBox1" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
											CssClass="c_ComboBox1 combobox-primary" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
											data-validation-engine="validate[funcCall[ComboBox1_Validation]]" data-validation-message="Entrega não pode ser vazio!"
											EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300"
											ExpandAnimation-Type="None" ForeColor="#292828" LoadingMessage="<%$ Resources: ComboBox1 %>" MarkFirstMatch="true" MaxHeight="100"
											OnClientBlur="___ComboBox1_OnBlur" OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
											OnItemsRequested="___ComboBox1_OnItemsRequested" RenderMode="Lightweight" TabIndex="5" />
									</div>
									<div id="LayoutCol6" class="col  col-12col-sm-6 c_LayoutCol6">
										<telerik:RadLabel id="Label_TOTAL_VENDA" runat="server" CssClass="c_Label_TOTAL_VENDA" Text="<%$ Resources: Label_TOTAL_VENDA %>" />
										<telerik:RadTextBox id="RadTextBox_TOTAL_VENDA" runat="server" AutoPostBack="False" CssClass="c_RadTextBox_TOTAL_VENDA textbox-default"
											EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#333333" MaxLength="11"
											onkeydown="___RadTextBox_TOTAL_VENDA_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="6" TextMode="SingleLine"
											UseTelerikMask="False" WrapperCssClass="c_RadTextBox_TOTAL_VENDA_wrapper" />
									</div>
								</div>
							</div>
							<div id="LayoutCol11" class="col  col-12col-sm-6 c_LayoutCol11">
								<telerik:RadToolBar id="gToolbar" runat="server" CssClass="c_gToolbar" EnableRoundedCorners="True" EnableShadows="True"
									OnClientButtonClicking="ToolbarClickHandler" Orientation="Horizontal" RenderMode="Lightweight" Style="z-index:5999">
									<Items>
										<telerik:RadToolBarButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1 Button1" CommandArgument="Button1"
											CommandName="Button1" RenderMode="Lightweight" TabIndex="8" ToolTip="Cria novo registro">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button2" runat="server" ButtonType="SkinnedButton" CssClass="c_Button2 Button2" CommandArgument="Button2"
											CommandName="Button2" RenderMode="Lightweight" TabIndex="9" ToolTip="Grava alterações do registro atual">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button3" runat="server" ButtonType="SkinnedButton" CssClass="c_Button3 Button3" CommandArgument="Button3"
											CommandName="Button3" RenderMode="Lightweight" TabIndex="10" ToolTip="Cancela modificações no registro atual">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button4" runat="server" ButtonType="SkinnedButton" CssClass="c_Button4 Button4" CommandArgument="Button4"
											CommandName="Button4" RenderMode="Lightweight" TabIndex="11" ToolTip="Excluir registro atual">
										</telerik:RadToolBarButton>
										<telerik:RadToolBarButton id="Button10" runat="server" ButtonType="SkinnedButton" CssClass="c_Button10 Button10" CommandArgument="Button10"
											CommandName="Button10" RenderMode="Lightweight" TabIndex="12" ToolTip="Inicia edição no registro atual">
										</telerik:RadToolBarButton>
									</Items>
								</telerik:RadToolBar>
							</div>
							<div id="LayoutCol24" class="col  col-12col-sm-6 c_LayoutCol24">
								<telerik:RadButton id="Button13" runat="server" ButtonType="SkinnedButton" CssClass="c_Button13 button-primary" CommandName="Button13"
									OnClick="___Button13_OnClick" RenderMode="Lightweight" TabIndex="7" Text="<%$ Resources: Button13 %>">
								</telerik:RadButton>
							</div>
						</div>
						<div id="LayoutRow4" class="row c_LayoutRow4">
							<div id="LayoutCol9" class="col  col-12 c_LayoutCol9">
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
					setTimeout("var $j = jQuery.noConflict();$j('#DatePicker_DATA_VENDA_dateInput').first().focus();", 200);
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
				case "Button10":
					___Button10_OnClientClick(sender, args);
				break;
			}
		}
		function DATA_VENDA() { return document.getElementById('DatePicker_DATA_VENDA').value; }
		function LOGIN_USER_LOGIN() { return $find("<%= ComboBox_ID_CLIENTE.ClientID %>").get_value(); }
		function OBS_VENDA() { return document.getElementById('RadTextBox_OBS_VENDA').value; }
		function ENTREGA_VENDA() { return $find("<%= ComboBox1.ClientID %>").get_value(); }
		function TOTAL_VENDA() { return document.getElementById('RadTextBox_TOTAL_VENDA').value; }
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
				$j("#RadTextBox_OBS_VENDA").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox_TOTAL_VENDA").bind("keydown", InitiateEditAuto);
				$j("#ComboBox_ID_CLIENTE").bind("change", InitiateEditAuto);
				$j("#ComboBox1").bind("change", InitiateEditAuto);
				$j("#DatePicker_DATA_VENDA").bind("change", InitiateEditAuto);
				$j("#DatePicker_DATA_VENDA_dateInput").bind("keydown", InitiateEditAuto);
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>

