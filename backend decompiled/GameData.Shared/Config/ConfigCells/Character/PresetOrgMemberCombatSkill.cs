using System;

namespace Config.ConfigCells.Character;

[Serializable]
public struct PresetOrgMemberCombatSkill(short skillGroupId, sbyte maxGrade)
{
	public short SkillGroupId = skillGroupId;

	public sbyte MaxGrade = maxGrade;
}
