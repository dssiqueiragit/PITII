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
	public partial class DbCupcake_TB_VENDAItem : GeneralDataProviderItem
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

		public DbCupcake_TB_VENDAItem(string DataBaseName) : this(DataBaseName, true)
		{
		}

		public DbCupcake_TB_VENDAItem(string DataBaseName, params string[] FieldNames) : this(DataBaseName, false, FieldNames)
		{
		}
		
		/// <summary>
		/// Construtor da Página
		/// </summary>
		private DbCupcake_TB_VENDAItem(string DataBaseName, bool AllFields, params string[] FieldNames)
		{
			this.DataBaseName = DataBaseName;	
			Fields = CreateItemFields(AllFields, FieldNames);
		}
		
		public static Dictionary<string, FieldBase> CreateItemFields(bool AllFields, params string[] FieldNames)
		{
			Dictionary<string, FieldBase> NewFields = new Dictionary<string, FieldBase>();
			 NewFields.Add("ID_VENDA", new LongField("ID_VENDA", "", null, false));
			if (AllFields || Contains(FieldNames, "LOGIN_USER_LOGIN")) NewFields.Add("LOGIN_USER_LOGIN", new TextField("LOGIN_USER_LOGIN", "", null, true));
			if (AllFields || Contains(FieldNames, "DATA_VENDA")) NewFields.Add("DATA_VENDA", new DateField("DATA_VENDA", "", null, true));
			if (AllFields || Contains(FieldNames, "OBS_VENDA")) NewFields.Add("OBS_VENDA", new MemoField("OBS_VENDA", "", null, true));
			if (AllFields || Contains(FieldNames, "TOTAL_VENDA")) NewFields.Add("TOTAL_VENDA", new DecimalField("TOTAL_VENDA", "", null, true));
			if (AllFields || Contains(FieldNames, "ENTREGA_VENDA")) NewFields.Add("ENTREGA_VENDA", new TextField("ENTREGA_VENDA", "", null, true));
			if (AllFields || Contains(FieldNames, "PENDENTE_VENDA")) NewFields.Add("PENDENTE_VENDA", new BooleanField("PENDENTE_VENDA", "", null, true));
			if (AllFields || Contains(FieldNames, "TIPO_PGTO_VENDA")) NewFields.Add("TIPO_PGTO_VENDA", new TextField("TIPO_PGTO_VENDA", "", null, true));
			
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
	public class DbCupcake_TB_VENDADataProvider : GeneralDataProvider
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
			return DbCupcake_TB_VENDAItem.CreateItemFields(true); 
		}
	
		public DbCupcake_TB_VENDADataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string Name) : base(BasePage, TableName, DataBaseName, IndexName, Name, "", false)
		{
		}

		public override void CreateUniqueParameter()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "PK_TB_VENDA":
					CreateParameter("ID_VENDA");
					break;
			}
		}
				
		public override void CreateParameters()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "PK_TB_VENDA":
					CreateParameter("ID_VENDA");
					break;
			}
			base.CreateParameters();
		}

		public override string ProviderFilterExpression()
		{
			return this.GetFilterExpression( DbCupcake_TB_VENDAItem.CreateItemFields(false, GetUniqueKeyFields()));
		}

		public override string[] GetUniqueKeyFields()
		{
			return new string[] { "ID_VENDA" };
		}			
	}
}
