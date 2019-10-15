using LibaryEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryApiCodes
{
    public class RipositoryBookIssue : IRipositoryBookIssue
    {
        private LibaryContext _context;

        public RipositoryBookIssue(LibaryContext context)
        {
            _context = context;
        }

        public void IssuedBook(StudentInfo student, BookInfo book, DateTime issueDate)
        {

            student.IssuedBookByStudent = new List<IssuedBookInfo>()
            {
                new IssuedBookInfo
                {
                    StudentId = student.Id,
                    BookInfoId = book.BookInfoId,
                    IssueDate = issueDate
                }
            };

        }

        public bool BookAlreadyIssued(int studentId, int bookId)
        {
            var result = _context.IssuedBookInfos.Where(i => i.StudentId == studentId && i.BookInfoId == bookId && i.Returned == false).FirstOrDefault();

            if (result != null)
                return true;
            else
                return false;

        }

        public void ReturnBook(IssuedBookInfo info, DateTime returnDate)
        {

            info.ReturnDate = returnDate;
            info.Returned = true;
        }

        public IssuedBookInfo BookIssueInfo(int studentId, int bookId)
        {
            var info = _context.IssuedBookInfos.Where(i => i.StudentId == studentId && i.BookInfoId == bookId && i.Returned == false).FirstOrDefault();

            return info;
        }
    }
}