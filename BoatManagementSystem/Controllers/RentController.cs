using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoatManagementSystem.DAL.Models;
using BoatManagementSystem.Services.RentManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoatManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private IRentManagement _service;
        public RentController(IRentManagement service)
        {
            _service = service;
        }
        [Route("RentBoat")]
        [HttpGet]
        public async Task<IActionResult> RentBoat(Boat_RentInfo model)
        {
            try
            {
                return Ok(await _service.AllocateBoat(model));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Route("RentOut")]
        [HttpGet]
        public async Task<IActionResult> RentOut(Boat_RentInfo model)
        {
            try
            {
                return Ok(await _service.DeallocateBoat(model));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}