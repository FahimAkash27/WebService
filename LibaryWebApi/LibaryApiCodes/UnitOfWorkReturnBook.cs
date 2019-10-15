using System;
using System.Collections.Generic;
using System.Text;

namespace LibaryApiCodes
{
    public class UnitOfWorkReturnBook : IUnitOfWorkReturnBook
    {
        private LibaryContext _context;

        public IRipositoryBookIssue ripositoryBookIssue { get; private set; }
        public IRipositoryStudentInfo ripositoryStudentInfo { get; private set; }
        public IRipositoryBookInfo ripositoryBookInfo { get; private set; }

        public UnitOfWorkReturnBook(string connectionString, string migrationAssemblyName)
        {
            _context = new LibaryContext(connectionString, migrationAssemblyName);

            ripositoryBookIssue = new RipositoryBookIssue(_context);

            ripositoryStudentInfo = new RepositoryStudentInfo(_context);

            ripositoryBookInfo = new RipositoryBookInfo(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
