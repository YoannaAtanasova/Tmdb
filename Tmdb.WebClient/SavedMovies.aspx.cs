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
    public partial class SavedMovies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ChannelFactory<IMovieService> factory = new ChannelFactory<IMovieService>("");
                IMovieService proxy = factory.CreateChannel();

                SearchMovieRepeater.DataSource = proxy.GetSavedMovies();
                SearchMovieRepeater.DataBind();

                factory.Close();
            }
            catch (FaultException)
            {

            }
            catch (Exception)
            {

            }
        }
    }
}