using InventoryAPI.Models;
using InventoryAPI.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryAPI.Controllers.Admin
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class InventoryController : ControllerBase
    {
        private IInventoryRepository _repo;

        public InventoryController(IInventoryRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _repo.Get();
            return Ok(results);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InventoryItem itemToAdd)
        {
            if (await _repo.Add(itemToAdd))
            {
                return Created("", itemToAdd);
            }

            return Conflict();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string skuToDelete)
        {
            if (await _repo.Delete(skuToDelete))
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] InventoryItem itemToUpdate)
        {
            if (await _repo.Update(itemToUpdate))
            {
                return Ok(itemToUpdate);
            }

            return NotFound();
        }
    }
}
