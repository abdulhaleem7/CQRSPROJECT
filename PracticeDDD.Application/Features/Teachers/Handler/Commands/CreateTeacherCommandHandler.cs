using AutoMapper;
using MediatR;
using PracticeDDD.Application.Contract.Persistence;
using PracticeDDD.Application.DTOs.Teacher.Validators;
using PracticeDDD.Application.Exceptions;
using PracticeDDD.Application.Features.Teachers.Request.Commands;
using PracticeDDD.Application.Responses;
using PracticeDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Teachers.Handler.Commands
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand,  BaseCommandResponse>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public CreateTeacherCommandHandler(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validation = new CreateTeacherDtoValidator();
            var validationResult = await validation.ValidateAsync(request.TeacherDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Not Created";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            
            var teacher = _mapper.Map<Teacher>(request.TeacherDto);
            teacher = await _teacherRepository.Add(teacher);
            response.Message = "Successfully Created";
            response.Success = true;
            response.Id = teacher.Id;
            return response;
        }
    }
}
