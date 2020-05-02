using DinosaurApi.Models;
using DinosaurApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DinosaurApi.Models.Filters;

namespace dinosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DinosaursController : ControllerBase
    {
        private readonly DinosaursService _dinoService;

        public DinosaursController(DinosaursService dinoService)
        {
            _dinoService = dinoService;
        }

        [HttpGet]
        public async Task<List<Dinossaur>> Get() =>
            await _dinoService.Get();

        [HttpGet("filter", Name = "filter")]
        public async Task<List<Dinossaur>> Filter([FromQuery] DinossaurFilter filter) =>
            await _dinoService.Get(filter);

        [HttpGet("{id:length(24)}", Name = "Getdino")]
        public async Task<ActionResult<Dinossaur>> Get(string id)
        {
            var dino = await _dinoService.Get(id);

            if (dino == null)
            {
                return NotFound();
            }

            return dino;
        }

        [HttpPost]
        public async Task<ActionResult<Dinossaur>> Create(Dinossaur dino)
        {
            await _dinoService.Create(dino);

            return CreatedAtRoute("Getdino", new { id = dino.Id.ToString() }, dino);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Dinossaur dinoIn)
        {
            var dino = await _dinoService.Get(id);

            if (dino == null)
            {
                return NotFound();
            }

            await _dinoService.Update(id, dinoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var dino = await _dinoService.Get(id);

            if (dino == null)
            {
                return NotFound();
            }

            await _dinoService.Remove(dino.Id);

            return NoContent();
        }
    }
}