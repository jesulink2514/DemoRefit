using System.Threading.Tasks;
using Refit;

namespace DemoRefit.Client
{
    public interface IMoviesApi
    {
        [Get("/")]
        Task<Movie> FindMovies([AliasAs("i")]string id,[AliasAs("t")] string title,MovieType? type, [AliasAs("y")]int? year,PlotType? plot);
    }

    public enum PlotType
    {
        Short,
        full
    }
}