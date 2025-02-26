using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DALGenericoImpl<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {

        private PeliculasContext _peliculasContext;

        public DALGenericoImpl(PeliculasContext peliculasContext)
        {

            _peliculasContext = peliculasContext;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _peliculasContext.Add(entity);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public TEntity Get(int id)
        {

            return _peliculasContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _peliculasContext.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _peliculasContext.Set<TEntity>().Attach(entity);
                _peliculasContext.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _peliculasContext.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
