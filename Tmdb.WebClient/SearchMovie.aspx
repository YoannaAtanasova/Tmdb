<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchMovie.aspx.cs" Inherits="Tmdb.WebClient.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table class="nav-justified">
        <tr>
            <td style="width: 118px">Search By Title:</td>
            <td>
                <asp:TextBox ID="SearchTextBox" runat="server" Style="margin-left: 24px; margin-right: 35px" Width="737px"></asp:TextBox>
                <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
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
    <asp:DataList ID="SearchMovieRepeater" runat="server" RepeatColumns="3" OnItemCommand="SearchMovieRepeater_ItemCommand">
        <ItemTemplate>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="width: 500px; min-height: 300px">
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton CommandName="ShowDetails" runat="server" ImageUrl='<%# Eval("ImageFullUrl") %>' Height="200"></asp:ImageButton>
                                </td>
                                <td>
                                    <asp:Panel ID="movieDetails" class="movieDetails" runat="server" Visible="false" >
                                        <ul>
                                            <asp:Label runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                            <br />

                                            <asp:Label runat="server" Text='<%# Eval("Year") %>'></asp:Label>
                                            <br />

                                            <asp:Label
                                                runat="server"
                                                Text='<%# Eval("Overview") %>'
                                                Style="word-wrap: normal; word-break: break-all;"
                                                Width="300">

                                            </asp:Label>
                                            <br />

                                            <asp:Button runat="server" CommandName="Save" CommandArgument='<%# Eval("MovieId") %>' Text="Save Movie"></asp:Button>
                                        </ul>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
