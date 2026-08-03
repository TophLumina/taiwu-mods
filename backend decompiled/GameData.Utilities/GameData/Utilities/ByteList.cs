using System.Collections;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

[SerializableGameData]
public class ByteList : IList<byte>, ICollection<byte>, IEnumerable<byte>, IEnumerable, IReadOnlyList<byte>, IReadOnlyCollection<byte>, ISerializableGameData
{
	[SerializableGameDataField]
	private List<byte> _implementList = new List<byte>();

	private IList<byte> Implement => _implementList;

	public int Count => Implement.Count;

	public bool IsReadOnly => Implement.IsReadOnly;

	public byte this[int index]
	{
		get
		{
			return Implement[index];
		}
		set
		{
			Implement[index] = value;
		}
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return Implement.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)Implement).GetEnumerator();
	}

	public void Add(byte item)
	{
		Implement.Add(item);
	}

	public void Clear()
	{
		Implement.Clear();
	}

	public bool Contains(byte item)
	{
		return Implement.Contains(item);
	}

	public void CopyTo(byte[] array, int arrayIndex)
	{
		Implement.CopyTo(array, arrayIndex);
	}

	public bool Remove(byte item)
	{
		return Implement.Remove(item);
	}

	public int IndexOf(byte item)
	{
		return Implement.IndexOf(item);
	}

	public void Insert(int index, byte item)
	{
		Implement.Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		Implement.RemoveAt(index);
	}

	public void AddRange(IEnumerable<byte> items)
	{
		_implementList.AddRange(items);
	}

	public ByteList()
	{
	}

	public ByteList(ByteList other)
	{
		_implementList = ((other._implementList == null) ? null : new List<byte>(other._implementList));
	}

	public void Assign(ByteList other)
	{
		_implementList = ((other._implementList == null) ? null : new List<byte>(other._implementList));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((_implementList == null) ? (totalSize + 2) : (totalSize + (2 + _implementList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (_implementList != null)
		{
			int elementsCount = _implementList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = _implementList[i];
			}
			pCurrData += elementsCount;
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
			if (_implementList == null)
			{
				_implementList = new List<byte>(elementsCount);
			}
			else
			{
				_implementList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				_implementList.Add(pCurrData[i]);
			}
			pCurrData += (int)elementsCount;
		}
		else
		{
			_implementList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
