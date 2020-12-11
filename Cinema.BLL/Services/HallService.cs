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
    public class HallService : IGenericService<HallDTO, int>
    {
        IGenericRepository<Hall, int> repository;
        IMapper mapper;
        protected Action<IMapperConfigurationExpression> _cfg;

        public HallService(IGenericRepository<Hall, int> repository)
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
                    cfg.CreateMap<Hall, HallDTO>();
                    cfg.CreateMap<HallDTO, Hall>();
                });
            }
            else
            {
                return new MapperConfiguration(_cfg);
            }
        }

        //

        public HallDTO Add(HallDTO obj)
        {
            throw new NotImplementedException();
        }

        public HallDTO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HallDTO> FindBy(Expression<Func<HallDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public HallDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HallDTO> GetAll()
        {
            //return repository.GetAll().AsEnumerable()
            //    .Select(h=> new HallDTO { IdHall=h.IdHall, NameHall = h.NameHall});

            return repository.GetAll().AsEnumerable().Select(h => mapper.Map<HallDTO>(h));
        }

        public HallDTO Update(HallDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
