using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetProject.Domain;

namespace PetProject.Persistence
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder
                .HasKey(n => n.Id);

            builder
                .Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property (n => n.Description)
                .HasMaxLength(777);

            builder
                .Property(n => n.Status)
                .IsRequired();
        }
    }
}