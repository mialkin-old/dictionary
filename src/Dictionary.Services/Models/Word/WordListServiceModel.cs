namespace Dictionary.Services.Models.Word
{
    public class WordListServiceModel
    {
        public int WordId { get; set; }

        public string Name { get; set; }

        public string Transcription { get; set; }

        public string Translation { get; set; }

        public int GenderId { get; set; }

        public int LanguageId { get; set; }

        /// <summary>
        /// Date when word was added to dictionary in dd.mm.yyyy format.
        /// </summary>
        public string Created { get; set; }
    }
}