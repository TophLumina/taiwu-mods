using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MakeItemTypeItem : ConfigItem<MakeItemTypeItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly short ItemSubType;

	public readonly string TypeName;

	public readonly string TypeBigIcon;

	public readonly List<short> MakeItemSubTypes;

	public MakeItemTypeItem(short templateId, string name, short itemSubType, string typeName, string typeBigIcon, List<short> makeItemSubTypes)
	{
		TemplateId = templateId;
		Name = name;
		ItemSubType = itemSubType;
		TypeName = typeName;
		TypeBigIcon = typeBigIcon;
		MakeItemSubTypes = makeItemSubTypes;
	}

	public MakeItemTypeItem()
	{
		TemplateId = 0;
		Name = null;
		ItemSubType = 0;
		TypeName = null;
		TypeBigIcon = null;
		MakeItemSubTypes = new List<short>();
	}

	public MakeItemTypeItem(short templateId, MakeItemTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ItemSubType = other.ItemSubType;
		TypeName = other.TypeName;
		TypeBigIcon = other.TypeBigIcon;
		MakeItemSubTypes = other.MakeItemSubTypes;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MakeItemTypeItem Duplicate(int templateId)
	{
		return new MakeItemTypeItem((short)templateId, this);
	}
}
