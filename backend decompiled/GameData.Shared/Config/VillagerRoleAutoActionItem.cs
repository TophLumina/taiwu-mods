using System;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleAutoActionItem : ConfigItem<VillagerRoleAutoActionItem, short>
{
	public readonly short TemplateId;

	public readonly short VillagerRole;

	public readonly string ShortName;

	public readonly string Name;

	public readonly string DisplayIcon;

	public readonly string DisplayIcon2;

	public readonly string Desc;

	public readonly bool UnlockByChicken;

	public readonly string DescName;

	public readonly string DescShort;

	public readonly string DescContent;

	public readonly string Illustration;

	public VillagerRoleAutoActionItem(short templateId, short villagerRole, string shortName, string name, string displayIcon, string displayIcon2, string desc, bool unlockByChicken, string descName, string descShort, string descContent, string illustration)
	{
		TemplateId = templateId;
		VillagerRole = villagerRole;
		ShortName = shortName;
		Name = name;
		DisplayIcon = displayIcon;
		DisplayIcon2 = displayIcon2;
		Desc = desc;
		UnlockByChicken = unlockByChicken;
		DescName = descName;
		DescShort = descShort;
		DescContent = descContent;
		Illustration = illustration;
	}

	public VillagerRoleAutoActionItem()
	{
		TemplateId = 0;
		VillagerRole = 0;
		ShortName = null;
		Name = null;
		DisplayIcon = null;
		DisplayIcon2 = null;
		Desc = null;
		UnlockByChicken = false;
		DescName = null;
		DescShort = null;
		DescContent = null;
		Illustration = null;
	}

	public VillagerRoleAutoActionItem(short templateId, VillagerRoleAutoActionItem other)
	{
		TemplateId = templateId;
		VillagerRole = other.VillagerRole;
		ShortName = other.ShortName;
		Name = other.Name;
		DisplayIcon = other.DisplayIcon;
		DisplayIcon2 = other.DisplayIcon2;
		Desc = other.Desc;
		UnlockByChicken = other.UnlockByChicken;
		DescName = other.DescName;
		DescShort = other.DescShort;
		DescContent = other.DescContent;
		Illustration = other.Illustration;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override VillagerRoleAutoActionItem Duplicate(int templateId)
	{
		return new VillagerRoleAutoActionItem((short)templateId, this);
	}
}
