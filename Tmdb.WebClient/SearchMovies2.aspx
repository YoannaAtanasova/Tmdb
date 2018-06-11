<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchMovies2.aspx.cs" Inherits="Tmdb.WebClient.SearchMovies2" %>

<%@ Register Src="~/MoviesDataList.ascx" TagPrefix="uc1" TagName="MoviesDataList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="nav-justified">
                <tr>
                    <td style="width: 118px">Search By Title:</td>
                    <td>
                        <asp:TextBox ID="SearchTextBox" runat="server" Style="margin-left: 24px; margin-right: 35px" Width="737px"></asp:TextBox>
                        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
                        <asp:RadioButton ID="ShowAll" Text="Show All Movies" runat="server" GroupName="FilterMovies" OnCheckedChanged="FilterMovies_CheckedChanged" AutoPostBack="True" Checked="true" />
                        <asp:RadioButton ID="FadeWatched" Text="Fade Watched Movies" runat="server" GroupName="FilterMovies" OnCheckedChanged="FilterMovies_CheckedChanged" AutoPostBack="True" />
                        <asp:RadioButton ID="FilterOutWatched" Text="Filterout Watched Movies" runat="server" GroupName="FilterMovies" OnCheckedChanged="FilterMovies_CheckedChanged" AutoPostBack="True" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>

            &nbsp;

            <asp:DataList
                ID="SearchMovieRepeater"
                runat="server"
                RepeatColumns="3"
                OnItemCommand="SearchMovieRepeater_ItemCommand"
                OnItemDataBound="SearchMovieRepeater_ItemDataBound">
                <ItemTemplate>
                    <asp:Panel ID="MoviePanel" Style="width: 500px; min-height: 300px" runat="server">

                        <uc1:MoviesDataList runat="server" ID="MoviesDataList" />

                        <asp:Button
                            runat="server"
                            CommandName="Save"
                            CommandArgument='<%# Eval("MovieId") %>'
                            Text="Save Movie"></asp:Button>

                    </asp:Panel>
                </ItemTemplate>
            </asp:DataList>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
