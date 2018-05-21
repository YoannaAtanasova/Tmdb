using System.Data.Entity;
using Tmdb.Data.Models;
using Tmdb.Data.Repositories.Interfaces;

namespace Tmdb.Data.Repositories.Implementations
{
    public class SavedMoviesRepository : Repository<SavedMovie>, ISavedMoviesRepository
    {
        public SavedMoviesRepository(DbContext context) : base(context)
        {
        }
    }
}
