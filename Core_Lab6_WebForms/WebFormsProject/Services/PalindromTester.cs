using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsProject.Services
{
    public class PalindromTester
    {
        public string Text { get; set; }

        public PalindromTester(string text)
        {
            Text = text;
        }

        public bool IsItPalindrome()
        {
            var original = Text;
            var reversed = new string(original.Reverse().ToArray());
            return original == reversed;
        }
    }
}