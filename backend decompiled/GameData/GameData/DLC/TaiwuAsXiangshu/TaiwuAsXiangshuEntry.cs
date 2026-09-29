using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.DLC.TaiwuAsXiangshu;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class TaiwuAsXiangshuEntry : IDlcEntry, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort TwelveImmortalsStatuses = 0;

		public const ushort PendingTwelveImmortalsPerformances = 1;

		public const ushort TaiwuAsXiangshuTowerFinalLayerEntered = 2;

		public const ushort TaiwuAsXiangshuTowerTiandiDefeatPerformancePlayed = 3;

		public const ushort TaiwuAsXiangshuTowerDemonHeartObtainedPerformancePlayed = 4;

		public const ushort PendingThreeRealmsPowerPerformances = 5;

		public const ushort ThreeRealmsPowerKillLocations = 6;

		public const ushort TwelveImmortalKillLocations = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "TwelveImmortalsStatuses", "PendingTwelveImmortalsPerformances", "TaiwuAsXiangshuTowerFinalLayerEntered", "TaiwuAsXiangshuTowerTiandiDefeatPerformancePlayed", "TaiwuAsXiangshuTowerDemonHeartObtainedPerformancePlayed", "PendingThreeRealmsPowerPerformances", "ThreeRealmsPowerKillLocations", "TwelveImmortalKillLocations" };
	}

	[SerializableGameDataField]
	public Dictionary<short, ETwelveImmortalsStatus> TwelveImmortalsStatuses = new Dictionary<short, ETwelveImmortalsStatus>();

	[SerializableGameDataField]
	public Dictionary<short, ETwelveImmortalsStatus> PendingTwelveImmortalsPerformances = new Dictionary<short, ETwelveImmortalsStatus>();

	[SerializableGameDataField]
	public bool TaiwuAsXiangshuTowerFinalLayerEntered;

	[SerializableGameDataField]
	public bool TaiwuAsXiangshuTowerTiandiDefeatPerformancePlayed;

	[SerializableGameDataField]
	public bool TaiwuAsXiangshuTowerDemonHeartObtainedPerformancePlayed;

	[SerializableGameDataField]
	public Dictionary<short, ETwelveImmortalsStatus> PendingThreeRealmsPowerPerformances = new Dictionary<short, ETwelveImmortalsStatus>();

	[SerializableGameDataField]
	public Dictionary<short, Location> ThreeRealmsPowerKillLocations = new Dictionary<short, Location>();

	[SerializableGameDataField]
	public Dictionary<short, Location> TwelveImmortalKillLocations = new Dictionary<short, Location>();

	public static TaiwuAsXiangshuEntry Instance
	{
		[return: MaybeNull]
		get
		{
			TaiwuAsXiangshuEntry data;
			return DomainManager.Extra.TryGetDlcEntry<TaiwuAsXiangshuEntry>(5093790uL, out data) ? data : null;
		}
	}

	public void OnLoadedArchiveData(bool firstEnable)
	{
		if (TwelveImmortalsStatuses == null)
		{
			TwelveImmortalsStatuses = new Dictionary<short, ETwelveImmortalsStatus>();
		}
		foreach (TwelveImmortalsItem immortal in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
		{
			TwelveImmortalsStatuses.TryAdd(immortal.Character, ETwelveImmortalsStatus.Default);
		}
		if (PendingTwelveImmortalsPerformances == null)
		{
			PendingTwelveImmortalsPerformances = new Dictionary<short, ETwelveImmortalsStatus>();
		}
		if (PendingThreeRealmsPowerPerformances == null)
		{
			PendingThreeRealmsPowerPerformances = new Dictionary<short, ETwelveImmortalsStatus>();
		}
		if (ThreeRealmsPowerKillLocations == null)
		{
			ThreeRealmsPowerKillLocations = new Dictionary<short, Location>();
		}
		if (TwelveImmortalKillLocations == null)
		{
			TwelveImmortalKillLocations = new Dictionary<short, Location>();
		}
	}

	public void OnEnterNewWorld()
	{
		foreach (TwelveImmortalsItem immortal in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
		{
			TwelveImmortalsStatuses[immortal.Character] = ETwelveImmortalsStatus.Default;
		}
		PendingTwelveImmortalsPerformances.Clear();
		PendingThreeRealmsPowerPerformances.Clear();
		ThreeRealmsPowerKillLocations.Clear();
		TwelveImmortalKillLocations.Clear();
		TaiwuAsXiangshuTowerFinalLayerEntered = false;
		TaiwuAsXiangshuTowerTiandiDefeatPerformancePlayed = false;
		TaiwuAsXiangshuTowerDemonHeartObtainedPerformancePlayed = false;
	}

	public void OnPostAdvanceMonth(DataContext context)
	{
	}

	public void OnCrossArchive(DataContext context, IDlcEntry entryBeforeCrossArchive)
	{
	}

	public ETwelveImmortalsStatus GetTwelveImmortalsStatus(short characterTemplateId)
	{
		ETwelveImmortalsStatus status;
		return TwelveImmortalsStatuses.TryGetValue(characterTemplateId, out status) ? status : ETwelveImmortalsStatus.Default;
	}

	public void SetTwelveImmortalsStatus(short characterTemplateId, ETwelveImmortalsStatus status)
	{
		ETwelveImmortalsStatus oldStatus = GetTwelveImmortalsStatus(characterTemplateId);
		TwelveImmortalsStatuses[characterTemplateId] = status;
		if (oldStatus == ETwelveImmortalsStatus.Default && status != ETwelveImmortalsStatus.Default)
		{
			if (PendingTwelveImmortalsPerformances == null)
			{
				PendingTwelveImmortalsPerformances = new Dictionary<short, ETwelveImmortalsStatus>();
			}
			PendingTwelveImmortalsPerformances[characterTemplateId] = status;
		}
	}

	public Dictionary<short, ETwelveImmortalsStatus> GetPendingTwelveImmortalsPerformances()
	{
		return PendingTwelveImmortalsPerformances ?? (PendingTwelveImmortalsPerformances = new Dictionary<short, ETwelveImmortalsStatus>());
	}

	public void ClearPendingTwelveImmortalsPerformance(short characterTemplateId)
	{
		PendingTwelveImmortalsPerformances?.Remove(characterTemplateId);
	}

	public Dictionary<short, ETwelveImmortalsStatus> GetPendingThreeRealmsPowerPerformances()
	{
		return PendingThreeRealmsPowerPerformances ?? (PendingThreeRealmsPowerPerformances = new Dictionary<short, ETwelveImmortalsStatus>());
	}

	public bool AddPendingThreeRealmsPowerPerformance(short characterTemplateId, ETwelveImmortalsStatus status)
	{
		if (PendingThreeRealmsPowerPerformances == null)
		{
			PendingThreeRealmsPowerPerformances = new Dictionary<short, ETwelveImmortalsStatus>();
		}
		if (PendingThreeRealmsPowerPerformances.ContainsKey(characterTemplateId))
		{
			return false;
		}
		PendingThreeRealmsPowerPerformances[characterTemplateId] = status;
		return true;
	}

	public void ClearPendingThreeRealmsPowerPerformance(short characterTemplateId)
	{
		PendingThreeRealmsPowerPerformances?.Remove(characterTemplateId);
	}

	public static void RecordThreeRealmsPowerKillLocation(DataContext context, short characterTemplateId, Location location)
	{
		if (!location.IsValid())
		{
			return;
		}
		DlcId? dlcId = DlcManager.GetDlcIdByAppId(5093790uL);
		if (dlcId.HasValue)
		{
			DlcId id = dlcId.GetValueOrDefault();
			TaiwuAsXiangshuEntry entry = Instance;
			if (entry != null)
			{
				entry.ThreeRealmsPowerKillLocations[TaiwuAsXiangshuTowerPerformanceHelper.GetPowerCharacterTemplateId(characterTemplateId)] = location;
				DomainManager.Extra.SetDlcEntry(context, id, entry);
			}
		}
	}

	public Location GetThreeRealmsPowerKillLocation(short characterTemplateId)
	{
		Location location;
		return ThreeRealmsPowerKillLocations.TryGetValue(TaiwuAsXiangshuTowerPerformanceHelper.GetPowerCharacterTemplateId(characterTemplateId), out location) ? location : Location.Invalid;
	}

	public static void RecordTwelveImmortalKillLocation(DataContext context, short characterTemplateId, Location location)
	{
		if (!location.IsValid())
		{
			return;
		}
		DlcId? dlcId = DlcManager.GetDlcIdByAppId(5093790uL);
		if (dlcId.HasValue)
		{
			DlcId id = dlcId.GetValueOrDefault();
			TaiwuAsXiangshuEntry entry = Instance;
			if (entry != null)
			{
				entry.TwelveImmortalKillLocations[characterTemplateId] = location;
				DomainManager.Extra.SetDlcEntry(context, id, entry);
			}
		}
	}

	public Location GetTwelveImmortalKillLocation(short characterTemplateId)
	{
		Location location;
		return TwelveImmortalKillLocations.TryGetValue(characterTemplateId, out location) ? location : Location.Invalid;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		totalSize += SerializationHelper.DictionaryAsBasicTypePair.GetSerializedSize<short, ETwelveImmortalsStatus, short, sbyte, Dictionary<short, ETwelveImmortalsStatus>>(TwelveImmortalsStatuses);
		totalSize += SerializationHelper.DictionaryAsBasicTypePair.GetSerializedSize<short, ETwelveImmortalsStatus, short, sbyte, Dictionary<short, ETwelveImmortalsStatus>>(PendingTwelveImmortalsPerformances);
		totalSize += SerializationHelper.DictionaryAsBasicTypePair.GetSerializedSize<short, ETwelveImmortalsStatus, short, sbyte, Dictionary<short, ETwelveImmortalsStatus>>(PendingThreeRealmsPowerPerformances);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(ThreeRealmsPowerKillLocations);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(TwelveImmortalKillLocations);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 8;
		pCurrData += 2;
		pCurrData += SerializationHelper.DictionaryAsBasicTypePair.Serialize(pCurrData, ref TwelveImmortalsStatuses, (short key) => key, (ETwelveImmortalsStatus value) => (sbyte)value);
		pCurrData += SerializationHelper.DictionaryAsBasicTypePair.Serialize(pCurrData, ref PendingTwelveImmortalsPerformances, (short key) => key, (ETwelveImmortalsStatus value) => (sbyte)value);
		*pCurrData = (TaiwuAsXiangshuTowerFinalLayerEntered ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (TaiwuAsXiangshuTowerTiandiDefeatPerformancePlayed ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (TaiwuAsXiangshuTowerDemonHeartObtainedPerformancePlayed ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += SerializationHelper.DictionaryAsBasicTypePair.Serialize(pCurrData, ref PendingThreeRealmsPowerPerformances, (short key) => key, (ETwelveImmortalsStatus value) => (sbyte)value);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref ThreeRealmsPowerKillLocations);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref TwelveImmortalKillLocations);
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
			pCurrData += SerializationHelper.DictionaryAsBasicTypePair.Deserialize(pCurrData, ref TwelveImmortalsStatuses, (short key) => key, (sbyte value) => (ETwelveImmortalsStatus)value);
		}
		if (fieldCount > 1)
		{
			pCurrData += SerializationHelper.DictionaryAsBasicTypePair.Deserialize(pCurrData, ref PendingTwelveImmortalsPerformances, (short key) => key, (sbyte value) => (ETwelveImmortalsStatus)value);
		}
		if (fieldCount > 2)
		{
			TaiwuAsXiangshuTowerFinalLayerEntered = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 3)
		{
			TaiwuAsXiangshuTowerTiandiDefeatPerformancePlayed = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 4)
		{
			TaiwuAsXiangshuTowerDemonHeartObtainedPerformancePlayed = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 5)
		{
			pCurrData += SerializationHelper.DictionaryAsBasicTypePair.Deserialize(pCurrData, ref PendingThreeRealmsPowerPerformances, (short key) => key, (sbyte value) => (ETwelveImmortalsStatus)value);
		}
		if (fieldCount > 6)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref ThreeRealmsPowerKillLocations);
		}
		if (fieldCount > 7)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref TwelveImmortalKillLocations);
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
