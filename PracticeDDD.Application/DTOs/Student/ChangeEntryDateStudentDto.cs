using PracticeDDD.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.DTOs.Student
{
    public class ChangeEntryDateStudentDto:BaseDto
    {
        public DateTime StartDate { get; set; }
        public bool? Active { get; set; }
    }
}
