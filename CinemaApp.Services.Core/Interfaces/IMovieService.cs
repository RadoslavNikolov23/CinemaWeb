namespace CinemaApp.Services.Core.Interfaces
{
    using CinemaApp.Web.ViewModels.Movie;

    public interface IMovieService
    {
        Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync();

        Task AddMovieAsync(MovieFormInputModel movie);

        Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(string? id);

        Task<MovieFormInputModel?> GetEditableMovieByIdAsync(string? id);

        Task<bool> EditMovieAsync(MovieFormInputModel inputModel);
 
    }
}
