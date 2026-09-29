using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
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

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (Data != null)
		{
			totalSize += 2;
			for (int i = 0; i < Data.Length; i++)
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
				int fieldSize = Data[i].Serialize(pCurrData);
				pCurrData += fieldSize;
				Tester.Assert(fieldSize <= 65535);
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
				Data[i] = default(NameAndAvatar);
				pCurrData += Data[i].Deserialize(pCurrData);
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
