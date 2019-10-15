using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryApiCodes
{
    public class ServiceReturnBook : IServiceReturnBook
    {
        private UnitOfWorkReturnBook _unitOfWorkReturn;

        public ServiceReturnBook(UnitOfWorkReturnBook unitOfWorkReturn)
        {
            _unitOfWorkReturn = unitOfWorkReturn;
        }

        public void ReturnBook(string[] values)
        {

            int studentId = Convert.ToInt32(values[0]);
            string bookBarCode = values[1];

            var student = _unitOfWorkReturn.ripositoryStudentInfo.GetStudentById(studentId);

            var book = _unitOfWorkReturn.ripositoryBookInfo.GetBookByBarcode(bookBarCode);

            var info = _unitOfWorkReturn.ripositoryBookIssue.BookIssueInfo(studentId, book.BookInfoId);

            DateTime returnDate = DateTime.Now;


            int dayDifference = Convert.ToInt32((info.IssueDate - returnDate).TotalDays);

            int fineAmount = 0;


            if (dayDifference > 7)
            {
                 fineAmount = (dayDifference - 7) * 10;
            }

            _unitOfWorkReturn.ripositoryBookIssue.ReturnBook(info, returnDate);

            book.Count += 1;

            student.FineAmount += fineAmount;

            _unitOfWorkReturn.Save();




        }
    }
}
