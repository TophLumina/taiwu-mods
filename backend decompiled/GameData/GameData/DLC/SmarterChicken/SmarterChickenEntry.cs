using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Chicken;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Building;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.DLC.SmarterChicken;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SmarterChickenEntry : IDlcEntry, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort EnabledChickensLegacy = 0;

		public const ushort ChickenHappinessDecayDelay = 1;

		public const ushort CombatChickenPreset = 2;

		public const ushort AllowChickenInCombat = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "EnabledChickensLegacy", "ChickenHappinessDecayDelay", "CombatChickenPreset", "AllowChickenInCombat" };
	}

	[Obsolete("This field is obsolete, use CombatChickenPreset instead.")]
	[SerializableGameDataField(FieldIndex = 0)]
	public List<short> EnabledChickensLegacy;

	[SerializableGameDataField(FieldIndex = 1)]
	public Dictionary<int, int> ChickenHappinessDecayDelay;

	[SerializableGameDataField(FieldIndex = 2)]
	public CombatChickenPreset CombatChickenPreset;

	[SerializableGameDataField(FieldIndex = 3)]
	public bool AllowChickenInCombat = true;

	private IReadOnlyList<short> EnabledChickens => CombatChickenPreset.CurrentPreset?.EnabledChickens;

	public void OnLoadedArchiveData(bool firstEnable)
	{
		if (CombatChickenPreset == null)
		{
			CombatChickenPreset = new CombatChickenPreset();
		}
		List<short> enabledChickensLegacy = EnabledChickensLegacy;
		if (enabledChickensLegacy != null && enabledChickensLegacy.Count > 0)
		{
			CombatChickenPreset.OverwritePreset(new CombatChickenPresetItem
			{
				EnabledChickens = EnabledChickensLegacy
			}, 0);
		}
		EnabledChickensLegacy = null;
	}

	public void OnEnterNewWorld()
	{
		if (CombatChickenPreset == null)
		{
			CombatChickenPreset = new CombatChickenPreset();
		}
	}

	public void OnPostAdvanceMonth(DataContext context)
	{
		DomainManager.Building.InvokeSmarterChickenMonthlyFeatherGift(context);
		DomainManager.Building.InvokeSmarterChickenMonthlyAdoptChicken(context);
		DomainManager.Building.InvokeWaitForReturnSmarterChickenMonthlyEvent();
		if (DomainManager.Building.IsHaveChickenKing())
		{
			EventArgBox argBox = DomainManager.Extra.GetOrCreateDlcArgBox(4975570uL, context);
			if (!argBox.GetBool("KingMonthlyEventInvoked"))
			{
				MonthlyEventCollection monthlyEvent = DomainManager.World.GetMonthlyEventCollection();
				monthlyEvent.AddDLCSmarterChickenKingBecomeHuman();
			}
		}
	}

	public void OnCrossArchive(DataContext context, IDlcEntry entryBeforeCrossArchive)
	{
		if (entryBeforeCrossArchive is SmarterChickenEntry entry)
		{
			CombatChickenPreset = entry.CombatChickenPreset;
			AllowChickenInCombat = entry.AllowChickenInCombat;
		}
	}

	public bool CheckChickenHappinessDecayDelay(DataContext context, int chickenId)
	{
		DlcId? dlcId = DlcManager.GetDlcIdByAppId(4975570uL);
		if (!dlcId.HasValue)
		{
			return false;
		}
		if (!DomainManager.Building.IsAliveSmarterChicken(chickenId))
		{
			return false;
		}
		if (ChickenHappinessDecayDelay == null)
		{
			ChickenHappinessDecayDelay = new Dictionary<int, int>();
		}
		ChickenHappinessDecayDelay.Accumulate(chickenId);
		bool delay = ChickenHappinessDecayDelay[chickenId] < 3;
		if (!delay)
		{
			ChickenHappinessDecayDelay.Remove(chickenId);
		}
		DomainManager.Extra.SetDlcEntry(context, dlcId.Value, this);
		return delay;
	}

	public void ResetChickenHappinessDecayDelay(DataContext context, int chickenId)
	{
		DlcId? dlcId = DlcManager.GetDlcIdByAppId(4975570uL);
		if (dlcId.HasValue && ChickenHappinessDecayDelay != null && ChickenHappinessDecayDelay.Remove(chickenId))
		{
			DomainManager.Extra.SetDlcEntry(context, dlcId.Value, this);
		}
	}

	public int InitializePendingPoints(IList<ChickenPointRuntime> pending, IRandomSource random)
	{
		int id = 0;
		if (!AllowChickenInCombat || !DomainManager.Building.IsHaveChickenKing())
		{
			return id;
		}
		foreach (GameData.Domains.Building.Chicken chicken in DomainManager.Building.GetTaiwuVillageChickens())
		{
			if (EnabledChickens != null && EnabledChickens.Contains(chicken.TemplateId))
			{
				ChickenItem config = Config.Chicken.Instance[chicken.TemplateId];
				pending.Add(new ChickenPointRuntime(id++, new ChickenPoint(config.PersonalityType, config.Grade + 1)));
			}
		}
		for (; id < GlobalConfig.Instance.MaxPendingChickenCount; id++)
		{
			int value = random.Next(0, 9) + 1;
			pending.Add(new ChickenPointRuntime(id, new ChickenPoint(sbyte.MaxValue, value)));
		}
		return id;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((EnabledChickensLegacy == null) ? (totalSize + 2) : (totalSize + (2 + 2 * EnabledChickensLegacy.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(ChickenHappinessDecayDelay);
		totalSize = ((CombatChickenPreset == null) ? (totalSize + 2) : (totalSize + (2 + CombatChickenPreset.GetSerializedSize())));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 4;
		pCurrData += 2;
		if (EnabledChickensLegacy != null)
		{
			int elementsCount = EnabledChickensLegacy.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = EnabledChickensLegacy[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref ChickenHappinessDecayDelay);
		if (CombatChickenPreset != null)
		{
			byte* pSubDataCount = pCurrData;
			pCurrData += 2;
			int fieldSize = CombatChickenPreset.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)pSubDataCount = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (AllowChickenInCombat ? ((byte)1) : ((byte)0));
		pCurrData++;
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
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (EnabledChickensLegacy == null)
				{
					EnabledChickensLegacy = new List<short>(elementsCount);
				}
				else
				{
					EnabledChickensLegacy.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					EnabledChickensLegacy.Add(((short*)pCurrData)[i]);
				}
				pCurrData += 2 * elementsCount;
			}
			else
			{
				EnabledChickensLegacy?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref ChickenHappinessDecayDelay);
		}
		if (fieldCount > 2)
		{
			ushort fieldSize = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize > 0)
			{
				if (CombatChickenPreset == null)
				{
					CombatChickenPreset = new CombatChickenPreset();
				}
				pCurrData += CombatChickenPreset.Deserialize(pCurrData);
			}
			else
			{
				CombatChickenPreset = null;
			}
		}
		if (fieldCount > 3)
		{
			AllowChickenInCombat = *pCurrData != 0;
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
