using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.IO;
using PROJETO;

namespace COMPONENTS
{
	public partial class GMultiMedia : System.Web.UI.UserControl
	{
		public GMultiMedia()
		{
			EnableViewState = true;
		}

		public string SessionHandlerObjectName
		{
			get
			{
				String s = (String)ViewState["SessionHandlerObjectName"];
				return ((s == null) ? "[" + this.ID + "]" : s);
			}

			set
			{
				ViewState["SessionHandlerObjectName"] = value;
			}
		}

		public string Identifier
		{
			get
			{
				String s = (String)ViewState["Identifier"];
				return ((s == null) ? "" : s);
			}

			set
			{
				ViewState["Identifier"] = value;
			}
		}

		public string ImageFit
        {
            get
            {
                String s = (String)ViewState["ImageFit"];
                return ((s == null) ? "contain" : s);
            }

            set
            {
                ViewState["ImageFit"] = value;
            }
        }

		public string NavigationReference
		{
			get
			{
				return (String)ViewState["NavigationReference"];			
			}

			set
			{
				ViewState["NavigationReference"] = value;
			}
		}

		public string EmptyImage
		{
			get
			{
				if (ViewState["EmptyImage"] == null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["EmptyImage"];
				}
			}
			set
			{
				ViewState["EmptyImage"] = value;
			}
		}

		public string Skin
		{
			get
			{
				if (ViewState["Skin"] == null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["Skin"];
				}
			}
			set
			{
				ViewState["Skin"] = value;
			}
		}

		public string CssClass
		{
			get
			{
				if (ViewState["CssClass"] == null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["CssClass"];
				}
			}
			set
			{
				ViewState["CssClass"] = value;
			}
		}

		public Unit Width
		{
			get
			{
				Unit u = (Unit)ViewState["Width"];
				return ((u == null) ? new Unit() : u);
			}

			set
			{
				ViewState["Width"] = value;
			}
		}

		public Unit Height
		{
			get
			{
				Unit u = (Unit)ViewState["Height"];
				return ((u == null) ? new Unit() : u);
			}

			set
			{
				ViewState["Height"] = value;
			}
		}

		public Unit Top
		{
			get
			{

				if (ViewState["Top"] == null)
					return new Unit();

				Unit u = (Unit)ViewState["Top"];
				return ((u == null) ? new Unit() : u);
			}

			set
			{
				ViewState["Top"] = value;
			}
		}

		public Unit Left
		{
			get
			{
				if (ViewState["Left"] == null)
					return new Unit();

				Unit u = (Unit)ViewState["Left"];
				return ((u == null) ? new Unit() : u);
			}

			set
			{
				ViewState["Left"] = value;
			}
		}

		public bool Responsive
        {
            get
            {
                if (ViewState["Responsive"] != null && ViewState["Responsive"].ToString() == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                ViewState["Responsive"] = value;
            }
        }

		public bool Disabled
		{
			get
			{
				if (ViewState["Disabled"] == null)
				{
					return false;
				}
				else
				{
					return (bool)ViewState["Disabled"];
				}
			}
			set
			{
				ViewState["Disabled"] = value;
			}
		}

		public bool ShowDownloadLink
        {
            get
            {
                if (ViewState["ShowDownloadLink"] == null)
                {
                    return false;
                }
                else
                {
                    return (bool)ViewState["ShowDownloadLink"];
                }
            }
            set
            {
                ViewState["ShowDownloadLink"] = value;
            }
        }

		public bool CanUploadFile
		{
			get
			{
				if (ViewState["CanUploadFile"] == null)
				{
					return true;
				}
				else
				{
					return (bool)ViewState["CanUploadFile"];
				}
			}
			set
			{
				ViewState["CanUploadFile"] = value;
			}
		}

		public bool ShowImage
		{
			get
			{
				if (ViewState["ShowImage"] == null)
				{
					return true;
				}
				else
				{
					return (bool)ViewState["ShowImage"];
				}
			}
			set
			{
				ViewState["ShowImage"] = value;
			}
		}

		public bool SaveAsFile
		{
			get
			{
				if (ViewState["SaveAsFile"] == null)
				{
					return false;
				}
				else
				{
					return (bool)ViewState["SaveAsFile"];
				}
			}
			set
			{
				ViewState["SaveAsFile"] = value;
			}
		}

		public string Path
		{
			get
			{
				if (ViewState["Path"] == null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["Path"];
				}
			}
			set
			{
				ViewState["Path"] = value;
			}
		}

		public bool CanDownloadFile
		{
			get
			{
				if (ViewState["CanDownloadFile"] == null)
				{
					return true;
				}
				else
				{
					return (bool)ViewState["CanDownloadFile"];
				}
			}
			set
			{
				ViewState["CanDownloadFile"] = value;
			}
		}

		public int BorderWidth
		{
			get
			{
				if (ViewState["BorderWidth"] == null)
				{
					return 1;
				}
				else
				{
					return (int)ViewState["BorderWidth"];
				}
			}
			set
			{
				ViewState["BorderWidth"] = value;
			}
		}
		
		public int TrimFileName
        {
            get
            {
                if (ViewState["TrimFileName"] == null)
                {
                    return 17;
                }
                else
                {
                    return (int)ViewState["TrimFileName"];
                }
            }
            set
            {
                ViewState["TrimFileName"] = value;
            }
        }

		public string Text
		{
			get
			{
				if (ViewState["Text"] == null || ViewState["Text"].ToString() == "")
				{
					return "Upload";
				}
				else
				{
					return (string)ViewState["Text"];
				}
			}
			set
			{
				ViewState["Text"] = value;
			}
		}

		public bool EncryptedFile
		{
			get
			{
				if (ViewState["EncryptedFile"] == null)
				{
					return false;
				}
				else
				{
					return (bool)ViewState["EncryptedFile"];
				}
			}
			set
			{
				ViewState["EncryptedFile"] = value;
			}
		}

		public int MaxFileSize
		{
			get
			{
				if (ViewState["MaxFileSize"] == null)
				{
					return 1;
				}
				else
				{
					return (int)ViewState["MaxFileSize"];
				}
			}
			set
			{
				ViewState["MaxFileSize"] = value;
			}
		}

		public string AllowFileExtensions
		{
			get
			{
				if (ViewState["AllowFileExtensions"] == null)
				{
					return "";
				}
				else
				{
					return (string)ViewState["AllowFileExtensions"];
				}
			}
			set
			{
				ViewState["AllowFileExtensions"] = value;
			}
		}

		protected void AsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
		{
			byte[] imageData = null;
			byte[] file = null;
			byte[] fname = null;
			
			Thumbnail.Width = Unit.Pixel(200);
			Thumbnail.Height = Unit.Pixel(150);

			try
			{
				using (Stream stream = e.File.InputStream)
				{
					imageData = new byte[stream.Length];
					stream.Read(imageData, 0, (int)stream.Length);
					Thumbnail.DataValue = imageData;
				}

				string FileName = e.File.FileName;
				fname = System.Text.Encoding.Default.GetBytes("|" + FileName);				

				if (SaveAsFile)
				{
					file = imageData;

					//Gera índice para a imagem no formato ddMMyyyyHHmmss_nome_do_arquivo
					string indice = DateTime.Now.ToString("ddMMyyyyHHmmss");
					FileName = System.IO.Path.Combine(Path, indice + "_" + FileName);
				}
				else
				{
					file = new byte[imageData.Length + fname.Length];
					fname.CopyTo(file, file.Length - fname.Length);
					imageData.CopyTo(file, 0);
				}

				string base64 = System.Convert.ToBase64String(file);
				Session[SessionHandlerObjectName] = base64;
				Session[SessionHandlerObjectName + "FileName"] = FileName;			

			}
			catch
			{
				throw;
			}
			finally
			{
				imageData = null;
				fname = null;
				file = null;				
			}
		}
		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (this.Attributes["TabIndex"] != null)
			{
				AsyncUpload1.TabIndex = Convert.ToInt16(this.Attributes["TabIndex"]);
			}
			// retira o link do ajax
			Control ParentControl = this.Parent;
			while (ParentControl != null)
			{
				if (ParentControl is RadAjaxPanel)
				{
					ScriptManager ScrManager = Page.FindControl("MainScriptManager") as ScriptManager;
					if (ScrManager != null)
					{
						ScrManager.RegisterPostBackControl(DownloadLink);
					}
					break;
				}
				ParentControl = ParentControl.Parent;
			}	
			AsyncUpload1.Attributes["Identifier"] = this.Identifier;
			BorderPanel.CssClass = this.CssClass;
		}

		private string BuscaNomeArquivo(string arquivo)
		{
			string nome = System.IO.Path.GetFileName(arquivo);
			return nome.Substring(nome.IndexOf("_") + 1);
		}

		protected override void OnPreRender(EventArgs e)
		{
			if(Skin != "")
				AsyncUpload1.Skin = Skin;
			AsyncUpload1.MaxFileSize = this.MaxFileSize;
            AsyncUpload1.Visible = (!Disabled && CanUploadFile);
			AsyncUpload1.Localization.Select = Text;

			if (!string.IsNullOrEmpty(this.AllowFileExtensions))			
				AsyncUpload1.AllowedFileExtensions = this.AllowFileExtensions.Split(',');
			
			double PhotoWidth = Width.Value;
			double PhotoHeight = 0;

			double ButtonHeight = 45;

            if(Responsive)
            {

                BorderPanel.Style["position"] = "relative";
			    BorderPanel.Style["top"] = Top.ToString();
			    BorderPanel.Style["left"] = Left.ToString();
			    BorderPanel.Style["width"] = Width.ToString();
			    BorderPanel.Style["height"] = Height.ToString();

            }
            else
            {
			    BorderPanel.Style["position"] = "absolute";
                BorderPanel.Style["top"] = Top.ToString();
                BorderPanel.Style["left"] = Left.ToString();
                BorderPanel.Style["width"] = Width.ToString();
                BorderPanel.Style["height"] = Height.ToString();
            }

			int ContentStart = 0;
			int ContentLenght = 0;
			string FileName = "";
			byte[] FileContent = null;

			if (Session[SessionHandlerObjectName] != null)
			{
				if (SaveAsFile)
				{
					FileContent = Convert.FromBase64String((string)Session[SessionHandlerObjectName]);

					//FileName = new FileInfo((Session[SessionHandlerObjectName + "FileName"].ToString())).Name;
					FileName = BuscaNomeArquivo(Session[SessionHandlerObjectName + "FileName"].ToString());

					ContentLenght = FileContent.Length;
				}
				else
				{
					MediaHandlerHelper.ParseFileContent(Convert.FromBase64String((string)Session[SessionHandlerObjectName]), out ContentStart, out ContentLenght, out FileName);
					FileContent = (new System.IO.MemoryStream(Convert.FromBase64String((string)Session[SessionHandlerObjectName]), ContentStart, ContentLenght)).ToArray();
				}
			}
			else
			{
				FileContent = GetDefaultImage(ref ContentLenght);
			}

			SetResponseImage(ContentLenght == FileContent.Length? 0: ContentStart, ContentLenght, FileContent, FileName);

			PhotoHeight = Height.Value;
            if (ShowDownloadLink || (!Disabled && (CanUploadFile || CanDownloadFile)))
			{
				if (PhotoHeight > ButtonHeight) PhotoHeight = PhotoHeight - ButtonHeight; 
			}

            if (Responsive)
            {
                ImagePanel.Style["position"] = "relative";
                ImagePanel.Style["top"] = "0px";
                ImagePanel.Style["left"] = "0px";
                ImagePanel.Style["width"] = PhotoWidth.ToString() + "%";
                ImagePanel.Style["height"] = PhotoHeight.ToString() + "px";
            }
            else
            {
                ImagePanel.Style["position"] = "absolute";
				ImagePanel.Style["top"] = "0px";
				ImagePanel.Style["left"] = "0px";
				ImagePanel.Style["width"] = PhotoWidth.ToString() + "px";
				ImagePanel.Style["height"] = PhotoHeight.ToString() + "px";
            }

            if (ShowImage)
			{
				if (Responsive)
				{
					Thumbnail.Width = Unit.Percentage(Convert.ToInt32(PhotoWidth));

				}
				else
				{
					Thumbnail.Width = Unit.Pixel(Convert.ToInt32(PhotoWidth));
				}
				Thumbnail.Height = Unit.Pixel(Convert.ToInt32(PhotoHeight));
				//Thumbnail.ImageAlign = ImageAlign.Bottom;
				Thumbnail.AutoAdjustImageControlSize = false;
                Thumbnail.Style["object-fit"] = ImageFit;
				ImagePanel.BorderWidth = BorderWidth;
				ImagePanel.Visible = true;
			}
			else
			{
				ImagePanel.Visible = false;
			}

			if (ShowDownloadLink || (!Disabled && (CanUploadFile || CanDownloadFile)))
			{
				ButtonHeight = ButtonHeight - 5;

				if (Responsive)
                {
                    FramePanel.Style["position"] = "relative";
                    FramePanel.Style["top"] = "0px";
                    FramePanel.Style["left"] = "0px";
                    FramePanel.Style["width"] = Width.ToString();
                    FramePanel.Style["height"] = ButtonHeight.ToString() + "px";
                    FramePanel.Visible = true;
                }
                else
                {
                    FramePanel.Style["position"] = "absolute";
					FramePanel.Style["top"] = ShowImage? new Unit(PhotoHeight + 5).ToString(): "0px";
				    FramePanel.Style["left"] = "5px";
				    FramePanel.Style["width"] = Width.ToString();
				    FramePanel.Style["height"] = ButtonHeight.ToString() + "px";
				    FramePanel.Visible = true;
                }

                if (ShowDownloadLink || CanDownloadFile)
				{
					DownloadLink.Text = FileNameLenght(FileName);
					NameLabel.Style["display"] = "none";
					DownloadLink.Enabled = !string.IsNullOrEmpty(DownloadLink.Text);
				}
				else
				{
					NameLabel.Text = FileNameLenght(FileName);
					DownloadLink.Style["display"] = "none";
				}
                if (!Disabled && FileName.Length > 0 && CanUploadFile)
				{
					CloseLink.Style["display"] = "block";
				}
				else
				{
					CloseLink.Style["display"] = "none";
				}
			}
			else
			{
				FramePanel.Visible = false;
			}

			if (!String.IsNullOrEmpty(NavigationReference))
			{
				DownloadLink.Attributes["onclick"] = string.Format("NavigateTargetByReference('{0}?File={1}', '{2}');return false;", Page.Request.Url.MakeRelative(new Uri(HttpContext.Current.Request.UrlReferrer, "/UserControls/GMultiMedia.aspx")), SessionHandlerObjectName, NavigationReference);
			}
		}

		protected string FileNameLenght(string fileName)
		{
			if (fileName.Length <= TrimFileName || TrimFileName == 0) return fileName;
			int larguraBotaoAsyncUpload1 = 70;
			int valorBaseCaracteres = 17;			
			int larguraThumbnail = Convert.ToInt32(Thumbnail.Width.Value);
			larguraThumbnail = larguraThumbnail - larguraBotaoAsyncUpload1;			
			int valorBaseLarguraThumbnail = 200 - larguraBotaoAsyncUpload1;
			int valor = ((valorBaseCaracteres * (larguraThumbnail)) / valorBaseLarguraThumbnail) - 1;
			// 6 = ( 2("..") + 4(".pdf") )
			// valor - 6 
			if (valor <= 6) valor = 7;
			if (valor >= fileName.Length) return fileName;
			return string.Format("{0}..{1}", fileName.Substring(0,(valor - 6)), System.IO.Path.GetExtension(fileName));			
		}

		protected void DeleteImage_Click(object sender, EventArgs e)
		{
			Session[SessionHandlerObjectName] = null;
			Session[SessionHandlerObjectName + "FileName"] = null;
		}

		protected void DownloadLink_Click(object sender, EventArgs e)
		{
			if (Session[SessionHandlerObjectName] != null)
			{
				byte[] FileContent = Convert.FromBase64String((string)Session[SessionHandlerObjectName]);
				int ContentStart;
				int ContentLenght;
				string FileName;
				if (!SaveAsFile)
				{
					MediaHandlerHelper.ParseFileContent(FileContent, out ContentStart, out ContentLenght, out FileName);
				}
				else
				{
					FileName = BuscaNomeArquivo(Session[SessionHandlerObjectName + "FileName"].ToString());
					ContentStart = 0;
					ContentLenght = FileContent.Length;
				}
				HttpContext.Current.Response.ContentType = System.Web.MimeMapping.GetMimeMapping(FileName);
				HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + FileName + "\"");
				HttpContext.Current.Response.Clear();
				HttpContext.Current.Response.OutputStream.Write(FileContent, ContentStart, ContentLenght);
				HttpContext.Current.Response.End();
			}
		}

		private byte[] GetDefaultImage(ref int ContentLenght)
		{
			return GetDefaultImage(ref ContentLenght, null);
		}

		private byte[] GetDefaultImage(ref int ContentLenght, string FileName)
		{
			byte[] FileContent;
			Stream ImageStream;
			if (FileName == null || FileName.Length == 0)
			{
				ImageStream = new FileStream(HttpContext.Current.Server.MapPath(EmptyImage != null && EmptyImage != ""? EmptyImage: "~\\Images\\naoDisponivel.jpg"), FileMode.Open, FileAccess.Read);
			}
			else
			{
				System.Drawing.Bitmap Bmp = new System.Drawing.Bitmap(300, 300, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
				System.Drawing.Graphics Graph = System.Drawing.Graphics.FromImage(Bmp);

				System.Drawing.Font DrawFont = new System.Drawing.Font("Arial", 10);
				System.Drawing.SizeF DrawSize = Graph.MeasureString(FileName, DrawFont);

				Bmp = new System.Drawing.Bitmap(Convert.ToInt32(DrawSize.Width + 50), Convert.ToInt32(DrawSize.Height + 50), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
				Graph = System.Drawing.Graphics.FromImage(Bmp);

				Graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				Graph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
				Graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
				Graph.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
				Graph.FillRectangle(System.Drawing.Brushes.White, new System.Drawing.Rectangle(0, 0, 300, 300));
				Graph.Flush();

				Graph.DrawString(FileName, DrawFont, System.Drawing.Brushes.Black, new System.Drawing.PointF(25, 25));
				ImageStream = new MemoryStream();
				Bmp.Save(ImageStream, System.Drawing.Imaging.ImageFormat.Png);
				ImageStream.Seek(0, SeekOrigin.Begin);
			}
			FileContent = new byte[ImageStream.Length];
			ImageStream.Read(FileContent, 0, (int)ImageStream.Length);
			ImageStream.Close();
			ContentLenght = FileContent.Length;
			ImageStream.Close();
			ImageStream.Dispose();
			return FileContent;
		}

		private void SetResponseImage(int ContentStart, int ContentLenght, byte[] FileContent, string FileName)
		{
			try
			{
				System.Drawing.Image vgFoto = System.Drawing.Image.FromStream(new System.IO.MemoryStream(FileContent, ContentStart, ContentLenght));
				Thumbnail.DataValue = FileContent;
				vgFoto.Dispose();
			}
			catch
			{
				double PhotoHeight = Height.Value;
				if (!Disabled && (CanUploadFile || CanDownloadFile))
				{
					PhotoHeight = PhotoHeight - 30;
				}
				System.Drawing.Bitmap newPicf = new System.Drawing.Bitmap(100,100);
				System.Drawing.Graphics grf = System.Drawing.Graphics.FromImage(newPicf);

				System.Drawing.Font font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
				System.Drawing.SizeF TextSize = grf.MeasureString(FileName, font);

				System.Drawing.Bitmap newPic = new System.Drawing.Bitmap((int)Math.Max(TextSize.Width + 40, Width.Value), (int)Math.Max(TextSize.Height + 40, PhotoHeight));
				System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(newPic);
				gr.DrawString(FileName, font, System.Drawing.Brushes.Black, new System.Drawing.PointF((newPic.Width - TextSize.Width) / 2, (newPic.Height - TextSize.Height) / 2));
				MemoryStream ms = new MemoryStream();
				newPic.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
				Thumbnail.DataValue = ms.ToArray();
				ms.Close();
				ms.Dispose();
				gr.Dispose();
				newPic.Dispose();
			}
		}

		public void SaveFile()
		{
			try
			{
				byte[] bArquivo;

				string arquivo = Server.MapPath(Session[this.SessionHandlerObjectName + "FileName"].ToString());
				
				byte[] currentContent = new byte[0];
                if (System.IO.File.Exists(arquivo))
                {
                    currentContent = System.IO.File.ReadAllBytes(arquivo);
                }

				bArquivo = Convert.FromBase64String(Session[this.SessionHandlerObjectName].ToString());

				if (EncryptedFile)
					bArquivo = Crypt.Encript_AES(bArquivo);

				File.WriteAllBytes(arquivo, bArquivo);

			}
			catch (Exception)
			{
			}
		}

		public void DeleteFile()
		{
			try
			{
				if(Session[this.SessionHandlerObjectName + "FileName"] != null && File.Exists(Server.MapPath(Session[this.SessionHandlerObjectName + "FileName"].ToString())))
					File.Delete(Server.MapPath(Session[this.SessionHandlerObjectName + "FileName"].ToString()));
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
