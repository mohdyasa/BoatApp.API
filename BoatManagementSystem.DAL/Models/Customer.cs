using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BoatManagementSystem.DAL.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(40,ErrorMessage = "Boat Name too large")]
        public string Name { get; set; }
    }
}
