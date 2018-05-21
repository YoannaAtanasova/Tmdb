using System.Data.Entity;
using Tmdb.Data.Models;

namespace Tmdb.Data
{
    public class TmdbDataContext : DbContext
    {
        public TmdbDataContext() : base("TmdbContext")
        {

        }

        DbSet<SavedMovie> SavedMovies { get; set; }
    }
}
