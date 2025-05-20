<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GMultiMedia.ascx.cs" Inherits="COMPONENTS.GMultiMedia" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel runat="server" ID="BorderPanel">
	<asp:Panel runat="server" ID="ImagePanel" Style="border-style:dashed; border-color:#ccc; text-align: center; border-radius: 5px;">
		<telerik:RadBinaryImage runat="server" ID="Thumbnail" ResizeMode="Fit" Style="top: 0px;
			left: 0px; right: 0px; bottom: 0px; margin: auto; position: absolute; height:100%" AlternateText="Thumbnail"
			CssClass="binary-image" />
	</asp:Panel>
	<asp:Panel runat="server" ID="FramePanel" Style="margin-top: 5px;" class="qsf-demo-canvas">
		<telerik:RadAsyncUpload runat="server" ID="AsyncUpload1" MaxFileInputsCount="1" OnClientFileUploaded="fileUploaded" Culture="en-US"
			OnFileUploaded="AsyncUpload1_FileUploaded" CssClass="FileUploader" OnClientValidationFailed="validationFailed">
			<Localization Select="Upload" />
		</telerik:RadAsyncUpload>
		<asp:Label runat="server" ID="NameLabel" CssClass="NameLabel"></asp:Label>
		<asp:LinkButton runat="server" ID="DownloadLink" OnClick="DownloadLink_Click" CssClass="DownloadLink"></asp:LinkButton>
		<asp:ImageButton ImageUrl="~/UserControls/close.png" runat="server" ID="CloseLink" OnClick="DeleteImage_Click" CssClass="CloseLink"></asp:ImageButton>
	</asp:Panel>
	<script type="text/javascript">
		function fileUploaded(sender, args) {
            ExecuteCommandRequest("FileUploaded", sender.get_element().getAttribute("identifier"));
		}
		function validationFailed(sender, eventArgs) {
			alert(getErrorMessage(sender, eventArgs));
            ExecuteCommandRequest("FileUploaded", sender.get_element().getAttribute("identifier"));
		}
        function getErrorMessage(sender, args) {
            var fileExtention = args.get_fileName().substring(args.get_fileName().lastIndexOf('.') + 1, args.get_fileName().length);
            if (args.get_fileName().lastIndexOf('.') != -1) {
                if (sender.get_allowedFileExtensions() && sender.get_allowedFileExtensions().indexOf(fileExtention) == -1) {
                    return ("O tipo de arquivo não é suportado!");
                }
                else {
                    return ("O arquivo ultrapassa o limite estabelecido de " + sender._maxFileSize / 1024 + " Kb");
                }
            }
            else {
                return ("O arquivo não tem uma extensão suportada.");
            }
        }
	</script>
	<style type="text/css">
		.qsf-demo-canvas .invalid
		{
			display: none;
		}
		
		.ruFileWrap
		{
			float: right;
		}
		
		.qsf-demo-canvas
		{
			width: 100%;
		}
		
		.FileUploader
		{
			width: 100% !important;
			float: right;
			border: 1px solid #ccc;
			border-radius: 5px;
			padding: 2px;
		}

		.ruFileInput {
			height: 100%;
			width: 100%;
		}
		
		.ruInputs li {
			margin:0px !important;
		}
		
		.DownloadLink, .NameLabel
		{
			float: left;
			position:absolute;
			margin: 7px 10px;
			font-family: "Segoe ui";
		}
		
		.CloseLink
		{
			float: right;
			margin-top: -29px;
			margin-right: 75px;			
			cursor:pointer;
		}
		
		/** Customize the input*/
		.qsf-demo-canvas .RadUpload input.ruFakeInput 
		{
			display: none;
		}
		
		.ruButton .ruBrowse .ruButtonHover
		{
			font-weight: bold;
		}
	</style>
</asp:Panel>
