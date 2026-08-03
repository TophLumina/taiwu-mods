using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.TaiwuEvent.MonthlyEventActions.CustomActions;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

[SerializableGameData(NotForDisplayModule = true)]
public class MonthlyEventActionsManager : ISerializableGameData
{
	[SerializableGameDataField]
	private Dictionary<MonthlyActionKey, MonthlyActionBase> _monthlyActions;

	public static readonly Dictionary<string, MonthlyActionKey> PredefinedKeys = new Dictionary<string, MonthlyActionKey>
	{
		{
			"EnemyNestDefault",
			new MonthlyActionKey(1, 0)
		},
		{
			"MartialArtTournamentDefault",
			new MonthlyActionKey(2, 0)
		},
		{
			"BrideOpenContestDefault",
			new MonthlyActionKey(4, 0)
		},
		{
			"SeasonalActionDefault",
			new MonthlyActionKey(5, 0)
		},
		{
			"EmeiStoryDefault",
			new MonthlyActionKey(4, 1)
		},
		{
			"RanshanStoryDefault",
			new MonthlyActionKey(4, 2)
		}
	};

	public readonly List<MonthlyActionBase> CustomMonthlyActionDefines = new List<MonthlyActionBase>();

	public static readonly Dictionary<short, Func<ConfigMonthlyAction, bool>> ConfigTriggerCheckersExtensionMap = new Dictionary<short, Func<ConfigMonthlyAction, bool>> { 
	{
		30,
		(ConfigMonthlyAction action) => DomainManager.World.GetWorldFunctionsStatus(25)
	} };

	public static readonly Dictionary<short, Action<ConfigMonthlyAction>> ConfigMonthlyNotificationHandlerMap = new Dictionary<short, Action<ConfigMonthlyAction>>();

	public static int NewlyActivated;

	public static int NewlyTriggered;

	public bool IsInitialized => _monthlyActions != null && _monthlyActions.Count > 0;

	public MonthlyActionBase GetMonthlyAction(MonthlyActionKey key)
	{
		if (!key.IsValid() || _monthlyActions == null || !_monthlyActions.TryGetValue(key, out var action))
		{
			return null;
		}
		return action;
	}

	public void RemoveTempDynamicAction(MonthlyActionKey key)
	{
		Tester.Assert(key.ActionType == 6);
		_monthlyActions.Remove(key);
	}

	public MonthlyActionKey AddTempDynamicAction<T>(T action) where T : MonthlyActionBase, IDynamicAction
	{
		for (short i = 0; i < short.MaxValue; i++)
		{
			MonthlyActionKey key = new MonthlyActionKey(6, i);
			if (!_monthlyActions.ContainsKey(key))
			{
				action.Key = key;
				_monthlyActions.Add(key, action);
				return key;
			}
		}
		return MonthlyActionKey.Invalid;
	}

	public MonthlyActionKey AddWrappedConfigAction(short templateId, short assignedAreaId = -1)
	{
		MonthlyActionKey key = new MonthlyActionKey(4, templateId);
		if (PredefinedKeys.ContainsValue(key))
		{
			throw new InvalidOperationException($"Unable to create monthly action because the key {key} is pre-defined.");
		}
		MonthlyActionBase actionBase;
		ConfigWrapperAction wrapperAction = (_monthlyActions.TryGetValue(key, out actionBase) ? ((ConfigWrapperAction)actionBase) : new ConfigWrapperAction(key));
		wrapperAction.CreateWrappedAction(templateId, assignedAreaId);
		_monthlyActions[key] = wrapperAction;
		return key;
	}

	public void ClearTaiwuBindingMonthlyActions()
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		List<MonthlyActionKey> actionKeys = new List<MonthlyActionKey>(_monthlyActions.Keys);
		foreach (MonthlyActionKey key in actionKeys)
		{
			MonthlyActionBase action = _monthlyActions[key];
			if (action is MarriageTriggerAction marriageTriggerAction && marriageTriggerAction.Location.IsValid())
			{
				DomainManager.Adventure.RemoveAdventureSite(context, marriageTriggerAction.Location.AreaId, marriageTriggerAction.Location.BlockId, isTimeout: false, isComplete: false);
			}
		}
	}

	public void CollectUnreleasedCalledCharacters(HashSet<int> calledCharacters)
	{
		if (!IsInitialized)
		{
			return;
		}
		foreach (var (key, action) in _monthlyActions)
		{
			action.CollectCalledCharacters(calledCharacters);
		}
	}

	public void HandleMonthlyActions()
	{
		NewlyActivated = 0;
		NewlyTriggered = 0;
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		if (!IsInitialized)
		{
			Init();
		}
		List<MonthlyActionBase> toExecute = _monthlyActions.Values.ToList();
		foreach (MonthlyActionBase actionItem in toExecute)
		{
			actionItem.MonthlyHandler();
		}
		stopwatch.Stop();
		AdaptableLog.Info($"HandleMonthlyEventActions ({NewlyTriggered} triggered, {NewlyActivated} activated): {stopwatch.ElapsedMilliseconds} ms");
	}

	public void HandleInvalidActions()
	{
		if (!IsInitialized)
		{
			return;
		}
		foreach (MonthlyActionBase actionItem in _monthlyActions.Values)
		{
			actionItem.ValidationHandler();
		}
	}

	public void Init()
	{
		if (IsInitialized)
		{
			return;
		}
		_monthlyActions = new Dictionary<MonthlyActionKey, MonthlyActionBase>();
		foreach (MonthlyActionsItem monthlyActionCfg in (IEnumerable<MonthlyActionsItem>)MonthlyActions.Instance)
		{
			if (!monthlyActionCfg.IsEnemyNest && monthlyActionCfg.MinInterval > 0)
			{
				ConfigMonthlyAction item = new ConfigMonthlyAction(monthlyActionCfg.TemplateId, -1);
				_monthlyActions.Add(item.Key, item);
			}
		}
		MonthlyActionKey brideOpenContestKey = PredefinedKeys["BrideOpenContestDefault"];
		_monthlyActions.Add(brideOpenContestKey, new ConfigWrapperAction(brideOpenContestKey));
		MonthlyActionKey seasonalActionKey = PredefinedKeys["SeasonalActionDefault"];
		_monthlyActions.Add(seasonalActionKey, new SeasonalMonthlyAction(seasonalActionKey));
		MonthlyActionKey emeiActionKey = PredefinedKeys["EmeiStoryDefault"];
		_monthlyActions.Add(emeiActionKey, new ConfigWrapperAction(emeiActionKey));
		MonthlyActionKey ranshanActionKey = PredefinedKeys["RanshanStoryDefault"];
		_monthlyActions.Add(ranshanActionKey, new ConfigWrapperAction(ranshanActionKey));
		for (short i = 0; i < CustomMonthlyActionDefines.Count; i++)
		{
			MonthlyActionKey key = new MonthlyActionKey(3, i);
			CustomMonthlyActionDefines[i].Key = key;
			_monthlyActions.Add(key, CustomMonthlyActionDefines[i]);
		}
	}

	public void OnArchiveDataLoaded()
	{
		if (!IsInitialized)
		{
			return;
		}
		List<short> keys = MonthlyActions.Instance.GetAllKeys();
		for (short i = 0; i < keys.Count; i++)
		{
			MonthlyActionKey key = new MonthlyActionKey(0, i);
			MonthlyActionsItem config = MonthlyActions.Instance[i];
			if (!config.IsEnemyNest)
			{
				if (config.MinInterval <= 0)
				{
					if (_monthlyActions.Remove(key))
					{
						AdaptableLog.TagWarning("MonthlyEventActionsManager", $"Removing invalid config action {config.Name} with key {key}");
					}
				}
				else if (!_monthlyActions.ContainsKey(key))
				{
					ConfigMonthlyAction item = new ConfigMonthlyAction(keys[i], -1);
					_monthlyActions.Add(key, item);
					AdaptableLog.TagInfo("MonthlyEventActionsManager", "New Config Action: " + item.ConfigData.Name);
				}
			}
		}
		MonthlyActionKey brideOpenContestKey = PredefinedKeys["BrideOpenContestDefault"];
		if (!_monthlyActions.ContainsKey(brideOpenContestKey))
		{
			_monthlyActions.Add(brideOpenContestKey, new ConfigWrapperAction(brideOpenContestKey));
			AdaptableLog.TagInfo("MonthlyEventActionsManager", $"New Wrapper Action: {brideOpenContestKey}");
		}
		MonthlyActionKey emeiStoryKey = PredefinedKeys["EmeiStoryDefault"];
		if (!_monthlyActions.ContainsKey(emeiStoryKey))
		{
			_monthlyActions.Add(emeiStoryKey, new ConfigWrapperAction(emeiStoryKey));
			AdaptableLog.TagInfo("EmeiStoryDefault", $"New Wrapper Action: {emeiStoryKey}");
		}
		MonthlyActionKey ranshanStoryKey = PredefinedKeys["RanshanStoryDefault"];
		if (!_monthlyActions.ContainsKey(ranshanStoryKey))
		{
			_monthlyActions.Add(ranshanStoryKey, new ConfigWrapperAction(ranshanStoryKey));
			AdaptableLog.TagInfo("RanshanStoryDefault", $"New Wrapper Action: {ranshanStoryKey}");
		}
		MonthlyActionKey seasonalActionKey = PredefinedKeys["SeasonalActionDefault"];
		if (!_monthlyActions.ContainsKey(seasonalActionKey))
		{
			_monthlyActions.Add(seasonalActionKey, new SeasonalMonthlyAction(seasonalActionKey));
			AdaptableLog.TagInfo("MonthlyEventActionsManager", $"New Seasonal Action: {seasonalActionKey}");
		}
		for (short i2 = 0; i2 < CustomMonthlyActionDefines.Count; i2++)
		{
			if (CustomMonthlyActionDefines[i2] != null)
			{
				MonthlyActionKey key2 = new MonthlyActionKey(3, i2);
				if (_monthlyActions.ContainsKey(key2))
				{
					_monthlyActions[key2].InheritNonArchiveData(CustomMonthlyActionDefines[i2]);
				}
				else
				{
					MonthlyActionBase copy = CustomMonthlyActionDefines[i2].CreateCopy();
					_monthlyActions.Add(key2, copy);
					AdaptableLog.TagInfo("MonthlyEventActionsManager", $"New Custom Monthly Action: {CustomMonthlyActionDefines[i2].Key}");
				}
			}
		}
	}

	public static bool ConfigItemTriggerCheck(short templateId, ConfigMonthlyAction actionItem)
	{
		if (ConfigTriggerCheckersExtensionMap.TryGetValue(templateId, out var func))
		{
			return func(actionItem);
		}
		return true;
	}

	public static void ConfigItemOnActivate(short templateId, ConfigMonthlyAction monthlyAction)
	{
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		monthlyNotificationCollection.AddConfigMonthlyActionNotification(monthlyAction.ConfigData, monthlyAction);
		if (ConfigMonthlyNotificationHandlerMap.TryGetValue(templateId, out var handler))
		{
			handler(monthlyAction);
		}
		short num = templateId;
		short num2 = num;
		if (num2 == 81)
		{
			DomainManager.World.TriggerExtraTask(DomainManager.TaiwuEvent.MainThreadDataContext, 34, 226);
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(DomainManager.TaiwuEvent.MainThreadDataContext, 2, SectMainStoryEventArgKey.DefValue.EmeiAdventureTwoAppearDate, DomainManager.World.GetCurrDate());
		}
	}

	public static void ConfigItemOnDeactivate(ConfigMonthlyAction monthlyAction, bool isComplete)
	{
		if (monthlyAction.Key.Equals(PredefinedKeys["BrideOpenContestDefault"]))
		{
			RemoveVeil(monthlyAction, isComplete);
		}
		AdaptableLog.Info($"Deactivating Config Monthly Action: {monthlyAction.ConfigData.Name} at [{monthlyAction.Location}] where isComplete = {isComplete}");
	}

	private static void RemoveVeil(ConfigMonthlyAction monthlyAction, bool isComplete)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (taiwuChar.GetAvatar().ShowVeil)
		{
			AvatarData avatarData = taiwuChar.GetAvatar();
			avatarData.ShowVeil = false;
			taiwuChar.SetAvatar(avatarData, DomainManager.TaiwuEvent.MainThreadDataContext);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (_monthlyActions != null)
		{
			totalSize += 2;
			int elementsCount = _monthlyActions.Count;
			totalSize += elementsCount * 3;
			foreach (MonthlyActionBase val in _monthlyActions.Values)
			{
				totalSize += val.GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (_monthlyActions != null)
		{
			int elementsCount = _monthlyActions.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			foreach (KeyValuePair<MonthlyActionKey, MonthlyActionBase> pair in _monthlyActions)
			{
				pCurrData += pair.Key.Serialize(pCurrData);
				pCurrData += pair.Value.Serialize(pCurrData);
			}
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_monthlyActions == null)
			{
				_monthlyActions = new Dictionary<MonthlyActionKey, MonthlyActionBase>(elementsCount);
			}
			else
			{
				_monthlyActions.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				MonthlyActionKey key = default(MonthlyActionKey);
				pCurrData += key.Deserialize(pCurrData);
				switch (key.ActionType)
				{
				case 0:
				{
					ConfigMonthlyAction configAction = new ConfigMonthlyAction();
					pCurrData += configAction.Deserialize(pCurrData);
					_monthlyActions.Add(key, configAction);
					break;
				}
				case 1:
				{
					EnemyNestMonthlyAction enemyNestAction = new EnemyNestMonthlyAction();
					pCurrData += enemyNestAction.Deserialize(pCurrData);
					_monthlyActions.Add(key, enemyNestAction);
					break;
				}
				case 3:
				{
					MonthlyActionBase customAction = CustomMonthlyActionDefines[key.Index].CreateCopy();
					pCurrData += customAction.Deserialize(pCurrData);
					_monthlyActions.Add(key, customAction);
					break;
				}
				case 4:
				{
					ConfigWrapperAction wrapperAction = new ConfigWrapperAction();
					pCurrData += wrapperAction.Deserialize(pCurrData);
					_monthlyActions.Add(key, wrapperAction);
					break;
				}
				case 5:
				{
					SeasonalMonthlyAction seasonalAction = new SeasonalMonthlyAction();
					pCurrData += seasonalAction.Deserialize(pCurrData);
					_monthlyActions.Add(key, seasonalAction);
					break;
				}
				case 6:
				{
					short dynamicActionType = *(short*)pCurrData;
					MonthlyActionBase dynamicAction = DynamicActionType.CreateDynamicAction(dynamicActionType);
					pCurrData += dynamicAction.Deserialize(pCurrData);
					_monthlyActions.Add(key, dynamicAction);
					break;
				}
				default:
					throw new Exception("Unrecognized type name.");
				}
			}
		}
		else
		{
			_monthlyActions?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
