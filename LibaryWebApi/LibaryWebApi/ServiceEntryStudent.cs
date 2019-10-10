using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryWebApi
{
    public class ServiceEntryStudent : IServiceEntryStudent
    {
        private IRipositoryStudentInfo _ripositoryStudentInfo;

        public ServiceEntryStudent(IRipositoryStudentInfo ripositoryStudentInfo)
        {
            _ripositoryStudentInfo = ripositoryStudentInfo;
        }

        public void InsertStudent(string[] values)
        {
            var student = _ripositoryStudentInfo.GetStudentById(Convert.ToInt32(values[0]));

            if(student == null)
            {
                _ripositoryStudentInfo.InsertStudent(Convert.ToInt32(values[0]), values[1]);
            }


            
        }

    }
}
