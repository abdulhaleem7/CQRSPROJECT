using PracticeDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Application.Contract.Persistence
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
        Task ChangeEntryDateStatus(Student student, bool? entyrstatus);
    }
}
