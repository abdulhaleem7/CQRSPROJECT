using MediatR;
using PracticeDDD.Application.DTOs.Student;
using PracticeDDD.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Students.Request.Commands
{
    public class CreateStudentCommand: IRequest<BaseCommandResponse>
    {
        public StudentDto studentDto { get; set; }
    }
}
