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
    public class FilmService : IGenericService<FilmDTO, int>
    {
        IGenericRepository<Film, int> repository;
        IMapper mapper;
        protected Action<IMapperConfigurationExpression> _cfg;

        public FilmService(IGenericRepository<Film, int> repository)
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
                    cfg.CreateMap<Film, FilmDTO>();
                    cfg.CreateMap<FilmDTO, Film>();
                });
            }
            else
            {
                return new MapperConfiguration(_cfg);
            }
        }
        //
        public IEnumerable<FilmDTO> GetAll()
        {
            return repository.GetAll().AsEnumerable().Select(f => mapper.Map<FilmDTO>(f));
        }

        public IEnumerable<FilmDTO> FindBy(Expression<Func<FilmDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public FilmDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public FilmDTO Add(FilmDTO obj)
        {
            throw new NotImplementedException();
        }

        public FilmDTO Update(FilmDTO obj)
        {
            throw new NotImplementedException();
        }

        public FilmDTO Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
