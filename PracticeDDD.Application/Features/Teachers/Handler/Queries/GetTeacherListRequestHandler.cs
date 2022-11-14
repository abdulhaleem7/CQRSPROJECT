using AutoMapper;
using MediatR;
using PracticeDDD.Application.Contract.Persistence;
using PracticeDDD.Application.DTOs;
using PracticeDDD.Application.DTOs.Teacher;
using PracticeDDD.Application.Features.Teachers.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Features.Teachers.Handler.Queries
{
    public class GetTeacherListRequestHandler : IRequestHandler<GetTeacherListRequest, List<TeacherDto>>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public GetTeacherListRequestHandler(ITeacherRepository teacherRepository,IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public async Task<List<TeacherDto>> Handle(GetTeacherListRequest request, CancellationToken cancellationToken)
        {
            var teachers = await _teacherRepository.GetAll();
            return _mapper.Map<List<TeacherDto>>(teachers);
        }
    }
}
