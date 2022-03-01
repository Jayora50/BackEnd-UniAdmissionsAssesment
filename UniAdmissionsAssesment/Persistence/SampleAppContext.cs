using Microsoft.EntityFrameworkCore;
using System;
using UniAdmissionsAssesment.Entities;

namespace UniAdmissionsAssesment
{
    public class SampleAppContext : DbContext
    {
        public SampleAppContext(DbContextOptions<SampleAppContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>().HasKey(p => p.Id);
            builder.Entity<Book>().Property(p => p.Title).IsRequired().HasMaxLength(255);
            builder.Entity<Book>().Property(p => p.Author).IsRequired().HasMaxLength(255);
            builder.Entity<Book>().Property(p => p.CreatedDate).IsRequired().HasDefaultValue(DateTimeOffset.Now);
            builder.Entity<Book>().Property(p => p.ModifiedDate).IsRequired().HasDefaultValue(DateTimeOffset.Now);
        }
    }
}