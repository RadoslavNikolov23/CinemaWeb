namespace CinemaApp.Data.Repository.Interface
{
    using CinemaApp.Data.Models;

    public interface ITicketRepository
        : IRepository<Ticket, Guid>, IAsyncRepository<Ticket, Guid>
    {

    }
}
