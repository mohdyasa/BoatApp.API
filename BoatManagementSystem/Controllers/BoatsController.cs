using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BoatManagementSystem.DAL.Models;
using BoatManagementSystem.Services.BoatManagement;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoatManagementSystem.Controllers
{
    [Route("api/[controller]")]
    public class BoatsController : Controller
    {
        private IBoatInformationService _service;
        public BoatsController(IBoatInformationService service)
        {
           _service = service;
        }
        [Route("GetBoats")]
        [HttpGet]
        public async Task<IActionResult> GetBoats()
        {
            try
            {
                return Ok(await _service.GetAllBoats());
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetBoatInfo(int Id)
        {
            try
            {
                return Ok(await _service.GetBoatInfo(Id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("AddBoat")]
        [HttpPost]
        public IActionResult AddBoat([FromForm] Boat_Info model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UploadedFile(model.Image);
                    _service.Add(model);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                //Logger.Error(ex)
                throw;
            }
        }

        [Route("DeleteBoat")]
        [HttpPost]
        public IActionResult DeleteBoat(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(_service.DeleteBoat(Id));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                //Logger.Error(ex)
                throw;
            }
        }
        #region Helpers
        private string UploadedFile(IFormFile image)
        {
            string uniqueFileName = null;

            if (image != null)
            {
                string uploadsFolder = 
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        #endregion
    }
}