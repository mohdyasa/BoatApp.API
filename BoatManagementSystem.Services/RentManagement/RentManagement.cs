using BoatManagementSystem.DAL.Models;
using BoatManagementSystem.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatManagementSystem.Services.RentManagement
{
    public class RentManagement : IRentManagement
    {
        private readonly BoatManagementDBContext _context;
        public RentManagement(BoatManagementDBContext context)
        {
            this._context = context;
        }
        public async Task<string> AllocateBoat(Boat_RentInfo model)
        {
            try
            {
                var boatInfo = await _context.Boat_RentInfo.Where(x => x.BoatId != model.BoatId && model.ReturnedStatus == true).FirstOrDefaultAsync();
                if(boatInfo == null)
                {
                    model.ReturnedStatus = false;
                    _context.Boat_RentInfo.Add(model);
                    _context.SaveChanges();
                    return "Boat rented successfully";
                }
                else
                {
                    return $"Boat with no {model.ModifiedBy} is currently unavilable";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeallocateBoat(Boat_RentInfo model)
        {
            try
            {
                var boatInfo = _context.Boat_RentInfo.Include(b => b.Boat_Info).Where(x => x.BoatId != model.BoatId && model.ReturnedStatus == false).FirstOrDefault();
                if (boatInfo == null)
                    return "Only rented out boats can be returned";
                else
                    boatInfo.ReturnedStatus = true;
               await _context.SaveChangesAsync();
                double rentTime = (DateTime.Now - boatInfo.CreatedOn).TotalHours;
                return $"Rent time: {rentTime}, Amount to be paid: {rentTime * model.Boat_Info.HourlyRate}";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
