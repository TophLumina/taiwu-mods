using System;

namespace Config.ConfigCells.Character;

[Serializable]
public struct PresetOrgMemberCombatSkill(short skillGroupId, sbyte maxGrade)
{
	/// <summary>
	/// 功法组 ID, 目前为该组的第一个功法的 ID.
	/// </summary>
	public short SkillGroupId = skillGroupId;

	/// <summary>
	/// 已习得的最高品阶.
	/// 即从最低品阶开始, 到此值指定的最高品阶, 都会习得.
	/// </summary>
	public sbyte MaxGrade = maxGrade;
}
