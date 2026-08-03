using System.Collections;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[SerializableGameData(NotForDisplayModule = true)]
public class SkillBreakPlateList : IList<SkillBreakPlate>, ICollection<SkillBreakPlate>, IEnumerable<SkillBreakPlate>, IEnumerable, ISerializableGameData
{
	[SerializableGameDataField]
	private List<SkillBreakPlate> _list = new List<SkillBreakPlate>();

	private IList<SkillBreakPlate> ListImplementation => _list ?? (_list = new List<SkillBreakPlate>());

	public int Count => ListImplementation.Count;

	public bool IsReadOnly => ListImplementation.IsReadOnly;

	public SkillBreakPlate this[int index]
	{
		get
		{
			return ListImplementation[index];
		}
		set
		{
			ListImplementation[index] = value;
		}
	}

	public IEnumerator<SkillBreakPlate> GetEnumerator()
	{
		return ListImplementation.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)ListImplementation).GetEnumerator();
	}

	public void Add(SkillBreakPlate item)
	{
		ListImplementation.Add(item);
	}

	public void Clear()
	{
		ListImplementation.Clear();
	}

	public bool Contains(SkillBreakPlate item)
	{
		return ListImplementation.Contains(item);
	}

	public void CopyTo(SkillBreakPlate[] array, int arrayIndex)
	{
		ListImplementation.CopyTo(array, arrayIndex);
	}

	public bool Remove(SkillBreakPlate item)
	{
		return ListImplementation.Remove(item);
	}

	public int IndexOf(SkillBreakPlate item)
	{
		return ListImplementation.IndexOf(item);
	}

	public void Insert(int index, SkillBreakPlate item)
	{
		ListImplementation.Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		ListImplementation.RemoveAt(index);
	}

	public SkillBreakPlateList()
	{
	}

	public SkillBreakPlateList(SkillBreakPlateList other)
	{
		if (other._list != null)
		{
			List<SkillBreakPlate> item = other._list;
			int elementsCount = item.Count;
			_list = new List<SkillBreakPlate>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				_list.Add(new SkillBreakPlate(item[i]));
			}
		}
		else
		{
			_list = null;
		}
	}

	public void Assign(SkillBreakPlateList other)
	{
		if (other._list != null)
		{
			List<SkillBreakPlate> item = other._list;
			int elementsCount = item.Count;
			_list = new List<SkillBreakPlate>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				_list.Add(new SkillBreakPlate(item[i]));
			}
		}
		else
		{
			_list = null;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (_list != null)
		{
			totalSize += 2;
			int elementsCount = _list.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				SkillBreakPlate element = _list[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (_list != null)
		{
			int elementsCount = _list.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				SkillBreakPlate element = _list[i];
				if (element != null)
				{
					byte* pSubDataCount = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)pSubDataCount = (ushort)subDataSize;
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
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_list == null)
			{
				_list = new List<SkillBreakPlate>(elementsCount);
			}
			else
			{
				_list.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort subDataCount = *(ushort*)pCurrData;
				pCurrData += 2;
				if (subDataCount > 0)
				{
					SkillBreakPlate element = new SkillBreakPlate();
					pCurrData += element.Deserialize(pCurrData);
					_list.Add(element);
				}
				else
				{
					_list.Add(null);
				}
			}
		}
		else
		{
			_list?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
