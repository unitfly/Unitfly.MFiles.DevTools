namespace Unitfly.MFiles.DevTools.Common.UpdateBehaviours
{
    public class AppendBehaviour : IUpdateBehaviour
    {
        public string UpdateAlias(string previousValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(previousValue))
            {
                return newValue;
            }

            return $"{previousValue};{newValue}";
        }
    }
}
