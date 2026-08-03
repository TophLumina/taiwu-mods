using System;
using Config.Common;

namespace Config;

[Serializable]
public class DebateReferenceItem : ConfigItem<DebateReferenceItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 技艺参考书类型
	/// </summary>
	public readonly sbyte LifeSkillType;

	/// <summary>
	/// 功法参考书门派类型
	/// </summary>
	public readonly sbyte SectType;

	/// <summary>
	/// 武学参考书武学类型
	/// </summary>
	public readonly sbyte CombatSkillType;

	/// <summary>
	/// 增强己方论点基础论据
	/// - 该列由公式生成，修改请在左边行中进行
	/// </summary>
	public readonly short[] BasesIncrement;

	/// <summary>
	/// 无效对方引经据典效果
	/// - 该列由公式生成，修改请在左边行中进行
	/// </summary>
	public readonly short[] IsInvalidatingReference;

	/// <summary>
	/// 获得对方引经据典书籍研读进度加倍
	/// - 该列由公式生成，修改请在左边行中进行
	/// </summary>
	public readonly short[] IsLearningSpeedBuff;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="lifeSkillType">技艺参考书类型</param>
	/// <param name="sectType">功法参考书门派类型</param>
	/// <param name="combatSkillType">武学参考书武学类型</param>
	/// <param name="basesIncrement">增强己方论点基础论据 - 该列由公式生成，修改请在左边行中进行</param>
	/// <param name="isInvalidatingReference">无效对方引经据典效果 - 该列由公式生成，修改请在左边行中进行</param>
	/// <param name="isLearningSpeedBuff">获得对方引经据典书籍研读进度加倍 - 该列由公式生成，修改请在左边行中进行</param>
	public DebateReferenceItem(short templateId, sbyte lifeSkillType, sbyte sectType, sbyte combatSkillType, short[] basesIncrement, short[] isInvalidatingReference, short[] isLearningSpeedBuff)
	{
		TemplateId = templateId;
		LifeSkillType = lifeSkillType;
		SectType = sectType;
		CombatSkillType = combatSkillType;
		BasesIncrement = basesIncrement;
		IsInvalidatingReference = isInvalidatingReference;
		IsLearningSpeedBuff = isLearningSpeedBuff;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public DebateReferenceItem()
	{
		TemplateId = 0;
		LifeSkillType = 0;
		SectType = 0;
		CombatSkillType = 0;
		BasesIncrement = new short[16];
		IsInvalidatingReference = new short[16];
		IsLearningSpeedBuff = new short[16];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public DebateReferenceItem(short templateId, DebateReferenceItem other)
	{
		TemplateId = templateId;
		LifeSkillType = other.LifeSkillType;
		SectType = other.SectType;
		CombatSkillType = other.CombatSkillType;
		BasesIncrement = other.BasesIncrement;
		IsInvalidatingReference = other.IsInvalidatingReference;
		IsLearningSpeedBuff = other.IsLearningSpeedBuff;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override DebateReferenceItem Duplicate(int templateId)
	{
		return new DebateReferenceItem((short)templateId, this);
	}
}
