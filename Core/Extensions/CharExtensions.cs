using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class CharExtensions
    {
        public static bool IsValidChoice(this char choice)
        {
            if (choice.ToString().ToLower() == "y" || choice.ToString().ToLower() == "n")
                return true;


            return false;
        }
    }
}
