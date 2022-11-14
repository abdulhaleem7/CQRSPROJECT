using MediatR;
using PracticeDDD.Application.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Students.Request.Queries
{
    public class GetStudentDetailRequest:IRequest<StudentRequestDto>
    {
        public int Id { get; set; }
    }
}
