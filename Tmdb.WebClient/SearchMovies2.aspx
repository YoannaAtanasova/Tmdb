<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchMovies2.aspx.cs" Inherits="Tmdb.WebClient.SearchMovies2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table class="nav-justified">
        <tr>
            <td style="width: 118px">Search By Title:</td>
            <td>
                <asp:TextBox ID="SearchTextBox" runat="server" Style="margin-left: 24px; margin-right: 35px" Width="737px"></asp:TextBox>
                <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
                <asp:RadioButton ID="ShowAll" Text="Show All Movies" runat="server" GroupName="FilterMovies" OnCheckedChanged="FilterMovies_CheckedChanged"  AutoPostBack="True" Checked="true"/>
                <asp:RadioButton ID="FadeWatched" Text="Fade Watched Movies" runat="server" GroupName="FilterMovies" OnCheckedChanged="FilterMovies_CheckedChanged"  AutoPostBack="True"/>
                <asp:RadioButton ID="FilterOutWatched" Text="Filterout Watched Movies" runat="server" GroupName="FilterMovies" OnCheckedChanged="FilterMovies_CheckedChanged"  AutoPostBack="True"/>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    &nbsp;
    <%--    <script type="text/javascript">
        $(function () {
            $('.movieDetails').hide();
            $(".showddiv").click(function () {
                $('.movieDetails').hide();
                $(this).closest('div').find('.movieDetails').toggle();
            });
        });
    </script>--%>
    <asp:DataList 
        ID="SearchMovieRepeater" 
        runat="server" 
        RepeatColumns="3" 
        OnItemCommand="SearchMovieRepeater_ItemCommand"
        OnItemDataBound="SearchMovieRepeater_ItemDataBound">
        <ItemTemplate>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>                    
                    <asp:Panel ID="MoviePanel" style="width: 500px; min-height: 300px" runat="server" >
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton 
                                        CommandName="ShowDetails"
                                        CommandArgument='<%# Eval("MovieId") %>'
                                        runat="server" 
                                        ImageUrl='<%# Eval("ImageFullUrl") %>' 
                                        Height="200" >
                                    </asp:ImageButton>
                                </td>
                                <td>
                                    <asp:Panel
                                        ID="movieDetails" 
                                        class="movieDetails" 
                                        runat="server" 
                                        Visible="false" >
                                        <ul>
                                            <asp:Label
                                                runat="server"
                                                Text='<%# Eval("MovieId") %>'
                                                ID="MovieIdLabel">
                                            </asp:Label>

                                            <asp:Label 
                                                runat="server" 
                                                Text='<%# Eval("Title") %>'>
                                            </asp:Label>

                                            <br />

                                            <asp:Label 
                                                runat="server" 
                                                Text='<%# Eval("Year") %>'>
                                            </asp:Label>

                                            <br />

                                            <asp:Label
                                                runat="server"
                                                Text='<%# Eval("Overview") %>'
                                                Style="word-wrap: normal; word-break: break-all;"
                                                Width="300">
                                            </asp:Label>

                                            <br />

                                            <asp:Button 
                                                runat="server" 
                                                CommandName="Save" 
                                                CommandArgument='<%# Eval("MovieId") %>' 
                                                Text="Save Movie">
                                            </asp:Button>
                                        </ul>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
