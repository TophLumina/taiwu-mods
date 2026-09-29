using System;
using System.Collections.Generic;
using System.Linq;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using GameData.Adventure;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Creation;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Taiwu.VillagerRole;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World;
using GameData.GameDataBridge;
using GameData.Utilities;
using NLog;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class AdventureRemakeFunctions
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	[EventFunction(220)]
	private static void SetAdventureParameter(EventScriptRuntime runtime, string paramName, int setValue)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureParameterValue parameterValue = adventureRuntime.GetParameter(paramName);
			if (SetParameter(ref parameterValue, setValue, paramName))
			{
				adventureRuntime.SetParameter(paramName, parameterValue);
				DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
			}
		}
	}

	private static bool SetParameter(ref AdventureParameterValue parameterValue, int setValue, string paramKey)
	{
		parameterValue.Set(setValue);
		return true;
	}

	[EventFunction(221)]
	private static ValueInfo ChangeAdventureParameter(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string paramName = parameters[0].GetStringValue(evaluator);
			int changeValue = parameters[1].GetIntValue(evaluator);
			adventureRuntime.ChangeParameter(paramName, changeValue);
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(223)]
	private static void SetAdventureParameterStartWith(EventScriptRuntime runtime, string paramName, int setValue)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		int adventureCoreId = adventureRuntime.CoreId;
		AdventureData adventureData = AdventureDomain.Core.GetAdventureData(adventureCoreId);
		foreach (AdventureParameterData parameterData in adventureData.Parameters)
		{
			if (parameterData.Key.StartsWith(paramName))
			{
				AdventureParameterValue parameterValue = adventureRuntime.GetParameter(parameterData.Key);
				if (SetParameter(ref parameterValue, setValue, parameterData.Key))
				{
					adventureRuntime.SetParameter(parameterData.Key, parameterValue);
				}
			}
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
	}

	[EventFunction(224)]
	private static ValueInfo ChangeAdventureParameterStartWith(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string paramName = parameters[0].GetStringValue(evaluator);
			int changeValue = parameters[1].GetIntValue(evaluator);
			int adventureCoreId = adventureRuntime.CoreId;
			AdventureData adventureData = AdventureDomain.Core.GetAdventureData(adventureCoreId);
			foreach (AdventureParameterData parameterData in adventureData.Parameters)
			{
				if (parameterData.Key.StartsWith(paramName))
				{
					adventureRuntime.ChangeParameter(parameterData.Key, changeValue);
				}
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(235)]
	private static void AdventureCreateItem(EventScriptRuntime runtime, UnmanagedVariant<TemplateKey> itemTemplate, int count)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		if (ItemTemplateHelper.IsStackable(itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId))
		{
			ItemKey itemKey = DomainManager.Item.CreateItem(runtime.Context, itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId);
			adventureRuntime.AddTemporaryItemTaiwu(runtime.Context, itemKey, count);
			runtime.Current.RegisterToShowGetItem(itemKey, count);
		}
		else
		{
			for (int i = 0; i < count; i++)
			{
				ItemKey itemKey2 = DomainManager.Item.CreateItem(runtime.Context, itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId);
				adventureRuntime.AddTemporaryItemTaiwu(runtime.Context, itemKey2);
				runtime.Current.RegisterToShowGetItem(itemKey2, 1);
			}
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
	}

	[EventFunction(236)]
	private static void AdventureRemoveItem(EventScriptRuntime runtime, UnmanagedVariant<TemplateKey> itemTemplate)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			ItemKey itemKey = adventureRuntime.GetTemporaryItemFirstTaiwu(itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId)?.ItemKey ?? ItemKey.Invalid;
			if (itemKey.IsValid())
			{
				adventureRuntime.RemoveTemporaryItemTaiwu(runtime.Context, itemKey);
				DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
			}
		}
	}

	[EventFunction(474)]
	private static void AdventureConsumeItem(EventScriptRuntime runtime, UnmanagedVariant<TemplateKey> itemTemplate, int count)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		GameData.Domains.Adventure.AdventureItem item = adventureRuntime.GetTemporaryItemFirstTaiwu(itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId);
		if (item != null)
		{
			if (!item.ChangeCount(-count))
			{
				adventureRuntime.RemoveTemporaryItemTaiwu(runtime.Context, item.ItemKey);
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
	}

	[EventFunction(240)]
	private static ValueInfo AdventureSetAutoDeleteDate(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int deleteDate = parameters[0].GetIntValue(evaluator);
			adventureRuntime.SetAutoDeleteDate((uint)deleteDate);
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(241)]
	private static void AdventureExit(EventScriptRuntime runtime, string afterEvent)
	{
		AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
		if (adventureTaiwu.InAdventure)
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddAdventureRemakeExitEvent(afterEvent, runtime.ArgBox);
			AdventureExitResetCharacterState(runtime);
			AdventureExitResetElementParameter(runtime);
			AdventureExitResetElementBlockIndex(runtime, IntList.Create());
			AdventureExitInterruptAllActions(runtime);
			AdventureExitResetTaiwuBuff(runtime);
			DomainManager.Adventure.ExitAdventureImmediate(runtime.Context);
		}
	}

	[EventFunction(687)]
	private static void AdventureExitNotReset(EventScriptRuntime runtime, string afterEvent)
	{
		AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
		if (adventureTaiwu.InAdventure)
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddAdventureRemakeExitEvent(afterEvent, runtime.ArgBox);
			DomainManager.Adventure.ExitAdventureImmediate(runtime.Context);
		}
	}

	[EventFunction(688)]
	private static void AdventureExitResetCharacterState(EventScriptRuntime runtime)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		DataContext context = runtime.Context;
		foreach (AdventureElement element in adventureRuntime.GetAllElements())
		{
			if (DomainManager.Character.TryGetElement_Objects(element.CharacterId, out var character))
			{
				Injuries injuries = default(Injuries);
				injuries.Initialize();
				character.SetInjuries(injuries, context);
				PoisonInts poisoned = default(PoisonInts);
				poisoned.Initialize();
				character.SetPoisoned(ref poisoned, context);
				character.SetDisorderOfQi(DisorderLevelOfQi.MinValue, context);
				character.ChangeHealth(context, int.MaxValue);
			}
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
	}

	[EventFunction(689)]
	private static void AdventureExitResetElementParameter(EventScriptRuntime runtime)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		foreach (AdventureElement element in adventureRuntime.GetAllElements())
		{
			foreach (AdventureParameterData data in element.Core.Parameters)
			{
				element.SetParameter(data.Key, new AdventureParameterValue(data.Type, data.InitialValue));
			}
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
	}

	[EventFunction(690)]
	private static void AdventureExitResetElementBlockIndex(EventScriptRuntime runtime, IntList elementIdList)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		foreach (AdventureElement element in adventureRuntime.GetAllElements())
		{
			if (!elementIdList.Items.Contains(element.Id))
			{
				element.SetIndex(element.ResetTarget);
			}
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
	}

	[EventFunction(691)]
	private static void AdventureExitInterruptAllActions(EventScriptRuntime runtime)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			adventureRuntime.InterruptAllActions();
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
	}

	[EventFunction(692)]
	private static void AdventureExitResetTaiwuBuff(EventScriptRuntime runtime)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		AdventureData adventureData = AdventureDomain.Core.GetAdventureData(adventureRuntime.CoreId);
		foreach (AdventureParameterData data in adventureData.Parameters)
		{
			if (data.Type == EAdventureParameterType.State && data.Style == 0 && adventureRuntime.GetParameter(data.Key).Current > 0)
			{
				adventureRuntime.SetParameter(data.Key, new AdventureParameterValue(data.Type, 0));
			}
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
	}

	[EventFunction(259)]
	private static ValueInfo AdventureElementFillByGroup(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			int groupId = parameters[1].GetIntValue(evaluator);
			int minCount = parameters[2].GetIntValue(evaluator);
			int maxCount = parameters[3].GetIntValue(evaluator);
			int count = runtime.Context.Random.Next(minCount, maxCount);
			List<(int, int)> blockList = new List<(int, int)>();
			foreach (AdventureBlockData blockData in adventureRuntime.CoreBlocks)
			{
				if (blockData.GroupIds.Contains(groupId) && !blockList.Contains((blockData.Index.X, blockData.Index.Y)))
				{
					blockList.Add((blockData.Index.X, blockData.Index.Y));
				}
			}
			CollectionUtils.Shuffle(runtime.Context.Random, blockList);
			for (int i = 0; i < blockList.Count && i < count; i++)
			{
				(int, int) coord = blockList[i];
				for (int j = 0; j < 9; j++)
				{
					DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, new AdventureBlockIndex(coord.Item1, coord.Item2, j));
				}
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(622)]
	private static void AdventureCreateElementAtAllBlock(EventScriptRuntime runtime, int elementCoreId, int count)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		foreach (AdventureBlockData blockData in adventureRuntime.CoreBlocks)
		{
			for (int i = 0; i < count; i++)
			{
				DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, blockData.Index);
			}
		}
	}

	[EventFunction(309)]
	private static ValueInfo AdventureCreateElementAtGroup(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			int groupId = parameters[1].GetIntValue(evaluator);
			int minCount = parameters[2].GetIntValue(evaluator);
			int maxCount = parameters[3].GetIntValue(evaluator);
			bool canRepeat = parameters[4].GetBoolValue(evaluator);
			int count = runtime.Context.Random.Next(minCount, maxCount);
			List<AdventureBlockIndex> blockIndexList = new List<AdventureBlockIndex>();
			foreach (AdventureBlockData blockData in adventureRuntime.CoreBlocks)
			{
				if (blockData.GroupIds.Contains(groupId) && !blockIndexList.Contains(blockData.Index) && (canRepeat || !adventureRuntime.GetElements(blockData.Index).Any()))
				{
					blockIndexList.Add(blockData.Index);
				}
			}
			CollectionUtils.Shuffle(runtime.Context.Random, blockIndexList);
			for (int i = 0; i < count && (canRepeat || i < blockIndexList.Count); i++)
			{
				AdventureBlockIndex blockIndex = blockIndexList[i % blockIndexList.Count];
				DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, blockIndex);
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(340)]
	private static ValueInfo AdventureCreateElementAtGroupWithTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string inputTags = parameters[0].GetStringValue(evaluator);
			int groupId = parameters[1].GetIntValue(evaluator);
			int minCount = parameters[2].GetIntValue(evaluator);
			int maxCount = parameters[3].GetIntValue(evaluator);
			bool canRepeat = parameters[4].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[5].GetIntValue(evaluator);
			List<AdventureBlockIndex> blockIndexList = (from blockData in adventureRuntime.CoreBlocks
				where blockData.GroupIds.Contains(groupId)
				select blockData.Index).Distinct().ToList();
			if (blockIndexList.Count <= 0)
			{
				Logger.Warn("AdventureCreateElementAtGroupWithTag,blockIndexList.Count == 0");
				return ValueInfo.Void;
			}
			List<string> tags = ParseInputTags(inputTags);
			IEnumerable<AdventureElementData> matchedElements = AdventureDomain.Core.AllAdventureElements.Where((AdventureElementData element) => CheckAdventureElementTagsMatch(element.Tags.ToList(), tags, tagArrayMatchType));
			List<int> coreIdList = matchedElements.Select((AdventureElementData element) => element.Id).Distinct().ToList();
			if (coreIdList.Count <= 0)
			{
				Logger.Warn("AdventureCreateElementAtGroupWithTag,coreIdList.Count == 0");
				return ValueInfo.Void;
			}
			CollectionUtils.Shuffle(runtime.Context.Random, blockIndexList);
			CollectionUtils.Shuffle(runtime.Context.Random, coreIdList);
			int needCount = runtime.Context.Random.Next(minCount, maxCount);
			int createCount = Math.Min(needCount, blockIndexList.Count);
			for (int i = 0; i < createCount && (canRepeat || i < coreIdList.Count); i++)
			{
				AdventureBlockIndex blockIndex = blockIndexList[i];
				int elementCoreId = coreIdList[i % coreIdList.Count];
				DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, blockIndex);
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(260)]
	private static ValueInfo AdventureElementFillByElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreIdDepend = parameters[0].GetIntValue(evaluator);
			string inputTags = parameters[1].GetStringValue(evaluator);
			List<string> tags = ParseInputTags(inputTags);
			int tagArrayMatchType = parameters[2].GetIntValue(evaluator);
			int minCount = parameters[3].GetIntValue(evaluator);
			int maxCount = parameters[4].GetIntValue(evaluator);
			int count = runtime.Context.Random.Next(minCount, maxCount);
			List<(int, int)> blockList = (from element in adventureRuntime.GetElementsByCoreId(elementCoreIdDepend)
				select (X: element.Index.X, Y: element.Index.Y)).Distinct().ToList();
			List<int> matchedElements = (from element in AdventureDomain.Core.AllAdventureElements
				where CheckAdventureElementTagsMatch(element.Tags.ToList(), tags, tagArrayMatchType)
				select element.Id).ToList();
			if (matchedElements.Count == 0 || blockList.Count == 0)
			{
				Logger.Warn("AdventureElementFillByElement,matchedElements.Count == 0 || blockList.Count == 0");
				return ValueInfo.Void;
			}
			foreach (var coord in blockList.Take(count))
			{
				DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, matchedElements.GetRandom(runtime.Context.Random), new AdventureBlockIndex(coord.Item1, coord.Item2, runtime.Context.Random.Next(0, 9)));
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(264)]
	private static void AdventureDelete(EventScriptRuntime runtime, bool success, string afterEvent)
	{
		AdventureDeleteNew(runtime, success, afterEvent);
	}

	[EventFunction(811)]
	private static void AdventureDeleteNew(EventScriptRuntime runtime, bool success, string afterEvent, bool skipCompleteAnim = false)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			if (adventureTaiwu.AdventureId == adventureId)
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddAdventureRemakeExitEvent(afterEvent, runtime.ArgBox);
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AdventureRemakeFinish(success, skipCompleteAnim);
			}
		}
	}

	[EventFunction(266)]
	private static void SetAdventureElementParameter(EventScriptRuntime runtime, int elementId, string paramName, int setValue)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement element = adventureRuntime.GetElement(elementId);
			AdventureParameterValue parameterValue = element.GetParameter(paramName);
			if (SetParameter(ref parameterValue, setValue, paramName))
			{
				element.SetParameter(paramName, parameterValue);
				DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
			}
		}
	}

	[EventFunction(267)]
	private static ValueInfo ChangeAdventureElementParameter(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			string paramName = parameters[1].GetStringValue(evaluator);
			int changeValue = parameters[2].GetIntValue(evaluator);
			element.ChangeParameter(paramName, changeValue);
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(268)]
	private static ValueInfo AdventureChangeElementCountAtTaiwuLocation(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			int changeCount = parameters[1].GetIntValue(evaluator);
			if (changeCount == 0)
			{
				return ValueInfo.Void;
			}
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			if (changeCount > 0)
			{
				for (int i = 0; i < changeCount; i++)
				{
					DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, adventureTaiwu.Index);
				}
			}
			else
			{
				List<AdventureElement> elements = adventureRuntime.GetElements(adventureTaiwu.Index).ToList();
				changeCount = -changeCount;
				int count = 0;
				for (int i2 = elements.Count - 1; i2 >= 0; i2--)
				{
					AdventureElement element = elements[i2];
					if (element.CoreId == elementCoreId)
					{
						adventureRuntime.RemoveElement(element.Id);
						count++;
					}
					if (count >= changeCount)
					{
						break;
					}
				}
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(774)]
	private static ValueInfo AdventureChangeElementCountAtTaiwuLocationBig(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			int changeCount = parameters[1].GetIntValue(evaluator);
			if (changeCount == 0)
			{
				return ValueInfo.Void;
			}
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			List<AdventureBlockIndexForSerialize> blocks = adventureRuntime.CoreBlocks.Where((AdventureBlockData b) => b.Index.X == adventureTaiwu.Index.X && b.Index.Y == adventureTaiwu.Index.Y).Select((Func<AdventureBlockData, AdventureBlockIndexForSerialize>)((AdventureBlockData b) => b.Index)).ToList();
			if (changeCount > 0)
			{
				for (int i = 0; i < changeCount; i++)
				{
					AdventureBlockIndexForSerialize block = blocks.GetRandom(runtime.Context.Random);
					DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, block);
				}
			}
			else
			{
				List<AdventureElement> elementList = new List<AdventureElement>();
				foreach (AdventureBlockIndexForSerialize block2 in blocks)
				{
					List<AdventureElement> elements = adventureRuntime.GetElements(block2).ToList();
					elementList.AddRange(elements);
				}
				changeCount = -changeCount;
				int count = 0;
				for (int i2 = elementList.Count - 1; i2 >= 0; i2--)
				{
					AdventureElement element = elementList[i2];
					if (element.CoreId == elementCoreId)
					{
						adventureRuntime.RemoveElement(element.Id);
						count++;
					}
					if (count >= changeCount)
					{
						break;
					}
				}
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(269)]
	private static ValueInfo AdventureClearElementAtTaiwuLocation(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			List<AdventureElement> elements = adventureRuntime.GetElements(adventureTaiwu.Index).ToList();
			for (int i = elements.Count - 1; i >= 0; i--)
			{
				AdventureElement element = elements[i];
				if (element.CoreId == elementCoreId)
				{
					adventureRuntime.RemoveElement(element.Id);
				}
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(270)]
	private static ValueInfo AdventureClearElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			List<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId).ToList();
			for (int i = elements.Count - 1; i >= 0; i--)
			{
				AdventureElement element = elements[i];
				adventureRuntime.RemoveElement(element.Id);
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(271)]
	private static ValueInfo AdventureDeleteElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			int deleteCount = parameters[1].GetIntValue(evaluator);
			bool showAnim = parameters[2].GetBoolValue(evaluator);
			List<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId).ToList();
			Tester.Assert(deleteCount >= 0);
			int count = 0;
			for (int i = elements.Count - 1; i >= 0; i--)
			{
				AdventureElement element = elements[i];
				if (showAnim)
				{
					GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureElementDeleteAnim, element.CoreId, element.VisibleIndex, (AdventureBlockIndexForSerialize)element.Index);
				}
				adventureRuntime.RemoveElement(element.Id);
				count++;
				if (count >= deleteCount)
				{
					break;
				}
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(899)]
	private static ValueInfo AdventureRemoveElementAndHandleBoundCharacterByInstanceId(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementInstanceId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementInstanceId);
			if (element == null)
			{
				Logger.Warn($"AdventureRemoveElementAndHandleBoundCharacterByInstanceId, element not found, ElementId:{elementInstanceId}");
			}
			else
			{
				RemoveAdventureElementsAndHandleBoundCharacters(runtime, adventureRuntime, new AdventureElement[1] { element });
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(947)]
	private static ValueInfo AdventureRemoveElementsAndHandleBoundCharactersByCoreId(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			RemoveAdventureElementsAndHandleBoundCharacters(runtime, adventureRuntime, adventureRuntime.GetElementsByCoreId(elementCoreId).ToList());
		}
		return ValueInfo.Void;
	}

	[EventFunction(948)]
	private static ValueInfo AdventureRemoveElementsAndHandleBoundCharactersByTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string elementTag = parameters[0].GetStringValue(evaluator);
			RemoveAdventureElementsAndHandleBoundCharacters(runtime, adventureRuntime, adventureRuntime.GetElementsByTag(elementTag).ToList());
		}
		return ValueInfo.Void;
	}

	private static void RemoveAdventureElementsAndHandleBoundCharacters(EventScriptRuntime runtime, AdventureRuntime adventureRuntime, IEnumerable<AdventureElement> elements)
	{
		bool changed = false;
		foreach (AdventureElement element in elements)
		{
			changed |= RemoveAdventureElementAndHandleBoundCharacter(runtime, adventureRuntime, element);
		}
		if (changed)
		{
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
	}

	private static bool RemoveAdventureElementAndHandleBoundCharacter(EventScriptRuntime runtime, AdventureRuntime adventureRuntime, AdventureElement element)
	{
		if (adventureRuntime.StatusType == EAdventureStatusType.Releasing)
		{
			Logger.Warn($"RemoveAdventureElementAndHandleBoundCharacter is not allowed while adventure is releasing, AdventureId:{adventureRuntime.Id}");
			return false;
		}
		int characterId = element.CharacterId;
		if (characterId < 0)
		{
			return adventureRuntime.RemoveElement(element.Id);
		}
		if (!DomainManager.Character.TryGetElement_Objects(characterId, out var character))
		{
			adventureRuntime.DynamicUnbindCharacterAndRemoveElement(element);
			return adventureRuntime.GetElement(element.Id) == null;
		}
		bool isCalledCharacter = adventureRuntime.IsCalledCharacter(characterId);
		bool isTemporaryCharacter = adventureRuntime.IsTemporaryCharacter(characterId);
		if (!isCalledCharacter && !isTemporaryCharacter)
		{
			Logger.Warn($"Adventure element bound character is not registered as called or temporary, ElementId:{element.Id}, CharacterId:{characterId}");
			return adventureRuntime.RemoveElement(element.Id);
		}
		byte creatingType = character.GetCreatingType();
		if (isCalledCharacter && creatingType == 1)
		{
			DomainManager.Character.GroupMove(runtime.Context, character, adventureRuntime.MapLocation);
		}
		switch (adventureRuntime.DynamicUnbindCharacterAndRemoveElement(element))
		{
		case EAdventureUnbindType.None:
			Logger.Warn($"Adventure element character unbind failed, ElementId:{element.Id}, CharacterId:{characterId}");
			return false;
		case EAdventureUnbindType.Called:
			DomainManager.Character.ReleaseCharacterByAdventure(runtime.Context, character);
			return true;
		default:
			character.DeactivateExternalRelationState(runtime.Context, 4uL);
			if (creatingType != 1)
			{
				DomainManager.Character.RemoveNonIntelligentCharacter(runtime.Context, character);
				return true;
			}
			if (DomainManager.Character.IsTemporaryIntelligentCharacter(characterId))
			{
				DomainManager.Character.RemoveTemporaryIntelligentCharacter(runtime.Context, character);
			}
			else
			{
				Logger.Warn($"Adventure temporary character is not registered as temporary, CharacterId:{characterId}");
			}
			return true;
		}
	}

	[EventFunction(272)]
	private static ValueInfo AdventureDeleteElementByElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			int elementCoreIdDelete = parameters[1].GetIntValue(evaluator);
			int deleteCount = parameters[2].GetIntValue(evaluator);
			Tester.Assert(deleteCount >= 0);
			bool miniGrid = parameters[3].GetBoolValue(evaluator);
			bool showAnim = parameters[4].GetBoolValue(evaluator);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId);
			List<int> elementIdList = new List<int>();
			if (miniGrid)
			{
				foreach (AdventureElement element in elements)
				{
					IEnumerable<AdventureElement> indexElements = adventureRuntime.GetElements(element.Index);
					foreach (AdventureElement indexElement in indexElements)
					{
						if (indexElement.CoreId == elementCoreIdDelete)
						{
							elementIdList.Add(indexElement.Id);
						}
					}
				}
			}
			else
			{
				List<AdventureBlockIndex> indexList = new List<AdventureBlockIndex>();
				foreach (AdventureElement element2 in elements)
				{
					for (int i = 0; i < 9; i++)
					{
						AdventureBlockIndex index = new AdventureBlockIndex(element2.Index.X, element2.Index.Y, i);
						if (!indexList.Contains(index))
						{
							indexList.Add(index);
						}
					}
				}
				foreach (AdventureBlockIndex index2 in indexList)
				{
					IEnumerable<AdventureElement> indexElements2 = adventureRuntime.GetElements(index2);
					foreach (AdventureElement indexElement2 in indexElements2)
					{
						if (indexElement2.CoreId == elementCoreIdDelete)
						{
							elementIdList.Add(indexElement2.Id);
						}
					}
				}
			}
			int count = 0;
			for (int i2 = elementIdList.Count - 1; i2 >= 0; i2--)
			{
				int elementId = elementIdList[i2];
				AdventureElement element3 = adventureRuntime.GetElement(elementId);
				if (showAnim)
				{
					GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureElementDeleteAnim, element3.CoreId, element3.VisibleIndex, (AdventureBlockIndexForSerialize)element3.Index);
				}
				adventureRuntime.RemoveElement(elementId);
				count++;
				if (count >= deleteCount)
				{
					break;
				}
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(273)]
	private static ValueInfo AdventureDeleteElementByElementGroup(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			int elementCoreIdDelete = parameters[1].GetIntValue(evaluator);
			int deleteCount = parameters[2].GetIntValue(evaluator);
			bool showAnim = parameters[3].GetBoolValue(evaluator);
			Tester.Assert(deleteCount >= 0);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId);
			IEnumerable<int> groupIdList = elements.SelectMany((AdventureElement adventureElement) => adventureRuntime.GetBlockGroupIds(adventureElement.Index)).Distinct();
			IEnumerable<AdventureBlockData> blocks = adventureRuntime.CoreBlocks.Where((AdventureBlockData block) => block.GroupIds.Any((int groupId) => groupIdList.Contains(groupId)));
			List<int> elementIdList = (from adventureElement in blocks.SelectMany((AdventureBlockData block) => adventureRuntime.GetElements(block.Index))
				where adventureElement.CoreId == elementCoreIdDelete
				select adventureElement.Id).ToList();
			int count = 0;
			for (int i = elementIdList.Count - 1; i >= 0; i--)
			{
				int elementId = elementIdList[i];
				AdventureElement element = adventureRuntime.GetElement(elementId);
				if (showAnim)
				{
					GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureElementDeleteAnim, element.CoreId, element.VisibleIndex, (AdventureBlockIndexForSerialize)element.Index);
				}
				adventureRuntime.RemoveElement(elementId);
				count++;
				if (count >= deleteCount)
				{
					break;
				}
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(277)]
	private static ValueInfo AdventureElementSimulateCombat(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement elementBy = adventureRuntime.GetElement(elementId);
			int elementCoreId = parameters[1].GetIntValue(evaluator);
			List<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId).ToList();
			if (!elements.Any() || elementBy.CharacterId < 0)
			{
				return ValueInfo.Void;
			}
			if (!DomainManager.Character.TryGetElement_Objects(elementBy.CharacterId, out var characterBy))
			{
				return ValueInfo.Void;
			}
			if (!DomainManager.Character.TryGetElement_Objects(elements.First().CharacterId, out var defendCharacter))
			{
				return ValueInfo.Void;
			}
			AiHelper.NpcCombatResultType combatResult = DomainManager.Character.SimulateCharacterCombat(runtime.Context, characterBy, defendCharacter, CombatType.Beat, isGroupCombat: false);
			runtime.ArgBox.Set("NpcCombatResultType", (sbyte)combatResult);
		}
		return ValueInfo.Void;
	}

	[EventFunction(338)]
	private static ValueInfo AdventureElementSimulateCombatWithTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement elementBy = adventureRuntime.GetElement(elementId);
			string inputTags = parameters[1].GetStringValue(evaluator);
			bool containsInvisible = parameters[2].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[3].GetIntValue(evaluator);
			List<string> tags = ParseInputTags(inputTags);
			IReadOnlyList<AdventureElement> allElements = adventureRuntime.GetAllElements();
			List<AdventureElement> matchedElements = (from element in allElements
				where containsInvisible || element.Visible
				where CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select element).ToList();
			if (!matchedElements.Any() || elementBy.CharacterId < 0)
			{
				return ValueInfo.Void;
			}
			if (!DomainManager.Character.TryGetElement_Objects(elementBy.CharacterId, out var characterBy))
			{
				return ValueInfo.Void;
			}
			if (!DomainManager.Character.TryGetElement_Objects(matchedElements.First().CharacterId, out var defendCharacter))
			{
				return ValueInfo.Void;
			}
			AiHelper.NpcCombatResultType combatResult = DomainManager.Character.SimulateCharacterCombat(runtime.Context, characterBy, defendCharacter, CombatType.Beat, isGroupCombat: false);
			runtime.ArgBox.Set("NpcCombatResultType", (sbyte)combatResult);
		}
		return ValueInfo.Void;
	}

	[EventFunction(279)]
	private static ValueInfo AdventureSaveElementCharacterId(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			string saveKey = parameters[1].GetStringValue(evaluator);
			runtime.ArgBox.Set(saveKey, element.CharacterId);
		}
		return ValueInfo.Void;
	}

	[EventFunction(280)]
	private static ValueInfo AdventureCreateElementRandom(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			int count = parameters[1].GetIntValue(evaluator);
			for (int i = 0; i < count; i++)
			{
				AdventureBlockData block = adventureRuntime.CoreBlocks.GetRandomReadOnly(runtime.Context.Random);
				DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, block.Index);
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(281)]
	private static void AdventureTaiwuRandomMove(EventScriptRuntime runtime)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			List<EAdventureDirection> directions = (from direction in AdventureBlockIndex.Directions
				where adventureRuntime.IsPassable(adventureTaiwu.Index.Move(direction))
				select (direction)).ToList();
			DataContext context = runtime.Context;
			if (directions.Count > 0)
			{
				adventureTaiwu.SetCurrentIndex(adventureTaiwu.Index.Move(directions.GetRandom(context.Random)));
				DomainManager.Adventure.SetAdventureTaiwu(adventureTaiwu, context);
			}
			else
			{
				Logger.Warn("AdventureTaiwuRandomMove,can not move");
			}
		}
	}

	[EventFunction(623)]
	private static void AdventureTeleportMoveTaiwuToBlock(EventScriptRuntime runtime, AdventureBlockIndexForSerialize adventureBlockIndex)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			adventureTaiwu.SetCurrentIndex(adventureBlockIndex);
			DomainManager.Adventure.SetAdventureTaiwu(adventureTaiwu, runtime.Context);
		}
	}

	[EventFunction(418)]
	private static ValueInfo WorldMapTaiwuRandomMove(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CharacterEscapeToNearbyBlock(runtime.ArgBox, runtime.ArgBox.GetCharacter("RoleTaiwu"), 1);
		return ValueInfo.Void;
	}

	[EventFunction(391)]
	private static ValueInfo AdventureElementRandomMove(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			List<AdventureBlockIndex> list = AdventureBlockIndex.Directions.Select((EAdventureDirection direction) => element.Index.Move(direction)).Where(adventureRuntime.IsPassable).ToList();
			if (list.Count > 0)
			{
				AdventureBlockIndex nextBlockIndex = list.GetRandom(runtime.Context.Random);
				DomainManager.Adventure.MoveElementTo(runtime.Context, adventureId, elementId, nextBlockIndex);
			}
			else
			{
				Logger.Warn("AdventureElementRandomMove,can not move");
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(282)]
	private static ValueInfo AdventureDeleteCurrElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			bool showAnim = parameters[1].GetBoolValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			if (showAnim)
			{
				GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureElementDeleteAnim, element.CoreId, element.VisibleIndex, (AdventureBlockIndexForSerialize)element.Index);
				GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.PlayAudioCommand, "ui_adventure_down", arg2: false, arg3: false);
			}
			adventureRuntime.RemoveElement(elementId);
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(484)]
	private static ValueInfo AdventurePlayDeleteElementAnim(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int elementId = parameters[0].GetIntValue(evaluator);
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement element = adventureRuntime.GetElement(elementId);
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureElementDeleteAnim, element.CoreId, element.VisibleIndex, (AdventureBlockIndexForSerialize)element.Index);
		}
		return ValueInfo.Void;
	}

	[EventFunction(285)]
	private static ValueInfo AdventureSaveElementTimeCosted(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int timeCosted = -1;
			runtime.ArgBox.Get("ConchShipPresetKey_CostedTime", ref timeCosted);
			int elementId = parameters[0].GetIntValue(evaluator);
			string paramName = parameters[1].GetStringValue(evaluator);
			int factor = parameters[2].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			element.ChangeParameter(paramName, factor * timeCosted);
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(287)]
	private static ValueInfo AdventureGetParameterValue(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string paramName = parameters[0].GetStringValue(evaluator);
			AdventureParameterValue paramValue = adventureRuntime.GetParameter(paramName);
			string saveKey = parameters[1].GetStringValue(evaluator);
			runtime.ArgBox.Set(saveKey, paramValue.Current);
		}
		return ValueInfo.Void;
	}

	[EventFunction(288)]
	private static ValueInfo AdventureGetElementParameterValue(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			string paramName = parameters[1].GetStringValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			AdventureParameterValue elementParamValue = element.GetParameter(paramName);
			string saveKey = parameters[2].GetStringValue(evaluator);
			runtime.ArgBox.Set(saveKey, elementParamValue.Current);
		}
		return ValueInfo.Void;
	}

	[EventFunction(289)]
	private static void AdventureGetItemCount(EventScriptRuntime runtime, UnmanagedVariant<TemplateKey> itemTemplate, string saveKey)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int sumCount = adventureRuntime.GetTemporaryItemsTaiwu(itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId).Sum((GameData.Domains.Adventure.AdventureItem item) => item.ItemCount);
			runtime.ArgBox.Set(saveKey, sumCount);
		}
	}

	[EventFunction(297)]
	private static ValueInfo AdventureChangeElementCount(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			int elementCoreId = parameters[1].GetIntValue(evaluator);
			int changeCount = parameters[2].GetIntValue(evaluator);
			if (changeCount == 0)
			{
				return ValueInfo.Void;
			}
			AdventureElement elementBy = adventureRuntime.GetElement(elementId);
			if (changeCount > 0)
			{
				for (int i = 0; i < changeCount; i++)
				{
					AdventureElement element = DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, elementBy.Index);
					if (element == null)
					{
						Logger.Warn("AdventureChangeElementCount,create element false");
					}
				}
			}
			else
			{
				List<AdventureElement> elements = adventureRuntime.GetElements(elementBy.Index).ToList();
				changeCount = -changeCount;
				int count = 0;
				for (int i2 = elements.Count - 1; i2 >= 0; i2--)
				{
					AdventureElement element2 = elements[i2];
					if (element2.CoreId == elementCoreId)
					{
						adventureRuntime.RemoveElement(element2.Id);
						count++;
					}
					if (count >= changeCount)
					{
						break;
					}
				}
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(301)]
	private static void AdventureSaveElementById(EventScriptRuntime runtime, int elementCoreId, string saveKey, bool containsInvisible)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement matchedElement = adventureRuntime.GetElementsByCoreId(elementCoreId).FirstOrDefault((AdventureElement element) => containsInvisible || element.Visible);
			if (matchedElement != null)
			{
				runtime.ArgBox.Set(saveKey, matchedElement.Id);
			}
			else
			{
				Logger.Warn("AdventureSaveElementById,Not find match element");
			}
		}
	}

	[EventFunction(302)]
	private static void AdventureSaveElementByTag(EventScriptRuntime runtime, int elementId, string inputTags, string saveKey, bool containsInvisible, int tagArrayMatchType)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement elementCurrent = adventureRuntime.GetElement(elementId);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElements(elementCurrent.Index);
			List<string> tags = ParseInputTags(inputTags);
			AdventureElement matchedElement = (from element in elements
				where containsInvisible || element.Visible
				where element.Id != elementId
				select element).FirstOrDefault((AdventureElement element) => CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
			if (matchedElement != null)
			{
				runtime.ArgBox.Set(saveKey, matchedElement.Id);
			}
			else
			{
				Logger.Warn("AdventureSaveElementByTag,Not find Match element");
			}
		}
	}

	[EventFunction(303)]
	private static void AdventureSaveElementByTagGlobal(EventScriptRuntime runtime, string inputTags, string saveKey, bool containsInvisible, int tagArrayMatchType)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			List<string> tags = ParseInputTags(inputTags);
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			AdventureElement matchedElement = elements.Where((AdventureElement element) => containsInvisible || element.Visible).FirstOrDefault((AdventureElement element) => CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
			if (matchedElement != null)
			{
				runtime.ArgBox.Set(saveKey, matchedElement.Id);
			}
			else
			{
				Logger.Warn("AdventureSaveElementByTagGlobal,Not find match element");
			}
		}
	}

	[EventFunction(305)]
	private static void AdventureSetTaiwuViewType(EventScriptRuntime runtime, int viewType, int setValue)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string paramKey = "view_range_" + viewType;
			AdventureParameterValue parameterValue = adventureRuntime.GetParameter("view_range_" + viewType);
			if (SetParameter(ref parameterValue, setValue, paramKey))
			{
				adventureRuntime.SetParameter(paramKey, parameterValue);
				DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
			}
		}
	}

	[EventFunction(310)]
	private static ValueInfo AdventureCreateElementInheritCharacter(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			int elementCoreId = parameters[1].GetIntValue(evaluator);
			int characterTemplateId = parameters[2].GetIntValue(evaluator);
			CharacterItem config = Config.Character.Instance[characterTemplateId];
			Tester.Assert(config.CreatingType == 2);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			if (DomainManager.Character.TryGetElement_Objects(element.CharacterId, out var character))
			{
				AdventureElement newElement = DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, element.Index);
				if (newElement != null)
				{
					RandomEnemyCreationInfo randomEnemyCreationInfo = new RandomEnemyCreationInfo();
					randomEnemyCreationInfo.Gender = character.GetGender();
					randomEnemyCreationInfo.Transgender = character.GetTransgender();
					RandomEnemyCreationInfo creationInfo = randomEnemyCreationInfo;
					GameData.Domains.Character.Character copyCharacter = DomainManager.Character.CreateRandomEnemy(runtime.Context, (short)characterTemplateId, isTemporary: false, ref creationInfo);
					int enemyId = copyCharacter.GetId();
					DomainManager.Character.CompleteCreatingCharacter(enemyId);
					adventureRuntime.DynamicBindTemporaryCharacter(newElement, enemyId);
					copyCharacter.SetFullName(character.GetFullName(), runtime.Context);
					copyCharacter.SetAvatar(character.GetAvatar(), runtime.Context);
					copyCharacter.SetActualAge(character.GetActualAge(), runtime.Context);
					copyCharacter.SetCurrAge(character.GetCurrAge(), runtime.Context);
					List<short> featureIds = copyCharacter.GetFeatureIds();
					for (int i = featureIds.Count - 1; i >= 0; i--)
					{
						copyCharacter.RemoveFeature(runtime.Context, featureIds[i]);
					}
					List<short> originalFeatures = character.GetFeatureIds();
					foreach (short featureId in originalFeatures)
					{
						copyCharacter.AddFeature(runtime.Context, featureId);
					}
				}
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(311)]
	private static void AdventureParameterStartProgress(EventScriptRuntime runtime, string actionKey)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			DomainManager.Adventure.StartAction(runtime.Context, actionKey);
		}
	}

	[EventFunction(312)]
	private static void AdventureElementParameterStartProgress(EventScriptRuntime runtime, int elementId, string actionKey)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			DomainManager.Adventure.StartAction(runtime.Context, adventureId, elementId, actionKey);
		}
	}

	[EventFunction(334)]
	private static ValueInfo AdventureElementParameterStartProgressWithTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string inputTags = parameters[0].GetStringValue(evaluator);
			string actionKey = parameters[1].GetStringValue(evaluator);
			bool containsInvisible = parameters[2].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[3].GetIntValue(evaluator);
			List<string> tags = ParseInputTags(inputTags);
			IReadOnlyList<AdventureElement> allElements = adventureRuntime.GetAllElements();
			IEnumerable<AdventureElement> matchedElements = from adventureElement in allElements
				where containsInvisible || adventureElement.Visible
				where CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(adventureElement.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select adventureElement;
			foreach (AdventureElement element in matchedElements)
			{
				DomainManager.Adventure.StartAction(runtime.Context, adventureId, element.Id, actionKey);
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(356)]
	private static void AdventureParameterStopProgress(EventScriptRuntime runtime)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime) && adventureRuntime.InterruptTaiwuAction())
		{
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
	}

	[EventFunction(357)]
	private static void AdventureElementParameterStopProgress(EventScriptRuntime runtime, int elementId)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement element = adventureRuntime.GetElement(elementId);
			if (adventureRuntime.IsElementAlive(element) && adventureRuntime.InterruptElementAction(element))
			{
				DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
			}
		}
	}

	[EventFunction(313)]
	private static void AdventureElementMoveToTaiwuNearby(EventScriptRuntime runtime, int elementId, int range)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
		IEnumerable<AdventureBlockIndex> blockIndices = adventureRuntime.GetIndexes();
		List<AdventureBlockIndex> blockList = new List<AdventureBlockIndex>();
		foreach (AdventureBlockIndex blockIndex in blockIndices)
		{
			if (adventureTaiwu.Index.GetManhattanDistance(blockIndex) <= range)
			{
				AdventureBlock adventureRemakeBlock = adventureRuntime.GetBlock(blockIndex);
				if (adventureRemakeBlock.ContainStatus(EAdventureBlockStatusType.Passable))
				{
					blockList.Add(blockIndex);
				}
			}
		}
		if (blockList.Count > 0)
		{
			AdventureBlockIndex moveToIndex = blockList.GetRandom(runtime.Context.Random);
			DomainManager.Adventure.MoveElementTo(runtime.Context, adventureId, elementId, moveToIndex);
		}
		else
		{
			Logger.Warn("AdventureElementMoveToTaiwuNearby,blockList.Count = 0");
		}
	}

	[EventFunction(314)]
	private static int AdventureGetElementCountInRange(EventScriptRuntime runtime, int elementId, int range, string inputTags, bool containsInvisible, int tagArrayMatchType)
	{
		int adventureId = -1;
		int count = 0;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			List<string> tags = ParseInputTags(inputTags);
			AdventureElement centerElement = adventureRuntime.GetElement(elementId);
			count = (from blockIndex in adventureRuntime.GetIndexes()
				where centerElement.Index.GetManhattanDistance(blockIndex) <= range
				select blockIndex).SelectMany((AdventureBlockIndex blockIndex) => adventureRuntime.GetElements(blockIndex)).Count((AdventureElement element) => (containsInvisible || element.Visible) && CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
		}
		return count;
	}

	[EventFunction(372)]
	private static int GetAdventureElementTagCount(EventScriptRuntime runtime, string inputTags, bool containsInvisible, int tagArrayMatchType)
	{
		int adventureId = -1;
		int count = 0;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			List<string> tags = ParseInputTags(inputTags);
			count = elements.Where((AdventureElement element) => containsInvisible || element.Visible).Count((AdventureElement element) => CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
		}
		return count;
	}

	[EventFunction(351)]
	private static int AdventureGetElementDistanceToTaiwu(EventScriptRuntime runtime, int elementId)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement elementCenter = adventureRuntime.GetElement(elementId);
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			return elementCenter.Index.GetManhattanDistance(adventureTaiwu.Index);
		}
		return int.MaxValue;
	}

	[EventFunction(366)]
	private static void AdventureSaveElementAtTaiwuBlock(EventScriptRuntime runtime, string elementTag, string saveKey, bool containsInvisible, int tagArrayMatchType)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			List<string> tags = ParseInputTags(elementTag);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElements(adventureTaiwu.Index);
			AdventureElement matchedElement = elements.Where((AdventureElement element) => containsInvisible || element.Visible).FirstOrDefault((AdventureElement element) => CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
			if (matchedElement != null)
			{
				runtime.ArgBox.Set(saveKey, matchedElement.Id);
			}
			else
			{
				Logger.Warn("AdventureSaveElementById,Not Find element");
			}
		}
	}

	[EventFunction(365)]
	private static void AdventureSaveElementAtTaiwuBigBlock(EventScriptRuntime runtime, string elementTag, string saveKey, bool containsInvisible, int tagArrayMatchType)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			List<string> tags = ParseInputTags(elementTag);
			AdventureElement matchedElement = (from element in adventureRuntime.CoreBlocks.Where((AdventureBlockData block) => block.Index.X == adventureTaiwu.Index.X && block.Index.Y == adventureTaiwu.Index.Y).SelectMany((AdventureBlockData block) => adventureRuntime.GetElements(block.Index))
				where containsInvisible || element.Visible
				select element).FirstOrDefault((AdventureElement element) => CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
			if (matchedElement != null)
			{
				runtime.ArgBox.Set(saveKey, matchedElement.Id);
			}
			else
			{
				Logger.Warn("AdventureSaveElementAtTaiwuBigBlock,Not find match element");
			}
		}
	}

	[EventFunction(367)]
	private static void AdventureSaveElementAtElementBigBlock(EventScriptRuntime runtime, int elementId, string inputTags, string saveKey, bool containsInvisible, int tagArrayMatchType)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement currentElement = adventureRuntime.GetElement(elementId);
			List<string> tags = ParseInputTags(inputTags);
			AdventureElement matchedElement = (from element in adventureRuntime.CoreBlocks.Where((AdventureBlockData block) => block.Index.X == currentElement.Index.X && block.Index.Y == currentElement.Index.Y).SelectMany((AdventureBlockData block) => adventureRuntime.GetElements(block.Index))
				where containsInvisible || element.Visible
				select element).FirstOrDefault((AdventureElement element) => CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
			if (matchedElement != null)
			{
				runtime.ArgBox.Set(saveKey, matchedElement.Id);
			}
			else
			{
				Logger.Warn("AdventureSaveElementAtElementBigBlock,Not find match element");
			}
		}
	}

	[EventFunction(370)]
	private static IntList AdventureGetCurrentCharIds(EventScriptRuntime runtime, string inputTags, int tagArrayMatchType, bool containsInvisible)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElements(adventureTaiwu.Index);
			List<string> tags = ParseInputTags(inputTags);
			foreach (AdventureElement element in elements)
			{
				if ((element.Visible || containsInvisible) && CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType))
				{
					result.Items.Add(element.CharacterId);
				}
			}
		}
		return result;
	}

	[EventFunction(371)]
	private static IntList AdventureGetCharIds(EventScriptRuntime runtime, string inputTags, int tagArrayMatchType, bool containsInvisible, int minCount, int maxCount)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			List<string> tags = ParseInputTags(inputTags);
			int getCount = runtime.Context.Random.Next(minCount, maxCount);
			int count = 0;
			foreach (AdventureElement element in elements)
			{
				if ((element.Visible || containsInvisible) && CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType))
				{
					result.Items.Add(element.CharacterId);
					count++;
					if (count >= getCount)
					{
						break;
					}
				}
			}
		}
		return result;
	}

	[EventFunction(393)]
	private static ValueInfo AdventureElementSimulateCombatById(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId1 = parameters[0].GetIntValue(evaluator);
			AdventureElement element1 = adventureRuntime.GetElement(elementId1);
			int elementId2 = parameters[1].GetIntValue(evaluator);
			AdventureElement element2 = adventureRuntime.GetElement(elementId2);
			if (element1.CharacterId < 0 || element2.CharacterId < 0 || element1.CharacterId == element2.CharacterId)
			{
				Logger.Warn($"AdventureElementSimulateCombatById, element1.CharacterId:{element1.CharacterId}, element2.CharacterId:{element2.CharacterId}");
				return ValueInfo.Void;
			}
			if (!DomainManager.Character.TryGetElement_Objects(element1.CharacterId, out var character1))
			{
				Logger.Warn($"AdventureElementSimulateCombatById, element1.CharacterId:{element1.CharacterId} can not find");
				return ValueInfo.Void;
			}
			if (!DomainManager.Character.TryGetElement_Objects(element2.CharacterId, out var character2))
			{
				Logger.Warn($"AdventureElementSimulateCombatById, element2.CharacterId:{element2.CharacterId} can not find");
				return ValueInfo.Void;
			}
			AiHelper.NpcCombatResultType combatResult = DomainManager.Character.SimulateCharacterCombat(runtime.Context, character1, character2, CombatType.Beat, isGroupCombat: false);
			runtime.ArgBox.Set("NpcCombatResultType", (sbyte)combatResult);
		}
		return ValueInfo.Void;
	}

	[EventFunction(380)]
	private static int AdventureCreateRandomEnemyBindElement(EventScriptRuntime runtime, int elementId, short characterTemplateId, short randomEnemyTemplateId)
	{
		int enemyId = -1;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement element = adventureRuntime.GetElement(elementId);
			RandomEnemyCreationInfo randomEnemyCreationInfo = new RandomEnemyCreationInfo();
			randomEnemyCreationInfo.RandomEnemyTemplateId = randomEnemyTemplateId;
			RandomEnemyCreationInfo creationInfo = randomEnemyCreationInfo;
			GameData.Domains.Character.Character randomEnemy = DomainManager.Character.CreateRandomEnemy(runtime.Context, characterTemplateId, isTemporary: false, ref creationInfo);
			enemyId = randomEnemy.GetId();
			DomainManager.Character.CompleteCreatingCharacter(enemyId);
			adventureRuntime.DynamicBindTemporaryCharacter(element, enemyId);
		}
		return enemyId;
	}

	[EventFunction(379)]
	private static bool AdventureConvertElementCharJoinGroup(EventScriptRuntime runtime, GameData.Domains.Character.Character character, bool joinGroup, string afterEvent)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			DataContext context = runtime.Context;
			if (joinGroup && GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsTaiwuGroupFull())
			{
				return false;
			}
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			IReadOnlyList<AdventureElement> allElements = adventureRuntime.GetAllElements();
			AdventureElement element = allElements.FirstOrDefault((AdventureElement e) => e.CharacterId == character.GetId());
			if (element == null)
			{
				Logger.Warn($"Related Element not find,CharacterId:{character.GetId()}");
				return false;
			}
			adventureRuntime.DynamicUnbindAndUnhideFromMap(context, element);
			if (character.GetCreatingType() == 2)
			{
				DomainManager.Character.ConvertRandomEnemy(context, character, taiwu.GetLocation());
			}
			else if (character.GetCreatingType() == 0 || character.GetCreatingType() == 3)
			{
				DomainManager.Character.ConvertFixedCharacter(context, character, taiwu.GetLocation(), recreateAttributesAndQualifications: false);
			}
			if (DomainManager.Character.IsTemporaryIntelligentCharacter(character.GetId()))
			{
				DomainManager.Character.ConvertTemporaryIntelligentCharacter(context, character);
			}
			if (joinGroup)
			{
				DomainManager.Taiwu.JoinGroup(context, character.GetId());
			}
			else
			{
				OrganizationInfo taiwuOrgInfo = taiwu.GetOrganizationInfo();
				taiwuOrgInfo.Grade = 0;
				DomainManager.Organization.ChangeOrganization(context, character, taiwuOrgInfo);
			}
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ShowGetItemPageForCharacters(new List<int> { character.GetId() }, !joinGroup, afterEvent, runtime.ArgBox);
		}
		return false;
	}

	[EventFunction(402)]
	private static void AdventureChangeElementValueWithSpecificTag(EventScriptRuntime runtime, string elementTag, string paramName, int tagArrayMatchType, int value)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		List<string> tags = ParseInputTags(elementTag);
		foreach (AdventureElement element in adventureRuntime.GetAllElements())
		{
			List<string> elementTags = AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList();
			if (CheckAdventureElementTagsMatch(elementTags, tags, tagArrayMatchType))
			{
				AdventureParameterValue parameterValue = element.GetParameter(paramName);
				if (SetParameter(ref parameterValue, value, paramName))
				{
					element.SetParameter(paramName, parameterValue);
				}
			}
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
	}

	[EventFunction(403)]
	private static void AdventureMoveElementToElementNearById(EventScriptRuntime runtime, int elementId, int elementCoreId, int range)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		AdventureBlockIndex index = new AdventureBlockIndex(int.MinValue, int.MinValue, int.MinValue);
		foreach (AdventureElement element in adventureRuntime.GetAllElements())
		{
			if (element.CoreId == elementCoreId)
			{
				index = element.Index;
				break;
			}
		}
		if (index.X == int.MinValue || index.Y == int.MinValue)
		{
			Logger.Warn("AdventureMoveElementToElementNearById failed, core not found");
			return;
		}
		IEnumerable<AdventureBlockIndex> blockIndices = adventureRuntime.GetIndexes();
		List<AdventureBlockIndex> blockList = new List<AdventureBlockIndex>();
		foreach (AdventureBlockIndex blockIndex in blockIndices)
		{
			if (index.GetManhattanDistance(blockIndex) <= range)
			{
				AdventureBlock adventureRemakeBlock = adventureRuntime.GetBlock(blockIndex);
				if (adventureRemakeBlock.ContainStatus(EAdventureBlockStatusType.Passable))
				{
					blockList.Add(blockIndex);
				}
			}
		}
		if (blockList.Count > 0)
		{
			AdventureBlockIndex moveToIndex = blockList.GetRandom(runtime.Context.Random);
			DomainManager.Adventure.MoveElementTo(runtime.Context, adventureId, elementId, moveToIndex);
		}
		else
		{
			Logger.Warn("AdventureMoveElementToElementNearById failed, placable block not found");
		}
	}

	[EventFunction(404)]
	private static void AdventureMoveElementToElementNearByKey(EventScriptRuntime runtime, int srcElementId, int dstElementId, int range)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		AdventureBlockIndex index = adventureRuntime.GetElement(dstElementId).Index;
		IEnumerable<AdventureBlockIndex> blockIndices = adventureRuntime.GetIndexes();
		List<AdventureBlockIndex> blockList = new List<AdventureBlockIndex>();
		foreach (AdventureBlockIndex blockIndex in blockIndices)
		{
			if (index.GetManhattanDistance(blockIndex) <= range)
			{
				AdventureBlock adventureRemakeBlock = adventureRuntime.GetBlock(blockIndex);
				if (adventureRemakeBlock.ContainStatus(EAdventureBlockStatusType.Passable))
				{
					blockList.Add(blockIndex);
				}
			}
		}
		if (blockList.Count > 0)
		{
			AdventureBlockIndex moveToIndex = blockList.GetRandom(runtime.Context.Random);
			DomainManager.Adventure.MoveElementTo(runtime.Context, adventureId, srcElementId, moveToIndex);
		}
		else
		{
			Logger.Warn("AdventureMoveElementToElementNearByKey failed, placable block not found");
		}
	}

	[EventFunction(405)]
	private static void AdventureMoveElementToGroup(EventScriptRuntime runtime, int elementId, int groupId, bool separate)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		List<AdventureBlockIndex> blockList = new List<AdventureBlockIndex>();
		foreach (AdventureBlockData blockData in adventureRuntime.CoreBlocks)
		{
			if (blockData.GroupIds.Contains(groupId) && blockData.PassableCondition.Check(adventureId) && (!separate || blockData.ElementCoreIds.Count == 0))
			{
				blockList.Add(blockData.Index);
			}
		}
		if (blockList.Count == 0)
		{
			if (!separate)
			{
				return;
			}
			foreach (AdventureBlockData blockData2 in adventureRuntime.CoreBlocks)
			{
				if (blockData2.GroupIds.Contains(groupId) && blockData2.PassableCondition.Check(adventureId))
				{
					blockList.Add(blockData2.Index);
				}
			}
			if (blockList.Count == 0)
			{
				return;
			}
		}
		AdventureBlockIndex moveToIndex = blockList.GetRandom(runtime.Context.Random);
		DomainManager.Adventure.MoveElementTo(runtime.Context, adventureId, elementId, moveToIndex);
	}

	[EventFunction(410)]
	private static void AdventureElementAlertAnim(EventScriptRuntime runtime, int elementId)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement element = adventureRuntime.GetElement(elementId);
			if (element.Visible)
			{
				GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureElementAlertAnim, elementId);
			}
		}
	}

	[EventFunction(411)]
	private static void AdventureBlockChangeIcon(EventScriptRuntime runtime, string blockIndexStr, string iconName)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			if (ParseAdventureBlockIndex(blockIndexStr, out var blockIndex))
			{
				AdventureBlock block = adventureRuntime.GetBlock(blockIndex);
				block.SpecialIcon = iconName;
				DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
				List<AdventureBlockIndexForSerialize> blockIndexList = new List<AdventureBlockIndexForSerialize> { blockIndex };
				GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureBlockChangeIcon, blockIndexList);
			}
			else
			{
				Logger.AppendWarning("AdventureBlockIndex parse error,please check input");
			}
		}
	}

	[EventFunction(719)]
	private static void AdventureGroupChangeIcon(EventScriptRuntime runtime, int groupId, string iconName)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		IEnumerable<AdventureBlock> blocks = adventureRuntime.GetBlocksByGroupId(groupId);
		List<AdventureBlockIndexForSerialize> blockIndexList = new List<AdventureBlockIndexForSerialize>();
		foreach (AdventureBlock block in blocks)
		{
			block.SpecialIcon = iconName;
			blockIndexList.Add(block.Index);
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureBlockChangeIcon, blockIndexList);
	}

	[EventFunction(412)]
	private static void AdventureElementShowHideEffect(EventScriptRuntime runtime, int elementId, bool isBlockElement)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureElementShowHideEffect, elementId, isBlockElement);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.PlayAudioCommand, "ui_adventure_juese", arg2: false, arg3: false);
	}

	[EventFunction(427)]
	private static int AdventureQueryTaiwuActionId(EventScriptRuntime runtime)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return adventureRuntime.QueryTaiwuActionId();
		}
		return -1;
	}

	[EventFunction(428)]
	private static int AdventureQueryElementActionId(EventScriptRuntime runtime, int elementId)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement element = adventureRuntime.GetElement(elementId);
			if (element == null)
			{
				throw new Exception($"adventureId:{adventureId},adventureCoreId:{adventureRuntime.CoreId},elementId:{elementId}");
			}
			return adventureRuntime.QueryElementActionId(element);
		}
		return -1;
	}

	[EventFunction(429)]
	private static int AdventureChangeAction(EventScriptRuntime runtime, int actionId, int changeValue)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			DomainManager.Adventure.ChangeAction(runtime.Context, adventureRuntime, actionId, changeValue);
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return -1;
	}

	[EventFunction(430)]
	private static void AdventureElementStartActionWithTaiwu(EventScriptRuntime runtime, int elementId, string actionKey)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement element = adventureRuntime.GetElement(elementId);
			if (element == null)
			{
				throw new Exception($"adventureId:{adventureId},adventureCoreId:{adventureRuntime.CoreId},elementId:{elementId},actionKey:{actionKey}");
			}
			adventureRuntime.StartActionWithTaiwu(actionKey, element);
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
	}

	[EventFunction(434)]
	private static void AdventureElementsStartActionWithTaiwu(EventScriptRuntime runtime, IntList list, string actionKey)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		List<AdventureElement> elements = new List<AdventureElement>();
		foreach (int elementId in list.Items)
		{
			AdventureElement element = adventureRuntime.GetElement(elementId);
			if (element == null)
			{
				throw new Exception($"adventureId:{adventureId},adventureCoreId:{adventureRuntime.CoreId},elementId:{elementId},actionKey:{actionKey}");
			}
			elements.Add(element);
		}
		adventureRuntime.StartActionWithTaiwu(actionKey, elements);
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
	}

	[EventFunction(431)]
	private static void AdventureElementStartActionWithElement(EventScriptRuntime runtime, int elementId1, int elementId2, string actionKey)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement element1 = adventureRuntime.GetElement(elementId1);
			AdventureElement element2 = adventureRuntime.GetElement(elementId2);
			if (element1 == null)
			{
				throw new Exception($"adventureId:{adventureId},adventureCoreId:{adventureRuntime.CoreId},elementId:{elementId1},actionKey:{actionKey}");
			}
			if (element2 == null)
			{
				throw new Exception($"adventureId:{adventureId},adventureCoreId:{adventureRuntime.CoreId},elementId:{elementId2},actionKey:{actionKey}");
			}
			List<AdventureElement> elements = new List<AdventureElement> { element1, element2 };
			adventureRuntime.StartAction(actionKey, elements);
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
	}

	[EventFunction(435)]
	private static void AdventureElementsStartAction(EventScriptRuntime runtime, IntList list, string actionKey)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		List<AdventureElement> elements = new List<AdventureElement>();
		foreach (int elementId in list.Items)
		{
			AdventureElement element = adventureRuntime.GetElement(elementId);
			if (element == null)
			{
				throw new Exception($"adventureId:{adventureId},adventureCoreId:{adventureRuntime.CoreId},elementId:{elementId},actionKey:{actionKey}");
			}
			elements.Add(element);
		}
		adventureRuntime.StartAction(actionKey, elements);
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
	}

	[EventFunction(433)]
	private static int AdventureGetFinishedActionElement(EventScriptRuntime runtime, int index)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && runtime.ArgBox.Get("ConchShipPresetKey_FinishedAction", out AdventureAction finishedAction) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			if (index >= finishedAction.Elements.Count)
			{
				return 0;
			}
			return finishedAction.Elements[index];
		}
		return 0;
	}

	[EventFunction(436)]
	private static void AdventureRemoveViewCloud(EventScriptRuntime runtime, bool farView)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
		string viewStr = (farView ? "view_range_1" : "view_range_0");
		int range = adventureRuntime.GetParameter(viewStr).Current;
		AdventureParameterData parameterData = adventureRuntime.GetParameterData(viewStr);
		int style = parameterData.Style;
		foreach (AdventureBlockData block in adventureRuntime.CoreBlocks)
		{
			int distance = ((style == 0) ? block.Index.GetManhattanDistance(adventureTaiwu.Index) : block.Index.GetRegionBoxDistance(adventureTaiwu.Index));
			if (distance <= range)
			{
				AdventureBlock adventureBlock = adventureRuntime.GetBlock(block.Index);
				adventureBlock.InCloud = false;
			}
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
	}

	[EventFunction(438)]
	private static IntList AdventureGetElementListByTag(EventScriptRuntime runtime, string inputTags, int tagArrayMatchType, bool containsInvisible)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			List<string> tags = ParseInputTags(inputTags);
			IEnumerable<int> elementIdList = from e in elements
				where containsInvisible || e.Visible
				where CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(e.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select e.Id;
			result.Items.AddRange(elementIdList);
		}
		return result;
	}

	[EventFunction(439)]
	private static IntList AdventureGetElementListByCoreId(EventScriptRuntime runtime, int elementCoreId, bool containsInvisible)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId);
			IEnumerable<int> elementIdList = from e in elements
				where containsInvisible || e.Visible
				select e.Id;
			result.Items.AddRange(elementIdList);
		}
		return result;
	}

	[EventFunction(452)]
	private static void AdventureAddElementItem(EventScriptRuntime runtime, int elementId, ItemKey itemKey)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			adventureRuntime.AddTemporaryItem(runtime.Context, elementId, itemKey);
		}
	}

	[EventFunction(453)]
	private static void AdventureRemoveElementItem(EventScriptRuntime runtime, int elementId, ItemKey itemKey)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			adventureRuntime.RemoveTemporaryItem(runtime.Context, elementId, itemKey);
		}
	}

	[EventFunction(775)]
	private static void AdventureHalfItemToTaiwu(EventScriptRuntime runtime, bool half)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		List<GameData.Domains.Adventure.AdventureItem> items = (from _ in adventureRuntime.GetTemporaryItemsTaiwu()
			orderby runtime.Context.Random.Next()
			select _).ToList();
		for (int i = 0; i < items.Count; i++)
		{
			if (!half || i % 2 != 0)
			{
				GameData.Domains.Adventure.AdventureItem item = items[i];
				ItemKey itemKey = item.ItemKey;
				if (!adventureRuntime.UnbindTemporaryItem(0, itemKey))
				{
					throw new ArgumentException($"UnbindTemporaryItem taiwu, temporaryItem:{itemKey} failed.");
				}
				ItemBase itemItem = DomainManager.Item.GetBaseItem(itemKey);
				if (!itemItem.Owner.Equals(ItemOwnerKey.None))
				{
					DomainManager.Item.RemoveOwner(itemKey, itemItem.Owner.OwnerType, itemItem.Owner.OwnerId);
				}
				taiwu.AddInventoryItem(runtime.Context, itemKey, item.ItemCount);
				DomainManager.World.GetInstantNotificationCollection().AddGetItem(taiwu.GetId(), itemKey.ItemType, itemKey.TemplateId);
				runtime.Current.RegisterToShowGetItem(itemKey, item.ItemCount);
			}
		}
	}

	[EventFunction(454)]
	private static void AdventureSelectElementItem(EventScriptRuntime runtime, int elementId, string itemSaveKey)
	{
		int adventureId = -1;
		EventArgBox argBox = runtime.ArgBox;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		IEnumerable<GameData.Domains.Adventure.AdventureItem> allItems = adventureRuntime.GetTemporaryItems(elementId);
		if (!argBox.Get("SelectItemInfo", out EventSelectItemData selectItemData))
		{
			selectItemData = new EventSelectItemData();
			argBox.Set("SelectItemInfo", selectItemData);
		}
		SelectItemFilter filter = new SelectItemFilter
		{
			Key = itemSaveKey,
			DisplayDataFilterId = 0,
			FilterTemplateId = -1
		};
		foreach (GameData.Domains.Adventure.AdventureItem item in allItems)
		{
			ItemDisplayData itemDisplayData = DomainManager.Item.GetItemDisplayData(item.ItemKey);
			selectItemData.CanSelectItemList.Add(itemDisplayData);
		}
		selectItemData.FilterList.Add(filter);
	}

	[EventFunction(461)]
	private static void AdventureAddElementItemPoison(EventScriptRuntime runtime, int elementId, ItemKey targetItemKey, ItemKey medicineItemKey)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			GameData.Domains.Adventure.AdventureItem temporaryItem = adventureRuntime.GetTemporaryItem(elementId, targetItemKey);
			if (temporaryItem == null)
			{
				throw new Exception($"elementId:{elementId}, temporaryItem:{targetItemKey} Not exist");
			}
			ItemBase itemBase = DomainManager.Item.GetBaseItem(targetItemKey);
			(ItemBase item, bool keyChanged) tuple = DomainManager.Item.SetAttachedPoisons(runtime.Context, itemBase, medicineItemKey.TemplateId, add: true);
			ItemBase newItemBase = tuple.item;
			bool keyChanged = tuple.keyChanged;
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			taiwu.RemoveInventoryItem(runtime.Context, medicineItemKey, 1, deleteItem: true);
			if (keyChanged)
			{
				temporaryItem.ItemKey = newItemBase.GetItemKey();
				DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
			}
		}
	}

	[EventFunction(462)]
	private static ItemKey AdventureTransferItemToCharacter(EventScriptRuntime runtime, int elementId, ItemKey itemKey, GameData.Domains.Character.Character character)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			DataContext context = runtime.Context;
			GameData.Domains.Adventure.AdventureItem temporaryItem = adventureRuntime.GetTemporaryItem(elementId, itemKey);
			if (temporaryItem == null)
			{
				throw new ArgumentException($"elementId:{elementId}, temporaryItem:{itemKey} not exist");
			}
			if (!adventureRuntime.UnbindTemporaryItem(elementId, itemKey))
			{
				throw new ArgumentException($"elementId:{elementId}, temporaryItem:{itemKey} has been multi owned.");
			}
			character.AddInventoryItem(context, itemKey, temporaryItem.ItemCount);
			if (character.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
			{
				DomainManager.World.GetInstantNotificationCollection().AddGetItem(character.GetId(), itemKey.ItemType, itemKey.TemplateId);
				runtime.Current.RegisterToShowGetItem(itemKey, temporaryItem.ItemCount);
			}
			return itemKey;
		}
		return ItemKey.Invalid;
	}

	[EventFunction(463)]
	private static void AdventureTaiwuShowDialog(EventScriptRuntime runtime, string key)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureTaiwuShowDialog, key);
		}
	}

	[EventFunction(464)]
	private static void AdventureElementShowDialog(EventScriptRuntime runtime, int elementId, string key)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureElementShowDialog, elementId, key);
		}
	}

	[EventFunction(471)]
	private static bool AdventureCheckElementItemSubType(EventScriptRuntime runtime, int elementId, short itemSubType)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			foreach (GameData.Domains.Adventure.AdventureItem item in adventure.GetTemporaryItems(elementId))
			{
				if (item.ItemKey.GetConfig().ItemSubType == itemSubType)
				{
					return true;
				}
			}
		}
		return false;
	}

	[EventFunction(472)]
	private static ItemKey AdventureSelectElementRandomItemBySubType(EventScriptRuntime runtime, int elementId, short itemSubType)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			List<ItemKey> pool = ObjectPool<List<ItemKey>>.Instance.Get();
			foreach (GameData.Domains.Adventure.AdventureItem item in adventure.GetTemporaryItems(elementId))
			{
				if (item.ItemKey.GetConfig().ItemSubType == itemSubType)
				{
					pool.Add(item.ItemKey);
				}
			}
			ItemKey result = ((pool.Count > 0) ? pool.GetRandom(runtime.Context.Random) : ItemKey.Invalid);
			ObjectPool<List<ItemKey>>.Instance.Return(pool);
			return result;
		}
		return ItemKey.Invalid;
	}

	[EventFunction(487)]
	private static bool AdventureFindElementByCharacterId(EventScriptRuntime runtime, GameData.Domains.Character.Character character, string saveKey)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			IReadOnlyList<AdventureElement> allElements = adventure.GetAllElements();
			int characterId = character.GetId();
			if (characterId < 0)
			{
				return false;
			}
			foreach (AdventureElement element in allElements)
			{
				if (element.CharacterId == characterId)
				{
					runtime.ArgBox.Set(saveKey, element.Id);
					return true;
				}
			}
		}
		return false;
	}

	[EventFunction(491)]
	private static IntList AdventureFindElementMeetCondition(EventScriptRuntime runtime, int elementCoreId, string paramName, int operatorId, int requiredValue, bool containsInvisible)
	{
		IntList result = IntList.Create();
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			IEnumerable<AdventureElement> elementsByCoreId = adventureRuntime.GetElementsByCoreId(elementCoreId);
			IEnumerable<int> matchedElements = from e in elementsByCoreId.Where(delegate(AdventureElement element)
				{
					AdventureParameterValue parameter = element.GetParameter(paramName);
					return EventConditions.PerformOperation(operatorId, parameter.Current, requiredValue) && (containsInvisible || element.Visible);
				})
				select e.Id;
			result.Items.AddRange(matchedElements);
		}
		return result;
	}

	[EventFunction(492)]
	private static IntList AdventureFindElementAtLocationByTags(EventScriptRuntime runtime, int elementId, string inputTags, int tagArrayMatchType, bool containsInvisible)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement elementCurrent = adventureRuntime.GetElement(elementId);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElements(elementCurrent.Index);
			List<string> tags = ParseInputTags(inputTags);
			IEnumerable<int> matchedElements = from e in elements
				where containsInvisible || e.Visible
				where CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(e.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select e.Id;
			result.Items.AddRange(matchedElements);
		}
		return result;
	}

	[EventFunction(624)]
	private static IntList AdventureGetElementListAtBlockByTag(EventScriptRuntime runtime, AdventureBlockIndexForSerialize adventureBlockIndex, string inputTags, int tagArrayMatchType, bool containsInvisible)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElements(adventureBlockIndex);
			List<string> tags = ParseInputTags(inputTags);
			IEnumerable<int> matchedElements = from e in elements
				where containsInvisible || e.Visible
				where CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(e.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select e.Id;
			result.Items.AddRange(matchedElements);
		}
		return result;
	}

	[EventFunction(669)]
	private static IntList AdventureGetTaiwuLocationElementListByTag(EventScriptRuntime runtime, bool bigBlock, string inputTags, int tagArrayMatchType, bool containsInvisible)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			IEnumerable<AdventureElement> elements;
			if (bigBlock)
			{
				IReadOnlyList<AdventureElement> allElements = adventureRuntime.GetAllElements();
				elements = allElements.Where((AdventureElement e) => e.Index.X == adventureTaiwu.Index.X && e.Index.Y == adventureTaiwu.Index.Y);
			}
			else
			{
				elements = adventureRuntime.GetElements(adventureTaiwu.Index);
			}
			List<string> tags = ParseInputTags(inputTags);
			IEnumerable<int> matchedElements = from e in elements
				where containsInvisible || e.Visible
				where CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(e.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select e.Id;
			result.Items.AddRange(matchedElements);
		}
		return result;
	}

	[EventFunction(670)]
	private static bool AdventureSaveNearestElementByTag(EventScriptRuntime runtime, int targetElementId, string saveKey, string inputTags, int tagArrayMatchType, bool containsInvisible)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			IReadOnlyList<AdventureElement> allElements = adventureRuntime.GetAllElements();
			List<string> tags = ParseInputTags(inputTags);
			IEnumerable<int> matchedElements = from e in allElements
				where containsInvisible || e.Visible
				where CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(e.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select e.Id;
			int minDistance = int.MaxValue;
			AdventureElement targetElement = adventureRuntime.GetElement(targetElementId);
			foreach (int elementId in matchedElements)
			{
				AdventureElement element = adventureRuntime.GetElement(elementId);
				int distance = element.Index.GetManhattanDistance(targetElement.Index);
				if (distance < minDistance)
				{
					minDistance = distance;
					runtime.ArgBox.Set(saveKey, elementId);
				}
			}
			if (minDistance < int.MaxValue)
			{
				return true;
			}
		}
		return false;
	}

	[EventFunction(672)]
	private static void AdventureStopElementActionByTag(EventScriptRuntime runtime, string inputTags, int tagArrayMatchType, bool containsInvisible)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		IReadOnlyList<AdventureElement> allElements = adventureRuntime.GetAllElements();
		List<string> tags = ParseInputTags(inputTags);
		IEnumerable<int> matchedElements = from e in allElements
			where containsInvisible || e.Visible
			where CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(e.CoreId).Tags.ToList(), tags, tagArrayMatchType)
			select e.Id;
		bool set = false;
		foreach (int elementId in matchedElements)
		{
			if (adventureRuntime.IsElementAlive(elementId))
			{
				set = true;
				AdventureElement element = adventureRuntime.GetElement(elementId);
				adventureRuntime.InterruptElementAction(element);
			}
		}
		if (set)
		{
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
	}

	[EventFunction(495)]
	private static IntList AdventureGetElementKidnappedCharacterList(EventScriptRuntime runtime, int elementId)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement elementCurrent = adventure.GetElement(elementId);
			if (elementCurrent == null)
			{
				Logger.Warn("AdventureGetElementKidnappedCharacterList Function,element is null");
				return result;
			}
			if (DomainManager.Character.TryGetKidnappedCharacters(elementCurrent.CharacterId, out var kidnappedCharacterList))
			{
				result.Items.AddRange(from e in kidnappedCharacterList.GetCollection()
					select e.CharId);
			}
		}
		return result;
	}

	[EventFunction(496)]
	private static void AdventureStartCricketCombat(EventScriptRuntime runtime, int elementId, string afterEvent)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement elementCurrent = adventure.GetElement(elementId);
			if (elementCurrent == null)
			{
				Logger.Warn("AdventureStartCricketCombat Function,element is null");
			}
			else if (elementCurrent.CharacterId >= 0)
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartCricketCombat(elementCurrent.CharacterId, afterEvent, runtime.ArgBox);
			}
		}
	}

	[EventFunction(497)]
	private static bool AdventureSaveElementBlockIndex(EventScriptRuntime runtime, int elementId, string saveKey, int xOffset, int yOffset)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement element = adventure.GetElement(elementId);
			if (element == null)
			{
				Logger.Warn("AdventureSaveElementBlockIndex Function,element is null");
				return false;
			}
			AdventureBlockIndex newIndex = new AdventureBlockIndex(element.Index.Gx + xOffset, element.Index.Gy + yOffset);
			if (!adventure.InAdventure(newIndex))
			{
				return false;
			}
			runtime.ArgBox.Set(saveKey, (AdventureBlockIndexForSerialize)newIndex);
			return true;
		}
		return false;
	}

	[EventFunction(498)]
	private static bool AdventureSaveTaiwuBlockIndex(EventScriptRuntime runtime, string saveKey, int xOffset, int yOffset)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			AdventureBlockIndex newIndex = new AdventureBlockIndex(adventureTaiwu.Index.Gx + xOffset, adventureTaiwu.Index.Gy + yOffset);
			if (!adventure.InAdventure(newIndex))
			{
				return false;
			}
			runtime.ArgBox.Set(saveKey, (AdventureBlockIndexForSerialize)newIndex);
			return true;
		}
		return false;
	}

	[EventFunction(500)]
	private static SerializableList<AdventureBlockIndexForSerialize> AdventureGetBlockListByGroup(EventScriptRuntime runtime, int blockGroupId)
	{
		SerializableList<AdventureBlockIndexForSerialize> result = SerializableList<AdventureBlockIndexForSerialize>.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			List<AdventureBlockIndexForSerialize> blocks = adventure.CoreBlocks.Where((AdventureBlockData b) => b.GroupIds.Contains(blockGroupId)).Select((Func<AdventureBlockData, AdventureBlockIndexForSerialize>)((AdventureBlockData b) => b.Index)).ToList();
			result.Items.AddRange(blocks);
		}
		return result;
	}

	[EventFunction(502)]
	private static SerializableList<AdventureBlockIndexForSerialize> AdventureGetElementBigBlockList(EventScriptRuntime runtime, int elementId)
	{
		SerializableList<AdventureBlockIndexForSerialize> result = SerializableList<AdventureBlockIndexForSerialize>.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement element = adventure.GetElement(elementId);
			List<AdventureBlockIndexForSerialize> blocks = adventure.CoreBlocks.Where((AdventureBlockData b) => b.Index.X == element.Index.X && b.Index.Y == element.Index.Y).Select((Func<AdventureBlockData, AdventureBlockIndexForSerialize>)((AdventureBlockData b) => b.Index)).ToList();
			result.Items.AddRange(blocks);
		}
		return result;
	}

	[EventFunction(503)]
	private static SerializableList<AdventureBlockIndexForSerialize> AdventureGetTaiwuBigBlockList(EventScriptRuntime runtime)
	{
		SerializableList<AdventureBlockIndexForSerialize> result = SerializableList<AdventureBlockIndexForSerialize>.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			List<AdventureBlockIndexForSerialize> blocks = adventure.CoreBlocks.Where((AdventureBlockData b) => b.Index.X == adventureTaiwu.Index.X && b.Index.Y == adventureTaiwu.Index.Y).Select((Func<AdventureBlockData, AdventureBlockIndexForSerialize>)((AdventureBlockData b) => b.Index)).ToList();
			result.Items.AddRange(blocks);
		}
		return result;
	}

	[EventFunction(504)]
	private static IntList AdventureGetBlockElementList(EventScriptRuntime runtime, AdventureBlockIndexForSerialize blockIndex, bool containsInvisible)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			List<int> elementList = (from e in adventureRuntime.GetElements(blockIndex)
				where e.Visible || containsInvisible
				select e.Id).ToList();
			result.Items.AddRange(elementList);
		}
		return result;
	}

	[EventFunction(545)]
	private static IntList AdventureGetElementsInAction(EventScriptRuntime runtime, string actionKey)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			IReadOnlyList<AdventureElement> allElements = adventureRuntime.GetAllElements();
			foreach (AdventureElement element in allElements)
			{
				if (adventureRuntime.InActionElement(element))
				{
					int remainTime;
					AdventureActionData data = adventureRuntime.QueryElementActionData(element, out remainTime);
					if (data != null && data.Key == actionKey)
					{
						result.Items.Add(element.Id);
					}
				}
			}
		}
		return result;
	}

	[EventFunction(546)]
	private static IntList AdventureGetElementsInActionWithElement(EventScriptRuntime runtime, int elementId, string actionKey)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureElement element = adventureRuntime.GetElement(elementId);
			int remainTime;
			AdventureActionData data = adventureRuntime.QueryElementActionData(element, out remainTime);
			if (data != null && data.Key == actionKey)
			{
				IEnumerable<AdventureElement> elements = adventureRuntime.QueryElementActionGroupElements(element);
				foreach (AdventureElement e in elements)
				{
					result.Items.Add(e.Id);
				}
			}
		}
		return result;
	}

	[EventFunction(505)]
	private static void AdventureCameraMoveToBlock(EventScriptRuntime runtime, AdventureBlockIndexForSerialize blockIndex, bool reset, float oneWayDuration, float stayDuration, string afterEvent)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			if (!string.IsNullOrEmpty(afterEvent))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(afterEvent, runtime.ArgBox, "AdventureCameraMoveToBlockFinish");
			}
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureCameraMoveToBlock, blockIndex, reset, oneWayDuration, stayDuration);
		}
	}

	[EventFunction(776)]
	private static void AdventureDelayAction(EventScriptRuntime runtime, float delayDuration, string afterEvent)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			if (!string.IsNullOrEmpty(afterEvent))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(afterEvent, runtime.ArgBox, "AdventureDelayFinish");
			}
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureDelayAction, delayDuration);
		}
	}

	[EventFunction(506)]
	private static void AdventureElementMoveToBlock(EventScriptRuntime runtime, int elementId, AdventureBlockIndexForSerialize blockIndex)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			DomainManager.Adventure.MoveElementTo(runtime.Context, adventureId, elementId, blockIndex);
		}
	}

	[EventFunction(562)]
	private static void SetAdventureElementFollowTargetBlock(EventScriptRuntime runtime, int elementId, AdventureBlockIndexForSerialize index)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement element = adventure.GetElement(elementId);
			element.RemoveParameter("ConchShipPresetKey_FollowTargetElementId");
			element.SetParameter("ConchShipPresetKey_FollowTargetBlockIndex", (AdventureBlockIndex)index);
			DomainManager.Adventure.SetAny(runtime.Context, adventure);
		}
	}

	[EventFunction(563)]
	private static void SetAdventureElementFollowTargetElement(EventScriptRuntime runtime, int elementId, int targetElementId)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement element = adventure.GetElement(elementId);
			element.RemoveParameter("ConchShipPresetKey_FollowTargetBlockIndex");
			element.SetParameter("ConchShipPresetKey_FollowTargetElementId", targetElementId);
			DomainManager.Adventure.SetAny(runtime.Context, adventure);
		}
	}

	[EventFunction(564)]
	private static void ClearAdventureElementFollowTarget(EventScriptRuntime runtime, int elementId)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement element = adventure.GetElement(elementId);
			element.RemoveParameter("ConchShipPresetKey_FollowTargetElementId");
			element.RemoveParameter("ConchShipPresetKey_FollowTargetBlockIndex");
			DomainManager.Adventure.SetAny(runtime.Context, adventure);
		}
	}

	[EventFunction(574)]
	private static void AdventureSetGroupBlockCloud(EventScriptRuntime runtime, int groupId, bool open)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		IEnumerable<AdventureBlock> blocks = adventureRuntime.GetBlocksByGroupId(groupId);
		foreach (AdventureBlock adventureBlock in blocks)
		{
			adventureBlock.InCloud = open;
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
	}

	[EventFunction(575)]
	private static void AdventureSetBlockCloud(EventScriptRuntime runtime, AdventureBlockIndexForSerialize blockIndex, bool open)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureBlock adventureBlock = adventureRuntime.GetBlock(blockIndex);
			adventureBlock.InCloud = open;
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
	}

	[EventFunction(576)]
	private static void AdventureSetBlockListCloud(EventScriptRuntime runtime, SerializableList<AdventureBlockIndexForSerialize> blockIndexList, bool open)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		foreach (AdventureBlockIndexForSerialize blockIndex in blockIndexList.Items)
		{
			AdventureBlock adventureBlock = adventureRuntime.GetBlock(blockIndex);
			adventureBlock.InCloud = open;
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
	}

	[EventFunction(579)]
	private static SerializableList<AdventureBlockIndexForSerialize> AdventureGetBlockListAroundElement(EventScriptRuntime runtime, int elementId, int range)
	{
		SerializableList<AdventureBlockIndexForSerialize> result = SerializableList<AdventureBlockIndexForSerialize>.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement element = adventure.GetElement(elementId);
			foreach (AdventureBlockData blockData in adventure.CoreBlocks)
			{
				int distance = blockData.Index.GetManhattanDistance(element.Index);
				if (distance <= range)
				{
					result.Items.Add(blockData.Index);
				}
			}
		}
		return result;
	}

	[EventFunction(413)]
	private static void AdventureGroupEffect(EventScriptRuntime runtime, int targetGroupId, short templateId)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		IEnumerable<AdventureBlockData> blocks = adventureRuntime.CoreBlocks.Where((AdventureBlockData block) => block.GroupIds.Any(((int)targetGroupId).Equals));
		string particleName = string.Empty;
		if (templateId >= 0)
		{
			particleName = templateId.ToString();
		}
		foreach (AdventureBlockData blockData in blocks)
		{
			AdventureBlock adventureBlock = adventureRuntime.GetBlock(blockData.Index);
			adventureBlock.SpecialParticle = particleName;
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureRefreshBlockEffect);
	}

	[EventFunction(658)]
	private static void AdventureBlockListSetEffect(EventScriptRuntime runtime, SerializableList<AdventureBlockIndexForSerialize> blockList, short templateId)
	{
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return;
		}
		string particleName = string.Empty;
		if (templateId >= 0)
		{
			particleName = templateId.ToString();
		}
		foreach (AdventureBlockIndexForSerialize blockIndex in (IEnumerable<AdventureBlockIndexForSerialize>)blockList/*cast due to constrained. prefix*/)
		{
			AdventureBlock adventureBlock = adventureRuntime.GetBlock(blockIndex);
			adventureBlock.SpecialParticle = particleName;
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureRefreshBlockEffect);
	}

	[EventFunction(686)]
	private static void AdventureBlockSetEffect(EventScriptRuntime runtime, AdventureBlockIndexForSerialize blockIndex, short templateId)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string particleName = string.Empty;
			if (templateId >= 0)
			{
				particleName = templateId.ToString();
			}
			AdventureBlock adventureBlock = adventureRuntime.GetBlock(blockIndex);
			adventureBlock.SpecialParticle = particleName;
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureRefreshBlockEffect);
		}
	}

	[EventFunction(659)]
	private static void AdventureSetGlobalEffect(EventScriptRuntime runtime, short templateId)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			adventureRuntime.SetParameter("ConchShipPresetKey_Adventure_Global_Particle", templateId);
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureRefreshGlobalEffect);
		}
	}

	[EventFunction(656)]
	private static SerializableList<AdventureBlockIndexForSerialize> AdventureCreateBlockList(EventScriptRuntime runtime)
	{
		return SerializableList<AdventureBlockIndexForSerialize>.Create();
	}

	[EventFunction(657)]
	private static void AdventureBlockListAddElement(EventScriptRuntime runtime, SerializableList<AdventureBlockIndexForSerialize> blockList, AdventureBlockIndexForSerialize block)
	{
		blockList.Items.Add(block);
	}

	[EventFunction(844)]
	private static int QueryAdventureCountInWorld(EventScriptRuntime runtime, int coreId)
	{
		return DomainManager.Adventure.QueryCountInWorld(coreId);
	}

	[EventFunction(582)]
	private static void AdventureGenerate(EventScriptRuntime runtime, MapBlockData mapBlockData, int coreId)
	{
		Location location = mapBlockData.GetLocation();
		DomainManager.Adventure.GenerateAny(runtime.Context, coreId, location)?.CallCharacters(runtime.Context);
	}

	[EventFunction(822)]
	private static void AdventureGenerateNotCallCharacter(EventScriptRuntime runtime, MapBlockData mapBlockData, int coreId)
	{
		Location location = mapBlockData.GetLocation();
		DomainManager.Adventure.GenerateAny(runtime.Context, coreId, location);
	}

	[EventFunction(838)]
	private static void AdventureFillPresetCharacter(EventScriptRuntime runtime, MapBlockData mapBlockData, int charId, string characterKey)
	{
		Location location = mapBlockData.GetLocation();
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		AdventureRuntime adventure = DomainManager.Adventure.QueryAdventureInLocation(location);
		if (adventure == null)
		{
			throw new Exception($"Failed to fill preset character {character} cause adventure not found.");
		}
		AdventureElement element = adventure.DynamicBindPreCheckKey(characterKey, charId);
		if (element != null)
		{
			adventure.DynamicBindCalledCharacter(element, charId);
			DomainManager.Character.CallCharacterByAdventure(runtime.Context, adventure.MapLocation, character);
			DomainManager.Adventure.SetAny(runtime.Context, adventure);
			return;
		}
		throw new Exception($"Failed to fill preset character {character} cause adventure rejected.");
	}

	[EventFunction(718)]
	private static void AdventureCreateAndEnter(EventScriptRuntime runtime, int coreId)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwu.GetLocation();
		IAdventureRuntime adventure = DomainManager.Adventure.GenerateAny(runtime.Context, coreId, taiwuLocation);
		if (adventure != null)
		{
			adventure.CallCharacters(runtime.Context);
			if (!DomainManager.Adventure.EnterAdventureRemake(runtime.Context, adventure.Id, null))
			{
				Logger.Warn("Enter adventure failed");
			}
			else
			{
				GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.EnterAdventureFromEvent, adventure.Id);
			}
		}
	}

	[EventFunction(590)]
	private static bool GetAdventureElementFollowTargetBlock(EventScriptRuntime runtime, int elementId, string saveKey)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement element = adventure.GetElement(elementId);
			AdventureParameterValue index;
			bool result = element.TryGetParameter("ConchShipPresetKey_FollowTargetBlockIndex", out index);
			if (result)
			{
				runtime.ArgBox.Set(saveKey, (AdventureBlockIndexForSerialize)index.AsIndex);
			}
			return result;
		}
		return false;
	}

	[EventFunction(591)]
	private static bool GetAdventureElementFollowTargetElement(EventScriptRuntime runtime, int elementId, string saveKey)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement element = adventure.GetElement(elementId);
			AdventureParameterValue elementParam;
			bool result = element.TryGetParameter("ConchShipPresetKey_FollowTargetElementId", out elementParam);
			if (result)
			{
				AdventureElement targetElement = adventure.GetElement(elementParam.Current);
				runtime.ArgBox.Set(saveKey, targetElement.Id);
			}
			return result;
		}
		return false;
	}

	[EventFunction(695)]
	private static int GetRangeBetweenElement(EventScriptRuntime runtime, int elementId1, int elementId2)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement element1 = adventure.GetElement(elementId1);
			AdventureElement element2 = adventure.GetElement(elementId2);
			return element1.Index.GetManhattanDistance(element2.Index);
		}
		return -1;
	}

	[EventFunction(694)]
	private static IntList AdventureGetElementListAroundElement(EventScriptRuntime runtime, int elementId, int range)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement elementCenter = adventure.GetElement(elementId);
			foreach (AdventureBlockData blockData in adventure.CoreBlocks)
			{
				int distance = blockData.Index.GetManhattanDistance(elementCenter.Index);
				if (distance > range)
				{
					continue;
				}
				IEnumerable<AdventureElement> elements = adventure.GetElements(blockData.Index);
				foreach (AdventureElement element in elements)
				{
					result.Items.Add(element.Id);
				}
			}
		}
		return result;
	}

	[EventFunction(696)]
	private static void AdventureSaveAllElementLocation(EventScriptRuntime runtime, string key)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			return;
		}
		foreach (AdventureElement element in adventure.GetAllElements())
		{
			element.SetParameter(key, element.Index);
		}
		DomainManager.Adventure.SetAny(runtime.Context, adventure);
	}

	[EventFunction(697)]
	private static void AdventureSaveElementLocation(EventScriptRuntime runtime, int elementId, string key)
	{
		IntList result = IntList.Create();
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			AdventureElement element = adventure.GetElement(elementId);
			element.SetParameter(key, element.Index);
			DomainManager.Adventure.SetAny(runtime.Context, adventure);
		}
	}

	[EventFunction(700)]
	private static void AdventureStartSelectElement(EventScriptRuntime runtime, AdventureBlockIndexForSerialize blockIndex, int range, string saveKey, string afterEvent)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			if (!string.IsNullOrEmpty(afterEvent))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(afterEvent, runtime.ArgBox, "AdventureSelectElementFinish");
			}
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.AdventureStartSelectElement, blockIndex, range, saveKey);
		}
	}

	[EventFunction(777)]
	private static ValueInfo AdventureElementDirectionalMoveNew(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			int xOffset = parameters[1].GetIntValue(evaluator);
			int yOffset = parameters[2].GetIntValue(evaluator);
			bool ignorePassable = parameters[3].GetBoolValue(evaluator);
			AdventureBlockIndex nextBlockIndex = new AdventureBlockIndex(element.Index.Gx + xOffset, element.Index.Gy + yOffset);
			if (adventureRuntime.InAdventure(nextBlockIndex) && (adventureRuntime.IsPassable(nextBlockIndex) || ignorePassable))
			{
				DomainManager.Adventure.MoveElementTo(runtime.Context, adventureId, elementId, nextBlockIndex);
				DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(783)]
	private static ValueInfo AdventureTaiwuDirectionalMoveNew(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			int xOffset = parameters[0].GetIntValue(evaluator);
			int yOffset = parameters[1].GetIntValue(evaluator);
			bool ignorePassable = parameters[2].GetBoolValue(evaluator);
			AdventureBlockIndex nextBlockIndex = new AdventureBlockIndex(adventureTaiwu.Index.Gx + xOffset, adventureTaiwu.Index.Gy + yOffset);
			if (adventureRuntime.InAdventure(nextBlockIndex) && (adventureRuntime.IsPassable(nextBlockIndex) || ignorePassable))
			{
				adventureTaiwu.SetCurrentIndex(nextBlockIndex);
				DomainManager.Adventure.SetAdventureTaiwu(adventureTaiwu, runtime.Context);
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(830)]
	private static void GenerateEnemyNestMinion(EventScriptRuntime runtime)
	{
		int adventureId = 0;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			return;
		}
		EnemyNestItem enemyNest = EnemyNest.Instance.FirstOrDefault((EnemyNestItem x) => x.AdventureId == adventure.CoreId);
		if (enemyNest == null)
		{
			return;
		}
		Location location = adventure.MapLocation;
		List<short> enemyIds = enemyNest.Members;
		List<short> baseSpawnAmount = enemyNest.SpawnAmountFactors;
		int factor = DomainManager.World.GetHereticsAmountFactor();
		List<MapBlockData> validBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetValidBlocksForRandomEnemy(location.AreaId, location.BlockId, 3, onSettlement: false, nearTaiwu: false, validBlocks);
		if (enemyNest.TemplateId == 3)
		{
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
			sbyte regionalSectId = MapState.Instance[stateTemplateId].SectID;
			int sectIndex = regionalSectId - 1;
			if (validBlocks.Count > 0)
			{
				DomainManager.Map.CreateRandomEnemiesOnValidBlocks(runtime.Context, 1, location, enemyIds[sectIndex], baseSpawnAmount[sectIndex] * factor / 100, validBlocks);
			}
		}
		else if (validBlocks.Count > 0)
		{
			for (int i = 0; i < enemyIds.Count; i++)
			{
				DomainManager.Map.CreateRandomEnemiesOnValidBlocks(runtime.Context, 1, location, enemyIds[i], baseSpawnAmount[i] * factor / 100, validBlocks);
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(validBlocks);
	}

	[EventFunction(831)]
	private static void ComplementEnemyNestMinion(EventScriptRuntime runtime)
	{
		int adventureId = 0;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			return;
		}
		EnemyNestItem enemyNest = EnemyNest.Instance.FirstOrDefault((EnemyNestItem x) => x.AdventureId == adventure.CoreId);
		if (enemyNest == null)
		{
			return;
		}
		Location location = adventure.MapLocation;
		List<short> enemyIds = enemyNest.Members;
		List<short> baseSpawnAmount = enemyNest.SpawnAmountFactors;
		int factor = DomainManager.World.GetHereticsAmountFactor();
		List<MapBlockData> validBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetValidBlocksForRandomEnemy(location.AreaId, location.BlockId, 3, onSettlement: false, nearTaiwu: false, validBlocks);
		if (enemyNest.TemplateId == 3)
		{
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId);
			sbyte regionalSectId = MapState.Instance[stateTemplateId].SectID;
			int sectIndex = regionalSectId - 1;
			int needAmount = baseSpawnAmount[sectIndex] * factor / 100;
			int hasAmount = validBlocks.Sum((MapBlockData x) => x.TemplateEnemyList?.Count((MapTemplateEnemyInfo mapTemplateEnemyInfo) => mapTemplateEnemyInfo.SourceType == 1) ?? 0);
			if (validBlocks.Count > 0 && needAmount > hasAmount)
			{
				DomainManager.Map.CreateRandomEnemiesOnValidBlocks(runtime.Context, 1, location, enemyIds[sectIndex], 1, validBlocks);
			}
		}
		else if (validBlocks.Count > 0)
		{
			Span<int> hasAmounts = stackalloc int[enemyIds.Count];
			Span<int> indexOrders = stackalloc int[enemyIds.Count];
			for (int i = 0; i < enemyIds.Count; i++)
			{
				hasAmounts[i] = 0;
				indexOrders[i] = i;
			}
			CollectionUtils.Shuffle(runtime.Context.Random, indexOrders, enemyIds.Count);
			foreach (MapBlockData blockData in validBlocks)
			{
				List<MapTemplateEnemyInfo> templateEnemyList = blockData.TemplateEnemyList;
				if (templateEnemyList == null || templateEnemyList.Count <= 0)
				{
					continue;
				}
				foreach (MapTemplateEnemyInfo templateEnemy in blockData.TemplateEnemyList)
				{
					int index = enemyIds.IndexOf(templateEnemy.TemplateId);
					if (index >= 0)
					{
						hasAmounts[index]++;
					}
				}
			}
			for (int i2 = 0; i2 < enemyIds.Count; i2++)
			{
				int index2 = indexOrders[i2];
				int needAmount2 = baseSpawnAmount[index2] * factor / 100;
				int hasAmount2 = hasAmounts[index2];
				if (needAmount2 > hasAmount2)
				{
					DomainManager.Map.CreateRandomEnemiesOnValidBlocks(runtime.Context, 1, location, enemyIds[index2], 1, validBlocks);
					break;
				}
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(validBlocks);
	}

	[EventFunction(855)]
	private static void ClearEnemyNestMinion(EventScriptRuntime runtime)
	{
		int adventureId = 0;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			return;
		}
		EnemyNestItem enemyNest = EnemyNest.Instance.FirstOrDefault((EnemyNestItem x) => x.AdventureId == adventure.CoreId);
		if (enemyNest == null)
		{
			return;
		}
		DataContext context = runtime.Context;
		Location location = adventure.MapLocation;
		List<MapBlockData> validBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetValidBlocksForRandomEnemy(location.AreaId, location.BlockId, 3, onSettlement: false, nearTaiwu: false, validBlocks);
		foreach (MapBlockData block in validBlocks)
		{
			List<MapTemplateEnemyInfo> templateEnemyList = block.TemplateEnemyList;
			if (templateEnemyList == null || templateEnemyList.Count <= 0)
			{
				continue;
			}
			Location enemyLocation = block.GetLocation();
			for (int i = block.TemplateEnemyList.Count - 1; i >= 0; i--)
			{
				MapTemplateEnemyInfo enemyInfo = block.TemplateEnemyList[i];
				if (enemyInfo.SourceAdventureBlockId == location.BlockId)
				{
					Events.RaiseTemplateEnemyLocationChanged(context, enemyInfo, enemyLocation, Location.Invalid);
				}
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(validBlocks);
		EAdventureRemoveType removeType = (EAdventureRemoveType)runtime.ArgBox.GetInt("ConchShipPresetKey_RemoveType");
		if (removeType == EAdventureRemoveType.Complete)
		{
			DomainManager.Adventure.ApplyDestroyEnemyNest(context, enemyNest.TemplateId);
		}
	}

	[EventFunction(895)]
	private static void ClearResourceDisasterStatus(EventScriptRuntime runtime)
	{
		EventArgBox argBox = runtime.ArgBox;
		int adventureId = 0;
		if (argBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adv))
		{
			DataContext context = runtime.Context;
			if (ResourceDisasterHelper.IsDisasterAdventure(adv.CoreId))
			{
				DomainManager.Extra.OnBuildingAreaEffectLocationChanged(context, 2, adv.MapLocation, Location.Invalid);
			}
		}
	}

	[EventFunction(883)]
	private static void ClearElopeWithLoveStatus(EventScriptRuntime runtime)
	{
		EventArgBox globalEventArgBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		globalEventArgBox.Remove<int>("ForeverLoverId");
		globalEventArgBox.Remove<int>("StoryForeverLoverId");
		DataContext context = runtime.Context;
		EventArgBox argBox = runtime.ArgBox;
		int adventureId = 0;
		if (!argBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adv))
		{
			return;
		}
		int charId = adv.GetElementByCharacterKey("TaiwuMate")?.CharacterId ?? (-1);
		if (charId < 0 || !DomainManager.Character.TryGetElement_Objects(charId, out var lover))
		{
			return;
		}
		OrganizationInfo orgInfo = lover.GetOrganizationInfo();
		OrganizationItem orgConfig = Config.Organization.Instance[orgInfo.OrgTemplateId];
		if (orgConfig.IsSect)
		{
			short featureId = orgConfig.PunishmentFeature;
			if (featureId >= 0)
			{
				lover.AddFeature(context, featureId);
			}
			if (DomainManager.Organization.TryGetElement_Sects(orgInfo.SettlementId, out var sect))
			{
				short punishmentType = 0;
				DomainManager.Organization.PunishSectMember(context, sect, lover, 3, punishmentType, isArrested: true);
				LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
				int date = DomainManager.World.GetCurrDate();
				lifeRecordCollection.AddSectPunishElope(charId, date);
			}
		}
	}

	[EventFunction(887)]
	private static void ClearSwordTombStatus(EventScriptRuntime runtime)
	{
		DataContext context = runtime.Context;
		EventArgBox argBox = runtime.ArgBox;
		int adventureId = 0;
		if (!argBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			return;
		}
		sbyte xiangshuAvatarId = XiangshuAvatarIds.GetXiangshuAvatarIdBySwordTomb(adventure.CoreId);
		if (xiangshuAvatarId < 0)
		{
			return;
		}
		for (short weakenedXiangshuTemplateId = XiangshuAvatarIds.WeakenedXiangshuBossBeginIds[xiangshuAvatarId]; weakenedXiangshuTemplateId <= XiangshuAvatarIds.WeakenedXiangshuBossEndIds[xiangshuAvatarId]; weakenedXiangshuTemplateId++)
		{
			if (DomainManager.Character.TryGetFixedCharacterByTemplateId(weakenedXiangshuTemplateId, out var character))
			{
				DomainManager.Character.RemoveNonIntelligentCharacter(context, character);
			}
		}
		IReadOnlySet<int> swordTombKeepers = DomainManager.Taiwu.GetVillagerRoleSet(5);
		foreach (int charId in swordTombKeepers)
		{
			VillagerRoleBase villagerRole = DomainManager.Extra.GetVillagerRole(charId);
			if (villagerRole is VillagerRoleSwordTombKeeper { ArrangementTemplateId: 13 } keeper && keeper.XiangshuAvatarId == xiangshuAvatarId)
			{
				DomainManager.Taiwu.RemoveVillagerWork(context, charId);
			}
		}
	}

	public static bool CheckAdventureElementTagsMatch(List<string> elementTags, List<string> paramTags, int adventureElementTagArrayMatchType)
	{
		return adventureElementTagArrayMatchType switch
		{
			0 => elementTags.SequenceEqual(paramTags), 
			1 => elementTags.Intersect(paramTags).Any(), 
			2 => paramTags.All(elementTags.Contains), 
			_ => throw new Exception($"adventureElementTagArrayMatchType : {adventureElementTagArrayMatchType} outside"), 
		};
	}

	public static List<string> ParseInputTags(string inputTag)
	{
		return (from e in inputTag.Split(",")
			select e.Trim()).ToList();
	}

	private static bool ParseAdventureBlockIndex(string blockIndexStr, out AdventureBlockIndex blockIndex)
	{
		blockIndex = default(AdventureBlockIndex);
		if (string.IsNullOrWhiteSpace(blockIndexStr))
		{
			return false;
		}
		string[] parts = blockIndexStr.Split(',');
		if (parts.Length != 3)
		{
			return false;
		}
		Span<int> indices = stackalloc int[3];
		for (int i = 0; i < 3; i++)
		{
			if (!int.TryParse(parts[i].AsSpan().Trim(), out var index))
			{
				return false;
			}
			indices[i] = index;
		}
		blockIndex = new AdventureBlockIndex(indices[0], indices[1], indices[2]);
		return true;
	}

	[EventFunction(510)]
	private static ValueInfo AdventureElementDirectionalMove(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			int xOffset = parameters[1].GetIntValue(evaluator);
			int yOffset = parameters[2].GetIntValue(evaluator);
			AdventureBlockIndex nextBlockIndex = new AdventureBlockIndex(element.Index.Gx + xOffset, element.Index.Gy + yOffset);
			if (adventureRuntime.IsPassable(nextBlockIndex))
			{
				DomainManager.Adventure.MoveElementTo(runtime.Context, adventureId, elementId, nextBlockIndex);
				DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(518)]
	private static ValueInfo AdventureElementParametricDirectionalMove(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			string xOffsetParameterKey = parameters[1].GetStringValue(evaluator);
			string yOffsetParameterKey = parameters[2].GetStringValue(evaluator);
			int xOffset = element.GetParameter(xOffsetParameterKey).Current;
			int yOffset = element.GetParameter(yOffsetParameterKey).Current;
			AdventureBlockIndex nextBlockIndex = new AdventureBlockIndex(element.Index.Gx + xOffset, element.Index.Gy + yOffset);
			if (adventureRuntime.IsPassable(nextBlockIndex))
			{
				DomainManager.Adventure.MoveElementTo(runtime.Context, adventureId, elementId, nextBlockIndex);
				DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(523)]
	private static ValueInfo AdventureChangeElementCountAtTaiwuDirectionalBlock(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			int xOffset = parameters[0].GetIntValue(evaluator);
			int yOffset = parameters[1].GetIntValue(evaluator);
			AdventureBlockIndex nextBlockIndex = new AdventureBlockIndex(adventureTaiwu.Index.Gx + xOffset, adventureTaiwu.Index.Gy + yOffset);
			int elementCoreId = parameters[2].GetIntValue(evaluator);
			int changeCount = parameters[3].GetIntValue(evaluator);
			if (changeCount == 0)
			{
				return ValueInfo.Void;
			}
			if (changeCount > 0)
			{
				for (int i = 0; i < changeCount; i++)
				{
					DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, nextBlockIndex);
				}
			}
			else
			{
				List<AdventureElement> elements = adventureRuntime.GetElements(nextBlockIndex).ToList();
				changeCount = -changeCount;
				int count = 0;
				for (int i2 = elements.Count - 1; i2 >= 0; i2--)
				{
					AdventureElement element = elements[i2];
					if (element.CoreId == elementCoreId)
					{
						adventureRuntime.RemoveElement(element.Id);
						count++;
					}
					if (count >= changeCount)
					{
						break;
					}
				}
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(524)]
	private static ValueInfo AdventureSaveElementByIdAtTaiwuDirectionalBlock(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			int xOffset = parameters[0].GetIntValue(evaluator);
			int yOffset = parameters[1].GetIntValue(evaluator);
			AdventureBlockIndex nextBlockIndex = new AdventureBlockIndex(adventureTaiwu.Index.Gx + xOffset, adventureTaiwu.Index.Gy + yOffset);
			int elementCoreId = parameters[2].GetIntValue(evaluator);
			string saveKey = parameters[3].GetStringValue(evaluator);
			bool containsInvisible = parameters[4].GetBoolValue(evaluator);
			AdventureElement matchedElement = (from element in adventureRuntime.GetElementsByCoreId(elementCoreId)
				where element.Index.Equals(nextBlockIndex)
				select element).LastOrDefault((AdventureElement element) => containsInvisible || element.Visible);
			if (matchedElement != null)
			{
				runtime.ArgBox.Set(saveKey, matchedElement.Id);
			}
			else
			{
				Logger.Warn("AdventureSaveElementByIdAtTaiwuDirectionalBlock,Not find match element");
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(528)]
	private static ValueInfo AdventureShowHideCloudByViewAtGroup(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			bool farView = parameters[0].GetBoolValue(evaluator);
			int groupId = parameters[1].GetIntValue(evaluator);
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			int range = adventureRuntime.GetParameter(farView ? "view_range_1" : "view_range_0").Current;
			foreach (AdventureBlockData blockData in adventureRuntime.CoreBlocks)
			{
				if (groupId == 0 || blockData.GroupIds.Contains(groupId))
				{
					AdventureBlock adventureBlock = adventureRuntime.GetBlock(blockData.Index);
					adventureBlock.InCloud = blockData.Index.GetManhattanDistance(adventureTaiwu.Index) > range;
				}
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(529)]
	private static ValueInfo AdventureHideCloudAtGroup(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int groupId = parameters[0].GetIntValue(evaluator);
			foreach (AdventureBlockData blockData in adventureRuntime.CoreBlocks)
			{
				if (groupId == 0 || blockData.GroupIds.Contains(groupId))
				{
					AdventureBlock adventureBlock = adventureRuntime.GetBlock(blockData.Index);
					adventureBlock.InCloud = false;
				}
			}
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(549)]
	private static ValueInfo AdventureTaiwuDirectionalMove(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			int xOffset = parameters[0].GetIntValue(evaluator);
			int yOffset = parameters[1].GetIntValue(evaluator);
			AdventureBlockIndex nextBlockIndex = new AdventureBlockIndex(adventureTaiwu.Index.Gx + xOffset, adventureTaiwu.Index.Gy + yOffset);
			if (adventureRuntime.IsPassable(nextBlockIndex))
			{
				adventureTaiwu.SetCurrentIndex(nextBlockIndex);
				DomainManager.Adventure.SetAdventureTaiwu(adventureTaiwu, runtime.Context);
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(550)]
	private static ValueInfo AdventureConsumeActionPoint(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int actionPoints = parameters[0].GetIntValue(evaluator);
		DomainManager.Adventure.ConsumeActionPointInAdventure(runtime.Context, actionPoints);
		return ValueInfo.Void;
	}

	[EventFunction(551)]
	private static ValueInfo AdventureSaveTaiwuPreAndCurBlockIndex(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			string paramNamePreBlockGx = parameters[0].GetStringValue(evaluator);
			string paramNamePreBlockGy = parameters[1].GetStringValue(evaluator);
			string paramNameCurBlockGx = parameters[2].GetStringValue(evaluator);
			string paramNameCurBlockGy = parameters[3].GetStringValue(evaluator);
			adventureRuntime.SetParameter(paramNamePreBlockGx, adventureRuntime.GetParameter(paramNameCurBlockGx).Current);
			adventureRuntime.SetParameter(paramNamePreBlockGy, adventureRuntime.GetParameter(paramNameCurBlockGy).Current);
			adventureRuntime.SetParameter(paramNameCurBlockGx, adventureTaiwu.Index.Gx);
			adventureRuntime.SetParameter(paramNameCurBlockGy, adventureTaiwu.Index.Gy);
		}
		return ValueInfo.Void;
	}

	[EventFunction(552)]
	private static ValueInfo AdventureSetTaiwuToBlockIndex(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			int gx = parameters[0].GetIntValue(evaluator);
			int gy = parameters[1].GetIntValue(evaluator);
			AdventureBlockIndex nextBlockIndex = new AdventureBlockIndex(gx, gy);
			if (adventureRuntime.IsPassable(nextBlockIndex))
			{
				adventureTaiwu.SetCurrentIndex(nextBlockIndex);
				DomainManager.Adventure.SetAdventureTaiwu(adventureTaiwu, runtime.Context);
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(554)]
	private static ValueInfo AdventureCreateElementRandomAtBigBlock(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			int blockX = parameters[1].GetIntValue(evaluator);
			int blockY = parameters[2].GetIntValue(evaluator);
			int count = parameters[3].GetIntValue(evaluator);
			for (int i = 0; i < count; i++)
			{
				int blockI = runtime.Context.Random.Next(0, 9);
				DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, new AdventureBlockIndex(blockX, blockY, blockI));
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(565)]
	private static ValueInfo AdventureSaveElementCurBlockIndex(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			string paramNameCurBlockGx = parameters[1].GetStringValue(evaluator);
			string paramNameCurBlockGy = parameters[2].GetStringValue(evaluator);
			element.SetParameter(paramNameCurBlockGx, element.Index.Gx);
			element.SetParameter(paramNameCurBlockGy, element.Index.Gy);
			DomainManager.Adventure.SetAny(runtime.Context, adventureRuntime);
		}
		return ValueInfo.Void;
	}

	[EventFunction(660)]
	private static ValueInfo ChangeCharacterRelationBecomeHusbandOrWife(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character characterA = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		GameData.Domains.Character.Character characterB = parameters[1].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		bool succeed = parameters[2].GetBoolValue(evaluator);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ApplyRelationBecomeHusbandOrWife(characterA, characterB, succeed);
		return ValueInfo.Void;
	}

	[EventFunction(673)]
	private static ValueInfo AdventureCreateElementRandomAtGroup(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int groupId = parameters[0].GetIntValue(evaluator);
			int elementCoreId = parameters[1].GetIntValue(evaluator);
			int needCreateNum = parameters[2].GetIntValue(evaluator);
			if (needCreateNum <= 0)
			{
				return ValueInfo.Void;
			}
			bool isCanStack = parameters[3].GetBoolValue(evaluator);
			List<AdventureBlockIndex> theGroupBlockIndexList = new List<AdventureBlockIndex>();
			foreach (AdventureBlockData blockData in adventureRuntime.CoreBlocks)
			{
				if (groupId == 0 || blockData.GroupIds.Contains(groupId))
				{
					theGroupBlockIndexList.Add(blockData.Index);
				}
			}
			if (theGroupBlockIndexList.Count == 0)
			{
				return ValueInfo.Void;
			}
			if (isCanStack)
			{
				for (int i = 0; i < needCreateNum; i++)
				{
					int tempRandomIndex = runtime.Context.Random.Next(0, theGroupBlockIndexList.Count);
					DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, theGroupBlockIndexList[tempRandomIndex]);
				}
			}
			else
			{
				string inputTags = parameters[4].GetStringValue(evaluator);
				List<string> tags = ParseInputTags(inputTags);
				bool containsInvisible = parameters[5].GetBoolValue(evaluator);
				int tagArrayMatchType = parameters[6].GetIntValue(evaluator);
				List<AdventureBlockIndex> tempBlockIndexList = new List<AdventureBlockIndex>();
				for (int j = 0; j < theGroupBlockIndexList.Count; j++)
				{
					IEnumerable<AdventureElement> elements = adventureRuntime.GetElements(theGroupBlockIndexList[j]);
					int count = elements.Where((AdventureElement element) => containsInvisible || element.Visible).Count((AdventureElement element) => CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
					if (count <= 0)
					{
						tempBlockIndexList.Add(theGroupBlockIndexList[j]);
					}
				}
				for (int i2 = 0; i2 < needCreateNum; i2++)
				{
					if (tempBlockIndexList.Count > 0)
					{
						int tempRandomIndex2 = runtime.Context.Random.Next(0, tempBlockIndexList.Count);
						DomainManager.Adventure.CreateElementAt(runtime.Context, adventureId, elementCoreId, tempBlockIndexList[tempRandomIndex2]);
						tempBlockIndexList.RemoveAt(tempRandomIndex2);
					}
				}
			}
		}
		return ValueInfo.Void;
	}

	[EventFunction(682)]
	private static ValueInfo GetCharacterAttraction(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		return evaluator.PushEvaluationResult(character.GetAttraction());
	}

	[EventFunction(684)]
	private static ValueInfo GetCharacterCurrMainAttribute(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int mainAttributeType = parameters[1].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(character.GetCurrMainAttribute((sbyte)mainAttributeType));
	}

	[EventFunction(685)]
	private static ValueInfo CreateEnemyCharacterByConsummateLevel(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int characterTemplateId = parameters[0].GetIntValue(evaluator);
		int consummateLevel = parameters[1].GetIntValue(evaluator);
		CharacterItem template = Config.Character.Instance[characterTemplateId];
		if (template.GroupId >= 0)
		{
			short adjustedTemplateId = CharacterDomain.GetCharacterTemplateIdInGroup(template.GroupId, (sbyte)consummateLevel);
			template = Config.Character.Instance[adjustedTemplateId];
		}
		return evaluator.PushEvaluationResult(GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateNonIntelligentCharacter(template.TemplateId));
	}
}
