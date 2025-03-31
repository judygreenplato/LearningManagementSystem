using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class ActivityDocument
    {
        public int ActivityDocumentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UploadedAt { get; set; }

        //public Guid FileName { get; set; } // Reference to the actual file saved on the server

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
