using System;
using Config.Common;

namespace Config;

/// <summary>
/// 突破盘玄机效果配置
/// </summary>
[Serializable]
public class SkillBreakBonusEffectItem : ConfigItem<SkillBreakBonusEffectItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 短名称
	/// - 用于前端筛选
	/// </summary>
	public readonly string ShortName;

	/// <summary>
	/// 类型名称
	/// - 此效果从属类型的前端显示
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 内功效果
	/// </summary>
	public readonly sbyte EffectNeigong;

	/// <summary>
	/// 摧破效果
	/// </summary>
	public readonly sbyte EffectAttack;

	/// <summary>
	/// 轻灵效果
	/// </summary>
	public readonly sbyte EffectAgile;

	/// <summary>
	/// 护体效果
	/// </summary>
	public readonly sbyte EffectDefense;

	/// <summary>
	/// 奇窍效果
	/// </summary>
	public readonly sbyte EffectAssist;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="shortName">短名称 - 用于前端筛选</param>
	/// <param name="name">类型名称 - 此效果从属类型的前端显示</param>
	/// <param name="effectNeigong">内功效果</param>
	/// <param name="effectAttack">摧破效果</param>
	/// <param name="effectAgile">轻灵效果</param>
	/// <param name="effectDefense">护体效果</param>
	/// <param name="effectAssist">奇窍效果</param>
	public SkillBreakBonusEffectItem(sbyte templateId, string shortName, string name, sbyte effectNeigong, sbyte effectAttack, sbyte effectAgile, sbyte effectDefense, sbyte effectAssist)
	{
		TemplateId = templateId;
		ShortName = shortName;
		Name = name;
		EffectNeigong = effectNeigong;
		EffectAttack = effectAttack;
		EffectAgile = effectAgile;
		EffectDefense = effectDefense;
		EffectAssist = effectAssist;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SkillBreakBonusEffectItem()
	{
		TemplateId = 0;
		ShortName = null;
		Name = null;
		EffectNeigong = 0;
		EffectAttack = 0;
		EffectAgile = 0;
		EffectDefense = 0;
		EffectAssist = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SkillBreakBonusEffectItem(sbyte templateId, SkillBreakBonusEffectItem other)
	{
		TemplateId = templateId;
		ShortName = other.ShortName;
		Name = other.Name;
		EffectNeigong = other.EffectNeigong;
		EffectAttack = other.EffectAttack;
		EffectAgile = other.EffectAgile;
		EffectDefense = other.EffectDefense;
		EffectAssist = other.EffectAssist;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SkillBreakBonusEffectItem Duplicate(int templateId)
	{
		return new SkillBreakBonusEffectItem((sbyte)templateId, this);
	}

	/// <summary>
	/// 获取效果实现配置 ID
	/// </summary>
	public int GetImplementId(sbyte equipType)
	{
		return equipType switch
		{
			0 => EffectNeigong, 
			1 => EffectAttack, 
			2 => EffectAgile, 
			3 => EffectDefense, 
			4 => EffectAssist, 
			_ => -1, 
		};
	}
}
