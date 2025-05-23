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
	public class ItemIncluiCRProcessProvider: GeneralProvider
	{
		public DbCupcake_TB_CRDataProvider AUX_TB_CRProvider;
		public DbCupcake_TB_VENDADataProvider DataProvider;
		
		public ItemIncluiCRProcessProvider(IGeneralDataProvider Provider, string TableName, string DataBaseName)
		{
			MainProvider = Provider;
			DataProvider = new DbCupcake_TB_VENDADataProvider(MainProvider, TableName, DataBaseName, "PK_TB_VENDA", "ItemIncluiCR");
			DataProvider.PageProvider = this;
			AUX_TB_CRProvider = new DbCupcake_TB_CRDataProvider(MainProvider, "TB_CR", "DbCupcake", "", "AUX_TB_CR");
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
			AllParentItems.Add(AUX_TB_CRProvider.Name, AUX_TB_CRProvider);
			try
			{
				DataProvider.FiltroAtual = DataProvider.Dao.PoeColAspas("ID_VENDA") + " = " + DataProvider.Dao.ToSql(AliasVariables["ParamVenda"].ToString(), FieldType.Integer);
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
							if (Entry.Provider.Name ==  "AUX_TB_CR")
							{
								Entry.Provider.FindRecord("PK_TB_CR", false, new string[] { Entry.Provider.Dao.GetIdentity(Entry.Provider.TableName, "ID_CR") });
							}
						}
					}
				}
			}
		}

		public void FillAuxiliarTables(Dictionary<string, GeneralDataProvider> AllParentItems)
		{
			SetParametersValues(AUX_TB_CRProvider, AllParentItems);
			AUX_TB_CRProvider.Dao = DataProvider.Dao;
			AUX_TB_CRProvider.SelectItem(1, FormPositioningEnum.First,false);
		}
		
		public void SetParametersValues(GeneralDataProvider Provider, Dictionary<string, GeneralDataProvider> AllParentItems)
        {
        }
		
		public void CreateEntries(Dictionary<string, GeneralDataProvider> AllParentItems,Dictionary<string, object> AliasVariables)
		{
			Entries = new Dictionary<string, Entry>();
			Entries.Clear();
			Entries.Add("Novo_Lançamento", new Entry("Novo_Lançamento",AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("TB_CR"),Convert.ToInt32(Convert.ToInt32(1)),AllParentItems["AUX_TB_CR"].Item.CodLan,AllParentItems["AUX_TB_CR"],1, 115, true));
		}
		
		public void CreateEntriesItems(Entry Entry, Dictionary<string, GeneralDataProvider> AllParentItems, Dictionary<string, object> AliasVariables, int vgNparc)
		{
			Entry.EntryItems.Clear(); 
			object ValueField="";
			switch (Entry.Title)
			{
				case "Novo_Lançamento":
					if(!Utility.PTab(AllParentItems["AUX_TB_CR"], "ID_VENDA", DataProvider.Dao.ToSql(AliasVariables["ParamVenda"].ToString(), FieldType.Integer) ))
					{
						ValueField = AllParentItems["AUX_TB_CR"].Dao.ToSql(new TextField("",EnvironmentVariable.LoggedLoginUser).GetFormattedValue(""),FieldType.Text);
						EntryItem Novo_Lancamento2= new EntryItem(AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("TB_CR"),AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("LOGIN_USER_LOGIN"),ValueField);
						Entry.EntryItems.Add(Novo_Lancamento2);
						ValueField = AllParentItems["AUX_TB_CR"].Dao.ToSql(new DateField(AllParentItems["AUX_TB_CR"].SelectCommand.DateFormat,Utility.FixValue<DateTime>(AliasVariables["ParamData"])).GetFormattedValue(AllParentItems["AUX_TB_CR"].SelectCommand.DateFormat),FieldType.Date);
						EntryItem Novo_Lancamento3= new EntryItem(AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("TB_CR"),AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("DATA_CR"),ValueField);
						Entry.EntryItems.Add(Novo_Lancamento3);
						ValueField = AllParentItems["AUX_TB_CR"].Dao.ToSql(new TextField("","1").GetFormattedValue(""),FieldType.Text);
						EntryItem Novo_Lancamento4= new EntryItem(AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("TB_CR"),AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("TPGTO_CR"),ValueField);
						Entry.EntryItems.Add(Novo_Lancamento4);
						ValueField = AllParentItems["AUX_TB_CR"].Dao.ToSql(new LongField("",Utility.FixValue<double>(AliasVariables["ParamVenda"])).GetFormattedValue(""),FieldType.Long);
						EntryItem Novo_Lancamento5= new EntryItem(AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("TB_CR"),AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("ID_VENDA"),ValueField);
						Entry.EntryItems.Add(Novo_Lancamento5);
						ValueField = AllParentItems["AUX_TB_CR"].Dao.ToSql(new TextField("",Utility.FixValue<double>(AliasVariables["ParamValor"])).GetFormattedValue(""),FieldType.Text);
						EntryItem Novo_Lancamento6= new EntryItem(AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("TB_CR"),AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("VALOR_CR"),ValueField);
						Entry.EntryItems.Add(Novo_Lancamento6);
						ValueField = AllParentItems["AUX_TB_CR"].Dao.ToSql(new BooleanField(AllParentItems["AUX_TB_CR"].SelectCommand.BoolFormat,"0").GetFormattedValue(AllParentItems["AUX_TB_CR"].SelectCommand.BoolFormat),FieldType.Boolean);
						EntryItem Novo_Lancamento7= new EntryItem(AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("TB_CR"),AllParentItems["AUX_TB_CR"].Dao.PoeColAspas("REC_CR"),ValueField);
						Entry.EntryItems.Add(Novo_Lancamento7);
					}
					break;
				default:
					break;
			}
		}

	}
}
