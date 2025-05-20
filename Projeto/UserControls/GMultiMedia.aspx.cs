using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_GMultiMedia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected override void Render(HtmlTextWriter writer)
	{
		string SessionHandlerObjectName = Page.Request["File"];
		byte[] FileContent = Convert.FromBase64String((string)Session[SessionHandlerObjectName]);
		int ContentStart;
		int ContentLenght;
		string FileName;
		
		FileName = BuscaNomeArquivo(Session[SessionHandlerObjectName + "FileName"].ToString());
		ContentStart = 0;
		ContentLenght = FileContent.Length;		
	
		if (FileName.EndsWith(".html") || FileName.EndsWith(".htm"))
		{
			HttpContext.Current.Response.ContentType = System.Net.Mime.MediaTypeNames.Text.Html;
		}
		else if (FileName.EndsWith(".xml"))
		{
			HttpContext.Current.Response.ContentType = System.Net.Mime.MediaTypeNames.Text.Xml;
		}
		else if (FileName.EndsWith(".pdf"))
		{
			HttpContext.Current.Response.ContentType = "application/pdf";
		}
		else
		{
			HttpContext.Current.Response.ContentType = "image/png";
		}
		HttpContext.Current.Response.AddHeader("Content-Length", ContentLenght.ToString());
		HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + FileName);
		HttpContext.Current.Response.Clear();
		HttpContext.Current.Response.OutputStream.Write(FileContent, ContentStart, ContentLenght);
		HttpContext.Current.Response.End();
	}
	private string BuscaNomeArquivo(string arquivo)
	{
		string nome = System.IO.Path.GetFileName(arquivo);
		return nome.Substring(nome.IndexOf("_") + 1);
	}
}
