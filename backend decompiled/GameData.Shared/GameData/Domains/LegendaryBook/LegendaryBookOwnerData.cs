using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Serializer;

namespace GameData.Domains.LegendaryBook;

[SerializableGameData(NoCopyConstructors = true)]
public class LegendaryBookOwnerData : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<sbyte, int> BookMap;

	[SerializableGameDataField]
	public Dictionary<int, CharacterDisplayData> CharacterDisplayDataMap;

	[SerializableGameDataField]
	public Dictionary<int, sbyte> CharacterHappinessMap;

	[SerializableGameDataField]
	public Dictionary<int, MainAttributes> CharacterAttributeMap;

	[SerializableGameDataField]
	public Dictionary<int, short> CharacterHealthMap;

	[SerializableGameDataField]
	public Dictionary<int, short> CharacterLeftMaxHealthMap;

	public LegendaryBookOwnerData()
	{
		BookMap = new Dictionary<sbyte, int>();
		CharacterDisplayDataMap = new Dictionary<int, CharacterDisplayData>();
		CharacterHappinessMap = new Dictionary<int, sbyte>();
		CharacterAttributeMap = new Dictionary<int, MainAttributes>();
		CharacterHealthMap = new Dictionary<int, short>();
		CharacterLeftMaxHealthMap = new Dictionary<int, short>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(BookMap);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CharacterDisplayDataMap);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CharacterHappinessMap);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CharacterAttributeMap);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CharacterHealthMap);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CharacterLeftMaxHealthMap);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* num = pData + SerializationHelper.DictionaryOfBasicTypePair.Serialize(pData, ref BookMap);
		byte* num2 = num + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(num, ref CharacterDisplayDataMap);
		byte* num3 = num2 + SerializationHelper.DictionaryOfBasicTypePair.Serialize(num2, ref CharacterHappinessMap);
		byte* num4 = num3 + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(num3, ref CharacterAttributeMap);
		byte* num5 = num4 + SerializationHelper.DictionaryOfBasicTypePair.Serialize(num4, ref CharacterHealthMap);
		int totalSize = (int)(num5 + SerializationHelper.DictionaryOfBasicTypePair.Serialize(num5, ref CharacterLeftMaxHealthMap) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* num = pData + SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pData, ref BookMap);
		byte* num2 = num + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(num, ref CharacterDisplayDataMap);
		byte* num3 = num2 + SerializationHelper.DictionaryOfBasicTypePair.Deserialize(num2, ref CharacterHappinessMap);
		byte* num4 = num3 + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(num3, ref CharacterAttributeMap);
		byte* num5 = num4 + SerializationHelper.DictionaryOfBasicTypePair.Deserialize(num4, ref CharacterHealthMap);
		int totalSize = (int)(num5 + SerializationHelper.DictionaryOfBasicTypePair.Deserialize(num5, ref CharacterLeftMaxHealthMap) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
