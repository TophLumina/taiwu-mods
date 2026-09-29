using System.Collections.Generic;

namespace GameData.Domains.CombatSkill;

public interface IFilterableCombatSkill
{
	short TemplateId { get; }

	sbyte Type { get; }

	sbyte SectId { get; }

	ushort ActivationState { get; }

	bool IsInAnyEquipPlans { get; }

	bool HasSectEmeiSkillBreakBonus { get; }

	short Power { get; }

	List<sbyte> BreakBonusGrades { get; }

	ushort ReadingState { get; }

	short MaxObtainableNeili { get; }

	short ObtainedNeili { get; }

	sbyte FiveElementTransferTypeWhileLooping { get; set; }

	sbyte FiveElementDestTypeWhileLooping { get; set; }

	int CombatSkillProficiency { get; }
}
