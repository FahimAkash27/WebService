using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryApiCodes
{
    public class ServiceBookAdd : IServiceBookAdd
    {
        private IRipositoryBookInfo _ripositoryBookInfo;

        public ServiceBookAdd(IRipositoryBookInfo ripositoryBookInfo)
        {
            _ripositoryBookInfo = ripositoryBookInfo;
        }

        public void AddBook(string[] values)
        {
            int bookId = Convert.ToInt32(values[0]);
            string title = values[1];
            string author = values[2];
            string version = values[3];
            string barcode = values[4];
            int count = Convert.ToInt32(values[5]);

            var book = _ripositoryBookInfo.GetBookByBarcode(barcode);

            if(book == null)
            {
                _ripositoryBookInfo.AddBook(bookId, title, author, version, barcode, count);
            }

        }
    }
}
