using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QyonProject.Data;
using QyonProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QyonProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public HistoricController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var historics = _dbContext.Historics;
            return Ok(historics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var historic = await _dbContext.Historics.FindAsync(id);

            if (historic == null)
            {
                return NotFound("Não há histórico com o ID informado.");
            }
            return Ok(historic);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Historic historic)
        {
            await _dbContext.Historics.AddAsync(historic);
            await _dbContext.SaveChangesAsync();
            historic.DataCorrida = DateTime.Now;
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Historic historicObj)
        {
            var historic = await _dbContext.Historics.FindAsync(id);

            if (historic == null)
            {
                return NotFound("Não há histórico com o ID informado.");
            }
            else
            {
                historic.Competidor = historicObj.Competidor;
                historic.Pista = historicObj.Pista;
                historic.DataCorrida = historicObj.DataCorrida;
                historic.TempoGasto = historicObj.TempoGasto;

                await _dbContext.SaveChangesAsync();
                return Ok("Dados alterados com sucesso.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var historic = await _dbContext.Historics.FindAsync(id);

            if (historic == null)
            {
                return NotFound("Não há histórico com o ID informado.");
            }
            else
            {
                _dbContext.Historics.Remove(historic);
                await _dbContext.SaveChangesAsync();
                return Ok("Dados deletados com sucesso.");
            }
        }
    }
}
