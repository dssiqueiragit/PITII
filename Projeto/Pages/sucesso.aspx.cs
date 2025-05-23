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
using System.Configuration;
using System.Linq;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Configuration;
using COMPONENTS.Security;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;

namespace PROJETO.DataPages
{
	public partial class sucesso : GeneralDataPage
	{
		protected sucessoPageProvider PageProvider;
	

		public long ID_VENDAField = 0;
		public string LOGIN_USER_LOGINField = "";
		public DateTime ? DATA_VENDAField = null;
		public string OBS_VENDAField = "";
		public double TOTAL_VENDAField = 0;
		public string ENTREGA_VENDAField = "";
		public bool PENDENTE_VENDAField = false;
		public string TIPO_PGTO_VENDAField = "";
		
		public override string FormID { get { return "36045"; } }
		public override string TableName { get { return "TB_VENDA"; } }
		public override string DatabaseName { get { return "DbCupcake"; } }
		public override string PageName { get { return "sucesso.aspx"; } }
		public override string ProjectID { get { return "ED2986E"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return false;}}
		public override bool CanEdit { get { return false && UpdateValidation(); }}
		public override bool CanInsert  { get { return false && InsertValidation(); } }
		public override bool CanDelete { get { return false && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return false; } }
		


		public string vendaId = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(vendaId))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = Dao.PoeColAspas("ID_VENDA") + " = " + Dao.ToSql(vendaId.ToString(), FieldType.Integer, true);
				}
				else
				{
					PageProvider.MainProvider.DataProvider.StartFilter = "1 = 2";
				}
			}
			catch
			{
				PageProvider.MainProvider.DataProvider.StartFilter = "1 = 2";
			}
		}
		
		public override void CreateProvider()
		{
			PageProvider = new sucessoPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			vendaId = HttpContext.Current.Request.QueryString["vendaId"];
			try { if (string.IsNullOrEmpty(vendaId)) vendaId = HttpContext.Current.Session["vendaId"].ToString();} catch {} 
			if (string.IsNullOrEmpty(vendaId)) vendaId = "0";
			AjaxPanel = MainAjaxPanel;
			if (IsPostBack)
			{
				AjaxPanel.ResponseScripts.Add("setTimeout(\"InitializeClient();\",100);");
			}
			if (!PageInsert )
				DisableEnableContros(false);

			base.OnInit(e);
		}
		

		/// <summary>
		/// Carrega os objetos de Item de acordo com os controles
		/// </summary>
		public override void UpdateItemFromControl(GeneralDataProviderItem  Item)
		{
			// só vamos permitir a carga dos itens de acordo com os controles de tela caso esteja ocorrendo
			// um postback pois em caso contrário a página está sendo aberta em modo de inclusão/edição
			// e dessa forma não teve alteração de usuário nos dados do formulário
			if (PageState != FormStateEnum.Navigation && this.IsPostBack)
			{
			}
			InitializeAlias(Item);
		}

		/// <summary>
		/// Carrega os objetos de tela para o Item Provider da página
		/// </summary>

		public override GeneralDataProviderItem LoadItemFromControl(bool EnableValidation)
		{
			GeneralDataProviderItem Item = PageProvider.GetDataProviderItem(DataProvider);
			if (PageState != FormStateEnum.Navigation)
			{
			}
			else
			{
				Item = PageProvider.MainProvider.DataProvider.SelectItem(PageNumber, FormPositioningEnum.Current);
			}
			if (EnableValidation)
			{
				InitializeAlias(Item);
				if (PageState == FormStateEnum.Insert)
				{
					FillAuxiliarTables();
				}
				PageProvider.Validate(Item); 
			}
			if (Item!=null) PageErrors.Add(Item.Errors);
			return Item;
		}
		


		public override void DefineStartScripts()
		{
		}
		
		public override void DisableEnableContros(bool Action)
		{
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
			if (ShouldClearFields)
			{
			}
			if (!PageInsert && PageState == FormStateEnum.Navigation)
				DisableEnableContros(false);				
			else
				DisableEnableContros(true);				
		}		

		public override void ShowInitialValues()
		{
		}

		public override void PageEdit()
		{
			DisableEnableContros(true); 
			base.PageEdit(); 
		}

		public override void ShowFormulas()
		{
			Label1.Text = Label1.Text.Replace("<", "&lt;");
			Label1.Text = Label1.Text.Replace(">", "&gt;");
			Label2.Text = Label2.Text.Replace("<", "&lt;");
			Label2.Text = Label2.Text.Replace(">", "&gt;");
			try { Label3.Text = (ID_VENDAField).ToString(); }
			catch { Label3.Text = ""; }
			Label3.Text = Label3.Text.Replace(double.NaN.ToString(), "");
			Label3.Text = Label3.Text.Replace("<", "&lt;");
			Label3.Text = Label3.Text.Replace(">", "&gt;");
		}
		
		/// <summary>
		/// Define conteudo dos objetos de Tela
		/// </summary>
		public override void DefinePageContent(GeneralDataProviderItem Item)
		{
			InitializePageContent();
			base.DefinePageContent(Item);
		}
		/// <summary>
		/// Define apelidos da Página
		/// </summary>
		public override void InitializeAlias(GeneralDataProviderItem Item)
        {
			PageProvider.AliasVariables = new Dictionary<string, object>();
			PageProvider.AliasVariables.Clear();
			
			try
			{
				if (Item != null)
				{
					ID_VENDAField = long.Parse(Item["ID_VENDA"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
					ID_VENDAField = 0;
				}
			}
			catch
			{
				ID_VENDAField = 0;
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_LOGINField = Item["LOGIN_USER_LOGIN"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_LOGINField = "";
				}
			}
			catch
			{
				LOGIN_USER_LOGINField = "";
			}
			try
			{
				if (Item != null)
				{
					DATA_VENDAField = DateTime.Parse(Item["DATA_VENDA"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
					DATA_VENDAField = null;
				}
			}
			catch
			{
				DATA_VENDAField = null;
			}
			try
			{
				if (Item != null)
				{
					OBS_VENDAField = Item["OBS_VENDA"].GetFormattedValue();
				}
				else
				{
					OBS_VENDAField = "";
				}
			}
			catch
			{
				OBS_VENDAField = "";
			}
			try
			{
				if (Item != null)
				{
					TOTAL_VENDAField = double.Parse(Item["TOTAL_VENDA"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
					TOTAL_VENDAField = 0;
				}
			}
			catch
			{
				TOTAL_VENDAField = 0;
			}
			try
			{
				if (Item != null)
				{
					ENTREGA_VENDAField = Item["ENTREGA_VENDA"].GetFormattedValue();
				}
				else
				{
					ENTREGA_VENDAField = "";
				}
			}
			catch
			{
				ENTREGA_VENDAField = "";
			}
			try
			{
				if (Item != null)
				{
					PENDENTE_VENDAField = Utility.StringConverterToBool(Item["PENDENTE_VENDA"].GetFormattedValue());
				}
				else
				{
					PENDENTE_VENDAField = false;
				}
			}
			catch
			{
				PENDENTE_VENDAField = false;
			}
			try
			{
				if (Item != null)
				{
					TIPO_PGTO_VENDAField = Item["TIPO_PGTO_VENDA"].GetFormattedValue();
				}
				else
				{
					TIPO_PGTO_VENDAField = "";
				}
			}
			catch
			{
				TIPO_PGTO_VENDAField = "";
			}
			PageProvider.AliasVariables.Add("ID_VENDAField", ID_VENDAField);
			PageProvider.AliasVariables.Add("LOGIN_USER_LOGINField", LOGIN_USER_LOGINField);
			PageProvider.AliasVariables.Add("DATA_VENDAField", DATA_VENDAField);
			PageProvider.AliasVariables.Add("OBS_VENDAField", OBS_VENDAField);
			PageProvider.AliasVariables.Add("TOTAL_VENDAField", TOTAL_VENDAField);
			PageProvider.AliasVariables.Add("ENTREGA_VENDAField", ENTREGA_VENDAField);
			PageProvider.AliasVariables.Add("PENDENTE_VENDAField", PENDENTE_VENDAField);
			PageProvider.AliasVariables.Add("TIPO_PGTO_VENDAField", TIPO_PGTO_VENDAField);
			PageProvider.AliasVariables.Add("vendaId", vendaId);
			PageProvider.AliasVariables.Add("BasePage", this);
        }




		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
	}
}
