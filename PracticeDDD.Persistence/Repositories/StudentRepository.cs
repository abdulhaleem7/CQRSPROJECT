using Microsoft.EntityFrameworkCore;
using PracticeDDD.Application.Contract.Persistence;
using PracticeDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Persistence.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly PracticeDDdDbContext _context;
        public StudentRepository(PracticeDDdDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task ChangeEntryDateStatus(Student student, bool? entyrstatus)
        {
            student.Active = entyrstatus;
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
