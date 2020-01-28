using MFilesAPI;
using System.Linq;
using Unitfly.MFiles.DevTools.CaseConverters;

namespace Unitfly.MFiles.DevTools.AliasUpdate.ItemNameParsers
{
    public abstract class WorkflowPartNameParser<T> : ItemNameParser<T>
    {
        protected WorkflowPartNameParser(string template, CaseConverter nameConverter = null) : base(template, nameConverter)
        {
        }

        protected Workflow GetWorkflow(IVault vault, int state)
        {
            var workflows = vault.WorkflowOperations.GetWorkflowsForClient()?.Cast<Workflow>();
            foreach (var workflow in workflows)
            {
                var states = vault.WorkflowOperations.GetWorkflowStates(workflow.ID)?.Cast<State>()?.Select(s => s.ID);
                if (states.Contains(state))
                {
                    return workflow;
                };
            }

            return null;
        }
    }
}
