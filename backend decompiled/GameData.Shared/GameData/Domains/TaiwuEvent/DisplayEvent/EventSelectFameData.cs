using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 选择名誉弹窗数据
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class EventSelectFameData : ISerializableGameData
{
	/// <summary>
	/// 所有可以被选择的名誉的相关数据
	/// </summary>
	[SerializableGameDataField]
	public List<FameActionRecord> fameActionRecords;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public EventSelectFameData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public EventSelectFameData(EventSelectFameData other)
	{
		fameActionRecords = ((other.fameActionRecords == null) ? null : new List<FameActionRecord>(other.fameActionRecords));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(EventSelectFameData other)
	{
		fameActionRecords = ((other.fameActionRecords == null) ? null : new List<FameActionRecord>(other.fameActionRecords));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((fameActionRecords == null) ? (totalSize + 2) : (totalSize + (2 + 8 * fameActionRecords.Count)));
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
		if (fameActionRecords != null)
		{
			int elementsCount = fameActionRecords.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += fameActionRecords[i].Serialize(pCurrData);
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
			if (fameActionRecords == null)
			{
				fameActionRecords = new List<FameActionRecord>(elementsCount);
			}
			else
			{
				fameActionRecords.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				FameActionRecord element = default(FameActionRecord);
				pCurrData += element.Deserialize(pCurrData);
				fameActionRecords.Add(element);
			}
		}
		else
		{
			fameActionRecords?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
