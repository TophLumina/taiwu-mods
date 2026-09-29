using System;
using System.Collections;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Organization;

public class OrgMemberCollection : ISerializableGameData, IEnumerable<int>, IEnumerable
{
	private readonly HashSet<int> _grade0;

	private readonly HashSet<int> _grade1;

	private readonly HashSet<int> _grade2;

	private readonly HashSet<int> _grade3;

	private readonly HashSet<int> _grade4;

	private readonly HashSet<int> _grade5;

	private readonly HashSet<int> _grade6;

	private readonly HashSet<int> _grade7;

	private readonly HashSet<int> _grade8;

	public OrgMemberCollection()
	{
		_grade0 = new HashSet<int>();
		_grade1 = new HashSet<int>();
		_grade2 = new HashSet<int>();
		_grade3 = new HashSet<int>();
		_grade4 = new HashSet<int>();
		_grade5 = new HashSet<int>();
		_grade6 = new HashSet<int>();
		_grade7 = new HashSet<int>();
		_grade8 = new HashSet<int>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 36 + 4 * _grade0.Count + 4 * _grade1.Count + 4 * _grade2.Count + 4 * _grade3.Count + 4 * _grade4.Count + 4 * _grade5.Count + 4 * _grade6.Count + 4 * _grade7.Count + 4 * _grade8.Count;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* num = pData + SerializationHelper.Serialize(pData, _grade0);
		byte* num2 = num + SerializationHelper.Serialize(num, _grade1);
		byte* num3 = num2 + SerializationHelper.Serialize(num2, _grade2);
		byte* num4 = num3 + SerializationHelper.Serialize(num3, _grade3);
		byte* num5 = num4 + SerializationHelper.Serialize(num4, _grade4);
		byte* num6 = num5 + SerializationHelper.Serialize(num5, _grade5);
		byte* num7 = num6 + SerializationHelper.Serialize(num6, _grade6);
		byte* num8 = num7 + SerializationHelper.Serialize(num7, _grade7);
		return (int)(num8 + SerializationHelper.Serialize(num8, _grade8) - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* num = pData + SerializationHelper.Deserialize(pData, _grade0);
		byte* num2 = num + SerializationHelper.Deserialize(num, _grade1);
		byte* num3 = num2 + SerializationHelper.Deserialize(num2, _grade2);
		byte* num4 = num3 + SerializationHelper.Deserialize(num3, _grade3);
		byte* num5 = num4 + SerializationHelper.Deserialize(num4, _grade4);
		byte* num6 = num5 + SerializationHelper.Deserialize(num5, _grade5);
		byte* num7 = num6 + SerializationHelper.Deserialize(num6, _grade6);
		byte* num8 = num7 + SerializationHelper.Deserialize(num7, _grade7);
		return (int)(num8 + SerializationHelper.Deserialize(num8, _grade8) - pData);
	}

	public HashSet<int> GetMembers(sbyte grade)
	{
		return grade switch
		{
			0 => _grade0, 
			1 => _grade1, 
			2 => _grade2, 
			3 => _grade3, 
			4 => _grade4, 
			5 => _grade5, 
			6 => _grade6, 
			7 => _grade7, 
			8 => _grade8, 
			_ => throw new Exception($"Unsupported grade: {grade}"), 
		};
	}

	public void GetAllMembers(List<int> members)
	{
		members.Clear();
		members.AddRange(_grade0);
		members.AddRange(_grade1);
		members.AddRange(_grade2);
		members.AddRange(_grade3);
		members.AddRange(_grade4);
		members.AddRange(_grade5);
		members.AddRange(_grade6);
		members.AddRange(_grade7);
		members.AddRange(_grade8);
	}

	public int GetCount()
	{
		return _grade0.Count + _grade1.Count + _grade2.Count + _grade3.Count + _grade4.Count + _grade5.Count + _grade6.Count + _grade7.Count + _grade8.Count;
	}

	public void Add(int charId, sbyte grade)
	{
		GetMembers(grade).Add(charId);
	}

	public void Remove(int charId, sbyte grade)
	{
		if (!GetMembers(grade).Remove(charId))
		{
			AdaptableLog.TagWarning("OrgMemberCollection", $"Cannot remove character {charId} of grade {grade}", appendWarningMessage: true);
		}
	}

	public void OnChangeGrade(int charId, sbyte srcGrade, sbyte destGrade)
	{
		Remove(charId, srcGrade);
		Add(charId, destGrade);
	}

	public IEnumerator<int> GetEnumerator()
	{
		foreach (int item in _grade0)
		{
			yield return item;
		}
		foreach (int item2 in _grade1)
		{
			yield return item2;
		}
		foreach (int item3 in _grade2)
		{
			yield return item3;
		}
		foreach (int item4 in _grade3)
		{
			yield return item4;
		}
		foreach (int item5 in _grade4)
		{
			yield return item5;
		}
		foreach (int item6 in _grade5)
		{
			yield return item6;
		}
		foreach (int item7 in _grade6)
		{
			yield return item7;
		}
		foreach (int item8 in _grade7)
		{
			yield return item8;
		}
		foreach (int item9 in _grade8)
		{
			yield return item9;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
