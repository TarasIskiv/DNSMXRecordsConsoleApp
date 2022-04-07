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
        private IndentityInput _indentityInput;
        public InputRequestType(string fileName)
        {
            _fileName = fileName;
        }
        public void processingRequest()
        {
            try
            {
                if (File.Exists(_fileName))
                {
                    var linesFromFile = new List<string>();
                    var fileStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read);

                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        string currentLine;
                        while ((currentLine = streamReader.ReadLine()) != null)
                        {
                            linesFromFile.Add(currentLine);
                        }
                    }
                    
                    fileStream.Close();

                    foreach(var line in linesFromFile)
                    {
                        var currentInput = line.Split(' ').ToArray();
                        _indentityInput = new IndentityInput(currentInput);
                        var type = _indentityInput.Identity();
                        type.processingRequest();
                    }
                }
                else
                {
                    Console.WriteLine("File not found");
                    return;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
