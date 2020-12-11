using Cinema.BLL.Models;
using Cinema.DAL.DomainModels;
using General.Repository.Commons;

namespace Cinema.BLL.Services
{
    public class SeanseService : GenericService<Seance, SeanceDTO, int>
    {
        public SeanseService(IGenericRepository<Seance, int> repository) : base(repository)
        {
        }
    }
}
