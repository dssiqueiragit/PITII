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
	public partial class DbCupcake_TB_PRODUTOItem : GeneralDataProviderItem
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

		public DbCupcake_TB_PRODUTOItem(string DataBaseName) : this(DataBaseName, true)
		{
		}

		public DbCupcake_TB_PRODUTOItem(string DataBaseName, params string[] FieldNames) : this(DataBaseName, false, FieldNames)
		{
		}
		
		/// <summary>
		/// Construtor da Página
		/// </summary>
		private DbCupcake_TB_PRODUTOItem(string DataBaseName, bool AllFields, params string[] FieldNames)
		{
			this.DataBaseName = DataBaseName;	
			Fields = CreateItemFields(AllFields, FieldNames);
		}
		
		public static Dictionary<string, FieldBase> CreateItemFields(bool AllFields, params string[] FieldNames)
		{
			Dictionary<string, FieldBase> NewFields = new Dictionary<string, FieldBase>();
			 NewFields.Add("ID_PRODUTO", new LongField("ID_PRODUTO", "", null, false));
			if (AllFields || Contains(FieldNames, "NOME_PRODUTO")) NewFields.Add("NOME_PRODUTO", new TextField("NOME_PRODUTO", "", null, true));
			if (AllFields || Contains(FieldNames, "VALOR_PRODUTO")) NewFields.Add("VALOR_PRODUTO", new DecimalField("VALOR_PRODUTO", "", null, true));
			if (AllFields || Contains(FieldNames, "FOTO1_PRODUTO")) NewFields.Add("FOTO1_PRODUTO", new BinaryField("FOTO1_PRODUTO", "", null, true));
			if (AllFields || Contains(FieldNames, "FOTO2_PRODUTO")) NewFields.Add("FOTO2_PRODUTO", new BinaryField("FOTO2_PRODUTO", "", null, true));
			if (AllFields || Contains(FieldNames, "OBS_PRODUTO")) NewFields.Add("OBS_PRODUTO", new MemoField("OBS_PRODUTO", "", null, true));
			
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
	public class DbCupcake_TB_PRODUTODataProvider : GeneralDataProvider
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
			return DbCupcake_TB_PRODUTOItem.CreateItemFields(true); 
		}
	
		public DbCupcake_TB_PRODUTODataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string Name) : base(BasePage, TableName, DataBaseName, IndexName, Name, "", false)
		{
		}

		public override void CreateUniqueParameter()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "PK_TB_PRODUTO":
					CreateParameter("ID_PRODUTO");
					break;
			}
		}
				
		public override void CreateParameters()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "PK_TB_PRODUTO":
					CreateParameter("ID_PRODUTO");
					break;
			}
			base.CreateParameters();
		}

		public override string ProviderFilterExpression()
		{
			return this.GetFilterExpression( DbCupcake_TB_PRODUTOItem.CreateItemFields(false, GetUniqueKeyFields()));
		}

		public override string[] GetUniqueKeyFields()
		{
			return new string[] { "ID_PRODUTO" };
		}			
	}
}
