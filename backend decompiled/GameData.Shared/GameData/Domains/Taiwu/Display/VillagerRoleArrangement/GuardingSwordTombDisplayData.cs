using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

/// <summary>
/// 看守剑冢
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class GuardingSwordTombDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	/// <summary>
	/// 正在看守哪个剑冢
	/// </summary>
	[SerializableGameDataField]
	public sbyte SwordTombId;

	/// <summary>
	/// 剑冢中的化身状态，0:平静如常;1:隐有异动;2:破冢而出
	/// </summary>
	[SerializableGameDataField]
	public sbyte EscapeState;

	/// <summary>
	/// 见闻收集成功率
	/// </summary>
	[SerializableGameDataField]
	public int InformationGatheringSuccessRate;

	/// <summary>
	/// 受伤几率
	/// </summary>
	[SerializableGameDataField]
	public int InjuryProbability;

	/// <summary>
	/// 特性几率 A
	/// <see cref="F:Config.VillagerRoleFormula.DefKey.SwordTombKeeperWorkFeatureOddWhenInformationCollect" />
	/// </summary>
	[SerializableGameDataField]
	public int FeatureGainRateA;

	/// <summary>
	/// 特性几率 B
	/// <see cref="F:Config.VillagerRoleFormula.DefKey.SwordTombKeeperWorkFeatureOddWhenBeAttacked" />
	/// </summary>
	[SerializableGameDataField]
	public int FeatureGainRateB;

	/// <summary>
	/// 降低入魔值变化
	/// </summary>
	[SerializableGameDataField]
	public int InfectionDecreaseRate;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 22;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)SwordTombId;
		byte* num = pData + 1;
		*num = (byte)EscapeState;
		byte* num2 = num + 1;
		*(int*)num2 = InformationGatheringSuccessRate;
		byte* num3 = num2 + 4;
		*(int*)num3 = InjuryProbability;
		byte* num4 = num3 + 4;
		*(int*)num4 = FeatureGainRateA;
		byte* num5 = num4 + 4;
		*(int*)num5 = FeatureGainRateB;
		byte* num6 = num5 + 4;
		*(int*)num6 = InfectionDecreaseRate;
		int totalSize = (int)(num6 + 4 - pData);
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
		SwordTombId = (sbyte)(*pCurrData);
		pCurrData++;
		EscapeState = (sbyte)(*pCurrData);
		pCurrData++;
		InformationGatheringSuccessRate = *(int*)pCurrData;
		pCurrData += 4;
		InjuryProbability = *(int*)pCurrData;
		pCurrData += 4;
		FeatureGainRateA = *(int*)pCurrData;
		pCurrData += 4;
		FeatureGainRateB = *(int*)pCurrData;
		pCurrData += 4;
		InfectionDecreaseRate = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
