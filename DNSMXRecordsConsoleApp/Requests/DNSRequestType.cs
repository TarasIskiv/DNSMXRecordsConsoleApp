using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSMXRecordsConsoleApp.Requests
{
    public class DNSRequestType : RequestType
    {
        private string[] _input;
        public DNSRequestType(string[] input)
        {
            _input = input;
        }

        public void processingRequest()
        {
            var domain = new DomainRequestType(_input);
            domain.address = _input[1];
            domain.processingRequest();
        }
    }
}
