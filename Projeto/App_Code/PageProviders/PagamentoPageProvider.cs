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
	public class PagamentoPageProvider : GeneralProvider
	{
		public List<RadComboBoxDataItem> ComboBox1Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem1").ToString(), "Pix"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem2").ToString(), "Cartão"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem3").ToString(), "Dinheiro (Na entrega)"),
				};
			}
		}

		public PagamentoPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DbCupcake_TB_VENDADataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_VENDA", "Pagamento");
			MainProvider.DataProvider.PageProvider = this;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DbCupcake_TB_VENDAItem(MainProvider.DatabaseName);
			}
			return Provider.Item;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
		return "";
		}
		
		public override object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
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
			if(FieldName == "PENDENTE_VENDA")
			{
				return MainProvider.DataProvider.Dao.ToSql(new BooleanField(MainProvider.DataProvider.SelectCommand.BoolFormat,"false").GetFormattedValue(MainProvider.DataProvider.SelectCommand.BoolFormat),FieldType.Boolean);
			}
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
			return (ProviderItem.Errors.Count == 0);
		}
		


	}

}
