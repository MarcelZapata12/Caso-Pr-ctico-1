using BackEnd.DTO;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramaController : ControllerBase
    {

        IProgramaService _programaService;


        public ProgramaController(IProgramaService programaService)
        {
            _programaService = programaService;
        }

        // GET: api/<ProgramaController>
        [HttpGet]
        public IEnumerable<ProgramaDTO> Get()
        {
            return _programaService.GetPrograma();
        }

        // GET api/<ProgramaController>/5
        [HttpGet("{id}")]
        public ProgramaDTO Get(int id)
        {
            return _programaService.GetProgramaById(id);
        }

        // POST api/<ProgramaController>
        [HttpPost]
        public void Post([FromBody] ProgramaDTO programa)
        {
            _programaService.AddPrograma(programa);

        }

        // PUT api/<ProgramaController>/5
        [HttpPut]
        public void Put([FromBody] ProgramaDTO programa)
        {
            try
            {
                _programaService.UpdatePrograma(programa);
            }
            catch (Exception e)
            {

            }
        }

        // DELETE api/<ProgramaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _programaService.DeletePrograma(id);
        }
    }
}
