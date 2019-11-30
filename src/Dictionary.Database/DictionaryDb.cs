using Dictionary.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.Database
{
    internal class DictionaryDb : DbContext
    {
        public DbSet<Word> Words { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=dictionary.db");
        }
    }
}
