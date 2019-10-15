using System;
using System.Collections.Generic;
using System.Text;

namespace LibaryApiCodes
{
    public interface IUnitOfWorkReturnBook
    {
        IRipositoryBookIssue ripositoryBookIssue { get; }
        IRipositoryStudentInfo ripositoryStudentInfo { get; }
        IRipositoryBookInfo ripositoryBookInfo { get; }

        void Save();
    }
}
