using Microsoft.EntityFrameworkCore;
using NotesApp.Models.Entities;

namespace NotesApp.Data
{
    public class NotesDbContext:DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options):base(options) { }

        public DbSet<Notes>Notes { get; set; }
    }
}
