using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmdb.Data.Models;

namespace Tmdb.Data.Repositories.Interfaces
{
    public interface ISavedMoviesRepository : IRepository<SavedMovie>
    {
    }
}
