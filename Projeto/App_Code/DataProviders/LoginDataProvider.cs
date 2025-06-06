using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Security;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Security;
using COMPONENTS.Configuration;
using System.Resources;
using System.Collections.Generic;

namespace PROJETO.DataProviders
{
	public class LoginGroupItem : GeneralDataProviderItem
	{

		public LoginGroupItem()
		{
			Fields.Add("Id", new TextField(GMembershipProvider.Default.GroupIdField, "", null, false));
			Fields.Add("Name", new TextField(GMembershipProvider.Default.GroupNameField, "", null));
			Fields.Add("IsAdmin", new BooleanField(GMembershipProvider.Default.GroupIsAdminField, "", null));
		}

		public void SetDefaultGroup()
		{

			Fields["Name"].SetValue("ADMINISTRAÇÃO");
Fields["IsAdmin"].SetValue(true);
		}

	}

	public class LoginGroupDataProvider : GeneralDataProvider
	{

		public LoginGroupDataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName,string IndexName, string Name) : base(BasePage, TableName, DataBaseName,IndexName, Name)
		{
		}
		
		public DataTable GetAllGroups()
		{
			return Dao.RunSql("SELECT * FROM " + Dao.PoeColAspas(TableName)).Tables[0]; 
		}
		
		public override void CreateParameters()
		{
			Parameters.Clear();
			switch (IndexName)
			{
				case "LOGIN_GROUP_PK":
			Parameters.Add("Id", new ParameterStruct(GMembershipProvider.Default.GroupIdField, new TextParameter(), true, true, true, false));
					break;
			}
			base.CreateParameters();
		}
	}
	public class LoginUserItem : GeneralDataProviderItem
	{

		public LoginUserItem()
		{
			Fields.Add("Id", new TextField(GMembershipProvider.Default.UserIdField, "", null, false));
			Fields.Add("Group", new TextField(GMembershipProvider.Default.UserGroupIdField, "", null));
			Fields.Add("Name", new TextField(GMembershipProvider.Default.UserNameField, "", null));
			Fields.Add("Obs", new TextField(GMembershipProvider.Default.UserObsField, "", null));
			Fields.Add("Login", new TextField(GMembershipProvider.Default.UserLoginField, "", null));
			Fields.Add("Password", new TextField(GMembershipProvider.Default.UserPasswordField, "", null));
		}

		public void SetDefaultUser()
		{
			LoginGroupItem Group = GMembershipProvider.Default.GetDefaultGroup();
			if (Group != null)
			{
 Fields["Group"].SetValue(Group.Fields["Id"].Value);
			}

 Fields["Name"].SetValue("ADMINISTRADOR");
 Fields["Obs"].SetValue("USUÁRIO ADMINISTRADOR DO SISTEMA");
 Fields["Login"].SetValue("026.779.336-75");
 Fields["Password"].SetValue("ADMIN");
		}
	}

	public class LoginUserDataProvider : GeneralDataProvider
	{

		public LoginUserDataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName,string IndexName, string Name) : base(BasePage, TableName, DataBaseName,IndexName, Name)
		{
		}

		public override void CreateParameters()
		{
			Parameters.Clear();
			Parameters.Add("Login", new ParameterStruct(GMembershipProvider.Default.UserLoginField, new TextParameter(), true, true, true, false));
			base.CreateParameters();			
		}
		
		public DataTable GetAllUsersByGroup(string TextSearch, string FieldName)
		{
			if (TextSearch != "")
			{
				return Dao.RunSql("SELECT * FROM " + Dao.PoeColAspas(TableName) + " WHERE " + Dao.PoeColAspas(FieldName) + " = " + TextSearch).Tables[0]; 
			}
			else
			{
				return Dao.RunSql("SELECT * FROM " + Dao.PoeColAspas(TableName)).Tables[0]; 
			}
		}
	}
}
