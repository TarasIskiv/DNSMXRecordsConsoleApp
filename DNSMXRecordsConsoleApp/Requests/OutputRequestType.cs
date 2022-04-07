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
        private string _path = "temporaryFile.txt";
        public OutputRequestType(string fileName)
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
                    var fileStreamTemp = new FileStream(_path, FileMode.Open, FileAccess.Read);

                    using (var streamReader = new StreamReader(fileStreamTemp, Encoding.UTF8))
                    {

                        var fileStreamMain = new FileStream(_fileName, FileMode.Append, FileAccess.Write);
                        using (var streamWritter = new StreamWriter(fileStreamMain, Encoding.UTF8))
                        {
                            string currentLine;
                            while ((currentLine = streamReader.ReadLine()) != null)
                            {
                                streamWritter.WriteLine(currentLine);
                            }
                        }
                        fileStreamMain.Close();

                    }
                    fileStreamTemp.Close();
                    File.WriteAllText(_path, string.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
