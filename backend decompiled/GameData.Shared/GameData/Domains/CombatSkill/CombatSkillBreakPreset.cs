using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.CombatSkill;

[SerializableGameData(IsExtensible = true)]
public class CombatSkillBreakPreset : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CurrentIndex = 0;

		public const ushort Presets = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "CurrentIndex", "Presets" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int CurrentIndex;

	[SerializableGameDataField(FieldIndex = 1)]
	public List<CombatSkillBreakSnapshot> Presets;

	public bool AnySuccess
	{
		get
		{
			List<CombatSkillBreakSnapshot> presets = Presets;
			if (presets == null || presets.Count <= 0)
			{
				return false;
			}
			foreach (CombatSkillBreakSnapshot preset in Presets)
			{
				if (preset?.BreakPlate?.Success == true)
				{
					return true;
				}
			}
			return false;
		}
	}

	public CombatSkillBreakPreset()
	{
	}

	public CombatSkillBreakPreset(CombatSkillBreakPreset other)
	{
		CurrentIndex = other.CurrentIndex;
		if (other.Presets != null)
		{
			List<CombatSkillBreakSnapshot> item = other.Presets;
			int elementsCount = item.Count;
			Presets = new List<CombatSkillBreakSnapshot>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				Presets.Add(new CombatSkillBreakSnapshot(item[i]));
			}
		}
		else
		{
			Presets = null;
		}
	}

	public void Assign(CombatSkillBreakPreset other)
	{
		CurrentIndex = other.CurrentIndex;
		if (other.Presets != null)
		{
			List<CombatSkillBreakSnapshot> item = other.Presets;
			int elementsCount = item.Count;
			Presets = new List<CombatSkillBreakSnapshot>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				Presets.Add(new CombatSkillBreakSnapshot(item[i]));
			}
		}
		else
		{
			Presets = null;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (Presets != null)
		{
			totalSize += 2;
			int elementsCount = Presets.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				CombatSkillBreakSnapshot element = Presets[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
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
		*(short*)pCurrData = 2;
		pCurrData += 2;
		*(int*)pCurrData = CurrentIndex;
		pCurrData += 4;
		if (Presets != null)
		{
			int elementsCount = Presets.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				CombatSkillBreakSnapshot element = Presets[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
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
			CurrentIndex = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (Presets == null)
				{
					Presets = new List<CombatSkillBreakSnapshot>(elementsCount);
				}
				else
				{
					Presets.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num2 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num2 > 0)
					{
						CombatSkillBreakSnapshot element = new CombatSkillBreakSnapshot();
						pCurrData += element.Deserialize(pCurrData);
						Presets.Add(element);
					}
					else
					{
						Presets.Add(null);
					}
				}
			}
			else
			{
				Presets?.Clear();
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
