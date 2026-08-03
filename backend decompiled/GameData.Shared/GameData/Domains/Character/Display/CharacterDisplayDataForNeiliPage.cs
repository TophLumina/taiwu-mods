using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class CharacterDisplayDataForNeiliPage : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public sbyte ConsummateLevel;

	[SerializableGameDataField]
	public int CurrNeili;

	[SerializableGameDataField]
	public int MaxNeili;

	[SerializableGameDataField]
	public sbyte NeiliType;

	[SerializableGameDataField]
	public NeiliProportionOfFiveElements NeiliPercent;

	[SerializableGameDataField]
	public sbyte TransferNeiliSrcType;

	[SerializableGameDataField]
	public sbyte TransferNeiliDstType;

	[SerializableGameDataField]
	public sbyte TransferNeiliAmount;

	[SerializableGameDataField]
	public NeiliAllocation BaseNeiliAllocation;

	[SerializableGameDataField]
	public NeiliAllocation NeiliAllocation;

	[SerializableGameDataField]
	public NeiliAllocation CombatNeiliAllocation;

	[SerializableGameDataField]
	public NeiliAllocation NeiliAllocationEffects;

	[SerializableGameDataField]
	public List<short> FeatureIds;

	[SerializableGameDataField]
	public bool NeedShowConsummateParticle;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 18;
		totalSize += NeiliPercent.GetSerializedSize();
		totalSize += BaseNeiliAllocation.GetSerializedSize();
		totalSize += NeiliAllocation.GetSerializedSize();
		totalSize += CombatNeiliAllocation.GetSerializedSize();
		totalSize += NeiliAllocationEffects.GetSerializedSize();
		totalSize = ((FeatureIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * FeatureIds.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*pCurrData = (byte)ConsummateLevel;
		pCurrData++;
		*(int*)pCurrData = CurrNeili;
		pCurrData += 4;
		*(int*)pCurrData = MaxNeili;
		pCurrData += 4;
		*pCurrData = (byte)NeiliType;
		pCurrData++;
		pCurrData += NeiliPercent.Serialize(pCurrData);
		*pCurrData = (byte)TransferNeiliSrcType;
		pCurrData++;
		*pCurrData = (byte)TransferNeiliDstType;
		pCurrData++;
		*pCurrData = (byte)TransferNeiliAmount;
		pCurrData++;
		pCurrData += BaseNeiliAllocation.Serialize(pCurrData);
		pCurrData += NeiliAllocation.Serialize(pCurrData);
		pCurrData += CombatNeiliAllocation.Serialize(pCurrData);
		pCurrData += NeiliAllocationEffects.Serialize(pCurrData);
		if (FeatureIds != null)
		{
			int elementsCount = FeatureIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = FeatureIds[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (NeedShowConsummateParticle ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		ConsummateLevel = (sbyte)(*pCurrData);
		pCurrData++;
		CurrNeili = *(int*)pCurrData;
		pCurrData += 4;
		MaxNeili = *(int*)pCurrData;
		pCurrData += 4;
		NeiliType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += NeiliPercent.Deserialize(pCurrData);
		TransferNeiliSrcType = (sbyte)(*pCurrData);
		pCurrData++;
		TransferNeiliDstType = (sbyte)(*pCurrData);
		pCurrData++;
		TransferNeiliAmount = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += BaseNeiliAllocation.Deserialize(pCurrData);
		pCurrData += NeiliAllocation.Deserialize(pCurrData);
		pCurrData += CombatNeiliAllocation.Deserialize(pCurrData);
		pCurrData += NeiliAllocationEffects.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (FeatureIds == null)
			{
				FeatureIds = new List<short>();
			}
			else
			{
				FeatureIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				FeatureIds.Add(element);
			}
		}
		else
		{
			FeatureIds?.Clear();
		}
		NeedShowConsummateParticle = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
