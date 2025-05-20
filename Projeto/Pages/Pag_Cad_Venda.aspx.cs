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
	public partial class Pag_Cad_Venda : GeneralDataPage
	{
		protected Pag_Cad_VendaPageProvider PageProvider;
	

		public DateTime ? DATA_VENDAField;
		public string LOGIN_USER_LOGINField = "";
		public string OBS_VENDAField = "";
		public string ENTREGA_VENDAField = "";
		public double TOTAL_VENDAField = 0;
		public long ID_VENDAField = 0;
		public bool PENDENTE_VENDAField = false;
		
		public override string FormID { get { return "36033"; } }
		public override string TableName { get { return "TB_VENDA"; } }
		public override string DatabaseName { get { return "DbCupcake"; } }
		public override string PageName { get { return "Pag_Cad_Venda.aspx"; } }
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
				PageProvider.MainProvider.DataProvider.StartFilter = "(" + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " = " + Dao.ToSql(EnvironmentVariable.LoggedLoginUser.ToString(), FieldType.Text, true) + " ) and " + Dao.PoeColAspas("PENDENTE_VENDA") + " = " + Dao.ToSql("true", FieldType.Boolean, true);
			}
			catch
			{
				PageProvider.MainProvider.DataProvider.StartFilter = "1 = 2";
			}
		}
		
		public override void CreateProvider()
		{
			PageProvider = new Pag_Cad_VendaPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}

		public override void GridRebind()
		{
			Grid1.CurrentPageIndex = 0;
			Grid1.DataSource = null;
			Grid1.Rebind();
		}


		protected void Grid1_PreRender(object sender, EventArgs e)
		{
			if (Grid1.MasterTableView.Items.Count == 0)
			{
				if (Grid1.MasterTableView.IsItemInserted == false)
				{
					Grid1.ShowHeader = false;
				}
				else
				{
					Grid1.ShowHeader = true;
				}
			}
			else
			{
				Grid1.ShowHeader = true;
			}
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
			if (HttpContext.Current.Request.UrlReferrer == null)
			{
				HttpContext.Current.Response.Redirect(Utility.StartPageName);  
				return;
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
				if (DatePicker_DATA_VENDA.SelectedDate != null) Item.SetFieldValue(Item["DATA_VENDA"], DatePicker_DATA_VENDA.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["DATA_VENDA"], DBNull.Value);
				Item.SetFieldValue(Item["LOGIN_USER_LOGIN"], ComboBox_ID_CLIENTE.SelectedValue);
				Item.SetFieldValue(Item["OBS_VENDA"], RadTextBox_OBS_VENDA.Text, false);
				Item.SetFieldValue(Item["ENTREGA_VENDA"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["TOTAL_VENDA"], RadTextBox_TOTAL_VENDA.Text, false);
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
				if (DatePicker_DATA_VENDA.SelectedDate != null) Item.SetFieldValue(Item["DATA_VENDA"], DatePicker_DATA_VENDA.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["DATA_VENDA"], DBNull.Value);
				Item.SetFieldValue(Item["LOGIN_USER_LOGIN"], ComboBox_ID_CLIENTE.SelectedValue);
				Item.SetFieldValue(Item["OBS_VENDA"], RadTextBox_OBS_VENDA.Text, false);
				Item.SetFieldValue(Item["ENTREGA_VENDA"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["TOTAL_VENDA"], RadTextBox_TOTAL_VENDA.Text, false);
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
			Utility.SetControlTabOnEnter(ComboBox_ID_CLIENTE);
			Utility.SetControlTabOnEnter(RadTextBox_OBS_VENDA);
			Utility.SetControlTabOnEnter(ComboBox1);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			DatePicker_DATA_VENDA.Enabled = Action;
			ComboBox_ID_CLIENTE.Enabled = Action;
			RadTextBox_OBS_VENDA.Enabled = Action;
			ComboBox1.Enabled = Action;
			RadTextBox_TOTAL_VENDA.Enabled = Action;
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
			if (ShouldClearFields)
			{
				DatePicker_DATA_VENDA.SelectedDate = null;
				ComboBox_ID_CLIENTE.SelectedIndex = -1;
				ComboBox_ID_CLIENTE.Text = "";
				RadTextBox_OBS_VENDA.Text = "";
				ComboBox1.SelectedIndex = -1;
				ComboBox1.Text = "";
				RadTextBox_TOTAL_VENDA.Text = "";
			}
			if (!PageInsert && PageState == FormStateEnum.Navigation)
				DisableEnableContros(false);				
			else
				DisableEnableContros(true);				
		}		

		public override void ShowInitialValues()
		{
			DatePicker_DATA_VENDA.SelectedDate = DateTime.Parse(EnvironmentVariable.ActualDateTime.ToString("dd/MM/yyyy"));
			try
			{
				SelectComboItem(ComboBox_ID_CLIENTE, PageProvider.ComboBox_ID_CLIENTEProvider, EnvironmentVariable.LoggedLoginUser.ToString().ToString());
			}
			catch (Exception e)
			{
				ComboBox_ID_CLIENTE.SelectedValue = "";
				ComboBox_ID_CLIENTE.Text = "";
			}
			try
			{
				ComboBox1.SelectedValue = ("1").ToString();
				ComboBox1.Text = "RETIRAR NA LOJA";
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
			Label_DATA_VENDA.Text = Label_DATA_VENDA.Text.Replace("<", "&lt;");
			Label_DATA_VENDA.Text = Label_DATA_VENDA.Text.Replace(">", "&gt;");
			Label_ID_CLIENTE.Text = Label_ID_CLIENTE.Text.Replace("<", "&lt;");
			Label_ID_CLIENTE.Text = Label_ID_CLIENTE.Text.Replace(">", "&gt;");
			Label_OBS_VENDA.Text = Label_OBS_VENDA.Text.Replace("<", "&lt;");
			Label_OBS_VENDA.Text = Label_OBS_VENDA.Text.Replace(">", "&gt;");
			Label_ENTREGA_VENDA.Text = Label_ENTREGA_VENDA.Text.Replace("<", "&lt;");
			Label_ENTREGA_VENDA.Text = Label_ENTREGA_VENDA.Text.Replace(">", "&gt;");
			Label_TOTAL_VENDA.Text = Label_TOTAL_VENDA.Text.Replace("<", "&lt;");
			Label_TOTAL_VENDA.Text = Label_TOTAL_VENDA.Text.Replace(">", "&gt;");
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
					DatePicker_DATA_VENDA.SelectedDate = Convert.ToDateTime(Item["DATA_VENDA"].GetFormattedValue("dd/MM/yyyy"));
				}
				else
				{
					DatePicker_DATA_VENDA.SelectedDate = null;
				}
			}
			catch
			{
				DatePicker_DATA_VENDA.SelectedDate = null;
			}
			try
			{
				string Val = Item["LOGIN_USER_LOGIN"].GetFormattedValue();
				SelectComboItem(ComboBox_ID_CLIENTE, PageProvider.ComboBox_ID_CLIENTEProvider, Val);
				ComboBox_ID_CLIENTE.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox_ID_CLIENTE.SelectedValue = "";
				ComboBox_ID_CLIENTE.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox_OBS_VENDA.Text = Item["OBS_VENDA"].GetFormattedValue();
				}
				else
				{
					RadTextBox_OBS_VENDA.Text = "";
				}
			}
			catch
			{
				RadTextBox_OBS_VENDA.Text = "";
			}
			try
			{
				string Val = Item["ENTREGA_VENDA"].GetFormattedValue();
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
					DATA_VENDAField = Convert.ToDateTime(Item["DATA_VENDA"].GetFormattedValue("dd/MM/yyyy"));
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
			PageProvider.AliasVariables.Add("DATA_VENDAField", DATA_VENDAField);
			PageProvider.AliasVariables.Add("LOGIN_USER_LOGINField", LOGIN_USER_LOGINField);
			PageProvider.AliasVariables.Add("OBS_VENDAField", OBS_VENDAField);
			PageProvider.AliasVariables.Add("ENTREGA_VENDAField", ENTREGA_VENDAField);
			PageProvider.AliasVariables.Add("TOTAL_VENDAField", TOTAL_VENDAField);
			PageProvider.AliasVariables.Add("ID_VENDAField", ID_VENDAField);
			PageProvider.AliasVariables.Add("PENDENTE_VENDAField", PENDENTE_VENDAField);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___Button13_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				PageProvider.ExecuteSingleProcess("Pendente");
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
		
		/// <summary>
		/// Carrega os objetos de tela para o Item Provider da grid
		/// </summary>
		public override GeneralDataProviderItem LoadItemFromGridControl(bool EnableValidation, string GridId)
		{
			GeneralDataProviderItem Item = null;
			switch (GridId)
			{
				case "Grid1":
					if (PageProvider.Pag_Cad_Venda_Grid1Provider.DataProvider.Item == null)
						Item = PageProvider.Pag_Cad_Venda_Grid1Provider.GetDataProviderItem();
					else
						Item = PageProvider.Pag_Cad_Venda_Grid1Provider.DataProvider.Item;
					PageProvider.Pag_Cad_Venda_Grid1Provider.RaiseSetRelationFields(PageProvider.Pag_Cad_Venda_Grid1Provider, Item);
					Item.SetFieldValue(Item["ID_PRODUTO"], PageProvider.Pag_Cad_Venda_Grid1Provider.GridData["ID_PRODUTO"]);
					Item.SetFieldValue(Item["QTDE_VENDA_ITEM"], PageProvider.Pag_Cad_Venda_Grid1Provider.GridData["QTDE_VENDA_ITEM"]);
					Item.SetFieldValue(Item["VALOR_VENDA_ITEM"], PageProvider.Pag_Cad_Venda_Grid1Provider.GridData["VALOR_VENDA_ITEM"]);
					PageProvider.Pag_Cad_Venda_Grid1Provider.InitializeAlias(Item);
					if (EnableValidation)
					{
						PageProvider.Pag_Cad_Venda_Grid1Provider.Validate(Item);
					}
					break;
			}

			return Item;
		}

		public override void setGridPerm()
		{
			if (!PageOperations.AllowInsert)
			{
				Grid1.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
			}
			if (Grid1.Columns[0] is GridEditCommandColumn && !PageOperations.AllowUpdate)
			{
				Grid1.Columns[0].Visible = false;
			}
			if (Grid1.Columns.Count != 0 && Grid1.Columns[Grid1.Columns.Count - 1] is GridButtonColumn && (Grid1.Columns[Grid1.Columns.Count - 1] as GridButtonColumn).CommandName == "Delete" && !PageOperations.AllowDelete)
			{
				Grid1.Columns[Grid1.Columns.Count - 1].Visible = false;
			}
		}

		protected void Grid1_ItemCreated(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridEditableItem && (e.Item.IsInEditMode))
			{
				if (Grid1.Columns[0].ColumnType == "GridEditCommandColumn" && PageOperations.AllowUpdate)
				{
					if (Grid1.Columns[0].HeaderStyle.Width == 20 && Grid1.Columns[0].Visible == true)
					{
						Grid1.Columns[0].HeaderStyle.Width = 70; 
					}
					else
					{
						Grid1.Columns[0].HeaderStyle.Width = 20; 
					}
				}
				GridEditableItem editableItem = (GridEditableItem)e.Item;
				TextBox txt;
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn_QTDE_VENDA_ITEM") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 44;
				txt.Attributes.Add("class", "GridColumn_QTDE_VENDA_ITEM");
				txt.Attributes.Add("isGrid", "true");
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn_VALOR_VENDA_ITEM") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				txt.Attributes.Add("class", "GridColumn_VALOR_VENDA_ITEM");
				txt.Attributes.Add("isGrid", "true");
				GridItemCreatedFinished(sender, e);
			}
		}
		
		
		private void PrepareCombo(RadComboBox cbo, string FieldTextName, string FieldValueName, GeneralDataProviderItem row, bool AutoCryptDecript)
		{
			if (row != null)
			{
				cbo.SelectedValue = row[FieldValueName].Value.ToString();
				var _text = "";
				var i = 0;
				foreach (var item in FieldTextName.Split('+'))
				{
					var _field = item.Replace("[", "").Replace("]", "").Trim();
					if (i % 2 == 0)
					{
						if (row[_field].Value != null)
						{
							if (!AutoCryptDecript)
								_text += row[_field].Value.ToString();
							else
								_text += Crypt.Decripta(row[_field].Value.ToString());
						}
					}
					else
					{
						_text += _field.Substring(1, 1);
					}
					i++;
				}
				cbo.Text = _text;
			}
			cbo.Attributes.Add("AllowFilter", "False");
		}
		
		
		
		protected void Grid1_ItemDataBound(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridPagerItem)
			{
				GridPagerItem pager = (GridPagerItem)e.Item;
				RadComboBox PageSizeComboBox = (RadComboBox)pager.FindControl("PageSizeComboBox");
				PageSizeComboBox.Visible = false;
				Label ChangePageSizeLabel = (Label)pager.FindControl("ChangePageSizeLabel");
				ChangePageSizeLabel.Visible = false;
			}
			bool ShowFormulas = false;
			
			// ajusta posicionamento da provider da grid de acordo com o registro na nagegação ou edição
			if ((e.Item is GridDataItem || (e.Item is GridEditableItem && e.Item.IsInEditMode)) && !(e.Item is GridDataInsertItem) && !(e.Item is GridEditFormInsertItem))
			{
				Tuple<Hashtable, Hashtable> GridValues = FillGridValues((GridEditableItem)e.Item, sender as RadGrid);
				GetGridProvider(sender as RadGrid).GridData = GridValues.Item2;
				GetGridProvider(sender as RadGrid).GridDataParameters = GridValues.Item2;
				var providerItem = GetGridProvider(sender as RadGrid).DataProvider.SelectItem(false, 0, FormPositioningEnum.Current);
				GetGridProvider((RadGrid)sender).DataProvider.LocateRecord(providerItem, false);
				ShowFormulas = true;
			}
			if (ShowFormulas)
			{
				try
				{
				(e.Item as GridDataItem)["GridColumn2"].Text = (int.Parse(PageProvider.Pag_Cad_Venda_Grid1Provider.DataProvider.Item["QTDE_VENDA_ITEM"].GetFormattedValue()) * double.Parse(PageProvider.Pag_Cad_Venda_Grid1Provider.DataProvider.Item["VALOR_VENDA_ITEM"].GetFormattedValue())).ToString();
					(e.Item as GridDataItem)["GridColumn2"].Text = Mask.ApplyMask((e.Item as GridDataItem)["GridColumn2"].Text, "999.999,00", true);
				}
				catch
				{
					(e.Item as GridDataItem)["GridColumn2"].Text = "";
				}
			}
			if (e.Item.IsInEditMode)
			{
				GridEditableItem item = (GridEditableItem)e.Item;
				if (!(item is IGridInsertItem))
				{
					Utility.SelectGridComboItemByValue(PageProvider.Pag_Cad_Venda_Grid1Provider.GridColumn_ID_PRODUTOProvider, item, "GridColumn_ID_PRODUTO", PageProvider.Pag_Cad_Venda_Grid1Provider.DataProvider.Item["ID_PRODUTO"].Value);
				}
			}
			if (e.Item is GridDataInsertItem && e.Item.OwnerTableView.IsItemInserted)
			{
				GridDataInsertItem insertItem = (GridDataInsertItem)e.Item;
				if (Grid1.Columns.Count > 0 && insertItem[Grid1.Columns[1]].Controls.Count > 0)
				{
					insertItem[Grid1.Columns[1]].Controls[0].Focus();
				}
			}
		}
		private void FillGridComboValues(string GridId, Hashtable newValues, GridTableRow item)
		{
			RadComboBox cbo;
			switch (GridId)
			{
				case "Grid1":
					cbo = (RadComboBox)item.FindControl("GridColumn_ID_PRODUTO_ComboBox");
					newValues["ID_PRODUTO"] = cbo.SelectedValue;
					break;
				}
		}
		
		protected void Grid1_ItemCommand(object source, GridCommandEventArgs e)
		{
			RadGrid Grid = (RadGrid)source;
			if (e.CommandName == RadGrid.InitInsertCommandName)// If insert mode, disallow edit
			{
				Grid.MasterTableView.ClearEditItems();
			}
			if (e.CommandName == RadGrid.FilterCommandName)
			{
				Grid.MasterTableView.ShowHeader = true;
				Grid.ShowGroupPanel = false;
				Grid.ShowFooter = false;
				Grid.ShowStatusBar = false;
			}
			if (e.CommandName == RadGrid.EditCommandName) // If edit mode, disallow insert
			{
				e.Item.OwnerTableView.IsItemInserted = false;
			}
			if (e.CommandName == RadGrid.ExpandCollapseCommandName) // Allow Expand/Collapse one row at a time
			{
				foreach (GridItem item in e.Item.OwnerTableView.Items)
				{
					if (item.Expanded && item != e.Item)
					{
						item.Expanded = false;
					}
				}
			}
			if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName || e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName ||
				e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName || e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
			{
				Grid.AllowPaging = false;
				Grid.ExportSettings.IgnorePaging = true;
				Grid.ExportSettings.OpenInNewWindow = true;
			}
		}

		public override void RefreshOnNavigation()
		{
			Grid1.MasterTableView.ClearEditItems();
			Grid1.MasterTableView.IsItemInserted = false;
		}

		protected void Grid_Init(object sender, EventArgs e)
		{
			RadGrid Grid = (RadGrid)sender;
			GridFilterMenu menu = Grid.FilterMenu;
			int i = 0;
			while (i < menu.Items.Count)
			{
				if (menu.Items[i].Value == "Between" || menu.Items[i].Value == "NotBetween")
				{
					menu.Items.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
		}

		protected void Grid_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
		{
			int TotalRecords = 0;
			string GridFilter = "";
			RadGrid Grid = (RadGrid)source;

			InitializeGridData(Grid);

			
			if (Grid.MasterTableView.SortExpressions.Count > 0)
			{
				string orderBy = "";
				foreach (GridSortExpression sort in Grid.MasterTableView.SortExpressions)
				{
					orderBy += GetGridProvider(Grid).DataProvider.Dao.PoeColAspas(sort.FieldName) + " " + sort.SortOrderAsString() + ", ";
				}
				GetGridProvider(Grid).DataProvider.OrderBy = orderBy.Remove(orderBy.Length - 2);
			}
			Grid.DataSource = GetGridProvider(Grid).DataProvider.SelectItems(Grid.CurrentPageIndex, Grid.PageSize, out TotalRecords);
			Grid.VirtualItemCount = TotalRecords;
		}
		 
		protected void Grid_UpdateCommand(object source, GridCommandEventArgs e)
		{
			var editableItem = (GridEditableItem)e.Item;
			RadGrid Grid = (RadGrid)source;
			Tuple<Hashtable, Hashtable> GridValues = FillGridValues(editableItem, Grid);
			FillGridComboValues(Grid.ID, GridValues.Item1, e.Item);
			GetGridProvider(Grid).UpdateItem(this, Grid.ID, DefineGridInsertValues(Grid.ID, GridValues.Item1), GridValues.Item2);
			 if (GetGridProvider(Grid).PageErrors != null)
            {
                e.Canceled = true;
                PageErrors.Add(GetGridProvider(Grid).PageErrors);
                return;
            }
			Grid.DataSource = null;
            Grid.Rebind();
			PageShow(FormPositioningEnum.Current, true, false, false);
		}

		protected void Grid_InsertCommand(object source, GridCommandEventArgs e)
		{
			var editableItem = (GridEditableItem)e.Item;
			RadGrid Grid = (RadGrid)source;
			Hashtable newValues = new Hashtable();
			e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editableItem);
			FillGridComboValues(Grid.ID, newValues, e.Item);
			GetGridProvider(Grid).InsertItem(this, Grid.ID, DefineGridInsertValues(Grid.ID, newValues));
			if (GetGridProvider(Grid).PageErrors != null)
            {
                e.Canceled = true;
                PageErrors.Add(GetGridProvider(Grid).PageErrors);
                return;
            }
			PageShow(FormPositioningEnum.Current, true, false, false);
		}

		protected void Grid_DeleteCommand(object source, GridCommandEventArgs e)
		{
			RadGrid Grid = (RadGrid)source;
            DeleteGrid(Grid, false, (GridEditableItem)e.Item);
			if (GetGridProvider(Grid).PageErrors != null)
			{
				e.Canceled = true;
				PageErrors.Add(GetGridProvider(Grid).PageErrors);
				return;
			}
			PageShow(FormPositioningEnum.Current, true, false, false);
		}

		public override void DeleteChildItens()
        {
			DeleteGrid(Grid1, true, null);
            base.DeleteChildItens();
        }

		public void DeleteGrid(RadGrid Grid, bool DeleteAllItems, GridEditableItem SingleItem)
        {
			int StartIndex = 0;
            if (!DeleteAllItems) StartIndex = SingleItem.ItemIndex;
            else
            {
                Grid.DataSource = null;
                Grid.CurrentPageIndex = 0;
                Grid.Rebind();
            }
            while (Grid.Items.Count != 0 && PageErrors.Count == 0)
            {
                for (int i = StartIndex; Grid.MasterTableView.Items.Count > i; i++)
                {
                    switch (Grid.ID)
                    {
					}
                    Tuple<Hashtable, Hashtable> GridValues = FillGridValues(Grid.MasterTableView.Items[i], Grid);
                    GetGridProvider(Grid).DeleteItem(this, Grid.ID, GridValues.Item1, GridValues.Item2);
					if(GetGridProvider(Grid).PageErrors != null) PageErrors.Add(GetGridProvider(Grid).PageErrors);
                    if (!DeleteAllItems) break;
                }
				Grid.DataSource = null;
				if (DeleteAllItems) Grid.CurrentPageIndex = 0;
                if (!DeleteAllItems && Grid.Items.Count == 1 && Grid.CurrentPageIndex > 0) Grid.CurrentPageIndex--;
                Grid.Rebind();
				if (!DeleteAllItems) break;
            }
		}

		private Tuple<Hashtable, Hashtable> FillGridValues(GridEditableItem editableItem, RadGrid Grid)
		{
			Hashtable newValues = new Hashtable();
			editableItem.OwnerTableView.ExtractValuesFromItem(newValues, editableItem);
			Hashtable oldValues = newValues.Clone() as Hashtable;
			if (!(editableItem is GridDataInsertItem) && !(editableItem is GridEditFormInsertItem))
			{
				foreach (string key in Grid.MasterTableView.DataKeyNames)
				{
					string FdAlias = (from f in GetGridProvider(Grid).DataProvider.Item.Fields where f.Value.Name == key select f.Key).FirstOrDefault();
					if (!newValues.ContainsKey(key)) newValues.Add(key, editableItem.GetDataKeyValue(key));
					if (!oldValues.ContainsKey(FdAlias))
					{
						oldValues.Add(FdAlias, editableItem.GetDataKeyValue(key));
					}
					else
					{
						oldValues[FdAlias] = editableItem.GetDataKeyValue(key);
					}
				}
			}
			return new Tuple<Hashtable, Hashtable>(newValues, oldValues);
		}
		
		private void InitializeGridData(RadGrid Grid)
		{
			switch (Grid.ID)
			{
				case "Grid1":
					try
					{
						GetGridProvider(Grid).DataProvider.FiltroAtual = Dao.PoeColAspas("ID_VENDA") + " = " + Dao.ToSql(PageProvider.MainProvider.DataProvider.Item["ID_VENDA"].GetFormattedValue(), FieldType.Integer);
					}
					catch
					{
						GetGridProvider(Grid).DataProvider.FiltroAtual = "1 = 2";
					}
					try
					{
						if(GetGridProvider(Grid).DataProvider.FiltroAtual != null && GetGridProvider(Grid).DataProvider.FiltroAtual.Trim().Length > 0)
						{
							GetGridProvider(Grid).DataProvider.FiltroAtual = "(" + GetGridProvider(Grid).DataProvider.FiltroAtual + ") AND (" + Dao.PoeColAspas("ID_VENDA") + " = " + Dao.ToSql(PageProvider.MainProvider.DataProvider.Item["ID_VENDA"].GetFormattedValue(), FieldType.Integer, true) + ")";
						}
						else
						{
							GetGridProvider(Grid).DataProvider.FiltroAtual = Dao.PoeColAspas("ID_VENDA") + " = " + Dao.ToSql(PageProvider.MainProvider.DataProvider.Item["ID_VENDA"].GetFormattedValue(), FieldType.Integer, true);
						}
					}
					catch
					{
						GetGridProvider(Grid).DataProvider.FiltroAtual = "1 = 2";
					}
					Grid.Enabled = true;
					if (PageProvider.MainProvider.DataProvider.Item == null || PageProvider.MainProvider.DataProvider.Item["ID_VENDA"].GetValue() == null)
					{
						Grid.Enabled = false;
					}
					break;
			}
		}
		
		public override GeneralGridProvider GetGridProvider(RadGrid Grid)
		{
			switch (Grid.ID)
			{
				case "Grid1":
					return PageProvider.Pag_Cad_Venda_Grid1Provider;
			}
			return null;
		}
		protected void ___ComboBox_ID_CLIENTE_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox_ID_CLIENTEProvider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox1_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox1Items, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		protected void ___Grid1_GridColumn_ID_PRODUTO_ComboBox_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			RadComboBoxItem item = new RadComboBoxItem("Todos");
			item.Font.Bold = true;
			if (((RadComboBox)sender).ID.EndsWith("Filter")) ((RadComboBox)sender).Items.Add(item);
			e.EndOfItems = PageProvider.Pag_Cad_Venda_Grid1Provider.FillCombo(PageProvider.Pag_Cad_Venda_Grid1Provider.GridColumn_ID_PRODUTOProvider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
	}
}
