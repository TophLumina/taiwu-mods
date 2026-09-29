using System;
using System.Collections.Generic;
using GameData.Adventure;
using GameData.Common;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.World.Notification;
using GameData.GameDataBridge;
using GameData.Utilities;
using Google.Protobuf.Collections;
using NLog;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class MajorEventFunctions
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[EventFunction(304)]
	private static bool MajorEventExitAndDelete(EventScriptRuntime runtime, bool removeMajorEvent = true)
	{
		return removeMajorEvent ? DomainManager.Adventure.ExitAndRemoveMajorEvent(runtime.Context, EAdventureRemoveType.Complete) : DomainManager.Adventure.ExitMajorEvent(runtime.Context);
	}

	[EventFunction(374)]
	private static bool MajorEventExitAndDeleteAndInvokeOther(EventScriptRuntime runtime, string postEvent, bool removeMajorEvent = true)
	{
		bool result = (removeMajorEvent ? DomainManager.Adventure.ExitAndRemoveMajorEvent(runtime.Context, EAdventureRemoveType.Complete) : DomainManager.Adventure.ExitMajorEvent(runtime.Context));
		if (!string.IsNullOrEmpty(postEvent) && result)
		{
			EventArgBox argBox = DomainManager.TaiwuEvent.GetEventArgBox();
			runtime.ArgBox.CloneTo(argBox);
			DomainManager.TaiwuEvent.SetListenerWithActionName(postEvent, argBox, "ExitMajorEvent");
		}
		return result;
	}

	[Obsolete]
	private static bool MajorEventExitAndDeleteNew(EventScriptRuntime runtime, string postEvent, bool removeMajorEvent = true, bool skipCompleteAnim = false)
	{
		if (skipCompleteAnim)
		{
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.MajorEventSkipCompleteAnim);
		}
		bool result = (removeMajorEvent ? DomainManager.Adventure.ExitAndRemoveMajorEvent(runtime.Context, EAdventureRemoveType.Complete) : DomainManager.Adventure.ExitMajorEvent(runtime.Context));
		if (!string.IsNullOrEmpty(postEvent) && result)
		{
			EventArgBox argBox = DomainManager.TaiwuEvent.GetEventArgBox();
			runtime.ArgBox.CloneTo(argBox);
			DomainManager.TaiwuEvent.SetListenerWithActionName(postEvent, argBox, "ExitMajorEvent");
		}
		return result;
	}

	[EventFunction(856)]
	private static void MajorEventSetSkipFinishAnim(EventScriptRuntime runtime)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.MajorEventSkipCompleteAnim);
	}

	[EventFunction(353)]
	private static bool MajorEventCreate(EventScriptRuntime runtime, MapBlockData mapBlockData, int id)
	{
		return DomainManager.Adventure.GenerateMajorEvent(runtime.Context, id, mapBlockData.GetLocation());
	}

	[EventFunction(780)]
	private static bool MajorEventCreateAndEnter(EventScriptRuntime runtime, int coreId, string afterEvent)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwu.GetLocation();
		IAdventureRuntime adventureRuntime = DomainManager.Adventure.GenerateAny(runtime.Context, coreId, taiwuLocation);
		if (adventureRuntime == null)
		{
			Logger.Warn("MajorEventCreateAndEnter:GenerateMajorEvent fail");
			return false;
		}
		if (!DomainManager.Adventure.EnterAny(runtime.Context, adventureRuntime, null))
		{
			Logger.Warn("MajorEventCreateAndEnter:EnterMajorEvent fail");
			return false;
		}
		if (!string.IsNullOrEmpty(afterEvent))
		{
			DomainManager.TaiwuEvent.SetListenerWithActionName(afterEvent, runtime.ArgBox, "ExitMajorEvent");
		}
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.EnterMajorEventFromEvent, adventureRuntime.Id);
		return true;
	}

	[EventFunction(443)]
	private static void MajorEventGetNodeReward(EventScriptRuntime runtime, int index)
	{
		AdventureMajorEventTaiwu majorEventTaiwu = DomainManager.Adventure.GetAdventureMajorEventTaiwu();
		if (majorEventTaiwu.NotInAdventure)
		{
			Logger.Warn("Not in majorEvent,but invoke MajorEventGetNodeReward");
			return;
		}
		DataContext context = runtime.Context;
		AdventureMajorEvent majorEvent = DomainManager.Adventure.GetElement_AdventureMajorEvents(majorEventTaiwu.AdventureId);
		AdventureMajorEventData majorEventData = majorEvent.Core;
		AdventureMajorEventNodeData nodeData = majorEventData.Nodes[majorEventTaiwu.Current];
		AdventureMajorEventRewardData rewards = nodeData.Rewards[index];
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotifications();
		AdventureCostItem item = rewards.Item;
		if (item != null)
		{
			RepeatedField<AdventureItemReference> availableItems = item.AvailableItems;
			if (availableItems != null && availableItems.Count > 0)
			{
				foreach (AdventureItemReference item2 in rewards.Item.AvailableItems)
				{
					ItemKey itemKey = DomainManager.Item.CreateItem(context, (sbyte)item2.Type, (short)item2.TemplateId);
					taiwu.AddInventoryItem(context, itemKey, 1);
					runtime.Current.RegisterToShowGetItem(itemKey, 1);
					instantNotification.AddGetItem(taiwu.GetId(), itemKey.ItemType, itemKey.TemplateId);
				}
			}
		}
		AdventureResourceGroup resource = rewards.Resource;
		if (resource != null)
		{
			RepeatedField<AdventureCostResource> resources = resource.Resources;
			if (resources != null && resources.Count > 0)
			{
				foreach (AdventureCostResource resource2 in rewards.Resource.Resources)
				{
					taiwu.ChangeResource(context, (sbyte)resource2.Type, resource2.Value);
					runtime.Current.RegisterToShowGetResource((sbyte)resource2.Type, resource2.Value);
					instantNotification.AddResourceIncreased(taiwu.GetId(), (sbyte)resource2.Type, resource2.Value);
				}
			}
		}
		if (rewards.Exp > 0)
		{
			taiwu.ChangeExp(context, rewards.Exp);
			instantNotification.AddExpIncreased(taiwu.GetId(), rewards.Exp);
		}
	}

	[EventFunction(450)]
	private static void RemoveAllMajorEventByCoreId(EventScriptRuntime runtime, int coreId)
	{
		List<int> removeMajorEventIds = ObjectPool<List<int>>.Instance.Get();
		foreach (AdventureMajorEvent majorEvent in DomainManager.Adventure.QueryMajorEventsByCoreId(coreId))
		{
			removeMajorEventIds.Add(majorEvent.Id);
		}
		foreach (int removeMajorEventId in removeMajorEventIds)
		{
			DomainManager.Adventure.RemoveMajorEvent(runtime.Context, removeMajorEventId, EAdventureRemoveType.Instruction);
		}
		ObjectPool<List<int>>.Instance.Return(removeMajorEventIds);
	}

	[EventFunction(927)]
	private static void RemoveAllAdventureByCoreId(EventScriptRuntime runtime, int coreId)
	{
		DomainManager.Adventure.RemoveAnyInWorld(runtime.Context, coreId);
	}

	[EventFunction(606)]
	private static void MajorEventSetAtmosphere(EventScriptRuntime runtime, int atmosphereType)
	{
		AdventureMajorEvent majorEvent = DomainManager.Adventure.GetElement_AdventureMajorEvents(DomainManager.Adventure.GetAdventureMajorEventTaiwu().AdventureId);
		majorEvent.SetParameter("ConchShipPresetKey_MajorEventAtmosphereType", atmosphereType);
		DataContext context = runtime.Context;
		DomainManager.Adventure.SetAny(context, majorEvent);
	}

	[EventFunction(607)]
	private static void MajorEventClearAtmosphere(EventScriptRuntime runtime)
	{
		AdventureMajorEvent majorEvent = DomainManager.Adventure.GetElement_AdventureMajorEvents(DomainManager.Adventure.GetAdventureMajorEventTaiwu().AdventureId);
		majorEvent.RemoveParameter("ConchShipPresetKey_MajorEventAtmosphereType");
		DataContext context = runtime.Context;
		DomainManager.Adventure.SetAny(context, majorEvent);
	}
}
