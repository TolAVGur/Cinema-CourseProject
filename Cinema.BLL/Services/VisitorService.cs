using AutoMapper;
using Cinema.BLL.Models;
using Cinema.DAL.DomainModels;
using General.Repository.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cinema.BLL.Services
{
    public class VisitorService : IGenericService<VisitorDTO, int>
    {
        IGenericRepository<Visitor, int> repository;
        IMapper mapper;
        protected Action<IMapperConfigurationExpression> _cfg;
        public VisitorService(IGenericRepository<Visitor, int> repository)
        {
            this.repository = repository;
            mapper = MapConfigurate().CreateMapper();
        }
        protected virtual MapperConfiguration MapConfigurate()
        {
            if (_cfg == null)
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Visitor, VisitorDTO>();
                    cfg.CreateMap<VisitorDTO, Visitor>();
                });
            }
            else
            {
                return new MapperConfiguration(_cfg);
            }
        }

        public IEnumerable<VisitorDTO> GetAll()
        {
            return repository.GetAll().AsEnumerable().Select(v => mapper.Map<VisitorDTO>(v));
        }

        public IEnumerable<VisitorDTO> FindBy(Expression<Func<VisitorDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public VisitorDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public VisitorDTO Add(VisitorDTO obj)
        {
            throw new NotImplementedException();
        }

        public VisitorDTO Update(VisitorDTO obj)
        {
            throw new NotImplementedException();
        }

        public VisitorDTO Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
