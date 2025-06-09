namespace CinemaApp.Services.Core
{
    using CinemaApp.Services.Core.Interfaces;
    using CinemaApp.Web.ViewModels.Watchlist;
    using System.Threading.Tasks;

    public class WatchlistService : IWatchlistService
    {
        public Task<bool> AddMovieToUserWatchlistAsync(string? movieId, string? userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WatchlistViewModel>> GetUserWatchlistAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsMovieAddedToWatchlist(string? movieId, string? userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveMovieFromWatchlistAsync(string? movieId, string? userId)
        {
            throw new NotImplementedException();
        }
    }
}
