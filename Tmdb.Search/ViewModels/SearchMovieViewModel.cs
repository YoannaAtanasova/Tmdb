using Microsoft.Practices.Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tmdb.Contracts;

namespace Tmdb.Search.ViewModels
{
    public class SearchMovieViewModel : BindableBase
    {
        #region Declarations

        private int searchId;

        private string searchTitle;

        private TmdbMovie movieById;

        private List<TmdbMovie> moviesByTitle;

        DelegateCommand searchByIdCommand;

        DelegateCommand searchByTitleCommand;

        #endregion

        public SearchMovieViewModel()
        {

        }

        #region Properties

        public int SearchId
        {
            get
            {
                return searchId;
            }

            set
            {
                if (searchId == value) return;

                searchId = value;
                OnPropertyChanged("SearchId");
            }
        }

        public string SearchTitle
        {
            get
            {
                return searchTitle;
            }

            set
            {
                if (searchTitle == value) return;

                searchTitle = value;
                OnPropertyChanged("SearchTitle");
            }
        }

        public TmdbMovie MovieById
        {
            get
            {
                return movieById;
            }

            set
            {
                if (movieById == value) return;

                movieById = value;
                OnPropertyChanged("MovieById");
            }
        }

        public List<TmdbMovie> MoviesByTitle
        {
            get
            {
                return moviesByTitle;
            }

            set
            {
                if (moviesByTitle == value) return;

                moviesByTitle = value;
                OnPropertyChanged("MoviesByTitle");
            }
        }

        #endregion

        #region Commands

        public DelegateCommand SearchByIdCommand
        {
            get
            {
                if (searchByIdCommand != null) return searchByIdCommand;

                searchByIdCommand = new DelegateCommand(SearchById);
                return searchByIdCommand;
            }
        }

        public DelegateCommand SearchByTitleCommand
        {
            get
            {
                if (searchByTitleCommand != null) return searchByTitleCommand;

                searchByTitleCommand = new DelegateCommand(SearchByTitle);
                return searchByTitleCommand;
            }
        }

        #endregion

        #region Methods

        public void SearchById()
        {
            ChannelFactory<ITmdbSearchService> factory = new ChannelFactory<ITmdbSearchService>("");
            ITmdbSearchService proxy = factory.CreateChannel();

            try
            {
                MovieById = proxy.SearchForMovieById(SearchId);
            }
            catch (FaultException)
            {

            }
            catch(Exception)
            {

            }
            

            factory.Close();
        }

        public void SearchByTitle()
        {
            ChannelFactory<ITmdbSearchService> factory = new ChannelFactory<ITmdbSearchService>("");
            ITmdbSearchService proxy = factory.CreateChannel();

            try
            {
                MoviesByTitle = proxy.SerachFormMovieByTitle(SearchTitle.Replace(" ", "+"));
            }
            catch(FaultException)
            {

            }
            catch (Exception)
            {

            }
            

            factory.Close();
        }

        #endregion
    }
}
