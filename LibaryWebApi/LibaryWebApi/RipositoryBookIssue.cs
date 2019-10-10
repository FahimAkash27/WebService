using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryWebApi
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

            student.IssuedBookByStudent = new List<IssuedBookInfo>
            {
                new IssuedBookInfo
                {
                    StudentId = student.Id,
                    BookInfoId = book.BookInfoId,
                    IssueDate = issueDate
                }
            };

            _context.SaveChanges();
        }

        public bool BookAlreadyIssued(int studentId, int bookId)
        {
            var result = _context.IssuedBookInfos.Where(i => i.StudentId == studentId && i.BookInfoId == bookId && i.Returned == false).FirstOrDefault();

            if (result != null)
                return true;
            else
                return false;

        }

        public void ReturnBook(StudentInfo student, BookInfo book, DateTime returnDate)
        {
            var returnBook = _context.IssuedBookInfos.Where(i => i.StudentId == student.Id && i.BookInfoId == book.BookInfoId && i.Returned == false).FirstOrDefault();

            returnBook.ReturnDate = returnDate;
            returnBook.Returned = true;

            _context.SaveChanges();
        }
    }
}