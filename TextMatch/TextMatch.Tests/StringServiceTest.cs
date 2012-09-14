using System;
using System.Linq;
using NUnit.Framework;
using Services;

namespace TextMatch.Tests
{
    [TestFixture]
    public class StringServiceTest
    {
        private const string ValidSubstring = "polly";
        private const string ValidBaseString = "Polly put the kettle on, Polly put the kettle on, Polly put the kettle on, We'll all have tea.";

        [Test]
        public void GetAllIndexesOf_VariousSubstrings_Success()
        {
            Assert.AreEqual(
                new[] { 1, 26, 51 },
                new StringService().GetAllIndexesOf(ValidBaseString, ValidSubstring));

            Assert.AreEqual(
                new[] { 7, 32, 57 },
                new StringService().GetAllIndexesOf(ValidBaseString, "put"));

            Assert.AreEqual(
                new[] { 3, 28, 53, 79, 83 },
                new StringService().GetAllIndexesOf(ValidBaseString, "ll"));
        }


        [Test]
        public void GetAllIndexesOf_LastCharacterIsSubstring_Success()
        {
            Assert.AreEqual(
                new[] { 94 },
                new StringService().GetAllIndexesOf(ValidBaseString, "."));
        }

        [Test]
        public void GetAllIndexesOf_PollyUpperCase_Success()
        {
            Assert.AreEqual(
                new[] { 1, 26, 51 },
                new StringService().GetAllIndexesOf(ValidBaseString, ValidSubstring.ToUpper()));

            Assert.AreEqual(
                new[] { 1, 26, 51 },
                new StringService().GetAllIndexesOf(ValidBaseString.ToUpper(), ValidSubstring));

            Assert.AreEqual(
                new[] { 1, 26, 51 },
                new StringService().GetAllIndexesOf(ValidBaseString.ToUpper(), ValidSubstring.ToUpper()));
        }

        [Test]
        public void GetAllIndexesOf_Empty_Success()
        {
            Assert.AreEqual(
                Enumerable.Empty<int>(),
                new StringService().GetAllIndexesOf(string.Empty, string.Empty));
        }

        [Test]
        public void GetAllIndexesOf_IsNotSubstring_Success()
        {
            Assert.AreEqual(
                Enumerable.Empty<int>(),
                new StringService().GetAllIndexesOf(ValidBaseString, "Foo"));

            Assert.AreEqual(
                Enumerable.Empty<int>(),
                new StringService().GetAllIndexesOf(ValidBaseString, "bar"));
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void ValidateInput_IncorrectBaseStringParameter_Exception()
        {
            new StringService().GetAllIndexesOf(null, ValidSubstring);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void ValidateInput_IncorrectSubstringParameter_Exception()
        {
            new StringService().GetAllIndexesOf(ValidBaseString, null);
        }
    }
}
