using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class FileSaver
    {
        public void SaveFile(string _outFile, HTMLTable _saveData)
        {
            StreamWriter _fileSaver = new StreamWriter(@"E:/Lab02/"+_outFile);
            _fileSaver.WriteLine(@"<html>");
            _fileSaver.WriteLine(@"<table>");
            _fileSaver.WriteLine(_saveData.Header);
            _fileSaver.WriteLine(_saveData.Footer);
            foreach (var _line in _saveData.Content)
            {
                _fileSaver.WriteLine(_line);
            }
            _fileSaver.WriteLine(@"</table>");
            _fileSaver.WriteLine(@"</html>");
            _fileSaver.Close();
        }
    }
}
