using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BoatManagementSystem.DAL.Models
{
   public class Boat_Info
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BoatName { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public double HourlyRate { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string  ModifiedBy { get; set; }
    }
}
