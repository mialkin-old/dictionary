using System;
using System.ComponentModel.DataAnnotations;

namespace Dictionary.Database.Models
{
    public class WordDbModel
    {
        public int WordId { get; set; }        
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Translation { get; set; }
        [MaxLength(50)]
        public string Transcription { get; set; }
        public int LanguageId { get; set; }
        public DateTime DateAdded { get; set; }
        public byte Gender { get; set; }
    }
}
