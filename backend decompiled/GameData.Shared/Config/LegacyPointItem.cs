using System;
using Config.Common;

namespace Config;

[Serializable]
public class LegacyPointItem : ConfigItem<LegacyPointItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 类型
	/// - 对应LegacyPointType表中的模板ID
	/// </summary>
	public readonly sbyte Type;

	/// <summary>
	/// 基础点数
	/// - 每次获得的基础点数，计算百分比加成后得到最终获得点数
	/// </summary>
	public readonly short BasePoint;

	/// <summary>
	/// 点数上限
	/// - 此类遗惠点获取上限
	/// </summary>
	public readonly short MaxPoint;

	/// <summary>
	/// 默认隐藏
	/// </summary>
	public readonly bool IsHidden;

	/// <summary>
	/// 世界细节加成
	/// - 根据玩家所选的世界细节等级，在获取遗惠点数时得到加成
	/// </summary>
	public readonly byte[] BonusTypes;

	/// <summary>
	/// 获得条件说明
	/// - 用在tips等地方显示
	/// </summary>
	public readonly string ConditionDesc;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="type">类型 - 对应LegacyPointType表中的模板ID</param>
	/// <param name="basePoint">基础点数 - 每次获得的基础点数，计算百分比加成后得到最终获得点数</param>
	/// <param name="maxPoint">点数上限 - 此类遗惠点获取上限</param>
	/// <param name="isHidden">默认隐藏</param>
	/// <param name="bonusTypes">世界细节加成 - 根据玩家所选的世界细节等级，在获取遗惠点数时得到加成</param>
	/// <param name="conditionDesc">获得条件说明 - 用在tips等地方显示</param>
	public LegacyPointItem(short templateId, string name, sbyte type, short basePoint, short maxPoint, bool isHidden, byte[] bonusTypes, string conditionDesc)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		BasePoint = basePoint;
		MaxPoint = maxPoint;
		IsHidden = isHidden;
		BonusTypes = bonusTypes;
		ConditionDesc = conditionDesc;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LegacyPointItem()
	{
		TemplateId = 0;
		Name = null;
		Type = 0;
		BasePoint = -1;
		MaxPoint = -1;
		IsHidden = false;
		BonusTypes = new byte[0];
		ConditionDesc = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public LegacyPointItem(short templateId, LegacyPointItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		BasePoint = other.BasePoint;
		MaxPoint = other.MaxPoint;
		IsHidden = other.IsHidden;
		BonusTypes = other.BonusTypes;
		ConditionDesc = other.ConditionDesc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LegacyPointItem Duplicate(int templateId)
	{
		return new LegacyPointItem((short)templateId, this);
	}
}
