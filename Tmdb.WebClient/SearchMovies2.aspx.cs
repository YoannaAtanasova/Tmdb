using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tmdb.Contracts;

namespace Tmdb.WebClient
{
    public partial class SearchMovies2 : System.Web.UI.Page
    {
        private IList<TmdbMovie> savedMovies;

        private IList<TmdbMovie> SavedMovies
        {
            get
            {
                if (savedMovies != null) return savedMovies;

                TmdbSavedMoviesBLL tmdbSavedMoviesBLL = new TmdbSavedMoviesBLL();
                savedMovies = tmdbSavedMoviesBLL.GetMovies();

                return savedMovies;
            }
        }

        //private void Page_PreRender(object sender, EventArgs e)
        //{
        //    if (Page.IsPostBack)
        //    {
        //        this.DataBind();
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["VisibleItem"] = null;
                Session["SearchTitle"] = null;
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Session["VisibleItem"] = null;
            Session["SearchTitle"] = SearchTextBox.Text;

            RebindData();

            ResetRadioButtons();
        }

        private List<TmdbMovie> SearchMovies(string searchText)
        {
            ChannelFactory<ITmdbSearchService> factory = new ChannelFactory<ITmdbSearchService>("");
            ITmdbSearchService proxy = factory.CreateChannel();
            List<TmdbMovie> searchedMovies = new List<TmdbMovie>();

            searchedMovies = proxy.SerachFormMovieByTitle(searchText);

            factory.Close();
            return searchedMovies;
        }

        private void ResetRadioButtons()
        {
            FilterOutWatched.Checked = false;
            FadeWatched.Checked = false;
            ShowAll.Checked = true;
        }

        private void RebindData()
        {
            SearchMovieRepeater.DataSource = SearchMovies((string)Session["SearchTitle"]);
            SearchMovieRepeater.DataBind();
        }

        protected void SearchMovieRepeater_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ShowDetails")
            {
                Session["VisibleItem"] = e.CommandArgument;
                RebindData();
            }
            else if (e.CommandName == "Save")
            {
                ChannelFactory<IMovieService> factory = new ChannelFactory<IMovieService>("");
                IMovieService proxy = factory.CreateChannel();

                proxy.SaveMovie(GetMovieById(int.Parse(e.CommandArgument.ToString())));

                factory.Close();
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

        protected void SearchMovieRepeater_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label label = (Label)e.Item.FindControl("MovieIdLabel");

            if (label != null && label.Text == (string)Session["VisibleItem"])
            {
                ((Panel)e.Item.FindControl("movieDetails")).Visible = false;              
            }

            int movieId = int.Parse(label.Text);

            if (FadeWatched.Checked)
            {
                if (SavedMovies.Any(s=>s.MovieId == movieId))
                {
                    ((Panel)e.Item.FindControl("MoviePanel")).Style.Add("opacity", "0.5");
                }                
            }
            else if (FilterOutWatched.Checked)
            {
                if (SavedMovies.Any(s => s.MovieId == movieId))
                {
                    ((Panel)e.Item.FindControl("MoviePanel")).Visible = false;
                }
            }
        }

        protected void FilterMovies_CheckedChanged(object sender, EventArgs e)
        {
            RebindData();
        }
    }
}