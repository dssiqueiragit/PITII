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

namespace PROJETO.DataProviders
{
	/// <summary>
	/// Classe de provider usada para a tabela auxiliar
	/// </summary>
	public class TB_VENDAProcessProvider: GeneralProvider
	{
		public DbCupcake_TB_VENDADataProvider DataProvider;
		
		public TB_VENDAProcessProvider(IGeneralDataProvider Provider, string TableName, string DataBaseName)
		{
			MainProvider = Provider;
			DataProvider = new DbCupcake_TB_VENDADataProvider(MainProvider, TableName, DataBaseName, "PK_TB_VENDA", "IncluiVenda");
			DataProvider.PageProvider = this;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			return null;
		}

		public void ExecutePreDefinedProcess(Dictionary<string, GeneralDataProvider> AllParentItemsFromParent,Dictionary<string, object> AliasVariables, Dictionary<string, DataAccessObject> AllDaos)
		{
			DataProvider.Dao = AllDaos[DataProvider.DataBaseName];
			this.AliasVariables = AliasVariables;
			Dictionary<string, GeneralDataProvider> AllParentItems = null;
			List<GeneralDataProviderItem> Items;
            if (AllParentItemsFromParent != null)
            {
                AllParentItems = new Dictionary<string, GeneralDataProvider>(AllParentItemsFromParent);
            }
			if(AllParentItems == null)
			{
				AllParentItems = new Dictionary<string, GeneralDataProvider>();
			}
			AllParentItems.Add(DataProvider.Name, DataProvider);
			try
			{
				DataProvider.FiltroAtual = DataProvider.Dao.PoeColAspas("LOGIN_USER_LOGIN") + " = " + DataProvider.Dao.ToSql(EnvironmentVariable.LoggedLoginUser.ToString(), FieldType.Text);
				DataProvider.SelectCommand.OrderBy = "";
			}
			catch
			{
				DataProvider.FiltroAtual = "1 = 2";
			}
			DataProvider.CreateParameters();
			Items = DataProvider.SelectAllItems(true);
			foreach(GeneralDataProviderItem item in Items)
			{
				if (item != null)
				{
					DataProvider.Item = item;
					((TableCommand)DataProvider.SelectCommand).Parameters.Clear();
					foreach(ParameterStruct ps in DataProvider.Parameters.Values)
					{
						string paramformat = "";
						if (ps.Parameter is DateParameter)
						{
							paramformat = DataProvider.SelectCommand.DateFormat;
						}
						((TableCommand)DataProvider.SelectCommand).AddParameter(ps.Name, ps.Parameter, paramformat, DataProvider.Dao.PoeColAspas(ps.Name), Condition.Equal, false);
					}
					FillAuxiliarTables(AllParentItems);
					CreateEntries(AllParentItems, AliasVariables);

					int vgNumberEntrie = 0;
					string ValueField = "";
					foreach (Entry Entry in Entries.Values)
					{
						for (int vgNparc = 1; vgNparc <= Entry.NumberEntries; vgNparc++)
						{
							CreateEntriesItems(Entry, AllParentItems, AliasVariables, vgNparc);
							if (Entry.EntryItems != null && Entry.EntryItems.Count > 0)
							{
								DataProcessEntry.ExecuteInsertEntry(new List<EntryItem>(Entry.EntryItems), Entry.Provider.Dao);
							}
						}
						if (Entry.EntryItems != null && Entry.EntryItems.Count > 0)
						{
						}
					}
				}
			}
		}

		public void FillAuxiliarTables(Dictionary<string, GeneralDataProvider> AllParentItems)
		{
		}
		
		public void SetParametersValues(GeneralDataProvider Provider, Dictionary<string, GeneralDataProvider> AllParentItems)
        {
        }
		
		public void CreateEntries(Dictionary<string, GeneralDataProvider> AllParentItems,Dictionary<string, object> AliasVariables)
		{
			Entries = new Dictionary<string, Entry>();
			Entries.Clear();
			Entries.Add("Novo_Lançamento", new Entry("Novo_Lançamento",AllParentItems["IncluiVenda"].Dao.PoeColAspas("TB_VENDA"),Convert.ToInt32(Convert.ToInt32(1)),AllParentItems["IncluiVenda"].Item.CodLan,AllParentItems["IncluiVenda"],0, 112, true));
		}
		
		public void CreateEntriesItems(Entry Entry, Dictionary<string, GeneralDataProvider> AllParentItems, Dictionary<string, object> AliasVariables, int vgNparc)
		{
			Entry.EntryItems.Clear(); 
			object ValueField="";
			switch (Entry.Title)
			{
				case "Novo_Lançamento":
					if(Utility.PTab(AllParentItems["IncluiVenda"], "LOGIN_USER_LOGIN", DataProvider.Dao.ToSql(EnvironmentVariable.LoggedLoginUser, FieldType.Text), "PENDENTE_VENDA", DataProvider.Dao.ToSql((true).ToString(), FieldType.Boolean) ))
					{
						ValueField = AllParentItems["IncluiVenda"].Dao.ToSql(new TextField("",EnvironmentVariable.LoggedLoginUser).GetFormattedValue(""),FieldType.Text);
						EntryItem Novo_Lancamento2= new EntryItem(AllParentItems["IncluiVenda"].Dao.PoeColAspas("TB_VENDA"),AllParentItems["IncluiVenda"].Dao.PoeColAspas("LOGIN_USER_LOGIN"),ValueField);
						Entry.EntryItems.Add(Novo_Lancamento2);
						ValueField = AllParentItems["IncluiVenda"].Dao.ToSql(new DateField(AllParentItems["IncluiVenda"].SelectCommand.DateFormat,EnvironmentVariable.ActualDateTime).GetFormattedValue(AllParentItems["IncluiVenda"].SelectCommand.DateFormat),FieldType.Date);
						EntryItem Novo_Lancamento3= new EntryItem(AllParentItems["IncluiVenda"].Dao.PoeColAspas("TB_VENDA"),AllParentItems["IncluiVenda"].Dao.PoeColAspas("DATA_VENDA"),ValueField);
						Entry.EntryItems.Add(Novo_Lancamento3);
						ValueField = AllParentItems["IncluiVenda"].Dao.ToSql(new BooleanField(AllParentItems["IncluiVenda"].SelectCommand.BoolFormat,"1").GetFormattedValue(AllParentItems["IncluiVenda"].SelectCommand.BoolFormat),FieldType.Boolean);
						EntryItem Novo_Lancamento7= new EntryItem(AllParentItems["IncluiVenda"].Dao.PoeColAspas("TB_VENDA"),AllParentItems["IncluiVenda"].Dao.PoeColAspas("PENDENTE_VENDA"),ValueField);
						Entry.EntryItems.Add(Novo_Lancamento7);
					}
					break;
				default:
					break;
			}
		}

	}
}
