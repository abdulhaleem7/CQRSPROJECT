using AutoMapper;
using MediatR;
using PracticeDDD.Application.Contract.Persistence;
using PracticeDDD.Application.DTOs.Teacher.Validators;
using PracticeDDD.Application.Exceptions;
using PracticeDDD.Application.Features.Teachers.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Teachers.Handler.Commands
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, Unit>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public UpdateTeacherCommandHandler(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var validation = new UpdateTeacherDtoValidator(_teacherRepository);
            var validationResult = await validation.ValidateAsync(request.updateTeacherDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var teacher = await _teacherRepository.Get(request.updateTeacherDto.Id);
            _mapper.Map(request.updateTeacherDto, teacher);
            await _teacherRepository.Update(teacher);
            return Unit.Value;
        }
    }
}
