using System.Collections.Generic;

namespace PROJETO
{	
	public static class ProjectControlPermissions
	{
		private static Dictionary<string, Dictionary<string, string>>  _permissions;
		
		public static Dictionary<string, Dictionary<string, string>> Permissions
		{
			get
			{
				if (_permissions == null) FillPermissions();
				return _permissions;
			}		
		}
		
		private static void FillPermissions()
		{
			_permissions = new Dictionary<string, Dictionary<string, string>>();

			// Permissões para página: ~/Pages/LoginPage.aspx
			_permissions["33240"] = new Dictionary<string, string>();
			_permissions["33240"]["$TITLE$"] =  "Login";
			_permissions["33240"]["$NAME$"] =  "LoginPage";
			_permissions["33240"]["$ALLOW_VIEW$"] = "Permitir visualização";
			
			// Permissões customizadas para: Modulo: 33240 (AspxModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/HomeAspx.aspx
			_permissions["36034"] = new Dictionary<string, string>();
			_permissions["36034"]["$TITLE$"] =  "Home";
			_permissions["36034"]["$NAME$"] =  "HomeAspx";
			_permissions["36034"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["36034"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["36034"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["36034"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 36034 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/Pag_Cad_Prod.aspx
			_permissions["36032"] = new Dictionary<string, string>();
			_permissions["36032"]["$TITLE$"] =  "Cadastro de Produto";
			_permissions["36032"]["$NAME$"] =  "Pag_Cad_Prod";
			_permissions["36032"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["36032"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["36032"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["36032"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 36032 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/Pag_Cad_Venda.aspx
			_permissions["36033"] = new Dictionary<string, string>();
			_permissions["36033"]["$TITLE$"] =  "Meu Carrinho de Compras";
			_permissions["36033"]["$NAME$"] =  "Pag_Cad_Venda";
			_permissions["36033"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["36033"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["36033"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["36033"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 36033 (DataPageModule) - Controle: Form1
			
			// Permissões customizadas para Grid1
			_permissions["36033"]["$2520630$"] = "Grid1";
			_permissions["36033"]["$2520630$.$ALLOW_VIEW$"] = "Permitir visualizar dados em " + _permissions["36033"]["$2520630$"];
			

			// Permissões para página: ~/Pages/Pagamento.aspx
			_permissions["36046"] = new Dictionary<string, string>();
			_permissions["36046"]["$TITLE$"] =  "Pagamento da Venda";
			_permissions["36046"]["$NAME$"] =  "Pagamento";
			_permissions["36046"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["36046"]["$ALLOW_UPDATE$"] = "Permitir edição";
			
			// Permissões customizadas para: Modulo: 36046 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/TB_LOGIN_USER.aspx
			_permissions["36035"] = new Dictionary<string, string>();
			_permissions["36035"]["$TITLE$"] =  "Cadastro";
			_permissions["36035"]["$NAME$"] =  "TB_LOGIN_USER";
			_permissions["36035"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["36035"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["36035"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["36035"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 36035 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/PagRec.aspx
			_permissions["36036"] = new Dictionary<string, string>();
			_permissions["36036"]["$TITLE$"] =  "Contas a Receber";
			_permissions["36036"]["$NAME$"] =  "PagRec";
			_permissions["36036"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["36036"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["36036"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["36036"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 36036 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/sucesso.aspx
			_permissions["36045"] = new Dictionary<string, string>();
			_permissions["36045"]["$TITLE$"] =  "Sucesso";
			_permissions["36045"]["$NAME$"] =  "sucesso";
			_permissions["36045"]["$ALLOW_VIEW$"] = "Permitir visualização";
			
			// Permissões customizadas para: Modulo: 36045 (DataPageModule) - Controle: Form1
			

			// Permissões para página: ~/Pages/IncluiVenda.aspx
			_permissions["36039"] = new Dictionary<string, string>();
			_permissions["36039"]["$TITLE$"] =  "IncluiVenda";
			_permissions["36039"]["$NAME$"] =  "IncluiVenda";
			_permissions["36039"]["$ALLOW_VIEW$"] = "Permitir visualização";
			

			// Permissões para página: ~/Pages/ItemIncluiCR.aspx
			_permissions["36043"] = new Dictionary<string, string>();
			_permissions["36043"]["$TITLE$"] =  "ItemIncluiCR";
			_permissions["36043"]["$NAME$"] =  "ItemIncluiCR";
			_permissions["36043"]["$ALLOW_VIEW$"] = "Permitir visualização";
			

			// Permissões para página: ~/Pages/TB_LOGIN_USER1.aspx
			_permissions["36044"] = new Dictionary<string, string>();
			_permissions["36044"]["$TITLE$"] =  "Usuário de login";
			_permissions["36044"]["$NAME$"] =  "TB_LOGIN_USER1";
			_permissions["36044"]["$ALLOW_VIEW$"] = "Permitir visualização";
			_permissions["36044"]["$ALLOW_INSERT$"] = "Permitir inclusão";
			_permissions["36044"]["$ALLOW_UPDATE$"] = "Permitir edição";
			_permissions["36044"]["$ALLOW_DELETE$"] = "Permitir exclusão";
			
			// Permissões customizadas para: Modulo: 36044 (DataPageModule) - Controle: Form1
			

		}
	
	}
}
