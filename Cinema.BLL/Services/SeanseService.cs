using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
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

        public override IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<Seance, SeanceDTO>()
                              .ForMember("NameHall", opt => opt.MapFrom(h => h.Hall.NameHall))
                              .ForMember("NameFilm", opt => opt.MapFrom(f => f.Film.NameFilm));
                cfg.CreateMap<SeanceDTO, Seance>();

            }).CreateMapper();
        }
    }
}
