using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DigitalNotesManager
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-IJ69SKI\SQLEXPRESS01;Database=DNMDb;Trusted_Connection=True;trust server certificate=true;");
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserID);
                entity.Property(u => u.Username)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(u => u.Password)
                      .IsRequired()
                      .HasMaxLength(100);
            });


            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(n => n.NoteID);
                entity.Property(n => n.Title)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(n => n.Content)
                      .IsRequired();
                entity.Property(n => n.Category)
                      .HasMaxLength(50);
                entity.Property(n => n.CreationDate)
                      .IsRequired();
                entity.Property(n => n.ReminderDate);


                entity.HasOne(n => n.User)
                      .WithMany(u => u.Notes)
                      .HasForeignKey(n => n.UserID)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
 
