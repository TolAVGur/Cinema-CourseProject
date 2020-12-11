using Cinema.BLL.Models;
using Cinema.DAL.DomainModels;
using General.Repository.Commons;

namespace Cinema.BLL.Services
{
    public class FilmService : GenericService<Film, FilmDTO, int>
    {
        public FilmService(IGenericRepository<Film, int> repository) : base(repository)
        {
        }
    }
}
