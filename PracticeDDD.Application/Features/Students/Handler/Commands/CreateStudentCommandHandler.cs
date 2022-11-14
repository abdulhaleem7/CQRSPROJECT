using AutoMapper;
using MediatR;
using PracticeDDD.Application.DTOs.Student.Validators;
using PracticeDDD.Application.Features.Students.Request.Commands;
using PracticeDDD.Application.Contract.Persistence;
using PracticeDDD.Application.Responses;
using PracticeDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticeDDD.Application.Contract.Infracstructure;
using PracticeDDD.Application.Models;

namespace PracticeDDD.Application.Features.Students.Handler.Commands
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, BaseCommandResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper,IEmailSender emailSender)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateStudentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.studentDto);
            if (validationResult.IsValid == false)
            {
                response.Success = true;
                response.Message = "Created Failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var student = _mapper.Map<Student>(request.studentDto);
            student = await _studentRepository.Add(student);
            response.Success = true;
            response.Message = "Created Successful";
            response.Id = student.Id;


            var email = new Email
            {
                To = "salaudeenhaleem7@gmail.com",
                Body = $"Your Name {request.studentDto.Name} has succesfully been created.",
                Subject = "Name Submited",

            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
