using MFilesAPI;
using Unitfly.MFiles.DevTools.Common.CaseConverters;

namespace Unitfly.MFiles.DevTools.Update.ItemNameParsers
{
    public class WorkflowNameParser : ItemNameParser<WorkflowAdmin>
    {
        public WorkflowNameParser(string template, CaseConverter nameConverter = null) : base(template, nameConverter)
        {
        }

        public override string Expand(WorkflowAdmin workflow, IVault vault)
        {
            return Template?.Replace("{Workflow}", NameConverter.ToString(workflow.Workflow.Name));
        }
    }
}
