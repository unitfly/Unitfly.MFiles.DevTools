using Unitfly.MFiles.DevTools.Common.CaseConverters;
using Xunit;

namespace Unitfly.MFiles.DevTools.Common.Tests.CaseConverters
{
    public class OriginalCaseConverterTests
    {
        private ICaseConverter casingConverter;

        public OriginalCaseConverterTests()
        {
            casingConverter = new OriginalCaseConverter();
        }

        [Fact]
        public void TestNull()
        {
            Assert.Null(casingConverter.ToString(null));
        }

        [Fact]
        public void TestAlphaNumeric()
        {
            Assert.Equal("The Quick BROWN fox", casingConverter.ToString("The Quick BROWN fox"));
        }

        [Fact]
        public void TestDash()
        {
            Assert.Equal("Oxlade-Chamberlain", casingConverter.ToString("Oxlade-Chamberlain"));
        }
    }
}
