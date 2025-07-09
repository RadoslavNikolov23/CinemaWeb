namespace CinemaApp.Data.Repository.Interface
{
    using Models;

    public interface IManagerRepository
        : IRepository<Manager, Guid>, IAsyncRepository<Manager, Guid>
    {

    }
}
