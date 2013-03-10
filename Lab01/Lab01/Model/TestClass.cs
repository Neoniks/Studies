using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class TestClass: FileSaver
    {
        private TextParser _textParser = new TextParser();
        public void TableGenerator(string fileName, string outFile)
        {
            TableGenerator(_textParser.ParseData(fileName),outFile);
        }
        public void TableGenerator(List<float> numberList, string outFile, int height, int width)
        {
            try
            {
                List<string> _send = _textParser.ParseData(numberList: numberList, height:height,width:width);
                if (_send == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                TableGenerator(_send, outFile);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        public void TableGenerator(List<string> wordList, string outFile, int height, int width)     
        {
            try
            {
                List<string> _send = _textParser.ParseData(wordList: wordList, height: height, width: width);
                if (_send == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                TableGenerator(_send, outFile);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        public void TableGenerator(List<string> textList, string outFile)
        {
            HTMLTable _htmlTable = new HTMLTable(textList);
            SaveFile(outFile, _htmlTable);
        }
    }
}
