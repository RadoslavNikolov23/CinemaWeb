namespace CinemaApp.Services.Core.Interfaces
{
    using CinemaApp.Web.ViewModels.Ticket;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITicketService
    {
        Task<IEnumerable<TicketIndexViewModel>> GetUserTicketsAsync(string? userId);

        Task<bool> AddTicketAsync(string? cinemaId, string? movieId, int quantity, string? showtime, string? userId);
    }
}
