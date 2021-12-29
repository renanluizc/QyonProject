using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QyonProject.Data;
using QyonProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QyonProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public RegisterController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<RegistersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Registers.ToListAsync());
        }

        // GET api/<RegistersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult > Get(int id)
        {
            var register = await _dbContext.Registers.FindAsync(id);

            if (register == null)
            {
                return NotFound("Não há registros com o ID informado.");
            }
            return Ok(register);
        }

        // POST api/<RegistersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Register register)
        {
            await _dbContext.Registers.AddAsync(register);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<RegistersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Register registerObj)
        {
            var register = await _dbContext.Registers.FindAsync(id);

            if (register == null)
            {
                return NotFound("Não há registros com o ID informado.");
            }
            else
            {
                register.Nome = registerObj.Nome;
                register.Sexo = registerObj.Sexo;
                register.TemperaturaMediaCorpo = registerObj.TemperaturaMediaCorpo;
                register.Peso = registerObj.Peso;
                register.Altura = registerObj.Altura;
                await _dbContext.SaveChangesAsync();
                return Ok("Registro alterado com sucesso.");
            }
        }

        // DELETE api/<RegistersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var register = await _dbContext.Registers.FindAsync(id);

            if (register == null)
            {
                return NotFound("Não há registros com o ID informado.");
            }
            else
            {
                _dbContext.Registers.Remove(register);
                await _dbContext.SaveChangesAsync();
                return Ok("Registro deletado com sucesso.");
            }               
        }
    }
}
