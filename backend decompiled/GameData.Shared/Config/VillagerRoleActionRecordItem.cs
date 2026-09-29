using System;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleActionRecordItem : ConfigItem<VillagerRoleActionRecordItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Icon;

	public readonly short VillagerRoleAutoAction;

	public readonly short VillagerRoleArrangement;

	public VillagerRoleActionRecordItem(short templateId, string name, string icon, short villagerRoleAutoAction, short villagerRoleArrangement)
	{
		TemplateId = templateId;
		Name = name;
		Icon = icon;
		VillagerRoleAutoAction = villagerRoleAutoAction;
		VillagerRoleArrangement = villagerRoleArrangement;
	}

	public VillagerRoleActionRecordItem()
	{
		TemplateId = 0;
		Name = null;
		Icon = null;
		VillagerRoleAutoAction = 0;
		VillagerRoleArrangement = 0;
	}

	public VillagerRoleActionRecordItem(short templateId, VillagerRoleActionRecordItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Icon = other.Icon;
		VillagerRoleAutoAction = other.VillagerRoleAutoAction;
		VillagerRoleArrangement = other.VillagerRoleArrangement;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override VillagerRoleActionRecordItem Duplicate(int templateId)
	{
		return new VillagerRoleActionRecordItem((short)templateId, this);
	}
}
