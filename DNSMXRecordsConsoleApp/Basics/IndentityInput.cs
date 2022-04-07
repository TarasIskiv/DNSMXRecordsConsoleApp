using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DNSMXRecordsConsoleApp
{
    public class IndentityInput
    {
        private string[] _input;
        public IndentityInput(string[] input)
        {
            _input = input;
        }

        public RequestType Identity()
        {
            if(_input.Length == 0)
            {
                return null;
            }

            var firstParameter = _input[0];
            switch (firstParameter)
            {
                case "-input":
                    Console.WriteLine("in");
                    return new InputRequestType(_input[1]);
                    break;
                case "-output":
                    Console.WriteLine("out");
                    return new OutputRequestType(_input[1]);
                    break;
                case "-dns":
                    Console.WriteLine("dns");
                    break;
                default:
                    if (Domain.possibleDomains.Contains(firstParameter))
                    {
                        Console.WriteLine("Operation : " + firstParameter);
                        return new DomainRequestType(_input);
                    }
                    else
                    {
                        Console.WriteLine("Can not indentity operation");
                    }
                    break;
            }

            return null;
        }

    }
}
