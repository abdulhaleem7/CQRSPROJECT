using PracticeDDD.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.DTOs.Teacher
{
    public class UpdateTeacherDto:BaseDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
