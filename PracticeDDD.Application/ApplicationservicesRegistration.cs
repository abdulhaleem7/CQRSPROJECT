﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application
{
    public static class ApplicationservicesRegistration
    {
        public static IServiceCollection ConfigureApplicationService(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly()); 
            service.AddMediatR(Assembly.GetExecutingAssembly());
            return service;
        }
             
    }
}
