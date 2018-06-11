<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoviesDataList.ascx.cs" Inherits="Tmdb.WebClient.MoviesDataList" %>

<table>
    <tr>
        <td>
            <asp:ImageButton
                CommandName="ShowDetails"
                CommandArgument='<%# Movie == null ? 0 : Movie.MovieId %>'
                runat="server"
                ImageUrl='<%# Movie == null ? null : Movie.ImageFullUrl %>'
                Height="200"></asp:ImageButton>
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
                        Text='<%# Movie == null ? 0 : Movie.MovieId %>'
                        ID="MovieIdLabel">
                    </asp:Label>
                    <br />
                    <asp:Label
                        runat="server"
                        Text='<%# Movie == null ? null : Movie.Title %>'>
                    </asp:Label>
                    <br />
                    <asp:Label
                        runat="server"
                        Text='<%# Movie == null ? null : Movie.Year %>'>
                    </asp:Label>
                    <br />
                    <asp:Label
                        runat="server"
                        Text='<%# Movie == null ? null : Movie.Overview %>'
                        Style="word-wrap: normal; word-break: break-all;"
                        Width="300">
                    </asp:Label>
                </ul>
            </asp:Panel>
        </td>
    </tr>
</table>

