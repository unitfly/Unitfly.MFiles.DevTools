using Unitfly.MFiles.DevTools.AliasUpdate.App.Configuration;
using Unitfly.MFiles.DevTools.Common.UpdateBehaviours;

namespace Unitfly.MFiles.DevTools.AliasUpdate.App
{
    public static class Helpers
    {
        public static IUpdateBehaviour GetUpdateBehaviour(this UpdateBehaviour behaviour)
        {
            switch (behaviour)
            {
                case UpdateBehaviour.Append:
                    return new AppendBehaviour();
                case UpdateBehaviour.Overwrite:
                    return new OverwriteBehaviour();
                case UpdateBehaviour.SetIfEmpty:
                default:
                    return new SetIfEmptyBehaviour();
            }
        }
    }
}
