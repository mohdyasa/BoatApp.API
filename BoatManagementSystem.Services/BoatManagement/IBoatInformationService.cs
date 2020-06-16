using BoatManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoatManagementSystem.Services.BoatManagement
{
    public interface IBoatInformationService
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Boat_Info>> GetAllBoats();
        Task<Boat_Info> GetBoatInfo(int id);
        Task<bool> DeleteBoat(int Id);
    }
}
