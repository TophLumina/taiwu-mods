using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 功法技艺资质加成
/// </summary>
[Serializable]
public struct SkillQualificationBonus(sbyte skillGroup, sbyte skillType, sbyte bonus, short skillId = -1) : ISerializableGameData
{
	/// <summary>
	/// 融合技能类型 (包含技能组以及技能类型).
	/// 技能组: <see cref="T:GameData.Domains.Character.SkillGroup" />.
	/// 技艺类型: <see cref="T:GameData.Domains.Character.LifeSkillType" />.
	/// 功法类型: <see cref="T:GameData.Domains.CombatSkill.CombatSkillType" />.
	/// </summary>
	public sbyte MergedSkillType = GetMergedSkillType(skillGroup, skillType);

	/// <summary>
	/// 资质增量
	/// </summary>
	public sbyte Bonus = bonus;

	/// <summary>
	/// 技能 ID.
	/// 只有当此加成为后天加成, 此值才有意义.
	/// </summary>
	public short SkillId = skillId;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 4;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)MergedSkillType;
		pData[1] = (byte)Bonus;
		((short*)pData)[1] = SkillId;
		return 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		MergedSkillType = (sbyte)(*pData);
		Bonus = (sbyte)pData[1];
		SkillId = ((short*)pData)[1];
		return 4;
	}

	/// <summary>
	/// 获取技能组以及技能类型
	/// </summary>
	/// <returns>技能组, 技能类型</returns>
	public (sbyte skillGroup, sbyte skillType) GetSkillGroupAndType()
	{
		if (MergedSkillType >= 16)
		{
			return (skillGroup: 1, skillType: (sbyte)(MergedSkillType - 16));
		}
		return (skillGroup: 0, skillType: MergedSkillType);
	}

	/// <summary>
	/// 获取融合技能类型
	/// </summary>
	/// <param name="skillGroup"></param>
	/// <param name="skillType"></param>
	/// <returns></returns>
	private static sbyte GetMergedSkillType(sbyte skillGroup, sbyte skillType)
	{
		return (sbyte)(skillGroup * 16 + skillType);
	}
}
