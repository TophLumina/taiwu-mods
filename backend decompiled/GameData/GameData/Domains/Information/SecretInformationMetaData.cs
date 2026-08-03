using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Information.Secret.Attachment;
using GameData.Serializer;

namespace GameData.Domains.Information;

[SerializableGameData(NotForDisplayModule = true)]
public class SecretInformationMetaData : BaseGameDataObject, ISerializableGameData
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 4;

		public const uint Offset_Offset = 4u;

		public const int Offset_Size = 4;

		public const uint RelevanceSecretInformationMetaDataId_Offset = 8u;

		public const int RelevanceSecretInformationMetaDataId_Size = 4;
	}

	[CollectionObjectField(false, true, false, true, false)]
	private int _id;

	[CollectionObjectField(false, true, false, false, false)]
	private int _offset;

	[CollectionObjectField(false, true, false, false, false)]
	private SecretInformationDisseminationData _disseminationData;

	[CollectionObjectField(false, true, false, false, false)]
	private int _relevanceSecretInformationMetaDataId;

	[CollectionObjectField(false, true, false, false, false)]
	private CharacterRelationshipSnapshot _secretInformationCharacterRelationshipSnapshotCollection;

	[CollectionObjectField(false, true, false, false, false)]
	private CharacterExtraInfo _secretInformationCharacterExtraInfoCollection;

	public const int FixedSize = 12;

	public const int DynamicCount = 3;

	private static readonly ushort[] ArchiveFieldIds = new ushort[6] { 0, 1, 3, 2, 4, 5 };

	private static readonly int[] FixedArchiveFieldSizes = new int[3] { 4, 4, 4 };

	public CharacterRelationshipSnapshot CharacterRelationshipSnapshotCollection => _secretInformationCharacterRelationshipSnapshotCollection;

	public CharacterExtraInfo CharacterExtraInfoCollection => _secretInformationCharacterExtraInfoCollection;

	public SecretInformationMetaData(int id, int offset, int relevanceSecretInformationMetaDataId = -1)
		: this()
	{
		_id = id;
		_offset = offset;
		_relevanceSecretInformationMetaDataId = relevanceSecretInformationMetaDataId;
	}

	public void UpdateOffset(int delta)
	{
		_offset += delta;
	}

	public void IncreaseCharacterDisseminationCount(int characterId)
	{
		if (_disseminationData.DisseminationCounts.TryGetValue(characterId, out var count))
		{
			_disseminationData.DisseminationCounts[characterId] = count + 1;
		}
		else
		{
			_disseminationData.DisseminationCounts.Add(characterId, 1);
		}
	}

	public int GetCharacterDisseminationCount(int characterId)
	{
		int count;
		return _disseminationData.DisseminationCounts.TryGetValue(characterId, out count) ? count : 0;
	}

	public ICollection<int> GetDisseminationBranchCharacterIds()
	{
		return _disseminationData.DisseminationCounts.Keys;
	}

	public int GetId()
	{
		return _id;
	}

	public int GetOffset()
	{
		return _offset;
	}

	public void SetOffset(int offset, DataContext context)
	{
		_offset = offset;
		SetModifiedAndInvalidateInfluencedCache(1, context);
	}

	public SecretInformationDisseminationData GetDisseminationData()
	{
		return _disseminationData;
	}

	public void SetDisseminationData(SecretInformationDisseminationData disseminationData, DataContext context)
	{
		_disseminationData = disseminationData;
		SetModifiedAndInvalidateInfluencedCache(2, context);
	}

	public int GetRelevanceSecretInformationMetaDataId()
	{
		return _relevanceSecretInformationMetaDataId;
	}

	public void SetRelevanceSecretInformationMetaDataId(int relevanceSecretInformationMetaDataId, DataContext context)
	{
		_relevanceSecretInformationMetaDataId = relevanceSecretInformationMetaDataId;
		SetModifiedAndInvalidateInfluencedCache(3, context);
	}

	public SecretInformationMetaData()
	{
		_disseminationData = new SecretInformationDisseminationData();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 4 + ArchiveFieldIds.Length * 2 + 4 + FixedArchiveFieldSizes.Length * 4 + GetSerializedSizeWithoutHeader();
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = (*(int*)pCurrData = ArchiveFieldIds.Length);
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		fixed (ushort* archiveFieldIds = ArchiveFieldIds)
		{
			void* pFieldId = archiveFieldIds;
			Buffer.MemoryCopy(pFieldId, pCurrData, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = (*(int*)pCurrData = FixedArchiveFieldSizes.Length);
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		fixed (int* fixedArchiveFieldSizes = FixedArchiveFieldSizes)
		{
			void* pFieldSize = fixedArchiveFieldSizes;
			Buffer.MemoryCopy(pFieldSize, pCurrData, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += SerializeWithoutHeader(pCurrData);
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = *(int*)pCurrData;
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		ushort[] fieldIds = new ushort[length];
		fixed (ushort* ptr = fieldIds)
		{
			void* pFieldId = ptr;
			Buffer.MemoryCopy(pCurrData, pFieldId, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = *(int*)pCurrData;
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		int[] fieldSizes = new int[fixedFieldSizesLength];
		fixed (int* ptr2 = fieldSizes)
		{
			void* pFieldSize = ptr2;
			Buffer.MemoryCopy(pCurrData, pFieldSize, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += DeserializeWithFieldIds(pCurrData, fieldIds, fieldSizes);
		return (int)(pCurrData - pData);
	}

	public override int GetSerializedSizeWithoutHeader()
	{
		int totalSize = 24;
		int dataSize = _disseminationData.GetSerializedSize();
		return totalSize + dataSize;
	}

	public unsafe override int SerializeWithoutHeader(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = _id;
		pCurrData += 4;
		*(int*)pCurrData = _offset;
		pCurrData += 4;
		*(int*)pCurrData = _relevanceSecretInformationMetaDataId;
		pCurrData += 4;
		byte* pBegin = pCurrData;
		pCurrData += 4;
		pCurrData += _disseminationData.Serialize(pCurrData);
		int fieldSize = (int)(pCurrData - pBegin - 4);
		if (fieldSize > 4194304)
		{
			throw new Exception($"Size of field {"_disseminationData"} must be less than {4096}KB");
		}
		*(int*)pBegin = fieldSize;
		return (int)(pCurrData - pData);
	}

	public unsafe override int DeserializeWithFieldIds(byte* pData, ushort[] fieldIds, int[] fixedFieldSizes)
	{
		byte* pCurrData = pData;
		for (int fieldIndex = 0; fieldIndex < fieldIds.Length; fieldIndex++)
		{
			switch (fieldIds[fieldIndex])
			{
			case 0:
				_id = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 1:
				_offset = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 3:
				_relevanceSecretInformationMetaDataId = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 2:
				pCurrData += 4;
				pCurrData += _disseminationData.Deserialize(pCurrData);
				continue;
			}
			if (fieldIndex < fixedFieldSizes.Length)
			{
				int fieldSize = fixedFieldSizes[fieldIndex];
				pCurrData += fieldSize;
			}
			else
			{
				int fieldSize2 = *(int*)pCurrData;
				pCurrData += 4;
				pCurrData += fieldSize2;
			}
		}
		return (int)(pCurrData - pData);
	}
}
