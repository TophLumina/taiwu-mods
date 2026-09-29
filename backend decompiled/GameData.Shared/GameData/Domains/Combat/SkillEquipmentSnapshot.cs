using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public struct SkillEquipmentSnapshot : ISerializableGameData
{
	[SerializableGameDataField]
	public ItemKey WeaponOrShoesKey = ItemKey.Invalid;

	[SerializableGameDataField]
	public short WeaponOrShoesStartDurability = 0;

	[SerializableGameDataField]
	public short WeaponOrShoesEndDurability = 0;

	public SkillEquipmentSnapshot()
	{
	}

	public void Clear()
	{
		WeaponOrShoesKey = ItemKey.Invalid;
		WeaponOrShoesStartDurability = 0;
		WeaponOrShoesEndDurability = 0;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += WeaponOrShoesKey.Serialize(pCurrData);
		*(short*)pCurrData = WeaponOrShoesStartDurability;
		pCurrData += 2;
		*(short*)pCurrData = WeaponOrShoesEndDurability;
		pCurrData += 2;
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
		pCurrData += WeaponOrShoesKey.Deserialize(pCurrData);
		WeaponOrShoesStartDurability = *(short*)pCurrData;
		pCurrData += 2;
		WeaponOrShoesEndDurability = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
