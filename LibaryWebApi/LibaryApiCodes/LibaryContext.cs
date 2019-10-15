using LibaryEntites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibaryApiCodes
{
    public class LibaryContext : DbContext
    {

        private string _connectionString;
        private string _migrationAssemblyName;

        public LibaryContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(optionsBuilder);
        }

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
