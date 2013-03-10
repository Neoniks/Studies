using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class TestData
    {
        public List<float> _testNumber = new List<float>();
        public List<string> _testString = new List<string>();
        public List<string> _testHeader = new List<string>();
        public List<string> _testFooter = new List<string>();
        public List<string> _testFootHead = new List<string>();

        public TestData()
        {
            
            for (int i = 0; i < 4; i++)
            {
                _testNumber.Add(i);
            }
            
            _testString.Add("Dlugi tekst");
            _testString.Add("Dlugi tekst");
            _testString.Add("Dlugi tekst");
            _testString.Add("Dlugi tekst");
            _testString.Add("Dlugi tekst");
            _testString.Add("Dlugi tekst");

            _testHeader.Add("@h Nagłowek");
            _testHeader.Add("Z naglowkiem");
            _testHeader.Add("Z naglowkiem");
            _testHeader.Add("Z naglowkiem");
            _testHeader.Add("Z naglowkiem");
            _testHeader.Add("Z naglowkiem");
            _testHeader.Add("Z naglowkiem");

            _testFooter.Add("@f Stopka");
            _testFooter.Add("Ze stopka");
            _testFooter.Add("Ze stopka");
            _testFooter.Add("Ze stopka");
            _testFooter.Add("Ze stopka");
            _testFooter.Add("Ze stopka");
            _testFooter.Add("Ze stopka");

            _testFootHead.Add("@h Nagłowek");
            _testFootHead.Add("@f Stopka");
            _testFootHead.Add("Ze stopka i naglowkiem");
            _testFootHead.Add("Ze stopka i naglowkiem");
            _testFootHead.Add("Ze stopka i naglowkiem");
            _testFootHead.Add("Ze stopka i naglowkiem");
            _testFootHead.Add("Ze stopka i naglowkiem");
            _testFootHead.Add("Ze stopka i naglowkiem");
        }
    }
}
