using LibaryEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryApiCodes
{
    public interface IRipositoryBookIssue
    {
        void IssuedBook(StudentInfo student, BookInfo book, DateTime issueDate);

        bool BookAlreadyIssued(int studentId, int bookId);

        void ReturnBook(IssuedBookInfo info, DateTime returnDate);

        IssuedBookInfo BookIssueInfo(int studentId, int bookId);
    }
}
