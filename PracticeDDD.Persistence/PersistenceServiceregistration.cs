using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracticeDDD.Application.Contract.Persistence;
using PracticeDDD.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Persistence
{
    public static class PersistenceServiceregistration
    {
        public static IServiceCollection ConfigurePersistenceService(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<PracticeDDdDbContext>(option =>
            option.UseSqlServer(
                configuration.GetConnectionString("PracticeDDDConnectionString")));

            service.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
            service.AddScoped<IStudentRepository, StudentRepository>();
            service.AddScoped<ITeacherRepository, TeacherRepository>();

            return service;
        }
    }
}
