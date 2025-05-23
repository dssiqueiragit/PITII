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
	public class PagRecPageProvider : GeneralProvider
	{
		public DbCupcake_TB_VENDADataProvider AUX_TB_VENDAProvider;
		public DbCupcake_TB_LOGIN_USERDataProvider ComboBox_LOGIN_USER_LOGINProvider;
		public List<RadComboBoxDataItem> ComboBox1Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem1").ToString(), "1"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem2").ToString(), "2"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem3").ToString(), "3"),
				};
			}
		}

		public PagRecPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DbCupcake_TB_CRDataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_CR", "PagRec");
			MainProvider.DataProvider.PageProvider = this;
			AUX_TB_VENDAProvider = new DbCupcake_TB_VENDADataProvider(MainProvider, "TB_VENDA", "DbCupcake", "PK_TB_VENDA", "AUX_TB_VENDA");
			ComboBox_LOGIN_USER_LOGINProvider = new DbCupcake_TB_LOGIN_USERDataProvider(MainProvider, "TB_LOGIN_USER", "DbCupcake", "", "PagRec_ComboBox_LOGIN_USER_LOGINProviderAlias");
			ComboBox_LOGIN_USER_LOGINProvider.PageProvider = this;
			ComboBox_LOGIN_USER_LOGINProvider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DbCupcake_TB_CRItem(MainProvider.DatabaseName);
			}
			else if (Provider.Name == "AUX_TB_VENDA")
			{
				return new DbCupcake_TB_VENDAItem("DbCupcakeSystem.Collections.ObjectModel.ObservableCollection`1[GAS.TableField]");
			}
			if (Provider == ComboBox_LOGIN_USER_LOGINProvider)
			{
				return new DbCupcake_TB_LOGIN_USERItem(Provider.DataBaseName, "LOGIN_USER_NAME", "LOGIN_USER_LOGIN");
			}
			return Provider.Item;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox_LOGIN_USER_LOGINProvider)
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
			if (Provider == ComboBox_LOGIN_USER_LOGINProvider)
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
			MainProvider.SetParametersValues(AUX_TB_VENDAProvider);
			AUX_TB_VENDAProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_TB_VENDAProvider.SelectItem(1, FormPositioningEnum.First,true);
		}

		public override int GetMaxProcessLanc()
		{
			return 2;
		}
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_CR", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "ID_CR") });
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
			if (MainProvider.DataProvider.PageNumber > 0 && (ProcessName == "Recebido"))
			{
				RawValue = "1";
				ValueField = MainProvider.DataProvider.Dao.ToSql(RawValue.ToString(),FieldType.Boolean);
				RelationField = MainProvider.DataProvider.ProviderFilterExpression();
				Process Recebido= new Process(MainProvider.DataProvider.Dao.PoeColAspas("TB_CR"),MainProvider.DataProvider.Dao.PoeColAspas("REC_CR"), ValueField, RelationField,0,false);
				Process.Add("Recebido653220", Recebido);
			}
			if (AUX_TB_VENDAProvider.PageNumber > 0 && (ProcessName == "Pendente"))
			{
				RawValue = "0";
				ValueField = AUX_TB_VENDAProvider.Dao.ToSql(RawValue.ToString(),FieldType.Boolean);
				RelationField = AUX_TB_VENDAProvider.ProviderFilterExpression();
				Process Pendente= new Process(AUX_TB_VENDAProvider.Dao.PoeColAspas("TB_VENDA"),AUX_TB_VENDAProvider.Dao.PoeColAspas("PENDENTE_VENDA"), ValueField, RelationField,1,false);
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
				if (Provider == ComboBox_LOGIN_USER_LOGINProvider && !string.IsNullOrEmpty(Value))
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
				if (Provider == ComboBox_LOGIN_USER_LOGINProvider)
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["DATA_CRField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:DatePicker_DATA_CR", "Data não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		


	}

}
