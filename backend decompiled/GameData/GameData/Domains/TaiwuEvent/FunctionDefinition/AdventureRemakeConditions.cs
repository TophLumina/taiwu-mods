using System.Collections.Generic;
using System.Linq;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using GameData.Adventure;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class AdventureRemakeConditions
{
	[EventFunction(421)]
	private static ValueInfo CheckCurrentAdventure(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		int adventureId = -1;
		Evaluator evaluator = runtime.Evaluator;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId))
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		AdventureRuntime adventure = DomainManager.Adventure.GetElement_Adventures(adventureId);
		int coreId = adventure.CoreId;
		int expectedCoreId = parameters[0].GetIntValue(evaluator);
		return evaluator.PushEvaluationResult(coreId == expectedCoreId);
	}

	[EventFunction(183)]
	private static ValueInfo CheckAdventureElementVisible(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			return evaluator.PushEvaluationResult(element.Visible);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(219)]
	private static ValueInfo CheckAdventureParameter(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string paramKey = parameters[0].GetStringValue(evaluator);
			int operatorId = parameters[1].GetIntValue(evaluator);
			int requiredValue = parameters[2].GetIntValue(evaluator);
			bool result = EventConditions.PerformOperation(operatorId, adventureRuntime.GetParameter(paramKey).Current, requiredValue);
			AdventureData adventureData = AdventureDomain.Core.GetAdventureData(adventureRuntime.CoreId);
			string paramName = string.Empty;
			foreach (AdventureParameterData parameterData in adventureData.Parameters)
			{
				if (parameterData.Key.Equals(paramKey))
				{
					paramName = parameterData.Name;
					break;
				}
			}
			if (runtime.RecordingConditionHints)
			{
				runtime.RecordConditionHint(219, result, paramName, EventConditionOperator.Instance[operatorId].Name, requiredValue.ToString());
			}
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(222)]
	private static ValueInfo CheckAdventureParameterStartWith(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureData adventureData = AdventureDomain.Core.GetAdventureData(adventureRuntime.CoreId);
			string paramName = parameters[0].GetStringValue(evaluator);
			int operatorId = parameters[1].GetIntValue(evaluator);
			int requiredValue = parameters[2].GetIntValue(evaluator);
			if (parameters[3].GetBoolValue(evaluator))
			{
				foreach (AdventureParameterData parameterData in adventureData.Parameters)
				{
					if (parameterData.Key.StartsWith(paramName) && EventConditions.PerformOperation(operatorId, adventureRuntime.GetParameter(parameterData.Key).Current, requiredValue))
					{
						return evaluator.PushEvaluationResult(value: true);
					}
				}
				return evaluator.PushEvaluationResult(value: false);
			}
			bool result = true;
			foreach (AdventureParameterData parameterData2 in adventureData.Parameters)
			{
				if (parameterData2.Key.StartsWith(paramName) && !EventConditions.PerformOperation(operatorId, adventureRuntime.GetParameter(parameterData2.Key).Current, requiredValue))
				{
					result = false;
					break;
				}
			}
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(225)]
	private static ValueInfo AdventureCheckProb(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		int chance = parameters[0].GetIntValue(runtime.Evaluator);
		bool retVal = runtime.Context.Random.CheckPercentProb(chance);
		return runtime.Evaluator.PushEvaluationResult(retVal);
	}

	[EventFunction(228)]
	private static ValueInfo CheckAdventureElementCount(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			int operatorId = parameters[1].GetIntValue(evaluator);
			int requiredCount = parameters[2].GetIntValue(evaluator);
			int count = adventureRuntime.GetElementsByCoreId(elementCoreId).Count();
			bool result = EventConditions.PerformOperation(operatorId, count, requiredCount);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(229)]
	private static ValueInfo CheckAdventureElementTagCount(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string inputTags = parameters[0].GetStringValue(evaluator);
			int operatorId = parameters[1].GetIntValue(evaluator);
			int requiredCount = parameters[2].GetIntValue(evaluator);
			bool containsInvisible = parameters[3].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[4].GetIntValue(evaluator);
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			int count = elements.Where((AdventureElement element) => containsInvisible || element.Visible).Count((AdventureElement element) => AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
			bool result = EventConditions.PerformOperation(operatorId, count, requiredCount);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(230)]
	private static ValueInfo CheckAdventureParameterIsMax(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string elementKey = parameters[0].GetStringValue(evaluator);
			string elementKeyStart = parameters[1].GetStringValue(evaluator);
			bool only = parameters[2].GetBoolValue(evaluator);
			bool result = true;
			int adventureCoreId = adventureRuntime.CoreId;
			AdventureData adventureData = AdventureDomain.Core.GetAdventureData(adventureCoreId);
			AdventureParameterValue parameterValue = adventureRuntime.GetParameter(elementKey);
			foreach (AdventureParameterData parameterData in adventureData.Parameters)
			{
				if (parameterData.Key.StartsWith(elementKeyStart))
				{
					AdventureParameterValue keyParameterValue = adventureRuntime.GetParameter(parameterData.Key);
					if ((only && parameterValue.Current <= keyParameterValue.Current) || (!only && parameterValue.Current < keyParameterValue.Current))
					{
						result = false;
						break;
					}
				}
			}
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(231)]
	private static ValueInfo CheckAdventureParameterIsMin(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string elementKey = parameters[0].GetStringValue(evaluator);
			string elementKeyStart = parameters[1].GetStringValue(evaluator);
			bool only = parameters[2].GetBoolValue(evaluator);
			bool result = true;
			int adventureCoreId = adventureRuntime.CoreId;
			AdventureData adventureData = AdventureDomain.Core.GetAdventureData(adventureCoreId);
			AdventureParameterValue parameterValue = adventureRuntime.GetParameter(elementKey);
			foreach (AdventureParameterData parameterData in adventureData.Parameters)
			{
				if (parameterData.Key.StartsWith(elementKeyStart))
				{
					AdventureParameterValue keyParameterValue = adventureRuntime.GetParameter(parameterData.Key);
					if ((only && parameterValue.Current >= keyParameterValue.Current) || (!only && parameterValue.Current > keyParameterValue.Current))
					{
						result = false;
						break;
					}
				}
			}
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(186)]
	private static ValueInfo CheckAdventureElementGroup(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			bool all = parameters[1].GetBoolValue(evaluator);
			int blockGroupId = parameters[2].GetIntValue(evaluator);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId);
			List<AdventureBlockIndex> blocks = (from b in adventureRuntime.CoreBlocks
				where b.GroupIds.Contains(blockGroupId)
				select b.Index).ToList();
			bool result = ((!all) ? elements.Any((AdventureElement element) => blocks.Contains(element.Index)) : elements.All((AdventureElement element) => blocks.Contains(element.Index)));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(232)]
	private static ValueInfo CheckAdventureElementInElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId1 = parameters[0].GetIntValue(evaluator);
			bool all = parameters[1].GetBoolValue(evaluator);
			int elementCoreId2 = parameters[2].GetIntValue(evaluator);
			IEnumerable<AdventureElement> elements1 = adventureRuntime.GetElementsByCoreId(elementCoreId1);
			IEnumerable<AdventureElement> elements2 = adventureRuntime.GetElementsByCoreId(elementCoreId2);
			List<AdventureBlockIndex> blocks = new List<AdventureBlockIndex>();
			foreach (AdventureElement element in elements2)
			{
				if (!blocks.Contains(element.Index))
				{
					blocks.Add(element.Index);
				}
			}
			bool result = ((!all) ? elements1.Any((AdventureElement adventureElement) => blocks.Contains(adventureElement.Index)) : elements1.All((AdventureElement adventureElement) => blocks.Contains(adventureElement.Index)));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(233)]
	private static ValueInfo CheckAdventureTaiwuInElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId);
			bool result = elements.Any((AdventureElement element) => element.Index.Equals(adventureTaiwu.Index));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(234)]
	private static ValueInfo CheckAdventureTaiwuInBlockGroup(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			int blockGroupId = parameters[0].GetIntValue(evaluator);
			List<AdventureBlockIndex> blocks = (from b in adventureRuntime.CoreBlocks
				where b.GroupIds.Contains(blockGroupId)
				select b.Index).ToList();
			bool result = blocks.Contains(adventureTaiwu.Index);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(237)]
	private static bool AdventureCheckUseItem(EventScriptRuntime runtime, UnmanagedVariant<TemplateKey> itemTemplate)
	{
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _) && runtime.ArgBox.Get("ConchShipPresetKey_TemporaryItemKey", out ItemKey itemKey))
		{
			return itemKey.ItemType == itemTemplate.Value.ItemType && itemKey.TemplateId == itemTemplate.Value.TemplateId;
		}
		return false;
	}

	[EventFunction(278)]
	private static ValueInfo AdventureCheckHasItem(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (!runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) || !DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return evaluator.PushEvaluationResult(value: false);
		}
		TemplateKey itemTemplate = parameters[0].GetAnyValue<UnmanagedVariant<TemplateKey>>(evaluator).Value;
		int count = parameters[1].GetIntValue(evaluator);
		GameData.Domains.Adventure.AdventureItem item = adventureRuntime.GetTemporaryItemFirstTaiwu(itemTemplate.ItemType, itemTemplate.TemplateId);
		bool result = item != null && item.ItemKey.IsValid() && item.ItemCount >= count;
		if (runtime.RecordingConditionHints)
		{
			string itemName = ItemTemplateHelper.GetName(itemTemplate.ItemType, itemTemplate.TemplateId);
			runtime.RecordConditionHint(278, result, itemName, count.ToString());
		}
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(245)]
	private static ValueInfo CheckAdventureElementVisibleWithTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string inputTags = parameters[0].GetStringValue(evaluator);
			bool allMeet = parameters[1].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[2].GetIntValue(evaluator);
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IEnumerable<AdventureElement> matchedElements = elements.Where((AdventureElement element) => AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
			bool result = (allMeet ? matchedElements.All((AdventureElement element) => element.Visible) : matchedElements.Any((AdventureElement element) => element.Visible));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(246)]
	private static ValueInfo CheckAdventureElementGroupWithTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string inputTags = parameters[0].GetStringValue(evaluator);
			int groupId = parameters[1].GetIntValue(evaluator);
			bool allMeet = parameters[2].GetBoolValue(evaluator);
			bool containsInvisible = parameters[3].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[4].GetIntValue(evaluator);
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IEnumerable<AdventureElement> matchedElements = from element in elements
				where containsInvisible || element.Visible
				where AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select element;
			bool result = (allMeet ? matchedElements.All((AdventureElement element) => adventureRuntime.GetBlockCore(element.Index).GroupIds.Contains(groupId)) : matchedElements.Any((AdventureElement element) => adventureRuntime.GetBlockCore(element.Index).GroupIds.Contains(groupId)));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(247)]
	private static ValueInfo CheckAdventureElementInElementWithTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string inputTags = parameters[0].GetStringValue(evaluator);
			int elementCoreId = parameters[1].GetIntValue(evaluator);
			bool all = parameters[2].GetBoolValue(evaluator);
			bool containsInvisible = parameters[3].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[4].GetIntValue(evaluator);
			List<AdventureBlockIndex> blocks = (from element in adventureRuntime.GetElementsByCoreId(elementCoreId)
				where containsInvisible || element.Visible
				select element.Index).Distinct().ToList();
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IEnumerable<AdventureElement> matchedElements = from element in elements
				where containsInvisible || element.Visible
				where AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select element;
			bool result = (all ? matchedElements.All((AdventureElement element) => blocks.Contains(element.Index)) : matchedElements.Any((AdventureElement element) => blocks.Contains(element.Index)));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(248)]
	private static ValueInfo CheckAdventureTaiwuInElementWithTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string inputTags = parameters[0].GetStringValue(evaluator);
			bool containsInvisible = parameters[1].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[2].GetIntValue(evaluator);
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			bool result = elements.Where((AdventureElement element) => (containsInvisible || element.Visible) && element.Index.Equals(adventureTaiwu.Index)).Any((AdventureElement element) => AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(265)]
	private static ValueInfo CheckAdventureElementParameter(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			string paramName = parameters[1].GetStringValue(evaluator);
			int operatorId = parameters[2].GetIntValue(evaluator);
			int requiredValue = parameters[3].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			bool result = EventConditions.PerformOperation(operatorId, element.GetParameter(paramName).Current, requiredValue);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(274)]
	private static ValueInfo CheckAdventureElementHaveElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			int elementCoreId = parameters[1].GetIntValue(evaluator);
			AdventureElement elementBy = adventureRuntime.GetElement(elementId);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElements(elementBy.Index);
			bool result = elements.Any((AdventureElement element) => element.CoreId == elementCoreId);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(276)]
	private static ValueInfo CheckAdventureElementCombatPowerIsMax(EventScriptRuntime runtime, ASTNode[] parameters)
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
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElements(elementBy.Index);
			IEnumerable<AdventureElement> result = from adventureElement in elements
				where containsInvisible || adventureElement.Visible
				where adventureElement.Id != elementId && AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(adventureElement.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select adventureElement;
			bool isMax = true;
			if (!DomainManager.Character.TryGetElement_Objects(elementBy.CharacterId, out var characterBy))
			{
				return evaluator.PushEvaluationResult(value: false);
			}
			foreach (AdventureElement element in result)
			{
				if (element.CharacterId < 0 || !DomainManager.Character.TryGetElement_Objects(element.CharacterId, out var character) || character.GetCombatPower() <= characterBy.GetCombatPower())
				{
					continue;
				}
				isMax = false;
				break;
			}
			return evaluator.PushEvaluationResult(isMax);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(286)]
	private static ValueInfo AdventureCheckIsSpecifyElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			int elementCoreId = parameters[1].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			return evaluator.PushEvaluationResult(element.CoreId == elementCoreId);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(296)]
	private static ValueInfo AdventureCheckIsSpecifyTagElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			string inputTags = parameters[1].GetStringValue(evaluator);
			int tagArrayMatchType = parameters[2].GetIntValue(evaluator);
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			bool contains = AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType);
			return evaluator.PushEvaluationResult(contains);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(294)]
	private static ValueInfo AdventureCheckElementSameLocation(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement elementCurrent = adventureRuntime.GetElement(elementId);
			int elementCoreId = parameters[1].GetIntValue(evaluator);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId);
			List<AdventureBlockIndex> blocks = new List<AdventureBlockIndex>();
			foreach (AdventureElement element in elements)
			{
				if (element.Id != elementId && !blocks.Contains(element.Index))
				{
					blocks.Add(element.Index);
				}
			}
			bool result = blocks.Contains(elementCurrent.Index);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(598)]
	private static ValueInfo AdventureCheckTwoElementSameLocation(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId1 = parameters[0].GetIntValue(evaluator);
			AdventureElement element1 = adventureRuntime.GetElement(elementId1);
			int elementId2 = parameters[1].GetIntValue(evaluator);
			AdventureElement element2 = adventureRuntime.GetElement(elementId2);
			bool result = element1.Index.Equals(element2.Index);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(295)]
	private static ValueInfo AdventureCheckElementSameLocationWithTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement elementCurrent = adventureRuntime.GetElement(elementId);
			string inputTags = parameters[1].GetStringValue(evaluator);
			bool containsInvisible = parameters[2].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[3].GetIntValue(evaluator);
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			IEnumerable<AdventureElement> allElementWithTag = from element in elements
				where containsInvisible || element.Visible
				where AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select element;
			bool result = (from element in allElementWithTag
				where element.Id != elementId
				select element.Index).Distinct().Contains(elementCurrent.Index);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(290)]
	private static ValueInfo AdventureCompareCombatPowerWithElementAtSameBlock(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement elementBy = adventureRuntime.GetElement(elementId);
			int elementCoreId = parameters[1].GetIntValue(evaluator);
			int operatorId = parameters[2].GetIntValue(evaluator);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElements(elementBy.Index);
			IEnumerable<AdventureElement> results = elements.Where((AdventureElement element) => element.Id != elementId && element.CoreId == elementCoreId);
			if (!DomainManager.Character.TryGetElement_Objects(elementBy.CharacterId, out var characterBy))
			{
				return evaluator.PushEvaluationResult(value: false);
			}
			int maxPower = GetMaxCombatPower(results);
			bool result = EventConditions.PerformOperation(operatorId, characterBy.GetCombatPower(), maxPower);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(292)]
	private static ValueInfo AdventureCompareCombatPowerWithElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement elementBy = adventureRuntime.GetElement(elementId);
			int elementCoreId = parameters[1].GetIntValue(evaluator);
			int operatorId = parameters[2].GetIntValue(evaluator);
			IEnumerable<AdventureElement> results = adventureRuntime.GetElementsByCoreId(elementCoreId);
			if (!DomainManager.Character.TryGetElement_Objects(elementBy.CharacterId, out var characterBy))
			{
				return evaluator.PushEvaluationResult(value: false);
			}
			int maxPower = GetMaxCombatPower(results);
			bool result = EventConditions.PerformOperation(operatorId, characterBy.GetCombatPower(), maxPower);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(291)]
	private static ValueInfo AdventureCompareCombatPowerWithElementTagAtSameBlock(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement elementBy = adventureRuntime.GetElement(elementId);
			string inputTags = parameters[1].GetStringValue(evaluator);
			int operatorId = parameters[2].GetIntValue(evaluator);
			bool containsInvisible = parameters[3].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[4].GetIntValue(evaluator);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElements(elementBy.Index);
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IEnumerable<AdventureElement> results = from element in elements
				where containsInvisible || element.Visible
				where element.Id != elementId && AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select element;
			if (!DomainManager.Character.TryGetElement_Objects(elementBy.CharacterId, out var characterBy))
			{
				return evaluator.PushEvaluationResult(value: false);
			}
			int maxPower = GetMaxCombatPower(results);
			bool result = EventConditions.PerformOperation(operatorId, characterBy.GetCombatPower(), maxPower);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(293)]
	private static ValueInfo AdventureCompareCombatPowerWithElementTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement elementBy = adventureRuntime.GetElement(elementId);
			string inputTags = parameters[1].GetStringValue(evaluator);
			int operatorId = parameters[2].GetIntValue(evaluator);
			bool containsInvisible = parameters[3].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[4].GetIntValue(evaluator);
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IEnumerable<AdventureElement> results = from element in elements
				where containsInvisible || element.Visible
				where element.Id != elementId && AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select element;
			if (!DomainManager.Character.TryGetElement_Objects(elementBy.CharacterId, out var characterBy))
			{
				return evaluator.PushEvaluationResult(value: false);
			}
			int maxPower = GetMaxCombatPower(results);
			bool result = EventConditions.PerformOperation(operatorId, characterBy.GetCombatPower(), maxPower);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	private static int GetMaxCombatPower(IEnumerable<AdventureElement> elements)
	{
		int maxPower = 0;
		foreach (AdventureElement element in elements)
		{
			if (element.CharacterId >= 0 && DomainManager.Character.TryGetElement_Objects(element.CharacterId, out var character))
			{
				int combatPower = character.GetCombatPower();
				if (combatPower > maxPower)
				{
					maxPower = combatPower;
				}
			}
		}
		return maxPower;
	}

	[EventFunction(306)]
	private static ValueInfo AdventureCheckViewType(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int viewType = parameters[0].GetIntValue(evaluator);
			int operatorId = parameters[1].GetIntValue(evaluator);
			int requiredValue = parameters[2].GetIntValue(evaluator);
			bool result = EventConditions.PerformOperation(operatorId, adventureRuntime.GetParameter("view_range_" + viewType).Current, requiredValue);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(378)]
	private static ValueInfo AdventureCheckElementDistanceToTaiwu(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			int operatorId = parameters[1].GetIntValue(evaluator);
			int requiredValue = parameters[2].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			int distance = element.Index.GetManhattanDistance(adventureTaiwu.Index);
			bool result = EventConditions.PerformOperation(operatorId, distance, requiredValue);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(352)]
	private static ValueInfo AdventureCheckViewTypeToElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			int operatorId = parameters[1].GetIntValue(evaluator);
			int viewType = parameters[2].GetIntValue(evaluator);
			AdventureElement elementCenter = adventureRuntime.GetElement(elementId);
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			int distance = elementCenter.Index.GetManhattanDistance(adventureTaiwu.Index);
			bool result = EventConditions.PerformOperation(operatorId, distance, adventureRuntime.GetParameter("view_range_" + viewType).Current);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(307)]
	private static ValueInfo AdventureCheckElementInRange(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			int elementCoreId = parameters[1].GetIntValue(evaluator);
			int range = parameters[2].GetIntValue(evaluator);
			bool containsInvisible = parameters[3].GetBoolValue(evaluator);
			AdventureElement centerElement = adventureRuntime.GetElement(elementId);
			bool result = (from blockIndex in adventureRuntime.GetIndexes()
				where centerElement.Index.GetManhattanDistance(blockIndex) <= range
				select blockIndex).SelectMany((AdventureBlockIndex blockIndex) => adventureRuntime.GetElements(blockIndex)).Any((AdventureElement element) => (containsInvisible || element.Visible) && element.CoreId == elementCoreId && element.Id != elementId);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(308)]
	private static ValueInfo AdventureCheckElementInRangeWithTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			string inputTags = parameters[1].GetStringValue(evaluator);
			int range = parameters[2].GetIntValue(evaluator);
			bool containsInvisible = parameters[3].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[4].GetIntValue(evaluator);
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			AdventureElement centerElement = adventureRuntime.GetElement(elementId);
			bool result = (from blockIndex in adventureRuntime.GetIndexes()
				where centerElement.Index.GetManhattanDistance(blockIndex) <= range
				select blockIndex).SelectMany((AdventureBlockIndex blockIndex) => adventureRuntime.GetElements(blockIndex)).Any((AdventureElement element) => (containsInvisible || element.Visible) && element.Id != elementId && AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(337)]
	private static ValueInfo CheckAdventureElementInProgress(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			bool inProgress = adventureRuntime.InActionElement(element);
			return evaluator.PushEvaluationResult(inProgress);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(349)]
	private static ValueInfo CheckAdventureElementParameterInProgress(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			string actionKey = parameters[1].GetStringValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			int remainTime;
			AdventureActionData data = adventureRuntime.QueryElementActionData(element, out remainTime);
			bool inProgress = data != null && data.Key == actionKey;
			return evaluator.PushEvaluationResult(inProgress);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(346)]
	private static ValueInfo CheckAdventureElementInTaiwuBigBlockWithTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string inputTags = parameters[0].GetStringValue(evaluator);
			bool needAll = parameters[1].GetBoolValue(evaluator);
			bool containsInvisible = parameters[2].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[3].GetIntValue(evaluator);
			AdventureBlockIndex currentIndex = DomainManager.Adventure.GetAdventureTaiwu().Index;
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IReadOnlyList<AdventureElement> allElements = adventureRuntime.GetAllElements();
			IEnumerable<AdventureElement> matchedElements = from element in allElements
				where containsInvisible || element.Visible
				where AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select element;
			bool result = (needAll ? matchedElements.All((AdventureElement e) => e.Index.X == currentIndex.X && e.Index.Y == currentIndex.Y) : matchedElements.Any((AdventureElement e) => e.Index.X == currentIndex.X && e.Index.Y == currentIndex.Y));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(347)]
	private static ValueInfo CheckAdventureElementInBigBlockWithTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			string inputTags = parameters[1].GetStringValue(evaluator);
			bool needAll = parameters[2].GetBoolValue(evaluator);
			bool containsInvisible = parameters[3].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[4].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IReadOnlyList<AdventureElement> allElements = adventureRuntime.GetAllElements();
			IEnumerable<AdventureElement> matchedElements = from e in allElements
				where containsInvisible || element.Visible
				where AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(e.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select e;
			bool result = (needAll ? matchedElements.All((AdventureElement e) => e.Index.X == element.Index.X && e.Index.Y == element.Index.Y) : matchedElements.Any((AdventureElement e) => e.Index.X == element.Index.X && e.Index.Y == element.Index.Y));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(358)]
	private static ValueInfo AdventureCheckElementDistanceToGroupBlock(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			int blockGroupId = parameters[1].GetIntValue(evaluator);
			int operatorId = parameters[2].GetIntValue(evaluator);
			int requiredValue = parameters[3].GetIntValue(evaluator);
			bool allMeet = parameters[4].GetBoolValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			List<AdventureBlockIndex> blocks = (from b in adventureRuntime.CoreBlocks
				where b.GroupIds.Contains(blockGroupId)
				select b.Index).ToList();
			bool result = false;
			result = ((!allMeet) ? blocks.Any((AdventureBlockIndex e) => EventConditions.PerformOperation(operatorId, e.GetManhattanDistance(element.Index), requiredValue)) : blocks.All((AdventureBlockIndex e) => EventConditions.PerformOperation(operatorId, e.GetManhattanDistance(element.Index), requiredValue)));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(361)]
	private static ValueInfo AdventureCheckElementAtResetTarget(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			return evaluator.PushEvaluationResult(element.ResetTarget.Equals(element.Index));
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(387)]
	private static ValueInfo AdventureCheckElementDistanceToResetTarget(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			int operatorId = parameters[1].GetIntValue(evaluator);
			int requiredValue = parameters[2].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			int distance = element.Index.GetManhattanDistance(element.ResetTarget);
			bool result = EventConditions.PerformOperation(operatorId, distance, requiredValue);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(381)]
	private static ValueInfo CheckAdventureParameterInProgress(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string actionKey = parameters[0].GetStringValue(evaluator);
			int remainTime;
			AdventureActionData data = adventureRuntime.QueryTaiwuActionData(out remainTime);
			return evaluator.PushEvaluationResult(data != null && data.Key == actionKey);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(382)]
	private static ValueInfo CheckAdventureInProgress(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			return evaluator.PushEvaluationResult(adventureRuntime.InActionTaiwu());
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(392)]
	private static ValueInfo CheckAdventureElementInBlockGroupBigBlockWithTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string inputTags = parameters[0].GetStringValue(evaluator);
			int groupId = parameters[1].GetIntValue(evaluator);
			bool allMeet = parameters[2].GetBoolValue(evaluator);
			bool containsInvisible = parameters[3].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[4].GetIntValue(evaluator);
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IEnumerable<AdventureElement> matchedElements = from element in elements
				where containsInvisible || element.Visible
				where AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select element;
			List<AdventureBlockData> groupBlocks = adventureRuntime.CoreBlocks.Where((AdventureBlockData b) => b.GroupIds.Contains(groupId)).ToList();
			if (groupBlocks.Count == 0)
			{
				return evaluator.PushEvaluationResult(value: false);
			}
			HashSet<(int X, int Y)> bigBlocks = new HashSet<(int, int)>();
			foreach (AdventureBlockData block in groupBlocks)
			{
				bigBlocks.Add((block.Index.X, block.Index.Y));
			}
			bool result = (allMeet ? matchedElements.All((AdventureElement element) => bigBlocks.Contains((element.Index.X, element.Index.Y))) : matchedElements.Any((AdventureElement element) => bigBlocks.Contains((element.Index.X, element.Index.Y))));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(432)]
	private static ValueInfo AdventureCheckFinishedActionKey(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && runtime.ArgBox.Get("ConchShipPresetKey_FinishedAction", out AdventureAction finishedAction) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			string actionKey = parameters[0].GetStringValue(evaluator);
			bool result = finishedAction.Key.Equals(actionKey);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(448)]
	private static ValueInfo AdventureCheckElementInRangeWithTagForTaiwu(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string inputTags = parameters[0].GetStringValue(evaluator);
			int range = parameters[1].GetIntValue(evaluator);
			bool containsInvisible = parameters[2].GetBoolValue(evaluator);
			int tagArrayMatchType = parameters[3].GetIntValue(evaluator);
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			bool result = (from blockIndex in adventureRuntime.GetIndexes()
				where adventureTaiwu.Index.GetManhattanDistance(blockIndex) <= range
				select blockIndex).SelectMany((AdventureBlockIndex blockIndex) => adventureRuntime.GetElements(blockIndex)).Any((AdventureElement element) => (containsInvisible || element.Visible) && AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(455)]
	private static ValueInfo AdventureCheckElementItem(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			TemplateKey itemTemplate = parameters[1].GetAnyValue<UnmanagedVariant<TemplateKey>>(evaluator).Value;
			return evaluator.PushEvaluationResult((adventureRuntime.GetTemporaryItemFirst(elementId, itemTemplate.ItemType, itemTemplate.TemplateId)?.ItemKey ?? ItemKey.Invalid).IsValid());
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(465)]
	private static ValueInfo AdventureTaiwuAtBlockByElementId(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			bool result = adventureTaiwu.Index.X == element.Index.X && adventureTaiwu.Index.Y == element.Index.Y;
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(466)]
	private static ValueInfo AdventureTaiwuAtBlockByElementCoreId(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			bool containsInvisible = parameters[1].GetBoolValue(evaluator);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId);
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			bool result = elements.Where((AdventureElement e) => containsInvisible || e.Visible).Any((AdventureElement e) => adventureTaiwu.Index.X == e.Index.X && adventureTaiwu.Index.Y == e.Index.Y);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(467)]
	private static ValueInfo AdventureTaiwuAtBlockByElementTags(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string inputTags = parameters[0].GetStringValue(evaluator);
			int tagArrayMatchType = parameters[1].GetIntValue(evaluator);
			bool containsInvisible = parameters[2].GetBoolValue(evaluator);
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IEnumerable<AdventureElement> matchedElements = from element in elements
				where containsInvisible || element.Visible
				where AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select element;
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			bool result = matchedElements.Any((AdventureElement e) => adventureTaiwu.Index.X == e.Index.X && adventureTaiwu.Index.Y == e.Index.Y);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(468)]
	private static ValueInfo AdventureTaiwuDistanceToElementById(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			int operatorId = parameters[1].GetIntValue(evaluator);
			int requiredValue = parameters[2].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			int distance = adventureTaiwu.Index.GetManhattanDistance(element.Index);
			bool result = EventConditions.PerformOperation(operatorId, distance, requiredValue);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(469)]
	private static ValueInfo AdventureTaiwuDistanceToElementByCoreId(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			int operatorId = parameters[1].GetIntValue(evaluator);
			int requiredValue = parameters[2].GetIntValue(evaluator);
			bool containsInvisible = parameters[3].GetBoolValue(evaluator);
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId);
			bool result = elements.Where((AdventureElement e) => containsInvisible || e.Visible).Any((AdventureElement e) => EventConditions.PerformOperation(operatorId, e.Index.GetManhattanDistance(adventureTaiwu.Index), requiredValue));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(470)]
	private static ValueInfo AdventureTaiwuDistanceToElementByTags(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			string inputTags = parameters[0].GetStringValue(evaluator);
			int tagArrayMatchType = parameters[1].GetIntValue(evaluator);
			int operatorId = parameters[2].GetIntValue(evaluator);
			int requiredValue = parameters[3].GetIntValue(evaluator);
			bool containsInvisible = parameters[4].GetBoolValue(evaluator);
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IEnumerable<AdventureElement> matchedElements = from element in elements
				where containsInvisible || element.Visible
				where AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select element;
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			bool result = matchedElements.Where((AdventureElement e) => containsInvisible || e.Visible).Any((AdventureElement e) => EventConditions.PerformOperation(operatorId, e.Index.GetManhattanDistance(adventureTaiwu.Index), requiredValue));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(499)]
	private static ValueInfo AdventureCheckElementBindCharacter(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			AdventureElementData elementData = AdventureDomain.Core.GetAdventureElementData(elementCoreId);
			bool result = elementData.CharacterId >= 0;
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(501)]
	private static ValueInfo AdventureCheckTaiwuAtBlock(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var _))
		{
			AdventureBlockIndex blockIndex = parameters[0].GetAnyValue<AdventureBlockIndexForSerialize>(evaluator);
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			bool result = adventureTaiwu.Index.Equals(blockIndex);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(507)]
	private static ValueInfo AdventureCheckElementAtBlockById(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureBlockIndex blockIndex = parameters[1].GetAnyValue<AdventureBlockIndexForSerialize>(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			bool result = element.Index.Equals(blockIndex);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(508)]
	private static ValueInfo AdventureCheckElementAtBlockByCoreId(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			AdventureBlockIndex blockIndex = parameters[1].GetAnyValue<AdventureBlockIndexForSerialize>(evaluator);
			bool anyMatch = parameters[2].GetBoolValue(evaluator);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId);
			bool result = false;
			result = ((!anyMatch) ? elements.All((AdventureElement e) => e.Index.Equals(blockIndex)) : elements.Any((AdventureElement e) => e.Index.Equals(blockIndex)));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(509)]
	private static ValueInfo AdventureCheckElementAtBlockByTag(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureBlockIndex blockIndex = parameters[0].GetAnyValue<AdventureBlockIndexForSerialize>(evaluator);
			string inputTags = parameters[1].GetStringValue(evaluator);
			int tagArrayMatchType = parameters[2].GetIntValue(evaluator);
			bool containsInvisible = parameters[3].GetBoolValue(evaluator);
			bool anyMatch = parameters[4].GetBoolValue(evaluator);
			List<string> tags = AdventureRemakeFunctions.ParseInputTags(inputTags);
			IReadOnlyList<AdventureElement> elements = adventureRuntime.GetAllElements();
			IEnumerable<AdventureElement> matchedElements = from element in elements
				where containsInvisible || element.Visible
				where AdventureRemakeFunctions.CheckAdventureElementTagsMatch(AdventureDomain.Core.GetAdventureElementData(element.CoreId).Tags.ToList(), tags, tagArrayMatchType)
				select element;
			bool result = false;
			result = ((!anyMatch) ? matchedElements.All((AdventureElement e) => e.Index.Equals(blockIndex)) : matchedElements.Any((AdventureElement e) => e.Index.Equals(blockIndex)));
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(561)]
	private static ValueInfo AdventureElementAnyFollowTarget(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventure))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventure.GetElement(elementId);
			return evaluator.PushEvaluationResult(element.GetFollowTarget(adventure).HasValue);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(592)]
	private static ValueInfo AdventureElementArrivedTarget(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementId = parameters[0].GetIntValue(evaluator);
			AdventureElement element = adventureRuntime.GetElement(elementId);
			AdventureBlockIndex? target = element.GetFollowTarget(adventureRuntime);
			bool result = target.HasValue && target.Equals(element.Index);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(671)]
	private static ValueInfo AdventureCheckBlockHaveElement(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && runtime.ArgBox.Get("ConchShipPresetKey_BlockIndex", out AdventureBlockIndexForSerialize blockIndex) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int elementCoreId = parameters[0].GetIntValue(evaluator);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElements(blockIndex);
			bool result = false;
			foreach (AdventureElement element in elements)
			{
				if (element.CoreId == elementCoreId)
				{
					result = true;
					break;
				}
			}
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(885)]
	private static ValueInfo ActiveAdventureOrMajorEventInTaiwuBlock(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
		bool result = DomainManager.Adventure.QueryAnyActivatedInLocation(location.AreaId, location.BlockId);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(890)]
	private static ValueInfo AdventureIsActive(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			bool result = adventureRuntime.StatusType.IsActive();
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(511)]
	private static ValueInfo CheckAdventureElementDirectionalPassable(EventScriptRuntime runtime, ASTNode[] parameters)
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
			return evaluator.PushEvaluationResult(adventureRuntime.IsPassable(nextBlockIndex));
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(519)]
	private static ValueInfo CheckAdventureElementParametricDirectionalPassable(EventScriptRuntime runtime, ASTNode[] parameters)
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
			return evaluator.PushEvaluationResult(adventureRuntime.IsPassable(nextBlockIndex));
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(521)]
	private static ValueInfo CheckAdventureTaiwuDirectionalPassable(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureTaiwu adventureTaiwu = DomainManager.Adventure.GetAdventureTaiwu();
			int xOffset = parameters[0].GetIntValue(evaluator);
			int yOffset = parameters[1].GetIntValue(evaluator);
			AdventureBlockIndex nextBlockIndex = new AdventureBlockIndex(adventureTaiwu.Index.Gx + xOffset, adventureTaiwu.Index.Gy + yOffset);
			return evaluator.PushEvaluationResult(adventureRuntime.IsPassable(nextBlockIndex));
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(522)]
	private static ValueInfo CheckAdventureTaiwuDirectionalElementCount(EventScriptRuntime runtime, ASTNode[] parameters)
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
			int operatorId = parameters[3].GetIntValue(evaluator);
			int requiredValue = parameters[4].GetIntValue(evaluator);
			bool containsInvisible = parameters[5].GetBoolValue(evaluator);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId);
			int elementNum = elements.Where((AdventureElement element) => containsInvisible || element.Visible).Count((AdventureElement element) => element.Index.Equals(nextBlockIndex));
			bool result = EventConditions.PerformOperation(operatorId, elementNum, requiredValue);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(553)]
	private static ValueInfo CheckItemGradeByOperator(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		ItemKey itemKey = parameters[0].GetAnyValue<ItemKey>(evaluator);
		sbyte grade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		bool result = EventConditions.PerformOperation(operatorId, grade, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(555)]
	private static ValueInfo CharacterCheckNeiliTypePercent(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int fiveElementsType = parameters[1].GetIntValue(evaluator);
		int operatorId = parameters[2].GetIntValue(evaluator);
		int requiredValue = parameters[3].GetIntValue(evaluator);
		bool result = EventConditions.PerformOperation(operatorId, character.GetNeiliProportionOfFiveElements()[fiveElementsType], requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(619)]
	private static ValueInfo CheckCharacterCarrierGrade(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		sbyte grade = -1;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		if (character != null)
		{
			ItemKey itemKey = character.GetEquipment()[11];
			if (itemKey.IsValid())
			{
				grade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
			}
		}
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		bool result = EventConditions.PerformOperation(operatorId, grade, requiredValue);
		return evaluator.PushEvaluationResult(result);
	}

	[EventFunction(639)]
	private static ValueInfo CheckAdventureBlcokIsInCloud(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			AdventureBlockIndexForSerialize blockIndex = parameters[0].GetAnyValue<AdventureBlockIndexForSerialize>(evaluator);
			AdventureBlock adventureBlock = adventureRuntime.GetBlock(blockIndex);
			bool result = adventureBlock.InCloud;
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(644)]
	private static ValueInfo CheckAdventureElementDirectionalElementCount(EventScriptRuntime runtime, ASTNode[] parameters)
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
			int elementCoreId = parameters[3].GetIntValue(evaluator);
			int operatorId = parameters[4].GetIntValue(evaluator);
			int requiredValue = parameters[5].GetIntValue(evaluator);
			bool containsInvisible = parameters[6].GetBoolValue(evaluator);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId);
			int elementNum = elements.Where((AdventureElement tempElement) => containsInvisible || tempElement.Visible).Count((AdventureElement tempElement) => tempElement.Index.Equals(nextBlockIndex));
			bool result = EventConditions.PerformOperation(operatorId, elementNum, requiredValue);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(664)]
	private static ValueInfo CheckAdventureBlcokElementCount(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		int adventureId = -1;
		if (runtime.ArgBox.Get("ConchShipPresetKey_AdventureId", ref adventureId) && DomainManager.Adventure.TryGetElement_Adventures(adventureId, out var adventureRuntime))
		{
			int x = parameters[0].GetIntValue(evaluator);
			int y = parameters[1].GetIntValue(evaluator);
			int i = parameters[2].GetIntValue(evaluator);
			AdventureBlockIndex nextBlockIndex = new AdventureBlockIndex(x, y, i);
			int elementCoreId = parameters[3].GetIntValue(evaluator);
			int operatorId = parameters[4].GetIntValue(evaluator);
			int requiredValue = parameters[5].GetIntValue(evaluator);
			bool containsInvisible = parameters[6].GetBoolValue(evaluator);
			IEnumerable<AdventureElement> elements = adventureRuntime.GetElementsByCoreId(elementCoreId);
			int elementNum = elements.Where((AdventureElement element) => containsInvisible || element.Visible).Count((AdventureElement element) => element.Index.Equals(nextBlockIndex));
			bool result = EventConditions.PerformOperation(operatorId, elementNum, requiredValue);
			return evaluator.PushEvaluationResult(result);
		}
		return evaluator.PushEvaluationResult(value: false);
	}

	[EventFunction(683)]
	private static ValueInfo CheckCharacterAttraction(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		Evaluator evaluator = runtime.Evaluator;
		GameData.Domains.Character.Character character = parameters[0].GetAnyValue<GameData.Domains.Character.Character>(evaluator);
		int operatorId = parameters[1].GetIntValue(evaluator);
		int requiredValue = parameters[2].GetIntValue(evaluator);
		bool result = EventConditions.PerformOperation(operatorId, character.GetAttraction(), requiredValue);
		return evaluator.PushEvaluationResult(result);
	}
}
