using Cinema.DAL.DomainModels;
using General.Repository.Commons;
using System.Data.Entity;

namespace Cinema.Repository.Repositories
{
    public class TicketRepository : GenericRepository<Ticket, int>
    {
        public TicketRepository(DbContext context) : base(context)
        {
        }
    }
}
