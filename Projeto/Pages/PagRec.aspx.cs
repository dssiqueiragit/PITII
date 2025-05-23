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
	public partial class PagRec : GeneralDataPage
	{
		protected PagRecPageProvider PageProvider;
	

		public long ID_CRField = 0;
		public DateTime ? DATA_CRField;
		public string LOGIN_USER_LOGINField = "";
		public string TPGTO_CRField = "";
		public long ID_VENDAField = 0;
		public bool REC_CRField;
		public string VALOR_CRField = "";
		
		public override string FormID { get { return "36036"; } }
		public override string TableName { get { return "TB_CR"; } }
		public override string DatabaseName { get { return "DbCupcake"; } }
		public override string PageName { get { return "PagRec.aspx"; } }
		public override string ProjectID { get { return "ED2986E"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return false;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return false; } }
		



		public override void SetStartFilter()
		{
			try
			{
				PageProvider.MainProvider.DataProvider.StartFilter = Dao.PoeColAspas("LOGIN_USER_LOGIN") + " = " + Dao.ToSql(EnvironmentVariable.LoggedLoginUser.ToString(), FieldType.Text, true);
			}
			catch
			{
				PageProvider.MainProvider.DataProvider.StartFilter = "1 = 2";
			}
		}
		
		public override void CreateProvider()
		{
			PageProvider = new PagRecPageProvider(this);
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
		/// Define os Parâmetros para acesso às tabelas auxiliares
		/// </summary>
		public override void SetParametersValues(GeneralDataProvider Provider)
		{
			try
			{
				if (Provider == PageProvider.AUX_TB_VENDAProvider && Provider.IndexName == "PK_TB_VENDA")
				{
					if (PageProvider.MainProvider.DataProvider.Item != null)
					{
						Provider.Parameters["ID_VENDA"].Parameter.SetValue(Utility.FixValue<double>(PageProvider.MainProvider.DataProvider.Item["ID_VENDA"].GetValue()));
					}
				}
			}
			catch
			{
			}
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
				if (DatePicker_DATA_CR.SelectedDate != null) Item.SetFieldValue(Item["DATA_CR"], DatePicker_DATA_CR.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["DATA_CR"], DBNull.Value);
				Item.SetFieldValue(Item["LOGIN_USER_LOGIN"], ComboBox_LOGIN_USER_LOGIN.SelectedValue);
				Item.SetFieldValue(Item["TPGTO_CR"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["ID_VENDA"], RadTextBox_ID_VENDA.Text, false);
				Item.SetFieldValue(Item["REC_CR"], RadCheckBox_REC_CR.Checked);
				Item.SetFieldValue(Item["VALOR_CR"], RadTextBox_VALOR_CR.Text, false);
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
				if (DatePicker_DATA_CR.SelectedDate != null) Item.SetFieldValue(Item["DATA_CR"], DatePicker_DATA_CR.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["DATA_CR"], DBNull.Value);
				Item.SetFieldValue(Item["LOGIN_USER_LOGIN"], ComboBox_LOGIN_USER_LOGIN.SelectedValue);
				Item.SetFieldValue(Item["TPGTO_CR"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["ID_VENDA"], RadTextBox_ID_VENDA.Text, false);
				Item.SetFieldValue(Item["REC_CR"], RadCheckBox_REC_CR.Checked);
				Item.SetFieldValue(Item["VALOR_CR"], RadTextBox_VALOR_CR.Text, false);
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
			Utility.SetControlTabOnEnter(ComboBox_LOGIN_USER_LOGIN);
			Utility.SetControlTabOnEnter(ComboBox1);
			Utility.SetControlTabOnEnter(RadCheckBox_REC_CR);
			Utility.SetControlTabOnEnter(RadTextBox_VALOR_CR);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox_ID_CR.Enabled = Action;
			DatePicker_DATA_CR.Enabled = Action;
			ComboBox_LOGIN_USER_LOGIN.Enabled = Action;
			ComboBox1.Enabled = Action;
			RadTextBox_ID_VENDA.Enabled = Action;
			RadCheckBox_REC_CR.Enabled = Action;
			RadTextBox_VALOR_CR.Enabled = Action;
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
				RadTextBox_ID_CR.Text = "";
			if (ShouldClearFields)
			{
				DatePicker_DATA_CR.SelectedDate = null;
				ComboBox_LOGIN_USER_LOGIN.SelectedIndex = -1;
				ComboBox_LOGIN_USER_LOGIN.Text = "";
				ComboBox1.SelectedIndex = -1;
				ComboBox1.Text = "";
				RadTextBox_ID_VENDA.Text = "";
				RadCheckBox_REC_CR.Checked = false;
				RadTextBox_VALOR_CR.Text = "";
			}
			if (!PageInsert && PageState == FormStateEnum.Navigation)
				DisableEnableContros(false);				
			else
				DisableEnableContros(true);				
		}		

		public override void ShowInitialValues()
		{
			DatePicker_DATA_CR.SelectedDate = DateTime.Parse(EnvironmentVariable.ActualDateTime.ToString("dd/MM/yyyy"));
			try
			{
				SelectComboItem(ComboBox_LOGIN_USER_LOGIN, PageProvider.ComboBox_LOGIN_USER_LOGINProvider, EnvironmentVariable.LoggedLoginUser.ToString().ToString());
			}
			catch (Exception e)
			{
				ComboBox_LOGIN_USER_LOGIN.SelectedValue = "";
				ComboBox_LOGIN_USER_LOGIN.Text = "";
			}
			try
			{
				ComboBox1.SelectedValue = ("2").ToString();
				ComboBox1.Text = "PIX";
			}
			catch (Exception e)
			{
				ComboBox1.SelectedValue = "";
				ComboBox1.Text = "";
			}
		}

		public override void PageEdit()
		{
			DisableEnableContros(true); 
			base.PageEdit(); 
		}

		public override void ShowFormulas()
		{
			Label_ID_CR.Text = Label_ID_CR.Text.Replace("<", "&lt;");
			Label_ID_CR.Text = Label_ID_CR.Text.Replace(">", "&gt;");
			Label_DATA_CR.Text = Label_DATA_CR.Text.Replace("<", "&lt;");
			Label_DATA_CR.Text = Label_DATA_CR.Text.Replace(">", "&gt;");
			Label_LOGIN_USER_LOGIN.Text = Label_LOGIN_USER_LOGIN.Text.Replace("<", "&lt;");
			Label_LOGIN_USER_LOGIN.Text = Label_LOGIN_USER_LOGIN.Text.Replace(">", "&gt;");
			Label_TPGTO_CR.Text = Label_TPGTO_CR.Text.Replace("<", "&lt;");
			Label_TPGTO_CR.Text = Label_TPGTO_CR.Text.Replace(">", "&gt;");
			Label_ID_VENDA.Text = Label_ID_VENDA.Text.Replace("<", "&lt;");
			Label_ID_VENDA.Text = Label_ID_VENDA.Text.Replace(">", "&gt;");
			Label_REC_CR.Text = Label_REC_CR.Text.Replace("<", "&lt;");
			Label_REC_CR.Text = Label_REC_CR.Text.Replace(">", "&gt;");
			Label_VALOR_CR.Text = Label_VALOR_CR.Text.Replace("<", "&lt;");
			Label_VALOR_CR.Text = Label_VALOR_CR.Text.Replace(">", "&gt;");
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
					RadTextBox_ID_CR.Text = Item["ID_CR"].GetFormattedValue();
				}
				else
				{
					RadTextBox_ID_CR.Text = "";
				}
			}
			catch
			{
				RadTextBox_ID_CR.Text = "";
			}
			try
			{
				if (Item != null)
				{
					DatePicker_DATA_CR.SelectedDate = Convert.ToDateTime(Item["DATA_CR"].GetFormattedValue("dd/MM/yyyy"));
				}
				else
				{
					DatePicker_DATA_CR.SelectedDate = null;
				}
			}
			catch
			{
				DatePicker_DATA_CR.SelectedDate = null;
			}
			try
			{
				string Val = Item["LOGIN_USER_LOGIN"].GetFormattedValue();
				SelectComboItem(ComboBox_LOGIN_USER_LOGIN, PageProvider.ComboBox_LOGIN_USER_LOGINProvider, Val);
				ComboBox_LOGIN_USER_LOGIN.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox_LOGIN_USER_LOGIN.SelectedValue = "";
				ComboBox_LOGIN_USER_LOGIN.Text = "";
			}
			try
			{
				string Val = Item["TPGTO_CR"].GetFormattedValue();
				RadComboBoxDataItem ComboBox1item = Utility.FindComboBoxItem(PageProvider.ComboBox1Items, Val);
				ComboBox1.Text = ComboBox1item.Text;
				ComboBox1.SelectedValue = ComboBox1item.Value;
				ComboBox1.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox1.SelectedValue = "";
				ComboBox1.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_ID_VENDA.Text = Item["ID_VENDA"].GetFormattedValue();
				}
				else
				{
					RadTextBox_ID_VENDA.Text = "";
				}
			}
			catch
			{
				RadTextBox_ID_VENDA.Text = "";
			}
			try
			{
				RadCheckBox_REC_CR.Attributes.Add("OnClick","InitiateEditAuto();");
				RadCheckBox_REC_CR.Checked = (Item["REC_CR"].Value != null && Convert.ToBoolean(Item["REC_CR"].Value));
			}
			catch { RadCheckBox_REC_CR.Checked = false;}
			try
			{
				if (Item != null)
				{
					RadTextBox_VALOR_CR.Text = Item["VALOR_CR"].GetFormattedValue();
				}
				else
				{
					RadTextBox_VALOR_CR.Text = "";
				}
			}
			catch
			{
				RadTextBox_VALOR_CR.Text = "";
			}
			InitializePageContent();
			base.DefinePageContent(Item);
		}
		private void SelectComboItem(RadComboBox Combo, GeneralDataProvider Provider, string Value)
        {
			if (Combo.Items.Count == 0 && !string.IsNullOrEmpty(Value))
			{
				GeneralDataProviderItem item = PageProvider.GetComboItem(Provider, Value);
				if (item != null)
				{
					Combo.Text = PageProvider.GetItemText(Provider, item);
					Combo.SelectedValue = PageProvider.GetItemValue(Provider, item).ToString();
					Combo.Attributes.Add("AllowFilter", "False");
					return;
				}
			}
			Combo.Text = null;
			Combo.SelectedValue = null;
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
					ID_CRField = long.Parse(Item["ID_CR"].GetFormattedValue());
				}
				else
				{
					ID_CRField = 0;
				}
			}
			catch
			{
				ID_CRField = 0;
			}
			try
			{
				if (Item != null)
				{
					DATA_CRField = Convert.ToDateTime(Item["DATA_CR"].GetFormattedValue("dd/MM/yyyy"));
				}
				else
				{
					DATA_CRField = null;
				}
			}
			catch
			{
				DATA_CRField = null;
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
					TPGTO_CRField = Item["TPGTO_CR"].GetFormattedValue();
				}
				else
				{
					TPGTO_CRField = "";
				}
			}
			catch
			{
				TPGTO_CRField = "";
			}
			try
			{
				if (Item != null)
				{
					ID_VENDAField = long.Parse(Item["ID_VENDA"].GetFormattedValue());
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
					REC_CRField = Convert.ToBoolean(Item["REC_CR"].Value);
				}
				else
				{
					REC_CRField = false;
				}
			}
			catch
			{
				REC_CRField = false;
			}
			try
			{
				if (Item != null)
				{
					VALOR_CRField = Item["VALOR_CR"].GetFormattedValue();
				}
				else
				{
					VALOR_CRField = "";
				}
			}
			catch
			{
				VALOR_CRField = "";
			}
			PageProvider.AliasVariables.Add("ID_CRField", ID_CRField);
			PageProvider.AliasVariables.Add("DATA_CRField", DATA_CRField);
			PageProvider.AliasVariables.Add("LOGIN_USER_LOGINField", LOGIN_USER_LOGINField);
			PageProvider.AliasVariables.Add("TPGTO_CRField", TPGTO_CRField);
			PageProvider.AliasVariables.Add("ID_VENDAField", ID_VENDAField);
			PageProvider.AliasVariables.Add("REC_CRField", REC_CRField);
			PageProvider.AliasVariables.Add("VALOR_CRField", VALOR_CRField);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___Button11_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				PageProvider.ExecuteSingleProcess("Recebido");
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
			bool ActionSucceeded_2 = true;
			try
			{
				PageProvider.ExecuteSingleProcess("Pendente");
			}
			catch (Exception ex)
			{
				ActionSucceeded_2 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}




		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
		protected void ___ComboBox_LOGIN_USER_LOGIN_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox_LOGIN_USER_LOGINProvider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox1_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox1Items, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
	}
}
