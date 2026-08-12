using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Information.Secret.Attachment;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Information.Secret;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SecretOccurence : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort TemplateId = 1;

		public const ushort InBroadcast = 2;

		public const ushort PackedParameters = 3;

		public const ushort Date = 4;

		public const ushort Location = 5;

		public const ushort RelevanceOccurenceId = 6;

		public const ushort CharacterRelationshipSnapshotCollection = 7;

		public const ushort CharacterExtraInfoCollection = 8;

		public const ushort Count = 9;

		public static readonly string[] FieldId2FieldName = new string[9] { "Id", "TemplateId", "InBroadcast", "PackedParameters", "Date", "Location", "RelevanceOccurenceId", "CharacterRelationshipSnapshotCollection", "CharacterExtraInfoCollection" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public SecretOccurenceId Id = SecretOccurenceId.Invalid;

	[SerializableGameDataField(FieldIndex = 1)]
	public short TemplateId = -1;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool InBroadcast;

	[SerializableGameDataField(FieldIndex = 3)]
	public byte[] PackedParameters = Array.Empty<byte>();

	[SerializableGameDataField(FieldIndex = 4)]
	public int Date = -1;

	[SerializableGameDataField(FieldIndex = 5)]
	public Location Location;

	[SerializableGameDataField(FieldIndex = 6)]
	public SecretOccurenceId RelevanceOccurenceId = SecretOccurenceId.Invalid;

	[SerializableGameDataField(FieldIndex = 7)]
	public Dictionary<int, CharacterRelationshipSnapshot> CharacterRelationshipSnapshotCollection = new Dictionary<int, CharacterRelationshipSnapshot>();

	[SerializableGameDataField(FieldIndex = 8)]
	public Dictionary<int, CharacterExtraInfo> CharacterExtraInfoCollection = new Dictionary<int, CharacterExtraInfo>();

	public override string ToString()
	{
		return string.Format("{0}#{1}({2})", "SecretOccurence", (int)Id, Config.SecretInformation.Instance[TemplateId].Name);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 21;
		totalSize = ((PackedParameters == null) ? (totalSize + 2) : (totalSize + (2 + PackedParameters.Length)));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CharacterRelationshipSnapshotCollection);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CharacterExtraInfoCollection);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 9;
		pCurrData += 2;
		pCurrData += Id.Serialize(pCurrData);
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*pCurrData = (InBroadcast ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (PackedParameters != null)
		{
			int elementsCount = PackedParameters.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = PackedParameters[i];
			}
			pCurrData += elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = Date;
		pCurrData += 4;
		pCurrData += Location.Serialize(pCurrData);
		pCurrData += RelevanceOccurenceId.Serialize(pCurrData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CharacterRelationshipSnapshotCollection);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CharacterExtraInfoCollection);
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
			pCurrData += Id.Deserialize(pCurrData);
		}
		if (fieldCount > 1)
		{
			TemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 2)
		{
			InBroadcast = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 3)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (PackedParameters == null || PackedParameters.Length != elementsCount)
				{
					PackedParameters = new byte[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					PackedParameters[i] = pCurrData[i];
				}
				pCurrData += (int)elementsCount;
			}
			else
			{
				PackedParameters = null;
			}
		}
		if (fieldCount > 4)
		{
			Date = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 5)
		{
			pCurrData += Location.Deserialize(pCurrData);
		}
		if (fieldCount > 6)
		{
			pCurrData += RelevanceOccurenceId.Deserialize(pCurrData);
		}
		if (fieldCount > 7)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CharacterRelationshipSnapshotCollection);
		}
		if (fieldCount > 8)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CharacterExtraInfoCollection);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
