using DALBookProject.Database.Tables;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBookProject.Database
{
    public partial class BookDbContext : DbContext
    {
        public class optionBuild
        {
            public optionBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<BookDbContext>();
                opsBuilder.UseSqlServer(settings.DbConnString);
                dbOptions = opsBuilder.Options;
            }

            public DbContextOptionsBuilder<BookDbContext> opsBuilder { get; set; }

            public DbContextOptions<BookDbContext> dbOptions { get; set; }

            private AppConfiguration settings { get; set; }
        }

        public static optionBuild ops = new optionBuild();

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            //Database.SetCommandTimeout(60);
        }

        public virtual DbSet<BOOK> Books { get; set; }

        public virtual DbSet<CATEGORY> Categories { get; set; }

        public virtual DbSet<USER> Users { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BOOK>(entity =>
            {
                entity.ToTable("tbl_BOOK");
                entity.HasKey(e => e.bookid);
                entity.Property(e => e.bookid).HasColumnName("bookid").IsRequired().HasColumnType("int");
                entity.Property(e => e.bookname).IsRequired().HasMaxLength(50);
                entity.Property(e => e.categoryid).HasColumnName("categoryid").IsRequired().HasColumnType("int");
                entity.Property(e => e.author).HasMaxLength(50);
                entity.Property(e => e.publisher).HasMaxLength(50);
                entity.Property(e => e.price).IsRequired().HasColumnType("decimal");
                //entity.HasOne(e => e.CATEGORY).WithOne(d => d.BOOK).HasForeignKey("categoryid");
            });

            modelBuilder.Entity<CATEGORY>(entity =>
            {
                entity.ToTable("tbl_CATEGORY");
                entity.HasKey(e => e.categoryid);
                entity.Property(e => e.categoryid).HasColumnName("categoryid").IsRequired().HasColumnType("int");
                entity.Property(e => e.categoryname).HasColumnName("categoryname").IsRequired().HasMaxLength(50);
            
            });


            modelBuilder.Entity<USER>(entity =>
            {
                entity.ToTable("tbl_USER");
                entity.HasKey(e => e.userid);
                entity.Property(e => e.userid).HasColumnName("userid").IsRequired().HasColumnType("int");
                entity.Property(e => e.first_name).HasColumnName("firstname").IsRequired().HasMaxLength(50);
                entity.Property(e => e.last_name).HasColumnName("lastname").HasMaxLength(50);
                entity.Property(e => e.email).HasColumnName("email").IsRequired().HasMaxLength(50);
                entity.Property(e => e.password).HasColumnName("password").IsRequired().HasMaxLength(50);
                entity.Property(e => e.mobile).HasMaxLength(50);
                
                
            });
            OnModelCreatingPartial(modelBuilder);
            
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
