using BoatManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoatManagementSystem.Services.RentManagement
{
    public interface IRentManagement
    {
        public Task<string> AllocateBoat(Boat_RentInfo model);
        public Task<string> DeallocateBoat(Boat_RentInfo model);
    }
}
