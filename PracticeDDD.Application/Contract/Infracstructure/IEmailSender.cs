using PracticeDDD.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Contract.Infracstructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
