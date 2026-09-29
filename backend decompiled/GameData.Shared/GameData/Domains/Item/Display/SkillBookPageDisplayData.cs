using System;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Item.Display;

[AutoGenerateSerializableGameData]
public class SkillBookPageDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public ItemKey ItemKey;

	[SerializableGameDataField]
	public sbyte[] State;

	[SerializableGameDataField]
	public sbyte[] ReadingProgress;

	[SerializableGameDataField]
	public sbyte[] Type;

	[SerializableGameDataField]
	public sbyte[] CombatSkillAllReadingProgress;

	public bool IsCombatBook => ItemTemplateHelper.GetItemSubType(ItemKey.ItemType, ItemKey.TemplateId) == 1001;

	public bool CanFix()
	{
		bool canFix = false;
		for (int i = 0; i < State.Length; i++)
		{
			if (State[i] == 1 || State[i] == 2)
			{
				canFix = true;
				break;
			}
		}
		return canFix;
	}

	public (sbyte pageNum, short needProgress) GetFixProgress()
	{
		sbyte grade = ItemTemplateHelper.GetGrade(ItemKey.ItemType, ItemKey.TemplateId);
		short needProgress = GlobalConfig.Instance.FixBookTotalProgress[grade];
		sbyte incompletePage = -1;
		for (sbyte i = 0; i < State.Length; i++)
		{
			if (State[i] == 1)
			{
				incompletePage = i;
				break;
			}
			if (State[i] == 2)
			{
				incompletePage = i;
				needProgress *= 3;
				break;
			}
		}
		needProgress = Math.Min(short.MaxValue, needProgress);
		return (pageNum: incompletePage, needProgress: needProgress);
	}

	public SkillBookPageDisplayData()
	{
	}

	public SkillBookPageDisplayData(SkillBookPageDisplayData other)
	{
		ItemKey = other.ItemKey;
		sbyte[] item = other.State;
		int elementsCount = item.Length;
		State = new sbyte[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			State[i] = item[i];
		}
		sbyte[] item2 = other.ReadingProgress;
		int elementsCount2 = item2.Length;
		ReadingProgress = new sbyte[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			ReadingProgress[j] = item2[j];
		}
		sbyte[] item3 = other.Type;
		int elementsCount3 = item3.Length;
		Type = new sbyte[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			Type[k] = item3[k];
		}
		sbyte[] item4 = other.CombatSkillAllReadingProgress;
		int elementsCount4 = item4.Length;
		CombatSkillAllReadingProgress = new sbyte[elementsCount4];
		for (int l = 0; l < elementsCount4; l++)
		{
			CombatSkillAllReadingProgress[l] = item4[l];
		}
	}

	public void Assign(SkillBookPageDisplayData other)
	{
		ItemKey = other.ItemKey;
		sbyte[] item = other.State;
		int elementsCount = item.Length;
		State = new sbyte[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			State[i] = item[i];
		}
		sbyte[] item2 = other.ReadingProgress;
		int elementsCount2 = item2.Length;
		ReadingProgress = new sbyte[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			ReadingProgress[j] = item2[j];
		}
		sbyte[] item3 = other.Type;
		int elementsCount3 = item3.Length;
		Type = new sbyte[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			Type[k] = item3[k];
		}
		sbyte[] item4 = other.CombatSkillAllReadingProgress;
		int elementsCount4 = item4.Length;
		CombatSkillAllReadingProgress = new sbyte[elementsCount4];
		for (int l = 0; l < elementsCount4; l++)
		{
			CombatSkillAllReadingProgress[l] = item4[l];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize = ((State == null) ? (totalSize + 2) : (totalSize + (2 + State.Length)));
		totalSize = ((ReadingProgress == null) ? (totalSize + 2) : (totalSize + (2 + ReadingProgress.Length)));
		totalSize = ((Type == null) ? (totalSize + 2) : (totalSize + (2 + Type.Length)));
		totalSize = ((CombatSkillAllReadingProgress == null) ? (totalSize + 2) : (totalSize + (2 + CombatSkillAllReadingProgress.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += ItemKey.Serialize(pCurrData);
		if (State != null)
		{
			int elementsCount = State.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = (byte)State[i];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ReadingProgress != null)
		{
			int elementsCount2 = ReadingProgress.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*pCurrData = (byte)ReadingProgress[j];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Type != null)
		{
			int elementsCount3 = Type.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				*pCurrData = (byte)Type[k];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CombatSkillAllReadingProgress != null)
		{
			int elementsCount4 = CombatSkillAllReadingProgress.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				*pCurrData = (byte)CombatSkillAllReadingProgress[l];
				pCurrData++;
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
		pCurrData += ItemKey.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (State == null || State.Length != elementsCount)
			{
				State = new sbyte[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				State[i] = (sbyte)(*pCurrData);
				pCurrData++;
			}
		}
		else
		{
			State = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (ReadingProgress == null || ReadingProgress.Length != elementsCount2)
			{
				ReadingProgress = new sbyte[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ReadingProgress[j] = (sbyte)(*pCurrData);
				pCurrData++;
			}
		}
		else
		{
			ReadingProgress = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (Type == null || Type.Length != elementsCount3)
			{
				Type = new sbyte[elementsCount3];
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				Type[k] = (sbyte)(*pCurrData);
				pCurrData++;
			}
		}
		else
		{
			Type = null;
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (CombatSkillAllReadingProgress == null || CombatSkillAllReadingProgress.Length != elementsCount4)
			{
				CombatSkillAllReadingProgress = new sbyte[elementsCount4];
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				CombatSkillAllReadingProgress[l] = (sbyte)(*pCurrData);
				pCurrData++;
			}
		}
		else
		{
			CombatSkillAllReadingProgress = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
