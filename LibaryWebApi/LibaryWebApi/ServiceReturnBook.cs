using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryWebApi
{
    public class ServiceReturnBook : IServiceReturnBook
    {
        private IRipositoryBookIssue _ripositoryBookIssue;
        private IRipositoryStudentInfo _ripositoryStudentInfo;
        private IRipositoryBookInfo _ripositoryBookInfo;

        public ServiceReturnBook(IRipositoryBookIssue ripositoryBookIssue, IRipositoryStudentInfo ripositoryStudentInfo, IRipositoryBookInfo ripositoryBookInfo)
        {
            _ripositoryBookIssue = ripositoryBookIssue;
            _ripositoryStudentInfo = ripositoryStudentInfo;
            _ripositoryBookInfo = ripositoryBookInfo;
        }

        public void ReturnBook(string[] values)
        {
            int studentId = Convert.ToInt32(values[0]);

            var student = _ripositoryStudentInfo.GetStudentById(studentId);

            if (student != null)
            {
                string barcode = values[1];

                var book = _ripositoryBookInfo.GetBookByBarcode(barcode);

                if (book != null)
                {
                    _ripositoryBookIssue.ReturnBook(student, book, DateTime.Now);

                    book.Count += 1;
                }
            }
        }
    }
}
