using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Web.UI;
using System.Web.Routing;
using COMPONENTS;
using System.Web.Routing;

namespace PROJETO
{

	public partial class Global : System.Web.HttpApplication
	{

        partial void ApplicationStartExtension();
        partial void RegisterRoutesExtension(RouteCollection routes);
        partial void SessionStartExtension();
        partial void ApplicationBeginRequestExtension();
        partial void ApplicationEndRequestExtension();
        partial void SessionEndExtension();
        partial void ApplicationEndExtension();

		protected void Application_Start(Object sender, EventArgs e)
		{
			LoadApplicationSettings();
			RegisterRoutes(RouteTable.Routes);
			ApplicationStartExtension();
		}

		void RegisterRoutes(RouteCollection routes)
		{
			routes.MapPageRoute("root", "", "~/Pages/HomeAspx.aspx", false);
			routes.MapPageRoute("LoginPage", "Login", "~/Pages/LoginPage.aspx", false);
			routes.MapPageRoute("HomeAspx", "home", "~/Pages/HomeAspx.aspx", false);
			routes.MapPageRoute("Pag_Cad_Prod", "produto", "~/Pages/Pag_Cad_Prod.aspx", false);
			routes.MapPageRoute("Pag_Cad_Venda", "venda", "~/Pages/Pag_Cad_Venda.aspx", false);
			routes.MapPageRoute("TB_LOGIN_USER", "cadastro", "~/Pages/TB_LOGIN_USER.aspx", false);
			routes.MapPageRoute("PagRec", "financeiro", "~/Pages/PagRec.aspx", false);
			routes.MapPageRoute("Access", "access", "~/Pages Administrativa/Access.aspx", false);
			RegisterRoutesExtension(routes);
		}

		protected string GetFileHash(string fileName)
		{
			FileStream file = new FileStream(fileName, FileMode.Open);
			System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] retVal = md5.ComputeHash(file);
			file.Close();

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			for (int i = 0; i < retVal.Length; i++)
			{
				sb.Append(retVal[i].ToString("x2"));
			}
			return sb.ToString();
		}

		private void LoadApplicationSettings()
		{
			string ConfigFile = Server.MapPath("~/App_Data/App.Config");
			string CurrentHash = GetFileHash(ConfigFile);
			
			// não vamos recarregar as configurações...
			if (Application["ConfigFileHash"] != null && Application["ConfigFileHash"].Equals(CurrentHash)) return;

			Application["Databases"] = new Databases(ConfigFile);
			Application["_locales"] = System.Configuration.ConfigurationManager.GetSection("locales");
			HttpContext.Current.Cache.Insert("__InvalidateAllPages", DateTime.Now, null,
											System.DateTime.MaxValue, System.TimeSpan.Zero,
											System.Web.Caching.CacheItemPriority.NotRemovable,
											null);
			Application["culture"] = Utility.siteLanguage;
			bool NeedToCreateDB = false;
			bool NeedToAdapter = false;
			foreach (DatabaseInfo vgDbi in ((Databases)Application["Databases"]).DataBaseList.Values)
			{
				if ((vgDbi.CheckDatabase == null || vgDbi.CheckDatabase == true) || (vgDbi.StringConnection == null || vgDbi.StringConnection == ""))
				{
					NeedToCreateDB = true;
				}
				else
				{
					if (vgDbi.RunAdapter)
					{
						NeedToAdapter = true;						
					}
				}
			}
			if (NeedToCreateDB)
			{
				Application["PageStart"] = "1";
			}
			else if (NeedToAdapter)
			{
		Application["PageStart"] = "2";
			}
			else
			{
				Application.Remove("PageStart");
			}
		}
		
		protected void Session_Start(Object sender, EventArgs e)
		{
			LoadApplicationSettings();
			if (Application["PageStart"] != null)
			{
				if (Application["PageStart"] == "1")
				{
					System.Web.HttpContext.Current.Response.Redirect(System.Web.VirtualPathUtility.ToAbsolute("~/Pages Administrativa/ConfigDB.aspx"));
				}
				else if (Application["PageStart"] == "2")
				{
					System.Web.HttpContext.Current.Response.Redirect(System.Web.VirtualPathUtility.ToAbsolute("~/Gadapter/Pages/Default.aspx?SilentMode=true"));
				}
				Application.Remove("PageStart");
			}
			SessionStartExtension();
		}
		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			if (Application[Request.PhysicalPath] != null)
				Request.ContentEncoding = System.Text.Encoding.GetEncoding(Application[Request.PhysicalPath].ToString());
			ApplicationBeginRequestExtension();
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{
			ApplicationEndRequestExtension();
		}

		protected void Session_End(Object sender, EventArgs e)
		{
			SessionEndExtension();
		}

		protected void Application_End(Object sender, EventArgs e)
		{
			ApplicationEndExtension();
		}

	}

}
