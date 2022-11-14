using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracticeDDD.Application.Contract.Infracstructure;
using PracticeDDD.Application.Models;
using PracticeDDD.Infracstructure.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Infracstructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureService(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
            service.AddTransient<IEmailSender, EmailSender>();
            return service;

        }
    }
}
