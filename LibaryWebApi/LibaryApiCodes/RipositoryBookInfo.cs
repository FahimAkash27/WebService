using LibaryEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryApiCodes
{
    public class RipositoryBookInfo : IRipositoryBookInfo
    {
        private LibaryContext _context;

        public RipositoryBookInfo(LibaryContext context)
        {
            _context = context;
        }

        public void AddBook(int bookId, string title, string author, string version, string barcode, int count)
        {
            _context.BookInfos.Add(new BookInfo
            {
                BookInfoId = bookId,
                Title = title,
                Author = author,
                Version = version,
                Barcode = barcode,
                Count = count
            });

            _context.SaveChanges();
        }

        public BookInfo GetBookByBarcode(string barcode)
        {
            var book = _context.BookInfos.Where(b => b.Barcode == barcode).FirstOrDefault();

            return book;
        }
    }
}
