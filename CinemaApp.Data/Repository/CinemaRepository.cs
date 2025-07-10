namespace CinemaApp.Data.Repository
{
    using CinemaApp.Data.Models;
    using CinemaApp.Data.Repository.Interface;

    public class CinemaRepository : BaseRepository<Cinema, Guid>, ICinemaRepository
    {
        public CinemaRepository(CinemaAppDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
