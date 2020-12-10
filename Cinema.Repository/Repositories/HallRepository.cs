using System.Data.Entity;
using Cinema.DAL.DomainModels;
using General.Repository.Commons;

namespace Cinema.Repository.Repositories
{
    public class HallRepository : GenericRepository<Hall, int>
    {
        public HallRepository(DbContext context) : base(context)
        {
        }
    }
}
