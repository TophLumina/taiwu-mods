using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public struct SkillIndexAndHitData : ISerializableGameData
{
	[SerializableGameDataField]
	public int SkillIndex;

	[SerializableGameDataField]
	public int HitOdds;

	[SerializableGameDataField]
	public bool Hit;

	public static SkillIndexAndHitData Invalid => new SkillIndexAndHitData(-1, 0, hit: false);

	public SkillIndexAndHitData(int skillIndex, int hitOdds, bool hit)
	{
		SkillIndex = skillIndex;
		HitOdds = hitOdds;
		Hit = hit;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 9;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = SkillIndex;
		byte* num = pData + 4;
		*(int*)num = HitOdds;
		byte* num2 = num + 4;
		*num2 = (Hit ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num2 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		SkillIndex = *(int*)pCurrData;
		pCurrData += 4;
		HitOdds = *(int*)pCurrData;
		pCurrData += 4;
		Hit = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
