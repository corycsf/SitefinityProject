<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentBlockTemplate.ascx.cs" Inherits="SitefinityWebApp.Templates.ContentBlockTemplate" %>
<%@ Register TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI.PublicControls.BrowseAndEdit"
    Assembly="Telerik.Sitefinity" %>
<asp:Literal ID="contentHtml" runat="server"></asp:Literal>
<sf:BrowseAndEditToolbar ID="browseAndEditToolbar" runat="server" Mode="Edit" Visible="false">
</sf:BrowseAndEditToolbar>
<asp:PlaceHolder ID="socialShareContainer" runat="server"></asp:PlaceHolder>