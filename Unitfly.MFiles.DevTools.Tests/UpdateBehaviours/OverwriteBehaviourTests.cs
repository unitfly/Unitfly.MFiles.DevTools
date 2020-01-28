using Unitfly.MFiles.DevTools.UpdateBehaviours;
using Xunit;

namespace Unitfly.MFiles.DevTools.Tests.UpdateBehaviours
{
    public class OverwriteBehaviourTests
    {
        private IUpdateBehaviour _behaviour;

        public OverwriteBehaviourTests()
        {
            _behaviour = new OverwriteBehaviour();
        }

        [Fact]
        public void TestEmpty()
        {
            Assert.Equal("", _behaviour.UpdateAlias("", ""));
        }

        [Fact]
        public void TestOverwrite()
        {
            Assert.Equal("second", _behaviour.UpdateAlias("first", "second"));
        }
    }
}
