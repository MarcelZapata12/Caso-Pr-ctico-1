using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IProgramaHelper
    {
        List<ProgramaViewModel> GetProgramas();
        ProgramaViewModel GetPrograma(int? id);
        ProgramaViewModel Add(ProgramaViewModel programa);
        ProgramaViewModel Update(ProgramaViewModel programa);
        void Delete(int id);
    }
}
