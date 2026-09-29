using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

[Serializable]
public struct SkillQualificationBonus(sbyte skillGroup, sbyte skillType, sbyte bonus, short skillId = -1) : ISerializableGameData
{
	public sbyte MergedSkillType = GetMergedSkillType(skillGroup, skillType);

	public sbyte Bonus = bonus;

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

	public (sbyte skillGroup, sbyte skillType) GetSkillGroupAndType()
	{
		if (MergedSkillType >= 16)
		{
			return (skillGroup: 1, skillType: (sbyte)(MergedSkillType - 16));
		}
		return (skillGroup: 0, skillType: MergedSkillType);
	}

	private static sbyte GetMergedSkillType(sbyte skillGroup, sbyte skillType)
	{
		return (sbyte)(skillGroup * 16 + skillType);
	}
}
