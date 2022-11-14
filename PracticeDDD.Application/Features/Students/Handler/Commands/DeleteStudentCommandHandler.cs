using AutoMapper;
using MediatR;
using PracticeDDD.Application.DTOs.Student.Validators;
using PracticeDDD.Application.Exceptions;
using PracticeDDD.Application.Features.Students.Request.Commands;
using PracticeDDD.Application.Contract.Persistence;
using PracticeDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Students.Handler.Commands
{
    public class DeleteStudentCommandHandler:IRequestHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.Get(request.Id);
            if (student == null)
                throw new NotFoundException(nameof(Student), request.Id);
            await _studentRepository.Delete(student);
            return Unit.Value;
        }
    }
}
