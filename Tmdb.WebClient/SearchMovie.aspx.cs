﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tmdb.Contracts;

namespace Tmdb.WebClient
{
    public partial class WebForm1 : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //this.PreRender += WebForm1_PreRender;
        }

        private void Page_PreRender(object sender, EventArgs e)
        {
            //if (Page.IsPostBack)
            //{
            //    this.DataBind();
            //}
        }

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
            SearchMovieRepeater.DataSource = SearchMovies(SearchTextBox.Text);
            SearchMovieRepeater.DataBind();

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

        protected void SearchMovieRepeater_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if( e.CommandName == "ShowDetails")
            {
                Session["VisibleItem"] = e.CommandArgument;

                if (ShowAll.Checked)
                    ShowAll_CheckedChanged(source, e);
                else if (FadeWatched.Checked)
                    FadeWatched_CheckedChanged(source, e);
                else if (FilterOutWatched.Checked)
                    FilterOutWatched_CheckedChanged(source, e);
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
                ((Panel)e.Item.FindControl("movieDetails")).Visible = true;
            }
        }

        protected void ShowAll_CheckedChanged(object sender, EventArgs e)
        {
            SearchMovieRepeater.DataSource = SearchMovies((string)Session["SearchTitle"]);
            SearchMovieRepeater.DataBind();
        }

        protected void FadeWatched_CheckedChanged(object sender, EventArgs e)
        {
            SearchMovieRepeater.DataSource = SearchMovies((string)Session["SearchTitle"]);
            SearchMovieRepeater.DataBind();

            TmdbSavedMoviesBLL tmdbSavedMoviesBLL = new TmdbSavedMoviesBLL();
            IList<TmdbMovie> savedMovies = tmdbSavedMoviesBLL.GetMovies();

            foreach (var item in SearchMovieRepeater.Items)
            {
                DataListItem dataListItem = (DataListItem)item;
                int gameId = int.Parse(((Label)dataListItem.FindControl("MovieIdLabel")).Text);

                if (savedMovies.Any(s => s.MovieId == gameId))
                {
                    ((Panel)dataListItem.FindControl("MoviePanel")).Style.Add("opacity", "0.5");
                }
            }
        }

        protected void FilterOutWatched_CheckedChanged(object sender, EventArgs e)
        {
            if (Session["SearchTitle"] != null)
            {
                TmdbSavedMoviesBLL tmdbSavedMoviesBLL = new TmdbSavedMoviesBLL();
                IList<TmdbMovie> savedMovies = tmdbSavedMoviesBLL.GetMovies();
                SearchMovieRepeater.DataSource = SearchMovies((string)Session["SearchTitle"]).Where(m => !savedMovies.Any(s => s.MovieId == m.MovieId));
                SearchMovieRepeater.DataBind();
            }
        }
    }
}