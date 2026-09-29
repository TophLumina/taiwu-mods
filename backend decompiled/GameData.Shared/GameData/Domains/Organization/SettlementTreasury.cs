using System;
using System.Collections.Generic;
using System.Diagnostics;
using Config;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Organization;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class SettlementTreasury : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort GuardIds = 0;

		public const ushort TemplateGuardIds = 1;

		public const ushort Resources = 2;

		public const ushort LovingItemSubTypes = 3;

		public const ushort HatingItemSubTypes = 4;

		public const ushort Contributions = 5;

		public const ushort Inventory = 6;

		public const ushort LayerIndex = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "GuardIds", "TemplateGuardIds", "Resources", "LovingItemSubTypes", "HatingItemSubTypes", "Contributions", "Inventory", "LayerIndex" };
	}

	[SerializableGameDataField]
	public CharacterSet GuardIds;

	[SerializableGameDataField]
	public List<short> TemplateGuardIds = new List<short>();

	[SerializableGameDataField]
	public ResourceInts Resources;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public Inventory Inventory = new Inventory();

	[SerializableGameDataField]
	public List<short> LovingItemSubTypes = new List<short>();

	[SerializableGameDataField]
	public List<short> HatingItemSubTypes = new List<short>();

	[SerializableGameDataField]
	public Dictionary<int, int> Contributions = new Dictionary<int, int>();

	[SerializableGameDataField]
	public sbyte LayerIndex;

	public bool NeedCommit;

	private readonly Dictionary<int, int> _memberUsedPresetContributions = new Dictionary<int, int>();

	public int CalcBonusInfluencePower(int charId)
	{
		int contribution = Contributions.GetValueOrDefault(charId, 0);
		int accessoryValue = Accessory.Instance[(short)8].BaseValue;
		return 100 + MathUtils.Min(contribution * 10 / accessoryValue, 100);
	}

	public int CalcAdjustedWorth(short itemSubType, int worth)
	{
		if (LovingItemSubTypes.Contains(itemSubType))
		{
			return worth * 125 / 100;
		}
		if (HatingItemSubTypes.Contains(itemSubType))
		{
			return worth * 50 / 100;
		}
		return worth;
	}

	public int GetContribution(int charId)
	{
		if (!Contributions.TryGetValue(charId, out var contribution))
		{
			return 0;
		}
		return contribution;
	}

	public void DetectAndFixInvalidData()
	{
		for (sbyte resourceType = 0; resourceType < 8; resourceType++)
		{
			if (Resources[resourceType] < 0)
			{
				AdaptableLog.Warning($"Invalid resource amount for settlement treasury: type={resourceType},value={Resources[resourceType]}\n{new StackTrace()}", appendWarningMessage: true);
				Resources[resourceType] = 0;
			}
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 35;
		totalSize += GuardIds.GetSerializedSize();
		totalSize = ((TemplateGuardIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TemplateGuardIds.Count)));
		totalSize = ((LovingItemSubTypes == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LovingItemSubTypes.Count)));
		totalSize = ((HatingItemSubTypes == null) ? (totalSize + 2) : (totalSize + (2 + 2 * HatingItemSubTypes.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(Contributions);
		totalSize = ((Inventory == null) ? (totalSize + 4) : (totalSize + (4 + Inventory.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 8;
		pCurrData += 2;
		int fieldSize = GuardIds.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		if (TemplateGuardIds != null)
		{
			int elementsCount = TemplateGuardIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = TemplateGuardIds[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += Resources.Serialize(pCurrData);
		if (LovingItemSubTypes != null)
		{
			int elementsCount2 = LovingItemSubTypes.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((short*)pCurrData)[j] = LovingItemSubTypes[j];
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (HatingItemSubTypes != null)
		{
			int elementsCount3 = HatingItemSubTypes.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = HatingItemSubTypes[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref Contributions);
		if (Inventory != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 4;
			int fieldSize2 = Inventory.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= int.MaxValue);
			*(int*)intPtr = fieldSize2;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		*pCurrData = (byte)LayerIndex;
		pCurrData++;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			pCurrData += GuardIds.Deserialize(pCurrData);
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (TemplateGuardIds == null)
				{
					TemplateGuardIds = new List<short>(elementsCount);
				}
				else
				{
					TemplateGuardIds.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					TemplateGuardIds.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				TemplateGuardIds?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			pCurrData += Resources.Deserialize(pCurrData);
		}
		if (fieldCount > 3)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (LovingItemSubTypes == null)
				{
					LovingItemSubTypes = new List<short>(elementsCount2);
				}
				else
				{
					LovingItemSubTypes.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					LovingItemSubTypes.Add(((short*)pCurrData)[j]);
				}
				pCurrData += 2 * elementsCount2;
			}
			else
			{
				LovingItemSubTypes?.Clear();
			}
		}
		if (fieldCount > 4)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (HatingItemSubTypes == null)
				{
					HatingItemSubTypes = new List<short>(elementsCount3);
				}
				else
				{
					HatingItemSubTypes.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					HatingItemSubTypes.Add(((short*)pCurrData)[k]);
				}
				pCurrData += 2 * elementsCount3;
			}
			else
			{
				HatingItemSubTypes?.Clear();
			}
		}
		if (fieldCount > 5)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref Contributions);
		}
		if (fieldCount > 6)
		{
			int num = *(int*)pCurrData;
			pCurrData += 4;
			if (num > 0)
			{
				if (Inventory == null)
				{
					Inventory = new Inventory();
				}
				pCurrData += Inventory.Deserialize(pCurrData);
			}
			else
			{
				Inventory = null;
			}
		}
		if (fieldCount > 7)
		{
			LayerIndex = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public void ClearMemberUsedPresetContribution()
	{
		_memberUsedPresetContributions.Clear();
	}

	public int GetMemberContribution(int charId, OrganizationInfo orgInfo)
	{
		int presetContribution = orgInfo.GetOrgMemberConfig().ContributionPerMonth;
		int usedPresetContribution = _memberUsedPresetContributions.GetValueOrDefault(charId, 0);
		return Contributions.GetValueOrDefault(charId, 0) + presetContribution - usedPresetContribution;
	}

	public void OfflineChangeContribution(int charId, int presetContribution, int delta)
	{
		if (delta >= 0)
		{
			OfflineChanceActualContribution(charId, delta);
			return;
		}
		int prevAmount = _memberUsedPresetContributions.GetValueOrDefault(charId);
		int remainingAmount = presetContribution - prevAmount;
		if (remainingAmount + delta >= 0)
		{
			_memberUsedPresetContributions[charId] = prevAmount - delta;
			return;
		}
		OfflineChanceActualContribution(charId, remainingAmount + delta);
		_memberUsedPresetContributions[charId] = presetContribution;
	}

	private void OfflineChanceActualContribution(int charId, int delta)
	{
		if (Contributions.TryGetValue(charId, out var value))
		{
			Contributions[charId] = (int)Math.Clamp((long)value + (long)delta, -2147483648L, 2147483647L);
		}
		else
		{
			Contributions.Add(charId, Math.Clamp(delta, int.MinValue, int.MaxValue));
		}
	}
}
