using Cinema.DAL.DomainModels;
using General.Repository.Commons;
using System.Data.Entity;

namespace Cinema.Repository.Repositories
{
    public class FilmRepository : GenericRepository<Film, int>
    {
        public FilmRepository(DbContext context) : base(context)
        {
        }
    }
}
