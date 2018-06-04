<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SavedMovies.aspx.cs" Inherits="Tmdb.WebClient.SavedMovies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- <script type="text/javascript">
        $(function () {
            $('.movieDetails').hide();
            $(".showddiv").click(function () {
                $('.movieDetails').hide();
                $(this).closest('div').find('.movieDetails').toggle();
            });
        });
    </script>--%>
    &nbsp;
    <asp:ObjectDataSource
        ID="ObjectDataSource1"
        runat="server"
        SelectMethod="GetMovies"
        TypeName="Tmdb.WebClient.TmdbSavedMoviesBLL" DeleteMethod="DeleteMovie" OldValuesParameterFormatString="original_{0}">
        <DeleteParameters>
            <asp:Parameter Name="movieId" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>

    <asp:DataList
        ID="SearchMovieRepeater"
        DataSourceID="ObjectDataSource1"
        runat="server"
        RepeatColumns="3"
        OnItemCommand="SearchMovieRepeater_ItemCommand"
        DataKeyField="MovieId" 
        OnItemDataBound="SearchMovieRepeater_ItemDataBound" >
        <ItemTemplate>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="width: 500px; min-height: 300px">
                        <table>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <asp:ImageButton
                                                CommandName="ShowDetails"
                                                CommandArgument='<%# Eval("MovieId") %>'
                                                runat="server"
                                                ImageUrl='<%# Eval("ImageFullUrl") %>'
                                                Height="200"></asp:ImageButton>
                                        </tr>
                                        <tr>
                                            <asp:Button
                                                Text="Remove Movie"
                                                CommandName="Delete"
                                                CommandArgument='<%# Eval("MovieId") %>'
                                                runat="server"></asp:Button>
                                        </tr>


                                    </table>
                                </td>
                                <td>
                                    <asp:Panel
                                        ID="movieDetails"
                                        class="movieDetails"
                                        runat="server"
                                        Visible="false">
                                        <ul>
                                            <asp:Label
                                                runat="server"
                                                Text='<%# Eval("MovieId") %>'
                                                ID="MovieIdLabel">
                                            </asp:Label>

                                            <br />

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
