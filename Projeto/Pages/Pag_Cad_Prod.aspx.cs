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
	public partial class Pag_Cad_Prod : GeneralDataPage
	{
		protected Pag_Cad_ProdPageProvider PageProvider;
	

		public string NOME_PRODUTOField = "";
		public double VALOR_PRODUTOField = 0;
		public string OBS_PRODUTOField = "";
		public long ID_PRODUTOField = 0;
		
		public override string FormID { get { return "36032"; } }
		public override string TableName { get { return "TB_PRODUTO"; } }
		public override string DatabaseName { get { return "DbCupcake"; } }
		public override string PageName { get { return "Pag_Cad_Prod.aspx"; } }
		public override string ProjectID { get { return "ED2986E"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return false;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return false; } }
		



		
		public override void CreateProvider()
		{
			PageProvider = new Pag_Cad_ProdPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			AjaxPanel = MainAjaxPanel;
			if (IsPostBack)
			{
				AjaxPanel.ResponseScripts.Add("setTimeout(\"InitializeClient();\",100);");
			}
			AjaxPanel.ResponseScripts.Add("setTimeout(\"RegisterClientValidateScript();\",100);");
			ErrorLabel = labError;
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
				Item.SetFieldValue(Item["NOME_PRODUTO"], RadTextBox_NOME_PRODUTO.Text, false);
				Item.SetFieldValue(Item["VALOR_PRODUTO"], RadTextBox_VALOR_PRODUTO.Text, false);
				if((string)Session["FOTO1_PRODUTO36032"]!=null)
					Item.SetFieldValue(Item["FOTO1_PRODUTO"], Convert.FromBase64String((string)Session["FOTO1_PRODUTO36032"]));
				else
					Item.SetFieldValue(Item["FOTO1_PRODUTO"], null);
				if((string)Session["FOTO2_PRODUTO36032"]!=null)
					Item.SetFieldValue(Item["FOTO2_PRODUTO"], Convert.FromBase64String((string)Session["FOTO2_PRODUTO36032"]));
				else
					Item.SetFieldValue(Item["FOTO2_PRODUTO"], null);
				Item.SetFieldValue(Item["OBS_PRODUTO"], RadTextBox_OBS_PRODUTO.Text, false);
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
				Item.SetFieldValue(Item["NOME_PRODUTO"], RadTextBox_NOME_PRODUTO.Text, false);
				Item.SetFieldValue(Item["VALOR_PRODUTO"], RadTextBox_VALOR_PRODUTO.Text, false);
				if((string)Session["FOTO1_PRODUTO36032"]!=null)
					Item.SetFieldValue(Item["FOTO1_PRODUTO"], Convert.FromBase64String((string)Session["FOTO1_PRODUTO36032"]));
				else
					Item.SetFieldValue(Item["FOTO1_PRODUTO"], null);
				if((string)Session["FOTO2_PRODUTO36032"]!=null)
					Item.SetFieldValue(Item["FOTO2_PRODUTO"], Convert.FromBase64String((string)Session["FOTO2_PRODUTO36032"]));
				else
					Item.SetFieldValue(Item["FOTO2_PRODUTO"], null);
				Item.SetFieldValue(Item["OBS_PRODUTO"], RadTextBox_OBS_PRODUTO.Text, false);
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
			Utility.SetControlTabOnEnter(RadTextBox_OBS_PRODUTO);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox_NOME_PRODUTO.Enabled = Action;
			RadTextBox_VALOR_PRODUTO.Enabled = Action;
			GMultiMedia_FOTO1_PRODUTO.Disabled = !Action;
			GMultiMedia_FOTO2_PRODUTO.Disabled = !Action;
			RadTextBox_OBS_PRODUTO.Enabled = Action;
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
			if (ShouldClearFields)
			{
				RadTextBox_NOME_PRODUTO.Text = "";
				RadTextBox_VALOR_PRODUTO.Text = "";
				MediaHandlerHelper.PrepareMediaHandler(null, "FOTO1_PRODUTO36032", false, false);
				MediaHandlerHelper.PrepareMediaHandler(null, "FOTO2_PRODUTO36032", false, false);
				RadTextBox_OBS_PRODUTO.Text = "";
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
			Label_NOME_PRODUTO.Text = Label_NOME_PRODUTO.Text.Replace("<", "&lt;");
			Label_NOME_PRODUTO.Text = Label_NOME_PRODUTO.Text.Replace(">", "&gt;");
			Label_VALOR_PRODUTO.Text = Label_VALOR_PRODUTO.Text.Replace("<", "&lt;");
			Label_VALOR_PRODUTO.Text = Label_VALOR_PRODUTO.Text.Replace(">", "&gt;");
			Label_FOTO1_PRODUTO.Text = Label_FOTO1_PRODUTO.Text.Replace("<", "&lt;");
			Label_FOTO1_PRODUTO.Text = Label_FOTO1_PRODUTO.Text.Replace(">", "&gt;");
			Label_FOTO2_PRODUTO.Text = Label_FOTO2_PRODUTO.Text.Replace("<", "&lt;");
			Label_FOTO2_PRODUTO.Text = Label_FOTO2_PRODUTO.Text.Replace(">", "&gt;");
			Label_OBS_PRODUTO.Text = Label_OBS_PRODUTO.Text.Replace("<", "&lt;");
			Label_OBS_PRODUTO.Text = Label_OBS_PRODUTO.Text.Replace(">", "&gt;");
		}
		
		/// <summary>
		/// Define conteudo dos objetos de Tela
		/// </summary>
		public override void DefinePageContent(GeneralDataProviderItem Item)
		{
			try
			{
				if (Item != null)
				{
					RadTextBox_NOME_PRODUTO.Text = Item["NOME_PRODUTO"].GetFormattedValue();
				}
				else
				{
					RadTextBox_NOME_PRODUTO.Text = "";
				}
			}
			catch
			{
				RadTextBox_NOME_PRODUTO.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_VALOR_PRODUTO.Text = Item["VALOR_PRODUTO"].GetFormattedValue().Replace(".",",");
				}
				else
				{
					RadTextBox_VALOR_PRODUTO.Text = "";
				}
			}
			catch
			{
				RadTextBox_VALOR_PRODUTO.Text = "";
			}
			if ((Item != null) && !(Item["FOTO1_PRODUTO"].GetValue() == null)  && !(Item["FOTO1_PRODUTO"].GetValue() is System.DBNull))
			{
				MediaHandlerHelper.PrepareMediaHandler((byte[])Item["FOTO1_PRODUTO"].GetValue(), "FOTO1_PRODUTO36032", false, false);
			}
			else
			{
				MediaHandlerHelper.PrepareMediaHandler(null, "FOTO1_PRODUTO36032", false, false);
			}
			if ((Item != null) && !(Item["FOTO2_PRODUTO"].GetValue() == null)  && !(Item["FOTO2_PRODUTO"].GetValue() is System.DBNull))
			{
				MediaHandlerHelper.PrepareMediaHandler((byte[])Item["FOTO2_PRODUTO"].GetValue(), "FOTO2_PRODUTO36032", false, false);
			}
			else
			{
				MediaHandlerHelper.PrepareMediaHandler(null, "FOTO2_PRODUTO36032", false, false);
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_OBS_PRODUTO.Text = Item["OBS_PRODUTO"].GetFormattedValue();
				}
				else
				{
					RadTextBox_OBS_PRODUTO.Text = "";
				}
			}
			catch
			{
				RadTextBox_OBS_PRODUTO.Text = "";
			}
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
					NOME_PRODUTOField = Item["NOME_PRODUTO"].GetFormattedValue();
				}
				else
				{
					NOME_PRODUTOField = "";
				}
			}
			catch
			{
				NOME_PRODUTOField = "";
			}
			try
			{
				if (Item != null)
				{
					VALOR_PRODUTOField = double.Parse(Item["VALOR_PRODUTO"].GetFormattedValue().Replace(".",","));
				}
				else
				{
					VALOR_PRODUTOField = 0;
				}
			}
			catch
			{
				VALOR_PRODUTOField = 0;
			}
			try
			{
				if (Item != null)
				{
					OBS_PRODUTOField = Item["OBS_PRODUTO"].GetFormattedValue();
				}
				else
				{
					OBS_PRODUTOField = "";
				}
			}
			catch
			{
				OBS_PRODUTOField = "";
			}
			try
			{
				if (Item != null)
				{
					ID_PRODUTOField = long.Parse(Item["ID_PRODUTO"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
					ID_PRODUTOField = 0;
				}
			}
			catch
			{
				ID_PRODUTOField = 0;
			}
			PageProvider.AliasVariables.Add("NOME_PRODUTOField", NOME_PRODUTOField);
			PageProvider.AliasVariables.Add("VALOR_PRODUTOField", VALOR_PRODUTOField);
			PageProvider.AliasVariables.Add("OBS_PRODUTOField", OBS_PRODUTOField);
			PageProvider.AliasVariables.Add("ID_PRODUTOField", ID_PRODUTOField);
			PageProvider.AliasVariables.Add("BasePage", this);
        }




		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
	}
}
