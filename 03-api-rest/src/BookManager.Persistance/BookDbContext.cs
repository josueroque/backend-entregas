using BookManager.Application;
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Persistance
{
    public class BookDbContext:DbContext, IBookDbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
        {
        }
        
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookEntity> Books { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<AuthorEntity>()
                .HasKey(a => a.Id);

            modelBuilder
                .Entity<BookEntity>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

        }

    }
}