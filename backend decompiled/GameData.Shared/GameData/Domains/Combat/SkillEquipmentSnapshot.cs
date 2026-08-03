using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 用于演出的摧破功法装备数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct SkillEquipmentSnapshot : ISerializableGameData
{
	/// <summary>
	/// 兵器道具键
	/// </summary>
	[SerializableGameDataField]
	public ItemKey WeaponOrShoesKey = ItemKey.Invalid;

	/// <summary>
	/// 兵器初始耐久
	/// </summary>
	[SerializableGameDataField]
	public short WeaponOrShoesStartDurability = 0;

	/// <summary>
	/// 兵器结束耐久
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
