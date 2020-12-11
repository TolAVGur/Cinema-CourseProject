using Cinema.BLL.Models;
using Cinema.DAL.DomainModels;
using General.Repository.Commons;

namespace Cinema.BLL.Services
{
    public class TicketService : GenericService<Ticket, TicketDTO, int>
    {
        public TicketService(IGenericRepository<Ticket, int> repository) : base(repository)
        {
        }
    }
}
