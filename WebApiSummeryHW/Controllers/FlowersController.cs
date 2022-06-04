using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSummeryHW.DTO;
using WebApiSummeryHW.Repos;

namespace WebApiSummeryHW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private IFlowersRepo _repo;

        public FlowersController(IFlowersRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async  Task<IActionResult> GetAllFlowers()
        {
            var flowers = await _repo.GetAllFlowersAsync();
            return Ok(flowers); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlowerById([FromRoute] int id)
        {
            var flower = await _repo.GetSingleFlower(id);
            return Ok(flower);
        }
        [HttpPost]
        public async Task<IActionResult> PostFlower([FromBody] FlowerModel flower)
        {
            await _repo.AddFlowerAsync(flower);
            return CreatedAtAction(nameof(PostFlower), flower);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _repo.DeleteFlower(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]FlowerModel flower)
        {
          var updatedFlower =  await _repo.UpdateFlower(flower);
            return Ok(updatedFlower);
        }

    }
}
