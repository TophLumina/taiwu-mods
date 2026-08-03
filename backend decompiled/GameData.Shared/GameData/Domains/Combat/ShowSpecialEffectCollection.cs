using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 需要显示的特效集合
/// </summary>
[SerializableGameData]
public class ShowSpecialEffectCollection : ISerializableGameData
{
	/// <summary>
	/// (特效ID, 说明文字序号, 需要用道具描述代替特效描述时的道具key)
	/// </summary>
	[SerializableGameDataField]
	public List<ShowSpecialEffectDisplayData> ShowEffectList = new List<ShowSpecialEffectDisplayData>();

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (ShowEffectList != null)
		{
			totalSize += 2;
			int elementsCount = ShowEffectList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += ShowEffectList[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
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
		if (ShowEffectList != null)
		{
			int elementsCount = ShowEffectList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = ShowEffectList[i].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
			}
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ShowEffectList == null)
			{
				ShowEffectList = new List<ShowSpecialEffectDisplayData>(elementsCount);
			}
			else
			{
				ShowEffectList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ShowSpecialEffectDisplayData element = default(ShowSpecialEffectDisplayData);
				pCurrData += element.Deserialize(pCurrData);
				ShowEffectList.Add(element);
			}
		}
		else
		{
			ShowEffectList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
