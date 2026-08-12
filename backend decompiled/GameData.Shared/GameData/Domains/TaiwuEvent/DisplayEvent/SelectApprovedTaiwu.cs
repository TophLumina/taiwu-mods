using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 选择支持太吾人物数据
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class SelectApprovedTaiwu : ISerializableGameData
{
	/// <summary>
	/// 每个人对太吾的支持度
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, short> CharacterApprovingRate;

	/// <summary>
	/// 拥有王公授予官职的角色id列表
	/// </summary>
	[SerializableGameDataField]
	public List<int> DukeTitleCharIdList;

	/// <summary>
	/// 目标支持度
	/// </summary>
	[SerializableGameDataField]
	public short TargetApprovingRate;

	public SelectApprovedTaiwu()
	{
		CharacterApprovingRate = new Dictionary<int, short>();
		DukeTitleCharIdList = new List<int>();
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CharacterApprovingRate);
		totalSize = ((DukeTitleCharIdList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * DukeTitleCharIdList.Count)));
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
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref CharacterApprovingRate);
		if (DukeTitleCharIdList != null)
		{
			int elementsCount = DukeTitleCharIdList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = DukeTitleCharIdList[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = TargetApprovingRate;
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
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref CharacterApprovingRate);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (DukeTitleCharIdList == null)
			{
				DukeTitleCharIdList = new List<int>(elementsCount);
			}
			else
			{
				DukeTitleCharIdList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				DukeTitleCharIdList.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			DukeTitleCharIdList?.Clear();
		}
		TargetApprovingRate = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
