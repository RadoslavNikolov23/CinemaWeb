namespace CinemaApp.Data.Repository
{
    using CinemaApp.Data.Models;
    using CinemaApp.Data.Repository.Interface;

    public class CinemaMovieRepository
      : BaseRepository<CinemaMovie, Guid>, ICinemaMovieRepository
    {
        public CinemaMovieRepository(CinemaAppDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
