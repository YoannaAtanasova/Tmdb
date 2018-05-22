using Microsoft.Practices.Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tmdb.Contracts;
using Tmdb.Core.Events;

namespace Tmdb.Search.ViewModels
{
    public class SearchMovieViewModel : BindableBase
    {
        #region Declarations

        private int searchId;

        private string searchTitle;

        private TmdbMovie movieById;

        private TmdbMovie selectedMovie;

        private List<TmdbMovie> moviesByTitle;

        private IEventAggregator eventAggregator;

        DelegateCommand searchByIdCommand;

        DelegateCommand searchByTitleCommand;

        DelegateCommand saveSelectedMovieCommand;

        #endregion

        public SearchMovieViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
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

        public TmdbMovie SelectedMovie
        {
            get
            {
                return selectedMovie;
            }

            set
            {
                if (selectedMovie == value) return;

                selectedMovie = value;
                OnPropertyChanged("SelectedMovie");
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

        public DelegateCommand SaveSelectedMovieCommand
        {
            get
            {
                if (saveSelectedMovieCommand != null) return saveSelectedMovieCommand;

                saveSelectedMovieCommand = new DelegateCommand(SaveSelectedMovie);
                return saveSelectedMovieCommand;
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
                SelectedMovie = MovieById;
                MoviesByTitle = null;
            }
            catch (FaultException)
            {

            }
            catch (Exception)
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
                SelectedMovie = null;
                MovieById = null;
            }
            catch (FaultException)
            {

            }
            catch (Exception)
            {

            }

            factory.Close();
        }

        public void SaveSelectedMovie()
        {
            ChannelFactory<IMovieService> factory = new ChannelFactory<IMovieService>("");
            IMovieService proxy = factory.CreateChannel();

            try
            {
                proxy.SaveMovie(SelectedMovie);
                eventAggregator.GetEvent<NewSavedMovieEvent>().Publish();
            }
            catch (FaultException)
            {

            }
            catch (Exception)
            {

            }
        }

        #endregion
    }
}
