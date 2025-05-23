using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Globalization;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Configuration;
using COMPONENTS.Security;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;
using System.Linq;

namespace PROJETO.DataPages
{
	
	public partial class ProcessoIncluiCr : GeneralDataProcess
	{

		private ProcessoIncluiCrProcessProvider PageProvider;

		public override string FormID { get { return "36042"; } }
		public override string PageName { get { return "ProcessoIncluiCr.aspx"; } }
		public string ParamVenda = "";
		public string ParamData = "";
		public string ParamValor = "";

		public override void CreateProvider()
		{
			PageProvider = new ProcessoIncluiCrProcessProvider(this);
		}
		
		/// <summary>
		/// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
		/// </summary>
		protected override void OnInit(EventArgs e)
		{
			ParamVenda = HttpContext.Current.Request.QueryString["ParamVenda"];
			try { if (string.IsNullOrEmpty(ParamVenda)) ParamVenda = HttpContext.Current.Session["ParamVenda"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamVenda)) ParamVenda = "0";
			ParamData = HttpContext.Current.Request.QueryString["ParamData"];
			try { if (string.IsNullOrEmpty(ParamData)) ParamData = HttpContext.Current.Session["ParamData"].ToString();} catch {} 
			ParamValor = HttpContext.Current.Request.QueryString["ParamValor"];
			try { if (string.IsNullOrEmpty(ParamValor)) ParamValor = HttpContext.Current.Session["ParamValor"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamValor)) ParamValor = "0";
			base.OnInit(e);
			
		}
		
		public override void ShowFormulas()
		{
		}

		public override void GetScreenFieldsValues()
		{
			PageProvider.AliasVariables = new Dictionary<string, object>();
			PageProvider.AliasVariables.Clear();
			PageProvider.AliasVariables.Add("ParamVenda", ParamVenda);
			PageProvider.AliasVariables.Add("ParamData", ParamData);
			PageProvider.AliasVariables.Add("ParamValor", ParamValor);
		}

		public void ExecutePreDefProcess()
		{
			try
			{
				GetScreenFieldsValues();
				GeneralDataProviderItem item = new GeneralDataProviderItem();
				PageProvider.Validate(item);
				if (item.Errors.Count == 0)
				{
					if (ErrorLabel != null) ErrorLabel.Text = "";
					PageProvider.ExecutePreDefinedProcess();
					OnProcessSucceeded();
				}
				else ShowErrors(item.Errors);
			}
			catch (Exception ex)
			{
				OnProcessFailed();
				NameValueCollection Errors = new NameValueCollection();
                Errors.Add("Error", ex.Message);
                ShowErrors(Errors);
			}
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "ItemIncluiCR")
			{
				return new DbCupcake_TB_VENDAItem("DbCupcake");
			}
			if (Provider.Name == "ItemIncluiCR")
			{
				return new DbCupcake_TB_VENDAItem("DbCupcake");
			}
			if (Provider.Name == "AUX_TB_CR")
			{
				return new DbCupcake_TB_CRItem("DbCupcake");
			}
			return null;
		}

	}


}
