﻿<%@ page language="C#" validaterequest="false" autoeventwireup="true" inherits="PROJETO.Pages.BlankPage, App_Web_yx2u1ccd" culture="auto" uiculture="auto" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
  <title>BlankPage</title>
</head>
	<body>
		<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
			<script type="text/javascript" src="<%= ResolveUrl("~/JS/Common.js??sv=4.0_20250520224510") %>"></script>
			<script type="text/javascript"> 
				currentPath = "<%= Page.Request.Path %>";
				function TryLogin(PageToRedirect, RefreshControlsID)
				{
					var isWindow = false;
					if (frameElement != null && frameElement.name.indexOf('gWinClass') != -1) 
					{
						isWindow = true;
					}
					TryParentLogin(PageToRedirect, RefreshControlsID, isWindow, '<%= ResolveUrl("~/Login") %>');
					try 
					{
						if (isWindow) 
						{
							var oWin = getParentPage().GetgWinsettings();
							var oArray = oWin.Windows.concat([]);
							for (i = 0; i < oArray.length; i++) 
							{
								if (oArray[i].Name == frameElement.name) 
								{
									oArray[i].Close();
									break;
								}
							}
						}
					}
					catch (ex)
					{
	
					}
					TryParentLogin(PageToRedirect, RefreshControlsID, false, '<%= ResolveUrl("~/Login") %>');
				}
			</script>
		</telerik:RadCodeBlock>
		<form id="Form1" runat="server"></form>
	</body>
	<script type="text/javascript">
		var Parameters = document.location.search;
		if (Parameters.length > 0)
		{
			var PageRedir = Parameters.substr(Parameters.indexOf("RequestingPage=") + 15);
			TryLogin(PageRedir, "");
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
		}
	</script>

</html>
