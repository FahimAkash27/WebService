using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryApiCodes
{
    public class ServiceFine : IServiceFine
    {
        private IRipositoryBookIssue _ripositoryBookIssue;
        private IRipositoryStudentInfo _ripositoryStudentInfo;
        private IRipositoryBookInfo _ripositoryBookInfo;

        public ServiceFine(IRipositoryBookIssue ripositoryBookIssue, IRipositoryStudentInfo ripositoryStudentInfo, IRipositoryBookInfo ripositoryBookInfo)
        {
            _ripositoryBookIssue = ripositoryBookIssue;
            _ripositoryStudentInfo = ripositoryStudentInfo;
            _ripositoryBookInfo = ripositoryBookInfo;
        }

        public double ShowFine(int id)
        {

            var student = _ripositoryStudentInfo.GetStudentById(id);

            if(student != null)
            {
                return student.FineAmount;
            }
            else
            {
                return 0;
            }
        }

        public void GiveFine(string[] values)
        {
            int id = Convert.ToInt32(values[0]);
            double fineAmount = Convert.ToDouble(values[1]);

            var student = _ripositoryStudentInfo.GetStudentById(id);

            if(student!= null)
            {
                _ripositoryStudentInfo.GiveFine(student, fineAmount);
            }
        }
    }
}
