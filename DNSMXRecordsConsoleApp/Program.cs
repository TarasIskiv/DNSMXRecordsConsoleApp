using DNSMXRecordsConsoleApp;
using System;

var input = new IndentityInput(args);
var type = input.Identity();
type.processingRequest();
