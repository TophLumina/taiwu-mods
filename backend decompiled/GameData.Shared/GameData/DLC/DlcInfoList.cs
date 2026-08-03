using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC;

/// <summary>
/// 包装Dlc列表，用于前后端传输需要读取的Mod数据
/// </summary>
public struct DlcInfoList : ISerializableGameData
{
	/// <summary>
	///
	/// </summary>
	[SerializableGameDataField]
	public List<DlcInfo> Items;

	/// <summary>
	/// 创建对象, 并创建内部集合.
	/// 使用 new 创建对象时, 无法同时创建内部集合.
	/// </summary>
	/// <returns></returns>
	public static DlcInfoList Create()
	{
		DlcInfoList obj = default(DlcInfoList);
		obj.Items = new List<DlcInfo>();
		return obj;
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public DlcInfoList(DlcInfoList other)
	{
		if (other.Items != null)
		{
			List<DlcInfo> item = other.Items;
			int elementsCount = item.Count;
			Items = new List<DlcInfo>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				Items.Add(new DlcInfo(item[i]));
			}
		}
		else
		{
			Items = null;
		}
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(DlcInfoList other)
	{
		if (other.Items != null)
		{
			List<DlcInfo> item = other.Items;
			int elementsCount = item.Count;
			Items = new List<DlcInfo>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				Items.Add(new DlcInfo(item[i]));
			}
		}
		else
		{
			Items = null;
		}
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
		if (Items != null)
		{
			totalSize += 2;
			int elementsCount = Items.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				DlcInfo element = Items[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
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
		if (Items != null)
		{
			int elementsCount = Items.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				DlcInfo element = Items[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
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
			if (Items == null)
			{
				Items = new List<DlcInfo>(elementsCount);
			}
			else
			{
				Items.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					DlcInfo element = new DlcInfo();
					pCurrData += element.Deserialize(pCurrData);
					Items.Add(element);
				}
				else
				{
					Items.Add(null);
				}
			}
		}
		else
		{
			Items?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
