using Unitfly.MFiles.DevTools.CaseConverters;
using Xunit;

namespace Unitfly.MFiles.DevTools.Tests.CaseConverters
{
    public class HypenCaseConverterTests
    {
        private ICaseConverter casingConverter;

        public HypenCaseConverterTests()
        {
            casingConverter = new HypenCaseConverter();
        }

        [Fact]
        public void TestNull()
        {
            Assert.Null(casingConverter.ToString(null));
        }

        [Fact]
        public void TestAlphaNumeric()
        {
            Assert.Equal("the-quick-brown-fox", casingConverter.ToString("The Quick BROWN fox"));
        }

        [Fact]
        public void TestDash()
        {
            Assert.Equal("oxlade-chamberlain", casingConverter.ToString("Oxlade-Chamberlain"));
        }
    }
}
