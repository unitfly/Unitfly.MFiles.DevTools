using Unitfly.MFiles.DevTools.CaseConverters;
using Xunit;

namespace Unitfly.MFiles.DevTools.Tests.CaseConverters
{
    public class CamelCaseConverterTests
    {
        private ICaseConverter casingConverter;

        public CamelCaseConverterTests()
        {
            casingConverter = new CamelCaseConverter();
        }

        [Fact]
        public void TestNull()
        {
            Assert.Null(casingConverter.ToString(null));
        }

        [Fact]
        public void TestAlphaNumeric()
        {
            Assert.Equal("theQuickBrownFox", casingConverter.ToString("The Quick BROWN fox"));
        }

        [Fact]
        public void TestDash()
        {
            Assert.Equal("oxladeChamberlain", casingConverter.ToString("Oxlade-Chamberlain"));
        }
    }
}
