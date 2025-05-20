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
	public partial class DbCupcake_TB_CRItem : GeneralDataProviderItem
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

		public DbCupcake_TB_CRItem(string DataBaseName) : this(DataBaseName, true)
		{
		}

		public DbCupcake_TB_CRItem(string DataBaseName, params string[] FieldNames) : this(DataBaseName, false, FieldNames)
		{
		}
		
		/// <summary>
		/// Construtor da Página
		/// </summary>
		private DbCupcake_TB_CRItem(string DataBaseName, bool AllFields, params string[] FieldNames)
		{
			this.DataBaseName = DataBaseName;	
			Fields = CreateItemFields(AllFields, FieldNames);
		}
		
		public static Dictionary<string, FieldBase> CreateItemFields(bool AllFields, params string[] FieldNames)
		{
			Dictionary<string, FieldBase> NewFields = new Dictionary<string, FieldBase>();
			 NewFields.Add("ID_CR", new LongField("ID_CR", "", null, false));
			if (AllFields || Contains(FieldNames, "LOGIN_USER_LOGIN")) NewFields.Add("LOGIN_USER_LOGIN", new TextField("LOGIN_USER_LOGIN", "", null, true));
			if (AllFields || Contains(FieldNames, "DATA_CR")) NewFields.Add("DATA_CR", new DateField("DATA_CR", "", null, true));
			if (AllFields || Contains(FieldNames, "TPGTO_CR")) NewFields.Add("TPGTO_CR", new TextField("TPGTO_CR", "", null, true));
			if (AllFields || Contains(FieldNames, "ID_VENDA")) NewFields.Add("ID_VENDA", new LongField("ID_VENDA", "", null, true));
			if (AllFields || Contains(FieldNames, "VALOR_CR")) NewFields.Add("VALOR_CR", new TextField("VALOR_CR", "", null, true));
			if (AllFields || Contains(FieldNames, "REC_CR")) NewFields.Add("REC_CR", new BooleanField("REC_CR", "", null, true));
			
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
	public class DbCupcake_TB_CRDataProvider : GeneralDataProvider
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
			return DbCupcake_TB_CRItem.CreateItemFields(true); 
		}
	
		public DbCupcake_TB_CRDataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string Name) : base(BasePage, TableName, DataBaseName, IndexName, Name, "", false)
		{
		}

		public override void CreateUniqueParameter()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "PK_TB_CR":
					CreateParameter("ID_CR");
					break;
			}
		}
				
		public override void CreateParameters()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "PK_TB_CR":
					CreateParameter("ID_CR");
					break;
			}
			base.CreateParameters();
		}

		public override string ProviderFilterExpression()
		{
			return this.GetFilterExpression( DbCupcake_TB_CRItem.CreateItemFields(false, GetUniqueKeyFields()));
		}

		public override string[] GetUniqueKeyFields()
		{
			return new string[] { "ID_CR" };
		}			
	}
}
