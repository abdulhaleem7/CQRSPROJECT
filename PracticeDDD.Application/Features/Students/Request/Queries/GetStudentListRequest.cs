using MediatR;
using PracticeDDD.Application.DTOs;
using PracticeDDD.Application.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Students.Request.Queries
{
    public class GetStudentListRequest:IRequest<List<StudentRequestListDto>>
    {

    }
}
