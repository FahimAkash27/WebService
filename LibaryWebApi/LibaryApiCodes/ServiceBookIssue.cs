using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryApiCodes
{
    public class ServiceBookIssue : IServiceBookIssue
    {
        private UnitOfWorkBookIssue _unitOfWorkBookIssue;

        public ServiceBookIssue(UnitOfWorkBookIssue unitOfWorkBookIssue)
        {
            _unitOfWorkBookIssue = unitOfWorkBookIssue;
        }

        public void IssueBook(string[] values)
        {
            int studentId = Convert.ToInt32(values[0]);

            var student = _unitOfWorkBookIssue.ripositoryStudentInfo.GetStudentById(studentId);

            if (student != null)
            {
                string barcode = values[1];

                var book = _unitOfWorkBookIssue.ripositoryBookInfo.GetBookByBarcode(barcode);

                if (book != null && book.Count >= 1)
                {
                    var AlreadyBookIssued = _unitOfWorkBookIssue.ripositoryBookIssue.BookAlreadyIssued(studentId, book.BookInfoId);

                    if (AlreadyBookIssued == false)
                    {
                        _unitOfWorkBookIssue.ripositoryBookIssue.IssuedBook(student, book, DateTime.Now);

                        book.Count -= 1;

                        _unitOfWorkBookIssue.Save();
                    }
                }
            }
        }
    }
}
