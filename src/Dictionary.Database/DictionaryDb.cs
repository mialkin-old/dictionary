using Dictionary.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.Database
{
    public class DictionaryDb : DbContext
    {
        public DbSet<Word> Words { get; set; }
        public DictionaryDb(DbContextOptions<DictionaryDb> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
