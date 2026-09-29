using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class ItemFilterRulesItem : ConfigItem<ItemFilterRulesItem, short>
{
	public readonly short TemplateId;

	public readonly PresetItemTemplateId AppointId;

	public readonly List<PresetItemSubTypeWithGradeRange> AppointOrSubTypeCore;

	public readonly List<PresetItemTemplateIdGroup> AppointOrIdCore;

	public ItemFilterRulesItem(short templateId, PresetItemTemplateId appointId, List<PresetItemSubTypeWithGradeRange> appointOrSubTypeCore, List<PresetItemTemplateIdGroup> appointOrIdCore)
	{
		TemplateId = templateId;
		AppointId = appointId;
		AppointOrSubTypeCore = appointOrSubTypeCore;
		AppointOrIdCore = appointOrIdCore;
	}

	public ItemFilterRulesItem()
	{
		TemplateId = 0;
		AppointId = new PresetItemTemplateId("Misc", -1);
		AppointOrSubTypeCore = new List<PresetItemSubTypeWithGradeRange>();
		AppointOrIdCore = new List<PresetItemTemplateIdGroup>();
	}

	public ItemFilterRulesItem(short templateId, ItemFilterRulesItem other)
	{
		TemplateId = templateId;
		AppointId = other.AppointId;
		AppointOrSubTypeCore = other.AppointOrSubTypeCore;
		AppointOrIdCore = other.AppointOrIdCore;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ItemFilterRulesItem Duplicate(int templateId)
	{
		return new ItemFilterRulesItem((short)templateId, this);
	}
}
