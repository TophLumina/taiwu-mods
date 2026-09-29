using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC.SmarterChicken;

[SerializableGameData(IsExtensible = true)]
public class CombatChickenPresetItem : PresetItemBase<CombatChickenPresetItem>
{
	private static class FieldIds
	{
		public const ushort EnabledChickens = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "EnabledChickens" };
	}

	[SerializableGameDataField]
	public List<short> EnabledChickens;

	public override void Clear()
	{
		EnabledChickens?.Clear();
	}

	public override CombatChickenPresetItem Clone()
	{
		return new CombatChickenPresetItem(this);
	}

	public CombatChickenPresetItem()
	{
	}

	public CombatChickenPresetItem(CombatChickenPresetItem other)
	{
		EnabledChickens = ((other.EnabledChickens == null) ? null : new List<short>(other.EnabledChickens));
	}

	public void Assign(CombatChickenPresetItem other)
	{
		EnabledChickens = ((other.EnabledChickens == null) ? null : new List<short>(other.EnabledChickens));
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((EnabledChickens == null) ? (totalSize + 2) : (totalSize + (2 + 2 * EnabledChickens.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 1;
		pCurrData += 2;
		if (EnabledChickens != null)
		{
			int elementsCount = EnabledChickens.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = EnabledChickens[i];
			}
			pCurrData += 2 * elementsCount;
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

	public unsafe override int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (EnabledChickens == null)
				{
					EnabledChickens = new List<short>(elementsCount);
				}
				else
				{
					EnabledChickens.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					EnabledChickens.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				EnabledChickens?.Clear();
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
