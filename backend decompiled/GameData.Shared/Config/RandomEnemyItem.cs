using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class RandomEnemyItem : ConfigItem<RandomEnemyItem, short>
{
	public readonly short TemplateId;

	public readonly List<short> SectIds;

	public readonly int SelectSectCount;

	public readonly List<short> RequireAttackSkillType;

	public readonly sbyte ItemGrade;

	public readonly short LifeSkillQualificationAdjust;

	public readonly short CombatSkillQualificationAdjust;

	public readonly short SpiritualDebt;

	public readonly sbyte AddPoisonRate;

	public readonly sbyte MaxAddPoisonCount;

	public readonly short[] PoisonsToAdd;

	public readonly (int, int) PracticeRandomRange;

	public readonly (int, int)[] PageCountRandomRange;

	public RandomEnemyItem(short templateId, List<short> sectIds, int selectSectCount, List<short> requireAttackSkillType, sbyte itemGrade, short lifeSkillQualificationAdjust, short combatSkillQualificationAdjust, short spiritualDebt, sbyte addPoisonRate, sbyte maxAddPoisonCount, short[] poisonsToAdd, (int, int) practiceRandomRange, (int, int)[] pageCountRandomRange)
	{
		TemplateId = templateId;
		SectIds = sectIds;
		SelectSectCount = selectSectCount;
		RequireAttackSkillType = requireAttackSkillType;
		ItemGrade = itemGrade;
		LifeSkillQualificationAdjust = lifeSkillQualificationAdjust;
		CombatSkillQualificationAdjust = combatSkillQualificationAdjust;
		SpiritualDebt = spiritualDebt;
		AddPoisonRate = addPoisonRate;
		MaxAddPoisonCount = maxAddPoisonCount;
		PoisonsToAdd = poisonsToAdd;
		PracticeRandomRange = practiceRandomRange;
		PageCountRandomRange = pageCountRandomRange;
	}

	public RandomEnemyItem()
	{
		TemplateId = 0;
		SectIds = new List<short> { 0 };
		SelectSectCount = 1;
		RequireAttackSkillType = new List<short>();
		ItemGrade = 0;
		LifeSkillQualificationAdjust = 0;
		CombatSkillQualificationAdjust = 0;
		SpiritualDebt = 0;
		AddPoisonRate = 0;
		MaxAddPoisonCount = 0;
		PoisonsToAdd = new short[0];
		PracticeRandomRange = default((int, int));
		PageCountRandomRange = new(int, int)[2]
		{
			(0, 0),
			(0, 0)
		};
	}

	public RandomEnemyItem(short templateId, RandomEnemyItem other)
	{
		TemplateId = templateId;
		SectIds = other.SectIds;
		SelectSectCount = other.SelectSectCount;
		RequireAttackSkillType = other.RequireAttackSkillType;
		ItemGrade = other.ItemGrade;
		LifeSkillQualificationAdjust = other.LifeSkillQualificationAdjust;
		CombatSkillQualificationAdjust = other.CombatSkillQualificationAdjust;
		SpiritualDebt = other.SpiritualDebt;
		AddPoisonRate = other.AddPoisonRate;
		MaxAddPoisonCount = other.MaxAddPoisonCount;
		PoisonsToAdd = other.PoisonsToAdd;
		PracticeRandomRange = other.PracticeRandomRange;
		PageCountRandomRange = other.PageCountRandomRange;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override RandomEnemyItem Duplicate(int templateId)
	{
		return new RandomEnemyItem((short)templateId, this);
	}
}
