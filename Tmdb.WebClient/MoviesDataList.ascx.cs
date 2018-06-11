using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tmdb.Contracts;

namespace Tmdb.WebClient
{
    public partial class MoviesDataList : System.Web.UI.UserControl
    {
        public TmdbMovie Movie { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}