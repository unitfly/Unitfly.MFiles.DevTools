using Unitfly.MFiles.DevTools.Common.CaseConverters;
using Xunit;

namespace Unitfly.MFiles.DevTools.Common.Tests.CaseConverters
{
    public class PascalCaseConverterTests
    {
        private ICaseConverter casingConverter;

        public PascalCaseConverterTests()
        {
            casingConverter = new PascalCaseConverter();
        }

        [Fact]
        public void TestNull()
        {
            Assert.Null(casingConverter.ToString(null));
        }

        [Fact]
        public void TestAlphaNumeric()
        {
            Assert.Equal("TheQuickBrownFox", casingConverter.ToString("The Quick BROWN fox"));
        }

        [Fact]
        public void TestDash()
        {
            Assert.Equal("OxladeChamberlain", casingConverter.ToString("Oxlade-Chamberlain"));
        }
    }
}
