using FluentValidation;
using PracticeDDD.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.DTOs.Student.Validators
{
    public class ChangeEntryDateStudentDtoValidator: AbstractValidator<ChangeEntryDateStudentDto>
    {
        private readonly IStudentRepository _studentRepository;

        public ChangeEntryDateStudentDtoValidator(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

            RuleFor(x => x.StartDate)
                .LessThan(DateTime.Now).WithMessage("{PropertyName} must be before {ComparisonValue}");


            RuleFor(x => x.Id)
                .MustAsync(async (id, token) =>
                {
                    var studentExist = await _studentRepository.Exist(id);
                    return studentExist;
                }).WithMessage("ok");
        }
    }
}
