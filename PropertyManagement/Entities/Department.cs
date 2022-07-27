using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Entities
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Remote("IsDepartmentUnique", "Department", HttpMethod = "POST", ErrorMessage = "Department already exists")]
        public string Name { get; set; }


        [ForeignKey("DepartmentId")]
        public ICollection<Task> Tasks { get; set; }
    }
}
