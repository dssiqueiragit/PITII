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
	public class ProcessoIncluiVendaProcessProvider : GeneralProvider
	{
		public TB_VENDAProcessProvider TB_VENDAPreDefProvider;

		public ProcessoIncluiVendaProcessProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			TB_VENDAPreDefProvider = new TB_VENDAProcessProvider(MainProvider, "TB_VENDA", "DbCupcake");
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			return null;
		}

		private DataAccessObject _DaoDbCupcake;
		public DataAccessObject DaoDbCupcake
		{
			get
			{
				if (_DaoDbCupcake == null) _DaoDbCupcake = Utility.GetDAO("DbCupcake");
				return _DaoDbCupcake;
			}
			set
			{
				_DaoDbCupcake = value;
			}
		}
		
		public void ExecutePreDefinedProcess()
		{
			bool HasTransaction = false;
			try
			{
				Dictionary<string, DataAccessObject> allDaos = new Dictionary<string, DataAccessObject>();
				DaoDbCupcake.OpenConnection();
				DaoDbCupcake.BeginTrans();
				HasTransaction = true;
				allDaos.Add("DbCupcake", DaoDbCupcake);
				HttpContext.Current.Session["AllDaos"] = allDaos;
				TB_VENDAPreDefProvider.ExecutePreDefinedProcess(null, AliasVariables, allDaos);
				DaoDbCupcake.CommitTrans();
				HttpContext.Current.Session.Remove("AllDaos");
			}
			catch (Exception ex)
			{
				HttpContext.Current.Session.Remove("AllDaos");
				if (HasTransaction)
				{
				DaoDbCupcake.RollBack();
				}
				throw ex;
			}
		}

		public override void FillAuxiliarTables()
		{
		}
	}
}
