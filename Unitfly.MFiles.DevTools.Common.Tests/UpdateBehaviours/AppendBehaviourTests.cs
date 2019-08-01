using Unitfly.MFiles.DevTools.Common.UpdateBehaviours;
using Xunit;

namespace Unitfly.MFiles.DevTools.Common.Tests.UpdateBehaviours
{
    public class AppendBehaviourTests
    {
        private IUpdateBehaviour _behaviour;

        public AppendBehaviourTests()
        {
            _behaviour = new AppendBehaviour();
        }

        [Fact]
        public void TestNull()
        {
            Assert.Equal("", _behaviour.UpdateAlias(null, ""));
        }

        [Fact]
        public void TestEmpty()
        {
            Assert.Equal("", _behaviour.UpdateAlias("", ""));
        }

        [Fact]
        public void TestAddFirst()
        {
            Assert.Equal("first", _behaviour.UpdateAlias("", "first"));
        }

        [Fact]
        public void TestAppend()
        {
            Assert.Equal("first;second", _behaviour.UpdateAlias("first", "second"));
        }

        [Fact]
        public void TestDontAppendExisting()
        {
            Assert.Equal("second;first", _behaviour.UpdateAlias("second;first", "second"));
        }

        [Fact]
        public void TestAppendExistingDifferentCase()
        {
            Assert.Equal("first;FIRST", _behaviour.UpdateAlias("first", "FIRST"));
        }
    }
}
