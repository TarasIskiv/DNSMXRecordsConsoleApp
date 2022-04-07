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
        public DomainRequestType(string[] input)
        {
            _input = input;
        }
        public void processingRequest()
        {
            if (_input.Length == 1)
            {
                SingleDomain(_input[0]);
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
                ConvertResponse(record.ToString());
            }
            return;
        }

        private void MultipleDomains()
        {
            foreach (var domain in _input)
            {
                SingleDomain(domain);
            }
            return;
        }

        private void ConvertResponse(string response)
        {
            try
            {
                var parameters = response.Split(' ').ToList();
                var domain = parameters[0];
                var preference = parameters[4];
                var exchange = parameters[5];
                var currentResponse = (domain + " MX preference = " + preference + ", mail exchanger = " + exchange).ToString();
                Console.WriteLine(currentResponse);
            }
            catch(Exception)
            {
                Console.WriteLine(response);
            }
        }
    }
}
