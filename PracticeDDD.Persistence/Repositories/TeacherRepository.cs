using PracticeDDD.Application.Contract.Persistence;
using PracticeDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Persistence.Repositories
{
    public class TeacherRepository: BaseRepository<Teacher>, ITeacherRepository
    {
        private readonly PracticeDDdDbContext _dbContext;
        public TeacherRepository(PracticeDDdDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
