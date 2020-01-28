namespace Unitfly.MFiles.DevTools.UpdateBehaviours
{
    public class OverwriteBehaviour : IUpdateBehaviour
    {
        public string UpdateAlias(string previousValue, string newValue)
        {
            return newValue;
        }
    }
}
