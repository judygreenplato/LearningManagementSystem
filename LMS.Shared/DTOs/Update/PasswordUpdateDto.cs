using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.DTOs.Update
{
    public class PasswordUpdateDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
