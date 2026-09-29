using System.Collections.Generic;
using Config;
using GameData.Domains.Character;

namespace GameData.Domains.CombatSkill;

public interface ICombatSkillBridge
{
	short SkillTemplateId { get; }

	OuterAndInnerInts CostBreathStance { get; }

	sbyte GetCostMobilityPercent();

	void GetCostTrick(List<NeedTrick> costTricks);

	(sbyte type, sbyte value) GetCostNeiliAllocation();
}
