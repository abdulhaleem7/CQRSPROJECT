using FluentValidation;
using PracticeDDD.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.DTOs.Student.Validators
{
    public class UpdateStudentDtoValidator:AbstractValidator<UpdateStudentDto>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentDtoValidator(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("{ProperName} must not be null")
                .MaximumLength(11).WithMessage("{ProperName} must be 11 numbers");

            RuleFor(x => x.Id)
                .MustAsync(async (id, token) =>
                {
                    var studentExist = await _studentRepository.Exist(id);
                    return studentExist;
                }).WithMessage("ok");
        }
    }
}
