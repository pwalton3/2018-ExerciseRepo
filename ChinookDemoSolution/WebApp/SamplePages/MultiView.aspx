﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiView.aspx.cs" Inherits="WebApp.SamplePages.MultiView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>MultiView Control Setup</h1>
    <div class="row">
        <div class="offset-1">
            <asp:Menu ID="Menu1" runat="server"
                 Font-Size="Large" Orientation="Horizontal" StaticMenuItemStyle-HorizontalPadding="50px" 
                 StaticSelectedStyle-BackColor="Turquoise" CssClass="tabs" StaticSelectedStyle-CssClass="selectedTab" OnMenuItemClick="Menu1_MenuItemClick" ActiveViewIndex="0" >
                <Items>
                    <asp:MenuItem Text="Page 1" Selected="true" Value="0"></asp:MenuItem>
                    <asp:MenuItem Text="Page 2" Selected="true" Value="1"></asp:MenuItem>
                    <asp:MenuItem Text="Page 3" Selected="true" Value="2"></asp:MenuItem>

                </Items>
            </asp:Menu>
        </div>
    </div>

    <div class="row">
        <div class="offset-1">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <%-- add a view control for each "webpage" view you need --%>
                <asp:View ID="View1" runat="server">
                    <h3>View Page 1</h3>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="IODataV1" runat="server"></asp:TextBox>
                    <asp:Button ID="SendToV2FromV1" runat="server" Text="Send To V2" OnClick="SendToV2FromV1_Click" />
                    <asp:Button ID="SendToV3FromV1" runat="server" Text="Send To V3" OnClick="SendToV3FromV1_Click" />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <h3>View Page 2</h3>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="IODataV2" runat="server"></asp:TextBox>
                    <asp:Button ID="SendToV1FromV2" runat="server" Text="Send To V1" OnClick="SendToV1FromV2_Click" />
                    <asp:Button ID="SendToV3FromV2" runat="server" Text="Send To V3" OnClick="SendToV3FromV2_Click" />
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <h3>View Page 3</h3>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="IODataV3" runat="server"></asp:TextBox>
                    <asp:Button ID="SendToV1FromV3" runat="server" Text="Send To V1" OnClick="SendToV1FromV3_Click" />
                    <asp:Button ID="SendToV2FromV3" runat="server" Text="Send To V2" OnClick="SendToV2FromV3_Click" />
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
