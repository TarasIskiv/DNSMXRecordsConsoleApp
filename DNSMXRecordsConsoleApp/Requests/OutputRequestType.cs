using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSMXRecordsConsoleApp
{
    public class OutputRequestType : RequestType
    {
        private string _fileName;
        public OutputRequestType(string fileName)
        {
            _fileName = fileName;
        }
        public void processingRequest()
        {
            Console.WriteLine(_fileName + " Output");
        }
    }
}
