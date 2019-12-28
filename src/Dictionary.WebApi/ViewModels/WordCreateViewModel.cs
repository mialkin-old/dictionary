namespace Dictionary.WebApi.ViewModels
{
    public class WordCreateViewModel
    {
        public string Name { get; set; }

        public string Transcription { get; set; }

        public string Translation { get; set; }

        public int GenderId { get; set; }

        public int LanguageId { get; set; }
    }
}
