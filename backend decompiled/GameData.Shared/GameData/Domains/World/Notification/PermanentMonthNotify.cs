using System;
using System.Collections.Generic;
using GameData.DLC.FiveLoong;
using GameData.Domains.Character.Display;
using GameData.Serializer;

namespace GameData.Domains.World.Notification;

[SerializableGameData(IsExtensible = true)]
[Obsolete]
public class PermanentMonthNotify : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort NotificationCollections = 0;

		public const ushort CharacterNames = 1;

		public const ushort JiaoLoongNames = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "NotificationCollections", "CharacterNames", "JiaoLoongNames" };
	}

	[SerializableGameDataField]
	public Dictionary<int, MonthlyNotificationCollection> NotificationCollections = new Dictionary<int, MonthlyNotificationCollection>();

	[SerializableGameDataField]
	public Dictionary<int, NameAndLifeRelatedData> CharacterNames = new Dictionary<int, NameAndLifeRelatedData>();

	[SerializableGameDataField]
	public Dictionary<int, JiaoLoongNameRelatedData> JiaoLoongNames = new Dictionary<int, JiaoLoongNameRelatedData>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(NotificationCollections);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CharacterNames);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(JiaoLoongNames);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 3;
		byte* num = pData + 2;
		byte* num2 = num + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(num, ref NotificationCollections);
		byte* num3 = num2 + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(num2, ref CharacterNames);
		int totalSize = (int)(num3 + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(num3, ref JiaoLoongNames) - pData);
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
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref NotificationCollections);
		}
		if (fieldCount > 1)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CharacterNames);
		}
		if (fieldCount > 2)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref JiaoLoongNames);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
