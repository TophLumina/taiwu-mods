using System;
using System.Collections.Generic;
using Config;
using Config.ConfigCells;
using GameData.Common;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Taiwu;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

[SerializableGameData(NotForDisplayModule = true)]
public class EnemyNestMonthlyAction : MonthlyActionBase, ISerializableGameData, IMonthlyActionGroup
{
	[SerializableGameDataField]
	private List<ConfigMonthlyAction>[] _enemyNestActionsInAreas;

	public override void MonthlyHandler()
	{
		if (!DomainManager.World.GetWorldFunctionsStatus(7))
		{
			return;
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		DomainManager.Extra.UpdateEnemyNestInitializationDates(context, currDate);
		for (short areaId = 0; areaId < 45; areaId++)
		{
			UpdateEnemiesInArea(context, areaId);
			List<ConfigMonthlyAction> nestsInArea = _enemyNestActionsInAreas[areaId];
			MapAreaData areaData = DomainManager.Map.GetElement_Areas(areaId);
			MapAreaItem areaCfg = areaData.GetConfig();
			for (int index = nestsInArea.Count - 1; index >= 0; index--)
			{
				ConfigMonthlyAction configAction = nestsInArea[index];
				if (configAction != null)
				{
					int interval = GetIntervalByAdventureId(areaCfg, index, configAction.ConfigData.AdventureId);
					if (configAction.State == 0 && configAction.LastFinishDate + interval <= currDate)
					{
						configAction.SelectLocation();
						configAction.TriggerAction();
					}
					else if (configAction.State == 5 && DomainManager.Adventure.QueryAnyActivatedInLocation(areaId, configAction.Location.BlockId))
					{
						List<CharacterSet> majorCharacterSets = configAction.MajorCharacterSets;
						if (majorCharacterSets != null && majorCharacterSets.Count > 0)
						{
							bool noLongerValid = false;
							short adventureId = configAction.ConfigData.AdventureId;
							foreach (CharacterSet majorCharacterSet in configAction.MajorCharacterSets)
							{
								HashSet<int> collection = majorCharacterSet.GetCollection();
								foreach (int charId in collection)
								{
									if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
									{
										noLongerValid = true;
										continue;
									}
									character.ChangeHealth(context, GlobalConfig.Instance.EnemyNestKidnappedCharHealthChange);
									if (character.GetHealth() <= 0)
									{
										noLongerValid = true;
										DomainManager.Character.MakeCharacterDead(context, character, 5, new CharacterDeathInfo(character.GetValidLocation())
										{
											AdventureId = adventureId
										});
									}
									else if (CheckEscape(context.Random, character, adventureId))
									{
										noLongerValid = true;
										if (character.GetOrganizationInfo().OrgTemplateId == 16 && charId != DomainManager.Taiwu.GetTaiwuCharId())
										{
											monthlyNotifications.AddEscapeFromEnemyNestVillager(charId, configAction.Location, adventureId);
										}
										else
										{
											monthlyNotifications.AddEscapeFromEnemyNest(charId, configAction.Location, adventureId);
										}
										lifeRecordCollection.AddEscapeFromEnemyNestBySelf(charId, currDate, configAction.Location, adventureId);
										character.ActivateAdvanceMonthStatus(16);
									}
								}
							}
							if (noLongerValid)
							{
								configAction.EnsurePrerequisites();
								if (configAction.GetCharacterArg() >= 0)
								{
									monthlyNotifications.AddConfigMonthlyActionNotification(configAction.ConfigData, configAction);
								}
							}
						}
					}
					configAction.MonthlyHandler();
				}
			}
		}
	}

	private static int GetIntervalByAdventureId(MapAreaItem mapAreaCfg, int index, short adventureId)
	{
		if (mapAreaCfg.EnemyNests.Count <= index)
		{
			return 0;
		}
		EnemyNestCreationInfo[] creationInfoGroup = mapAreaCfg.EnemyNests[index];
		EnemyNestCreationInfo[] array = creationInfoGroup;
		foreach (EnemyNestCreationInfo creationInfo in array)
		{
			if (EnemyNest.Instance[creationInfo.EnemyNest].AdventureId == adventureId)
			{
				return creationInfo.Interval;
			}
		}
		return 0;
	}

	private static bool CheckEscape(IRandomSource randomSource, GameData.Domains.Character.Character character, short adventureId)
	{
		sbyte enemyNestTemplateId = AdventureDomain.GetEnemyNestTemplateId(adventureId);
		EnemyNestItem enemyNestCfg = EnemyNest.Instance[enemyNestTemplateId];
		CharacterItem nestLeaderCfg = Config.Character.Instance[enemyNestCfg.Leader];
		GameData.Domains.Character.Character nestLeader = DomainManager.Character.GetPregeneratedRandomEnemy(nestLeaderCfg.RandomEnemyId);
		int characterCombatPower = character.GetCombatPower();
		int nestLeaderCombatPower = nestLeader.GetCombatPower();
		int rate = characterCombatPower * 100 / nestLeaderCombatPower - 100;
		return randomSource.CheckPercentProb(rate);
	}

	public override void ValidationHandler()
	{
		if (!DomainManager.World.GetWorldFunctionsStatus(7))
		{
			return;
		}
		for (short areaId = 0; areaId < 45; areaId++)
		{
			for (int index = _enemyNestActionsInAreas[areaId].Count - 1; index >= 0; index--)
			{
				ConfigMonthlyAction configAction = _enemyNestActionsInAreas[areaId][index];
				configAction.ValidationHandler();
			}
		}
	}

	public override void FillEventArgBox(EventArgBox eventArgBox)
	{
		eventArgBox.Get("AdventureLocation", out Location location);
		if (location.IsValid())
		{
			ConfigMonthlyAction configAction = GetConfigAction(location.AreaId, location.BlockId);
			configAction.EnsurePrerequisites();
			configAction.FillEventArgBox(eventArgBox);
		}
	}

	public override void CollectCalledCharacters(HashSet<int> calledCharacters)
	{
		List<ConfigMonthlyAction>[] enemyNestActionsInAreas = _enemyNestActionsInAreas;
		foreach (List<ConfigMonthlyAction> areaActions in enemyNestActionsInAreas)
		{
			foreach (ConfigMonthlyAction item in areaActions)
			{
				item?.CollectCalledCharacters(calledCharacters);
			}
		}
	}

	private void UpdateEnemiesInArea(DataContext context, short areaId)
	{
		if (_enemyNestActionsInAreas.Length <= areaId)
		{
			return;
		}
		List<ConfigMonthlyAction> nestsInArea = _enemyNestActionsInAreas[areaId];
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(areaId);
		MapAreaItem areaCfg = areaData.GetConfig();
		if (areaCfg.EnemyNests == null)
		{
			return;
		}
		IRandomSource random = context.Random;
		int currDate = DomainManager.World.GetCurrDate();
		int i = 0;
		for (int count = areaCfg.EnemyNests.Count; i < count; i++)
		{
			if (nestsInArea.Count > i)
			{
				ConfigMonthlyAction action = nestsInArea[i];
				if (action != null)
				{
					continue;
				}
			}
			else
			{
				nestsInArea.Add(null);
			}
			EnemyNestCreationInfo creationInfo = areaCfg.EnemyNests[i].GetRandom(random);
			EnemyNestItem nestCfg = EnemyNest.Instance[creationInfo.EnemyNest];
			int beginDate = Math.Max(DomainManager.Extra.GetEnemyNestInitializationDate(areaId, i), currDate);
			nestsInArea[i] = new ConfigMonthlyAction(Key, nestCfg.MonthlyActionId, areaId);
		}
	}

	public ConfigMonthlyAction GetConfigAction(short areaId, short blockId)
	{
		foreach (ConfigMonthlyAction configAction in _enemyNestActionsInAreas[areaId])
		{
			if (configAction != null && configAction.Location.BlockId == blockId)
			{
				return configAction;
			}
		}
		return null;
	}

	public void DeactivateSubAction(short areaId, short blockId, bool isComplete)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(areaId);
		MapAreaItem areaConfig = areaData.GetConfig();
		List<ConfigMonthlyAction> nestsInArea = _enemyNestActionsInAreas[areaId];
		int index = 0;
		for (int count = nestsInArea.Count; index < count; index++)
		{
			ConfigMonthlyAction configAction = nestsInArea[index];
			if (configAction != null && configAction.Location.BlockId == blockId)
			{
				VillagerWorkData workData = DomainManager.Taiwu.GetVillagerMapWorkData(areaId, blockId, 11);
				if (workData != null)
				{
					DomainManager.Taiwu.RemoveVillagerWork(context, workData.CharacterId);
					Location location = configAction.Location;
					short adventureId = configAction.ConfigData.AdventureId;
					InstantNotificationCollection instantNotifications = DomainManager.World.GetInstantNotificationCollection();
					instantNotifications.AddTheNestOfRegulationDies(location, adventureId, workData.CharacterId);
				}
				configAction.Deactivate(isComplete);
				if (areaConfig.EnemyNests.CheckIndex(index))
				{
					EnemyNestCreationInfo creationInfo = areaConfig.EnemyNests[index].GetRandom(context.Random);
					EnemyNestItem nestCfg = EnemyNest.Instance[creationInfo.EnemyNest];
					nestsInArea[index] = new ConfigMonthlyAction(Key, nestCfg.MonthlyActionId, areaId)
					{
						LastFinishDate = DomainManager.World.GetCurrDate()
					};
				}
				else
				{
					nestsInArea.RemoveAt(index);
				}
				break;
			}
		}
	}

	internal void ResetIntervals()
	{
		List<ConfigMonthlyAction>[] enemyNestActionsInAreas = _enemyNestActionsInAreas;
		foreach (List<ConfigMonthlyAction> areaActions in enemyNestActionsInAreas)
		{
			foreach (ConfigMonthlyAction action in areaActions)
			{
				if (action != null && action.State == 0)
				{
					action.LastFinishDate = int.MinValue;
				}
			}
		}
	}

	public override MonthlyActionBase CreateCopy()
	{
		return GameData.Serializer.Serializer.CreateCopy(this);
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 12;
		if (_enemyNestActionsInAreas != null)
		{
			totalSize += 2;
			List<ConfigMonthlyAction>[] enemyNestActionsInAreas = _enemyNestActionsInAreas;
			foreach (List<ConfigMonthlyAction> actionsInArea in enemyNestActionsInAreas)
			{
				totalSize += 2;
				foreach (ConfigMonthlyAction action in actionsInArea)
				{
					totalSize += action.GetSerializedSize();
				}
			}
		}
		else
		{
			totalSize += 2;
		}
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (_enemyNestActionsInAreas != null)
		{
			int elementsCount = _enemyNestActionsInAreas.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			List<ConfigMonthlyAction>[] enemyNestActionsInAreas = _enemyNestActionsInAreas;
			foreach (List<ConfigMonthlyAction> actionsInArea in enemyNestActionsInAreas)
			{
				*(ushort*)pCurrData = (ushort)actionsInArea.Count;
				pCurrData += 2;
				foreach (ConfigMonthlyAction action in actionsInArea)
				{
					pCurrData += action.Serialize(pCurrData);
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += Key.Serialize(pCurrData);
		*pCurrData = (byte)State;
		pCurrData++;
		*(int*)pCurrData = Month;
		pCurrData += 4;
		*(int*)pCurrData = LastFinishDate;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (_enemyNestActionsInAreas == null || _enemyNestActionsInAreas.Length != elementsCount)
		{
			_enemyNestActionsInAreas = new List<ConfigMonthlyAction>[elementsCount];
		}
		for (int i = 0; i < elementsCount; i++)
		{
			if (_enemyNestActionsInAreas[i] == null)
			{
				_enemyNestActionsInAreas[i] = new List<ConfigMonthlyAction>();
			}
			else
			{
				_enemyNestActionsInAreas[i].Clear();
			}
			ushort subElementCount = *(ushort*)pCurrData;
			pCurrData += 2;
			for (int j = 0; j < subElementCount; j++)
			{
				ConfigMonthlyAction action = new ConfigMonthlyAction();
				pCurrData += action.Deserialize(pCurrData);
				_enemyNestActionsInAreas[i].Add(action);
			}
		}
		pCurrData += Key.Deserialize(pCurrData);
		State = (sbyte)(*pCurrData);
		pCurrData++;
		Month = *(int*)pCurrData;
		pCurrData += 4;
		LastFinishDate = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
