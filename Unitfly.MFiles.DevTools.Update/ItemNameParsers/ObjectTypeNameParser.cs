﻿using MFilesAPI;
using Unitfly.MFiles.DevTools.Common.CaseConverters;

namespace Unitfly.MFiles.DevTools.Update.ItemNameParsers
{
    public class ObjectTypeNameParser : ItemNameParser<ObjTypeAdmin>
    {
        public ObjectTypeNameParser(string template, CaseConverter nameConverter = null) : base(template, nameConverter)
        {
        }

        public override string Expand(ObjTypeAdmin @type, IVault vault)
        {
            return Template?.Replace("{ObjectType}", NameConverter.ToString(@type.ObjectType.NameSingular));
        }
    }
}
