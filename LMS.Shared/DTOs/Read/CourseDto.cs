using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.DTOs.Read
{
    public class CourseDto
    {
        // ToDo test with init on all reads
        public int CourseId { get; set; }
        [Display(Name = "Kursnamn")]
        public string Name { get; set; }
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        [Display(Name = "Startdatum")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Slutdatum")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Kursdokument")]
        public List<CourseDocumentDto> CourseDocuments { get; set; }
        [Display(Name = "Moduler")]
        public List<ModuleDto> Modules { get; set; }
        [Display(Name = "Kursdeltagare")]
        public List<UserDto> Users { get; set; }
    }
}
