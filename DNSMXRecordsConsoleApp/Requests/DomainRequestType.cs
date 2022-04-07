using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ARSoft.Tools.Net.Dns;
using DnsClient;

namespace DNSMXRecordsConsoleApp
{
    public class DomainRequestType : RequestType
    {
        //gmail.com MX preference = XXX, mail exchanger = alt3.gmail-smtp-in.l.google.com 8.8.8.8

        private string[] _input;
        private string _path = "temporaryFile.txt";
        public string address = string.Empty;
        public DomainRequestType(string[] input)
        {
            _input = input;
        }
        public void processingRequest()
        {
            if (_input.Length == 1 || _input[0].Equals("-dns"))
            {
                if(_input[0].Equals("-dns"))
                {
                    SingleDomain(_input[_input.Length - 1]);
                }
                else
                {
                    SingleDomain(_input[0]);
                }
            }
            else
            {
                MultipleDomains();
            }
        }

        private void SingleDomain(string domain)
        {
            var lookup = new LookupClient();
            var result = lookup.Query(domain, QueryType.MX);
            foreach (var record in result.Answers)
            {
                var convertedResponse = ConvertResponse(record.ToString());
                writeToTemporaryFile(convertedResponse);
                Console.WriteLine(convertedResponse);
            }
        }

        private void MultipleDomains()
        {
            foreach (var domain in _input)
            {
                SingleDomain(domain);
            }
        }

        private string ConvertResponse(string response)
        {
            try
            {
                var parameters = response.Split(' ').ToList();
                var domain = parameters[0];
                var preference = parameters[4];
                var exchange = parameters[5];
                if(string.IsNullOrEmpty(address))
                {
                    address = (Dns.GetHostAddresses(exchange))[0].ToString();
                }
                var currentResponse = ($"{domain} MX preference = {preference}, mail exchanger = {exchange} {address}").ToString();
                RequestResult.addResult(currentResponse);
                return currentResponse;
            }
            catch(Exception)
            {
                return response;
            }
        }

        private void writeToTemporaryFile(string content)
        {
            try
            {
                if(!File.Exists(_path))
                {
                    File.Create(_path);
                }
                var fileStream = new FileStream(_path, FileMode.Append, FileAccess.Write);
                using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.WriteLine(content);
                }
               
                fileStream.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
