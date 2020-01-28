using System.Linq;

namespace Unitfly.MFiles.DevTools.UpdateBehaviours
{
    public class AppendBehaviour : IUpdateBehaviour
    {
        public string UpdateAlias(string previousValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(previousValue))
            {
                return newValue;
            }

            var existingAliases = previousValue.Split(';');
            if (existingAliases != null && existingAliases.Contains(newValue))
            {
                return previousValue;
            }

            return $"{previousValue};{newValue}";
        }
    }
}
