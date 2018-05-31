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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ChannelFactory<ITmdbSearchService> factory = new ChannelFactory<ITmdbSearchService>("");
            ITmdbSearchService proxy = factory.CreateChannel();

            try
            {
                SearchMovieRepeater.DataSource = proxy.SerachFormMovieByTitle(SearchTextBox.Text);
                SearchMovieRepeater.DataBind();
            }
            catch (FaultException)
            {

            }
            catch (Exception)
            {

            }

            factory.Close();
        }

        protected void SearchMovieRepeater_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Save")
            {
                ChannelFactory<IMovieService> factory = new ChannelFactory<IMovieService>("");
                IMovieService proxy = factory.CreateChannel();

                try
                {
                    proxy.SaveMovie(GetMovieById(int.Parse(e.CommandArgument.ToString()))); 

                }
                catch (FaultException)
                {

                }
                catch (Exception)
                {

                }
            }
            else if (e.CommandName == "ShowDetails")
            {
                ResetAllPanels();
                var details = (Panel)e.Item.FindControl("movieDetails");
                details.Visible = true;
            }
        }

        private TmdbMovie GetMovieById(int id)
        {
            ChannelFactory<ITmdbSearchService> factory = new ChannelFactory<ITmdbSearchService>("");
            ITmdbSearchService proxy = factory.CreateChannel();
            TmdbMovie movieToReturn = null;

            try
            {
                movieToReturn = proxy.SearchForMovieById(id);
            }
            catch (FaultException)
            {

            }
            catch (Exception)
            {

            }

            factory.Close();
            return movieToReturn;
        }

        private void ResetAllPanels()
        {
            foreach(DataListItem listItem in SearchMovieRepeater.Items)
            {
                var details = (Panel)listItem.FindControl("movieDetails");

                if(details.Visible == true)
                    details.Visible = false;               
            }
        }
    }
}