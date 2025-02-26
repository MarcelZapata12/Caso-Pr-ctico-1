using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IProgramaDAL ProgramaDAL { get; set; }

        private PeliculasContext _peliculaContext;

        public UnidadDeTrabajo(PeliculasContext peliculaContext,IProgramaDAL programaDAL)
        {
            this._peliculaContext = peliculaContext;
            this.ProgramaDAL = programaDAL;

        }


        public bool Complete()
        {
            try
            {
                _peliculaContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._peliculaContext.Dispose();
        }
    }
}
