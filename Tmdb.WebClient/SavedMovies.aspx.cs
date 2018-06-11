using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tmdb.Contracts;

namespace Tmdb.WebClient
{
    public partial class SavedMovies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["VisibleItem"] = null;
            }

            MovieById.Movie = GetMovieById(550);
            MovieById.DataBind();
        }

        protected void SearchMovieRepeater_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ShowDetails")
            {
                Session["VisibleItem"] = (string)e.CommandArgument;
                SearchMovieRepeater.DataBind();
            }
            else if (e.CommandName == "Delete")
            {
                ObjectDataSource1.DeleteParameters["movieId"].DefaultValue = e.CommandArgument.ToString();
                ObjectDataSource1.Delete();
                SearchMovieRepeater.DataBind();
            }
        }

        protected void SearchMovieRepeater_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            UserControl userControl = (UserControl)e.Item.FindControl("MoviesDataList");
            Label label = (Label)userControl.FindControl("MovieIdLabel");

            if (label.Text == (string)Session["VisibleItem"])
            {
                ((Panel)userControl.FindControl("movieDetails")).Visible = true;
            }
        }

        private TmdbMovie GetMovieById(int id)
        {
            ChannelFactory<ITmdbSearchService> factory = new ChannelFactory<ITmdbSearchService>("");
            ITmdbSearchService proxy = factory.CreateChannel();
            TmdbMovie movieToReturn = null;
            movieToReturn = proxy.SearchForMovieById(id);

            factory.Close();
            return movieToReturn;
        }
    }
}