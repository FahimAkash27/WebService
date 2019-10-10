using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryWebApi
{
    public class BookInfo
    {
        public int BookInfoId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Version { get; set; }

        public string Barcode { get; set; }

        public int Count { get; set; }


    }
}
