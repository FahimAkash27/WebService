using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryWebApi
{
    public interface IRipositoryStudentInfo
    {
        void InsertStudent(int id, string name);
        StudentInfo GetStudentById(int id);
    }
}
