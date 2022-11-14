using MediatR;
using PracticeDDD.Application.DTOs.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Teachers.Request.Commands
{
    public class UpdateTeacherCommand:IRequest<Unit>
    {
        public UpdateTeacherDto updateTeacherDto { get; set; }
    }
}
