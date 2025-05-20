using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
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
using Newtonsoft.Json;

namespace PROJETO.DataProviders
{
	public partial class DbCupcake_TB_VENDA_ITEMItem : GeneralDataProviderItem
	{
		private string DataBaseName;
				
		private DataAccessObject _Dao;
		public DataAccessObject Dao
		{
			get 
			{ 
				if (_Dao == null) _Dao = Utility.GetDAO(DataBaseName);
				return _Dao;
			}
		}

		public DbCupcake_TB_VENDA_ITEMItem(string DataBaseName) : this(DataBaseName, true)
		{
		}

		public DbCupcake_TB_VENDA_ITEMItem(string DataBaseName, params string[] FieldNames) : this(DataBaseName, false, FieldNames)
		{
		}
		
		/// <summary>
		/// Construtor da Página
		/// </summary>
		private DbCupcake_TB_VENDA_ITEMItem(string DataBaseName, bool AllFields, params string[] FieldNames)
		{
			this.DataBaseName = DataBaseName;	
			Fields = CreateItemFields(AllFields, FieldNames);
		}
		
		public static Dictionary<string, FieldBase> CreateItemFields(bool AllFields, params string[] FieldNames)
		{
			Dictionary<string, FieldBase> NewFields = new Dictionary<string, FieldBase>();
			 NewFields.Add("ID_VENDA_ITEM", new LongField("ID_VENDA_ITEM", "", null, false));
			if (AllFields || Contains(FieldNames, "ID_VENDA")) NewFields.Add("ID_VENDA", new LongField("ID_VENDA", "", null, true));
			if (AllFields || Contains(FieldNames, "ID_PRODUTO")) NewFields.Add("ID_PRODUTO", new LongField("ID_PRODUTO", "", null, true));
			if (AllFields || Contains(FieldNames, "QTDE_VENDA_ITEM")) NewFields.Add("QTDE_VENDA_ITEM", new LongField("QTDE_VENDA_ITEM", "", null, true));
			if (AllFields || Contains(FieldNames, "VALOR_VENDA_ITEM")) NewFields.Add("VALOR_VENDA_ITEM", new DecimalField("VALOR_VENDA_ITEM", "", null, true));
			
			if (!AllFields)
			{
				Dictionary<string, FieldBase> NewFieldsOrder = new Dictionary<string, FieldBase>();
				foreach (string Field in FieldNames)
				{
					NewFieldsOrder.Add(Field, NewFields[Field]);
				}
				NewFields = NewFieldsOrder; 
			}
			
			return NewFields;
		}
		
		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para inserir o registro na tabela</param>
		public override void Validate(GeneralDataProvider provider)
		{
		}
	}
	
	/// <summary>
	/// Classe de provider usada para acessar a tabela de produtos
	/// </summary>
	public class DbCupcake_TB_VENDA_ITEMDataProvider : GeneralDataProvider
	{
		public FieldBase this[string ColumnName]
		{
			get
			{
				return Item[ColumnName];
			}
		}

		public override Dictionary<string, FieldBase> CreateItemFields()
		{
			return DbCupcake_TB_VENDA_ITEMItem.CreateItemFields(true); 
		}
	
		public DbCupcake_TB_VENDA_ITEMDataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string Name) : base(BasePage, TableName, DataBaseName, IndexName, Name, "", false)
		{
		}

		public override void CreateUniqueParameter()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "PK_TB_VENDA_ITEM":
					CreateParameter("ID_VENDA_ITEM");
					break;
			}
		}
				
		public override void CreateParameters()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "PK_TB_VENDA_ITEM":
					CreateParameter("ID_VENDA_ITEM");
					break;
			}
			base.CreateParameters();
		}

		public override string ProviderFilterExpression()
		{
			return this.GetFilterExpression( DbCupcake_TB_VENDA_ITEMItem.CreateItemFields(false, GetUniqueKeyFields()));
		}

		public override string[] GetUniqueKeyFields()
		{
			return new string[] { "ID_VENDA_ITEM" };
		}			
	}
}
