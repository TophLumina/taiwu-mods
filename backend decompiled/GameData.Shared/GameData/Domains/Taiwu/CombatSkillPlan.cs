using System;
using System.Linq;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[SerializableGameData(NotForDisplayModule = true)]
public class CombatSkillPlan : ISerializableGameData
{
	public const int MaxPlanCount = 9;

	[SerializableGameDataField]
	public short[] NeigongList = new short[9];

	[SerializableGameDataField]
	public short[] AttackSkillList = new short[9];

	[SerializableGameDataField]
	public short[] AgilitySkillList = new short[9];

	[SerializableGameDataField]
	public short[] DefenseSkillList = new short[9];

	[SerializableGameDataField]
	public short[] AssistanceSkillList = new short[9];

	[SerializableGameDataField]
	public byte[] GenericGridAllocation = new byte[4];

	public CombatSkillPlan()
	{
		Reset();
	}

	public void Reset()
	{
		for (int i = 0; i < NeigongList.Length; i++)
		{
			NeigongList[i] = -1;
		}
		for (int j = 0; j < AttackSkillList.Length; j++)
		{
			AttackSkillList[j] = -1;
		}
		for (int k = 0; k < AgilitySkillList.Length; k++)
		{
			AgilitySkillList[k] = -1;
		}
		for (int l = 0; l < DefenseSkillList.Length; l++)
		{
			DefenseSkillList[l] = -1;
		}
		for (int m = 0; m < AssistanceSkillList.Length; m++)
		{
			AssistanceSkillList[m] = -1;
		}
	}

	public void CopyFrom(CombatSkillPlan plan)
	{
		NeigongList = CopyArray(plan.NeigongList, NeigongList);
		AttackSkillList = CopyArray(plan.AttackSkillList, AttackSkillList);
		AgilitySkillList = CopyArray(plan.AgilitySkillList, AgilitySkillList);
		DefenseSkillList = CopyArray(plan.DefenseSkillList, DefenseSkillList);
		AssistanceSkillList = CopyArray(plan.AssistanceSkillList, AssistanceSkillList);
	}

	private short[] CopyArray(short[] srcArray, short[] dstArray)
	{
		if (srcArray.Length == dstArray.Length)
		{
			Array.Copy(srcArray, dstArray, srcArray.Length);
		}
		else
		{
			dstArray = srcArray.ToArray();
		}
		return dstArray;
	}

	public void Record(short[] skillIdList)
	{
		for (sbyte type = 0; type < 5; type++)
		{
			short[] skillList = GetSkillList(type);
			for (sbyte i = 0; i < skillList.Length; i++)
			{
				skillList[i] = (short)((i < CombatSkillHelper.MaxSlotCounts[type]) ? CombatSkillHelper.GetEquippedSkill(skillIdList, type, i) : (-1));
			}
		}
	}

	public bool Equal(short[] skillIdList)
	{
		for (sbyte type = 0; type < 5; type++)
		{
			short[] skillList = GetSkillList(type);
			for (sbyte i = 0; i < skillList.Length; i++)
			{
				if (skillList[i] != CombatSkillHelper.GetEquippedSkill(skillIdList, type, i))
				{
					return false;
				}
			}
		}
		return true;
	}

	public short[] GetSkillList(sbyte type)
	{
		return type switch
		{
			0 => NeigongList, 
			1 => AttackSkillList, 
			2 => AgilitySkillList, 
			3 => DefenseSkillList, 
			4 => AssistanceSkillList, 
			_ => null, 
		};
	}

	public void EnsureSkillListCapacity(sbyte type, int capacity)
	{
		short[] collection = new short[capacity + 1];
		Array.Fill(collection, (short)(-1));
		switch (type)
		{
		case 0:
			NeigongList.CopyTo(collection, 0);
			NeigongList = collection;
			break;
		case 1:
			AttackSkillList.CopyTo(collection, 0);
			AttackSkillList = collection;
			break;
		case 2:
			AgilitySkillList.CopyTo(collection, 0);
			AgilitySkillList = collection;
			break;
		case 3:
			DefenseSkillList.CopyTo(collection, 0);
			DefenseSkillList = collection;
			break;
		case 4:
			AssistanceSkillList.CopyTo(collection, 0);
			AssistanceSkillList = collection;
			break;
		default:
			throw new ArgumentException($"Unrecognized equip type {type}");
		}
	}

	public CombatSkillPlan(CombatSkillPlan other)
	{
		short[] item = other.NeigongList;
		int elementsCount = item.Length;
		NeigongList = new short[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			NeigongList[i] = item[i];
		}
		short[] item2 = other.AttackSkillList;
		int elementsCount2 = item2.Length;
		AttackSkillList = new short[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			AttackSkillList[j] = item2[j];
		}
		short[] item3 = other.AgilitySkillList;
		int elementsCount3 = item3.Length;
		AgilitySkillList = new short[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			AgilitySkillList[k] = item3[k];
		}
		short[] item4 = other.DefenseSkillList;
		int elementsCount4 = item4.Length;
		DefenseSkillList = new short[elementsCount4];
		for (int l = 0; l < elementsCount4; l++)
		{
			DefenseSkillList[l] = item4[l];
		}
		short[] item5 = other.AssistanceSkillList;
		int elementsCount5 = item5.Length;
		AssistanceSkillList = new short[elementsCount5];
		for (int m = 0; m < elementsCount5; m++)
		{
			AssistanceSkillList[m] = item5[m];
		}
		byte[] item6 = other.GenericGridAllocation;
		int elementsCount6 = item6.Length;
		GenericGridAllocation = new byte[elementsCount6];
		for (int n = 0; n < elementsCount6; n++)
		{
			GenericGridAllocation[n] = item6[n];
		}
	}

	public void Assign(CombatSkillPlan other)
	{
		short[] item = other.NeigongList;
		int elementsCount = item.Length;
		NeigongList = new short[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			NeigongList[i] = item[i];
		}
		short[] item2 = other.AttackSkillList;
		int elementsCount2 = item2.Length;
		AttackSkillList = new short[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			AttackSkillList[j] = item2[j];
		}
		short[] item3 = other.AgilitySkillList;
		int elementsCount3 = item3.Length;
		AgilitySkillList = new short[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			AgilitySkillList[k] = item3[k];
		}
		short[] item4 = other.DefenseSkillList;
		int elementsCount4 = item4.Length;
		DefenseSkillList = new short[elementsCount4];
		for (int l = 0; l < elementsCount4; l++)
		{
			DefenseSkillList[l] = item4[l];
		}
		short[] item5 = other.AssistanceSkillList;
		int elementsCount5 = item5.Length;
		AssistanceSkillList = new short[elementsCount5];
		for (int m = 0; m < elementsCount5; m++)
		{
			AssistanceSkillList[m] = item5[m];
		}
		byte[] item6 = other.GenericGridAllocation;
		int elementsCount6 = item6.Length;
		GenericGridAllocation = new byte[elementsCount6];
		for (int n = 0; n < elementsCount6; n++)
		{
			GenericGridAllocation[n] = item6[n];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((NeigongList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * NeigongList.Length)));
		totalSize = ((AttackSkillList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * AttackSkillList.Length)));
		totalSize = ((AgilitySkillList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * AgilitySkillList.Length)));
		totalSize = ((DefenseSkillList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * DefenseSkillList.Length)));
		totalSize = ((AssistanceSkillList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * AssistanceSkillList.Length)));
		totalSize = ((GenericGridAllocation == null) ? (totalSize + 2) : (totalSize + (2 + GenericGridAllocation.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (NeigongList != null)
		{
			int elementsCount = NeigongList.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = NeigongList[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (AttackSkillList != null)
		{
			int elementsCount2 = AttackSkillList.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((short*)pCurrData)[j] = AttackSkillList[j];
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (AgilitySkillList != null)
		{
			int elementsCount3 = AgilitySkillList.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = AgilitySkillList[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (DefenseSkillList != null)
		{
			int elementsCount4 = DefenseSkillList.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				((short*)pCurrData)[l] = DefenseSkillList[l];
			}
			pCurrData += 2 * elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (AssistanceSkillList != null)
		{
			int elementsCount5 = AssistanceSkillList.Length;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				((short*)pCurrData)[m] = AssistanceSkillList[m];
			}
			pCurrData += 2 * elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GenericGridAllocation != null)
		{
			int elementsCount6 = GenericGridAllocation.Length;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				pCurrData[n] = GenericGridAllocation[n];
			}
			pCurrData += elementsCount6;
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
			if (NeigongList == null || NeigongList.Length != elementsCount)
			{
				NeigongList = new short[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				NeigongList[i] = ((short*)pCurrData)[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			NeigongList = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (AttackSkillList == null || AttackSkillList.Length != elementsCount2)
			{
				AttackSkillList = new short[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				AttackSkillList[j] = ((short*)pCurrData)[j];
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			AttackSkillList = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (AgilitySkillList == null || AgilitySkillList.Length != elementsCount3)
			{
				AgilitySkillList = new short[elementsCount3];
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				AgilitySkillList[k] = ((short*)pCurrData)[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			AgilitySkillList = null;
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (DefenseSkillList == null || DefenseSkillList.Length != elementsCount4)
			{
				DefenseSkillList = new short[elementsCount4];
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				DefenseSkillList[l] = ((short*)pCurrData)[l];
			}
			pCurrData += 2 * elementsCount4;
		}
		else
		{
			DefenseSkillList = null;
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (AssistanceSkillList == null || AssistanceSkillList.Length != elementsCount5)
			{
				AssistanceSkillList = new short[elementsCount5];
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				AssistanceSkillList[m] = ((short*)pCurrData)[m];
			}
			pCurrData += 2 * elementsCount5;
		}
		else
		{
			AssistanceSkillList = null;
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (GenericGridAllocation == null || GenericGridAllocation.Length != elementsCount6)
			{
				GenericGridAllocation = new byte[elementsCount6];
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				GenericGridAllocation[n] = pCurrData[n];
			}
			pCurrData += (int)elementsCount6;
		}
		else
		{
			GenericGridAllocation = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
