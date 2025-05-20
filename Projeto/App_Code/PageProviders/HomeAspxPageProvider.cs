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
	public class HomeAspxPageProvider : GeneralProvider
	{
		public TB_PRODUTORepeaterDataProvider Repeater1RepeaterProvider;

		public HomeAspxPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DbCupcake_TB_PRODUTODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_PRODUTO", "HomeAspx");
			MainProvider.DataProvider.PageProvider = this;
			Repeater1RepeaterProvider = new TB_PRODUTORepeaterDataProvider(this);
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DbCupcake_TB_PRODUTOItem(MainProvider.DatabaseName);
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
			MainProvider.DataProvider.FindRecord("PK_TB_PRODUTO", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "ID_PRODUTO") });
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


		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}
		


	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do Repeater
	/// </summary>
	public class TB_PRODUTORepeaterDataProvider : GeneralListControlProvider
	{
		public long ID_PRODUTOField;
		public string NOME_PRODUTOField;
		public double VALOR_PRODUTOField;
		public string OBS_PRODUTOField;

		#region GeneralDataListProvider Members

		private DbCupcake_TB_PRODUTODataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as DbCupcake_TB_PRODUTODataProvider;
			}
		}

		public HomeAspxPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_PRODUTO"; } }

		public override string DatabaseName { get { return "DbCupcake"; } }

		public override string FormID { get { return "36034"; } }
		
		/// <summary>
		/// Valida se todos os campos do DataList foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public TB_PRODUTORepeaterDataProvider(HomeAspxPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new DbCupcake_TB_PRODUTODataProvider(this, TableName, DatabaseName, "PK_TB_PRODUTO", "TB_PRODUTO");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}

		public DbCupcake_TB_PRODUTOItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as DbCupcake_TB_PRODUTOItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "TB_PRODUTO")
			{
				return new DbCupcake_TB_PRODUTOItem(DatabaseName);
			}
			return null;
		}
		
		public override void SetParametersValues(GeneralDataProvider Provider)
        {
            try
            {
            }
            catch
            {
            }
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
			NOME_PRODUTOField = Convert.ToString(Item["NOME_PRODUTO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOME_PRODUTOField"))
			{
				AliasVariables["NOME_PRODUTOField"] = NOME_PRODUTOField;
			}
			else
			{
				AliasVariables.Add("NOME_PRODUTOField" ,NOME_PRODUTOField);
			}
			VALOR_PRODUTOField = Convert.ToDouble(Item["VALOR_PRODUTO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("VALOR_PRODUTOField"))
			{
				AliasVariables["VALOR_PRODUTOField"] = VALOR_PRODUTOField;
			}
			else
			{
				AliasVariables.Add("VALOR_PRODUTOField" ,VALOR_PRODUTOField);
			}
			OBS_PRODUTOField = Convert.ToString(Item["OBS_PRODUTO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("OBS_PRODUTOField"))
			{
				AliasVariables["OBS_PRODUTOField"] = OBS_PRODUTOField;
			}
			else
			{
				AliasVariables.Add("OBS_PRODUTOField" ,OBS_PRODUTOField);
			}
		}
		
		public override void GetTableIdentity()
		{
		}


}
	}

}
