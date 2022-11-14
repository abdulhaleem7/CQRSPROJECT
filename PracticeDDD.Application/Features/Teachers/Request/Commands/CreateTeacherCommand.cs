using MediatR;
using PracticeDDD.Application.DTOs.Teacher;
using PracticeDDD.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Teachers.Request.Commands
{
    public class CreateTeacherCommand:IRequest<BaseCommandResponse>
    {
        public TeacherDto TeacherDto { get; set; }
    }
}
