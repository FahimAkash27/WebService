using System;
using System.Collections.Generic;
using System.Text;

namespace LibaryUser
{
    class IssueBook : IIssueBook
    {
        private const string puturl = "https://localhost:44327/api/BookIssue/PutReturnBook";
        private const string posturl = "https://localhost:44327/api/BookIssue/PostIssueBook";

        private IPostToWebservice _postToWebservice;
        private IPutToWebservice _putToWebservice;

        public IssueBook(IPostToWebservice postToWebservice, IPutToWebservice putToWebservice)
        {
            _postToWebservice = postToWebservice;
            _putToWebservice = putToWebservice;
        }

        public void BookIssue()
        {
            string[] values = new string[2];

            Console.Write("Please enter student ID: ");
            values[0] = Console.ReadLine();

            Console.Write("Please enter book barcode: ");
            values[1] = Console.ReadLine();

            _postToWebservice.PostMethod(values, posturl);
        }

        public void ReturnBook()
        {
            string[] values = new string[2];

            Console.Write("Please enter student ID: ");
            values[0] = Console.ReadLine();

            Console.Write("Please enter book barcode: ");
            values[1] = Console.ReadLine();

            _putToWebservice.PutMethod(values, puturl);
        }
    }
}
