using DNSMXRecordsConsoleApp;
using System;
Console.WriteLine("Hello, World!");

var input = new IndentityInput(args);
var type = input.Identity();
type.processingRequest();
Console.WriteLine("\n");



//Console.WriteLine(args[0]);
