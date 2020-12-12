using Autofac;
using Cinema.BLL.Models;
using Cinema.BLL.Infrastructure;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Linq;
using Cinema.BLL.Services;

namespace WpfUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        IGenericService<SeanceDTO,int> service;
        private List<SeanceDTO> _seances;
        public MainViewModel()
        {
            IContainer container = BuildContainer();
            service = container.Resolve<IGenericService<SeanceDTO, int>>();
            Seances = service.GetAll().Where(s => s.StartTime >= DateTime.Today).ToList();      
        }

        public List<SeanceDTO> Seances
        {
            get { return _seances; }
            set { _seances = value; OnProperty(); }
        }
        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RegisterModule>();
            return builder.Build();
        }
    }
}
