<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiView.aspx.cs" Inherits="WebApp.SamplePages.MultiView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>MultiView Control Setup</h1>
    <div class="row">
        <div class="offset-1">
            <asp:Menu ID="Menu1" runat="server"
                 Font-Size="Large" Orientation="Horizontal" StaticMenuItemStyle-HorizontalPadding="50px" 
                 StaticSelectedStyle-BackColor="Turquoise" CssClass="tabs" StaticSelectedStyle-CssClass="selectedTab" OnMenuItemClick="Menu1_MenuItemClick" >
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
            <asp:MultiView ID="MultiView1" runat="server">
                <%-- add a view control for each "webpage" view you need --%>
                <asp:View ID="View1" runat="server">
                    <h3>View Page 1</h3>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <h3>View Page 2</h3>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <h3>View Page 3</h3>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
