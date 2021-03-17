<%@ Page Title="ListViewODSCRUD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListViewODSCRUD.aspx.cs" Inherits="WebApp.SamplePages.ListViewODSCRUD" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Single Control ODS : CRUD</h1>
    <div class="row">
        <div class="offset-2">
            <blockquote class="alert alert-info">
                This page will use the asp:ListView control <br />
                This page will use ObjectDataSource with the ListView control<br />
                This page will use minimum code behind<br />
                This page will use the MessageUserControl for error handling<br />
                This page will demonstrate validation on the aspListView control<br />
            </blockquote>
        </div>
    </div>
    <div class ="row">
        <div class="offset-1">
            <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
            <asp:ValidationSummary ID="ValidationSummaryEdit" HeaderText="Following are concerns with your data:" ValidationGroup="egroup" runat="server" />
            <asp:ValidationSummary ID="ValidationSummaryInsert" HeaderText="Following are concerns with your data:" ValidationGroup="igroup" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="offset-1">
        <%-- REMINDER: to use the attribute DataKeyNames to get the  
            Delete function of you ListView CRUD to work
            
            the DataKeyNames attribute is set to you PK field
            
            the validation executes ONLY on the use of the Template by the user--%>
        <asp:ListView ID="AlbumList" runat="server" 
            DataSourceID="AlbumListODS"
            DataKeyNames="AlbumId" 
            InsertItemPosition="LastItem">

            <AlternatingItemTemplate>
                <tr style="background-color: #FFFFFF; color: #284775;">
                    <td>
                        <asp:Button runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you wish to delete this album?')" ID="DeleteButton" />
                        <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                    </td>
                    <td>
                        <asp:Label Text='<%# Eval("AlbumId") %>' runat="server" ID="AlbumIdLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" /></td>
                    <td>
                        <asp:Label runat="server" ID="ArtistIdLabel" />
                        <asp:DropDownList ID="ArtistList" runat="server" 
                            DataSourceID="ArtistListODS" 
                            DataTextField="DisplayField"
                            DataValueField="ValueField"
                            Enabled="false"
                            width="300px"
                             selectedValue='<%# Eval("ArtistId") %>' >

                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label Text='<%# Eval("ReleaseYear") %>' runat="server" ID="ReleaseYearLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("ReleaseLabel") %>' runat="server" ID="ReleaseLabelLabel" /></td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <%-- validation controls will be placed inside the associated Template
                    The ID of the validated control needs to be unique
                    The validation controls for a particular Template needs to be grouped--%>
                <asp:RequiredFieldValidator ID="RequiredTitleE" runat="server" ErrorMessage="Album title is required on edit!" ControlToValidate="ReleaseYearTextBoxE" Display="None" 
                     ValidationGroup="egroup">

                </asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredReleaseYearE" runat="server" ErrorMessage="Album title is required on edit!" ControlToValidate="TitleTextBoxE" Display="None"  ValidationGroup="egroup"></asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="RegExTitleE" runat="server" ErrorMessage="Album title is limited to 160 characters!" ControlToValidate="TitleTextBoxE" Display="None" ValidationGroup="egroup" ValidationExpression="^.{1,160}$"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegExReleaseLabelE" runat="server" ErrorMessage="Album label is limited to 50 characters!" ControlToValidate="ReleaseLabelTextBoxE" Display="None" ValidationGroup="egroup" ValidationExpression="^.{1,50}$"></asp:RegularExpressionValidator>

                <asp:CompareValidator ID="CompareReleaseYearE" runat="server" ErrorMessage="Year must be a number"
                     ControlToValidate="ReleaseYearTextBoxE" Display="None" Operator="DataTypeCheck" Type="Integer" ValidationGroup="egroup"></asp:CompareValidator>

                <asp:RangeValidator ID="RangeReleaseYearE" runat="server" ErrorMessage="Year must be between 1950 and this year" ControlToValidate="ReleaseYearTextBoxE" Display="None" ValidationGroup="egroup" MinimumValue="1950" MaximumValue="<%# DateTime.Today.Year %>"></asp:RangeValidator>
                <tr style="background-color: #999999;">
                    <td>
                        <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton"  ValidationGroup="egroup"/>
                        <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                    </td>
                    <td>
                        <asp:TextBox Text='<%# Bind("AlbumId") %>' runat="server" Enabled="false" ID="AlbumIdTextBox" /></td>
                    <td>
                        <asp:TextBox Text='<%# Bind("Title") %>' runat="server" ID="TitleTextBoxE" /></td>
                    <td>
                        <asp:DropDownList ID="ArtistList" runat="server" 
                            DataSourceID="ArtistListODS" 
                            DataTextField="DisplayField"
                            DataValueField="ValueField"
                            width="300px"
                            Enabled="false"
                             selectedValue='<%# Eval("ArtistId") %>'>

                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox Text='<%# Bind("ReleaseYear") %>' width="70px" runat="server" ID="ReleaseYearTextBoxE" /></td>
                    <td>
                        <asp:TextBox Text='<%# Bind("ReleaseLabel") %>' runat="server" ID="ReleaseLabelTextBoxE" /></td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <asp:RequiredFieldValidator ID="RequiredTitleI" runat="server" ErrorMessage="Album title is required on edit!" ControlToValidate="TitleTextBoxI" Display="None" 
                     ValidationGroup="igroup">

                </asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredReleaseYearI" runat="server" ErrorMessage="Album year is required on edit!" ControlToValidate="TitleTextBoxI" Display="None"  ValidationGroup="igroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegExTitleI" runat="server" ErrorMessage="Album title is limited to 160 characters!" ControlToValidate="TitleTextBoxI" Display="None" ValidationGroup="igroup" ValidationExpression="^.{1,160}$"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegExReleaseLabelI" runat="server" ErrorMessage="Album label is limited to 50 characters!" ControlToValidate="ReleaseLabelTextBoxI" Display="None" ValidationGroup="igroup" ValidationExpression="^.{1,50}$"></asp:RegularExpressionValidator>

                <asp:CompareValidator ID="CompareReleaseYearI" runat="server" ErrorMessage="Year must be a number"
                     ControlToValidate="ReleaseYearTextBoxI" Display="None" Operator="DataTypeCheck" Type="Integer" ValidationGroup="egroup"></asp:CompareValidator>

                <asp:RangeValidator ID="RangeReleaseYearI" runat="server" ErrorMessage="Year must be between 1950 and this year" ControlToValidate="ReleaseYearTextBoxI" Display="None" ValidationGroup="igroup" MinimumValue="1950" MaximumValue="<%# DateTime.Today.Year %>"></asp:RangeValidator>
                <tr style="background-color: #999999;">
                <tr style="">
                    <td>
                        <asp:Button runat="server" CommandName="Insert" ValidationGroup="igroup" Text="Insert" ID="InsertButton" />
                        <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                    </td>
                    <td>
                        <asp:TextBox Text='<%# Bind("AlbumId") %>' runat="server" Enabled="false" Width="50px" ID="AlbumIdTextBox" /></td>
                    <td>
                        <asp:TextBox Text='<%# Bind("Title") %>' runat="server" ID="TitleTextBoxI" /></td>
                    <td>
                        <asp:DropDownList ID="ArtistList" runat="server" 
                            DataSourceID="ArtistListODS" 
                            DataTextField="DisplayField"
                            DataValueField="ValueField"
                            width="300px"
                             selectedValue='<%# Bind("ArtistId") %>'>

                        </asp:DropDownList>

                    </td>
                    <td>
                        <asp:TextBox Text='<%# Bind("ReleaseYear") %>' Width="70px" runat="server" ID="ReleaseYearTextBoxI" /></td>
                    <td>
                        <asp:TextBox Text='<%# Bind("ReleaseLabel") %>' runat="server" ID="ReleaseLabelTextBoxI" /></td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color: #E0FFFF; color: #f62681;">
                    <td>
                        <asp:Button runat="server" OnClientClick="return confirm('Are you sure you wish to delete this album?')" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                        <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                    </td>
                    <td>
                        <asp:Label Text='<%# Eval("AlbumId") %>' Width="50px" runat="server" ID="AlbumIdLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" /></td>
                    <td>
                        <asp:DropDownList ID="ArtistList" runat="server" 
                            DataSourceID="ArtistListODS" 
                            DataTextField="DisplayField"
                            DataValueField="ValueField"
                            Enabled="false"
                            width="300px"
                             selectedValue='<%# Eval("ArtistId") %>'>

                        </asp:DropDownList></td>
                    <td>
                        <asp:Label Text='<%# Eval("ReleaseYear") %>' width="70px" runat="server" ID="ReleaseYearLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("ReleaseLabel") %>' runat="server" ID="ReleaseLabelLabel" /></td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                <tr runat="server" style="background-color: #E0FFFF; color: #333333;">
                                    <th runat="server"></th>
                                    <th runat="server">AlbumID</th>
                                    <th runat="server">Title</th>
                                    <th runat="server">Artist</th>
                                    <th runat="server">Year</th>
                                    <th runat="server">Label</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center; background-color: #c0c0c0; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
                            <asp:DataPager runat="server" ID="DataPager1">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                    <asp:NumericPagerField></asp:NumericPagerField>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color: #E2DED6; font-weight: bold; color: #333333;">
                    <td>
                        <asp:Button runat="server" OnClientClick="return confirm('Are you sure you wish to delete this album?')" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                        <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                    </td>
                    <td>
                        <asp:Label Text='<%# Eval("AlbumId") %>' runat="server" ID="AlbumIdLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("ArtistId") %>' runat="server" ID="ArtistIdLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("ReleaseYear") %>' runat="server" ID="ReleaseYearLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("ReleaseLabel") %>' runat="server" ID="ReleaseLabelLabel" /></td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="AlbumListODS" runat="server" 
            DataObjectTypeName="ChinookSystem.ViewModels.AlbumItem" 
            DeleteMethod="Albums_Delete" 
            InsertMethod="Albums_Add" 
            SelectMethod="Albums_List"
            OnDeleted="DeleteCheckForException"
            OnInserted="InsertCheckForException"
            OnSelected="SelectCheckForException"
            OnUpdated="UpdateCheckForException"
            OldValuesParameterFormatString="original_{0}" 
            TypeName="ChinookSystem.BLL.AlbumController"
            UpdateMethod="Albums_Update">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ArtistListODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Artists_ddlList" TypeName="ChinookSystem.BLL.ArtistController" OnSelected="SelectCheckForException">

        </asp:ObjectDataSource>
    </div>
        
    </div>
</asp:Content>
