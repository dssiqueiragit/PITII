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
	
	public partial class ProcessoIncluiVenda : GeneralDataProcess
	{

		private ProcessoIncluiVendaProcessProvider PageProvider;

		public override string FormID { get { return "36038"; } }
		public override string PageName { get { return "ProcessoIncluiVenda.aspx"; } }

		public override void CreateProvider()
		{
			PageProvider = new ProcessoIncluiVendaProcessProvider(this);
		}
		
		/// <summary>
		/// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
		/// </summary>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			
		}
		
		public override void ShowFormulas()
		{
		}

		public override void GetScreenFieldsValues()
		{
			PageProvider.AliasVariables = new Dictionary<string, object>();
			PageProvider.AliasVariables.Clear();
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
			if (Provider.Name == "IncluiVenda")
			{
				return new DbCupcake_TB_VENDAItem("DbCupcake");
			}
			if (Provider.Name == "IncluiVenda")
			{
				return new DbCupcake_TB_VENDAItem("DbCupcake");
			}
			return null;
		}

	}


}
