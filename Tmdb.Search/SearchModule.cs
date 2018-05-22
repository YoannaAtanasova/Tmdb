using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Tmdb.Search.Views;

namespace Tmdb.Search
{
    public class SearchModule : IModule
    {
        IRegionManager regionManager;
        IUnityContainer container;

        public SearchModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("SearchMovieRegion", typeof(SearchMovieView));
            regionManager.RegisterViewWithRegion("SavedMoviesRegion", typeof(SavedMoviesView));
        }
    }
}
