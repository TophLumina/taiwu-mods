using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 太吾身上的资源
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class TaiwuResourceDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int[] Resources;

	[SerializableGameDataField]
	public int[] ResourcesDelta;

	[SerializableGameDataField]
	public int Villager;

	[SerializableGameDataField]
	public int IdleVillager;

	[SerializableGameDataField]
	public int AreaId;

	[SerializableGameDataField]
	public int Debt;

	[SerializableGameDataField]
	public int Exp;

	[SerializableGameDataField]
	public int TaiwuPopulationTipsAdult;

	[SerializableGameDataField]
	public int TaiwuPopulationTipsAdultWorking;

	[SerializableGameDataField]
	public int TaiwuPopulationTipsAdultAssign;

	[SerializableGameDataField]
	public int TaiwuPopulationTipsChildWorking;

	[SerializableGameDataField]
	public int TaiwuPopulationTipsInJail;

	public int TaiwuPopulationTipsTotal => Villager;

	public int TaiwuPopulationTipsAdultIdle => IdleVillager;

	public int TaiwuPopulationTipsChild => Villager - TaiwuPopulationTipsAdult;

	public int TaiwuPopulationTipsChildIdle => TaiwuPopulationTipsChild - TaiwuPopulationTipsChildWorking;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 40;
		totalSize = ((Resources == null) ? (totalSize + 2) : (totalSize + (2 + 4 * Resources.Length)));
		totalSize = ((ResourcesDelta == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ResourcesDelta.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Resources != null)
		{
			int elementsCount = Resources.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(int*)pCurrData = Resources[i];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ResourcesDelta != null)
		{
			int elementsCount2 = ResourcesDelta.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(int*)pCurrData = ResourcesDelta[j];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = Villager;
		pCurrData += 4;
		*(int*)pCurrData = IdleVillager;
		pCurrData += 4;
		*(int*)pCurrData = AreaId;
		pCurrData += 4;
		*(int*)pCurrData = Debt;
		pCurrData += 4;
		*(int*)pCurrData = Exp;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuPopulationTipsAdult;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuPopulationTipsAdultWorking;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuPopulationTipsAdultAssign;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuPopulationTipsChildWorking;
		pCurrData += 4;
		*(int*)pCurrData = TaiwuPopulationTipsInJail;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Resources == null || Resources.Length != elementsCount)
			{
				Resources = new int[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				Resources[i] = *(int*)pCurrData;
				pCurrData += 4;
			}
		}
		else
		{
			Resources = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (ResourcesDelta == null || ResourcesDelta.Length != elementsCount2)
			{
				ResourcesDelta = new int[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ResourcesDelta[j] = *(int*)pCurrData;
				pCurrData += 4;
			}
		}
		else
		{
			ResourcesDelta = null;
		}
		Villager = *(int*)pCurrData;
		pCurrData += 4;
		IdleVillager = *(int*)pCurrData;
		pCurrData += 4;
		AreaId = *(int*)pCurrData;
		pCurrData += 4;
		Debt = *(int*)pCurrData;
		pCurrData += 4;
		Exp = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuPopulationTipsAdult = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuPopulationTipsAdultWorking = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuPopulationTipsAdultAssign = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuPopulationTipsChildWorking = *(int*)pCurrData;
		pCurrData += 4;
		TaiwuPopulationTipsInJail = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
