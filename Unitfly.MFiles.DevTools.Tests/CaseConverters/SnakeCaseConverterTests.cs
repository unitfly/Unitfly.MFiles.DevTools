using Unitfly.MFiles.DevTools.CaseConverters;
using Xunit;

namespace Unitfly.MFiles.DevTools.Tests.CaseConverters
{
    public class SnakeCaseConverterTests
    {
        private ICaseConverter casingConverter;

        public SnakeCaseConverterTests()
        {
            casingConverter = new SnakeCaseConverter();
        }

        [Fact]
        public void TestNull()
        {
            Assert.Null(casingConverter.ToString(null));
        }

        [Fact]
        public void TestAlphaNumeric()
        {
            Assert.Equal("the_quick_brown_fox", casingConverter.ToString("The Quick BROWN fox"));
        }

        [Fact]
        public void TestDash()
        {
            Assert.Equal("oxlade_chamberlain", casingConverter.ToString("Oxlade-Chamberlain"));
        }
    }
}
