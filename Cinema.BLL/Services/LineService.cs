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
    public class LineService : IGenericService<LineDTO, int>
    {
        IGenericRepository<line, int> repository;
        IMapper mapper;
        protected Action<IMapperConfigurationExpression> _cfg;

        public LineService(IGenericRepository<line,int> repository)
        {
            this.repository = repository;
            mapper = MapConfigurate().CreateMapper();
        }
        protected virtual MapperConfiguration MapConfigurate()
        {
            if (_cfg == null) return new MapperConfiguration(cfg => { cfg.CreateMap<line, LineDTO>(); cfg.CreateMap<LineDTO, line>(); });
            else return new MapperConfiguration(_cfg); 
        }
        //


        public LineDTO Add(LineDTO obj)
        {
            throw new NotImplementedException();
        }

        public LineDTO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineDTO> FindBy(Expression<Func<LineDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public LineDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineDTO> GetAll()
        {
            return repository.GetAll().AsEnumerable().Select(l => mapper.Map<LineDTO>(l));
        }

        public LineDTO Update(LineDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
