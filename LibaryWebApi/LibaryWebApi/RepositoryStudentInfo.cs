using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryWebApi
{
    public class RepositoryStudentInfo : IRipositoryStudentInfo
    {
        private LibaryContext _context;

        public RepositoryStudentInfo(LibaryContext context)
        {
            _context = context;
        }

        public void InsertStudent(int id, string name)
        {
            _context.StudentInfos.Add(new StudentInfo
            {
                Id = id,
                Name = name
            });

            _context.SaveChanges();
        }

        public StudentInfo GetStudentById(int id)
        {
            var student = _context.StudentInfos.Where(s => s.Id == id).FirstOrDefault();
            return student;
        }

    }
}
