using System.Collections.Generic;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.DLC.TaiwuAsXiangshu;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForArchive = true, NoCopyConstructors = true)]
public class TaiwuAsXiangshuTowerDisplayData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort TwelveImmortals = 0;

		public const ushort TamedTwelveImmortalsCount = 1;

		public const ushort ThreeRealmsPowerCount = 2;

		public const ushort XiangshuDemonHeartObtained = 3;

		public const ushort ThreeRealmsPowers = 4;

		public const ushort TiandiDefeated = 5;

		public const ushort PendingPerformances = 6;

		public const ushort FinalLayerEntered = 7;

		public const ushort TiandiDefeatPerformancePlayed = 8;

		public const ushort DemonHeartObtainedPerformancePlayed = 9;

		public const ushort PendingThreeRealmsPowerPerformances = 10;

		public const ushort AvailableSwordFragments = 11;

		public const ushort Count = 12;

		public static readonly string[] FieldId2FieldName = new string[12]
		{
			"TwelveImmortals", "TamedTwelveImmortalsCount", "ThreeRealmsPowerCount", "XiangshuDemonHeartObtained", "ThreeRealmsPowers", "TiandiDefeated", "PendingPerformances", "FinalLayerEntered", "TiandiDefeatPerformancePlayed", "DemonHeartObtainedPerformancePlayed",
			"PendingThreeRealmsPowerPerformances", "AvailableSwordFragments"
		};
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public List<TaiwuAsXiangshuTowerTwelveImmortalDisplayData> TwelveImmortals = new List<TaiwuAsXiangshuTowerTwelveImmortalDisplayData>();

	[SerializableGameDataField(FieldIndex = 1)]
	public int TamedTwelveImmortalsCount;

	[SerializableGameDataField(FieldIndex = 2)]
	public int ThreeRealmsPowerCount;

	[SerializableGameDataField(FieldIndex = 3)]
	public bool XiangshuDemonHeartObtained;

	[SerializableGameDataField(FieldIndex = 4)]
	public List<TaiwuAsXiangshuTowerThreeRealmsPowerDisplayData> ThreeRealmsPowers = new List<TaiwuAsXiangshuTowerThreeRealmsPowerDisplayData>();

	[SerializableGameDataField(FieldIndex = 5)]
	public bool TiandiDefeated;

	[SerializableGameDataField(FieldIndex = 6)]
	public List<TaiwuAsXiangshuTowerPerformanceEntryDisplayData> PendingPerformances = new List<TaiwuAsXiangshuTowerPerformanceEntryDisplayData>();

	[SerializableGameDataField(FieldIndex = 7)]
	public bool FinalLayerEntered;

	[SerializableGameDataField(FieldIndex = 8)]
	public bool TiandiDefeatPerformancePlayed;

	[SerializableGameDataField(FieldIndex = 9)]
	public bool DemonHeartObtainedPerformancePlayed;

	[SerializableGameDataField(FieldIndex = 10)]
	public List<TaiwuAsXiangshuTowerPerformanceEntryDisplayData> PendingThreeRealmsPowerPerformances = new List<TaiwuAsXiangshuTowerPerformanceEntryDisplayData>();

	[SerializableGameDataField(FieldIndex = 11)]
	public List<ItemDisplayData> AvailableSwordFragments = new List<ItemDisplayData>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 15;
		if (TwelveImmortals != null)
		{
			totalSize += 2;
			for (int i = 0; i < TwelveImmortals.Count; i++)
			{
				totalSize = ((TwelveImmortals[i] == null) ? (totalSize + 2) : (totalSize + (2 + TwelveImmortals[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (ThreeRealmsPowers != null)
		{
			totalSize += 2;
			for (int j = 0; j < ThreeRealmsPowers.Count; j++)
			{
				totalSize = ((ThreeRealmsPowers[j] == null) ? (totalSize + 2) : (totalSize + (2 + ThreeRealmsPowers[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (PendingPerformances != null)
		{
			totalSize += 2;
			for (int k = 0; k < PendingPerformances.Count; k++)
			{
				totalSize = ((PendingPerformances[k] == null) ? (totalSize + 2) : (totalSize + (2 + PendingPerformances[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (PendingThreeRealmsPowerPerformances != null)
		{
			totalSize += 2;
			for (int l = 0; l < PendingThreeRealmsPowerPerformances.Count; l++)
			{
				totalSize = ((PendingThreeRealmsPowerPerformances[l] == null) ? (totalSize + 2) : (totalSize + (2 + PendingThreeRealmsPowerPerformances[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (AvailableSwordFragments != null)
		{
			totalSize += 2;
			for (int m = 0; m < AvailableSwordFragments.Count; m++)
			{
				totalSize = ((AvailableSwordFragments[m] == null) ? (totalSize + 2) : (totalSize + (2 + AvailableSwordFragments[m].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 12;
		pCurrData += 2;
		if (TwelveImmortals != null)
		{
			int elementsCount = TwelveImmortals.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (TwelveImmortals[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = TwelveImmortals[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
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
		*(int*)pCurrData = TamedTwelveImmortalsCount;
		pCurrData += 4;
		*(int*)pCurrData = ThreeRealmsPowerCount;
		pCurrData += 4;
		*pCurrData = (XiangshuDemonHeartObtained ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (ThreeRealmsPowers != null)
		{
			int elementsCount2 = ThreeRealmsPowers.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (ThreeRealmsPowers[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = ThreeRealmsPowers[j].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize2;
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
		*pCurrData = (TiandiDefeated ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (PendingPerformances != null)
		{
			int elementsCount3 = PendingPerformances.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (PendingPerformances[k] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = PendingPerformances[k].Serialize(pCurrData);
					pCurrData += fieldSize3;
					Tester.Assert(fieldSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)fieldSize3;
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
		*pCurrData = (FinalLayerEntered ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (TiandiDefeatPerformancePlayed ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (DemonHeartObtainedPerformancePlayed ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (PendingThreeRealmsPowerPerformances != null)
		{
			int elementsCount4 = PendingThreeRealmsPowerPerformances.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (PendingThreeRealmsPowerPerformances[l] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int fieldSize4 = PendingThreeRealmsPowerPerformances[l].Serialize(pCurrData);
					pCurrData += fieldSize4;
					Tester.Assert(fieldSize4 <= 65535);
					*(ushort*)intPtr4 = (ushort)fieldSize4;
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
		if (AvailableSwordFragments != null)
		{
			int elementsCount5 = AvailableSwordFragments.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				if (AvailableSwordFragments[m] != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 2;
					int fieldSize5 = AvailableSwordFragments[m].Serialize(pCurrData);
					pCurrData += fieldSize5;
					Tester.Assert(fieldSize5 <= 65535);
					*(ushort*)intPtr5 = (ushort)fieldSize5;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (TwelveImmortals == null)
				{
					TwelveImmortals = new List<TaiwuAsXiangshuTowerTwelveImmortalDisplayData>();
				}
				else
				{
					TwelveImmortals.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					TaiwuAsXiangshuTowerTwelveImmortalDisplayData element;
					if (num > 0)
					{
						element = new TaiwuAsXiangshuTowerTwelveImmortalDisplayData();
						pCurrData += element.Deserialize(pCurrData);
					}
					else
					{
						element = null;
					}
					TwelveImmortals.Add(element);
				}
			}
			else
			{
				TwelveImmortals?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			TamedTwelveImmortalsCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			ThreeRealmsPowerCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			XiangshuDemonHeartObtained = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 4)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (ThreeRealmsPowers == null)
				{
					ThreeRealmsPowers = new List<TaiwuAsXiangshuTowerThreeRealmsPowerDisplayData>();
				}
				else
				{
					ThreeRealmsPowers.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					ushort num2 = *(ushort*)pCurrData;
					pCurrData += 2;
					TaiwuAsXiangshuTowerThreeRealmsPowerDisplayData element2;
					if (num2 > 0)
					{
						element2 = new TaiwuAsXiangshuTowerThreeRealmsPowerDisplayData();
						pCurrData += element2.Deserialize(pCurrData);
					}
					else
					{
						element2 = null;
					}
					ThreeRealmsPowers.Add(element2);
				}
			}
			else
			{
				ThreeRealmsPowers?.Clear();
			}
		}
		if (fieldCount > 5)
		{
			TiandiDefeated = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 6)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (PendingPerformances == null)
				{
					PendingPerformances = new List<TaiwuAsXiangshuTowerPerformanceEntryDisplayData>();
				}
				else
				{
					PendingPerformances.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					ushort num3 = *(ushort*)pCurrData;
					pCurrData += 2;
					TaiwuAsXiangshuTowerPerformanceEntryDisplayData element3;
					if (num3 > 0)
					{
						element3 = new TaiwuAsXiangshuTowerPerformanceEntryDisplayData();
						pCurrData += element3.Deserialize(pCurrData);
					}
					else
					{
						element3 = null;
					}
					PendingPerformances.Add(element3);
				}
			}
			else
			{
				PendingPerformances?.Clear();
			}
		}
		if (fieldCount > 7)
		{
			FinalLayerEntered = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 8)
		{
			TiandiDefeatPerformancePlayed = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 9)
		{
			DemonHeartObtainedPerformancePlayed = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 10)
		{
			ushort elementsCount4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount4 > 0)
			{
				if (PendingThreeRealmsPowerPerformances == null)
				{
					PendingThreeRealmsPowerPerformances = new List<TaiwuAsXiangshuTowerPerformanceEntryDisplayData>();
				}
				else
				{
					PendingThreeRealmsPowerPerformances.Clear();
				}
				for (int l = 0; l < elementsCount4; l++)
				{
					ushort num4 = *(ushort*)pCurrData;
					pCurrData += 2;
					TaiwuAsXiangshuTowerPerformanceEntryDisplayData element4;
					if (num4 > 0)
					{
						element4 = new TaiwuAsXiangshuTowerPerformanceEntryDisplayData();
						pCurrData += element4.Deserialize(pCurrData);
					}
					else
					{
						element4 = null;
					}
					PendingThreeRealmsPowerPerformances.Add(element4);
				}
			}
			else
			{
				PendingThreeRealmsPowerPerformances?.Clear();
			}
		}
		if (fieldCount > 11)
		{
			ushort elementsCount5 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount5 > 0)
			{
				if (AvailableSwordFragments == null)
				{
					AvailableSwordFragments = new List<ItemDisplayData>();
				}
				else
				{
					AvailableSwordFragments.Clear();
				}
				for (int m = 0; m < elementsCount5; m++)
				{
					ushort num5 = *(ushort*)pCurrData;
					pCurrData += 2;
					ItemDisplayData element5;
					if (num5 > 0)
					{
						element5 = new ItemDisplayData();
						pCurrData += element5.Deserialize(pCurrData);
					}
					else
					{
						element5 = null;
					}
					AvailableSwordFragments.Add(element5);
				}
			}
			else
			{
				AvailableSwordFragments?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
