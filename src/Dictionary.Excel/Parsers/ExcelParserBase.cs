using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Packaging.Ionic.Zip;

namespace Dictionary.Excel.Parsers
{
    public abstract class ExcelParserBase<T> : IExcelParser<T>
    {
        protected ExcelWorksheet Worksheet;

        private ExcelPackage _package;

        protected int LastColumn;

        protected int LastRow;

        private bool _isInitialized;

        public IExcelParser<T> Initialize(Stream stream)
        {
            if(_isInitialized)
                throw new BadStateException("Excel parser cannot be initialized twice");

            _package = new ExcelPackage(stream);
            Worksheet = _package.Workbook.Worksheets[0];
            LastColumn = GetLastUsedColumn();
            LastRow = GetLastUsedRow();

            _isInitialized = true;

            return this;
        }

        public abstract IEnumerable<T> Parse();

        private int GetLastUsedRow()
        {
            int col = Worksheet.Dimension.End.Column;
            int row = Worksheet.Dimension.End.Row;
            
            while (row >= 1)
            {
                ExcelRange range = Worksheet.Cells[row, 1, row, col];
                if (range.Any(c => !string.IsNullOrWhiteSpace(c.Text)))
                {
                    break;
                }
                row--;
            }
            
            return row;
        }

        private int GetLastUsedColumn()
        {
            int column = Worksheet.Dimension.End.Column;
            int row = Worksheet.Dimension.End.Row;
            
            while (column >= 1)
            {
                ExcelRange range = Worksheet.Cells[1, column, row, column];
                if (range.Any(c => !string.IsNullOrWhiteSpace(c.Text)))
                {
                    break;
                }
                column--;
            }
            
            return column;
        }

        protected void ParseString(Action<string> action, int row, int col) => action(Convert.ToString(Worksheet.Cells[row, col].Value));

        protected void ParseInt(Action<int> action, int row, int col) => action(Convert.ToInt32(Worksheet.Cells[row, col].Value));

        protected void ParseDateTime(Action<DateTime> action, int row, int col) => action(Convert.ToDateTime(Worksheet.Cells[row, col].Value));

        public void Dispose()
        {
            Worksheet?.Dispose();
            _package?.Dispose();
        }
    }
}
