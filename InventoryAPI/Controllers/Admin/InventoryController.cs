using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.Models.Repository.Interfaces;

namespace InventoryAPI.Controllers.Admin
{
    [Route("api/Admin/[controller]")]
    [ApiController]
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



    }
}
