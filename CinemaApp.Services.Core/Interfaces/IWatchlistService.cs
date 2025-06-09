namespace CinemaApp.Services.Core.Interfaces
{
    using CinemaApp.Web.ViewModels.Watchlist;

    public interface IWatchlistService
    {
        Task<IEnumerable<WatchlistViewModel>> GetUserWatchlistAsync(string userId);

        Task<bool> AddMovieToUserWatchlistAsync(string? movieId, string? userId);

        Task<bool> RemoveMovieFromWatchlistAsync(string? movieId, string? userId);

        Task<bool> IsMovieAddedToWatchlist(string? movieId, string? userId);
    }
}
