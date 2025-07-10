namespace CinemaApp.Data.Repository.Interface
{
    using CinemaApp.Data.Models;

    public interface ICinemaRepository
       : IRepository<Cinema, Guid>, IAsyncRepository<Cinema, Guid>
    {

    }
}
