using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryWebApi
{
    public interface IRipositoryBookInfo
    {
        void AddBook(int bookId, string title, string author, string version, string barcode, int count);

        BookInfo GetBookByBarcode(string barcode);


    }
}
