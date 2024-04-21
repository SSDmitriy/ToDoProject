using Microsoft.EntityFrameworkCore;
using PetProject.Domain;



namespace PetProject.Persistence
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new NoteConfiguration());
        }
    }
}
