using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSMXRecordsConsoleApp
{
    internal class InputRequestType : RequestType
    {
        private string _fileName;
        public InputRequestType(string fileName)
        {
            _fileName = fileName;
        }
        public void processingRequest()
        {
            if (File.Exists(_fileName))
            {
                var linesFromFile = new List<string>();
                var fileStream = new FileStream(@_fileName, FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string currentLine;
                    while ((currentLine = streamReader.ReadLine()) != null)
                    {
                        linesFromFile.Add(currentLine);
                    }
                }

                ///

            }
            
        }
    }
}
