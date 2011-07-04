using System;
using Microsoft.Office.Interop.Word;
using MsWordApplication = Microsoft.Office.Interop.Word.Application;

namespace Homework.PatentApplicationSystem.Model
{
    public sealed class WordToPdfConverter : IDisposable
    {
        private readonly MsWordApplication _application = new MsWordApplication {Visible = true};

        internal WordToPdfConverter()
        {
        }

        public void Convert(string from, string to)
        {
            Document document = _application.Documents.Open(from, ReadOnly: true);
            document.SaveAs(to, WdSaveFormat.wdFormatPDF);
            document.Close(false);
        }

        public bool TryConvert(string from, string to)
        {
            try
            {
                Convert(from, to);
                return true;
            }
            catch
            {
                return false;
            }
        }

        ~WordToPdfConverter()
        {
            Dispose();
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            try
            {
                _application.Quit(false);
            }
            catch
            {
                ;
            }
        }

        #endregion
    }
}