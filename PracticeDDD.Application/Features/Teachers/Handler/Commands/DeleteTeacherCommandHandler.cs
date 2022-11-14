using AutoMapper;
using MediatR;
using PracticeDDD.Application.Contract.Persistence;
using PracticeDDD.Application.Exceptions;
using PracticeDDD.Application.Features.Teachers.Request.Commands;
using PracticeDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Teachers.Handler.Commands
{
    public class DeleteTeacherCommandHandler:IRequestHandler<DeleteTeacherCommand>
    {
        private readonly ITeacherRepository _teacherRepository;

        public DeleteTeacherCommandHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<Unit> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.Get(request.Id);
            if (teacher == null)
                throw new NotFoundException(nameof(Teacher), request.Id);
            await _teacherRepository.Delete(teacher);
            return Unit.Value;
        }
    }
}
