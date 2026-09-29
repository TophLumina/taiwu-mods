using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class SpreadingInfluenceDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	[SerializableGameDataField]
	public int SafetyOrCultureChange;

	[SerializableGameDataField]
	public bool IsIncreaseSafetyOrCulture;

	[SerializableGameDataField]
	public int AuthorityGain;

	[SerializableGameDataField]
	public int GatherOrBattleEnemyProbability;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 13;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = SafetyOrCultureChange;
		byte* num = pData + 4;
		*num = (IsIncreaseSafetyOrCulture ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*(int*)num2 = AuthorityGain;
		byte* num3 = num2 + 4;
		*(int*)num3 = GatherOrBattleEnemyProbability;
		int totalSize = (int)(num3 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		SafetyOrCultureChange = *(int*)pCurrData;
		pCurrData += 4;
		IsIncreaseSafetyOrCulture = *pCurrData != 0;
		pCurrData++;
		AuthorityGain = *(int*)pCurrData;
		pCurrData += 4;
		GatherOrBattleEnemyProbability = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
