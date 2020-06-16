using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BoatManagementSystem.DAL.Models
{
    public class Boat_RentInfo
    {
        [Key]
        public int Id { get; set; }
        public int BoatId { get; set; }
        public string CustomerName { get; set; }
        public Boat_Info Boat_Info { get; set; }
        public DateTime RentedDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatdBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool ReturnedStatus { get; set; }

    }
}
