using Tmdb.Data.Repositories.Interfaces;

namespace Tmdb.Data.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Declarations

        private TmdbDataContext dbContext;

        SavedMoviesRepository savedMoviesRepository;

        #endregion

        public UnitOfWork()
        {
            dbContext = new TmdbDataContext();
        }

        #region Repositories

        public ISavedMoviesRepository SavedMoviesRepository
        {
            get
            {
                if (savedMoviesRepository != null) return savedMoviesRepository;

                savedMoviesRepository = new SavedMoviesRepository(dbContext);
                return savedMoviesRepository;
            }
        }

        #endregion

        #region Methods

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        #endregion
    }
}
