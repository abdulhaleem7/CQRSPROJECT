using FluentValidation;
using PracticeDDD.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.DTOs.Teacher.Validators
{
    public class UpdateTeacherDtoValidator: AbstractValidator<UpdateTeacherDto>
    {
        private readonly ITeacherRepository _teacherRepository;

        public UpdateTeacherDtoValidator(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;


            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("{ProperName} must not be null")
                .MaximumLength(11).WithMessage("{ProperName} must be 11 numbers");


            RuleFor(x => x.Id)
                .MustAsync(async (id, token) =>
                {
                    var studentExist = await _teacherRepository.Exist(id);
                    return studentExist;
                }).WithMessage("ok");
        }
    }
}
