using MFilesAPI;
using Unitfly.MFiles.DevTools.Common.CaseConverters;

namespace Unitfly.MFiles.DevTools.Update.ItemNameParsers
{
    public class StateTransitionNameParser : WorkflowPartNameParser<StateTransition>
    {
        public StateTransitionNameParser(string template, CaseConverter nameConverter = null) : base(template, nameConverter)
        {
        }

        public override string Expand(StateTransition transition, IVault vault)
        {
            if (string.IsNullOrWhiteSpace(transition?.Name)) return string.Empty;

            var result = Template?.Replace("{StateTransition}", NameConverter.ToString(transition.Name));
            if (result?.Contains("{Workflow}") != true)
            {
                return result;
            }

            var workflow = GetWorkflow(vault, transition.FromState);
            return result.Replace("{Workflow}", NameConverter.ToString(workflow.Name));
        }
    }

}
