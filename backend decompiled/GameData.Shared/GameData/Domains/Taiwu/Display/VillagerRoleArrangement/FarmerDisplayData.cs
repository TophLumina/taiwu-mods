using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display.VillagerRoleArrangement;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class FarmerDisplayData : IVillagerRoleArrangementDisplayData, ISerializableGameData
{
	[SerializableGameDataField]
	public int CollectResourceActionCount;

	[SerializableGameDataField]
	public int MigrateResourceSuccessRate;

	[SerializableGameDataField]
	public int MigrateResourceBaseSuccessRate;

	[SerializableGameDataField]
	public int MigrateResourceSuccessRateBonus;

	[SerializableGameDataField]
	public int MigrateResourceSuccessRateBuildingBonus;

	[SerializableGameDataField]
	public int UpgradeBuildingCoreRate;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 24;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = CollectResourceActionCount;
		byte* num = pData + 4;
		*(int*)num = MigrateResourceSuccessRate;
		byte* num2 = num + 4;
		*(int*)num2 = MigrateResourceBaseSuccessRate;
		byte* num3 = num2 + 4;
		*(int*)num3 = MigrateResourceSuccessRateBonus;
		byte* num4 = num3 + 4;
		*(int*)num4 = MigrateResourceSuccessRateBuildingBonus;
		byte* num5 = num4 + 4;
		*(int*)num5 = UpgradeBuildingCoreRate;
		int totalSize = (int)(num5 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		CollectResourceActionCount = *(int*)pCurrData;
		pCurrData += 4;
		MigrateResourceSuccessRate = *(int*)pCurrData;
		pCurrData += 4;
		MigrateResourceBaseSuccessRate = *(int*)pCurrData;
		pCurrData += 4;
		MigrateResourceSuccessRateBonus = *(int*)pCurrData;
		pCurrData += 4;
		MigrateResourceSuccessRateBuildingBonus = *(int*)pCurrData;
		pCurrData += 4;
		UpgradeBuildingCoreRate = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
