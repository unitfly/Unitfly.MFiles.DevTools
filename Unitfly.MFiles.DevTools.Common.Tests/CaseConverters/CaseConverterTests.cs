using System;
using Unitfly.MFiles.DevTools.Common.CaseConverters;
using Xunit;

namespace Unitfly.MFiles.DevTools.Common.Tests.CaseConverters
{
    public class CasingConverterTests : CaseConverter
    {
        [Fact]
        public void RemoveWhitespacesTest()
        {
            Assert.Null(RemoveWhitespaces(null));
            Assert.Equal("", RemoveWhitespaces(""));
            Assert.Equal("", RemoveWhitespaces(" "));
            Assert.Equal("", RemoveWhitespaces("  "));
            Assert.Equal("abc", RemoveWhitespaces(" abc"));
            Assert.Equal("abc", RemoveWhitespaces("ab c"));
            Assert.Equal("abc", RemoveWhitespaces("abc "));
        }

        [Fact]
        public void RemoveSpecialCharsTest()
        {
            Assert.Null(RemoveSpecialChars(null));
            Assert.Equal("", RemoveSpecialChars(""));
            Assert.Equal("abc ", RemoveSpecialChars("abc "));
            Assert.Equal("ab c", RemoveSpecialChars("ab/c"));
            Assert.Equal("abc ", RemoveSpecialChars("abc*"));
            Assert.Equal("abc123", RemoveSpecialChars("abc123"));
        }

        [Fact]
        public void RemoveAccentsTest()
        {
            Assert.Null(RemoveAccents(null));
            Assert.Equal("", RemoveAccents(""));
            Assert.Equal(" ", RemoveAccents(" "));
            Assert.Equal("C,c,C,c,Z,z,S,s,D,d", RemoveAccents("Č,č,Ć,ć,Ž,ž,Š,š,Đ,đ"));
            Assert.Equal("Ae,ae,Oe,oe,Ue,ue,ss,ss", RemoveAccents("Ä,ä,Ö,ö,Ü,ü,ß,ß"));
            Assert.Equal("A,a,Ae,ae,Oe,oe", RemoveAccents("Å,å,Ä,ä,Ö,ö"));
            Assert.Equal("A,a,AE,ae,O,o", RemoveAccents("Å,å,Æ,æ,Ø,ø"));
        }

        protected override string Transform(string input)
        {
            throw new NotImplementedException();
        }
    }
}
