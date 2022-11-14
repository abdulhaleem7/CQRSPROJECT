using AutoMapper;
using MediatR;
using PracticeDDD.Application.DTOs.Student.Validators;
using PracticeDDD.Application.Exceptions;
using PracticeDDD.Application.Features.Students.Request.Commands;
using PracticeDDD.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Students.Handler.Commands
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateStudentDtoValidator(_studentRepository);
            var validationResult = await validator.ValidateAsync(request.UpdatestudentDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var student = await _studentRepository.Get(request.Id);
            if (request.UpdatestudentDto != null)
            {
               
                _mapper.Map(request.UpdatestudentDto, student);
                await _studentRepository.Update(student);
            }
            else if(request.ChangeEntryDateStudentDto != null )
            {
                await _studentRepository.ChangeEntryDateStatus(student,request.ChangeEntryDateStudentDto.Active);
            }
           
            return Unit.Value;
        }
    }
}
