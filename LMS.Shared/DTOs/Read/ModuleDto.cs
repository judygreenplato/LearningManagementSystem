using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.DTOs.Read
{
    public class ModuleDto
    {
        public int ModuleId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public List<ModuleDocumentDto> ModuleDocuments { get; set; }
        public List<ActivityDto> Activities { get; set; }
    }
}
