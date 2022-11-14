using AutoMapper;
using MediatR;
using PracticeDDD.Application.Contract.Persistence;
using PracticeDDD.Application.DTOs;
using PracticeDDD.Application.DTOs.Student;
using PracticeDDD.Application.Features.Students.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Students.Handler.Queries
{
    public class GetStudentListRequestHandler : IRequestHandler<GetStudentListRequest, List<StudentRequestListDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentListRequestHandler(IStudentRepository studentRepository,IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<List<StudentRequestListDto>> Handle(GetStudentListRequest request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetAll();
            return _mapper.Map<List<StudentRequestListDto>>(student);
        }
    }
}
