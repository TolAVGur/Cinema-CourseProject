using Cinema.BLL.Models;
using Cinema.DAL.DomainModels;
using General.Repository.Commons;

namespace Cinema.BLL.Services
{
    public class VisitorService : GenericService<Visitor, VisitorDTO, int>
    {
        public VisitorService(IGenericRepository<Visitor, int> repository) : base(repository)
        {
        }
    }
}
