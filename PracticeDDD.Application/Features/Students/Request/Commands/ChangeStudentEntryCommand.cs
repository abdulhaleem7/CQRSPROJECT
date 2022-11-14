using MediatR;
using PracticeDDD.Application.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Students.Request.Commands
{
    public class ChangeStudentEntryCommand : IRequest<Unit>
    {
        public ChangeEntryDateStudentDto changeEntryDateStudentDto { get; set; }
    }
}
