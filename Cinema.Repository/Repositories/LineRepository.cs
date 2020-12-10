using System.Data.Entity;
using Cinema.DAL.DomainModels;
using General.Repository.Commons;

namespace Cinema.Repository.Repositories
{
    public class LineRepository : GenericRepository<line, int>
    {
        public LineRepository(DbContext context) : base(context)
        {
        }
    }
}
