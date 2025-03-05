using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ProgramaHelper : IProgramaHelper
    {
        IServiceRepository _ServiceRepository;

        ProgramaViewModel Convertir(ProgramaAPI programa)
        {
            ProgramaViewModel programaViewModel = new ProgramaViewModel
            {
                ProgramaId = programa.ProgramaId,
                Nombre = programa.Nombre,
                Tipo = programa.Tipo,
                Categoria = programa.Categoria
            };
            return programaViewModel;
        }


        public ProgramaHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        public ProgramaViewModel Add(ProgramaViewModel programa)
        {
            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Programa", programa);
            if (response.IsSuccessStatusCode)
            {

                var content = response.Content.ReadAsStringAsync().Result;
            }
            return programa;
        }

        public void Delete(int id)
        {
            HttpResponseMessage response = _ServiceRepository.DeleteResponse("api/Programa/" + id.ToString());
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al eliminar el programa");
            }
        }


        public List<ProgramaViewModel> GetProgramas()
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Programa");
            List<ProgramaAPI> programas = new List<ProgramaAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                programas = JsonConvert.DeserializeObject<List<ProgramaAPI>>(content);
            }
            List<ProgramaViewModel> lista = new List<ProgramaViewModel>();
            foreach (var programa in programas)
            {
                lista.Add(Convertir(programa));
            }
            return lista;
        }

        public ProgramaViewModel GetPrograma(int? id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Programa/" + id.ToString());
            ProgramaAPI programa = new ProgramaAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                programa = JsonConvert.DeserializeObject<ProgramaAPI>(content);
            }

            ProgramaViewModel resultado = Convertir(programa);


            return resultado;
        }

        public ProgramaViewModel Update(ProgramaViewModel programa)
        {
            HttpResponseMessage response = _ServiceRepository.PutResponse("api/Programa", programa);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<ProgramaViewModel>(content);
            }
            else
            {
                throw new Exception("Error al actualizar el programa");
            }
        }

    }
}

