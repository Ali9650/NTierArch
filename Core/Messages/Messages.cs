using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Messages
{
    public static class Messages
    {
        public static void InvalidInputMeesages(string title)
        {
            Console.WriteLine($"{title} is invalid. Please try again");
        }

        public static void InputMessages(string title)
        {
            Console.WriteLine($"Please input {title}");
        }
        public static void SuccessMessages(string title, string operation)
        {
            Console.WriteLine($"{title} successfully {operation}");
        }
        public static void ErrorOccuredMessage()
        {
            Console.WriteLine("Error occured. Please try again");
        }
        public static void NotFountMessage(string title)
        {
            Console.WriteLine($"{title}not found");
        }
        public static void WantToChangeMessage(string title)
        {
            Console.WriteLine($"Do you want to change {title} ? (y or n)");
        }
        public static void AlreadyExistMessage(string title)
        {
            Console.WriteLine($"{title} already exists");
        }
        public static void WarningMessage(string title)
        {
            Console.WriteLine($"There is no any {title}, Add {title} first please ");
        }
        public static void DatePeriodMessage(string title)
        {
            Console.WriteLine($"EndDate {title} BeginDate cox olmalidir");
        }
    }
}
