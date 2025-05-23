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
	public partial class Pagamento : GeneralDataPage
	{
		protected PagamentoPageProvider PageProvider;
	

		public double TOTAL_VENDAField = 0;
		public string TIPO_PGTO_VENDAField = "";
		public long ID_VENDAField = 0;
		public string LOGIN_USER_LOGINField = "";
		public DateTime ? DATA_VENDAField = null;
		public string OBS_VENDAField = "";
		public string ENTREGA_VENDAField = "";
		public bool PENDENTE_VENDAField = false;
		
		public override string FormID { get { return "36046"; } }
		public override string TableName { get { return "TB_VENDA"; } }
		public override string DatabaseName { get { return "DbCupcake"; } }
		public override string PageName { get { return "Pagamento.aspx"; } }
		public override string ProjectID { get { return "ED2986E"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return false;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return false && InsertValidation(); } }
		public override bool CanDelete { get { return false && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return true; } }
		


		public string VendaId = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(VendaId))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = Dao.PoeColAspas("ID_VENDA") + " = " + Dao.ToSql(VendaId.ToString(), FieldType.Integer, true);
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
			PageProvider = new PagamentoPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			VendaId = HttpContext.Current.Request.QueryString["VendaId"];
			try { if (string.IsNullOrEmpty(VendaId)) VendaId = HttpContext.Current.Session["VendaId"].ToString();} catch {} 
			if (string.IsNullOrEmpty(VendaId)) VendaId = "0";
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
				Item.SetFieldValue(Item["TOTAL_VENDA"], RadTextBox_TOTAL_VENDA.Text, false);
				Item.SetFieldValue(Item["TIPO_PGTO_VENDA"], ComboBox1.SelectedValue);
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
				Item.SetFieldValue(Item["TOTAL_VENDA"], RadTextBox_TOTAL_VENDA.Text, false);
				Item.SetFieldValue(Item["TIPO_PGTO_VENDA"], ComboBox1.SelectedValue);
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
			Utility.SetControlTabOnEnter(ComboBox1);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox_TOTAL_VENDA.Attributes.Add("EnableEdit", "True");
			ComboBox1.Attributes.Add("EnableEdit", "True");
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
			if (ShouldClearFields)
			{
				RadTextBox_TOTAL_VENDA.Text = "";
				ComboBox1.SelectedIndex = -1;
				ComboBox1.Text = "";
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
			base.PageEdit(); 
		}

		public override void ShowFormulas()
		{
			Label_TOTAL_VENDA.Text = Label_TOTAL_VENDA.Text.Replace("<", "&lt;");
			Label_TOTAL_VENDA.Text = Label_TOTAL_VENDA.Text.Replace(">", "&gt;");
			Label2.Text = Label2.Text.Replace("<", "&lt;");
			Label2.Text = Label2.Text.Replace(">", "&gt;");
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
					RadTextBox_TOTAL_VENDA.Text = Item["TOTAL_VENDA"].GetFormattedValue().Replace(".",",");
				}
				else
				{
					RadTextBox_TOTAL_VENDA.Text = "";
				}
			}
			catch
			{
				RadTextBox_TOTAL_VENDA.Text = "";
			}
			try
			{
				string Val = Item["TIPO_PGTO_VENDA"].GetFormattedValue();
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
					TOTAL_VENDAField = double.Parse(Item["TOTAL_VENDA"].GetFormattedValue().Replace(".",","));
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
			PageProvider.AliasVariables.Add("TOTAL_VENDAField", TOTAL_VENDAField);
			PageProvider.AliasVariables.Add("TIPO_PGTO_VENDAField", TIPO_PGTO_VENDAField);
			PageProvider.AliasVariables.Add("ID_VENDAField", ID_VENDAField);
			PageProvider.AliasVariables.Add("LOGIN_USER_LOGINField", LOGIN_USER_LOGINField);
			PageProvider.AliasVariables.Add("DATA_VENDAField", DATA_VENDAField);
			PageProvider.AliasVariables.Add("OBS_VENDAField", OBS_VENDAField);
			PageProvider.AliasVariables.Add("ENTREGA_VENDAField", ENTREGA_VENDAField);
			PageProvider.AliasVariables.Add("PENDENTE_VENDAField", PENDENTE_VENDAField);
			PageProvider.AliasVariables.Add("VendaId", VendaId);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___Form1_OnSaveSucceeded(GeneralDataProviderItem Item)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				string UrlPage = ResolveUrl("~/Pages/sucesso.aspx?vendaId={vendaId}");
				UrlPage = UrlPage.Replace("{vendaId}", (Convert.ToDouble(PageProvider.AliasVariables["VendaId"])).ToString());
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
		protected void ___ComboBox1_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox1Items, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		public override void SaveSucceeded(GeneralDataProviderItem Item)
		{
			___Form1_OnSaveSucceeded(Item);
		}
	}
}
