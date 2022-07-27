using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime TimePosted { get; set; }

        public DateTime TimeEdited { get; set; }

        public int DepartmentId { get; set; }
        public int PriorityId { get; set; }
        public int RoomId { get; set; }

        [ForeignKey("TaskId")]
        public virtual ICollection<UserTask> UserTask { get; set; }



    }
}
