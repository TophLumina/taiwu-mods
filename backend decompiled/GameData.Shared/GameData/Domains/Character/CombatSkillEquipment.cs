using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

[SerializableGameData(NotForArchive = true)]
public class CombatSkillEquipment : IEnumerable<short>, IEnumerable, ISerializableGameData
{
	private object _sourceObj;

	public ArraySegmentList<short> Neigong;

	public ArraySegmentList<short> Attack;

	public ArraySegmentList<short> Agility;

	public ArraySegmentList<short> Defense;

	public ArraySegmentList<short> Assistance;

	public ref ArraySegmentList<short> this[sbyte type] => type switch
	{
		0 => ref Neigong, 
		1 => ref Attack, 
		2 => ref Agility, 
		3 => ref Defense, 
		4 => ref Assistance, 
		_ => throw new IndexOutOfRangeException($"{type} is out of range [0, {5})"), 
	};

	public void Assign(CombatSkillEquipment other)
	{
		_sourceObj = other._sourceObj;
		Neigong = other.Neigong;
		Attack = other.Attack;
		Agility = other.Agility;
		Defense = other.Defense;
		Assistance = other.Assistance;
	}

	public bool IsCombatSkillEquipped(short templateId)
	{
		return this[Config.CombatSkill.Instance[templateId].EquipType].IndexOf(templateId) >= 0;
	}

	public void GetValidSkills(ICollection<short> result)
	{
		result.Clear();
		for (sbyte equipType = 0; equipType < 5; equipType++)
		{
			ArraySegmentList<short>.Enumerator enumerator = this[equipType].GetEnumerator();
			while (enumerator.MoveNext())
			{
				short skillTemplateId = enumerator.Current;
				if (skillTemplateId >= 0)
				{
					result.Add(skillTemplateId);
				}
			}
		}
	}

	public void GetValidSkills(sbyte equipType, ICollection<short> result)
	{
		result.Clear();
		ArraySegmentList<short>.Enumerator enumerator = this[equipType].GetEnumerator();
		while (enumerator.MoveNext())
		{
			short skillTemplateId = enumerator.Current;
			if (skillTemplateId >= 0)
			{
				result.Add(skillTemplateId);
			}
		}
	}

	public IEnumerator<short> GetEnumerator()
	{
		for (sbyte type = 0; type < 5; type++)
		{
			ArraySegmentList<short> collection = this[type];
			ArraySegmentList<short>.Enumerator enumerator = collection.GetEnumerator();
			while (enumerator.MoveNext())
			{
				yield return enumerator.Current;
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10 + 2 * (Neigong.Count + Attack.Count + Agility.Count + Defense.Count + Assistance.Count);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += SerializeArraySegment(pCurrData, Neigong);
		pCurrData += SerializeArraySegment(pCurrData, Attack);
		pCurrData += SerializeArraySegment(pCurrData, Agility);
		pCurrData += SerializeArraySegment(pCurrData, Defense);
		pCurrData += SerializeArraySegment(pCurrData, Assistance);
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
		pCurrData += DeserializeArraySegment(pCurrData, ref Neigong);
		pCurrData += DeserializeArraySegment(pCurrData, ref Attack);
		pCurrData += DeserializeArraySegment(pCurrData, ref Agility);
		pCurrData += DeserializeArraySegment(pCurrData, ref Defense);
		pCurrData += DeserializeArraySegment(pCurrData, ref Assistance);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	private unsafe int SerializeArraySegment(byte* pData, ArraySegmentList<short> arr)
	{
		byte* pCurrData = pData;
		*(ushort*)pCurrData = (ushort)arr.Count;
		pCurrData += 2;
		for (int i = 0; i < arr.Count; i++)
		{
			*(short*)pCurrData = arr[i];
			pCurrData += 2;
		}
		return (int)(pCurrData - pData);
	}

	private unsafe int DeserializeArraySegment(byte* pData, ref ArraySegmentList<short> arr)
	{
		byte* pCurrData = pData;
		ushort count = *(ushort*)pCurrData;
		pCurrData += 2;
		if (arr.Count != count)
		{
			arr = new short[count];
		}
		arr.Clear();
		for (int i = 0; i < count; i++)
		{
			arr.Add(*(short*)pCurrData);
			pCurrData += 2;
		}
		return (int)(pCurrData - pData);
	}

	public T GetSourceObject<T>() where T : class
	{
		return _sourceObj as T;
	}

	public void OfflineSetSlot(int slot, short skillTemplateId)
	{
		sbyte equipType = Config.CombatSkill.Instance[skillTemplateId].EquipType;
		OfflineEnsureCapacity(equipType, slot + 1);
		this[equipType][slot] = skillTemplateId;
	}

	public void OfflineAddSkill(short skillTemplateId)
	{
		sbyte equipType = Config.CombatSkill.Instance[skillTemplateId].EquipType;
		OfflineEnsureCapacity(equipType);
		this[equipType].Add(skillTemplateId);
	}

	public bool OfflineRemoveSkill(short skillTemplateId)
	{
		sbyte equipType = Config.CombatSkill.Instance[skillTemplateId].EquipType;
		ArraySegmentList<short> collection = this[equipType];
		int index = collection.IndexOf(skillTemplateId);
		if (index < 0)
		{
			return false;
		}
		collection.RemoveAt(index);
		return true;
	}

	public void OfflineClear()
	{
		Neigong.Clear();
		Attack.Clear();
		Agility.Clear();
		Defense.Clear();
		Assistance.Clear();
	}

	public short OfflineRemoveLastSkill(sbyte equipType)
	{
		ArraySegmentList<short> collection = this[equipType];
		int count = collection.Count;
		if (count < 0)
		{
			return -1;
		}
		int lastIndex = count - 1;
		short result = collection[lastIndex];
		collection.RemoveAt(lastIndex);
		return result;
	}

	public bool OfflineEnsureCapacity(sbyte equipType, int capacity = -1)
	{
		ArraySegmentList<short> collection = this[equipType];
		if (capacity < 0)
		{
			capacity = collection.Count + 1;
		}
		if (collection.Capacity >= capacity)
		{
			return false;
		}
		object sourceObj = _sourceObj;
		if (!(sourceObj is short[] array))
		{
			if (sourceObj is CombatSkillPlan combatSkillPlan)
			{
				combatSkillPlan.EnsureSkillListCapacity(equipType, capacity);
				Set(combatSkillPlan);
				return true;
			}
			throw new InvalidOperationException("No source object for CombatSkillEquipment.");
		}
		CombatSkillPlan combatSkillPlan2 = new CombatSkillPlan();
		combatSkillPlan2.Record(array);
		CombatSkillHelper.InitializeEquippedSkills(array);
		combatSkillPlan2.EnsureSkillListCapacity(equipType, capacity);
		Set(combatSkillPlan2);
		return true;
	}

	public void Set(short[] equippedCombatSkills)
	{
		_sourceObj = equippedCombatSkills;
		Neigong = ConvertPartialSegmentList(equippedCombatSkills, 0);
		Attack = ConvertPartialSegmentList(equippedCombatSkills, 1);
		Agility = ConvertPartialSegmentList(equippedCombatSkills, 2);
		Defense = ConvertPartialSegmentList(equippedCombatSkills, 3);
		Assistance = ConvertPartialSegmentList(equippedCombatSkills, 4);
	}

	public void Set(CombatSkillPlan combatSkillPlan)
	{
		_sourceObj = combatSkillPlan;
		Neigong = ConvertFullSegmentList(combatSkillPlan.NeigongList);
		Attack = ConvertFullSegmentList(combatSkillPlan.AttackSkillList);
		Agility = ConvertFullSegmentList(combatSkillPlan.AgilitySkillList);
		Defense = ConvertFullSegmentList(combatSkillPlan.DefenseSkillList);
		Assistance = ConvertFullSegmentList(combatSkillPlan.AssistanceSkillList);
	}

	public void CopyFrom(CombatSkillEquipment other)
	{
		for (sbyte equipType = 0; equipType < 5; equipType++)
		{
			ArraySegmentList<short> otherCollection = other[equipType];
			OfflineEnsureCapacity(equipType, otherCollection.Count);
			ref ArraySegmentList<short> thisCollection = ref this[equipType];
			thisCollection.Clear();
			for (int i = 0; i < otherCollection.Count; i++)
			{
				short skillId = otherCollection[i];
				if (skillId >= 0)
				{
					thisCollection.Add(skillId);
				}
			}
		}
	}

	public bool EqualsTo(CombatSkillEquipment other)
	{
		for (sbyte equipType = 0; equipType < 5; equipType++)
		{
			ArraySegmentList<short> selfCollection = this[equipType];
			ArraySegmentList<short> otherCollection = other[equipType];
			if (!CheckArraySegmentEquals(ref otherCollection, ref selfCollection))
			{
				return false;
			}
		}
		return true;
	}

	private bool CheckArraySegmentEquals(ref ArraySegmentList<short> segA, ref ArraySegmentList<short> segB)
	{
		if (segA.Count != segB.Count)
		{
			return false;
		}
		int count = segA.Count;
		for (int i = 0; i < count; i++)
		{
			if (segA[i] != segB[i])
			{
				return false;
			}
		}
		return true;
	}

	private ArraySegmentList<short> ConvertFullSegmentList(short[] array)
	{
		return new ArraySegmentList<short>(array, 0, array.Length, GetNextIndex(array), (short)(-1));
	}

	private static ArraySegmentList<short> ConvertPartialSegmentList(short[] equippedSkills, sbyte equipType)
	{
		sbyte offset = CombatSkillHelper.SlotBeginIndexes[equipType];
		sbyte length = CombatSkillHelper.MaxSlotCounts[equipType];
		int count = GetNextIndex(equippedSkills, offset, length);
		return new ArraySegmentList<short>(equippedSkills, offset, length, count, (short)(-1));
	}

	private static int GetNextIndex(short[] array)
	{
		int count = array.Length;
		for (int i = 0; i < count; i++)
		{
			if (array[i] < 0)
			{
				return i;
			}
		}
		return count;
	}

	private static int GetNextIndex(short[] array, int offset, int maxLength)
	{
		for (int i = 0; i < maxLength; i++)
		{
			if (array[offset + i] < 0)
			{
				return i;
			}
		}
		return maxLength;
	}
}
