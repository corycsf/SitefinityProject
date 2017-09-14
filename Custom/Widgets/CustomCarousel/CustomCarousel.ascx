﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomCarousel.ascx.cs" Inherits="SitefinityWebApp.Custom.Widgets.CustomCarousel.CustomCarousel" %>


<div class="content-wrapper">
    <div class="content-panel main-content">
        <div class="content-head">
            <div class="car-wrapper">

                <asp:Repeater ID="imageRptr" runat="server">
                    <HeaderTemplate></HeaderTemplate>
                    <ItemTemplate>
                        <div class="car-row">

                            <div style='<%# "background: url('" + Eval("Url") + "')" %>'>
                                <span><%# Eval("Title") %></span>
                            </div>

                        </div>
                    </ItemTemplate>
                    <FooterTemplate></FooterTemplate>

                </asp:Repeater>
            </div>

        </div>
    </div>
</div>
<script type="text/javascript" src="//cdn.jsdelivr.net/jquery.slick/1.6.0/slick.min.js"></script>
<script type="text/javascript" src="~/Custom/Content/Scripts/carousel.js"></script>
