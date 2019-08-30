using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Loja.Repository;
using Microsoft.AspNetCore.Http;
using Loja.Domain;

namespace Loja.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensPedidosController : ControllerBase
    {
        private readonly ILojaRepository _repo;
        public ItensPedidosController(ILojaRepository repo)
        {
            _repo = repo;            
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var itens = await _repo.GetAllItensPedidosAsync();
               return Ok(itens);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        // GET api/values
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
               var itens = await _repo.GetItensPedidosAsyncById(Id);
               return Ok(itens);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }
        
        // GET api/values
        [HttpPost]
        public async Task<IActionResult> Post(ItensPedidos model)
        {
            try
            {
               _repo.Add(model);

               if(await _repo.SaveChangesAsync())
               {
                  return Created($"/api/ItensPedidos/{model.Id}", model);
               }           
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            return BadRequest();
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, ItensPedidos model)
        {
            try
            {
                var itens = await _repo.GetItensPedidosAsyncById(Id);
                if(itens == null ) return NotFound();

               _repo.Update(model);
               if(await _repo.SaveChangesAsync())
               {
                  return Created($"/api/ItensPedidos/{model.Id}", model);
               }
              
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var itens = await _repo.GetItensPedidosAsyncById(Id);
                if(itens == null ) return NotFound();

               _repo.Delete(itens);
               if(await _repo.SaveChangesAsync())
               {
                  return Ok();
               }
              
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            return BadRequest();
        }
    }
}
