using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.DTOs.Teacher.Validators
{
    public class CreateTeacherDtoValidator: AbstractValidator<TeacherDto>
    {
        public CreateTeacherDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PrpertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 character");



            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("{PrpertyName} is required")
                .NotNull()
                .MaximumLength(11).WithMessage("{PropertyName} must not exceed 11 numbers");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PrpertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 character");

        }
    }
}
