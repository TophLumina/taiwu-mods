using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Organization.Display;

[SerializableGameData(NoCopyConstructors = true)]
public struct SettlementTreasuryDisplayData : ISerializableGameData
{
	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public SettlementTreasury SettlementTreasury;

	[SerializableGameDataField]
	public int SupplyLevel;

	[SerializableGameDataField]
	public int DebtOrSupport;

	[SerializableGameDataField]
	public CharacterDisplayData[] GuardianCharacterDisplayDataLow;

	[SerializableGameDataField]
	public CharacterDisplayData[] GuardianCharacterDisplayDataMid;

	[SerializableGameDataField]
	public CharacterDisplayData[] GuardianCharacterDisplayDataHigh;

	[SerializableGameDataField]
	public int OrgTemplateId;

	[SerializableGameDataField]
	public sbyte SectStoryEnding;

	[SerializableGameDataField]
	public bool MartialArtTournamentResult;

	[SerializableGameDataField]
	public Inventory SupplyItems;

	[SerializableGameDataField]
	public sbyte[] SupplyCounts;

	[SerializableGameDataField]
	public byte AlertTime;

	[SerializableGameDataField]
	public byte InfluenceRefreshTime;

	[SerializableGameDataField]
	public sbyte ResourceStatus;

	[SerializableGameDataField]
	public SettlementNameRelatedData SettlementNameRelatedData;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 21;
		totalSize = ((SettlementTreasury == null) ? (totalSize + 4) : (totalSize + (4 + SettlementTreasury.GetSerializedSize())));
		if (GuardianCharacterDisplayDataLow != null)
		{
			totalSize += 2;
			int elementsCount = GuardianCharacterDisplayDataLow.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterDisplayData element = GuardianCharacterDisplayDataLow[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (GuardianCharacterDisplayDataMid != null)
		{
			totalSize += 2;
			int elementsCount2 = GuardianCharacterDisplayDataMid.Length;
			for (int j = 0; j < elementsCount2; j++)
			{
				CharacterDisplayData element2 = GuardianCharacterDisplayDataMid[j];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + element2.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (GuardianCharacterDisplayDataHigh != null)
		{
			totalSize += 2;
			int elementsCount3 = GuardianCharacterDisplayDataHigh.Length;
			for (int k = 0; k < elementsCount3; k++)
			{
				CharacterDisplayData element3 = GuardianCharacterDisplayDataHigh[k];
				totalSize = ((element3 == null) ? (totalSize + 2) : (totalSize + (2 + element3.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((SupplyItems == null) ? (totalSize + 2) : (totalSize + (2 + SupplyItems.GetSerializedSize())));
		totalSize = ((SupplyCounts == null) ? (totalSize + 2) : (totalSize + (2 + SupplyCounts.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (SettlementTreasury != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 4;
			int fieldSize = SettlementTreasury.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= int.MaxValue);
			*(int*)intPtr = fieldSize;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*(int*)pCurrData = SupplyLevel;
		pCurrData += 4;
		*(int*)pCurrData = DebtOrSupport;
		pCurrData += 4;
		if (GuardianCharacterDisplayDataLow != null)
		{
			int elementsCount = GuardianCharacterDisplayDataLow.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterDisplayData element = GuardianCharacterDisplayDataLow[i];
				if (element != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr2 = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GuardianCharacterDisplayDataMid != null)
		{
			int elementsCount2 = GuardianCharacterDisplayDataMid.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				CharacterDisplayData element2 = GuardianCharacterDisplayDataMid[j];
				if (element2 != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int subDataSize2 = element2.Serialize(pCurrData);
					pCurrData += subDataSize2;
					Tester.Assert(subDataSize2 <= 65535);
					*(ushort*)intPtr3 = (ushort)subDataSize2;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GuardianCharacterDisplayDataHigh != null)
		{
			int elementsCount3 = GuardianCharacterDisplayDataHigh.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				CharacterDisplayData element3 = GuardianCharacterDisplayDataHigh[k];
				if (element3 != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int subDataSize3 = element3.Serialize(pCurrData);
					pCurrData += subDataSize3;
					Tester.Assert(subDataSize3 <= 65535);
					*(ushort*)intPtr4 = (ushort)subDataSize3;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = OrgTemplateId;
		pCurrData += 4;
		*pCurrData = (byte)SectStoryEnding;
		pCurrData++;
		*pCurrData = (MartialArtTournamentResult ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (SupplyItems != null)
		{
			byte* intPtr5 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = SupplyItems.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr5 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SupplyCounts != null)
		{
			int elementsCount4 = SupplyCounts.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData[l] = (byte)SupplyCounts[l];
			}
			pCurrData += elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = AlertTime;
		pCurrData++;
		*pCurrData = InfluenceRefreshTime;
		pCurrData++;
		*pCurrData = (byte)ResourceStatus;
		pCurrData++;
		pCurrData += SettlementNameRelatedData.Serialize(pCurrData);
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
		int num = *(int*)pCurrData;
		pCurrData += 4;
		if (num > 0)
		{
			if (SettlementTreasury == null)
			{
				SettlementTreasury = new SettlementTreasury();
			}
			pCurrData += SettlementTreasury.Deserialize(pCurrData);
		}
		else
		{
			SettlementTreasury = null;
		}
		SupplyLevel = *(int*)pCurrData;
		pCurrData += 4;
		DebtOrSupport = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (GuardianCharacterDisplayDataLow == null || GuardianCharacterDisplayDataLow.Length != elementsCount)
			{
				GuardianCharacterDisplayDataLow = new CharacterDisplayData[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num2 > 0)
				{
					CharacterDisplayData element = GuardianCharacterDisplayDataLow[i] ?? new CharacterDisplayData();
					pCurrData += element.Deserialize(pCurrData);
					GuardianCharacterDisplayDataLow[i] = element;
				}
				else
				{
					GuardianCharacterDisplayDataLow[i] = null;
				}
			}
		}
		else
		{
			GuardianCharacterDisplayDataLow = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (GuardianCharacterDisplayDataMid == null || GuardianCharacterDisplayDataMid.Length != elementsCount2)
			{
				GuardianCharacterDisplayDataMid = new CharacterDisplayData[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num3 > 0)
				{
					CharacterDisplayData element2 = GuardianCharacterDisplayDataMid[j] ?? new CharacterDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
					GuardianCharacterDisplayDataMid[j] = element2;
				}
				else
				{
					GuardianCharacterDisplayDataMid[j] = null;
				}
			}
		}
		else
		{
			GuardianCharacterDisplayDataMid = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (GuardianCharacterDisplayDataHigh == null || GuardianCharacterDisplayDataHigh.Length != elementsCount3)
			{
				GuardianCharacterDisplayDataHigh = new CharacterDisplayData[elementsCount3];
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num4 = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num4 > 0)
				{
					CharacterDisplayData element3 = GuardianCharacterDisplayDataHigh[k] ?? new CharacterDisplayData();
					pCurrData += element3.Deserialize(pCurrData);
					GuardianCharacterDisplayDataHigh[k] = element3;
				}
				else
				{
					GuardianCharacterDisplayDataHigh[k] = null;
				}
			}
		}
		else
		{
			GuardianCharacterDisplayDataHigh = null;
		}
		OrgTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		SectStoryEnding = (sbyte)(*pCurrData);
		pCurrData++;
		MartialArtTournamentResult = *pCurrData != 0;
		pCurrData++;
		ushort num5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num5 > 0)
		{
			if (SupplyItems == null)
			{
				SupplyItems = new Inventory();
			}
			pCurrData += SupplyItems.Deserialize(pCurrData);
		}
		else
		{
			SupplyItems = null;
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (SupplyCounts == null || SupplyCounts.Length != elementsCount4)
			{
				SupplyCounts = new sbyte[elementsCount4];
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				SupplyCounts[l] = (sbyte)pCurrData[l];
			}
			pCurrData += (int)elementsCount4;
		}
		else
		{
			SupplyCounts = null;
		}
		AlertTime = *pCurrData;
		pCurrData++;
		InfluenceRefreshTime = *pCurrData;
		pCurrData++;
		ResourceStatus = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += SettlementNameRelatedData.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
