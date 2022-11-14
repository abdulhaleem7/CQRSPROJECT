using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.DTOs.Student.Validators
{
    public class CreateStudentDtoValidator: AbstractValidator<StudentDto>
    {
        public CreateStudentDtoValidator()
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
