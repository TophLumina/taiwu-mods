using System;
using System.Collections.Generic;
using System.Reflection;
using Config;
using GameData.Common;
using GameData.DLC;
using GameData.Domains;
using GameData.Domains.Global;
using GameData.GameDataBridge;
using GameData.Steamworks;
using GameData.Utilities;

namespace GameData.Achievement;

public static class AchievementManager
{
	private readonly struct HandlerKey(EInfoType type, short id, DataUid uid) : IEqualityComparer<HandlerKey>
	{
		private readonly EInfoType _type = type;

		private readonly short _id = id;

		private readonly DataUid _uid = uid;

		private bool Equals(HandlerKey other)
		{
			return _type == other._type && _id == other._id && _uid.Equals(other._uid);
		}

		public bool Equals(HandlerKey key1, HandlerKey key2)
		{
			return key1.Equals(key2);
		}

		public override bool Equals(object obj)
		{
			return obj is HandlerKey other && Equals(other);
		}

		public int GetHashCode(HandlerKey obj)
		{
			return HashCode.Combine(obj._type, obj._id, obj._uid);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_type, _id, _uid);
		}

		public static bool operator ==(HandlerKey key1, HandlerKey key2)
		{
			return key1.Equals(key2);
		}

		public static bool operator !=(HandlerKey key1, HandlerKey key2)
		{
			return !key1.Equals(key2);
		}

		public override string ToString()
		{
			return $"AchievementManager[{_type}, {_id}, {_uid}].Handler";
		}
	}

	private enum EUpdateDataUidInfoType : ushort
	{
		None,
		Minus,
		Replace,
		LogicalAnd,
		LogicalOr,
		LogicalXor
	}

	private enum EInfoType : ushort
	{
		Stat,
		Dependent
	}

	private class PlatFormType
	{
		public const ushort Local = 1;

		public const ushort Steam = 2;

		public const ushort EpicGames = 4;
	}

	private delegate ulong[] DependentDelegate(DataContext context);

	private readonly struct Dependent : IEquatable<Dependent>
	{
		private readonly EDependent _dependentId;

		public readonly DependentInfo[] DependentInfoArray;

		public readonly DependentDelegate EventCallback;

		public Dependent(EDependent dependentId, DependentInfo[] dependentInfoArray)
		{
			_dependentId = dependentId;
			DependentInfoArray = dependentInfoArray;
			EventCallback = null;
		}

		public Dependent(Dependent dependent, DependentDelegate eventCallback)
		{
			_dependentId = dependent._dependentId;
			DependentInfoArray = dependent.DependentInfoArray;
			EventCallback = eventCallback;
		}

		public void OnTriggered(DataContext context, DataUid uid)
		{
			TriggerDependentEventCallback(context, _dependentId);
		}

		public void UpdateListener()
		{
			IsDependentEventTriggered[(int)_dependentId] = false;
			if (DependentDataUidMap.TryGetValue((short)_dependentId, out var dataUid))
			{
				GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(dataUid, $"AchievementManager[{EInfoType.Dependent}, {(short)_dependentId}, {dataUid}].Handler", OnTriggered);
			}
		}

		public void RemoveListener()
		{
			if (DependentDataUidMap.TryGetValue((short)_dependentId, out var dataUid))
			{
				GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(dataUid, $"AchievementManager[{EInfoType.Dependent}, {(short)_dependentId}, {dataUid}].Handler");
			}
		}

		public void UpdateDataUid(DataUid[] uidArray, EUpdateDataUidInfoType updateType)
		{
			DependentDataUidMap[(short)_dependentId] = uidArray[0];
		}

		public bool Equals(Dependent other)
		{
			return _dependentId == other._dependentId;
		}

		public override bool Equals(object obj)
		{
			return obj is Dependent other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_dependentId);
		}

		public static bool operator ==(Dependent event1, Dependent event2)
		{
			return event1.Equals(event2);
		}

		public static bool operator !=(Dependent event1, Dependent event2)
		{
			return !event1.Equals(event2);
		}
	}

	private readonly struct DependentInfo
	{
		public readonly EInfoType Type;

		public readonly EUpdateDataUidInfoType UpdateType;

		public readonly short Id;

		public readonly DataUid? UidTemplate;

		public DependentInfo(EInfoType type, EUpdateDataUidInfoType updateType, short id, DataUid uidTemplate)
		{
			Type = type;
			UpdateType = updateType;
			Id = id;
			UidTemplate = uidTemplate;
		}

		public DependentInfo(EInfoType type, EUpdateDataUidInfoType updateType, short id)
		{
			Type = type;
			UpdateType = updateType;
			Id = id;
			UidTemplate = null;
		}
	}

	private delegate T StatDelegate<out T>();

	private readonly struct Stat(short statId) : IEquatable<Stat>
	{
		private readonly short _statId = statId;

		public void OnTriggered(DataContext context, DataUid uid)
		{
			StatInfoItem config = StatInfo.Instance[_statId];
			switch (config.Type)
			{
			case EStatInfoType.Int:
				RequestSetStat(context, _statId, IntStats[_statId]());
				break;
			case EStatInfoType.ListInt:
				RequestSetStat(context, _statId, ListIntStats[_statId]());
				break;
			}
		}

		public void UpdateListener()
		{
			DataUid[] array = StatDataUidMap[_statId];
			foreach (DataUid uid in array)
			{
				HandlerKey key = new HandlerKey(EInfoType.Stat, _statId, uid);
				string str = key.ToString();
				if (!HandlerKeys.TryAdd(key, value: true))
				{
					GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(uid, str);
				}
				GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(uid, str, OnTriggered);
			}
		}

		public void RemoveListener()
		{
			DataUid[] array = StatDataUidMap[_statId];
			foreach (DataUid uid in array)
			{
				HandlerKey key = new HandlerKey(EInfoType.Stat, _statId, uid);
				if (HandlerKeys.ContainsKey(key))
				{
					GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(uid, key.ToString());
					HandlerKeys.Remove(key);
				}
			}
		}

		public void UpdateDataUid(DataUid[] uidArray, EUpdateDataUidInfoType updateType)
		{
			switch (updateType)
			{
			case EUpdateDataUidInfoType.None:
				break;
			case EUpdateDataUidInfoType.Minus:
				StatDataUidMap[_statId] = Except(StatDataUidMap[_statId], uidArray);
				break;
			case EUpdateDataUidInfoType.Replace:
				StatDataUidMap[_statId] = uidArray;
				break;
			case EUpdateDataUidInfoType.LogicalAnd:
				StatDataUidMap[_statId] = Intersect(StatDataUidMap[_statId], uidArray);
				break;
			case EUpdateDataUidInfoType.LogicalOr:
				StatDataUidMap[_statId] = Union(StatDataUidMap[_statId], uidArray);
				break;
			case EUpdateDataUidInfoType.LogicalXor:
				StatDataUidMap[_statId] = Xor(StatDataUidMap[_statId], uidArray);
				break;
			}
		}

		public bool Equals(Stat other)
		{
			return _statId == other._statId;
		}

		public override bool Equals(object obj)
		{
			return obj is Stat other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_statId);
		}

		public static bool operator ==(Stat stat1, Stat stat2)
		{
			return stat1.Equals(stat2);
		}

		public static bool operator !=(Stat stat1, Stat stat2)
		{
			return !stat1.Equals(stat2);
		}
	}

	private static readonly Dictionary<HandlerKey, bool> HandlerKeys = new Dictionary<HandlerKey, bool>();

	private static ushort _platform;

	private static bool _bInfoInitialized;

	internal static int CookingBeast1Count;

	private static readonly Dependent[] Dependents = new Dependent[100];

	private static readonly bool[] IsDependentEventTriggered = new bool[100];

	private static readonly Dictionary<short, DataUid> DependentDataUidMap = new Dictionary<short, DataUid>();

	private static readonly Dictionary<short, Stat> Stats = new Dictionary<short, Stat>();

	private static readonly Dictionary<short, DataUid[]> StatDataUidMap = new Dictionary<short, DataUid[]>();

	private static readonly Dictionary<short, StatDelegate<int>> IntStats = new Dictionary<short, StatDelegate<int>>();

	private static readonly Dictionary<short, StatDelegate<List<int>>> ListIntStats = new Dictionary<short, StatDelegate<List<int>>>();

	public static void Initialize()
	{
		InitializePlatform();
		CreateDependentInfo();
	}

	private static void InitializePlatform()
	{
		_platform = 1;
		_platform |= 2;
	}

	private static void TryUnlockAchievement(DataContext context, short achievementId)
	{
		if (!CheckAchieved(achievementId) && CheckFulfilled(achievementId))
		{
			UnlockAchievement(context, achievementId);
		}
	}

	private static bool CheckFulfilled(short achievementId)
	{
		AchievementInfoItem config = AchievementInfo.Instance[achievementId];
		if (config.DlcId != 0 && !DlcManager.IsDlcInstalled(config.DlcId))
		{
			return false;
		}
		if (config.RequirementTypes == null || config.RequirementTypes.Count == 0)
		{
			return CheckFulfilledCustom(achievementId);
		}
		for (int i = 0; i < config.RequirementTypes.Count; i++)
		{
			EAchievementInfoRequirementType requirementType = config.RequirementTypes[i];
			int[] requiredStat = config.RequirementStats[i];
			switch (requirementType)
			{
			case EAchievementInfoRequirementType.Greater:
				if (RequestGetStat((short)requiredStat[0]) <= requiredStat[1])
				{
					return false;
				}
				break;
			case EAchievementInfoRequirementType.GreaterOrEqual:
				if (RequestGetStat((short)requiredStat[0]) < requiredStat[1])
				{
					return false;
				}
				break;
			case EAchievementInfoRequirementType.Equal:
				if (RequestGetStat((short)requiredStat[0]) != requiredStat[1])
				{
					return false;
				}
				break;
			case EAchievementInfoRequirementType.LessOrEqual:
				if (RequestGetStat((short)requiredStat[0]) > requiredStat[1])
				{
					return false;
				}
				break;
			case EAchievementInfoRequirementType.Less:
				if (RequestGetStat((short)requiredStat[0]) >= requiredStat[1])
				{
					return false;
				}
				break;
			default:
				return false;
			}
		}
		return true;
	}

	private static bool CheckFulfilledCustom(short achievementId)
	{
		return false;
	}

	private static bool CheckAchieved(short achievementId)
	{
		bool achieved = false;
		AchievementInfoItem config = AchievementInfo.Instance[achievementId];
		if ((_platform & 2) != 0 && !string.IsNullOrEmpty(config.SteamName))
		{
			SteamManager.GetAchievement(config.SteamName, out achieved);
		}
		if ((_platform & 4) != 0)
		{
		}
		if ((_platform & 1) != 0)
		{
			achieved = DomainManager.Global.GetAchievement(achievementId);
		}
		return achieved;
	}

	private static void UnlockAchievement(DataContext context, short achievementId)
	{
		AchievementInfoItem config = AchievementInfo.Instance[achievementId];
		if ((_platform & 1) != 0)
		{
			DomainManager.Global.SetAchievement(context, achievementId);
		}
		if ((_platform & 2) != 0 && !string.IsNullOrEmpty(config.SteamName))
		{
			SteamManager.AddAchievement(AchievementInfo.Instance[achievementId].SteamName);
		}
		if ((_platform & 4) == 0)
		{
		}
	}

	private static void SaveStatOnPlatforms(short statId, int value)
	{
		StatInfoItem config = StatInfo.Instance[statId];
		if ((_platform & 2) != 0 && !string.IsNullOrEmpty(config.SteamName) && !string.IsNullOrEmpty(StatInfo.Instance[statId].SteamName))
		{
			SteamManager.SetStat(StatInfo.Instance[statId].SteamName, value);
		}
		if ((_platform & 4) == 0)
		{
		}
	}

	public static int RequestGetStat(short statId)
	{
		StatInfoItem config = StatInfo.Instance[statId];
		return (config.SaveType == EStatInfoSaveType.Global) ? DomainManager.Global.GetStat(statId) : DomainManager.World.GetStat(statId);
	}

	public static void RequestSetStat<T>(DataContext context, short statId, T value)
	{
		bool condition = ((value is List<int> || value is int) ? true : false);
		Tester.Assert(condition, "Stat value type is invalid.");
		StatInfoItem config = StatInfo.Instance[statId];
		GameStatRecordWrapper wrapper = ((config.SaveType == EStatInfoSaveType.Global) ? DomainManager.Global.GetStatWrapper(statId) : DomainManager.World.GetStatWrapper(statId));
		wrapper.SetStat(value, config.SetType);
		if (config.SaveType == EStatInfoSaveType.Global)
		{
			DomainManager.Global.SetStat(context, statId, wrapper);
		}
		else
		{
			DomainManager.World.SetStat(context, statId, wrapper);
		}
		SaveStatOnPlatforms(statId, wrapper.GetStat());
		foreach (short achievementId in config.AchievementTemplateId)
		{
			TryUnlockAchievement(context, achievementId);
		}
	}

	public static void ResetStatsAndAchievements(DataContext context)
	{
		DomainManager.World.ClearAllStat(context);
		DomainManager.Global.ClearAllStat(context);
		SteamManager.ResetStatsAndAchievements();
	}

	private static bool FindDataUid(DataUid target, DataUid[] source)
	{
		foreach (DataUid dataUid in source)
		{
			if (dataUid.Equals(target))
			{
				return true;
			}
		}
		return false;
	}

	private static DataUid[] Except(DataUid[] array1, DataUid[] array2)
	{
		DataUid[] result = new DataUid[array1.Length];
		int index = 0;
		foreach (DataUid dataUid in array1)
		{
			if (!FindDataUid(dataUid, array2))
			{
				result[index] = dataUid;
				index++;
			}
		}
		Array.Resize(ref result, index);
		return result;
	}

	private static DataUid[] Union(DataUid[] array1, DataUid[] array2)
	{
		DataUid[] result = new DataUid[array1.Length + array2.Length];
		int index = 0;
		foreach (DataUid dataUid in array1)
		{
			result[index] = dataUid;
			index++;
		}
		foreach (DataUid dataUid2 in array2)
		{
			if (!FindDataUid(dataUid2, result))
			{
				result[index] = dataUid2;
				index++;
			}
		}
		Array.Resize(ref result, index);
		return result;
	}

	private static DataUid[] Intersect(DataUid[] array1, DataUid[] array2)
	{
		DataUid[] result = new DataUid[Math.Min(array1.Length, array2.Length)];
		int index = 0;
		foreach (DataUid dataUid in array1)
		{
			if (FindDataUid(dataUid, array2))
			{
				result[index] = dataUid;
				index++;
			}
		}
		Array.Resize(ref result, index);
		return result;
	}

	private static DataUid[] Xor(DataUid[] array1, DataUid[] array2)
	{
		DataUid[] result = new DataUid[array1.Length + array2.Length];
		int index = 0;
		foreach (DataUid dataUid in array1)
		{
			if (!FindDataUid(dataUid, array2))
			{
				result[index] = dataUid;
				index++;
			}
		}
		foreach (DataUid dataUid2 in array2)
		{
			if (!FindDataUid(dataUid2, array1))
			{
				result[index] = dataUid2;
				index++;
			}
		}
		Array.Resize(ref result, index);
		return result;
	}

	public static void OnArchiveDataLoaded(DataContext context, DataUid uid)
	{
		if (!DomainManager.Global.GetLoadedAllArchiveData())
		{
			return;
		}
		CookingBeast1Count = -1;
		if (!_bInfoInitialized)
		{
			InitializeStatInfo();
			InitializeDependentInfo();
		}
		foreach (StatInfoItem info in (IEnumerable<StatInfoItem>)StatInfo.Instance)
		{
			if (StatDataUidMap.ContainsKey(info.TemplateId))
			{
				RemoveStatListener(info.TemplateId);
				StatDataUidMap.Remove(info.TemplateId);
			}
		}
		EDependent[] values = Enum.GetValues<EDependent>();
		foreach (EDependent dependentId in values)
		{
			if (DependentDataUidMap.ContainsKey((short)dependentId))
			{
				RemoveDependentListener(dependentId);
				DependentDataUidMap.Remove((short)dependentId);
			}
		}
		InitializeDataUidListeners();
		foreach (StatInfoItem info2 in (IEnumerable<StatInfoItem>)StatInfo.Instance)
		{
			if (!StatDataUidMap.ContainsKey(info2.TemplateId))
			{
				StatDataUidMap.Add(info2.TemplateId, Array.Empty<DataUid>());
			}
			else
			{
				UpdateStatListener(info2.TemplateId);
			}
		}
		EDependent[] values2 = Enum.GetValues<EDependent>();
		foreach (EDependent dependentId2 in values2)
		{
			UpdateDependentListener(dependentId2);
		}
		Dependents[0].OnTriggered(DataContextManager.GetCurrentThreadDataContext(), default(DataUid));
		foreach (AchievementInfoItem info3 in (IEnumerable<AchievementInfoItem>)AchievementInfo.Instance)
		{
			TryUnlockAchievement(context, info3.TemplateId);
		}
		_bInfoInitialized = true;
	}

	private static void InitializeDependentInfo()
	{
		MethodInfo[] methodInfos = typeof(DependentEventCallbacks).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
		Dictionary<short, DependentDelegate> methodDict = new Dictionary<short, DependentDelegate>();
		MethodInfo[] array = methodInfos;
		foreach (MethodInfo info in array)
		{
			DependentIdentifierAttribute attr = info.GetCustomAttribute<DependentIdentifierAttribute>();
			if (attr != null)
			{
				methodDict.Add(attr.Id, info.CreateDelegate<DependentDelegate>());
			}
		}
		for (short id = 0; id < 3; id++)
		{
			if (!methodDict.TryGetValue(id, out var value))
			{
				throw new Exception($"Dependent {id} is missing a callback method!");
			}
			Dependents[id] = new Dependent(Dependents[id], value);
		}
	}

	private static void UpdateDependentListener(EDependent dependentId)
	{
		Dependents[(int)dependentId].UpdateListener();
	}

	private static void RemoveDependentListener(EDependent dependentId)
	{
		Dependents[(int)dependentId].RemoveListener();
	}

	private static void TriggerDependentEventCallback(DataContext context, EDependent dependentId)
	{
		IsDependentEventTriggered[(int)dependentId] = true;
		Dependent dependent = Dependents[(int)dependentId];
		ulong[] subIds = dependent.EventCallback(context);
		DependentInfo[] dependentInfoArray = dependent.DependentInfoArray;
		for (int i = 0; i < dependentInfoArray.Length; i++)
		{
			DependentInfo dependentInfo = dependentInfoArray[i];
			short id = dependentInfo.Id;
			if (dependentInfo.Type == EInfoType.Dependent && IsDependentEventTriggered[id])
			{
				throw new Exception($"Fatal error!!! Circular event dependency detected: {dependentId} -> {id} (Already triggered)");
			}
			DataUid[] newDataUidArray = new DataUid[subIds.Length];
			if (dependentInfo.UidTemplate.HasValue && subIds.Length != 0)
			{
				DataUid uid = dependentInfo.UidTemplate.Value;
				for (int j = 0; j < subIds.Length; j++)
				{
					newDataUidArray[j] = new DataUid(uid.DomainId, uid.DataId, subIds[j], uid.SubId1);
				}
			}
			switch (dependentInfo.Type)
			{
			case EInfoType.Stat:
				if (dependentInfo.UidTemplate.HasValue && subIds.Length != 0)
				{
					Stats[id].RemoveListener();
					Stats[id].UpdateDataUid(newDataUidArray, dependentInfo.UpdateType);
					Stats[id].UpdateListener();
				}
				Stats[id].OnTriggered(context, default(DataUid));
				break;
			case EInfoType.Dependent:
				if (dependentInfo.UidTemplate.HasValue && subIds.Length != 0)
				{
					Dependents[id].RemoveListener();
					Dependents[id].UpdateDataUid(newDataUidArray, dependentInfo.UpdateType);
					Dependents[id].UpdateListener();
				}
				Dependents[id].OnTriggered(context, default(DataUid));
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		IsDependentEventTriggered[(int)dependentId] = false;
	}

	private static void CreateDependentInfo()
	{
		Dependents[0] = new Dependent(EDependent.OnArchiveDataLoaded, new DependentInfo[1]
		{
			new DependentInfo(EInfoType.Dependent, EUpdateDataUidInfoType.None, 1)
		});
		Dependents[1] = new Dependent(EDependent.OnTaiwuCharIdChanged, new DependentInfo[1]
		{
			new DependentInfo(EInfoType.Dependent, EUpdateDataUidInfoType.Replace, 2, new DataUid(4, 0, 18446744073709551614uL, 57u))
		});
		Dependents[2] = new Dependent(EDependent.OnTaiwuItemsChanged, Array.Empty<DependentInfo>());
	}

	private static void InitializeDataUidListeners()
	{
		DependentDataUidMap.Add(1, new DataUid(5, 0, ulong.MaxValue));
	}

	private static void InitializeStatInfo()
	{
		MethodInfo[] methodInfos = typeof(StatEventCallbacks).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
		MethodInfo[] array = methodInfos;
		foreach (MethodInfo info in array)
		{
			StatIdentifierAttribute attr = info.GetCustomAttribute<StatIdentifierAttribute>();
			if (attr != null)
			{
				StatInfoItem config = StatInfo.Instance[attr.Id];
				switch (config.Type)
				{
				case EStatInfoType.Int:
					IntStats[attr.Id] = info.CreateDelegate<StatDelegate<int>>();
					break;
				case EStatInfoType.ListInt:
					ListIntStats[attr.Id] = info.CreateDelegate<StatDelegate<List<int>>>();
					break;
				}
				Stats.Add(attr.Id, new Stat(attr.Id));
			}
		}
	}

	private static void UpdateStatListener(short statId)
	{
		Stats[statId].UpdateListener();
	}

	private static void RemoveStatListener(short statId)
	{
		if (Stats.TryGetValue(statId, out var stat))
		{
			stat.RemoveListener();
		}
	}
}
