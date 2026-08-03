using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[SerializableGameData(IsExtensible = true)]
public class HunterSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort UsedCarrierAnimalAttackCount = 0;

		public const ushort AnimalCharIdToItemKey = 1;

		public const ushort AnimalItemKeyToGender = 2;

		public const ushort AnimalCharIdToAttraction = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "UsedCarrierAnimalAttackCount", "AnimalCharIdToItemKey", "AnimalItemKeyToGender", "AnimalCharIdToAttraction" };
	}

	/// <summary>
	/// 坐骑攻击消耗耐久值
	/// </summary>
	public const int AnimalAttackCostDurability = 30;

	/// <summary>
	/// 本月已使用坐骑攻击次数。用于猎户技能3，过月时重置
	/// </summary>
	[SerializableGameDataField]
	public sbyte UsedCarrierAnimalAttackCount;

	/// <summary>
	/// 升灵动物集合.
	/// 动物角色实例ID -&gt; 模板ID
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, ItemKey> AnimalCharIdToItemKey;

	/// <summary>
	/// 升灵时如果没性别，会随机性别并在这里记录，下次升灵还给同样的性别
	/// 道具Key -&gt; 性别
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<ItemKey, sbyte> AnimalItemKeyToGender;

	/// <summary>
	/// 升灵动物的魅力，随机生成并记录
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<ItemKey, short> AnimalCharIdToAttraction;

	/// <inheritdoc />
	public void Initialize()
	{
		UsedCarrierAnimalAttackCount = 0;
		AnimalCharIdToItemKey?.Clear();
		AnimalItemKeyToGender?.Clear();
		AnimalCharIdToAttraction?.Clear();
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		if (sourceData is ObsoleteHunterSkillsData skillsData)
		{
			UsedCarrierAnimalAttackCount = skillsData.UsedCarrierAnimalAttackCount;
		}
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public HunterSkillsData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public HunterSkillsData(HunterSkillsData other)
	{
		UsedCarrierAnimalAttackCount = other.UsedCarrierAnimalAttackCount;
		AnimalCharIdToItemKey = ((other.AnimalCharIdToItemKey == null) ? null : new Dictionary<int, ItemKey>(other.AnimalCharIdToItemKey));
		AnimalItemKeyToGender = ((other.AnimalItemKeyToGender == null) ? null : new Dictionary<ItemKey, sbyte>(other.AnimalItemKeyToGender));
		AnimalCharIdToAttraction = ((other.AnimalCharIdToAttraction == null) ? null : new Dictionary<ItemKey, short>(other.AnimalCharIdToAttraction));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(HunterSkillsData other)
	{
		UsedCarrierAnimalAttackCount = other.UsedCarrierAnimalAttackCount;
		AnimalCharIdToItemKey = ((other.AnimalCharIdToItemKey == null) ? null : new Dictionary<int, ItemKey>(other.AnimalCharIdToItemKey));
		AnimalItemKeyToGender = ((other.AnimalItemKeyToGender == null) ? null : new Dictionary<ItemKey, sbyte>(other.AnimalItemKeyToGender));
		AnimalCharIdToAttraction = ((other.AnimalCharIdToAttraction == null) ? null : new Dictionary<ItemKey, short>(other.AnimalCharIdToAttraction));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(AnimalCharIdToItemKey);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(AnimalItemKeyToGender);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(AnimalCharIdToAttraction);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 4;
		byte* num = pData + 2;
		*num = (byte)UsedCarrierAnimalAttackCount;
		byte* num2 = num + 1;
		byte* num3 = num2 + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(num2, ref AnimalCharIdToItemKey);
		byte* num4 = num3 + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(num3, ref AnimalItemKeyToGender);
		int totalSize = (int)(num4 + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(num4, ref AnimalCharIdToAttraction) - pData);
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			UsedCarrierAnimalAttackCount = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref AnimalCharIdToItemKey);
		}
		if (num > 2)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref AnimalItemKeyToGender);
		}
		if (num > 3)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref AnimalCharIdToAttraction);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
