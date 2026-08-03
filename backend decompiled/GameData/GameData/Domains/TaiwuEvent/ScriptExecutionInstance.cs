using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.Map;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.Display;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent;

public class ScriptExecutionInstance
{
	public enum ScopeType
	{
		If,
		Loop
	}

	private struct Scope(int beginIndex, int contentIndent, ScopeType type)
	{
		public readonly int BeginIndex = beginIndex;

		public readonly int ContentIndent = contentIndent;

		public readonly ScopeType Type = type;
	}

	private struct Branch(int beginIndex, int indent, bool isEntered)
	{
		public readonly int BeginIndex = beginIndex;

		public readonly int Indent = indent;

		public readonly bool IsEntered = isEntered;
	}

	private IEnumerator _enumerator;

	private EventScript _currentScript;

	private EventArgBox _argBox;

	private int _executingIndex;

	private int _nextIndex;

	private readonly Stack<Scope> _scopeStack;

	private readonly Stack<Branch> _executedBranchStack;

	private readonly Dictionary<int, int> _loopCounts;

	private EventScriptDebugInfo _debugInfo;

	private bool _logExecution;

	private const int MaxLoopCount = 65535;

	public string NextEvent;

	private EventSelectCharacterData _selectCharacterData;

	private readonly List<short> _selectItemSubTypes = new List<short>();

	private readonly List<sbyte> _selectItemGrades = new List<sbyte>();

	private readonly List<(sbyte itemType, short itemTemplateId)> _selectItemTemplateIds = new List<(sbyte, short)>();

	private readonly List<(sbyte itemType, short itemTemplateId)> _excludeItemTemplateIds = new List<(sbyte, short)>();

	private readonly List<(sbyte itemType, short itemTemplateId)> _selectItemGroups = new List<(sbyte, short)>();

	private readonly List<sbyte> _selectItemResourceType = new List<sbyte>();

	private readonly List<sbyte> _excludeItemResourceType = new List<sbyte>();

	private Inventory _toShowGetItems;

	private int[] _toShowGetResources;

	private List<int> _toShowGetCharacters;

	private bool _obtainPopupEnabled = true;

	private EObtainType _eObtainTypeGetCharacters;

	private const string ToEmptyEvent = "6cab5c73-ed29-4051-990e-e4f47e18763d";

	public int ExecutingIndex => _executingIndex;

	public bool IsScriptMonitored => _debugInfo != null;

	public EventArgBox ArgBox => _argBox;

	public bool IsRunning => _enumerator != null;

	public EventScriptId ScriptId => _currentScript.Id;

	public string EventGuid => (_currentScript != null && EventScriptId.IsEventType(_currentScript.Id.Type)) ? _currentScript.Id.EventScriptRef.Guid.ToString() : string.Empty;

	private bool HasToShowGetItems => _toShowGetItems != null && _toShowGetItems.Items.Count > 0;

	private bool HasToShowGetResources => _toShowGetResources != null && _toShowGetResources.Sum() > 0;

	private bool HasToShowGetCharacters => _toShowGetCharacters != null && _toShowGetCharacters.Sum() > 0;

	public ScriptExecutionInstance()
	{
		_scopeStack = new Stack<Scope>();
		_executedBranchStack = new Stack<Branch>();
		_loopCounts = new Dictionary<int, int>();
		NextEvent = null;
	}

	public void Update(EventScriptRuntime runtime)
	{
		if (_enumerator == null)
		{
			return;
		}
		try
		{
			if (!_enumerator.MoveNext())
			{
				_enumerator = null;
			}
		}
		catch (Exception value)
		{
			_enumerator = null;
			string errorMessage = $"Exception occurred when executing script. \n{value}";
			runtime.Debugger?.LogError(errorMessage);
			AdaptableLog.TagWarning("ExecuteScript", errorMessage, appendWarningMessage: true);
		}
	}

	public void ExecuteScript(EventScriptRuntime runtime, EventScript script, EventArgBox argBox, EventScriptDebugInfo debugInfo = null)
	{
		_currentScript = script;
		_argBox = argBox;
		_scopeStack.Clear();
		_executedBranchStack.Clear();
		_loopCounts.Clear();
		NextEvent = null;
		_obtainPopupEnabled = true;
		_debugInfo = debugInfo;
		_logExecution = runtime.LogScriptExecution(script.Id);
		if (_logExecution)
		{
			runtime.Debugger.LogScriptInfo(script.Id);
		}
		if (debugInfo != null && debugInfo.PauseOnStart)
		{
			runtime.IsPaused = true;
		}
		_enumerator = Execute(runtime);
		Update(runtime);
	}

	private IEnumerator Execute(EventScriptRuntime runtime)
	{
		EvaluationStack evaluationStack = runtime.Evaluator.EvaluationStack;
		_executingIndex = 0;
		for (_nextIndex = 1; _currentScript != null && _executingIndex < _currentScript.Instructions.Length; _executingIndex = _nextIndex, _nextIndex++)
		{
			EventInstruction instruction = _currentScript.Instructions[_executingIndex];
			if (_scopeStack.TryPeek(out var scope))
			{
				if (scope.ContentIndent > instruction.Indent)
				{
					if (scope.Type == ScopeType.Loop)
					{
						GotoLoopHead();
						continue;
					}
					_scopeStack.Pop();
				}
				else if (scope.ContentIndent < instruction.Indent)
				{
					throw new TaiwuEventScriptException("Unrecognized indention", _currentScript.Id, _executingIndex, instruction, null);
				}
			}
			if (!runtime.MovingNext)
			{
				while (runtime.IsPaused && !runtime.MovingNext)
				{
					yield return null;
				}
				if (_debugInfo != null && _debugInfo.BreakPoints.TryGetValue(_executingIndex, out var breakPointCondition))
				{
					bool pause = breakPointCondition?.Invoke() ?? true;
					while (pause && !runtime.MovingNext)
					{
						yield return null;
					}
				}
				breakPointCondition = null;
			}
			else
			{
				runtime.MovingNext = false;
			}
			try
			{
				if (_logExecution)
				{
					runtime.Debugger.LogInstructionWithArgs(_executingIndex, instruction);
				}
				ValueInfo valueInfo = instruction.Instruction.Execute(runtime);
				Branch branch;
				while (_executedBranchStack.TryPeek(out branch) && branch.BeginIndex != _executingIndex && branch.Indent >= instruction.Indent)
				{
					_executedBranchStack.Pop();
				}
				if (valueInfo.ValueType != EValueType.Void)
				{
					if (_logExecution)
					{
						runtime.Debugger.LogInstructionReturn(instruction.AssignToVar, valueInfo);
					}
					_argBox.SetValueFromStack(evaluationStack, instruction.AssignToVar, valueInfo.ValueType);
				}
				else if (!string.IsNullOrEmpty(instruction.AssignToVar))
				{
					throw new Exception("Failed to get return value and assign to \"" + instruction.AssignToVar + "\"");
				}
			}
			catch (Exception innerException)
			{
				throw new TaiwuEventScriptException("Failed to execute instruction", _currentScript.Id, _executingIndex, instruction, innerException);
			}
		}
		try
		{
			UpdateShowGetItems();
			UpdateShowGetCharacters();
			UpdateShowGetLegacies();
			UpdateShowGetFeatures();
		}
		catch (Exception ex)
		{
			Exception e = ex;
			throw new TaiwuEventScriptException("Failed to display get items", ScriptId, _executingIndex, string.Empty, e);
		}
	}

	public void GotoLabel(string label)
	{
		_nextIndex = _currentScript.Labels[label];
	}

	public void ExecuteBranch(int indent, bool executed)
	{
		if (_executedBranchStack.TryPeek(out var branch) && branch.Indent == indent)
		{
			_executedBranchStack.Pop();
		}
		_executedBranchStack.Push(new Branch(_executingIndex, indent, executed));
	}

	public bool IsBranchEntered(int indent)
	{
		Branch executedBranch;
		return _executedBranchStack.TryPeek(out executedBranch) && executedBranch.Indent == indent && executedBranch.IsEntered;
	}

	public void ExitBranch(int beginIndex)
	{
		Branch branch;
		while (_executedBranchStack.TryPeek(out branch) && branch.BeginIndex >= beginIndex)
		{
			_executedBranchStack.Pop();
		}
	}

	public void BreakLoop()
	{
		Scope scope;
		while (_scopeStack.TryPop(out scope))
		{
			if (scope.Type != ScopeType.Loop)
			{
				continue;
			}
			ExitScope(scope.ContentIndent);
			_loopCounts.Remove(scope.BeginIndex);
			Branch branch;
			while (_executedBranchStack.TryPeek(out branch) && branch.BeginIndex >= scope.BeginIndex)
			{
				_executedBranchStack.Pop();
			}
			return;
		}
		throw new Exception("Currently not in loop");
	}

	public void CheckAndAdvanceIteration(int maxCount)
	{
		_loopCounts.TryGetValue(_executingIndex, out var currIteration);
		if (currIteration >= maxCount)
		{
			BreakLoop();
		}
		else
		{
			_loopCounts[_executingIndex] = currIteration + 1;
		}
	}

	public void CheckAndAdvanceIteration(bool condition)
	{
		if (!condition)
		{
			BreakLoop();
		}
		_loopCounts.TryGetValue(_executingIndex, out var currIteration);
		if (currIteration >= 65535)
		{
			throw new Exception($"Maximum loop count ({65535}) exceeded.");
		}
		_loopCounts[_executingIndex] = currIteration + 1;
	}

	public void GotoLoopHead()
	{
		Scope scope;
		while (_scopeStack.TryPop(out scope))
		{
			if (scope.Type != ScopeType.Loop)
			{
				continue;
			}
			_nextIndex = scope.BeginIndex;
			Branch branch;
			while (_executedBranchStack.TryPeek(out branch) && branch.BeginIndex >= _nextIndex)
			{
				_executedBranchStack.Pop();
			}
			return;
		}
		throw new Exception("Currently not in loop");
	}

	public int GetCurrentIndentAmount()
	{
		Scope scope;
		return _scopeStack.TryPeek(out scope) ? scope.ContentIndent : 0;
	}

	public void EnterScope(ScopeType scopeType)
	{
		int indent = GetCurrentIndentAmount();
		_scopeStack.Push(new Scope(_executingIndex, indent + 1, scopeType));
	}

	public void ExitScope(int indentAmount)
	{
		if (indentAmount <= 0)
		{
			throw new ArgumentException($"Unable to exit scope with contentIndent {indentAmount}.");
		}
		while (_nextIndex < _currentScript.Instructions.Length)
		{
			EventInstruction nextInstruction = _currentScript.Instructions[_nextIndex];
			if (nextInstruction.Indent < indentAmount)
			{
				break;
			}
			_nextIndex++;
		}
		Scope scope;
		while (_scopeStack.TryPeek(out scope) && scope.ContentIndent >= indentAmount)
		{
			if (scope.Type == ScopeType.Loop)
			{
				_loopCounts.Remove(scope.BeginIndex);
			}
			_scopeStack.Pop();
		}
	}

	public void ExitScript()
	{
		_nextIndex = _currentScript.Instructions.Length;
	}

	public int StartSelectFilteredCharacters(sbyte selectRange, short matcherId, string saveKey)
	{
		List<CharacterDisplayData> selectableCharList = InitSelectCharacterData(saveKey);
		CharacterMatcherItem matcher = ((matcherId >= 0) ? CharacterMatcher.Instance[matcherId] : null);
		foreach (int charId in GetCharactersInEventSelectRange(selectRange))
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && (matcher == null || matcher.Match(character)))
			{
				CharacterDisplayData displayData = DomainManager.Character.GetCharacterDisplayData(charId);
				selectableCharList.Add(displayData);
			}
		}
		ArgBox.Set("SelectCharacterData", _selectCharacterData);
		return selectableCharList.Count;
	}

	public static bool AnySelectableFilteredCharacter(sbyte selectRange, short matcherId)
	{
		CharacterMatcherItem matcher = ((matcherId >= 0) ? CharacterMatcher.Instance[matcherId] : null);
		foreach (int charId in GetCharactersInEventSelectRange(selectRange))
		{
			if (!DomainManager.Character.TryGetElement_Objects(charId, out var character) || (matcher != null && !matcher.Match(character)))
			{
				continue;
			}
			return true;
		}
		return false;
	}

	private List<CharacterDisplayData> InitSelectCharacterData(string saveKey)
	{
		if (_selectCharacterData == null)
		{
			_selectCharacterData = new EventSelectCharacterData();
			_selectCharacterData.FilterList = new List<CharacterSelectFilter>();
			CharacterSelectFilter filter = new CharacterSelectFilter
			{
				FilterTemplateId = -1,
				SelectKey = saveKey,
				AvailableCharactersDisplayDataList = new List<CharacterDisplayData>()
			};
			_selectCharacterData.FilterList.Add(filter);
			return filter.AvailableCharactersDisplayDataList;
		}
		CharacterSelectFilter filter2 = _selectCharacterData.FilterList[0];
		filter2.SelectKey = saveKey;
		filter2.AvailableCharactersDisplayDataList.Clear();
		return filter2.AvailableCharactersDisplayDataList;
	}

	private static IEnumerable<int> GetCharactersInEventSelectRange(sbyte selectRange)
	{
		if (EventSelectCharacterRange.SelectInGroup(selectRange))
		{
			foreach (int item in DomainManager.Taiwu.GetGroupCharIds().GetCollection())
			{
				yield return item;
			}
		}
		if (EventSelectCharacterRange.SelectInSpecialGroup(selectRange))
		{
			foreach (int item2 in DomainManager.Taiwu.GetTaiwuSpecialGroup())
			{
				yield return item2;
			}
		}
		if (!EventSelectCharacterRange.SelectInInBlock(selectRange))
		{
			yield break;
		}
		Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!location.IsValid())
		{
			yield break;
		}
		MapBlockData block = DomainManager.Map.GetBlock(location);
		if (block.CharacterSet == null)
		{
			yield break;
		}
		foreach (int item3 in block.CharacterSet)
		{
			yield return item3;
		}
	}

	public void ClearSelectItemRegisterData()
	{
		_selectItemSubTypes?.Clear();
		_selectItemGrades?.Clear();
		_selectItemTemplateIds?.Clear();
		_excludeItemTemplateIds?.Clear();
		_selectItemGroups?.Clear();
		_selectItemResourceType?.Clear();
		_excludeItemResourceType?.Clear();
	}

	public void RegisterToSelectItemSubTypes(short itemSubType)
	{
		_selectItemSubTypes.Add(itemSubType);
	}

	public void RegisterToSelectItemGrades(sbyte grade)
	{
		_selectItemGrades.Add(grade);
	}

	public void RegisterToSelectItemGroups(sbyte itemType, short itemTemplateId)
	{
		_selectItemGroups.Add((itemType, itemTemplateId));
	}

	public void RegisterToSelectItemTemplateIds(sbyte itemType, short itemTemplateId)
	{
		_selectItemTemplateIds.Add((itemType, itemTemplateId));
	}

	public void RegisterToExcludeItemTemplateIds(sbyte itemType, short itemTemplateId)
	{
		_excludeItemTemplateIds.Add((itemType, itemTemplateId));
	}

	public void RegisterToSelectItemResourceType(sbyte resourceType)
	{
		_selectItemResourceType.Add(resourceType);
	}

	public void RegisterToExcludeItemResourceType(sbyte resourceType)
	{
		_excludeItemResourceType.Add(resourceType);
	}

	public void FilterItemForCharacter(GameData.Domains.Character.Character character, string selectItemNameKey, bool includeTransferable = false)
	{
		List<Predicate<ItemKey>> predicates = GetRegisterPredicates();
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.FilterItemForCharacterByType(character.GetId(), selectItemNameKey, ArgBox, -1, -1, includeTransferable, predicates, -1);
		ClearSelectItemRegisterData();
	}

	public TemplateKey GetRandomTemplateKey(DataContext context)
	{
		ItemList itemList = CreateItemListByRegister(context, createItem: false);
		ItemKey item = itemList.GetRandom(context.Random);
		ClearSelectItemRegisterData();
		return new TemplateKey(item.ItemType, item.TemplateId);
	}

	private List<Predicate<ItemKey>> GetRegisterPredicates()
	{
		List<Predicate<ItemKey>> predicates = new List<Predicate<ItemKey>>();
		predicates.Add(delegate(ItemKey itemKey)
		{
			if (_excludeItemTemplateIds.Contains((itemKey.ItemType, itemKey.TemplateId)))
			{
				return false;
			}
			sbyte resourceType = ItemTemplateHelper.GetResourceType(itemKey.ItemType, itemKey.TemplateId);
			if (_excludeItemResourceType.Contains(resourceType))
			{
				return false;
			}
			if (_selectItemTemplateIds.Contains((itemKey.ItemType, itemKey.TemplateId)))
			{
				return true;
			}
			if (_selectItemSubTypes.Count == 0 && _selectItemGrades.Count == 0 && _selectItemGroups.Count == 0 && _selectItemResourceType.Count == 0 && _selectItemTemplateIds.Count > 0 && !_selectItemTemplateIds.Contains((itemKey.ItemType, itemKey.TemplateId)))
			{
				return false;
			}
			short itemSubType = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
			sbyte grade = ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId);
			short groupId = ItemTemplateHelper.GetGroupId(itemKey.ItemType, itemKey.TemplateId);
			bool flag = false;
			foreach (var (b, templateId) in _selectItemGroups)
			{
				if (b == itemKey.ItemType)
				{
					short groupId2 = ItemTemplateHelper.GetGroupId(b, templateId);
					if (groupId2 == groupId)
					{
						flag = true;
						break;
					}
				}
			}
			return (_selectItemSubTypes.Contains(itemSubType) || _selectItemSubTypes.Count == 0) && (_selectItemGrades.Contains(grade) || _selectItemGrades.Count == 0) && (flag || _selectItemGroups.Count == 0) && (_selectItemResourceType.Contains(resourceType) || _selectItemResourceType.Count == 0);
		});
		return predicates;
	}

	public ItemList CreateItemListByRegister(DataContext context, bool createItem)
	{
		List<Predicate<ItemKey>> predicates = GetRegisterPredicates();
		ItemList result = new ItemList();
		foreach (AccessoryItem configItem in (IEnumerable<AccessoryItem>)Config.Accessory.Instance)
		{
			ItemKey itemKey = new ItemKey
			{
				ItemType = configItem.ItemType,
				TemplateId = configItem.TemplateId
			};
			AddItem(itemKey);
		}
		foreach (ArmorItem configItem2 in (IEnumerable<ArmorItem>)Config.Armor.Instance)
		{
			ItemKey itemKey2 = new ItemKey
			{
				ItemType = configItem2.ItemType,
				TemplateId = configItem2.TemplateId
			};
			AddItem(itemKey2);
		}
		foreach (CarrierItem configItem3 in (IEnumerable<CarrierItem>)Config.Carrier.Instance)
		{
			ItemKey itemKey3 = new ItemKey
			{
				ItemType = configItem3.ItemType,
				TemplateId = configItem3.TemplateId
			};
			AddItem(itemKey3);
		}
		foreach (ClothingItem configItem4 in (IEnumerable<ClothingItem>)Config.Clothing.Instance)
		{
			ItemKey itemKey4 = new ItemKey
			{
				ItemType = configItem4.ItemType,
				TemplateId = configItem4.TemplateId
			};
			AddItem(itemKey4);
		}
		foreach (CraftToolItem configItem5 in (IEnumerable<CraftToolItem>)Config.CraftTool.Instance)
		{
			ItemKey itemKey5 = new ItemKey
			{
				ItemType = configItem5.ItemType,
				TemplateId = configItem5.TemplateId
			};
			AddItem(itemKey5);
		}
		foreach (FoodItem configItem6 in (IEnumerable<FoodItem>)Config.Food.Instance)
		{
			ItemKey itemKey6 = new ItemKey
			{
				ItemType = configItem6.ItemType,
				TemplateId = configItem6.TemplateId
			};
			AddItem(itemKey6);
		}
		foreach (MaterialItem configItem7 in (IEnumerable<MaterialItem>)Config.Material.Instance)
		{
			ItemKey itemKey7 = new ItemKey
			{
				ItemType = configItem7.ItemType,
				TemplateId = configItem7.TemplateId
			};
			AddItem(itemKey7);
		}
		foreach (MedicineItem configItem8 in (IEnumerable<MedicineItem>)Config.Medicine.Instance)
		{
			ItemKey itemKey8 = new ItemKey
			{
				ItemType = configItem8.ItemType,
				TemplateId = configItem8.TemplateId
			};
			AddItem(itemKey8);
		}
		foreach (MiscItem configItem9 in (IEnumerable<MiscItem>)Config.Misc.Instance)
		{
			ItemKey itemKey9 = new ItemKey
			{
				ItemType = configItem9.ItemType,
				TemplateId = configItem9.TemplateId
			};
			AddItem(itemKey9);
		}
		foreach (SkillBookItem configItem10 in (IEnumerable<SkillBookItem>)Config.SkillBook.Instance)
		{
			ItemKey itemKey10 = new ItemKey
			{
				ItemType = configItem10.ItemType,
				TemplateId = configItem10.TemplateId
			};
			AddItem(itemKey10);
		}
		foreach (TeaWineItem configItem11 in (IEnumerable<TeaWineItem>)Config.TeaWine.Instance)
		{
			ItemKey itemKey11 = new ItemKey
			{
				ItemType = configItem11.ItemType,
				TemplateId = configItem11.TemplateId
			};
			AddItem(itemKey11);
		}
		foreach (WeaponItem configItem12 in (IEnumerable<WeaponItem>)Config.Weapon.Instance)
		{
			ItemKey itemKey12 = new ItemKey
			{
				ItemType = configItem12.ItemType,
				TemplateId = configItem12.TemplateId
			};
			AddItem(itemKey12);
		}
		return result;
		void AddItem(ItemKey obj)
		{
			if (predicates?.Any((Predicate<ItemKey> predicate) => predicate(obj)) ?? false)
			{
				ItemKey item = ((!createItem) ? new ItemKey
				{
					ItemType = obj.ItemType,
					TemplateId = obj.TemplateId
				} : DomainManager.Item.CreateItem(context, obj.ItemType, obj.TemplateId));
				result.Add(item);
			}
		}
	}

	public void SetObtainPopupEnabled(bool enabled)
	{
		_obtainPopupEnabled = enabled;
	}

	public void RegisterToShowGetItem(ItemKey itemKey, int amount)
	{
		if (_obtainPopupEnabled && itemKey.IsValid())
		{
			if (_toShowGetItems == null)
			{
				_toShowGetItems = new Inventory();
			}
			if (_toShowGetItems.Items.TryGetValue(itemKey, out var oriAmount))
			{
				_toShowGetItems.Items[itemKey] = oriAmount + amount;
			}
			else
			{
				_toShowGetItems.Items.Add(itemKey, amount);
			}
		}
	}

	public void UnregisterToShowGetItem(ItemKey itemKey, int amount)
	{
		if (itemKey.IsValid() && _toShowGetItems != null && _toShowGetItems.Items != null && _toShowGetItems.Items.TryGetValue(itemKey, out var oriAmount))
		{
			if (oriAmount <= amount)
			{
				_toShowGetItems.Items.Remove(itemKey);
			}
			else
			{
				_toShowGetItems.Items[itemKey] = oriAmount - amount;
			}
		}
	}

	public void RegisterToShowGetResource(sbyte resourceType, int amount)
	{
		if (_obtainPopupEnabled)
		{
			if (_toShowGetResources == null)
			{
				_toShowGetResources = new int[8];
			}
			_toShowGetResources[resourceType] += amount;
		}
	}

	private void UpdateShowGetItems()
	{
		if (!HasToShowGetItems && !HasToShowGetResources)
		{
			return;
		}
		NextEventToListenedEvent("GetItemShowed");
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		List<ItemDisplayData> itemDisplayDataList = DomainManager.Item.GetItemDisplayDataListOptionalFromInventory(_toShowGetItems, taiwuCharId, 1);
		if (_toShowGetResources != null)
		{
			if (itemDisplayDataList == null)
			{
				itemDisplayDataList = new List<ItemDisplayData>();
			}
			for (sbyte resourceType = 0; resourceType < 8; resourceType++)
			{
				int amount = _toShowGetResources[resourceType];
				if (amount > 0)
				{
					itemDisplayDataList.Add(new ItemDisplayData(12, resourceType)
					{
						Amount = amount
					});
				}
			}
		}
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Item, itemDisplayDataList, arg2: false);
		_toShowGetItems?.Items?.Clear();
		_toShowGetResources = null;
	}

	public void RegisterToShowGetCharacter(int characterId, EObtainType eObtainType)
	{
		if (_obtainPopupEnabled)
		{
			if (_toShowGetCharacters == null)
			{
				_toShowGetCharacters = new List<int>();
			}
			_toShowGetCharacters.Add(characterId);
			_eObtainTypeGetCharacters = eObtainType;
		}
	}

	private void UpdateShowGetCharacters()
	{
		if (HasToShowGetCharacters)
		{
			NextEventToListenedEvent("GetItemShowed");
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Character, _toShowGetCharacters, (sbyte)_eObtainTypeGetCharacters);
			_toShowGetCharacters.Clear();
		}
	}

	private void UpdateShowGetLegacies()
	{
		IReadOnlyList<short> legacies = DomainManager.TaiwuEvent.GetNeedToShowLegacies();
		if (legacies.Count != 0)
		{
			NextEventToListenedEvent("GetItemShowed");
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Legacy, legacies, (sbyte)1);
			DomainManager.TaiwuEvent.ClearNeedToShowLegacies();
		}
	}

	private void UpdateShowGetFeatures()
	{
		IReadOnlyList<short> features = DomainManager.TaiwuEvent.GetNeedToShowFeatures();
		if (features.Count != 0)
		{
			NextEventToListenedEvent("GetItemShowed");
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Feature, features, (sbyte)13);
			DomainManager.TaiwuEvent.ClearNeedToShowFeatures();
		}
	}

	private void NextEventToListenedEvent(string actionKey)
	{
		if (string.IsNullOrEmpty(NextEvent))
		{
			if (DomainManager.World.GetAdvancingMonthState() == 0)
			{
				return;
			}
			NextEvent = "6cab5c73-ed29-4051-990e-e4f47e18763d";
		}
		DomainManager.TaiwuEvent.SetListenerWithActionName(NextEvent, ArgBox, actionKey);
		DomainManager.TaiwuEvent.CheckTaiwuStatusImmediately();
		NextEvent = string.Empty;
	}
}
