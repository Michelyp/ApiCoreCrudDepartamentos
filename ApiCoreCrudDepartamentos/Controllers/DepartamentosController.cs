using ApiCoreCrudDepartamentos.Models;
using ApiCoreCrudDepartamentos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDepartamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;
        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> GetDepartamentos()
        {
            return await this.repo.GetDepartamentosAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> FindDepartamento(int id)
        {
            return await this.repo.FindDepartamentoAsync(id);
        }
        //los métodos por defecto post o put reciben un objeto
        //Podemos personalizar la respuesta en el caso que no nos guste algo
        [HttpPost]
        public async Task<ActionResult> PostDepartamento (Departamento departamento)
        {
            await this.repo.InsertarDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if(await this.repo.FindDepartamentoAsync(id) == null)
            {
                return NotFound();
            }
            else
            {
                await this.repo.DeleteDepartamentoAsync(id);
                return Ok();
            }
        }
        [HttpPut]
        public async Task<ActionResult> Update(Departamento depar)
        {
            await this.repo.UpdateDepartamentoAsync(depar.IdDepartamento, depar.Nombre, depar.Localidad);
            return Ok();
        }
        //Podemos tener todos los métodos Post/put/delete
        [HttpPost]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public async Task<ActionResult> InsertParams( int id, string nombre, string localidad)
        {
            await this.repo.InsertarDepartamentoAsync(id, nombre, localidad);
            return Ok();
        }
        ////También se puede combinar recibir objetos con route, el objeto siempre tiene que ir como último
        //[HttpPut]
        //[Route("[action]/{id}")]
        //public async Task
    }

}
