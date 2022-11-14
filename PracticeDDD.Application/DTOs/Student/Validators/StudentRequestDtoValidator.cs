using FluentValidation;
using PracticeDDD.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.DTOs.Student.Validators
{
    public class StudentRequestDtoValidator: AbstractValidator<StudentRequestDto>
    {
        private readonly IStudentRepository _studentRepository;

        public StudentRequestDtoValidator(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(x => x.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(x => x.Id)
                .MustAsync(async (id, token) =>
                {
                    var studentexist = await _studentRepository.Exist(id);
                    return !studentexist;
                }).WithMessage("{PropertyName} does not exist");
        }
    }
}
