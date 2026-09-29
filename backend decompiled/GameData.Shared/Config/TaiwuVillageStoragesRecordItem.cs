using System;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuVillageStoragesRecordItem : ConfigItem<TaiwuVillageStoragesRecordItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string[] Parameters;

	public TaiwuVillageStoragesRecordItem(short templateId, string name, string desc, string[] parameters)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Parameters = parameters;
	}

	public TaiwuVillageStoragesRecordItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Parameters = new string[6] { "", "", "", "", "", "" };
	}

	public TaiwuVillageStoragesRecordItem(short templateId, TaiwuVillageStoragesRecordItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Parameters = other.Parameters;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override TaiwuVillageStoragesRecordItem Duplicate(int templateId)
	{
		return new TaiwuVillageStoragesRecordItem((short)templateId, this);
	}
}
