using Cinema.BLL.Models;
using Cinema.DAL.DomainModels;
using General.Repository.Commons;

namespace Cinema.BLL.Services
{
    public class LineService : GenericService<line, LineDTO, int>
    {
        public LineService(IGenericRepository<line, int> repository) : base(repository)
        {
        }
    }
}
