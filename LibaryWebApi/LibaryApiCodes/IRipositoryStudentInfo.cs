using LibaryEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryApiCodes
{
    public interface IRipositoryStudentInfo
    {
        void InsertStudent(int id, string name);
        StudentInfo GetStudentById(int id);

        void GiveFine(StudentInfo student, double fineAmount);
    }
}
