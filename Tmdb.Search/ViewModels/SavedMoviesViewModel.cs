using Microsoft.Practices.Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tmdb.Contracts;
using Tmdb.Core.Events;

namespace Tmdb.Search.ViewModels
{
    public class SavedMoviesViewModel : BindableBase
    {
        #region Declarations

        private ObservableCollection<TmdbMovie> savedMovies;

        private IEventAggregator eventAggregator;

        #endregion

        public SavedMoviesViewModel(IEventAggregator eventAggregator)
        {
            GetAllSavedMovies();

            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<NewSavedMovieEvent>().Subscribe(GetAllSavedMovies);
        }

        #region Properties

        public ObservableCollection<TmdbMovie> SavedMovies
        {
            get
            {
                return savedMovies;
            }

            set
            {
                SetProperty(ref savedMovies, value);
            }
        }


        public string DisplayName { get; set; }

        #endregion

        #region Methods

        public void GetAllSavedMovies()
        {          
            try
            {
                ChannelFactory<IMovieService> factory = new ChannelFactory<IMovieService>("");
                IMovieService proxy = factory.CreateChannel();
                SavedMovies = new ObservableCollection<TmdbMovie>(proxy.GetSavedMovies());
                factory.Close();
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
