namespace Dictionary.Services.Models.Word
{
    public class WordExistsSm
    {
        public int LanguageId { get; set; }
        
        public string Name { get; set; }
        
        public WordExistsSm(string name, in int languageId)
        {
            Name = name;
            LanguageId = languageId;
        }
    }
}