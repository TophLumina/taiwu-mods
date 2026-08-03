using System;
using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true)]
public class CharacterCombatSkillConfiguration : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CurrentPlanId = 0;

		public const ushort CombatSkillEquipPlans = 1;

		public const ushort CombatSkillMasterPlans = 2;

		public const ushort IsCombatSkillLocked = 3;

		public const ushort IsCombatSkillAttainmentLocked = 4;

		public const ushort IsNeiliAllocationLocked = 5;

		public const ushort NeiliAllocation = 6;

		public const ushort CombatSkillAttainmentPanels = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "CurrentPlanId", "CombatSkillEquipPlans", "CombatSkillMasterPlans", "IsCombatSkillLocked", "IsCombatSkillAttainmentLocked", "IsNeiliAllocationLocked", "NeiliAllocation", "CombatSkillAttainmentPanels" };
	}

	[SerializableGameDataField]
	public int CurrentPlanId;

	[SerializableGameDataField]
	public bool IsCombatSkillLocked;

	[SerializableGameDataField]
	public List<CombatSkillPlan> CombatSkillEquipPlans;

	[SerializableGameDataField]
	public List<ShortList> CombatSkillMasterPlans;

	[SerializableGameDataField]
	public bool IsCombatSkillAttainmentLocked;

	[SerializableGameDataField]
	public bool IsNeiliAllocationLocked;

	[SerializableGameDataField]
	public NeiliAllocation NeiliAllocation;

	[SerializableGameDataField]
	public short[] CombatSkillAttainmentPanels;

	public int PlanCount => CombatSkillEquipPlans?.Count ?? 0;

	public CombatSkillPlan CurrentEquipPlan => CombatSkillEquipPlans[CurrentPlanId];

	public ShortList CurrentMasterPlan => CombatSkillMasterPlans[CurrentPlanId];

	public void OfflineRecordNeiliAllocation(GameData.Domains.Character.Character character)
	{
		NeiliAllocation = character.GetBaseNeiliAllocation();
	}

	public void OfflineRecordCombatSkillAttainmentPanels(GameData.Domains.Character.Character character)
	{
		short[] panels = character.GetCombatSkillAttainmentPanels();
		if (CombatSkillAttainmentPanels == null)
		{
			CombatSkillAttainmentPanels = new short[panels.Length];
		}
		CombatSkillAttainmentPanelsHelper.CopyAll(panels, CombatSkillAttainmentPanels);
	}

	public void OfflineRecordCombatSkillPlan(GameData.Domains.Character.Character character, int targetPlanId)
	{
		ShortList masteredSkills = DomainManager.Extra.GetCharacterMasteredCombatSkills(character.GetId());
		if (targetPlanId >= PlanCount)
		{
			OfflineUpdateMaxPlanCount(targetPlanId + 1);
		}
		CombatSkillEquipPlans[targetPlanId].Record(character);
		CombatSkillMasterPlans[targetPlanId] = new ShortList(masteredSkills);
	}

	public void OfflineDeleteCombatSkillPlan(int planId)
	{
		int lastPlanId = PlanCount - 1;
		if (lastPlanId <= 0)
		{
			throw new InvalidOperationException("Deleting the only plan is not allowed.");
		}
		for (int i = planId; i < lastPlanId; i++)
		{
			int nextPlanId = planId + 1;
			CombatSkillEquipPlans[planId] = CombatSkillEquipPlans[nextPlanId];
			CombatSkillMasterPlans[planId] = CombatSkillMasterPlans[nextPlanId];
		}
		CombatSkillEquipPlans.RemoveAt(lastPlanId);
		CombatSkillMasterPlans.RemoveAt(lastPlanId);
		if (CurrentPlanId >= lastPlanId)
		{
			CurrentPlanId = lastPlanId - 1;
		}
	}

	public void OfflineUpdateMaxPlanCount(int count)
	{
		if (CombatSkillEquipPlans == null)
		{
			CombatSkillEquipPlans = new List<CombatSkillPlan>();
		}
		for (int i = CombatSkillEquipPlans.Count; i < count; i++)
		{
			CombatSkillEquipPlans.Add(new CombatSkillPlan());
		}
		if (CombatSkillMasterPlans == null)
		{
			CombatSkillMasterPlans = new List<ShortList>();
		}
		for (int j = CombatSkillMasterPlans.Count; j < count; j++)
		{
			CombatSkillMasterPlans.Add(ShortList.Create());
		}
	}

	public CharacterCombatSkillConfiguration(GameData.Domains.Character.Character character)
	{
		OfflineUpdateMaxPlanCount(3);
		OfflineRecordCombatSkillPlan(character, 0);
		OfflineRecordNeiliAllocation(character);
		OfflineRecordCombatSkillAttainmentPanels(character);
	}

	public CharacterCombatSkillConfiguration()
	{
	}

	public CharacterCombatSkillConfiguration(CharacterCombatSkillConfiguration other)
	{
		CurrentPlanId = other.CurrentPlanId;
		if (other.CombatSkillEquipPlans != null)
		{
			List<CombatSkillPlan> item = other.CombatSkillEquipPlans;
			int elementsCount = item.Count;
			CombatSkillEquipPlans = new List<CombatSkillPlan>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				CombatSkillEquipPlans.Add(new CombatSkillPlan(item[i]));
			}
		}
		else
		{
			CombatSkillEquipPlans = null;
		}
		if (other.CombatSkillMasterPlans != null)
		{
			List<ShortList> item2 = other.CombatSkillMasterPlans;
			int elementsCount2 = item2.Count;
			CombatSkillMasterPlans = new List<ShortList>(elementsCount2);
			for (int j = 0; j < elementsCount2; j++)
			{
				CombatSkillMasterPlans.Add(new ShortList(item2[j]));
			}
		}
		else
		{
			CombatSkillMasterPlans = null;
		}
		IsCombatSkillLocked = other.IsCombatSkillLocked;
		IsCombatSkillAttainmentLocked = other.IsCombatSkillAttainmentLocked;
		IsNeiliAllocationLocked = other.IsNeiliAllocationLocked;
		NeiliAllocation = other.NeiliAllocation;
		short[] item3 = other.CombatSkillAttainmentPanels;
		int elementsCount3 = item3.Length;
		CombatSkillAttainmentPanels = new short[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			CombatSkillAttainmentPanels[k] = item3[k];
		}
	}

	public void Assign(CharacterCombatSkillConfiguration other)
	{
		CurrentPlanId = other.CurrentPlanId;
		if (other.CombatSkillEquipPlans != null)
		{
			List<CombatSkillPlan> item = other.CombatSkillEquipPlans;
			int elementsCount = item.Count;
			CombatSkillEquipPlans = new List<CombatSkillPlan>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				CombatSkillEquipPlans.Add(new CombatSkillPlan(item[i]));
			}
		}
		else
		{
			CombatSkillEquipPlans = null;
		}
		if (other.CombatSkillMasterPlans != null)
		{
			List<ShortList> item2 = other.CombatSkillMasterPlans;
			int elementsCount2 = item2.Count;
			CombatSkillMasterPlans = new List<ShortList>(elementsCount2);
			for (int j = 0; j < elementsCount2; j++)
			{
				CombatSkillMasterPlans.Add(new ShortList(item2[j]));
			}
		}
		else
		{
			CombatSkillMasterPlans = null;
		}
		IsCombatSkillLocked = other.IsCombatSkillLocked;
		IsCombatSkillAttainmentLocked = other.IsCombatSkillAttainmentLocked;
		IsNeiliAllocationLocked = other.IsNeiliAllocationLocked;
		NeiliAllocation = other.NeiliAllocation;
		short[] item3 = other.CombatSkillAttainmentPanels;
		int elementsCount3 = item3.Length;
		CombatSkillAttainmentPanels = new short[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			CombatSkillAttainmentPanels[k] = item3[k];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 17;
		if (CombatSkillEquipPlans != null)
		{
			totalSize += 2;
			int elementsCount = CombatSkillEquipPlans.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				CombatSkillPlan element = CombatSkillEquipPlans[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (CombatSkillMasterPlans != null)
		{
			totalSize += 2;
			int elementsCount2 = CombatSkillMasterPlans.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				totalSize += CombatSkillMasterPlans[j].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((CombatSkillAttainmentPanels == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CombatSkillAttainmentPanels.Length)));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 8;
		pCurrData += 2;
		*(int*)pCurrData = CurrentPlanId;
		pCurrData += 4;
		if (CombatSkillEquipPlans != null)
		{
			int elementsCount = CombatSkillEquipPlans.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				CombatSkillPlan element = CombatSkillEquipPlans[i];
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
		if (CombatSkillMasterPlans != null)
		{
			int elementsCount2 = CombatSkillMasterPlans.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				int subDataSize2 = CombatSkillMasterPlans[j].Serialize(pCurrData);
				pCurrData += subDataSize2;
				Tester.Assert(subDataSize2 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsCombatSkillLocked ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsCombatSkillAttainmentLocked ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsNeiliAllocationLocked ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += NeiliAllocation.Serialize(pCurrData);
		if (CombatSkillAttainmentPanels != null)
		{
			int elementsCount3 = CombatSkillAttainmentPanels.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = CombatSkillAttainmentPanels[k];
			}
			pCurrData += 2 * elementsCount3;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			CurrentPlanId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (CombatSkillEquipPlans == null)
				{
					CombatSkillEquipPlans = new List<CombatSkillPlan>(elementsCount);
				}
				else
				{
					CombatSkillEquipPlans.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort subDataCount = *(ushort*)pCurrData;
					pCurrData += 2;
					if (subDataCount > 0)
					{
						CombatSkillPlan element = new CombatSkillPlan();
						pCurrData += element.Deserialize(pCurrData);
						CombatSkillEquipPlans.Add(element);
					}
					else
					{
						CombatSkillEquipPlans.Add(null);
					}
				}
			}
			else
			{
				CombatSkillEquipPlans?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (CombatSkillMasterPlans == null)
				{
					CombatSkillMasterPlans = new List<ShortList>(elementsCount2);
				}
				else
				{
					CombatSkillMasterPlans.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					ShortList element2 = default(ShortList);
					pCurrData += element2.Deserialize(pCurrData);
					CombatSkillMasterPlans.Add(element2);
				}
			}
			else
			{
				CombatSkillMasterPlans?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			IsCombatSkillLocked = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 4)
		{
			IsCombatSkillAttainmentLocked = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 5)
		{
			IsNeiliAllocationLocked = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 6)
		{
			pCurrData += NeiliAllocation.Deserialize(pCurrData);
		}
		if (fieldCount > 7)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (CombatSkillAttainmentPanels == null || CombatSkillAttainmentPanels.Length != elementsCount3)
				{
					CombatSkillAttainmentPanels = new short[elementsCount3];
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					CombatSkillAttainmentPanels[k] = ((short*)pCurrData)[k];
				}
				pCurrData += 2 * elementsCount3;
			}
			else
			{
				CombatSkillAttainmentPanels = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
