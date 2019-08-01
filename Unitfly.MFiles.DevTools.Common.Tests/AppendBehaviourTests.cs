using Unitfly.MFiles.DevTools.Common.UpdateBehaviours;
using Xunit;

namespace Unitfly.MFiles.DevTools.Common.Tests
{
    public class AppendBehaviourTests
    {
        private IUpdateBehaviour _behaviour;

        public AppendBehaviourTests()
        {
            _behaviour = new AppendBehaviour();
        }

        [Fact]
        public void TestEmpty()
        {
            Assert.Equal("", _behaviour.UpdateAlias("", ""));
        }

        [Fact]
        public void TestAppend()
        {
            Assert.Equal("first;second", _behaviour.UpdateAlias("first", "second"));
        }

        [Fact]
        public void TestDontAppendExisting()
        {
            Assert.Equal("first;second", _behaviour.UpdateAlias("first;second", "second"));
        }

        [Fact]
        public void TestAppendExistingDifferentCase()
        {
            Assert.Equal("first;FIRST", _behaviour.UpdateAlias("first", "FIRST"));
        }
    }
}
