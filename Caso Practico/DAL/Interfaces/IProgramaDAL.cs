using DAL.Implementations;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProgramaDAL : IDALGenerico<Programa>
    {
        List<Programa> GetAllProgramas();
    }
}
