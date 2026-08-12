using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions;

[SerializableGameData(NotForDisplayModule = true)]
public class SeasonalMonthlyAction : MonthlyActionBase, IMonthlyActionGroup, ISerializableGameData
{
	[SerializableGameDataField]
	private int _prevSpringDate;

	[SerializableGameDataField]
	private int _prevSummerDate;

	[SerializableGameDataField]
	private int _prevAutumnDate;

	[SerializableGameDataField]
	private int _prevWinterDate;

	[SerializableGameDataField]
	private Dictionary<Location, ConfigMonthlyAction> _monthlyActions;

	public SeasonalMonthlyAction(MonthlyActionKey key)
	{
		Key = key;
		_prevSpringDate = 0;
		_prevSummerDate = 0;
		_prevAutumnDate = 0;
		_prevWinterDate = 0;
		_monthlyActions = new Dictionary<Location, ConfigMonthlyAction>();
	}

	public override void MonthlyHandler()
	{
		if (!DomainManager.World.GetWorldFunctionsStatus(4))
		{
			return;
		}
		ClearInvalidActions();
		TriggerAction();
		foreach (var (location2, action) in _monthlyActions)
		{
			action.MonthlyHandler();
		}
	}

	private void ClearInvalidActions()
	{
		List<Location> toRemove = null;
		foreach (var (location2, action) in _monthlyActions)
		{
			if (!action.Location.IsValid() || !(action.Location == location2))
			{
				if (toRemove == null)
				{
					toRemove = new List<Location>();
				}
				toRemove.Add(location2);
			}
		}
		if (toRemove == null)
		{
			return;
		}
		foreach (Location location3 in toRemove)
		{
			AdaptableLog.Info($"Removing invalid seasonal action at {location3}.");
			_monthlyActions.Remove(location3);
		}
	}

	public override MonthlyActionBase CreateCopy()
	{
		return GameData.Serializer.Serializer.CreateCopy(this);
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
		foreach (var (location2, action) in _monthlyActions)
		{
			action.CollectCalledCharacters(calledCharacters);
		}
	}

	public void DeactivateSubAction(short areaId, short blockId, bool isComplete)
	{
		Location location = new Location(areaId, blockId);
		ConfigMonthlyAction action = _monthlyActions[location];
		action.Deactivate(isComplete);
		_monthlyActions.Remove(location);
	}

	public ConfigMonthlyAction GetConfigAction(short areaId, short blockId)
	{
		return _monthlyActions[new Location(areaId, blockId)];
	}

	public ConfigMonthlyAction CreateNewConfigAction(short templateId, Location location)
	{
		ConfigMonthlyAction action = new ConfigMonthlyAction(templateId, -1)
		{
			Key = Key,
			Location = location
		};
		if (!location.IsValid())
		{
			action.SelectLocation();
		}
		action.TriggerAction();
		if (action.Location.IsValid())
		{
			_monthlyActions.Add(action.Location, action);
		}
		return action;
	}

	private bool IsValidSettlement(short settlementId)
	{
		List<short> blockIds = ObjectPool<List<short>>.Instance.Get();
		blockIds.Clear();
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		Location location = settlement.GetLocation();
		if (IsBlockIdValid(location.BlockId))
		{
			return true;
		}
		DomainManager.Map.GetSettlementBlocks(location.AreaId, location.BlockId, blockIds);
		bool hasValidBlock = blockIds.Exists(IsBlockIdValid);
		ObjectPool<List<short>>.Instance.Return(blockIds);
		return hasValidBlock;
		bool IsBlockIdValid(short blockId)
		{
			return !DomainManager.Adventure.QueryAnyAdventureOrMajorEvent(location.AreaId, blockId);
		}
	}

	public SeasonalMonthlyAction()
	{
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 28;
		if (_monthlyActions != null)
		{
			totalSize += 2;
			foreach (KeyValuePair<Location, ConfigMonthlyAction> monthlyAction in _monthlyActions)
			{
				monthlyAction.Deconstruct(out var key, out var value);
				Location location = key;
				ConfigMonthlyAction action = value;
				totalSize += location.GetSerializedSize();
				totalSize += action.GetSerializedSize();
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
		pCurrData += Key.Serialize(pCurrData);
		*pCurrData = (byte)State;
		pCurrData++;
		*(int*)pCurrData = Month;
		pCurrData += 4;
		*(int*)pCurrData = LastFinishDate;
		pCurrData += 4;
		*(int*)pCurrData = _prevSpringDate;
		pCurrData += 4;
		*(int*)pCurrData = _prevSummerDate;
		pCurrData += 4;
		*(int*)pCurrData = _prevAutumnDate;
		pCurrData += 4;
		*(int*)pCurrData = _prevWinterDate;
		pCurrData += 4;
		if (_monthlyActions != null)
		{
			int elementsCount = _monthlyActions.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			foreach (KeyValuePair<Location, ConfigMonthlyAction> monthlyAction in _monthlyActions)
			{
				monthlyAction.Deconstruct(out var key, out var value);
				Location location = key;
				ConfigMonthlyAction action = value;
				pCurrData += location.Serialize(pCurrData);
				pCurrData += action.Serialize(pCurrData);
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

	public unsafe override int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += Key.Deserialize(pCurrData);
		State = (sbyte)(*pCurrData);
		pCurrData++;
		Month = *(int*)pCurrData;
		pCurrData += 4;
		LastFinishDate = *(int*)pCurrData;
		pCurrData += 4;
		_prevSpringDate = *(int*)pCurrData;
		pCurrData += 4;
		_prevSummerDate = *(int*)pCurrData;
		pCurrData += 4;
		_prevAutumnDate = *(int*)pCurrData;
		pCurrData += 4;
		_prevWinterDate = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (_monthlyActions == null)
		{
			_monthlyActions = new Dictionary<Location, ConfigMonthlyAction>();
		}
		else
		{
			_monthlyActions.Clear();
		}
		for (int i = 0; i < elementsCount; i++)
		{
			Location location = default(Location);
			ConfigMonthlyAction action = new ConfigMonthlyAction();
			pCurrData += location.Deserialize(pCurrData);
			pCurrData += action.Deserialize(pCurrData);
			_monthlyActions.Add(location, action);
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
