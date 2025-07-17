namespace CinemaApp.Data.Repository.Interface
{
    using CinemaApp.Data.Models;

    public interface ICinemaMovieRepository
       : IRepository<CinemaMovie, Guid>, IAsyncRepository<CinemaMovie, Guid>
    {

    }
}
