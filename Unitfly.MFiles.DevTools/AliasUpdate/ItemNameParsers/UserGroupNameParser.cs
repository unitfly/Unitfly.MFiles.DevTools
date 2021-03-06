﻿using MFilesAPI;
using Unitfly.MFiles.DevTools.CaseConverters;

namespace Unitfly.MFiles.DevTools.AliasUpdate.ItemNameParsers
{
    public class UserGroupNameParser : ItemNameParser<UserGroupAdmin>
    {
        public UserGroupNameParser(string template, CaseConverter nameConverter = null) : base(template, nameConverter)
        {
        }

        public override string Expand(UserGroupAdmin userGroup, IVault vault)
        {
            return Template?.Replace("{UserGroup}", NameConverter.ToString(userGroup.UserGroup.Name));
        }
    }
}
