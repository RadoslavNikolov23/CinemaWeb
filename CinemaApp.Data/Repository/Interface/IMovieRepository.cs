namespace CinemaApp.Data.Repository.Interface
{
    using CinemaApp.Data.Models;
    using System;

    public interface IMovieRepository
      : IRepository<Movie, Guid>, IAsyncRepository<Movie, Guid>
    {

    }
}
