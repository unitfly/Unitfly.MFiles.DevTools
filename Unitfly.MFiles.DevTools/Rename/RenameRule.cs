using MFilesAPI;
using System.Collections.Generic;
using System.Linq;

namespace Unitfly.MFiles.DevTools.Rename
{
    public class RenameRule
    {
        public string Alias { get; set; }

        public int? ID { get; set; }

        public string NewName { get; set; }

        public string OldName { get; set; }

        public override string ToString()
        {
            return $"({Alias};{ID};{OldName}) -> {NewName}";
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(OldName) && string.IsNullOrWhiteSpace(Alias) && !ID.HasValue) return false;
            return true;
        }

        public string NewPluralName()
        {
            if (string.IsNullOrWhiteSpace(OldName) || string.IsNullOrWhiteSpace(NewName))
            {
                return null;
            }

            var old = OldName.ToLower();
            return (old.EndsWith("sh") || old.EndsWith("ch") || old.EndsWith("s") || old.EndsWith("x") || old.EndsWith("z")) ? $"{NewName}es" : $"{NewName}s";
        }

        public IEnumerable<ObjTypeAdmin> GetObjTypes(IEnumerable<ObjTypeAdmin> items)
        {
            IEnumerable<ObjTypeAdmin> filtered = null;
            if (ID.HasValue)
            {
                filtered = items.Where(i => i.ObjectType.ID == ID.Value);
            }
            else if (!string.IsNullOrWhiteSpace(Alias))
            {
                filtered = items.Where(i => (i.SemanticAliases.Value ?? "").Split(';').Contains(Alias));
            }
            else
            {
                filtered = items.Where(i => i.ObjectType.NameSingular == OldName);
            }

            return filtered;
        }

        public IEnumerable<ObjectClassAdmin> GetObjectClasses(IEnumerable<ObjectClassAdmin> items)
        {
            IEnumerable<ObjectClassAdmin> filtered = null;
            if (ID.HasValue)
            {
                filtered = items.Where(i => i.ID == ID.Value);
            }
            else if (!string.IsNullOrWhiteSpace(Alias))
            {
                filtered = items.Where(i => (i.SemanticAliases.Value ?? "").Split(';').Contains(Alias));
            }
            else
            {
                filtered = items.Where(i => i.Name == OldName);
            }

            return filtered;
        }

        public IEnumerable<NamedACLAdmin> GetNamedACLs(IEnumerable<NamedACLAdmin> items)
        {
            IEnumerable<NamedACLAdmin> filtered = null;
            if (ID.HasValue)
            {
                filtered = items.Where(i => i.NamedACL.ID == ID.Value);
            }
            else if (!string.IsNullOrWhiteSpace(Alias))
            {
                filtered = items.Where(i => (i.SemanticAliases.Value ?? "").Split(';').Contains(Alias));
            }
            else
            {
                filtered = items.Where(i => i.NamedACL.Name == OldName);
            }

            return filtered;
        }

        public IEnumerable<UserGroupAdmin> GetUserGroups(IEnumerable<UserGroupAdmin> items)
        {
            IEnumerable<UserGroupAdmin> filtered = null;
            if (ID.HasValue)
            {
                filtered = items.Where(i => i.UserGroup.ID == ID.Value);
            }
            else if (!string.IsNullOrWhiteSpace(Alias))
            {
                filtered = items.Where(i => (i.SemanticAliases.Value ?? "").Split(';').Contains(Alias));
            }
            else
            {
                filtered = items.Where(i => i.UserGroup.Name == OldName);
            }

            return filtered;
        }

        public IEnumerable<PropertyDefAdmin> GetPropertyDefs(IEnumerable<PropertyDefAdmin> items)
        {
            IEnumerable<PropertyDefAdmin> filtered = null;
            if (ID.HasValue)
            {
                filtered = items.Where(i => i.PropertyDef.ID == ID.Value);
            }
            else if (!string.IsNullOrWhiteSpace(Alias))
            {
                filtered = items.Where(i => (i.SemanticAliases.Value ?? "").Split(';').Contains(Alias));
            }
            else
            {
                filtered = items.Where(i => i.PropertyDef.Name == OldName);
            }

            return filtered;
        }

        public IEnumerable<WorkflowAdmin> GetWorkflows(IEnumerable<WorkflowAdmin> items)
        {
            IEnumerable<WorkflowAdmin> filtered = null;
            if (ID.HasValue)
            {
                filtered = items.Where(i => i.Workflow.ID == ID.Value);
            }
            else if (!string.IsNullOrWhiteSpace(Alias))
            {
                filtered = items.Where(i => (i.SemanticAliases.Value ?? "").Split(';').Contains(Alias));
            }
            else
            {
                filtered = items.Where(i => i.Workflow.Name == OldName);
            }

            return filtered;
        }

        public Dictionary<WorkflowAdmin, IEnumerable<IStateTransition>> GetWorkflowStateTransitions(IEnumerable<WorkflowAdmin> workflows)
        {
            var dict = new Dictionary<WorkflowAdmin, IEnumerable<IStateTransition>>();

            foreach (var workflow in workflows)
            {
                var items = workflow.StateTransitions?.Cast<StateTransition>() ?? new List<StateTransition>();

                IEnumerable<IStateTransition> transitions = null;
                if (ID.HasValue)
                {
                    transitions = items.Where(i => i.ID == ID.Value);
                }
                else if (!string.IsNullOrWhiteSpace(Alias))
                {
                    transitions = items.Where(i => (i.SemanticAliases.Value ?? "").Split(';').Contains(Alias));
                }
                else
                {
                    transitions = items.Where(i => i.Name == OldName);
                }

                if (transitions != null && transitions.Any())
                {
                    dict[workflow] = transitions;
                }
            }

            return dict;
        }

        public Dictionary<WorkflowAdmin, IEnumerable<StateAdmin>> GetWorkflowStates(IEnumerable<WorkflowAdmin> workflows)
        {
            var dict = new Dictionary<WorkflowAdmin, IEnumerable<StateAdmin>>();

            foreach (var workflow in workflows)
            {
                var items = workflow.States?.Cast<StateAdmin>() ?? new List<StateAdmin>();

                IEnumerable<StateAdmin> states = null;
                if (ID.HasValue)
                {
                    states = items.Where(i => i.ID == ID.Value);
                }
                else if (!string.IsNullOrWhiteSpace(Alias))
                {
                    states = items.Where(i => (i.SemanticAliases.Value ?? "").Split(';').Contains(Alias));
                }
                else
                {
                    states = items.Where(i => i.Name == OldName);
                }

                if (states != null && states.Any())
                {
                    dict[workflow] = states;
                }
            }

            return dict;
        }
    }
}
