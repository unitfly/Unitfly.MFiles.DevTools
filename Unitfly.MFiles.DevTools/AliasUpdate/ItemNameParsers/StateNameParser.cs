using MFilesAPI;
using Unitfly.MFiles.DevTools.CaseConverters;

namespace Unitfly.MFiles.DevTools.AliasUpdate.ItemNameParsers
{
    public class StateNameParser : WorkflowPartNameParser<StateAdmin>
    {
        public StateNameParser(string template, CaseConverter nameConverter = null) : base(template, nameConverter)
        {
        }

        public override string Expand(StateAdmin state, IVault vault)
        {
            var result = Template?.Replace("{State}", NameConverter.ToString(state.Name));
            if (result?.Contains("{Workflow}") != true)
            {
                return result;
            }

            var workflow = GetWorkflow(vault, state.ID);
            return result.Replace("{Workflow}", NameConverter.ToString(workflow?.Name));
        }
    }
}
