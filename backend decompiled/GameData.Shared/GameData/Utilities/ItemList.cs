using System;
using System.Collections;
using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Utilities;

/// <summary>
/// 用于适配序列化的道具列表
/// </summary>
[SerializableGameData(NotForDisplayModule = true)]
public class ItemList : ISerializableGameData, IList<ItemKey>, ICollection<ItemKey>, IEnumerable<ItemKey>, IEnumerable, IReadOnlyList<ItemKey>, IReadOnlyCollection<ItemKey>
{
	[SerializableGameDataField]
	private List<ItemKey> _internalList;

	private IList<ItemKey> InternalList => _internalList ?? (_internalList = new List<ItemKey>());

	public int Count => InternalList.Count;

	public bool IsReadOnly => InternalList.IsReadOnly;

	public ItemKey this[int index]
	{
		get
		{
			return InternalList[index];
		}
		set
		{
			InternalList[index] = value;
		}
	}

	public ItemList(IEnumerable<ItemKey> collection)
	{
		_internalList = new List<ItemKey>(collection);
	}

	public void AddRange(IEnumerable<ItemKey> collection)
	{
		if (_internalList == null)
		{
			_internalList = new List<ItemKey>();
		}
		_internalList.AddRange(collection);
	}

	public void Sort(Comparison<ItemKey> comparison)
	{
		_internalList?.Sort(comparison);
	}

	public IEnumerator<ItemKey> GetEnumerator()
	{
		return InternalList.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)InternalList).GetEnumerator();
	}

	public void Add(ItemKey item)
	{
		InternalList.Add(item);
	}

	public void Clear()
	{
		InternalList.Clear();
	}

	public bool Contains(ItemKey item)
	{
		return InternalList.Contains(item);
	}

	public void CopyTo(ItemKey[] array, int arrayIndex)
	{
		InternalList.CopyTo(array, arrayIndex);
	}

	public bool Remove(ItemKey item)
	{
		return InternalList.Remove(item);
	}

	public int IndexOf(ItemKey item)
	{
		return InternalList.IndexOf(item);
	}

	public void Insert(int index, ItemKey item)
	{
		InternalList.Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		InternalList.RemoveAt(index);
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public ItemList()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public ItemList(ItemList other)
	{
		_internalList = ((other._internalList == null) ? null : new List<ItemKey>(other._internalList));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(ItemList other)
	{
		_internalList = ((other._internalList == null) ? null : new List<ItemKey>(other._internalList));
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
		totalSize = ((_internalList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * _internalList.Count)));
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
		if (_internalList != null)
		{
			int elementsCount = _internalList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += _internalList[i].Serialize(pCurrData);
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
			if (_internalList == null)
			{
				_internalList = new List<ItemKey>(elementsCount);
			}
			else
			{
				_internalList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ItemKey element = default(ItemKey);
				pCurrData += element.Deserialize(pCurrData);
				_internalList.Add(element);
			}
		}
		else
		{
			_internalList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
