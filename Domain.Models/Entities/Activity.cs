using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }

        public List<ActivityDocument> ActivityDocument { get; set; }
    }
}
