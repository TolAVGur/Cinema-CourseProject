using System.Data.Entity;
using Cinema.DAL.DomainModels;
using General.Repository.Commons;

namespace Cinema.Repository.Repositories
{
    public class SeanseRepository : GenericRepository<Seance, int>
    {
        public SeanseRepository(DbContext context) : base(context)
        {
        }
    }
}
