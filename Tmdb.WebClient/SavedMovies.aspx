<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SavedMovies.aspx.cs" Inherits="Tmdb.WebClient.SavedMovies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.movieDetails').hide();
            $(".showddiv").click(function () {
                $('.movieDetails').hide();
                $(this).closest('div').find('.movieDetails').toggle();
            });
        });
    </script>
    &nbsp;
    <asp:DataList ID="SearchMovieRepeater" runat="server" RepeatColumns="3">
        <ItemTemplate>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="width:500px; min-height:300px">
                        <table>
                        <tr>
                            <td>
                                <a href="#" class="showddiv">
                                    <asp:Image runat="server" ImageUrl='<%# Eval("ImageFullUrl") %>' Height="200"></asp:Image>
                                </a>

                            </td>
                            <td>
                                <div class="movieDetails" runat="server">
                                    <ul>
                                        <asp:Label runat="server" Text='<%# Eval("MovieId") %>' ID="MovieIdLabel"></asp:Label>
                                        <br />

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
                                    </ul>
                                </div>
                            </td>
                        </tr>
                    </table>
                    </div>
                    
                </ContentTemplate>
            </asp:UpdatePanel>


        </ItemTemplate>
    </asp:DataList>
</asp:Content>
