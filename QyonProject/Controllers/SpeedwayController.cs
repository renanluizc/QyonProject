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
    public class SpeedwayController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public SpeedwayController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var speedways =  _dbContext.Speedways;
            return Ok(speedways);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var speedway = await _dbContext.Speedways.FindAsync(id);

            if (speedway == null)
            {
                return NotFound("Não há pistas com o ID informado.");
            }
            return Ok(speedway);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Speedway speedway)
        {
            await _dbContext.Speedways.AddAsync(speedway);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Speedway speedwayObj)
        {
            var speedway = await _dbContext.Speedways.FindAsync(id);

            if (speedway == null)
            {
                return NotFound("Não há pistas com o ID informado.");
            }
            else
            {
                speedway.Descricao = speedwayObj.Descricao;

                await _dbContext.SaveChangesAsync();
                return Ok("Pista alterada com sucesso.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var speedway = await _dbContext.Speedways.FindAsync(id);

            if (speedway == null)
            {
                return NotFound("Não há pistas com o ID informado.");
            }
            else
            {
                _dbContext.Speedways.Remove(speedway);
                await _dbContext.SaveChangesAsync();
                return Ok("Pista deletada com sucesso.");
            }
        }
    }
}
