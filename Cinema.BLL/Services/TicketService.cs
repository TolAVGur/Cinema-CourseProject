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
    public class TicketService : IGenericService<TicketDTO, int>
    {
        IGenericRepository<Ticket, int> repository;
        IMapper mapper;
        protected Action<IMapperConfigurationExpression> _cfg;

        public TicketService(IGenericRepository<Ticket, int> repository)
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
                    cfg.CreateMap<Ticket, TicketDTO>();
                    cfg.CreateMap<TicketDTO, Ticket>();
                });
            }
            else
            {
                return new MapperConfiguration(_cfg);
            }
        }

        public IEnumerable<TicketDTO> GetAll()
        {
            return repository.GetAll().AsEnumerable().Select(t => mapper.Map<TicketDTO>(t));
        }

        public IEnumerable<TicketDTO> FindBy(Expression<Func<TicketDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TicketDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public TicketDTO Add(TicketDTO obj)
        {
            throw new NotImplementedException();
        }

        public TicketDTO Update(TicketDTO obj)
        {
            throw new NotImplementedException();
        }

        public TicketDTO Delete(int id)
        {
            throw new NotImplementedException();
        }
        //

    }
}
