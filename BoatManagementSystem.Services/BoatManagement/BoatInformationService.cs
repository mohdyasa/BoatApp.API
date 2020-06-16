using BoatManagementSystem.DAL.Models;
using BoatManagementSystem.DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatManagementSystem.Services.BoatManagement
{
    public class BoatInformationService : IBoatInformationService
    {
        private readonly BoatManagementDBContext _context;
        public BoatInformationService(BoatManagementDBContext context)
        {
            this._context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            try
            {
                _context.Add(entity);
                _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            try
            {
                _context.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteBoat(int Id)
        {
            var boatInfo = await _context.Boat_Info.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (boatInfo == null)
                return false;
            else
                boatInfo.IsAvailable = false;
           await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Boat_Info>> GetAllBoats()
        {
            try
            {
                var boat_Infos = await _context.Boat_Info.ToListAsync();
                return boat_Infos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Boat_Info> GetBoatInfo(int id)
        {
            try
            {
                var boat_Info = await _context.Boat_Info.FirstOrDefaultAsync(u => u.Id == id);
                return boat_Info;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
