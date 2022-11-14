using AutoMapper;
using PracticeDDD.Application.DTOs;
using PracticeDDD.Application.DTOs.Student;
using PracticeDDD.Application.DTOs.Teacher;
using PracticeDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Student Mapping
            CreateMap<Student, StudentRequestDto>().ReverseMap();
            CreateMap<Student, StudentRequestListDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, ChangeEntryDateStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();
            #endregion Student

            #region Teacher Mapping
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDto>().ReverseMap();
            #endregion Teacher
        }
    }
}
