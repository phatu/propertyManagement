using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Entities
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [Remote("IsRoomNumberUnique", "Room", HttpMethod = "POST", ErrorMessage = "Room Number already exists")]

        public int Number { get; set; }

        [Required]
        [Remote("IsCapacityValid", "Room", HttpMethod = "POST", ErrorMessage = "Capacity must be a positive whole number")]
        
        public int Capacity { get; set; }

        [Required]
        [Remote("IsSingleBedValid", "Room", HttpMethod = "POST", ErrorMessage = "Capacity must be a positive whole number")]
        [Display(Name ="Single Bed")]
        public int SingleBed { get; set; }

        [Required]
        [Display(Name = "Double Bed")]
        public int DoubleBed { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool Status { get; set; }

        [ForeignKey("RoomId")]
        public ICollection<Task> Tasks { get; set; }

    }
}
