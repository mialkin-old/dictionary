using System;
using System.Collections.Generic;

namespace Dictionary.Excel.Parsers.Word
{
    public class WordsImportParser : ExcelParserBase<WordImportModel>
    {
        public override IEnumerable<WordImportModel> Parse()
        {
            var models = new List<WordImportModel>();


            for (int index = 2; index <= LastRow; index++)
            {
                try
                {
                    WordImportModel model = ParseRow(index);
                    models.Add(model);
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return models;
        }

        private WordImportModel ParseRow(int row)
        {
            var model = new WordImportModel();

            ParseInt(x => model.WordId = x, row, 1);
            ParseString(x => model.Name = x, row, 2);
            ParseString(x => model.Translation = x, row, 3);
            ParseString(x => model.Transcription = x, row, 4);
            ParseInt(x => model.GenderId = x, row, 5);
            ParseInt(x => model.LanguageId = x, row, 6);
            ParseDateTime(x => model.Created = x, row, 7);

            return model;
        }
    }
}
