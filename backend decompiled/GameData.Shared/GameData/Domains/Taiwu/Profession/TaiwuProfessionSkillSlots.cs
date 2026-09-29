using System.Collections.Generic;
using Config;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class TaiwuProfessionSkillSlots : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Slots = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "Slots" };
	}

	[SerializableGameDataField]
	public IntList[] Slots;

	public const int LevelCount = 4;

	public void Initialize()
	{
		Slots = new IntList[4];
		for (int i = 0; i < 4; i++)
		{
			IntList levelSlots = IntList.Create();
			int slotCount = 4 - i;
			for (int j = 0; j < slotCount; j++)
			{
				levelSlots.Items.Add(-1);
			}
			Slots[i] = levelSlots;
		}
	}

	public bool IsFull()
	{
		IntList[] slots = Slots;
		for (int i = 0; i < slots.Length; i++)
		{
			foreach (int item in slots[i].Items)
			{
				if (item < 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	public bool IsEquipped(int professionSkillId)
	{
		ProfessionSkillItem skillCfg = ProfessionSkill.Instance[professionSkillId];
		return Slots[skillCfg.Level - 1].Items.Contains(professionSkillId);
	}

	public bool IsEquipped(ProfessionSkillItem skillCfg)
	{
		return Slots[skillCfg.Level - 1].Items.Contains(skillCfg.TemplateId);
	}

	public IEnumerable<int> GetNewlyEquippedSkills(TaiwuProfessionSkillSlots newSlots)
	{
		for (int i = 0; i < 4; i++)
		{
			IntList oldLevelSlots = Slots[i];
			IntList newLevelSlots = newSlots.Slots[i];
			for (int j = 0; j < oldLevelSlots.Items.Count; j++)
			{
				if (oldLevelSlots.Items[j] == -1 && newLevelSlots.Items[j] != -1)
				{
					yield return newLevelSlots.Items[j];
				}
			}
		}
	}

	public IEnumerable<int> GetNewlyRemovedSkills(TaiwuProfessionSkillSlots newSlots)
	{
		for (int i = 0; i < 4; i++)
		{
			IntList oldLevelSlots = Slots[i];
			IntList newLevelSlots = newSlots.Slots[i];
			for (int j = 0; j < oldLevelSlots.Items.Count; j++)
			{
				if (oldLevelSlots.Items[j] != -1 && newLevelSlots.Items[j] == -1)
				{
					yield return oldLevelSlots.Items[j];
				}
			}
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (Slots != null)
		{
			totalSize += 2;
			int elementsCount = Slots.Length;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += Slots[i].GetSerializedSize();
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
		*(short*)pCurrData = 1;
		pCurrData += 2;
		if (Slots != null)
		{
			int elementsCount = Slots.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = Slots[i].Serialize(pCurrData);
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

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (Slots == null || Slots.Length != elementsCount)
				{
					Slots = new IntList[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					IntList element = default(IntList);
					pCurrData += element.Deserialize(pCurrData);
					Slots[i] = element;
				}
			}
			else
			{
				Slots = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
