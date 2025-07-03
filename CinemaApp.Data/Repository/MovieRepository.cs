namespace CinemaApp.Data.Repository
{
    using CinemaApp.Data.Models;
    using CinemaApp.Data.Repository.Interface;

    public class MovieRepository : BaseRepository<Movie, Guid>, IMovieRepository
    {
        public MovieRepository(CinemaAppDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
