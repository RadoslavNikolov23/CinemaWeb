namespace CinemaApp.Data.Repository
{
    using CinemaApp.Data.Repository.Interface;
    using Models;

    public class ManagerRepository : BaseRepository<Manager, Guid>, IManagerRepository
    {
        public ManagerRepository(CinemaAppDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
