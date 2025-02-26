using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ProgramaService : IProgramaService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;

        public ProgramaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Programa Convertir(ProgramaDTO programa)
        {
            return new Programa
            {
                ProgramaId = programa.ProgramaId,
                Nombre = programa.Nombre,
                Tipo = programa.Tipo,
                Categoria = programa.Categoria
            };
        }

        ProgramaDTO Convertir(Programa programa)
        {
            return new ProgramaDTO
            {
                ProgramaId = programa.ProgramaId,
                Nombre = programa.Nombre,
                Tipo = programa.Tipo,
                Categoria = programa.Categoria
            };
        }

        public void AddPrograma(ProgramaDTO programa)
        {
            var programaEntity = Convertir(programa);
            _unidadDeTrabajo.ProgramaDAL.Add(programaEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeletePrograma(int id)
        {
            var programa = new Programa { ProgramaId = id };
            _unidadDeTrabajo.ProgramaDAL.Remove(programa);
            _unidadDeTrabajo.Complete();
        }

        public List<ProgramaDTO> GetPrograma()
        {
            var result = _unidadDeTrabajo.ProgramaDAL.GetAllProgramas();

            List<ProgramaDTO> programa = new List<ProgramaDTO>();
            foreach (var item in result)
            {
                programa.Add(Convertir(item));
            }
            return programa;
        }

        public void UpdatePrograma(ProgramaDTO programa)
        {
            var programaEntity = Convertir(programa);
            _unidadDeTrabajo.ProgramaDAL.Update(programaEntity);
            _unidadDeTrabajo.Complete();
        }

        public ProgramaDTO GetProgramaById(int id)
        {
            var result = _unidadDeTrabajo.ProgramaDAL.Get(id);
            return Convertir(result);
        }
    }
}
