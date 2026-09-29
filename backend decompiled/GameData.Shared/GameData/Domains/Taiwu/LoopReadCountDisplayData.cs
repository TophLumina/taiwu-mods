using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class LoopReadCountDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte LoopInCombatCount;

	[SerializableGameDataField]
	public sbyte LoopInLifeSkillCombatCount;

	[SerializableGameDataField]
	public sbyte ReadInLifeSkillCombatCount;

	[SerializableGameDataField]
	public sbyte ReadInCombatCount;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)LoopInCombatCount;
		byte* num = pData + 1;
		*num = (byte)LoopInLifeSkillCombatCount;
		byte* num2 = num + 1;
		*num2 = (byte)ReadInLifeSkillCombatCount;
		byte* num3 = num2 + 1;
		*num3 = (byte)ReadInCombatCount;
		int totalSize = (int)(num3 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		LoopInCombatCount = (sbyte)(*pCurrData);
		pCurrData++;
		LoopInLifeSkillCombatCount = (sbyte)(*pCurrData);
		pCurrData++;
		ReadInLifeSkillCombatCount = (sbyte)(*pCurrData);
		pCurrData++;
		ReadInCombatCount = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
