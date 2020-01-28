using Unitfly.MFiles.DevTools.UpdateBehaviours;
using Xunit;

namespace Unitfly.MFiles.DevTools.Tests.UpdateBehaviours
{
    public class SetEmptyBehaviourTests
    {
        private IUpdateBehaviour _behaviour;

        public SetEmptyBehaviourTests()
        {
            _behaviour = new SetIfEmptyBehaviour();
        }

        [Fact]
        public void TestEmpty()
        {
            Assert.Equal("", _behaviour.UpdateAlias("", ""));
        }

        [Fact]
        public void TestSet()
        {
            Assert.Equal("first", _behaviour.UpdateAlias("", "first"));
        }

        [Fact]
        public void TestDontOverwrite()
        {
            Assert.Equal("first", _behaviour.UpdateAlias("first", "second"));
        }
    }
}
