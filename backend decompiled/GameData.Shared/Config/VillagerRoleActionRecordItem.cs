using System;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleActionRecordItem : ConfigItem<VillagerRoleActionRecordItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 自发行为
	/// </summary>
	public readonly short VillagerRoleAutoAction;

	/// <summary>
	/// 主动行为
	/// </summary>
	public readonly short VillagerRoleArrangement;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="icon">图标</param>
	/// <param name="villagerRoleAutoAction">自发行为</param>
	/// <param name="villagerRoleArrangement">主动行为</param>
	public VillagerRoleActionRecordItem(short templateId, string name, string icon, short villagerRoleAutoAction, short villagerRoleArrangement)
	{
		TemplateId = templateId;
		Name = name;
		Icon = icon;
		VillagerRoleAutoAction = villagerRoleAutoAction;
		VillagerRoleArrangement = villagerRoleArrangement;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public VillagerRoleActionRecordItem()
	{
		TemplateId = 0;
		Name = null;
		Icon = null;
		VillagerRoleAutoAction = 0;
		VillagerRoleArrangement = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override VillagerRoleActionRecordItem Duplicate(int templateId)
	{
		return new VillagerRoleActionRecordItem((short)templateId, this);
	}
}
