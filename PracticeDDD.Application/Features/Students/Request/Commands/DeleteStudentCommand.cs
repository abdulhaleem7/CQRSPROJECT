using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Students.Request.Commands
{
    public class DeleteStudentCommand:IRequest
    {
        public int Id { get; set; }
    }
}
