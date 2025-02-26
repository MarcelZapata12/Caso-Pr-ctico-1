using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ProgramaDAL : DALGenericoImpl<Programa>, IProgramaDAL
    {
        private PeliculasContext _context;

        public ProgramaDAL(PeliculasContext context) : base(context)
        {
            _context = context;
        }
        public List<Programa> GetAllProgramas()
        {
            string query = "sp_GetAllProgramas";

            var resul = _context.Programas.FromSqlRaw(query);


            return resul.ToList();
        }

        public bool Add(Programa entity)
        {
            try
            {
                string sql = "exec [dbo].[sp_AddPrograma] @Nombre, @Tipo, @Categoria";

                var param = new SqlParameter[]
                {
            new SqlParameter()
            {
                ParameterName = "@Nombre",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Value = entity.Nombre
            },
            new SqlParameter()
            {
                ParameterName = "@Tipo",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = entity.Tipo
            },
            new SqlParameter()
            {
                ParameterName = "@Categoria",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = entity.Categoria
            }
                };

                _context
                    .Database
                    .ExecuteSqlRaw(sql, param);
                return true;
            }
            catch (Exception e)
            {
                // Optionally log the exception
                return false;
            }
        }


        public bool Update(Programa entity)
        {
            try
            {
                _context.Programas.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var entity = _context.Programas.Find(id);
                if (entity != null)
                {
                    _context.Programas.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
