using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.DataAccess.Entities
{
    public class ProjectAdminstrator
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}
