namespace Dictionary.Services.Models.Word
{
    public class WordExistsServiceModel
    {
        public int LanguageId { get; set; }
        
        public string Name { get; set; }
        
        public WordExistsServiceModel(string name, in int languageId)
        {
            Name = name;
            LanguageId = languageId;
        }
    }
}