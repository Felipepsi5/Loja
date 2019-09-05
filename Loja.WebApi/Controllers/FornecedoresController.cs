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
    public class FornecedoresController : ControllerBase
    {
        private readonly ILojaRepository _repo;
        public FornecedoresController(ILojaRepository repo)
        {
            _repo = repo;            
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var results = await _repo.GetAllFornecedoresAsync();
               return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
               var results = await _repo.GetFornecedoresAsyncById(Id);
               return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Fornecedores model)
        {
            try
            {
               _repo.Add(model);               
               if(await _repo.SaveChangesAsync())
               {
                  return Created($"/api/Fornecedores/{model.Id}", model);
               }              
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            return BadRequest();
        }        
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, Fornecedores model)
        {
            try
            {
                var fornecedor = await _repo.GetFornecedoresAsyncById(Id);
                if(fornecedor == null ){ return NotFound();}
               _repo.Update(model);     
               if(await _repo.SaveChangesAsync())
               {
                 return Created($"/api/Fornecedores/{model.Id}", model);   
               }                      
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var fornecedor = await _repo.GetFornecedoresAsyncById(id);
                if(fornecedor == null ) return NotFound();

               _repo.Delete(fornecedor);
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
