using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Configuration;
using System.Linq;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Configuration;
using COMPONENTS.Security;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;

namespace PROJETO.DataPages
{
	public partial class HomeAspx : GeneralDataPage
	{
		protected HomeAspxPageProvider PageProvider;
	

		public long ID_PRODUTOField = 0;
		public string NOME_PRODUTOField = "";
		public double VALOR_PRODUTOField = 0;
		public string OBS_PRODUTOField = "";
		
		public override string FormID { get { return "36034"; } }
		public override string TableName { get { return "TB_PRODUTO"; } }
		public override string DatabaseName { get { return "DbCupcake"; } }
		public override string PageName { get { return "HomeAspx.aspx"; } }
		public override string ProjectID { get { return "ED2986E"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return false;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return false; } }
		



		
		public override void CreateProvider()
		{
			PageProvider = new HomeAspxPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			AjaxPanel = MainAjaxPanel;
			if (IsPostBack)
			{
				AjaxPanel.ResponseScripts.Add("setTimeout(\"InitializeClient();\",100);");
			}
			if (!PageInsert )
				DisableEnableContros(false);
			this.Load += new EventHandler(DataPage_Load);

			base.OnInit(e);
		}
		
		
		private bool AlreadyStartedListControls;
		
		private void StartListControls()
		{
			if (AlreadyStartedListControls) return;
			Repeater1Index = new Hashtable();
			PageProvider.Repeater1RepeaterProvider.DataProvider.PrepareSelectCountCommands();
			Repeater1.DataSource = PageProvider.Repeater1RepeaterProvider.DataProvider.SelectAllItems();
			Repeater1.ItemDataBound += new RepeaterItemEventHandler(Repeater1_ItemDataBound);
			Repeater1.DataBind();
			AlreadyStartedListControls = true;
		}

		public Hashtable Repeater1Index
		{
			get
			{
				if (ViewState["Repeater1Index"] != null)
				{
					return (Hashtable)ViewState["Repeater1Index"];
				}
				return null;
			}
			set
			{
				ViewState["Repeater1Index"] = value;
			}
		}

		void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			object RowObj = e.Item.DataItem;
			if (RowObj is DataRowView) RowObj = ((DataRowView)RowObj).Row;
			DataRow row = RowObj as DataRow;
			if(row != null)
			{
				DataListProviderSinc(row, null, PageProvider.Repeater1RepeaterProvider.DataProvider);
				Repeater1Index[e.Item.UniqueID] = "ID_PRODUTO=" + row["ID_PRODUTO"].ToString();
			}
			switch (e.Item.ItemType)
			{
				case ListItemType.Item:
					if(row != null)
					{
						GMultiMedia RepCtrGMultiMedia1 = e.Item.FindControl("GMultiMedia1") as GMultiMedia;
						if (row["FOTO1_PRODUTO"] != DBNull.Value)
						{
							RepCtrGMultiMedia1.SessionHandlerObjectName = e.Item.UniqueID + "FOTO1_PRODUTO2520279" + e.Item.ItemIndex.ToString();
							MediaHandlerHelper.PrepareMediaHandler((byte[])row["FOTO1_PRODUTO"], RepCtrGMultiMedia1.SessionHandlerObjectName,false,false);
						}
						RadLabel RepCtrLabel1 = e.Item.FindControl("Label1") as RadLabel;
						RepCtrLabel1.Text = row["NOME_PRODUTO"].ToString();
						RepCtrLabel1.Text = RepCtrLabel1.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel1.Text = Mask.ApplyMask(RepCtrLabel1.Text, "@!@A", "TEXT");
						RadLabel RepCtrLabel2 = e.Item.FindControl("Label2") as RadLabel;
						RepCtrLabel2.Text = row["VALOR_PRODUTO"].ToString();
						RepCtrLabel2.Text = RepCtrLabel2.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel2.Text = Mask.ApplyMask(RepCtrLabel2.Text, "99.999.999,99", "NUMBER");
						RadLabel RepCtrLabel3 = e.Item.FindControl("Label3") as RadLabel;
						RepCtrLabel3.Text = row["OBS_PRODUTO"].ToString();
						RepCtrLabel3.Text = RepCtrLabel3.Text.Replace("<", "&lt;").Replace(">", "&gt;");
					}
					break;
				case ListItemType.AlternatingItem:
					if(row != null)
					{
						GMultiMedia RepCtrGMultiMedia2 = e.Item.FindControl("GMultiMedia2") as GMultiMedia;
						if (row["FOTO2_PRODUTO"] != DBNull.Value)
						{
							RepCtrGMultiMedia2.SessionHandlerObjectName = e.Item.UniqueID + "FOTO2_PRODUTO2520280" + e.Item.ItemIndex.ToString();
							MediaHandlerHelper.PrepareMediaHandler((byte[])row["FOTO2_PRODUTO"], RepCtrGMultiMedia2.SessionHandlerObjectName,false,false);
						}
						RadLabel RepCtrLabel5 = e.Item.FindControl("Label5") as RadLabel;
						RepCtrLabel5.Text = row["NOME_PRODUTO"].ToString();
						RepCtrLabel5.Text = RepCtrLabel5.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel5.Text = Mask.ApplyMask(RepCtrLabel5.Text, "@!@A", "TEXT");
						RadLabel RepCtrLabel6 = e.Item.FindControl("Label6") as RadLabel;
						RepCtrLabel6.Text = row["VALOR_PRODUTO"].ToString();
						RepCtrLabel6.Text = RepCtrLabel6.Text.Replace("<", "&lt;").Replace(">", "&gt;");
						RepCtrLabel6.Text = Mask.ApplyMask(RepCtrLabel6.Text, "99.999.999,99", "NUMBER");
						RadLabel RepCtrLabel4 = e.Item.FindControl("Label4") as RadLabel;
						RepCtrLabel4.Text = row["OBS_PRODUTO"].ToString();
						RepCtrLabel4.Text = RepCtrLabel4.Text.Replace("<", "&lt;").Replace(">", "&gt;");
					}
					break;
			}
		}


		/// <summary>
		/// Carrega os objetos de Item de acordo com os controles
		/// </summary>
		public override void UpdateItemFromControl(GeneralDataProviderItem  Item)
		{
			// só vamos permitir a carga dos itens de acordo com os controles de tela caso esteja ocorrendo
			// um postback pois em caso contrário a página está sendo aberta em modo de inclusão/edição
			// e dessa forma não teve alteração de usuário nos dados do formulário
			if (PageState != FormStateEnum.Navigation && this.IsPostBack)
			{
			}
			InitializeAlias(Item);
		}

		/// <summary>
		/// Carrega os objetos de tela para o Item Provider da página
		/// </summary>

		public override GeneralDataProviderItem LoadItemFromControl(bool EnableValidation)
		{
			GeneralDataProviderItem Item = PageProvider.GetDataProviderItem(DataProvider);
			if (PageState != FormStateEnum.Navigation)
			{
			}
			else
			{
				Item = PageProvider.MainProvider.DataProvider.SelectItem(PageNumber, FormPositioningEnum.Current);
			}
			if (EnableValidation)
			{
				InitializeAlias(Item);
				if (PageState == FormStateEnum.Insert)
				{
					FillAuxiliarTables();
				}
				PageProvider.Validate(Item); 
			}
			if (Item!=null) PageErrors.Add(Item.Errors);
			return Item;
		}
		


		public override void DefineStartScripts()
		{
		}
		
		public override void DisableEnableContros(bool Action)
		{
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
			if (ShouldClearFields)
			{
			}
			if (!PageInsert && PageState == FormStateEnum.Navigation)
				DisableEnableContros(false);				
			else
				DisableEnableContros(true);				
		}		

		public override void ShowInitialValues()
		{
		}

		public override void PageEdit()
		{
			DisableEnableContros(true); 
			base.PageEdit(); 
		}

		public override void ShowFormulas()
		{
		}
		
		/// <summary>
		/// Define conteudo dos objetos de Tela
		/// </summary>
		public override void DefinePageContent(GeneralDataProviderItem Item)
		{
			InitializePageContent();
			base.DefinePageContent(Item);
		}
		/// <summary>
		/// Define apelidos da Página
		/// </summary>
		public override void InitializeAlias(GeneralDataProviderItem Item)
        {
			PageProvider.AliasVariables = new Dictionary<string, object>();
			PageProvider.AliasVariables.Clear();
			
			try
			{
				if (Item != null)
				{
					ID_PRODUTOField = long.Parse(Item["ID_PRODUTO"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
					ID_PRODUTOField = 0;
				}
			}
			catch
			{
				ID_PRODUTOField = 0;
			}
			try
			{
				if (Item != null)
				{
					NOME_PRODUTOField = Item["NOME_PRODUTO"].GetFormattedValue();
				}
				else
				{
					NOME_PRODUTOField = "";
				}
			}
			catch
			{
				NOME_PRODUTOField = "";
			}
			try
			{
				if (Item != null)
				{
					VALOR_PRODUTOField = double.Parse(Item["VALOR_PRODUTO"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
					VALOR_PRODUTOField = 0;
				}
			}
			catch
			{
				VALOR_PRODUTOField = 0;
			}
			try
			{
				if (Item != null)
				{
					OBS_PRODUTOField = Item["OBS_PRODUTO"].GetFormattedValue();
				}
				else
				{
					OBS_PRODUTOField = "";
				}
			}
			catch
			{
				OBS_PRODUTOField = "";
			}
			PageProvider.AliasVariables.Add("ID_PRODUTOField", ID_PRODUTOField);
			PageProvider.AliasVariables.Add("NOME_PRODUTOField", NOME_PRODUTOField);
			PageProvider.AliasVariables.Add("VALOR_PRODUTOField", VALOR_PRODUTOField);
			PageProvider.AliasVariables.Add("OBS_PRODUTOField", OBS_PRODUTOField);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___Button1_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				Button1_OnClick(sender, e);
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}

		protected void ___Button2_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				Button2_OnClick(sender, e);
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}

		protected override void OnLoadComplete(EventArgs e)
		{
			StartListControls();
			base.OnLoadComplete(e);
		}

        public void DataListProviderSinc(object LineIndex, Hashtable Repeaterindex, GeneralDataProvider Provider)
		{
            if (LineIndex is DataRow)
            {
                Provider.LocateRecordByRow((DataRow)LineIndex);
            }
            else
            {
				if (Repeaterindex.Count > 0 && Repeaterindex.ContainsKey(LineIndex))
                {
					Dictionary<string, object> Values = new Dictionary<string, object>();
					string[] splittedVals = Repeaterindex[LineIndex].ToString().Split('§');
					foreach (string Val in splittedVals)
					{
						Values.Add(Val.Substring(0, Val.IndexOf("=")), Val.Substring(Val.IndexOf("=") + 1));
					}
					Provider.FindRecord(Values);
				}
            }
		}


		private void DataPage_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				string EventTarget = Request["__EVENTTARGET"];
                int End = EventTarget.LastIndexOf("$");
                
                if (End == -1)
                {
                    EventTarget = Request["__EVENTARGUMENT"];
                    int Start  = EventTarget.LastIndexOf("|TargetControl:");
                    
                    if (Start > -1 )
                    {
                        End = (EventTarget.IndexOf("|", Start + 1) > -1 ? EventTarget.IndexOf("|"):(EventTarget.Length - 15) - Start);
                        EventTarget = EventTarget.Substring(Start + 15, End);
                    }
                }

				string[] TargetParts = EventTarget.Split(':');
				bool callPageShow = true;

				int Repeater1Pos = EventTarget.LastIndexOf("$");
				int Repeater1StartPos = ("$" + EventTarget).IndexOf("$Repeater1$");
				if (Repeater1StartPos != -1)
				{
					if (callPageShow) { PageShow(FormPositioningEnum.Current); callPageShow = false; };
					string Repeater1ClientID = EventTarget.Substring(0, Repeater1Pos);
					while (Repeater1ClientID.Substring(Repeater1StartPos).Count(c => c.Equals('$')) > 1)
                    {
                        Repeater1ClientID = Repeater1ClientID.Substring(0, Repeater1ClientID.LastIndexOf("$"));
                    }
					DataListProviderSinc(Repeater1ClientID, Repeater1Index, PageProvider.Repeater1RepeaterProvider.DataProvider);
				}
			}
		}


		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
#region CÓDIGO DE USUARIO

		protected void Button2_OnClick(object sender, EventArgs e)
		{
			InsereProduto();
		}
		
		protected void Button1_OnClick(object sender, EventArgs e)
		{
		    InsereProduto();
		}
		
		private void InsereProduto()
		{
		    Dictionary<string, object> parameters = new Dictionary<string, object>();
		    parameters["LOGIN_USER_LOGIN"] = EnvironmentVariable.LoggedLoginUser;
		    parameters["ID_PRODUTO"] = Convert.ToInt32(PageProvider.Repeater1RepeaterProvider.DataProvider.Item["ID_PRODUTO"].GetValue());
		
		    Dao.OpenConnection();
		
		    long ultimaVenda = long.Parse(Dao.RunSql("SELECT ISNULL(MAX(ID_VENDA), 0) total FROM TB_VENDA WHERE PENDENTE_VENDA = 1 AND LOGIN_USER_LOGIN = @LOGIN_USER_LOGIN", parameters).Tables[0].Rows[0]["total"].ToString());
		
		    long itemId = 0;
		
		    if (ultimaVenda == 0)
		    {
		        parameters["DATA_VENDA"] = DateTime.Now;
		        parameters["TOTAL_VENDA"] = 0;
		        parameters["ENTREGA_VENDA"] = "RETIRAR NA LOJA";
		        parameters["PENDENTE_VENDA"] = true;
		        parameters["TIPO_PGTO_VENDA"] = "Pix";
		
		        Dao.RunSql("INSERT INTO TB_VENDA (LOGIN_USER_LOGIN, DATA_VENDA, TOTAL_VENDA, ENTREGA_VENDA, PENDENTE_VENDA, TIPO_PGTO_VENDA) VALUES (@LOGIN_USER_LOGIN, @DATA_VENDA, @TOTAL_VENDA, @ENTREGA_VENDA, @PENDENTE_VENDA, @TIPO_PGTO_VENDA)", parameters);
		
		        ultimaVenda = long.Parse(Dao.RunSql("SELECT ISNULL(MAX(ID_VENDA), 0) total FROM TB_VENDA WHERE PENDENTE_VENDA = 1 AND LOGIN_USER_LOGIN = @LOGIN_USER_LOGIN", parameters).Tables[0].Rows[0]["total"].ToString());
		        parameters["ID_VENDA"] = ultimaVenda;
		
		    }
		    else
		    {
		        parameters["ID_VENDA"] = ultimaVenda;
		
		        var tabItem = Dao.RunSql("SELECT ID_VENDA_ITEM ID FROM TB_VENDA_ITEM WHERE ID_VENDA = @ID_VENDA AND ID_PRODUTO = @ID_PRODUTO", parameters).Tables[0];
		        if (tabItem.Rows.Count > 0)
		        {
		            itemId = long.Parse(tabItem.Rows[0]["ID"].ToString());
		        }
		    }
		
		    if (itemId == 0)
		    {
		        parameters["QTDE_VENDA_ITEM"] = 1;
		        Dao.RunSql("INSERT INTO TB_VENDA_ITEM (ID_VENDA, ID_PRODUTO, QTDE_VENDA_ITEM, VALOR_VENDA_ITEM) VALUES (@ID_VENDA, @ID_PRODUTO, @QTDE_VENDA_ITEM, (SELECT VALOR_PRODUTO FROM TB_PRODUTO WHERE ID_PRODUTO = @ID_PRODUTO))", parameters);
		    }
		    else
		    {
		        parameters["ID_VENDA_ITEM"] = itemId;
		        Dao.RunSql("UPDATE TB_VENDA_ITEM SET QTDE_VENDA_ITEM = QTDE_VENDA_ITEM + 1 WHERE ID_VENDA_ITEM = @ID_VENDA_ITEM", parameters);
		    }

	        Dao.RunSql("UPDATE TB_VENDA SET TOTAL_VENDA = (SELECT SUM(QTDE_VENDA_ITEM * VALOR_VENDA_ITEM) FROM TB_VENDA_ITEM WHERE ID_VENDA = @ID_VENDA) WHERE ID_VENDA = @ID_VENDA", parameters);
		
		    Dao.CloseConnection();
		}
		
#endregion
	}
}
