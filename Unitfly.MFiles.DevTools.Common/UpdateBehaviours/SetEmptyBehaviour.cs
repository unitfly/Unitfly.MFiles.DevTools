namespace Unitfly.MFiles.DevTools.Common.UpdateBehaviours
{
    public class SetEmptyBehaviour : IUpdateBehaviour
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
