﻿using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using General.Repository.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Services
{
    public abstract class GenericService<DbObject, DbObjectDTO, TKey> : IGenericService<DbObjectDTO, TKey> where DbObjectDTO : class, new()
                                                where DbObject : class, new()
    {
        IGenericRepository<DbObject, TKey> repository;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<DbObject, TKey> repository)
        {
            this.repository = repository;
            _mapper = GetMapper();
        }

        public virtual IMapper GetMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.CreateMap<DbObject, DbObjectDTO>();
                cfg.CreateMap<DbObjectDTO, DbObject>();

            }).CreateMapper();
        }
            //
        public DbObjectDTO Add(DbObjectDTO obj)
        {
            try
            {
                DbObject dbObject = _mapper.Map<DbObject>(obj);
                repository.Create(dbObject);
                repository.Save();
                return _mapper.Map<DbObjectDTO>(dbObject);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public DbObjectDTO Delete(TKey id)
        {
            try
            {
                var objDB = repository.Get(id);
                var objDTO = _mapper.Map<DbObjectDTO>(objDB);
                repository.Delete(id);
                repository.Save();
                return objDTO;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public IEnumerable<DbObjectDTO> FindBy(Expression<Func<DbObjectDTO, bool>> predicate)
        {
            try
            {
                var predicateObj = _mapper.Map<Expression<Func<DbObject, bool>>>(predicate);
                return repository.FindBy(predicateObj).AsEnumerable().Select(obj => _mapper.Map<DbObjectDTO>(obj));
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public DbObjectDTO Get(TKey id)
        {
            try
            {
                DbObject dbObject = repository.Get(id);
                return _mapper.Map<DbObjectDTO>(dbObject);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public IEnumerable<DbObjectDTO> GetAll()
        {
            try
            {
                var collection = repository.GetAll().AsEnumerable().Select(e => _mapper.Map<DbObjectDTO>(e));
                return collection;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public DbObjectDTO Update(DbObjectDTO obj)
        {
            try
            {
                DbObject dbObject = _mapper.Map<DbObject>(obj);
                repository.Update(dbObject);
                repository.Save();
                return _mapper.Map<DbObjectDTO>(dbObject);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
