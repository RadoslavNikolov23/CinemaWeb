namespace CinemaApp.Services.Core.Interfaces
{
    using CinemaApp.Web.ViewModels.Cinema;

    public interface ICinemaService
    {
        Task<IEnumerable<UsersCinemaIndexViewModel>> GetAllCinemasUserViewAsync();

        Task<CinemaProgramViewModel?> GetCinemaProgramAsync(string? cinemaId);

        Task<CinemaDetailsViewModel?> GetCinemaDetailsAsync(string? cinemaId);
    }
}
