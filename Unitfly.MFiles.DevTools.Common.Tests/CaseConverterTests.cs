using System;
using Unitfly.MFiles.DevTools.Common.CaseConverters;
using Xunit;

namespace Unitfly.MFiles.DevTools.Common.Tests
{
    public class UnitTest1
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

            [Fact]
            public void OriginalCaseConverterTests()
            {
                var casingConverter = new OriginalCaseConverter();
                Assert.Null(casingConverter.ToString(null));
                Assert.Equal("The Quick BROWN fox", casingConverter.ToString("The Quick BROWN fox"));
                Assert.Equal("Oxlade-Chamberlain", casingConverter.ToString("Oxlade-Chamberlain"));
            }


            [Fact]
            public void UpperCaseConverterTests()
            {
                var casingConverter = new UpperCaseConverter();
                Assert.Null(casingConverter.ToString(null));
                Assert.Equal("THE QUICK BROWN FOX", casingConverter.ToString("The Quick BROWN fox"));
                Assert.Equal("OXLADE-CHAMBERLAIN", casingConverter.ToString("Oxlade-Chamberlain"));
            }

            [Fact]
            public void LowerCaseConverterTests()
            {
                var casingConverter = new LowerCaseConverter();
                Assert.Null(casingConverter.ToString(null));
                Assert.Equal("the quick brown fox", casingConverter.ToString("The Quick BROWN fox"));
                Assert.Equal("oxlade-chamberlain", casingConverter.ToString("Oxlade-Chamberlain"));
            }

            [Fact]
            public void HypenCaseConverterTests()
            {
                var casingConverter = new HypenCaseConverter();
                Assert.Null(casingConverter.ToString(null));
                Assert.Equal("the-quick-brown-fox", casingConverter.ToString("The Quick BROWN fox"));
                Assert.Equal("oxlade-chamberlain", casingConverter.ToString("Oxlade-Chamberlain"));
            }

            [Fact]
            public void SnakeCaseConverterTests()
            {
                var casingConverter = new SnakeCaseConverter();
                Assert.Null(casingConverter.ToString(null));
                Assert.Equal("the_quick_brown_fox", casingConverter.ToString("The Quick BROWN fox"));
                Assert.Equal("oxlade_chamberlain", casingConverter.ToString("Oxlade-Chamberlain"));
            }

            [Fact]
            public void PascalCaseConverterTests()
            {
                var casingConverter = new PascalCaseConverter();
                Assert.Null(casingConverter.ToString(null));
                Assert.Equal("TheQuickBrownFox", casingConverter.ToString("The Quick BROWN fox"));
                Assert.Equal("OxladeChamberlain", casingConverter.ToString("Oxlade-Chamberlain"));
            }

            [Fact]
            public void CamelCaseConverterTests()
            {
                var casingConverter = new CamelCaseConverter();
                Assert.Null(casingConverter.ToString(null));
                Assert.Equal("theQuickBrownFox", casingConverter.ToString("The Quick BROWN fox"));
                Assert.Equal("oxladeChamberlain", casingConverter.ToString("Oxlade-Chamberlain"));
            }

            protected override string Transform(string input)
            {
                throw new NotImplementedException();
            }
        }
    }
}
