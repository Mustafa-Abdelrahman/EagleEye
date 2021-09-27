using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.DataAccess.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        public int AreaId { get; set; }
        public int StatusId { get; set; } // In-Progress ,Ended , On-Hold
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public bool PassedDeadline { get; set; }
        public ProjectAdminstrator Adminstrator { get; set; }
        public int AdminstratorId { get; set; }
        public decimal Budget { get; set; }
        public string XCoordinate { get; set; }
        public string YCoordinate { get; set; }
    }
}
