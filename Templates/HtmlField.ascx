<%@ Control Language="C#" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI.Extenders" TagPrefix="sf" %>
<sf:ResourceLinks ID="ResourceLinks1" runat="server" UseEmbeddedThemes="false">
    <sf:ResourceFile Name="~/Templates/HtmlField.css" />
</sf:ResourceLinks>
<sf:ConditionalTemplateContainer ID="conditionalTemplate" runat="server">
    <Templates>
        <sf:ConditionalTemplate Left="DisplayMode" Operator="Equal" Right="Read" runat="server">
            <sf:SitefinityLabel id="titleLabel_read" runat="server" WrapperTagName="div" HideIfNoText="false" CssClass="sfTxtLbl" />
            <sf:SitefinityLabel id="viewControl" runat="server" WrapperTagName="div" HideIfNoText="false" CssClass="sfRTFContent" />
        </sf:ConditionalTemplate>
        <sf:ConditionalTemplate Left="DisplayMode" Operator="Equal" Right="Write" runat="server">
            <sf:ResourceLinks id="resourcesLinks2" runat="server" UseEmbeddedThemes="true" UseBackendTheme="True">
                <sf:EmbeddedResourcePropertySetter Name="Telerik.Sitefinity.Resources.Themes.Default.Styles.EditorDialogs.css" Static="true" ControlID="editControl" ControlPropertyName="DialogsCssFile" />
                <sf:ResourceFile Name="Styles/Window.css" />
            </sf:ResourceLinks>
            <asp:Label ID="titleLabel_write" runat="server" CssClass="sfTxtLbl" AssociatedControlID="editControl" />
            <asp:LinkButton ID="expandLink" runat="server" OnClientClick="return false;" CssClass="sfOptionalExpander" />
            <%--NewLineBr="False" - removed because of bug 112126. The bug should be fixed in the next release of RadControls.--%>
            <asp:Panel ID="expandableTarget" runat="server" CssClass="sfEditorWrp sfClearfix">
                <telerik:RadEditor 
                    ID="editControl" 
                    runat="server" 
                    Skin="Default" 
                    Width="100%" 
                    Height="550px"
                    EnableResize="False"
                    EditModes="Design,HTML" 
                    DialogHandlerUrl="~/Telerik.Web.UI.DialogHandler.axd"
                    Content="">
                    <FlashManager ViewPaths="~/Files" UploadPaths="~/Files" DeletePaths="~/Files" />
                </telerik:RadEditor>
                <sf:RadEditorCustomDialogsExtender runat="server" id="editorCustomDialogsExtender" TargetControlID="editControl"/>
                <sf:SitefinityLabel id="descriptionLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfDescription" />
                <sf:SitefinityLabel id="exampleLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfExample" />
            </asp:Panel>
        </sf:ConditionalTemplate>
    </Templates>        
</sf:ConditionalTemplateContainer>

<script type="text/javascript">
        // custom toolbox item handler
        Telerik.Web.UI.Editor.CommandList["YouTube"] = function (commandName, editor, args) {
            var videoID = prompt("Enter the YouTube VIDEO ID only");
            if (videoID === "") return;

            // simple attempt to prevent user from pasting the full url
            if (videoID.indexOf("://") != -1) {
                alert("Please enter the video id only, not the full url.");
                return;
            }

            // insert the shortcode with the video id
            editor.pasteHtml(String.format("[youtube:{0}] ", videoID))
        };
    </script>