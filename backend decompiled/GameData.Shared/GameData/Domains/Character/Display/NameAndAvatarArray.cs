using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 对于引用类型字段, 构造函数中可以不创建对象, 保留默认的 null 值.
/// 在进行反序列化时, 允许所有引用类型字段都为 null.
/// 但是在序列化时, 要求所有是定长集合的引用字段都已经被创建, 且长度与定义一致. 集合中的引用类型元素若也为定长, 则也必须被创建; 变长的则可以为 null.
/// </summary>
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public struct NameAndAvatarArray : IReadOnlyList<NameAndAvatar>, IEnumerable<NameAndAvatar>, IEnumerable, IReadOnlyCollection<NameAndAvatar>, ISerializableGameData
{
	[SerializableGameDataField]
	public NameAndAvatar[] Data;

	public int Count => Data.Length;

	public NameAndAvatar this[int index] => Data[index];

	public static implicit operator NameAndAvatar[](NameAndAvatarArray item)
	{
		return item.Data;
	}

	public static implicit operator NameAndAvatarArray(NameAndAvatar[] item)
	{
		return new NameAndAvatarArray
		{
			Data = item
		};
	}

	public IEnumerator<NameAndAvatar> GetEnumerator()
	{
		return Data.AsEnumerable().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return Data.GetEnumerator();
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
		if (Data != null)
		{
			totalSize += 2;
			int elementsCount = Data.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += Data[i].GetSerializedSize();
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
		if (Data != null)
		{
			int elementsCount = Data.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = Data[i].Serialize(pCurrData);
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
			if (Data == null || Data.Length != elementsCount)
			{
				Data = new NameAndAvatar[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				NameAndAvatar element = default(NameAndAvatar);
				pCurrData += element.Deserialize(pCurrData);
				Data[i] = element;
			}
		}
		else
		{
			Data = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
