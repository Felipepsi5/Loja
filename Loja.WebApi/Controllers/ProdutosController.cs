using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Loja.Repository;
using Microsoft.AspNetCore.Http;

namespace Loja.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ILojaRepository _repo;
        public ProdutosController(ILojaRepository repo)
        {
            _repo = repo;            
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var results = await _repo.GetAllProdutosAsync();
               return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        // GET api/values
        [HttpGet("ProdutoId")]
        public async Task<IActionResult> Get(int ProdutoId)
        {
            try
            {
               var results = await _repo.GetProdutosAsyncById(ProdutoId);
               return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }
        
        // GET api/values
        [HttpPost]
        public async Task<IActionResult> Post(Produto model)
        {
            try
            {
               _repo.Add(model);
               if(await _repo.SaveChangesAsync())
               {
                  return Created($"/api/Produto/{model.Id}", model);
               }
              
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Put(int ProdutoId, Produto model)
        {
            try
            {
                var produto = await _repo.GetProdutosAsyncById(ProdutoId)
                if(produto == null ) return NotFound();

               _repo.Update(model);
               if(await _repo.SaveChangesAsync())
               {
                  return Created($"/api/Produto/{model.Id}", model);
               }
              
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Put(int ProdutoId)
        {
            try
            {
                var produto = await _repo.GetProdutosAsyncById(ProdutoId)
                if(produto == null ) return NotFound();

               _repo.Delete(model);
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
