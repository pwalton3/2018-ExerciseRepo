﻿<%@ Page Title="SearchByDDL" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchByDDL.aspx.cs" Inherits="WebApp.SamplePages.SearchByDDL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search Albums by Artist</h1>
    <div class="row">
        <div class="offset-3">
            <asp:Label ID="Label1" runat="server" Text="Select an Artist"></asp:Label>&nbsp;&nbsp;
            <asp:DropDownList ID="ArtistList" runat="server">

            </asp:DropDownList>&nbsp;&nbsp;
            <asp:LinkButton ID="SearchAlbums" runat="server" OnClick="SearchAlbums_Click">Search<i class="fa fa-search"></i></asp:LinkButton>

        </div>
    </div>
    <br /><br />
    <div class="row">
        <div class="offset-3">
            <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        </div>
    </div>
    <br /><br />
    <div class="row">
        <div class="offset-3">
            <asp:GridView ID="ArtistAlbumsList" runat="server" AutoGenerateColumns="False">

                <Columns>
                    <asp:TemplateField HeaderText="Album">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Released">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("ReleaseYear") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center">
                        </ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Artist">
                        <ItemTemplate>
                            <asp:DropDownList ID="ArtistNameList" runat="server" 
                                DataSourceID="ArtistNameListODS" 
                                DataTextField="DisplayField" 
                                DataValueField="ValueField" Width="250px"
                                 selectedvalue='<%# Eval("ArtistId") %>'>
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No albums for display
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="ArtistNameListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Artists_ddlList" TypeName="ChinookSystem.BLL.ArtistController">

            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
