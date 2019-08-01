namespace Unitfly.MFiles.DevTools.Common.UpdateBehaviours
{
    public class SetIfEmptyBehaviour : IUpdateBehaviour
    {
        public string UpdateAlias(string previousValue, string newValue)
        {
            if (!string.IsNullOrWhiteSpace(previousValue))
            {
                return previousValue;
            }

            return newValue;
        }
    }
}
