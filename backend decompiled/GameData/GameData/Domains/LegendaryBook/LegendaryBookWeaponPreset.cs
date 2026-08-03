using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.LegendaryBook;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true)]
public class LegendaryBookWeaponPreset : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort WeaponPresets = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "WeaponPresets" };
	}

	[SerializableGameDataField]
	public ItemKey[] WeaponPresets;

	public LegendaryBookWeaponPreset()
	{
		WeaponPresets = new ItemKey[9];
		for (int i = 0; i < WeaponPresets.Length; i++)
		{
			WeaponPresets[i] = ItemKey.Invalid;
		}
	}

	public LegendaryBookWeaponPreset(LegendaryBookWeaponPreset other)
	{
		ItemKey[] item = other.WeaponPresets;
		int elementsCount = item.Length;
		WeaponPresets = new ItemKey[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			WeaponPresets[i] = item[i];
		}
	}

	public void Assign(LegendaryBookWeaponPreset other)
	{
		ItemKey[] item = other.WeaponPresets;
		int elementsCount = item.Length;
		WeaponPresets = new ItemKey[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			WeaponPresets[i] = item[i];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((WeaponPresets == null) ? (totalSize + 2) : (totalSize + (2 + 8 * WeaponPresets.Length)));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 1;
		pCurrData += 2;
		if (WeaponPresets != null)
		{
			int elementsCount = WeaponPresets.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += WeaponPresets[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
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
				if (WeaponPresets == null || WeaponPresets.Length != elementsCount)
				{
					WeaponPresets = new ItemKey[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ItemKey element = default(ItemKey);
					pCurrData += element.Deserialize(pCurrData);
					WeaponPresets[i] = element;
				}
			}
			else
			{
				WeaponPresets = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
