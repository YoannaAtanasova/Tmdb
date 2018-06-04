using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;

namespace Tmdb.Contracts
{
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface IMovieService
    {
        [OperationContract]
        void SaveMovie(TmdbMovie tmdbMovie);

        [OperationContract]
        ICollection<TmdbMovie> GetSavedMovies();

        [OperationContract]
        void DeleteMovie(int id);

        [OperationContract]
        bool ChackIfMovieExists(int movieId);
    }
}
