using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

/// <summary>
/// 传播影响
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class SpreadingInfluenceDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	/// <summary>
	/// 文化或安定变化量
	/// </summary>
	[SerializableGameDataField]
	public int SafetyOrCultureChange;

	/// <summary>
	/// 工作设置是需要升高还是降低文化或安定
	/// </summary>
	[SerializableGameDataField]
	public bool IsIncreaseSafetyOrCulture;

	/// <summary>
	/// 威望获取量
	/// </summary>
	[SerializableGameDataField]
	public int AuthorityGain;

	/// <summary>
	/// 讨伐外道或集结外道的概率。文人的工作中不用填此数据，护冢独有。
	/// </summary>
	[SerializableGameDataField]
	public int GatherOrBattleEnemyProbability;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 13;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
