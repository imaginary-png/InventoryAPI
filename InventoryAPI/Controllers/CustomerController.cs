using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.Models.DTO;
using InventoryAPI.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _context;

        public CustomerController(ICustomerRepository context)
        {
            _context = context;
        }


        /// <summary>
        /// Login Endpoint
        /// </summary>
        /// <remarks>Test comment</remarks>
        /// <returns code="200"></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto userLogin)
        {
            var result = await _context.Login(userLogin);
            return Ok(result);
        }



    }
}
