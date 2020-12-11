using Autofac;
using Cinema.BLL.Models;
using Cinema.BLL.Services;
using Cinema.DAL.DomainModels;
using Cinema.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Infrastructure
{
    class RegisterModule : Module // Autofac
    {
        protected override void Load(ContainerBuilder builder)
        {
            //base.Load(builder);

            // Halls - Залы 
            builder.RegisterType(typeof(HallService)).As(typeof(IGenericService<HallDTO, int>));
            builder.RegisterType(typeof(HallRepository)).As(typeof(IGenericService<Hall, int>));
            builder.RegisterType(typeof(CinemaContext)).As(typeof(DbContext));
        }
    }
}
