using Cinema.DAL.DomainModels;
using General.Repository.Commons;
using System.Data.Entity;

namespace Cinema.Repository.Repositories
{
    public class VisitorRepository : GenericRepository<Visitor, int>
    {
        public VisitorRepository(DbContext context) : base(context)
        {
        }
    }
}
