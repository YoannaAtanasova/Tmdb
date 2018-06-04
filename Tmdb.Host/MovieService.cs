using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Tmdb.Contracts;
using Tmdb.Data.Models;
using Tmdb.Data.Repositories.Implementations;
using Tmdb.Data.Repositories.Interfaces;

namespace Tmdb.Host
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MovieService : IMovieService
    {
        #region Declarations

        private UnitOfWork unitOfWork;

        #endregion

        #region Properties

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork != null) return unitOfWork;

                unitOfWork = new UnitOfWork();
                return unitOfWork;
            }
        }        

        #endregion

        public ICollection<TmdbMovie> GetSavedMovies()
        {
            var movies = UnitOfWork.SavedMoviesRepository.GetAll();

            List<TmdbMovie> moviesToReturn = new List<TmdbMovie>();

            foreach (var item in movies)
            {
                moviesToReturn.Add(new TmdbMovie()
                {
                    MovieId = item.MovieId,
                    Title = item.Title,
                    Year = item.Year,
                    Overview = item.Overview,
                    ImageUrl = item.ImageUrl
                });
            }

            return moviesToReturn;
        }

        public bool ChackIfMovieExists(int movieId)
        {
            return UnitOfWork.SavedMoviesRepository.Get(movieId) != null;
        }

        public void SaveMovie(TmdbMovie tmdbMovie)
        {
            if (tmdbMovie != null)
            {
                UnitOfWork.SavedMoviesRepository.Add(new SavedMovie()
                {
                    MovieId = tmdbMovie.MovieId,
                    Title = tmdbMovie.Title,
                    Year = tmdbMovie.Year,
                    Overview = tmdbMovie.Overview,
                    ImageUrl = tmdbMovie.ImageUrl
                });

                UnitOfWork.Commit();
            }
            else
            {
                throw new FaultException("something went wrong");
            }

        }

        public void DeleteMovie(int id)
        {
            SavedMovie movieToDelete = UnitOfWork.SavedMoviesRepository.Get(id);
            UnitOfWork.SavedMoviesRepository.Remove(movieToDelete);
            UnitOfWork.Commit();
        }

    }
}
