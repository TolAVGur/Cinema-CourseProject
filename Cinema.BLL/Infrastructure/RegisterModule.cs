using Autofac;
using Cinema.BLL.Models;
using Cinema.BLL.Services;
using Cinema.DAL.DomainModels;
using Cinema.Repository.Repositories;
using System.Data.Entity;

namespace Cinema.BLL.Infrastructure
{
    class RegisterModule : Module // Autofac
    {
        protected override void Load(ContainerBuilder builder)
        {
            //base.Load(builder);
            builder.RegisterType(typeof(CinemaContext)).As(typeof(DbContext));

            // Films - Фильмы
            builder.RegisterType(typeof(FilmService)).As(typeof(IGenericService<FilmDTO, int>));
            builder.RegisterType(typeof(FilmRepository)).As(typeof(IGenericService<Film, int>));

            // Halls - Залы 
            builder.RegisterType(typeof(HallService)).As(typeof(IGenericService<HallDTO, int>));
            builder.RegisterType(typeof(HallRepository)).As(typeof(IGenericService<Hall, int>));

            // lines - Ряды в залах
            builder.RegisterType(typeof(LineService)).As(typeof(IGenericService<LineDTO, int>));
            builder.RegisterType(typeof(LineRepository)).As(typeof(IGenericService<line, int>));

            // Seances - Сеансы
            builder.RegisterType(typeof(SeanseService)).As(typeof(IGenericService<SeanceDTO, int>));
            builder.RegisterType(typeof(SeanseRepository)).As(typeof(IGenericService<Seance, int>));

            // Tickets - Билеты
            builder.RegisterType(typeof(TicketService)).As(typeof(IGenericService<TicketDTO, int>));
            builder.RegisterType(typeof(TicketRepository)).As(typeof(IGenericService<Ticket, int>));

            // Visitors - Клиенты
            builder.RegisterType(typeof(VisitorService)).As(typeof(IGenericService<VisitorDTO, int>));
            builder.RegisterType(typeof(VisitorRepository)).As(typeof(IGenericService<Visitor, int>));
        }
    }
}
