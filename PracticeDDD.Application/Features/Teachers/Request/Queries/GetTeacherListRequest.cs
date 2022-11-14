using MediatR;
using PracticeDDD.Application.DTOs;
using PracticeDDD.Application.DTOs.Teacher;
using PracticeDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Teachers.Request.Queries
{
    public class GetTeacherListRequest: IRequest<List<TeacherDto>>
    {

    }
}
