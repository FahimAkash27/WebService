using System;
using System.Collections.Generic;
using System.Text;

namespace LibaryUser
{
    class BookInformation : IBookInformation
    {
        private const string url = "https://localhost:44327/api/book/PostAddBook";

        private IPostToWebservice _postToWebservice;

        public BookInformation(IPostToWebservice postToWebservice)
        {
            _postToWebservice = postToWebservice;
        }

        public void InsertBook()
        {
            string[] values = new string[6];

            Console.Write("Please enter book Id: ");
            values[0] = Console.ReadLine();

            Console.Write("Please enter book title: ");
            values[1] = Console.ReadLine();

            Console.Write("Please enter book author: ");
            values[2] = Console.ReadLine();

            Console.Write("Please enter book edition: ");
            values[3] = Console.ReadLine();

            Console.Write("Please enter book barcode: ");
            values[4] = Console.ReadLine();

            Console.Write("Please enter book copy count: ");
            values[5] = Console.ReadLine();

            _postToWebservice.PostMethod(values, url);
        }
    }
}
