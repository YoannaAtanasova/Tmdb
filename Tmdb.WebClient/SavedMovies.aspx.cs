using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

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
            Label label = (Label)e.Item.FindControl("MovieIdLabel");

            if (label.Text == (string)Session["VisibleItem"])
            {
                ((Panel)e.Item.FindControl("movieDetails")).Visible = true;
            }
        }

    }
}