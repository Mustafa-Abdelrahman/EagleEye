using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.DataAccess.ViewModels
{
    public class DashboardTableViewModel
    {
        public string ProjectName { get; set; }
        public string AdminName { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Budget { get; set; }
        public string Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
