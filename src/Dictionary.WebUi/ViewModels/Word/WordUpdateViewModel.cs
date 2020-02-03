namespace Dictionary.WebUi.ViewModels.Word
{
    public class WordUpdateViewModel
    {
        public string WordId { get; set; }

        public string Transcription { get; set; }

        public string Translation { get; set; }

        public int GenderId { get; set; }

        public int LanguageId { get; set; }
    }
}
