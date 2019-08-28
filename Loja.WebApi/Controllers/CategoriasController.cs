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
    public class CategoriasController : ControllerBase
    {
        private readonly ILojaRepository _repo;
        public CategoriasController(ILojaRepository repo)
        {
            _repo = repo;            
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var results = await _repo.GetAllCategoriasAsync();
               return Ok(results);
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
               var results = await _repo.GetCategoriasAsyncById(Id);
               return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }
        
        // GET api/values
        [HttpPost]
        public async Task<IActionResult> Post(Categorias model)
        {
            try
            {
               _repo.Add(model);

               if(await _repo.SaveChangesAsync())
               {
                  return Created($"/api/Categorias/{model.Id}", model);
               }           
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            return BadRequest();
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, Categorias model)
        {
            try
            {
                var categoria = await _repo.GetCategoriasAsyncById(Id);
                if(categoria == null ) return NotFound();

               _repo.Update(model);
               if(await _repo.SaveChangesAsync())
               {
                  return Created($"/api/Categorias/{model.Id}", model);
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
                var categoria = await _repo.GetCategoriasAsyncById(Id);
                if(categoria == null ) return NotFound();

               _repo.Delete(categoria);
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
