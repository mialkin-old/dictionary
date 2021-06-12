using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.Database.Models
{
    [Index(nameof(Name), nameof(LanguageId), IsUnique = true)]
    public class WordDto
    {
        [Key]
        public int WordId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Translation { get; set; }

        [MaxLength(50)]
        public string Transcription { get; set; }

        public int LanguageId { get; set; }
        
        public int GenderId { get; set; }

        public DateTime Created { get; set; }
    }
}
