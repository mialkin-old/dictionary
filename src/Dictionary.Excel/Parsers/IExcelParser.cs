using System;
using System.Collections.Generic;
using System.IO;

namespace Dictionary.Excel.Parsers
{
    public interface IExcelParser<T> : IDisposable
    {
        IExcelParser<T> Initialize(Stream stream);
        IEnumerable<T> Parse();
    }
}
