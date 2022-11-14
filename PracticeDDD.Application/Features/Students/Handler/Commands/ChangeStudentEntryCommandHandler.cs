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
using PracticeDDD.Application.Contract.Infracstructure;

namespace PracticeDDD.Application.Features.Students.Handler.Commands
{
    public class ChangeStudentEntryCommandHandler : IRequestHandler<ChangeStudentEntryCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;


        public ChangeStudentEntryCommandHandler(IStudentRepository studentRepository, IMapper mapper,IEmailSender emailSender)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<Unit> Handle(ChangeStudentEntryCommand request, CancellationToken cancellationToken)
        {
            var validator = new ChangeEntryDateStudentDtoValidator(_studentRepository);
            var validationResult = await validator.ValidateAsync(request.changeEntryDateStudentDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);


            var student = await _studentRepository.Get(request.changeEntryDateStudentDto.Id);
            _mapper.Map(request.changeEntryDateStudentDto, student);
            await _studentRepository.Update(student);
            return Unit.Value;
        }
    }
}
