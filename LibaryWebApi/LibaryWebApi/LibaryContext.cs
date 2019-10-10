using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryWebApi
{
    public class LibaryContext : DbContext
    {
        public LibaryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<IssuedBookInfo>()
                .HasKey(sb => new { sb.StudentId, sb.BookInfoId});

            builder.Entity<IssuedBookInfo>()
                .HasOne(sb => sb.StudentInfo)
                .WithMany(s => s.IssuedBookByStudent)
                .HasForeignKey(sb => sb.StudentId);


            base.OnModelCreating(builder);
        }

        public DbSet<StudentInfo> StudentInfos { get; set; }
        public DbSet<BookInfo> BookInfos { get; set; }
        public DbSet<IssuedBookInfo> IssuedBookInfos { get; set; }
    }
}
