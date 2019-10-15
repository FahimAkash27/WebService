using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryEntites
{
    public class StudentInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double FineAmount { get; set; }

        public IList<IssuedBookInfo> IssuedBookByStudent { get; set; }
    }
}
