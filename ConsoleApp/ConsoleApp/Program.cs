using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageDetails details1 = new MessageDetails
            {
                Language = "english",
                DateTime = "evening",
                Status = "user"
            };
            string message = GetWeclome(details1);
            Console.WriteLine(message);

            MessageDetails details2 = new MessageDetails
            {
                Language = "french",
                DateTime = "morning",
                Status = "admin"
            };
            Console.WriteLine(GetWeclome(details2));

            MessageDetails details3 = new MessageDetails
            {
                Language = "spanish",
                DateTime = "morning",
                Status = "user"
            };
            Console.WriteLine(GetWeclome(details3));
        }

        static string GetWeclome(MessageDetails details) => (details) switch
        {
            ("english", "morning", _) => "Good, morning!",
            ("english", "evening", _) => "Good, evening!",
            ("german", "morning", _) => "Guten, Morgen!",
            ("german", "evening", _) => "Guten, Aben!",
            (_, _, "admin") => "Hello, admin!",
            (var lang, var dateTime, var status) => $"{lang} not found, {dateTime} unkown, {status} undefined",
            _ => "Здрасьть"
        };
    }

    class MessageDetails
    {
        public string Language { get; set; }
        public string DateTime { get; set; }
        public string Status { get; set; }

        public void Deconstruct(out string lang, out string dateTime, out string status)
        {
            lang = Language;
            dateTime = DateTime;
            status = Status;
        }
    }
}