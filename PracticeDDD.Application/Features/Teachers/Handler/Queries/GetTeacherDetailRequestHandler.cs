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
    public class GetTeacherDetailRequestHandler : IRequestHandler<GetTeacherDetailRequest, TeacherDto>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public GetTeacherDetailRequestHandler(ITeacherRepository teacherRepository,IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public async Task<TeacherDto> Handle(GetTeacherDetailRequest request, CancellationToken cancellationToken)
        {
            var teacher = await _teacherRepository.Get(request.Id);
            return _mapper.Map<TeacherDto>(teacher);
        }
    }
}
