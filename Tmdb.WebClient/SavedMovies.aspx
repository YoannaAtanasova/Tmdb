<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SavedMovies.aspx.cs" Inherits="Tmdb.WebClient.SavedMovies" %>

<%@ Register Src="~/MoviesDataList.ascx" TagPrefix="uc1" TagName="MoviesDataList" %>


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
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:MoviesDataList runat="server" ID="MovieById"/>

            <asp:DataList
                ID="SearchMovieRepeater"
                DataSourceID="ObjectDataSource1"
                runat="server"
                RepeatColumns="3"
                OnItemCommand="SearchMovieRepeater_ItemCommand"
                DataKeyField="MovieId"
                OnItemDataBound="SearchMovieRepeater_ItemDataBound">
                <ItemTemplate>

                    <asp:Panel Style="width: 500px; min-height: 300px" runat="server">

                        <uc1:MoviesDataList runat="server" ID="MoviesDataList" Movie='<%# Container.DataItem %>'/>

                        <asp:Button
                            Text="Remove Movie"
                            CommandName="Delete"
                            CommandArgument='<%# Eval("MovieId") %>'
                            runat="server"></asp:Button>

                    </asp:Panel>
                </ItemTemplate>
            </asp:DataList>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
