namespace CinemaApp.Data.Repository
{
    using CinemaApp.Data.Models;
    using CinemaApp.Data.Repository.Interface;
    using Microsoft.EntityFrameworkCore;

    public class WatchlistRepository : BaseRepository<ApplicationUserMovie, object>, IWatchlistRepository
    {
        public WatchlistRepository(CinemaAppDbContext dbContext)
            : base(dbContext)
        {

        }

        public ApplicationUserMovie? GetByCompositeKey(string userId, string movieId)
        {
            return this
                .GetAllAttached()
                .SingleOrDefault(aum => aum.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                        aum.MovieId.ToString().ToLower() == movieId.ToLower());
        }

        public Task<ApplicationUserMovie?> GetByCompositeKeyAsync(string userId, string movieId)
        {
            return this
                .GetAllAttached()
                .SingleOrDefaultAsync(aum => aum.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                        aum.MovieId.ToString().ToLower() == movieId.ToLower());
        }

        public bool Exists(string userId, string movieId)
        {
            return this
                .GetAllAttached()
                .Any(aum => aum.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                            aum.MovieId.ToString().ToLower() == movieId.ToLower());
        }

        public Task<bool> ExistsAsync(string userId, string movieId)
        {
            return this
                .GetAllAttached()
                .AnyAsync(aum => aum.ApplicationUserId.ToString().ToLower() == userId.ToLower() &&
                            aum.MovieId.ToString().ToLower() == movieId.ToLower());
        }
    }
}
