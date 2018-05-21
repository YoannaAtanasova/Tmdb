using System;

namespace Tmdb.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISavedMoviesRepository SavedMoviesRepository { get; }

        int Commit();
    }
}
