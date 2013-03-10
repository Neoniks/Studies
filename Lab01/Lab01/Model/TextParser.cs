using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class TextParser
    {
        public List<string> ParseData(string filename = null, List<float> numberList = null, int height = 0, int width = 0, List<string> wordList = null)
        {
            if (numberList != null && height != 0)
            {
                List<string> _textList = new List<string>();
                string row = string.Empty;
                _textList.Add(string.Empty);
                _textList.Add(string.Empty);
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        try
                        {
                            row += numberList[0] + ";";
                            numberList.RemoveRange(0, 1);
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            row += "0;";
                        }
                    }
                    _textList.Add(row);
                    row = string.Empty;
                }
                return _textList;
            }
            else if (filename != null)
            {
                StreamReader file = new StreamReader(filename);
                string _line = string.Empty;
                string _header = string.Empty;
                string _footer = string.Empty;
                List<string> _content = new List<string>();
                string _check = string.Empty;

                while (!file.EndOfStream)
                {
                    _line = file.ReadLine();
                    if (_line[0] == '@' && _line[1] == 'h')
                    {
                        _line = _line.Remove(0, 2);
                        _header = _line;
                    }
                    else if (_line[0] == '@' && _line[1] == 'f')
                    {
                        _line = _line.Remove(0, 2);
                        _footer = _line;
                    }
                    else
                    {
                        _content.Add(_line);
                    }
                }
                List<string> _parsedData = new List<string>();
                _parsedData.Add(_header);
                _parsedData.Add(_footer);
                foreach (var value in _content)
                {
                    _parsedData.Add(value);
                }
                file.Close();
                return _parsedData;
            }
            else if (wordList != null && height != 0)
            {
                List<string> _parsedData = new List<string>();
                if (wordList[0][0] == '@' && wordList[0][1] == 'h')
                {
                    _parsedData.Add(wordList[0].Remove(0, 2));
                    wordList.RemoveRange(0, 1);
                }
                if (wordList[0][0] == '@' && wordList[0][1] == 'f')
                {
                    if (_parsedData.Count == 0)
                    {
                        _parsedData.Add(string.Empty);
                    }
                    _parsedData.Add(wordList[0].Remove(0, 2));
                    wordList.RemoveRange(0, 1);
                }

                while (_parsedData.Count < 2)
                {
                    _parsedData.Add(string.Empty);
                }
                string row = string.Empty;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        try
                        {
                            row += wordList[0] + ";";
                            wordList.RemoveRange(0, 1);
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            row += "<i>Empty</i>;";
                        }
                    }
                    _parsedData.Add(row);
                    row = string.Empty;
                }
                return _parsedData;
            }
            else
            {
                return null;
            }
        }
        public List<string> ParseContent(List<string> content)
        {
            List<string> _parsedContent = new List<string>();

            foreach (var row in content)
            {
                string[] _tmpRow = row.Split(';');
                string _row = @"<tr>";
                foreach (var _dataCell in _tmpRow)
                {
                    _row += @"<td>" + _dataCell + @"</td>";
                }
                _row += @"</tr>";
                _parsedContent.Add(_row);
            }
            return _parsedContent;
        }
    }
}
