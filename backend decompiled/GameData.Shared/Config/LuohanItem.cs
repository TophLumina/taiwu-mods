using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LuohanItem : ConfigItem<LuohanItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名字
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 关联道具
	/// </summary>
	public readonly short Accessory;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly ELuohanBonusType BonusType;

	/// <summary>
	/// 关联药物
	/// - 使用该物品模板创建玄机
	/// </summary>
	public readonly List<short> Medicine;

	/// <summary>
	/// 关联引子
	/// - 使用该物品模板创建玄机
	/// </summary>
	public readonly short Material;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名字</param>
	/// <param name="accessory">关联道具</param>
	/// <param name="bonusType">类型</param>
	/// <param name="medicine">关联药物 - 使用该物品模板创建玄机</param>
	/// <param name="material">关联引子 - 使用该物品模板创建玄机</param>
	public LuohanItem(sbyte templateId, string name, short accessory, ELuohanBonusType bonusType, List<short> medicine, short material)
	{
		TemplateId = templateId;
		Name = name;
		Accessory = accessory;
		BonusType = bonusType;
		Medicine = medicine;
		Material = material;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LuohanItem()
	{
		TemplateId = 0;
		Name = null;
		Accessory = 0;
		BonusType = ELuohanBonusType.Invalid;
		Medicine = null;
		Material = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public LuohanItem(sbyte templateId, LuohanItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Accessory = other.Accessory;
		BonusType = other.BonusType;
		Medicine = other.Medicine;
		Material = other.Material;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LuohanItem Duplicate(int templateId)
	{
		return new LuohanItem((sbyte)templateId, this);
	}
}
