using Unitfly.MFiles.DevTools.Common.CaseConverters;
using Xunit;

namespace Unitfly.MFiles.DevTools.Common.Tests.CaseConverters
{
    public class UpperCaseConverterTests
    {

        private ICaseConverter casingConverter;

        public UpperCaseConverterTests()
        {
            casingConverter = new UpperCaseConverter();
        }

        [Fact]
        public void TestNull()
        {
            Assert.Null(casingConverter.ToString(null));
        }

        [Fact]
        public void TestAlphaNumeric()
        {
            Assert.Equal("THE QUICK BROWN FOX", casingConverter.ToString("The Quick BROWN fox"));
        }

        [Fact]
        public void TestDash()
        {
            Assert.Equal("OXLADE-CHAMBERLAIN", casingConverter.ToString("Oxlade-Chamberlain"));
        }
    }
}
