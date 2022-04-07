using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNSMXRecordsConsoleApp
{
    public static class RequestResult
    {
        private static readonly ISet<string> results = new HashSet<string>();

        public static void addResult(string response) => results.Add(response);

        public static IEnumerable<string> getAllResults() => results;

        public static void clearResults() => results.Clear();

    }
}
