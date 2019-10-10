using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryWebApi
{
    public interface IRipositoryBookIssue
    {
        void IssuedBook(StudentInfo student, BookInfo book, DateTime issueDate);

        bool BookAlreadyIssued(int studentId, int bookId);

        void ReturnBook(StudentInfo student, BookInfo book, DateTime returnDate);
    }
}
