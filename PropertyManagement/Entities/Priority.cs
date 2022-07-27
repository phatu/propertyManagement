using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Entities
{
    public class Priority
    {

        public int Id { get; set; }

        [Required]
        [Remote("IsPriorityUnique", "Priority", HttpMethod = "POST", ErrorMessage = "Priority Name already exists")]
        public string Name { get; set; }


        [Required]
        [Remote("IsColorUnique", "Priority", HttpMethod = "POST", ErrorMessage = "Color already exists")]
        public string Color { get; set; }


        [ForeignKey("PriorityId")]
        public ICollection<Task> Tasks { get; set; }

    }
}
