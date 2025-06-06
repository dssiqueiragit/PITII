﻿<%@ control language="C#" autoeventwireup="true" inherits="PROJETO.SidebarEmpresa, App_Web_exi4olje" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
	<meta name="generator" content="Gvinci Low-Code Platform" />
	<telerik:RadCodeBlock ID="CustomHeaderCodeBlock" runat="server">
			<link rel="stylesheet" href="<%= ResolveUrl("~/Styles/Bootstrap_PanelBar_panelbar_default.css")%>" type ="text/css" media="screen" title="no title" charset="utf-8" />
	</telerik:RadCodeBlock>
	<asp:HiddenField ID="Sidebar_ClientState" runat="server" />
	<div id="Form1" runat="server" class="c_SidebarEmpresa_Form1">
		<div id="__MainDiv" class="SidebarEmpresa_MainDiv" runat="server" StrechVertical="None">
			<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_SidebarEmpresa_Div1 div-secondary">
				<telerik:RadLabel id="labSolutionTitle" runat="server" CssClass="c_SidebarEmpresa_labSolutionTitle" Text="Cupcake" />
				<telerik:RadLabel id="Label2" runat="server" CssClass="c_SidebarEmpresa_Label2" />
				<div class="c_container_SidebarEmpresa_Icon1" id="Icon1Container" runat="server">
					<i id="Icon1" class="fas fa-user-circle c_SidebarEmpresa_Icon1">
					</i>
				</div>
			</div>
			<telerik:RadPanelBar id="PanelBar1" runat="server" CssClass="c_SidebarEmpresa_PanelBar1 panelbar-default" CollapseAnimation-Duration="200"
				CollapseAnimation-Type="OutQuint" ExpandAnimation-Duration="200" ExpandAnimation-Type="OutQuint" ExpandMode="SingleExpandedItem"
				OnClientItemClicked="___PanelBar1ClickHandler" PersistStateInCookie="True" RenderMode="Lightweight">
				<Items>
					<telerik:RadPanelItem id="PanelBarItem1" runat="server" CssClass="c_SidebarEmpresa_PanelBarItem1" Text="<%$ Resources: PanelBarItem1 %>"
						Value="PanelBarItem1" />
					<telerik:RadPanelItem id="PanelBarItem12" runat="server" CssClass="c_SidebarEmpresa_PanelBarItem12" Text="<%$ Resources: PanelBarItem12 %>"
						Value="PanelBarItem12" />
					<telerik:RadPanelItem id="PanelBarItem13" runat="server" CssClass="c_SidebarEmpresa_PanelBarItem13" Text="<%$ Resources: PanelBarItem13 %>"
						Value="PanelBarItem13" />
					<telerik:RadPanelItem id="PanelBarItem14" runat="server" CssClass="c_SidebarEmpresa_PanelBarItem14" Text="<%$ Resources: PanelBarItem14 %>"
						Value="PanelBarItem14" />
					<telerik:RadPanelItem id="PanelBarItem15" runat="server" CssClass="c_SidebarEmpresa_PanelBarItem15" Text="<%$ Resources: PanelBarItem15 %>"
						Value="PanelBarItem15" />
					<telerik:RadPanelItem id="PanelBarItem16" runat="server" CssClass="c_SidebarEmpresa_PanelBarItem16" Text="<%$ Resources: PanelBarItem16 %>"
						Value="PanelBarItem16" />
					<telerik:RadPanelItem id="PanelBarItem11" runat="server" CssClass="c_SidebarEmpresa_PanelBarItem11" Text="<%$ Resources: PanelBarItem11 %>"
						Value="PanelBarItem11" />
				</Items>
			</telerik:RadPanelBar>
		</div>
	</div>
<script type="text/javascript">
		function ___PanelBar1ClickHandler(sender, args)
		{
			var ClickedItem = args.get_item();
			if (HasValue(ClickedItem))
			{
				switch (ClickedItem.get_value())
				{
					case "PanelBarItem1":
						___PanelBarItem1_OnClick(sender, args);
					break;
					case "PanelBarItem12":
						___PanelBarItem12_OnClick(sender, args);
					break;
					case "PanelBarItem13":
						___PanelBarItem13_OnClick(sender, args);
					break;
					case "PanelBarItem14":
						___PanelBarItem14_OnClick(sender, args);
					break;
					case "PanelBarItem15":
						___PanelBarItem15_OnClick(sender, args);
					break;
					case "PanelBarItem16":
						___PanelBarItem16_OnClick(sender, args);
					break;
					case "PanelBarItem11":
						___PanelBarItem11_OnClick(sender, args);
					break;
				}
			}
		}
		function ___PanelBarItem1_OnClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/home") %>';
			NavigateBrowser(UrlPage);
		}
		function ___PanelBarItem12_OnClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/access") %>';
			NavigateBrowser(UrlPage);
		}
		function ___PanelBarItem13_OnClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/cadastro") %>';
			NavigateBrowser(UrlPage);
		}
		function ___PanelBarItem14_OnClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/produto") %>';
			NavigateBrowser(UrlPage);
		}
		function ___PanelBarItem15_OnClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/venda") %>';
			NavigateBrowser(UrlPage);
		}
		function ___PanelBarItem16_OnClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/financeiro") %>';
			NavigateBrowser(UrlPage);
		}
		function ___PanelBarItem11_OnClick(sender, args)
		{
			localStorage.removeItem('SSI_F'); localStorage.removeItem('SSI_T'); Logoff();
		}
</script>
