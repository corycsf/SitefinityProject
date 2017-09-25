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
            <sf:SitefinityLabel ID="titleLabel_read" runat="server" WrapperTagName="div" HideIfNoText="false" CssClass="sfTxtLbl" />
            <sf:SitefinityLabel ID="viewControl" runat="server" WrapperTagName="div" HideIfNoText="false" CssClass="sfRTFContent" />
        </sf:ConditionalTemplate>
        <sf:ConditionalTemplate Left="DisplayMode" Operator="Equal" Right="Write" runat="server">
            <sf:ResourceLinks ID="resourcesLinks2" runat="server" UseEmbeddedThemes="true" UseBackendTheme="True">
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
                    Content=""
                    OnClientLoad="OnClientLoad">
                    <ContextMenus>
                        <telerik:EditorContextMenu TagName="P">
                            <telerik:EditorTool Name="VideoProperties" Text="Video Properties" />
                        </telerik:EditorContextMenu>
                    </ContextMenus>
                    <FlashManager ViewPaths="~/Files" UploadPaths="~/Files" DeletePaths="~/Files" />
                    
                </telerik:RadEditor>
                <sf:RadEditorCustomDialogsExtender runat="server" ID="editorCustomDialogsExtender" TargetControlID="editControl" />
                <sf:SitefinityLabel ID="descriptionLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfDescription" />
                <sf:SitefinityLabel ID="exampleLabel" runat="server" WrapperTagName="div" HideIfNoText="true" CssClass="sfExample" />
                <div id="myModal" class="modal">

                    <!-- Modal content -->
                    <form id="video-form">
                        <div class="modal-content">
                            <div class="form-group">
                                <label for="videoId">Video ID</label>
                                <input id="videoId" type="text" />
                            </div>
                            <div class="form-group">
                                <label for="set-autoplay">Auto play</label>
                                <select id="set-autoplay" class="video-select form-control"></select>
                            </div>
                            <div class="form-group">
                                <label for="set-controls">Show Controls</label>
                                <select id="set-controls" class="video-select form-control"></select>
                            </div>
                            <div class="form-group">
                                <label for="set-loop">Loop</label>
                                <select id="set-loop" class="video-select form-control"></select>
                            </div>
                            <div class="form-group">
                                <label for="set-info">Show Info</label>
                                <select id="set-info" class="video-select form-control"></select>
                            </div>
                            <div class="video-buttons">
                                <input id="video-btn" type="button" value="Submit">
                                <input id="close-video-modal" type="button" value="Close">
                            </div>
                        </div>
                    </form>
                </div>
            </asp:Panel>
        </sf:ConditionalTemplate>
    </Templates>

</sf:ConditionalTemplateContainer>


<script>


    function OnClientLoad(editor, args) {
        // custom toolbox item handler
        
        Telerik.Web.UI.Editor.CommandList["YouTube"] = function (commandName, editor, args) {
            //var videoID = prompt("Enter the YouTube VIDEO ID only");
            //$('#videoID').val() = videoID;
            //if (videoID === "") return;
            openModal(editor, "");
            // simple attempt to prevent user from pasting the full url
            

            // insert the shortcode with the video id
            //editor.pasteHtml(String.format("<p class='video-link' value='{0}' properties='properties'>[youtube:{0}]</p>", videoID))


        };

        var modal = document.getElementById('myModal');

        // Get the closeButton element that closes the modal
        var closeButton = $("#close-video-modal")[0];

        // When the user clicks on closeButton (x), close the modal
        closeButton.onclick = function () {
            modal.style.display = "none";
        }

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
        
        setupContextMenu(editor, "P");

    }
    Telerik.Web.UI.Editor.CommandList["VideoProperties"] = function (commandName, editor, args) {
        var existingVideoID = editor.getSelectedElement().getAttribute('value');
        var videoData = null;
        console.log(editor.getSelectedElement());
        console.log(editor.getSelectedElement().innerHTML);
        openModal(editor, existingVideoID);

    };
    function openModal(editor, videoID) {
        var modal = document.getElementById('myModal');
        modal.style.display = "block";

        var sel = editor.getSelectedElement();
        
        $('#videoId').val(videoID);

        var videoSelect = $('.video-select');

        $.each(videoSelect, function (index, value) {
            $(value).append('<option value=1>Yes</option><option value=0>No</option>');
        });

        $('#video-btn').click(function () {

            modal.style.display = "none";
            updateShortCode(editor, sel);

        });
    }
    function updateShortCode(editor, sel, videoID) {
        
        var videoID = $('#videoId').val();
        
        if (videoID.indexOf("://") != -1) {
            alert("Please enter the video id only, not the full url.");
            return;
        }

        
        var autoPlay = $('#set-autoplay').val();
        var controls = $('#set-controls').val();
        var loop = $('#set-loop').val();
        var info = $('#set-info').val();
        
        if (videoID === "") return;

        editor.pasteHtml(String.format("<p class='video-link' value='{0}' properties='properties'>[youtube:ID={0},autoplay={1},controls={2},loop={3},info={4}]</p>", videoID, autoPlay, controls, loop, info));
        
    }
    function setupContextMenu(editor, tagname) {
        var contextMenu = editor.getContextMenuByTagName(tagname);

        if (!contextMenu) return;

        //Attach to the context menu show event, obtain editor selection and determine which tools to show
        contextMenu.add_show(function () {
            setTimeout(function () {
                //Must be an p, the context menu would not fire     
                var sel = editor.getSelectedElement();
                
                if (sel.tagName == "P") {

                    //An array of menu item objects     
                    var menuItems = contextMenu.get_items();

                    //The custom menu item     
                    var customItem = menuItems[menuItems.length - 1];

                    //get ContextMenuElement    
                    var contextMenuElement = $telerik.$("div.reDropDownBody")[0];

                    //Check for custom attribute     
                    if (sel.getAttribute("properties")) {
                        //Enable custom tool                             
                        customItem.get_element().style.display = "";


                        contextMenuElement.style.height = contextMenuElement.firstChild.offsetHeight + "px";

                        // Fix vertical scroll in IE   
                        contextMenuElement.style.overflow = 'hidden';
                    }
                    else {
                        //Hide custom tool     
                        customItem.get_element().style.display = "none";
                        customItem.get_element().parentNode.style.display = "none";

                        contextMenuElement.style.height = contextMenuElement.firstChild.offsetHeight + "px";

                        // Fix vertical scroll in IE   
                        contextMenuElement.style.overflow = 'hidden';

                        // If only menu item hide it
                        if (menuItems.length == 1) {
                            contextMenuElement.style.display = "none";
                        }
                    }
                }
            }, 0);
        });
    }
</script>

