using System.Collections;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

[AutoGenerateSerializableGameData]
public class SkillBreakPlateBonusList : IList<SkillBreakPlateBonus>, ICollection<SkillBreakPlateBonus>, IEnumerable<SkillBreakPlateBonus>, IEnumerable, ISerializableGameData
{
	[SerializableGameDataField]
	private List<SkillBreakPlateBonus> _list = new List<SkillBreakPlateBonus>();

	private IList<SkillBreakPlateBonus> ListImplementation => _list ?? (_list = new List<SkillBreakPlateBonus>());

	public int Count => ListImplementation.Count;

	public bool IsReadOnly => ListImplementation.IsReadOnly;

	public SkillBreakPlateBonus this[int index]
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

	public SkillBreakPlateBonusList(IEnumerable<SkillBreakPlateBonus> collection)
	{
		if (_list == null)
		{
			_list = new List<SkillBreakPlateBonus>();
		}
		_list.Clear();
		_list.AddRange(collection);
	}

	public IEnumerator<SkillBreakPlateBonus> GetEnumerator()
	{
		return ListImplementation.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)ListImplementation).GetEnumerator();
	}

	public void Add(SkillBreakPlateBonus item)
	{
		ListImplementation.Add(item);
	}

	public void Clear()
	{
		ListImplementation.Clear();
	}

	public bool Contains(SkillBreakPlateBonus item)
	{
		return ListImplementation.Contains(item);
	}

	public void CopyTo(SkillBreakPlateBonus[] array, int arrayIndex)
	{
		ListImplementation.CopyTo(array, arrayIndex);
	}

	public bool Remove(SkillBreakPlateBonus item)
	{
		return ListImplementation.Remove(item);
	}

	public int IndexOf(SkillBreakPlateBonus item)
	{
		return ListImplementation.IndexOf(item);
	}

	public void Insert(int index, SkillBreakPlateBonus item)
	{
		ListImplementation.Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		ListImplementation.RemoveAt(index);
	}

	public SkillBreakPlateBonusList()
	{
	}

	public SkillBreakPlateBonusList(SkillBreakPlateBonusList other)
	{
		_list = ((other._list == null) ? null : new List<SkillBreakPlateBonus>(other._list));
	}

	public void Assign(SkillBreakPlateBonusList other)
	{
		_list = ((other._list == null) ? null : new List<SkillBreakPlateBonus>(other._list));
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
			for (int i = 0; i < _list.Count; i++)
			{
				totalSize += _list[i].GetSerializedSize();
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
		if (_list != null)
		{
			int elementsCount = _list.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int fieldSize = _list[i].Serialize(pCurrData);
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
			if (_list == null)
			{
				_list = new List<SkillBreakPlateBonus>();
			}
			else
			{
				_list.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				SkillBreakPlateBonus element = default(SkillBreakPlateBonus);
				pCurrData += element.Deserialize(pCurrData);
				_list.Add(element);
			}
		}
		else
		{
			_list?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
