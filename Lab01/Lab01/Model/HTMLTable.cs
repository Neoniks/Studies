using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class HTMLTable :TextParser
    {
        public HTMLTable(): base()
        { }
        public HTMLTable(List<string> _data): base()
        {
            CreateHeader(_data[0]);
            CreateFooter(_data[1]);
            _data.RemoveRange(0, 2);
            CreateContent(_data);
        }

        private string _header;
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }

        private string _footer;
        public string Footer
        {
            get { return _footer; }
            set { _footer = value; }
        }

        private List<string> _content = new List<string>();
        public  List<string> Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private void CreateHeader(string header)
        {
            if (header != string.Empty)
            {
                Header = @"<thead><tr><th>" + header + @"</th></tr></thead>";
            }
        }     
        private void CreateFooter(string footer)
        {
            if (footer != string.Empty)
            {
                Footer = @"<tfoot><tr><td>" + footer + @"</td></tr></tfoot>";
            }
        }     
        private void CreateContent(List<string> content) 
        {
            List<string> _tmpContent = ParseContent(content);
            Content.Add(@"<tbody>");
            foreach (var _cont in _tmpContent)
            {
                Content.Add(_cont);
            }
            Content.Add(@"</tbody>");
        }
    }
}
