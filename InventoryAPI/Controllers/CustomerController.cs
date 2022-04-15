using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryAPI.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private DatabaseContext _context;

        public CustomerController(DatabaseContext context)
        {
            _context = context;
        }



    }
}
