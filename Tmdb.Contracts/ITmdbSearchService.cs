using System.Collections.Generic;
using System.Net.Security;
using System.ServiceModel;

namespace Tmdb.Contracts
{
    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface ITmdbSearchService
    {
        [OperationContract]
        TmdbMovie SearchForMovieById(int id);

        [OperationContract]
        List<TmdbMovie> SerachFormMovieByTitle(string title);
    }
}
