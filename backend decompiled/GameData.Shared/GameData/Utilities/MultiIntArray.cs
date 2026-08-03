using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

[SerializableGameData(NotForArchive = true)]
public class MultiIntArray : ISerializableGameData
{
	[SerializableGameDataField]
	public List<IntList> Values;

	public MultiIntArray(IEnumerable<IntList> values)
	{
		Values = ((values == null) ? null : new List<IntList>(values));
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public MultiIntArray()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public MultiIntArray(MultiIntArray other)
	{
		if (other.Values != null)
		{
			List<IntList> item = other.Values;
			int elementsCount = item.Count;
			Values = new List<IntList>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				Values.Add(new IntList(item[i]));
			}
		}
		else
		{
			Values = null;
		}
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(MultiIntArray other)
	{
		if (other.Values != null)
		{
			List<IntList> item = other.Values;
			int elementsCount = item.Count;
			Values = new List<IntList>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				Values.Add(new IntList(item[i]));
			}
		}
		else
		{
			Values = null;
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
		if (Values != null)
		{
			totalSize += 2;
			int elementsCount = Values.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += Values[i].GetSerializedSize();
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
		if (Values != null)
		{
			int elementsCount = Values.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = Values[i].Serialize(pCurrData);
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
			if (Values == null)
			{
				Values = new List<IntList>(elementsCount);
			}
			else
			{
				Values.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				IntList element = default(IntList);
				pCurrData += element.Deserialize(pCurrData);
				Values.Add(element);
			}
		}
		else
		{
			Values?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
