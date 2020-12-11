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
    public class SeanseService : IGenericService<SeanceDTO, int>
    {
        IGenericRepository<Seance, int> repository;
        IMapper mapper;
        protected Action<IMapperConfigurationExpression> _cfg;
        public SeanseService(IGenericRepository<Seance,int> repository)
        {
            this.repository = repository;
            mapper = MapConfigurate().CreateMapper();
        }
        protected virtual MapperConfiguration MapConfigurate()
        {
            if (_cfg==null)
            {
                return new MapperConfiguration(cfg => { cfg.CreateMap<Seance, SeanceDTO>(); cfg.CreateMap<SeanceDTO, Seance>(); });
            }
            else
            {
                return new MapperConfiguration(_cfg);
            }
        }



        public SeanceDTO Add(SeanceDTO obj)
        {
            throw new NotImplementedException();
        }

        public SeanceDTO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeanceDTO> FindBy(Expression<Func<SeanceDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public SeanceDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeanceDTO> GetAll()
        {
            return repository.GetAll().AsEnumerable().Select(s => mapper.Map<SeanceDTO>(s));
        }

        public SeanceDTO Update(SeanceDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
