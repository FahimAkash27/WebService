using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryEntites
{
    public class IssuedBookInfo
    {
        public int StudentId { get; set; }

        public StudentInfo StudentInfo { get; set; }

        public int BookInfoId { get; set; }

        public BookInfo BookInfo { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public bool Returned { get; set; }

        
    }
}
