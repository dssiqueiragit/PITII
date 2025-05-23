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
	public partial class TB_LOGIN_USER1 : GeneralDataPage
	{
		protected TB_LOGIN_USER1PageProvider PageProvider;
	

		public string LOGIN_USER_LOGINField = "";
		public string LOGIN_USER_PASSWORDField = "";
		public string LOGIN_USER_NAMEField = "";
		public string LOGIN_USER_ENDERECOField = "";
		public string LOGIN_USER_NUMField = "";
		public string LOGIN_USER_COMPLField = "";
		public string LOGIN_USER_BAIRROField = "";
		public string LOGIN_USER_CIDADEField = "";
		public string LOGIN_USER_CEPField = "";
		public string LOGIN_USER_EMAILField = "";
		public string LOGIN_USER_CELField = "";
		public string LOGIN_USER_OBSField = "";
		public string LOGIN_GROUP_NAMEField = "";
		
		public override string FormID { get { return "36044"; } }
		public override string TableName { get { return "TB_LOGIN_USER"; } }
		public override string DatabaseName { get { return "DbCupcake"; } }
		public override string PageName { get { return "TB_LOGIN_USER1.aspx"; } }
		public override string ProjectID { get { return "ED2986E"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return true;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return true; } }
		



		public override bool AuthenticationRequired { get { return false; } }
		public override void SetStartFilter()
		{
			try
			{
				PageProvider.MainProvider.DataProvider.StartFilter = "1=2";
			}
			catch
			{
				PageProvider.MainProvider.DataProvider.StartFilter = "1 = 2";
			}
		}
		
		public override void CreateProvider()
		{
			PageProvider = new TB_LOGIN_USER1PageProvider(this);
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
				Item.SetFieldValue(Item["LOGIN_USER_LOGIN"], RadTextBox_LOGIN_USER_LOGIN.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_PASSWORD"], txtLoginPassword.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_NAME"], RadTextBox_LOGIN_USER_NAME.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_ENDERECO"], RadTextBox_LOGIN_USER_ENDERECO.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_NUM"], RadTextBox_LOGIN_USER_NUM.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_COMPL"], RadTextBox_LOGIN_USER_COMPL.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_BAIRRO"], RadTextBox_LOGIN_USER_BAIRRO.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_CIDADE"], RadTextBox_LOGIN_USER_CIDADE.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_CEP"], RadTextBox_LOGIN_USER_CEP.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_EMAIL"], RadTextBox_LOGIN_USER_EMAIL.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_CEL"], RadTextBox_LOGIN_USER_CEL.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_OBS"], RadTextBox_LOGIN_USER_OBS.Text, false);
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
				Item.SetFieldValue(Item["LOGIN_USER_LOGIN"], RadTextBox_LOGIN_USER_LOGIN.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_PASSWORD"], txtLoginPassword.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_NAME"], RadTextBox_LOGIN_USER_NAME.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_ENDERECO"], RadTextBox_LOGIN_USER_ENDERECO.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_NUM"], RadTextBox_LOGIN_USER_NUM.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_COMPL"], RadTextBox_LOGIN_USER_COMPL.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_BAIRRO"], RadTextBox_LOGIN_USER_BAIRRO.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_CIDADE"], RadTextBox_LOGIN_USER_CIDADE.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_CEP"], RadTextBox_LOGIN_USER_CEP.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_EMAIL"], RadTextBox_LOGIN_USER_EMAIL.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_CEL"], RadTextBox_LOGIN_USER_CEL.Text, false);
				Item.SetFieldValue(Item["LOGIN_USER_OBS"], RadTextBox_LOGIN_USER_OBS.Text, false);
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
			Utility.SetControlTabOnEnter(RadTextBox_LOGIN_USER_ENDERECO);
			Utility.SetControlTabOnEnter(RadTextBox_LOGIN_USER_NUM);
			Utility.SetControlTabOnEnter(RadTextBox_LOGIN_USER_COMPL);
			Utility.SetControlTabOnEnter(RadTextBox_LOGIN_USER_BAIRRO);
			Utility.SetControlTabOnEnter(RadTextBox_LOGIN_USER_CIDADE);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox_LOGIN_USER_LOGIN.Enabled = Action;
			txtLoginPassword.Enabled = Action;
			RadTextBox_LOGIN_USER_NAME.Enabled = Action;
			RadTextBox_LOGIN_USER_ENDERECO.Enabled = Action;
			RadTextBox_LOGIN_USER_NUM.Enabled = Action;
			RadTextBox_LOGIN_USER_COMPL.Enabled = Action;
			RadTextBox_LOGIN_USER_BAIRRO.Enabled = Action;
			RadTextBox_LOGIN_USER_CIDADE.Enabled = Action;
			RadTextBox_LOGIN_USER_CEP.Enabled = Action;
			RadTextBox_LOGIN_USER_EMAIL.Enabled = Action;
			RadTextBox_LOGIN_USER_CEL.Enabled = Action;
			RadTextBox_LOGIN_USER_OBS.Enabled = Action;
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
				RadTextBox_LOGIN_USER_LOGIN.Text = "";
				txtLoginPassword.Attributes["Value"] = "";
				RadTextBox_LOGIN_USER_NAME.Text = "";
				RadTextBox_LOGIN_USER_ENDERECO.Text = "";
				RadTextBox_LOGIN_USER_NUM.Text = "";
				RadTextBox_LOGIN_USER_COMPL.Text = "";
				RadTextBox_LOGIN_USER_BAIRRO.Text = "";
				RadTextBox_LOGIN_USER_CIDADE.Text = "";
				RadTextBox_LOGIN_USER_CEP.Text = "";
				RadTextBox_LOGIN_USER_EMAIL.Text = "";
				RadTextBox_LOGIN_USER_CEL.Text = "";
			if (ShouldClearFields)
			{
				RadTextBox_LOGIN_USER_OBS.Text = "";
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
			Label_LOGIN_USER_LOGIN.Text = Label_LOGIN_USER_LOGIN.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_LOGIN.Text = Label_LOGIN_USER_LOGIN.Text.Replace(">", "&gt;");
			Label_LOGIN_USER_PASSWORD.Text = Label_LOGIN_USER_PASSWORD.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_PASSWORD.Text = Label_LOGIN_USER_PASSWORD.Text.Replace(">", "&gt;");
			Label_LOGIN_USER_NAME.Text = Label_LOGIN_USER_NAME.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_NAME.Text = Label_LOGIN_USER_NAME.Text.Replace(">", "&gt;");
			Label_LOGIN_USER_ENDERECO.Text = Label_LOGIN_USER_ENDERECO.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_ENDERECO.Text = Label_LOGIN_USER_ENDERECO.Text.Replace(">", "&gt;");
			Label_LOGIN_USER_NUM.Text = Label_LOGIN_USER_NUM.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_NUM.Text = Label_LOGIN_USER_NUM.Text.Replace(">", "&gt;");
			Label_LOGIN_USER_COMPL.Text = Label_LOGIN_USER_COMPL.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_COMPL.Text = Label_LOGIN_USER_COMPL.Text.Replace(">", "&gt;");
			Label_LOGIN_USER_BAIRRO.Text = Label_LOGIN_USER_BAIRRO.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_BAIRRO.Text = Label_LOGIN_USER_BAIRRO.Text.Replace(">", "&gt;");
			Label_LOGIN_USER_CIDADE.Text = Label_LOGIN_USER_CIDADE.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_CIDADE.Text = Label_LOGIN_USER_CIDADE.Text.Replace(">", "&gt;");
			Label_LOGIN_USER_CEP.Text = Label_LOGIN_USER_CEP.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_CEP.Text = Label_LOGIN_USER_CEP.Text.Replace(">", "&gt;");
			Label_LOGIN_USER_EMAIL.Text = Label_LOGIN_USER_EMAIL.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_EMAIL.Text = Label_LOGIN_USER_EMAIL.Text.Replace(">", "&gt;");
			Label_LOGIN_USER_CEL.Text = Label_LOGIN_USER_CEL.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_CEL.Text = Label_LOGIN_USER_CEL.Text.Replace(">", "&gt;");
			Label_LOGIN_USER_OBS.Text = Label_LOGIN_USER_OBS.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_OBS.Text = Label_LOGIN_USER_OBS.Text.Replace(">", "&gt;");
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
					RadTextBox_LOGIN_USER_LOGIN.Text = Item["LOGIN_USER_LOGIN"].GetFormattedValue();
				}
				else
				{
					RadTextBox_LOGIN_USER_LOGIN.Text = "";
				}
			}
			catch
			{
				RadTextBox_LOGIN_USER_LOGIN.Text = "";
			}
			try
			{
				if (Item != null)
				{
					txtLoginPassword.Attributes["value"] = Item["LOGIN_USER_PASSWORD"].GetFormattedValue();
				}
				else
				{
					txtLoginPassword.Attributes["value"] = "";
				}
			}
			catch
			{
				txtLoginPassword.Attributes["value"] = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_LOGIN_USER_NAME.Text = Item["LOGIN_USER_NAME"].GetFormattedValue();
				}
				else
				{
					RadTextBox_LOGIN_USER_NAME.Text = "";
				}
			}
			catch
			{
				RadTextBox_LOGIN_USER_NAME.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_LOGIN_USER_ENDERECO.Text = Item["LOGIN_USER_ENDERECO"].GetFormattedValue();
				}
				else
				{
					RadTextBox_LOGIN_USER_ENDERECO.Text = "";
				}
			}
			catch
			{
				RadTextBox_LOGIN_USER_ENDERECO.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_LOGIN_USER_NUM.Text = Item["LOGIN_USER_NUM"].GetFormattedValue();
				}
				else
				{
					RadTextBox_LOGIN_USER_NUM.Text = "";
				}
			}
			catch
			{
				RadTextBox_LOGIN_USER_NUM.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_LOGIN_USER_COMPL.Text = Item["LOGIN_USER_COMPL"].GetFormattedValue();
				}
				else
				{
					RadTextBox_LOGIN_USER_COMPL.Text = "";
				}
			}
			catch
			{
				RadTextBox_LOGIN_USER_COMPL.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_LOGIN_USER_BAIRRO.Text = Item["LOGIN_USER_BAIRRO"].GetFormattedValue();
				}
				else
				{
					RadTextBox_LOGIN_USER_BAIRRO.Text = "";
				}
			}
			catch
			{
				RadTextBox_LOGIN_USER_BAIRRO.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_LOGIN_USER_CIDADE.Text = Item["LOGIN_USER_CIDADE"].GetFormattedValue();
				}
				else
				{
					RadTextBox_LOGIN_USER_CIDADE.Text = "";
				}
			}
			catch
			{
				RadTextBox_LOGIN_USER_CIDADE.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_LOGIN_USER_CEP.Text = Item["LOGIN_USER_CEP"].GetFormattedValue();
				}
				else
				{
					RadTextBox_LOGIN_USER_CEP.Text = "";
				}
			}
			catch
			{
				RadTextBox_LOGIN_USER_CEP.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_LOGIN_USER_EMAIL.Text = Item["LOGIN_USER_EMAIL"].GetFormattedValue();
				}
				else
				{
					RadTextBox_LOGIN_USER_EMAIL.Text = "";
				}
			}
			catch
			{
				RadTextBox_LOGIN_USER_EMAIL.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_LOGIN_USER_CEL.Text = Item["LOGIN_USER_CEL"].GetFormattedValue();
				}
				else
				{
					RadTextBox_LOGIN_USER_CEL.Text = "";
				}
			}
			catch
			{
				RadTextBox_LOGIN_USER_CEL.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_LOGIN_USER_OBS.Text = Item["LOGIN_USER_OBS"].GetFormattedValue();
				}
				else
				{
					RadTextBox_LOGIN_USER_OBS.Text = "";
				}
			}
			catch
			{
				RadTextBox_LOGIN_USER_OBS.Text = "";
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
					LOGIN_USER_PASSWORDField = Item["LOGIN_USER_PASSWORD"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_PASSWORDField = "";
				}
			}
			catch
			{
				LOGIN_USER_PASSWORDField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_NAMEField = Item["LOGIN_USER_NAME"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_NAMEField = "";
				}
			}
			catch
			{
				LOGIN_USER_NAMEField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_ENDERECOField = Item["LOGIN_USER_ENDERECO"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_ENDERECOField = "";
				}
			}
			catch
			{
				LOGIN_USER_ENDERECOField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_NUMField = Item["LOGIN_USER_NUM"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_NUMField = "";
				}
			}
			catch
			{
				LOGIN_USER_NUMField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_COMPLField = Item["LOGIN_USER_COMPL"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_COMPLField = "";
				}
			}
			catch
			{
				LOGIN_USER_COMPLField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_BAIRROField = Item["LOGIN_USER_BAIRRO"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_BAIRROField = "";
				}
			}
			catch
			{
				LOGIN_USER_BAIRROField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_CIDADEField = Item["LOGIN_USER_CIDADE"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_CIDADEField = "";
				}
			}
			catch
			{
				LOGIN_USER_CIDADEField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_CEPField = Item["LOGIN_USER_CEP"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_CEPField = "";
				}
			}
			catch
			{
				LOGIN_USER_CEPField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_EMAILField = Item["LOGIN_USER_EMAIL"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_EMAILField = "";
				}
			}
			catch
			{
				LOGIN_USER_EMAILField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_CELField = Item["LOGIN_USER_CEL"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_CELField = "";
				}
			}
			catch
			{
				LOGIN_USER_CELField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_OBSField = Item["LOGIN_USER_OBS"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_OBSField = "";
				}
			}
			catch
			{
				LOGIN_USER_OBSField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_GROUP_NAMEField = Item["LOGIN_GROUP_NAME"].GetFormattedValue();
				}
				else
				{
					LOGIN_GROUP_NAMEField = "";
				}
			}
			catch
			{
				LOGIN_GROUP_NAMEField = "";
			}
			PageProvider.AliasVariables.Add("LOGIN_USER_LOGINField", LOGIN_USER_LOGINField);
			PageProvider.AliasVariables.Add("LOGIN_USER_PASSWORDField", LOGIN_USER_PASSWORDField);
			PageProvider.AliasVariables.Add("LOGIN_USER_NAMEField", LOGIN_USER_NAMEField);
			PageProvider.AliasVariables.Add("LOGIN_USER_ENDERECOField", LOGIN_USER_ENDERECOField);
			PageProvider.AliasVariables.Add("LOGIN_USER_NUMField", LOGIN_USER_NUMField);
			PageProvider.AliasVariables.Add("LOGIN_USER_COMPLField", LOGIN_USER_COMPLField);
			PageProvider.AliasVariables.Add("LOGIN_USER_BAIRROField", LOGIN_USER_BAIRROField);
			PageProvider.AliasVariables.Add("LOGIN_USER_CIDADEField", LOGIN_USER_CIDADEField);
			PageProvider.AliasVariables.Add("LOGIN_USER_CEPField", LOGIN_USER_CEPField);
			PageProvider.AliasVariables.Add("LOGIN_USER_EMAILField", LOGIN_USER_EMAILField);
			PageProvider.AliasVariables.Add("LOGIN_USER_CELField", LOGIN_USER_CELField);
			PageProvider.AliasVariables.Add("LOGIN_USER_OBSField", LOGIN_USER_OBSField);
			PageProvider.AliasVariables.Add("LOGIN_GROUP_NAMEField", LOGIN_GROUP_NAMEField);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___Form1_OnSaveSucceeded(GeneralDataProviderItem Item)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				string UrlPage = ResolveUrl("~/Login");
				try
				{
					if (!IsPostBack)
					{
						ClientScript.RegisterStartupScript(this.GetType(), "OnSaveSucceeded_Browser", "<script>NavigateBrowser('" + UrlPage + "');</script>");
					}
					else
					{
						AjaxPanel.ResponseScripts.Add("NavigateBrowser('" + UrlPage + "');");
					}
				}
				catch(Exception ex)
				{
				}
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}




		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
		public override void SaveSucceeded(GeneralDataProviderItem Item)
		{
			___Form1_OnSaveSucceeded(Item);
		}
	}
}
