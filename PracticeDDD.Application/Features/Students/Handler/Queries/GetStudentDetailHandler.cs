using AutoMapper;
using MediatR;
using PracticeDDD.Application.DTOs;
using PracticeDDD.Application.DTOs.Student;
using PracticeDDD.Application.Features.Students.Request.Queries;
using PracticeDDD.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Students.Handler.Queries
{
    public class GetStudentDetailHandler : IRequestHandler<GetStudentDetailRequest, StudentRequestDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentDetailHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<StudentRequestDto> Handle(GetStudentDetailRequest request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.Get(request.Id);
            return _mapper.Map<StudentRequestDto>(student);
        }
    }
}
