using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.DTOs.Read
{
    public class ActivityDto
    {
        public int ModuleId { get; set; }
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ActivityTypeId { get; set; }
        public ActivityTypeDto ActivityType { get; set; }

        public List<ActivityDocumentDto> ActivityDocument { get; set; }
    }
}
