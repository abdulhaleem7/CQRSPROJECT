using MediatR;
using PracticeDDD.Application.DTOs;
using PracticeDDD.Application.DTOs.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Teachers.Request.Queries
{
    public class GetTeacherDetailRequest: IRequest<TeacherDto>
    {
        public int Id { get; set; }
    }
}
