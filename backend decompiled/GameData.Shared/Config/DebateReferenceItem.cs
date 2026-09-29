using System;
using Config.Common;

namespace Config;

[Serializable]
public class DebateReferenceItem : ConfigItem<DebateReferenceItem, short>
{
	public readonly short TemplateId;

	public readonly sbyte LifeSkillType;

	public readonly sbyte SectType;

	public readonly sbyte CombatSkillType;

	public readonly short[] BasesIncrement;

	public readonly short[] IsInvalidatingReference;

	public readonly short[] IsLearningSpeedBuff;

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

	public override DebateReferenceItem Duplicate(int templateId)
	{
		return new DebateReferenceItem((short)templateId, this);
	}
}
