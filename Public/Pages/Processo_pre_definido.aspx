﻿<%@ page language="C#" autoeventwireup="true" enableeventvalidation="True" inherits="PROJETO.DataPages.Processo_pre_definido, App_Web_yx2u1ccd" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<meta name="generator" content="Gvinci Low-Code Platform" />
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/Processo_pre_definido.css" OrderIndex="1"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		<script type="text/javascript" src="../JS/jquery.js" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/popper.min.js??sv=4.0_20250519235534") %>" ></script>
		<script type="text/javascript" src="<%= ResolveUrl("~/JS/bootstrap.min.js??sv=4.0_20250519235534") %>" ></script>
		<script type="text/javascript" src="../JS/Mask.js" ></script>
		<script type="text/javascript" src="../JS/Functions.js"></script>
		<script type="text/javascript" src="../JS/Common.js"></script>


	<script type="text/javascript" src="<%= ResolveUrl("~/JS/Processo_pre_definido_USER.js??sv=4.0_20250519235534") %>"></script>

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
	function Navigate(Url, isWindow)
	{
		try
		{
			if(isWindow)
			{
				Gasopen(Url);
			}
			else
			{
				document.location.href = Url;
			}
		}
		catch(ex)
		{
		}
	}
	try
	{
		if(getParentPage() != self)
		{
			getParentPage().EnableButtons();
		}
	}
	catch (e)
	{
	}
</script>

	</telerik:RadCodeBlock>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="None">
			</div>
		</form>
</body>
<telerik:RadCodeBlock ID="EndCodeBlock" runat="server">
</telerik:RadCodeBlock>
</html>
