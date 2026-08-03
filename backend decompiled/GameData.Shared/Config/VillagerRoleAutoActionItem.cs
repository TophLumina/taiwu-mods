using System;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleAutoActionItem : ConfigItem<VillagerRoleAutoActionItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 对应身份
	/// </summary>
	public readonly short VillagerRole;

	/// <summary>
	/// 工作短名称
	/// </summary>
	public readonly string ShortName;

	/// <summary>
	/// 工作名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 对应图标
	/// </summary>
	public readonly string DisplayIcon;

	/// <summary>
	/// 对应另一套图标
	/// </summary>
	public readonly string DisplayIcon2;

	/// <summary>
	/// 工作说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 需要元鸡解锁
	/// </summary>
	public readonly bool UnlockByChicken;

	/// <summary>
	/// 工作名称
	/// - 村民身份界面工作名称
	/// </summary>
	public readonly string DescName;

	/// <summary>
	/// 简短描述
	/// - 村民身份界面工作简短描述
	/// </summary>
	public readonly string DescShort;

	/// <summary>
	/// 完整描述
	/// - 村民身份界面工作完整描述
	/// </summary>
	public readonly string DescContent;

	/// <summary>
	/// 图片
	/// - 村民身份界面上的图片
	/// </summary>
	public readonly string Illustration;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="villagerRole">对应身份</param>
	/// <param name="shortName">工作短名称</param>
	/// <param name="name">工作名称</param>
	/// <param name="displayIcon">对应图标</param>
	/// <param name="displayIcon2">对应另一套图标</param>
	/// <param name="desc">工作说明</param>
	/// <param name="unlockByChicken">需要元鸡解锁</param>
	/// <param name="descName">工作名称 - 村民身份界面工作名称</param>
	/// <param name="descShort">简短描述 - 村民身份界面工作简短描述</param>
	/// <param name="descContent">完整描述 - 村民身份界面工作完整描述</param>
	/// <param name="illustration">图片 - 村民身份界面上的图片</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override VillagerRoleAutoActionItem Duplicate(int templateId)
	{
		return new VillagerRoleAutoActionItem((short)templateId, this);
	}
}
