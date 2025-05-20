using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Security;
using COMPONENTS.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;


namespace PROJETO.DataProviders
{
	/// <summary>
	/// Classe de provider usada para a tabela auxiliar
	/// </summary>
	public class Pag_Cad_VendaPageProvider : GeneralProvider
	{
		public Pag_Cad_Venda_Grid1GridDataProvider Pag_Cad_Venda_Grid1Provider;
		public DbCupcake_TB_LOGIN_USERDataProvider ComboBox_ID_CLIENTEProvider;
		public List<RadComboBoxDataItem> ComboBox1Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem1").ToString(), "1"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem2").ToString(), "2"),
				};
			}
		}

		public Pag_Cad_VendaPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DbCupcake_TB_VENDADataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_VENDA", "Pag_Cad_Venda");
			MainProvider.DataProvider.PageProvider = this;
			ComboBox_ID_CLIENTEProvider = new DbCupcake_TB_LOGIN_USERDataProvider(MainProvider, "TB_LOGIN_USER", "DbCupcake", "", "Pag_Cad_Venda_ComboBox_ID_CLIENTEProviderAlias");
			ComboBox_ID_CLIENTEProvider.PageProvider = this;
			ComboBox_ID_CLIENTEProvider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			Pag_Cad_Venda_Grid1Provider = new Pag_Cad_Venda_Grid1GridDataProvider(this);
			Pag_Cad_Venda_Grid1Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(Pag_Cad_Venda_Grid1Provider_SetRelationFields);
			Pag_Cad_Venda_Grid1Provider.SetRelationParameters += new GeneralGridProvider.SetRelationParametersEventHandler(Pag_Cad_Venda_Grid1Provider_SetRelationParameters);
			Pag_Cad_Venda_Grid1Provider.DataProvider.CreatingParameters += new GeneralDataProvider.CreatingParametersEventHandler(Pag_Cad_Venda_Grid1Provider_CreatingParameters);
			Pag_Cad_Venda_Grid1Provider.DataProvider.CreatingUniqueParameters += new GeneralDataProvider.CreatingUniqueParametersEventHandler(Pag_Cad_Venda_Grid1Provider_CreatingUniqueParameters);
			Pag_Cad_Venda_Grid1Provider.DataProvider.PrepareSelectCountCommands();
		}


		private void Pag_Cad_Venda_Grid1Provider_SetRelationParameters(object sender)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Pag_Cad_Venda_Grid1Provider.DataProvider.Parameters["ID_VENDA"].Parameter.SetValue(MainProvider.DataProvider.Item["ID_VENDA"].Value);
			}
			catch (Exception)
			{
			}
		}

		private void Pag_Cad_Venda_Grid1Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Item.SetFieldValue(Item["ID_VENDA"], MainProvider.DataProvider.Item["ID_VENDA"].Value);
				Pag_Cad_Venda_Grid1Provider.AliasVariables = new Dictionary<string, object>();
				Pag_Cad_Venda_Grid1Provider.AliasVariables.Add("OBS_VENDAField", MainProvider.DataProvider.Item["OBS_VENDA"].Value);
				Pag_Cad_Venda_Grid1Provider.AliasVariables.Add("TOTAL_VENDAField", MainProvider.DataProvider.Item["TOTAL_VENDA"].Value);
				Pag_Cad_Venda_Grid1Provider.AliasVariables.Add("LOGIN_USER_LOGINField", MainProvider.DataProvider.Item["LOGIN_USER_LOGIN"].Value);
				Pag_Cad_Venda_Grid1Provider.AliasVariables.Add("ENTREGA_VENDAField", MainProvider.DataProvider.Item["ENTREGA_VENDA"].Value);
				Pag_Cad_Venda_Grid1Provider.AliasVariables.Add("DATA_VENDAField", MainProvider.DataProvider.Item["DATA_VENDA"].Value);
			}
			catch (Exception)
			{
			}
		}

		void Pag_Cad_Venda_Grid1Provider_CreatingParameters(object sender)
		{
			Pag_Cad_Venda_Grid1Provider.DataProvider.CreateParameter("ID_VENDA");
		}

		void Pag_Cad_Venda_Grid1Provider_CreatingUniqueParameters(object sender)
		{
			Pag_Cad_Venda_Grid1Provider.DataProvider.CreateUniqueParameter();
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DbCupcake_TB_VENDAItem(MainProvider.DatabaseName);
			}
			if (Provider == ComboBox_ID_CLIENTEProvider)
			{
				return new DbCupcake_TB_LOGIN_USERItem(Provider.DataBaseName, "LOGIN_USER_NAME", "LOGIN_USER_LOGIN");
			}
			return Provider.Item;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox_ID_CLIENTEProvider)
			{
			if (Item["LOGIN_USER_NAME"].GetValue() != null)
				{
					return "" + Item["LOGIN_USER_NAME"].GetValue().ToString();
				}
			}
		return "";
		}
		
		public override object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox_ID_CLIENTEProvider)
			{
				if (Item["LOGIN_USER_LOGIN"].GetValue() != null)
				{
					return Item["LOGIN_USER_LOGIN"].GetValue();
				}
				return "";
			}
		return null;
		}

		public override void FillAuxiliarTables()
		{
		}

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_VENDA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "ID_VENDA") });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
		}

		public void ExecuteSingleProcess(string ProcessName)
        {
            CreateProcess(ProcessName, false);
            List<Process> ProcList = new List<Process>(Process.Values);
            if (ProcList.Count > 0)
                DataProcessEntry.ExecuteProcess(ProcList, MainProvider.DataProvider.Dao);
        }
		
		public void CreateProcess(string ProcessName, bool AllProcess)
		{
			CreateProcess(ProcessName, AllProcess, -1);
		}

		public void CreateProcess(string ProcessName, bool AllProcess, int Pos)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			Process = new Dictionary<string, Process>();
			Process.Clear();
			if (MainProvider.DataProvider.PageNumber > 0 && (ProcessName == "Pendente"))
			{
				RawValue = "0";
				ValueField = MainProvider.DataProvider.Dao.ToSql(RawValue.ToString(),FieldType.Boolean);
				RelationField = MainProvider.DataProvider.ProviderFilterExpression();
				Process Pendente= new Process(MainProvider.DataProvider.Dao.PoeColAspas("TB_VENDA"),MainProvider.DataProvider.Dao.PoeColAspas("PENDENTE_VENDA"), ValueField, RelationField,0,false);
				Process.Add("Pendente653239", Pendente);
			}
		}

		public override void CreateReverseProcess(int Pos , string SituationProcess)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			ReverseProcess = new Dictionary<string, Process>();
			ReverseProcess.Clear();
			var situationP = new Dictionary<string, bool>();
		}

		public override void CreateEntries(EntryCommand EntryCommand)
		{   
			Entries = new Dictionary<string, Entry>();
			Entries.Clear();
			if (EntryCommand == EntryCommand.Insert || EntryCommand == EntryCommand.Update)
            {
			}				
			else if (EntryCommand == EntryCommand.Delete)
            {
            }
		}
		
		public override void CreateEntriesItems(Entry Entry,int vgNparc)
		{
			Entry.EntryItems.Clear(); 
			object ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}
		public override GeneralDataProviderItem GetComboItem(GeneralDataProvider Provider, string Value)
		{
			try
			{
				var Dao = Provider.Dao;
				if (Provider == ComboBox_ID_CLIENTEProvider && !string.IsNullOrEmpty(Value))
				{
					try
					{
						Provider.FiltroAtual = Provider.Dao.PoeColAspas("LOGIN_USER_LOGIN") + " = " + Provider.Dao.ToSql(EnvironmentVariable.LoggedLoginUser.ToString(), FieldType.Text, true);
					}
					catch { }
					Provider.FindRecord(new Dictionary<string, object>() { { "LOGIN_USER_LOGIN", Value } });
					return Provider.Item;
				}
			
			}
			catch
			{
			}
			return null;
		}
		
		public bool FillCombo(GeneralDataProvider Provider, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			return FillCombo(Provider, ComboBox, NumberOfItems, TextFilter, AllowFilter, null);
		}
		
		public bool FillCombo(GeneralDataProvider Provider, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter, Dictionary<string, object> ClientFields)
		{
			try
			{
				var Dao = Provider.Dao;
				if (Provider == ComboBox_ID_CLIENTEProvider)
				{
					Provider.ResetParameters();
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter.TrimEnd();
						Provider.FilterFields = "LOGIN_USER_NAME";
					}
					try
					{
						Provider.StartFilter = Provider.Dao.PoeColAspas("LOGIN_USER_LOGIN") + " = " + Provider.Dao.ToSql(EnvironmentVariable.LoggedLoginUser.ToString(), FieldType.Text, true);
					}
					catch { }
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "LOGIN_USER_LOGIN", " LOGIN_USER_NAME", false);
					return Total > 0;
				}
			}
			catch
			{
			}
			return false;
		}
		
		public bool FillCombo(List<RadComboBoxDataItem> ComboBoxDataItem, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			if (AllowFilter && !String.IsNullOrEmpty(TextFilter))
			{
				return Utility.FillComboBoxItems(ComboBox, 15, ComboBoxDataItem.FindAll(c => c.Text.ToLower().Contains(TextFilter.ToLower())));
			}
			return Utility.FillComboBoxItems(ComboBox, 15, ComboBoxDataItem);
		}



		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			bool Accepted = false;
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["DATA_VENDAField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:DatePicker_DATA_VENDA", "DATA_VENDA não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["LOGIN_USER_LOGINField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox_ID_CLIENTE", "Cliente não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["ENTREGA_VENDAField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox1", "Entrega não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		


	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class Pag_Cad_Venda_Grid1GridDataProvider : GeneralGridProvider
	{
		public long ID_PRODUTOField;
		public long QTDE_VENDA_ITEMField;
		public double VALOR_VENDA_ITEMField;
		public long ID_VENDA_ITEMField;
		public long ID_VENDAField;
		
		public DbCupcake_TB_PRODUTODataProvider GridColumn_ID_PRODUTOProvider;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private DbCupcake_TB_VENDA_ITEMDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as DbCupcake_TB_VENDA_ITEMDataProvider;
			}
		}

		public Pag_Cad_VendaPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_VENDA_ITEM"; } }

		public override string DatabaseName { get { return "DbCupcake"; } }

		public override string FormID { get { return "36033"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public Pag_Cad_Venda_Grid1GridDataProvider(Pag_Cad_VendaPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new DbCupcake_TB_VENDA_ITEMDataProvider(this, TableName, DatabaseName, "PK_TB_VENDA_ITEM", "Pag_Cad_Venda_Grid1");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
			GridColumn_ID_PRODUTOProvider = new DbCupcake_TB_PRODUTODataProvider(MainProvider, "TB_PRODUTO", "DbCupcake", "", "Pag_Cad_Venda_GridColumn_ID_PRODUTOProviderAlias");
			GridColumn_ID_PRODUTOProvider.PageProvider = this;
			GridColumn_ID_PRODUTOProvider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
ParentPageProvider.MainProvider.DataProvider.Dao = MainProvider.DataProvider.Dao;
		}
		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == GridColumn_ID_PRODUTOProvider)
			{
				if (Item != null)
				{
					return Provider.Item["NOME_PRODUTO"].GetFormattedValue();
				}
			}
			return "";
		}

		
		public override string GetGridComboText(string GridColumnId, string FieldId)
		{
			if (string.IsNullOrEmpty(FieldId)) return "";
			DataTable dt;
			DataAccessObject Dao;
			Dictionary<string, object> filter;
			switch (GridColumnId)
			{
				case "GridColumn_ID_PRODUTO":
					filter = new Dictionary<string, object>() { { "ID_PRODUTO", FieldId } };
					Dao = Utility.GetDAO("DbCupcake");
					GridColumn_ID_PRODUTOProvider.FindRecord(filter, false);
					if (GridColumn_ID_PRODUTOProvider.PageNumber != 0)
					{
						var retval = "";
						if (GridColumn_ID_PRODUTOProvider.Item["NOME_PRODUTO"].Value != null) retval +=  GridColumn_ID_PRODUTOProvider.Item["NOME_PRODUTO"].Value.ToString();
						return System.Net.WebUtility.HtmlEncode(retval);
					}
					return "";
				default:
					return "";
			}
		}

		public override GeneralDataProviderItem GetComboItem(GeneralDataProvider Provider, string Value)
		{
			try
			{
				var Dao = Provider.Dao;
				if (Provider == GridColumn_ID_PRODUTOProvider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "ID_PRODUTO", Value } });
					return Provider.Item;
				}
			
			}
			catch
			{
			}
			return null;
		}
		
		public bool FillCombo(GeneralDataProvider Provider, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			return FillCombo(Provider, ComboBox, NumberOfItems, TextFilter, AllowFilter, null);
		}
		
		public bool FillCombo(GeneralDataProvider Provider, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter, Dictionary<string, object> ClientFields)
		{
			try
			{
			var Dao = Provider.Dao;
				if (Provider == GridColumn_ID_PRODUTOProvider)
				{
					Provider.ResetParameters();
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter.TrimEnd();
						Provider.FilterFields = "NOME_PRODUTO";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "ID_PRODUTO", " NOME_PRODUTO", false);
					return Total > 0;
				}
			}
			catch
			{
			}
			return false;
		}
		
		public bool FillCombo(List<RadComboBoxDataItem> ComboBoxDataItem, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			if (AllowFilter && !String.IsNullOrEmpty(TextFilter))
			{
				return Utility.FillComboBoxItems(ComboBox, 15, ComboBoxDataItem.FindAll(c => c.Text.ToLower().Contains(TextFilter.ToLower())));
			}
			return Utility.FillComboBoxItems(ComboBox, 15, ComboBoxDataItem);
		}

		public DbCupcake_TB_VENDA_ITEMItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as DbCupcake_TB_VENDA_ITEMItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "Pag_Cad_Venda_Grid1")
			{
				return new DbCupcake_TB_VENDA_ITEMItem(DatabaseName);
			}
			else if (Provider.Name == "Pag_Cad_Venda_GridColumn_ID_PRODUTOProviderAlias")
			{
				return new DbCupcake_TB_PRODUTOItem(MainProvider.DatabaseName, "ID_PRODUTO", "NOME_PRODUTO");
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (Pag_Cad_VendaPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			ID_PRODUTOField = Convert.ToInt64(Item["ID_PRODUTO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ID_PRODUTOField"))
			{
				AliasVariables["ID_PRODUTOField"] = ID_PRODUTOField;
			}
			else
			{
				AliasVariables.Add("ID_PRODUTOField" ,ID_PRODUTOField);
			}
			QTDE_VENDA_ITEMField = Convert.ToInt64(Item["QTDE_VENDA_ITEM"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("QTDE_VENDA_ITEMField"))
			{
				AliasVariables["QTDE_VENDA_ITEMField"] = QTDE_VENDA_ITEMField;
			}
			else
			{
				AliasVariables.Add("QTDE_VENDA_ITEMField" ,QTDE_VENDA_ITEMField);
			}
			try{VALOR_VENDA_ITEMField = Convert.ToDouble(Item["VALOR_VENDA_ITEM"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("VALOR_VENDA_ITEMField"))
			{
				AliasVariables["VALOR_VENDA_ITEMField"] = VALOR_VENDA_ITEMField;
			}
			else
			{
				AliasVariables.Add("VALOR_VENDA_ITEMField" ,VALOR_VENDA_ITEMField);
			}
			ID_VENDA_ITEMField = Convert.ToInt64(Item["ID_VENDA_ITEM"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ID_VENDA_ITEMField"))
			{
				AliasVariables["ID_VENDA_ITEMField"] = ID_VENDA_ITEMField;
			}
			else
			{
				AliasVariables.Add("ID_VENDA_ITEMField" ,ID_VENDA_ITEMField);
			}
			ID_VENDAField = Convert.ToInt64(Item["ID_VENDA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ID_VENDAField"))
			{
				AliasVariables["ID_VENDAField"] = ID_VENDAField;
			}
			else
			{
				AliasVariables.Add("ID_VENDAField" ,ID_VENDAField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_VENDA_ITEM", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "ID_VENDA_ITEM") });
		}

		public override void PositionParentsProvider()
        {
			ParentPageProvider.MainProvider.DataProvider.Dao = MainProvider.DataProvider.Dao;
            ParentPageProvider.MainProvider.DataProvider.SelectItem(ParentPageProvider.MainProvider.DataProvider.PageNumber, FormPositioningEnum.Current);
        }

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
		}

		public void CreateProcess(string ProcessName, bool AllProcess)
		{
			CreateProcess(ProcessName, AllProcess, -1);
		}

		public void CreateProcess(string ProcessName, bool AllProcess, int Pos)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			Process = new Dictionary<string, Process>();
			Process.Clear();
			InitializeAlias(MainProvider.DataProvider.Item);
			if (ParentPageProvider.MainProvider.DataProvider.PageNumber > 0 && (ProcessName == "Total" || (AllProcess && Pos == 0)))
			{
				RawValue = Utility.FixValue<double>(ParentPageProvider.MainProvider.DataProvider.Item["TOTAL_VENDA"].GetValue()) + ( Utility.FixValue<double>(MainProvider.DataProvider.Item["QTDE_VENDA_ITEM"].GetValue()) * Utility.FixValue<double>(MainProvider.DataProvider.Item["VALOR_VENDA_ITEM"].GetValue()) ) ;
				ParentPageProvider.MainProvider.DataProvider.Item["TOTAL_VENDA"].SetValue(RawValue);
				ValueField = ParentPageProvider.MainProvider.DataProvider.Dao.ToSql(ParentPageProvider.MainProvider.DataProvider.Item["TOTAL_VENDA"].GetFormattedValue() ,FieldType.Decimal);
				RelationField = ParentPageProvider.MainProvider.DataProvider.ProviderFilterExpression();
				Process Total= new Process(ParentPageProvider.MainProvider.DataProvider.Dao.PoeColAspas("TB_VENDA"),ParentPageProvider.MainProvider.DataProvider.Dao.PoeColAspas("TOTAL_VENDA"), ValueField, RelationField,0,false);
				Process.Add("Total653193", Total);
			}
		}

		public override void CreateReverseProcess(int Pos, string SituationProcess)
		{
			CreateReverseProcess("", true, Pos, SituationProcess);
		}

		public void CreateReverseProcess(string ProcessName, bool AllProcess, int Pos, string SituationProcess)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			ReverseProcess = new Dictionary<string, Process>();
			ReverseProcess.Clear();
			var situationP = new Dictionary<string, bool>();
			situationP["Insert"] = true;
			situationP["Delete"] = true;
			situationP["Update"] = true;
			if(Pos ==0 && situationP[SituationProcess] )
			{
				RawValue = new DecimalField("",Utility.FixValue<double>(ParentPageProvider.MainProvider.DataProvider.Item["TOTAL_VENDA"].GetValue()) - ( Utility.FixValue<double>(MainProvider.DataProvider.Item["QTDE_VENDA_ITEM"].GetValue()) * Utility.FixValue<double>(MainProvider.DataProvider.Item["VALOR_VENDA_ITEM"].GetValue()) ) ).GetFormattedValue("");
				ParentPageProvider.MainProvider.DataProvider.Item["TOTAL_VENDA"].SetValue(RawValue);
				ValueField = ParentPageProvider.MainProvider.DataProvider.Dao.ToSql(ParentPageProvider.MainProvider.DataProvider.Item["TOTAL_VENDA"].GetFormattedValue() ,FieldType.Decimal);
				RelationField = ParentPageProvider.MainProvider.DataProvider.ProviderFilterExpression();
				Process Total= new Process(ParentPageProvider.MainProvider.DataProvider.Dao.PoeColAspas("TB_VENDA"),ParentPageProvider.MainProvider.DataProvider.Dao.PoeColAspas("TOTAL_VENDA"), ValueField, RelationField,0,false);
				ReverseProcess.Add("Total653193", Total);
			}
		}

		public override void CreateEntries(EntryCommand EntryCommand)
		{   
			Entries = new Dictionary<string, Entry>();
			Entries.Clear();
			if (EntryCommand == EntryCommand.Insert || EntryCommand == EntryCommand.Update)
            {
			}				
			else if (EntryCommand == EntryCommand.Delete)
            {
            }
		}
		
		public override void CreateEntriesItems(Entry Entry,int vgNparc)
		{
			Entry.EntryItems.Clear(); 
			string ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}

	}

}
