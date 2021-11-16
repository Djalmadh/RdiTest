using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestClass()]
    public class PalindromeTests
    {
        [TestMethod()]
        public void IsPalindromeTest_EmptyInput()
        {
            Palindrome palindrome = new();
            Assert.AreEqual("Invalid Input", palindrome.IsPalindrome(""));
        }

        [TestMethod()]
        public void IsPalindromeTest_NullInput()
        {
            Palindrome palindrome = new();
            Assert.AreEqual("Invalid Input", palindrome.IsPalindrome(null));
        }

        [TestMethod()]
        public void IsPalindromeTest_FirstInput()
        {
            Palindrome palindrome = new();
            Assert.AreEqual("Yes", palindrome.IsPalindrome("carroaco"));
        }

        [TestMethod()]
        public void IsPalindromeTest_SecondInput()
        {
            Palindrome palindrome = new();
            Assert.AreEqual("No", palindrome.IsPalindrome("abcabcabc"));
        }
    }
}