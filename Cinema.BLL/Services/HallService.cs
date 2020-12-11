using Cinema.BLL.Models;
using Cinema.DAL.DomainModels;
using General.Repository.Commons;

namespace Cinema.BLL.Services
{
    public class HallService : GenericService<Hall, HallDTO, int>
    {
        public HallService(IGenericRepository<Hall, int> repository) : base(repository)
        {
        }
    }
}
