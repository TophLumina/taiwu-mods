using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Organization;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class SettlementLayeredTreasuries : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort SettlementTreasuries = 0;

		public const ushort AlertTime = 1;

		public const ushort ResupplyTotalValue = 2;

		public const ushort CurrentTotalValue = 3;

		public const ushort SupplyLevelAddOn = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "SettlementTreasuries", "AlertTime", "ResupplyTotalValue", "CurrentTotalValue", "SupplyLevelAddOn" };
	}

	[SerializableGameDataField]
	public SettlementTreasury[] SettlementTreasuries = InitTreasuries();

	[SerializableGameDataField]
	public byte AlertTime;

	[SerializableGameDataField]
	public int ResupplyTotalValue;

	[SerializableGameDataField]
	public int CurrentTotalValue;

	[SerializableGameDataField]
	public int SupplyLevelAddOn;

	private static SettlementTreasury[] InitTreasuries()
	{
		int count = Enum.GetValues(typeof(SettlementTreasuryLayers)).Length;
		SettlementTreasury[] treasuries = new SettlementTreasury[count];
		for (sbyte i = 0; i < count; i++)
		{
			treasuries[i] = new SettlementTreasury
			{
				LayerIndex = i
			};
		}
		return treasuries;
	}

	public SettlementTreasury GetTreasury(SettlementTreasuryLayers layer)
	{
		return layer switch
		{
			SettlementTreasuryLayers.Shallow => SettlementTreasuries[0], 
			SettlementTreasuryLayers.Mid => SettlementTreasuries[1], 
			SettlementTreasuryLayers.Deep => SettlementTreasuries[2], 
			_ => throw new ArgumentOutOfRangeException("layer", layer, null), 
		};
	}

	public SettlementTreasury GetTreasury(sbyte layerIndex)
	{
		return SettlementTreasuries[layerIndex];
	}

	public sbyte GetTreasuryResourceStatus()
	{
		if (ResupplyTotalValue == 0)
		{
			return 1;
		}
		int percent = CurrentTotalValue * 100 / ResupplyTotalValue;
		if (percent >= GlobalConfig.Instance.TreasuryStatusThreshold[0])
		{
			if (percent < GlobalConfig.Instance.TreasuryStatusThreshold[1])
			{
				return 1;
			}
			return 2;
		}
		return 0;
	}

	public bool TryRemoveGuard(int charId, out sbyte layerIndex)
	{
		layerIndex = -1;
		SettlementTreasury[] settlementTreasuries = SettlementTreasuries;
		foreach (SettlementTreasury treasury in settlementTreasuries)
		{
			if (treasury.GuardIds.Remove(charId).Item2)
			{
				layerIndex = treasury.LayerIndex;
				return true;
			}
		}
		return false;
	}

	public void GetGuardIds(HashSet<int> ids)
	{
		SettlementTreasury[] settlementTreasuries = SettlementTreasuries;
		for (int i = 0; i < settlementTreasuries.Length; i++)
		{
			foreach (int id in settlementTreasuries[i].GuardIds.GetCollection())
			{
				ids.Add(id);
			}
		}
	}

	public IEnumerable<int> GetGuardIds()
	{
		SettlementTreasury[] settlementTreasuries = SettlementTreasuries;
		foreach (SettlementTreasury treasury in settlementTreasuries)
		{
			foreach (int item in treasury.GuardIds.GetCollection())
			{
				yield return item;
			}
		}
	}

	public bool IsGuard(int id)
	{
		SettlementTreasury[] settlementTreasuries = SettlementTreasuries;
		for (int i = 0; i < settlementTreasuries.Length; i++)
		{
			if (settlementTreasuries[i].GuardIds.Contains(id))
			{
				return true;
			}
		}
		return false;
	}

	public byte GuardLevel(int id)
	{
		for (byte i = 3; i != 0; i--)
		{
			if (SettlementTreasuries[i - 1].GuardIds.Contains(id))
			{
				return i;
			}
		}
		return 0;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 15;
		if (SettlementTreasuries != null)
		{
			totalSize += 2;
			int elementsCount = SettlementTreasuries.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				SettlementTreasury element = SettlementTreasuries[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
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
		*(short*)pCurrData = 5;
		pCurrData += 2;
		if (SettlementTreasuries != null)
		{
			int elementsCount = SettlementTreasuries.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				SettlementTreasury element = SettlementTreasuries[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
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
		*pCurrData = AlertTime;
		pCurrData++;
		*(int*)pCurrData = ResupplyTotalValue;
		pCurrData += 4;
		*(int*)pCurrData = CurrentTotalValue;
		pCurrData += 4;
		*(int*)pCurrData = SupplyLevelAddOn;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (SettlementTreasuries == null || SettlementTreasuries.Length != elementsCount)
				{
					SettlementTreasuries = new SettlementTreasury[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num > 0)
					{
						SettlementTreasury element = SettlementTreasuries[i] ?? new SettlementTreasury();
						pCurrData += element.Deserialize(pCurrData);
						SettlementTreasuries[i] = element;
					}
					else
					{
						SettlementTreasuries[i] = null;
					}
				}
			}
			else
			{
				SettlementTreasuries = null;
			}
		}
		if (fieldCount > 1)
		{
			AlertTime = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			ResupplyTotalValue = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			CurrentTotalValue = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 4)
		{
			SupplyLevelAddOn = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
