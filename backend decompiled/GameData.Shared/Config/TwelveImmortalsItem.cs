using System;
using Config.Common;

namespace Config;

[Serializable]
public class TwelveImmortalsItem : ConfigItem<TwelveImmortalsItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 角色
	/// </summary>
	public readonly short Character;

	/// <summary>
	/// 功法
	/// </summary>
	public readonly short CombatSkill;

	/// <summary>
	/// 影响范围
	/// </summary>
	public readonly int ImpactRange;

	/// <summary>
	/// 生成州域
	/// </summary>
	public readonly sbyte MapState;

	/// <summary>
	/// 出现顺序
	/// - 填 0~2
	/// </summary>
	public readonly int Group;

	/// <summary>
	/// 法宝化身名称
	/// </summary>
	public readonly string TreasureDesc;

	/// <summary>
	/// 法宝状态1
	/// </summary>
	public readonly string TreasureState1;

	/// <summary>
	/// 法宝状态0
	/// </summary>
	public readonly string TreasureState0;

	/// <summary>
	/// 法宝名称
	/// </summary>
	public readonly string TreasureName;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="character">角色</param>
	/// <param name="combatSkill">功法</param>
	/// <param name="impactRange">影响范围</param>
	/// <param name="mapState">生成州域</param>
	/// <param name="group">出现顺序 - 填 0~2</param>
	/// <param name="treasureDesc">法宝化身名称</param>
	/// <param name="treasureState1">法宝状态1</param>
	/// <param name="treasureState0">法宝状态0</param>
	/// <param name="treasureName">法宝名称</param>
	public TwelveImmortalsItem(sbyte templateId, short character, short combatSkill, int impactRange, sbyte mapState, int group, string treasureDesc, string treasureState1, string treasureState0, string treasureName)
	{
		TemplateId = templateId;
		Character = character;
		CombatSkill = combatSkill;
		ImpactRange = impactRange;
		MapState = mapState;
		Group = group;
		TreasureDesc = treasureDesc;
		TreasureState1 = treasureState1;
		TreasureState0 = treasureState0;
		TreasureName = treasureName;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TwelveImmortalsItem()
	{
		TemplateId = 0;
		Character = 0;
		CombatSkill = 0;
		ImpactRange = 0;
		MapState = 0;
		Group = 0;
		TreasureDesc = null;
		TreasureState1 = null;
		TreasureState0 = null;
		TreasureName = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TwelveImmortalsItem(sbyte templateId, TwelveImmortalsItem other)
	{
		TemplateId = templateId;
		Character = other.Character;
		CombatSkill = other.CombatSkill;
		ImpactRange = other.ImpactRange;
		MapState = other.MapState;
		Group = other.Group;
		TreasureDesc = other.TreasureDesc;
		TreasureState1 = other.TreasureState1;
		TreasureState0 = other.TreasureState0;
		TreasureName = other.TreasureName;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TwelveImmortalsItem Duplicate(int templateId)
	{
		return new TwelveImmortalsItem((sbyte)templateId, this);
	}
}
