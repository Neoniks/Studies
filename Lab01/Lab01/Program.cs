using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            TestData _data = new TestData();

            TestClass _newTest = new TestClass();
            _newTest.TableGenerator("table.txt", "tableHTMLFile.html");
            _newTest.TableGenerator(_data._testNumber, "tableHTMLN.html",2,2);
            _newTest.TableGenerator(_data._testString, "tableHTMLS.html", 2, 3);
            _newTest.TableGenerator(_data._testFooter, "tableHTMLF.html", 4, 4);
            _newTest.TableGenerator(_data._testHeader, "tableHTMLH.html", 5, 5);
            _newTest.TableGenerator(_data._testFootHead, "tableHTMLFH.html", 5, 5);
        }
    }
}
