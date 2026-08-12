using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakPageEffectItem : ConfigItem<SkillBreakPageEffectItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 是否为正练书页
	/// </summary>
	public readonly bool IsDirect;

	/// <summary>
	/// 书页索引
	/// - 参考 GameData.Domains.Item.CombatSkillBookPage 的定义
	/// </summary>
	public readonly byte PageId;

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
	/// <param name="isDirect">是否为正练书页</param>
	/// <param name="pageId">书页索引 - 参考 GameData.Domains.Item.CombatSkillBookPage 的定义</param>
	/// <param name="effectNeigong">内功效果</param>
	/// <param name="effectAttack">摧破效果</param>
	/// <param name="effectAgile">轻灵效果</param>
	/// <param name="effectDefense">护体效果</param>
	/// <param name="effectAssist">奇窍效果</param>
	public SkillBreakPageEffectItem(sbyte templateId, bool isDirect, byte pageId, sbyte effectNeigong, sbyte effectAttack, sbyte effectAgile, sbyte effectDefense, sbyte effectAssist)
	{
		TemplateId = templateId;
		IsDirect = isDirect;
		PageId = pageId;
		EffectNeigong = effectNeigong;
		EffectAttack = effectAttack;
		EffectAgile = effectAgile;
		EffectDefense = effectDefense;
		EffectAssist = effectAssist;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SkillBreakPageEffectItem()
	{
		TemplateId = 0;
		IsDirect = false;
		PageId = 0;
		EffectNeigong = 0;
		EffectAttack = 0;
		EffectAgile = 0;
		EffectDefense = 0;
		EffectAssist = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SkillBreakPageEffectItem(sbyte templateId, SkillBreakPageEffectItem other)
	{
		TemplateId = templateId;
		IsDirect = other.IsDirect;
		PageId = other.PageId;
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
	public override SkillBreakPageEffectItem Duplicate(int templateId)
	{
		return new SkillBreakPageEffectItem((sbyte)templateId, this);
	}
}
