using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Adventure;
using GameData.Adventure.Exceptions;
using GameData.Combat.Math;
using GameData.Common.Algorithm;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using Google.Protobuf.Collections;
using Redzen.Random;

namespace GameData.Domains.Adventure;

[SerializableGameData(IsExtensible = true)]
public class AdventureRuntime : IAdventureRuntime, IAdventureParameterProvider, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort MapLocation = 1;

		public const ushort CoreId = 2;

		public const ushort Blocks = 3;

		public const ushort Elements = 4;

		public const ushort ParameterValues = 5;

		public const ushort InvokedOnceAutoEvents = 6;

		public const ushort InvokedOnceElementEvents = 7;

		public const ushort TemporaryItems = 8;

		public const ushort CalledCharacters = 9;

		public const ushort TemporaryCharacters = 10;

		public const ushort InternalStatusType = 11;

		public const ushort AutoDeleteDate = 12;

		public const ushort DisplayRandomSeed = 13;

		public const ushort Actions = 14;

		public const ushort NextElementId = 15;

		public const ushort BlockGroupIndex = 16;

		public const ushort Version = 17;

		public const ushort Count = 18;

		public static readonly string[] FieldId2FieldName = new string[18]
		{
			"Id", "MapLocation", "CoreId", "Blocks", "Elements", "ParameterValues", "InvokedOnceAutoEvents", "InvokedOnceElementEvents", "TemporaryItems", "CalledCharacters",
			"TemporaryCharacters", "InternalStatusType", "AutoDeleteDate", "DisplayRandomSeed", "Actions", "NextElementId", "BlockGroupIndex", "Version"
		};
	}

	private const int BinarySearchThreshold = 64;

	[SerializableGameDataField(FieldIndex = 0)]
	public int Id;

	[SerializableGameDataField(FieldIndex = 1)]
	public Location MapLocation;

	[SerializableGameDataField(FieldIndex = 2)]
	public int CoreId;

	[SerializableGameDataField(FieldIndex = 3)]
	private List<AdventureBlock> _blocks;

	[SerializableGameDataField(FieldIndex = 4)]
	private List<AdventureElement> _elements;

	[SerializableGameDataField(FieldIndex = 5)]
	private Dictionary<AdventureParameterKey, AdventureParameterValue> _parameterValues;

	[SerializableGameDataField(FieldIndex = 6)]
	private List<int> _invokedOnceAutoEvents;

	[SerializableGameDataField(FieldIndex = 7)]
	private Dictionary<int, IntList> _invokedOnceElementEvents;

	[SerializableGameDataField(FieldIndex = 8)]
	private List<AdventureItem> _temporaryItems;

	[SerializableGameDataField(FieldIndex = 9)]
	private List<int> _calledCharacters;

	[SerializableGameDataField(FieldIndex = 10)]
	private List<int> _temporaryCharacters;

	[SerializableGameDataField(FieldIndex = 11)]
	private byte _internalStatusType;

	[SerializableGameDataField(FieldIndex = 12)]
	private int _autoDeleteDate = -1;

	[SerializableGameDataField(FieldIndex = 13)]
	public int DisplayRandomSeed;

	[SerializableGameDataField(FieldIndex = 14)]
	private List<AdventureAction> _actions;

	[SerializableGameDataField(FieldIndex = 15)]
	private int _nextElementId;

	[SerializableGameDataField(FieldIndex = 16)]
	private int _blockGroupIndex;

	[SerializableGameDataField(FieldIndex = 17)]
	public AdventureVersion Version;

	private List<int> _justRemovedElementIds;

	private AdventureBlockBucket _blockCacheBucket;

	private AStarAlgorithmSimple<AdventureBlockIndex> _aStarAlgorithm;

	private static readonly Dictionary<CharacterFilterKey, List<AdventureElement>> FilterElements = new Dictionary<CharacterFilterKey, List<AdventureElement>>();

	public EAdventureStatusType StatusType => (EAdventureStatusType)_internalStatusType;

	public int Size => Core.Size;

	public IReadOnlyList<AdventureItem> TemporaryItems
	{
		get
		{
			IReadOnlyList<AdventureItem> temporaryItems = _temporaryItems;
			return temporaryItems ?? Array.Empty<AdventureItem>();
		}
	}

	public int RemainMonths => CalcRemainMonths(ExternalDataBridge.Context.CurrDate);

	public IReadOnlyList<AdventureBlockData> CoreBlocks => Core.Groups[_blockGroupIndex].Blocks;

	public AdventureData Core => ExternalDataBridge.Context.AdventureCore.GetAdventureData(CoreId);

	int IAdventureRuntime.Id => Id;

	int IAdventureRuntime.CoreId => CoreId;

	Location IAdventureRuntime.MapLocation => MapLocation;

	bool IAdventureRuntime.Satisfied => AllSatisfied();

	IReadOnlyList<AdventureParameterData> IAdventureParameterProvider.Parameters => Core.Parameters;

	public bool AnyEntry => _blocks.Any((AdventureBlock x) => x.ContainStatus(EAdventureBlockStatusType.In));

	public IReadOnlyList<int> TemporaryCharacters
	{
		get
		{
			if (_temporaryCharacters == null)
			{
				return Array.Empty<int>();
			}
			return _temporaryCharacters;
		}
	}

	public bool ShouldStay
	{
		get
		{
			if ((int)StatusType >= 1)
			{
				return CalcRemainMonths(ExternalDataBridge.Context.CurrDate) != 0;
			}
			return true;
		}
	}

	public bool InAdventure(AdventureBlockIndex index)
	{
		return MathUtils.Abs(index.X) + MathUtils.Abs(index.Y) <= Size;
	}

	public bool IsPassable(AdventureBlockIndex index)
	{
		if (!InAdventure(index))
		{
			return false;
		}
		if (_blockCacheBucket != null)
		{
			return _blockCacheBucket.GetPassable(index);
		}
		foreach (AdventureBlock block in _blocks)
		{
			if (block.Index.Equals(index) && !block.ContainStatus(EAdventureBlockStatusType.Passable))
			{
				return false;
			}
		}
		return true;
	}

	public bool IsExitPoint(AdventureBlockIndex index)
	{
		foreach (AdventureBlock block in _blocks)
		{
			if (block.Index.Equals(index) && block.ContainStatus(EAdventureBlockStatusType.Out))
			{
				return true;
			}
		}
		return false;
	}

	public int CalcRemainMonths(int currDate)
	{
		if (_autoDeleteDate < 0)
		{
			return -1;
		}
		return MathUtils.Max(_autoDeleteDate - currDate, 0);
	}

	public bool IsInvokedOnceAutoEvent(int eventId)
	{
		return _invokedOnceAutoEvents?.Contains(eventId) ?? false;
	}

	public bool IsInvokedOnceElementEvent(int elementId, int eventId)
	{
		return _invokedOnceElementEvents?.GetOrDefault(elementId).Items?.Contains(eventId) == true;
	}

	public bool OnceAutoEventInvoked(int eventId)
	{
		if (_invokedOnceAutoEvents == null)
		{
			_invokedOnceAutoEvents = new List<int>();
		}
		if (_invokedOnceAutoEvents.Contains(eventId))
		{
			return false;
		}
		_invokedOnceAutoEvents.Add(eventId);
		return true;
	}

	public bool OnceElementEventInvoked(int elementId, int eventId)
	{
		if (_invokedOnceElementEvents == null)
		{
			_invokedOnceElementEvents = new Dictionary<int, IntList>();
		}
		if (_invokedOnceElementEvents.TryGetValue(elementId, out var intList))
		{
			List<int> items = intList.Items;
			if (items != null && items.Count > 0)
			{
				goto IL_004b;
			}
		}
		IntList intList2 = (_invokedOnceElementEvents[elementId] = IntList.Create());
		intList = intList2;
		goto IL_004b;
		IL_004b:
		List<int> elementEvents = intList.Items;
		if (elementEvents.Contains(eventId))
		{
			return false;
		}
		elementEvents.Add(eventId);
		return true;
	}

	public IEnumerable<AdventureBlockIndex> GetIndexes()
	{
		return AdventureBlockIndex.GetIndexes(Size);
	}

	public IEnumerable<AdventureBlockIndex> GetNeighborPassableIndexes(AdventureBlockIndex index, int distance)
	{
		foreach (AdventureBlockIndex neighbor in GetIndexes())
		{
			if (!(neighbor == index) && neighbor.GetManhattanDistance(index) <= distance && GetBlock(neighbor).ContainStatus(EAdventureBlockStatusType.Passable))
			{
				yield return neighbor;
			}
		}
	}

	public IReadOnlyList<AdventureElement> GetAllElements()
	{
		if (_elements == null)
		{
			return Array.Empty<AdventureElement>();
		}
		return _elements;
	}

	public bool IsElementAlive(int elementId)
	{
		return GetElement(elementId) != null;
	}

	public bool IsElementAlive(AdventureElement element)
	{
		return IsElementAlive(element.Id);
	}

	public AdventureElement GetElement(int elementId)
	{
		List<AdventureElement> elements = _elements;
		if (elements == null || elements.Count <= 0)
		{
			return null;
		}
		if (_elements.Count > 64)
		{
			return GetElementByBinarySearch(elementId);
		}
		foreach (AdventureElement element in _elements)
		{
			if (element.Id == elementId)
			{
				return element;
			}
		}
		return null;
	}

	private AdventureElement GetElementByBinarySearch(int elementId)
	{
		int minIndex = 0;
		int maxIndex = _elements.Count - 1;
		while (minIndex <= maxIndex)
		{
			int midIndex = minIndex + (maxIndex - minIndex >> 1);
			int midId = _elements[midIndex].Id;
			if (midId == elementId)
			{
				return _elements[midIndex];
			}
			if (midId < elementId)
			{
				minIndex = midIndex + 1;
			}
			else
			{
				maxIndex = midIndex - 1;
			}
		}
		return null;
	}

	public AdventureElement GetElement(AdventureBlockIndex index)
	{
		List<AdventureElement> elements = _elements;
		if (elements == null || elements.Count <= 0)
		{
			return null;
		}
		foreach (AdventureElement element in _elements)
		{
			if (element.Index == index)
			{
				return element;
			}
		}
		return null;
	}

	public IEnumerable<AdventureElement> GetElements(AdventureBlockIndex index)
	{
		List<AdventureElement> elements = _elements;
		if (elements == null || elements.Count <= 0)
		{
			yield break;
		}
		foreach (AdventureElement element in _elements)
		{
			if (element.Index == index)
			{
				yield return element;
			}
		}
	}

	public IEnumerable<AdventureElement> GetElementsByCoreId(int elementCoreId)
	{
		List<AdventureElement> elements = _elements;
		if (elements == null || elements.Count <= 0)
		{
			yield break;
		}
		foreach (AdventureElement element in _elements)
		{
			if (element.CoreId == elementCoreId)
			{
				yield return element;
			}
		}
	}

	public IEnumerable<AdventureElement> GetElementsByTag(string tag)
	{
		List<AdventureElement> elements = _elements;
		if (elements == null || elements.Count <= 0)
		{
			yield break;
		}
		foreach (AdventureElement element in _elements)
		{
			if (element.Core.Tags.Contains(tag))
			{
				yield return element;
			}
		}
	}

	public IEnumerable<AdventureElement> GetElementByAnyTags(IReadOnlyList<string> tags)
	{
		if (tags == null || tags.Count <= 0)
		{
			yield break;
		}
		List<AdventureElement> elements = _elements;
		if (elements == null || elements.Count <= 0)
		{
			yield break;
		}
		foreach (AdventureElement element in _elements)
		{
			if (tags.Any(element.Core.Tags.Contains))
			{
				yield return element;
			}
		}
	}

	public IEnumerable<AdventureElement> GetElementByAllTags(IReadOnlyList<string> tags)
	{
		if (tags == null || tags.Count <= 0)
		{
			yield break;
		}
		List<AdventureElement> elements = _elements;
		if (elements == null || elements.Count <= 0)
		{
			yield break;
		}
		foreach (AdventureElement element in _elements)
		{
			if (tags.All(element.Core.Tags.Contains))
			{
				yield return element;
			}
		}
	}

	public AdventureElement GetElementByCharacterKey(string characterKey)
	{
		if (!string.IsNullOrEmpty(characterKey))
		{
			List<AdventureElement> elements = _elements;
			if (elements != null && elements.Count > 0)
			{
				foreach (AdventureElement element in _elements)
				{
					if (element.Core.CharacterKey == characterKey)
					{
						return element;
					}
				}
				return null;
			}
		}
		return null;
	}

	public IReadOnlyList<AdventureBlock> GetAllBlocks()
	{
		return _blocks;
	}

	public AdventureBlock GetBlock(AdventureBlockIndex index)
	{
		foreach (AdventureBlock block in _blocks)
		{
			if (block.Index == index)
			{
				return block;
			}
		}
		return null;
	}

	public AdventureBlockData GetBlockCore(AdventureBlockIndex index)
	{
		if (_blockCacheBucket != null)
		{
			return _blockCacheBucket.GetBlockCore(index);
		}
		foreach (AdventureBlockData block in CoreBlocks)
		{
			if (block.Index == index)
			{
				return block;
			}
		}
		return null;
	}

	public IReadOnlyList<int> GetBlockGroupIds(AdventureBlockIndex index)
	{
		IReadOnlyList<int> readOnlyList = GetBlockCore(index)?.GroupIds;
		return readOnlyList ?? Array.Empty<int>();
	}

	public IEnumerable<AdventureBlock> GetBlocksByGroupId(int groupId)
	{
		foreach (AdventureBlock block in _blocks)
		{
			if (GetBlockGroupIds(block.Index).Contains(groupId))
			{
				yield return block;
			}
		}
	}

	public IEnumerable<AdventureBlock> GetBlocksByAnyGroupIds(IReadOnlyList<int> groupIds)
	{
		if (groupIds == null || groupIds.Count <= 0)
		{
			yield break;
		}
		foreach (AdventureBlock block in _blocks)
		{
			if (groupIds.Any(((IEnumerable<int>)GetBlockGroupIds(block.Index)).Contains<int>))
			{
				yield return block;
			}
		}
	}

	public IEnumerable<AdventureBlock> GetBlocksByAllGroupIds(IReadOnlyList<int> groupIds)
	{
		if (groupIds == null || groupIds.Count <= 0)
		{
			yield break;
		}
		foreach (AdventureBlock block in _blocks)
		{
			if (groupIds.All(((IEnumerable<int>)GetBlockGroupIds(block.Index)).Contains<int>))
			{
				yield return block;
			}
		}
	}

	public IReadOnlyList<AdventureBlockIndex> FindShortestPath(AdventureBlockIndex from, AdventureBlockIndex to)
	{
		if (_aStarAlgorithm == null)
		{
			_aStarAlgorithm = new AStarAlgorithmSimple<AdventureBlockIndex>(GetValidNeighbors, GetMoveCost);
		}
		return _aStarAlgorithm.FindShortestPath(from, to);
	}

	public IEnumerable<AdventureBlockIndex> GetValidNeighbors(AdventureBlockIndex index)
	{
		foreach (EAdventureDirection direction in AdventureBlockIndex.Directions)
		{
			AdventureBlockIndex neighbor = index.Move(direction);
			if (IsPassable(neighbor))
			{
				yield return neighbor;
			}
		}
	}

	public int GetMoveCost(AdventureBlockIndex pos)
	{
		int timeCost = GetBlockCore(pos).TimeCost;
		if (timeCost <= 0)
		{
			return 0;
		}
		CValuePercentBonus costPercent = 0;
		foreach (AdventureElement element in GetElements(pos))
		{
			costPercent += (CValuePercentBonus)element.Core.TimeCost;
		}
		return MathUtils.Max(timeCost * costPercent, 1);
	}

	public AdventureParameterValue? GetParameterOrNull(AdventureParameterKey key)
	{
		return _parameterValues?.GetOrNull(key);
	}

	public void SetParameter(AdventureParameterKey key, AdventureParameterValue value)
	{
		if (_parameterValues == null)
		{
			_parameterValues = new Dictionary<AdventureParameterKey, AdventureParameterValue>();
		}
		_parameterValues[key] = value;
	}

	public void RemoveParameter(AdventureParameterKey key)
	{
		_parameterValues?.Remove(key);
	}

	public AdventureItem GetTemporaryItemTaiwu(ItemKey itemKey)
	{
		return GetTemporaryItem(0, itemKey);
	}

	public AdventureItem GetTemporaryItem(int ownerId, ItemKey itemKey)
	{
		foreach (AdventureItem item in TemporaryItems)
		{
			if (item.OwnerId == ownerId && item.ItemKey == itemKey)
			{
				return item;
			}
		}
		return null;
	}

	public AdventureItem GetTemporaryItemFirstTaiwu(sbyte itemType, short templateId)
	{
		return GetTemporaryItemFirst(0, itemType, templateId);
	}

	public AdventureItem GetTemporaryItemFirst(int ownerId, sbyte itemType, short templateId)
	{
		foreach (AdventureItem item in TemporaryItems)
		{
			if (item.OwnerId == ownerId && item.ItemKey.TemplateEquals(itemType, templateId))
			{
				return item;
			}
		}
		return null;
	}

	public IEnumerable<AdventureItem> GetTemporaryItemsTaiwu(sbyte itemType, short templateId)
	{
		return GetTemporaryItems(0, itemType, templateId);
	}

	public IEnumerable<AdventureItem> GetTemporaryItems(int ownerId, sbyte itemType, short templateId)
	{
		return from x in GetTemporaryItems(ownerId)
			where x.ItemKey.TemplateEquals(itemType, templateId)
			select x;
	}

	public IEnumerable<AdventureItem> GetTemporaryItemsTaiwu()
	{
		return TemporaryItems.Where(AdventureItem.IsItemOwnedByTaiwu);
	}

	public IEnumerable<AdventureItem> GetTemporaryItems(int ownerId)
	{
		foreach (AdventureItem item in TemporaryItems)
		{
			if (item.OwnerId == ownerId)
			{
				yield return item;
			}
		}
	}

	public override string ToString()
	{
		return $"{Core.Name}({Id})";
	}

	private static int RandomBlockGroupIndex(IRandomSource random, AdventureData data)
	{
		RepeatedField<AdventureGroupData> groups = data.Groups;
		if (groups == null || groups.Count <= 0)
		{
			throw new AdventureCoreGroupEmptyException(data);
		}
		if (random == null)
		{
			return 0;
		}
		List<uint> weights = ObjectPool<List<uint>>.Instance.Get();
		foreach (AdventureGroupData group in data.Groups)
		{
			weights.Add(group.Weight);
		}
		int index = RandomUtils.GetRandomIndex(weights, random);
		ObjectPool<List<uint>>.Instance.Return(weights);
		if (index >= 0)
		{
			return index;
		}
		throw new AdventureCoreGroupNoWeightException(data);
	}

	public AdventureRuntime(int id, Location location, AdventureData data, IRandomSource random = null)
	{
		Id = id;
		MapLocation = location;
		CoreId = data.Id;
		this.InitializeVersion();
		_blocks = new List<AdventureBlock>();
		_parameterValues = new Dictionary<AdventureParameterKey, AdventureParameterValue>();
		this.InitializeParameters();
		List<AdventureBlockIndex> pool = new List<AdventureBlockIndex>(GetIndexes());
		RepeatedField<AdventureGroupData> groups = data.Groups;
		if (groups == null || groups.Count <= 0)
		{
			throw new AdventureCoreGroupEmptyException(data);
		}
		_blockGroupIndex = RandomBlockGroupIndex(random, data);
		_nextElementId = 1;
		_elements = new List<AdventureElement>();
		foreach (AdventureBlockData blockData in CoreBlocks)
		{
			pool.Remove(blockData.Index);
			_blocks.Add(new AdventureBlock(blockData));
			RepeatedField<int> elementCoreIds = blockData.ElementCoreIds;
			if (elementCoreIds == null || elementCoreIds.Count <= 0)
			{
				continue;
			}
			foreach (int elementCoreId in blockData.ElementCoreIds)
			{
				if (TrySelectIndex(random, elementCoreId, blockData.Index, out var elementIndex))
				{
					_elements.Add(new AdventureElement(_nextElementId++, elementCoreId, elementIndex));
				}
			}
		}
		foreach (AdventureBlockIndex index in pool)
		{
			_blocks.Add(new AdventureBlock(index));
		}
	}

	public bool InheritByUpgrade(AdventureRuntime other)
	{
		_parameterValues = ((other._parameterValues != null) ? new Dictionary<AdventureParameterKey, AdventureParameterValue>(other._parameterValues) : new Dictionary<AdventureParameterKey, AdventureParameterValue>());
		this.InitializeParameters();
		this.SetParameter("ConchShipPresetKey_Task_Count", 0);
		List<AdventureElement> elements = _elements;
		if (elements == null || elements.Count <= 0)
		{
			return true;
		}
		Dictionary<string, List<AdventureElement>> presetCharacters = new Dictionary<string, List<AdventureElement>>();
		foreach (AdventureElement element in _elements)
		{
			if (!string.IsNullOrEmpty(element.Core.CharacterKey))
			{
				presetCharacters.GetOrNew(element.Core.CharacterKey).Add(element);
			}
		}
		if (presetCharacters == null || presetCharacters.Count <= 0)
		{
			return true;
		}
		elements = other._elements;
		if (elements == null || elements.Count <= 0)
		{
			return false;
		}
		List<int> bindCharacters = new List<int>();
		foreach (AdventureElement element2 in other._elements)
		{
			string key = element2.Core.CharacterKey;
			if (string.IsNullOrEmpty(key) || element2.CharacterId < 0)
			{
				continue;
			}
			List<AdventureElement> nowElements = presetCharacters.GetOrDefault(key);
			if (nowElements != null && nowElements.Count > 0)
			{
				nowElements[nowElements.Count - 1].BindCharacter(element2.CharacterId);
				bindCharacters.Add(element2.CharacterId);
				nowElements.RemoveAt(nowElements.Count - 1);
				if (nowElements.Count == 0)
				{
					presetCharacters.Remove(key);
				}
			}
		}
		if (presetCharacters.Count > 0)
		{
			return false;
		}
		other._calledCharacters.RemoveAll(bindCharacters.Contains);
		return true;
	}

	private bool TrySelectIndex(IRandomSource random, int elementCoreId, AdventureBlockIndex blockIndex, out AdventureBlockIndex elementIndex)
	{
		elementIndex = blockIndex;
		if (elementCoreId < 1)
		{
			AdaptableLog.Warning($"Failed to generate element by invalid core id {elementCoreId}", appendWarningMessage: true);
			return false;
		}
		AdventureElementData elementCore = ExternalDataBridge.Context.AdventureCore.GetAdventureElementData(elementCoreId);
		if (elementCore == null)
		{
			AdaptableLog.Warning($"Failed to generate element by empty element core {elementCoreId}", appendWarningMessage: true);
			return false;
		}
		elementIndex = elementCore.CreatingType switch
		{
			EAdventureElementCreatingType.Inherit => blockIndex, 
			EAdventureElementCreatingType.RandomInBlock => (random == null) ? blockIndex : blockIndex.SetI(random.Next(9)), 
			EAdventureElementCreatingType.RandomInGroup => (random == null) ? blockIndex : RandomIndexInGroup(random, blockIndex), 
			_ => blockIndex, 
		};
		return true;
	}

	private AdventureBlockIndex RandomIndexInGroup(IRandomSource random, AdventureBlockIndex index)
	{
		IReadOnlyList<int> groupIds = GetBlockGroupIds(index);
		if (groupIds == null || groupIds.Count <= 0)
		{
			return index;
		}
		List<AdventureBlockIndex> pool = ObjectPool<List<AdventureBlockIndex>>.Instance.Get();
		pool.AddRange(from block in CoreBlocks
			where block.GroupIds.Any(((IEnumerable<int>)groupIds).Contains<int>)
			select block.Index);
		if (pool.Count <= 0)
		{
			return index;
		}
		return pool.GetRandom(random);
	}

	public AdventureElement CreateElementAt(IAdventureContextBridge context, int coreId, AdventureBlockIndex index)
	{
		if (!TrySelectIndex(context.Random, coreId, index, out var elementIndex))
		{
			return null;
		}
		AdventureElement newElement = new AdventureElement(_nextElementId, coreId, elementIndex);
		if (!GenerateAndBindCharacterImmediate(context, newElement))
		{
			return null;
		}
		_nextElementId++;
		_elements.Add(newElement);
		return newElement;
	}

	public bool RemoveElement(int elementId)
	{
		List<AdventureElement> elements = _elements;
		if (elements == null || elements.Count <= 0)
		{
			return false;
		}
		bool anyChanged = false;
		for (int i = _elements.Count - 1; i >= 0; i--)
		{
			if (_elements[i].Id == elementId)
			{
				RemoveElementAtIndex(i);
				anyChanged = true;
			}
		}
		return anyChanged;
	}

	private void RemoveElementAtIndex(int elementIndex)
	{
		AdventureElement element = _elements[elementIndex];
		_elements.RemoveAt(elementIndex);
		_invokedOnceElementEvents?.Remove(element.Id);
		if (_justRemovedElementIds == null)
		{
			_justRemovedElementIds = new List<int>();
		}
		_justRemovedElementIds.Add(element.Id);
		if (!string.IsNullOrEmpty(element.Core.CharacterKey))
		{
			this.SetParameter("ConchShipPresetKey_RemoveAfterCallCharacters", true);
		}
	}

	public AdventureBlockIndex PickEntryPoint(IRandomSource random)
	{
		int priority = int.MinValue;
		List<AdventureBlockIndex> pool = new List<AdventureBlockIndex>();
		foreach (AdventureBlock block in _blocks)
		{
			if (block.EntryPriority >= priority && block.ContainStatus(EAdventureBlockStatusType.In))
			{
				if (block.EntryPriority > priority)
				{
					pool.Clear();
				}
				priority = block.EntryPriority;
				pool.Add(block.Index);
			}
		}
		if (pool.Count > 0)
		{
			return pool.GetRandom(random);
		}
		AdaptableLog.Warning("Adventure has no entry point, fallback to center as entry point", appendWarningMessage: true);
		return new AdventureBlockIndex(0, 0, AdventureBlockIndex.CenterI);
	}

	public void SetStatusType(IAdventureContextBridge context, EAdventureStatusType statusType)
	{
		EAdventureStatusType statusType2 = StatusType;
		_internalStatusType = (byte)statusType;
		if (statusType == EAdventureStatusType.Ready)
		{
			SetAutoDeleteDate(Core.StayMonths);
		}
		EAdventureStatusType currStatusType = StatusType;
		if (!statusType2.IsActive() && currStatusType.IsActive())
		{
			context.Execute(Core.ActiveAction, this);
		}
	}

	public void SetAutoDeleteDate(uint stayMonths)
	{
		if (stayMonths == 0)
		{
			_autoDeleteDate = -1;
		}
		else
		{
			_autoDeleteDate = (int)Math.Min(ExternalDataBridge.Context.CurrDate + stayMonths, 2147483647L);
		}
	}

	public bool UpdateStatus(IAdventureDomainBridge bridge)
	{
		if (_blockCacheBucket == null)
		{
			_blockCacheBucket = new AdventureBlockBucket(Size, CoreBlocks);
		}
		bool anyChanged = false;
		foreach (AdventureBlock block in _blocks)
		{
			AdventureBlockData blockData = _blockCacheBucket.GetBlockCore(block.Index);
			if (blockData != null)
			{
				anyChanged = block.UpdateStatus(bridge, Id, blockData) || anyChanged;
				_blockCacheBucket.SetPassable(block.Index, block.ContainStatus(EAdventureBlockStatusType.Passable));
			}
		}
		foreach (AdventureElement allElement in GetAllElements())
		{
			anyChanged = allElement.UpdateStatus(bridge, Id) || anyChanged;
		}
		return anyChanged;
	}

	public void CheckForceRemove()
	{
		List<AdventureElement> elements = _elements;
		if (elements != null && elements.Count > 0 && _elements.Any((AdventureElement element) => element.CharacterId < 0 && !string.IsNullOrEmpty(element.Core.CharacterKey)))
		{
			this.SetParameter("ConchShipPresetKey_RemoveAfterCallCharacters", true);
		}
	}

	private bool AllSatisfied()
	{
		List<AdventureElement> elements = _elements;
		if (elements == null || elements.Count <= 0)
		{
			return true;
		}
		foreach (AdventureElement element in _elements)
		{
			if (element.CharacterId < 0 && element.Core.CharacterData.Type == EAdventureCharacterType.Necessary)
			{
				return false;
			}
		}
		return true;
	}

	public void AddTemporaryItemTaiwu(IAdventureContextBridge context, ItemKey itemKey, int count = 1)
	{
		AddTemporaryItem(context, 0, itemKey, count);
	}

	public void AddTemporaryItem(IAdventureContextBridge context, int ownerId, ItemKey itemKey, int count = 1)
	{
		if (_temporaryItems == null)
		{
			_temporaryItems = new List<AdventureItem>();
		}
		AdventureItem existTemporaryItem = GetTemporaryItem(ownerId, itemKey);
		if (existTemporaryItem == null)
		{
			_temporaryItems.Add(new AdventureItem(itemKey, count, ownerId));
		}
		else
		{
			existTemporaryItem.ChangeCount(count);
		}
		context.OwnedByAdventure(itemKey);
	}

	public void RemoveTemporaryItemTaiwu(IAdventureContextBridge context, ItemKey itemKey)
	{
		RemoveTemporaryItem(context, 0, itemKey);
	}

	public void RemoveTemporaryItem(IAdventureContextBridge context, int ownerId, ItemKey itemKey)
	{
		List<AdventureItem> temporaryItems = _temporaryItems;
		if (temporaryItems == null || temporaryItems.Count <= 0)
		{
			return;
		}
		bool removed = false;
		bool stillOwned = false;
		for (int i = _temporaryItems.Count - 1; i >= 0; i--)
		{
			AdventureItem temporaryItem = _temporaryItems[i];
			if (!(temporaryItem.ItemKey != itemKey))
			{
				if (temporaryItem.OwnerId != ownerId)
				{
					stillOwned = true;
				}
				else
				{
					_temporaryItems.RemoveAt(i);
					removed = true;
				}
			}
		}
		if (removed && !stillOwned)
		{
			context.ReleaseTemporaryItem(itemKey);
		}
	}

	public bool UnbindTemporaryItem(int ownerId, ItemKey itemKey)
	{
		if (!ItemTemplateHelper.IsPureStackable(itemKey) && IsMultiOwned(itemKey))
		{
			return false;
		}
		for (int i = _temporaryItems.Count - 1; i >= 0; i--)
		{
			AdventureItem temporaryItem = _temporaryItems[i];
			if (!(temporaryItem.ItemKey != itemKey) && temporaryItem.OwnerId == ownerId)
			{
				_temporaryItems.RemoveAt(i);
				return true;
			}
		}
		return false;
	}

	private bool IsMultiOwned(ItemKey itemKey)
	{
		List<AdventureItem> temporaryItems = _temporaryItems;
		if (temporaryItems == null || temporaryItems.Count <= 0)
		{
			return false;
		}
		int ownerCount = 0;
		foreach (AdventureItem temporaryItem in _temporaryItems)
		{
			if (temporaryItem.ItemKey == itemKey)
			{
				ownerCount++;
			}
		}
		return ownerCount > 1;
	}

	public bool IsTemporaryCharacter(int charId)
	{
		return _temporaryCharacters?.Contains(charId) ?? false;
	}

	public bool IsCalledCharacter(int charId)
	{
		return _calledCharacters?.Contains(charId) ?? false;
	}

	public void CollectCharacters(ICollection<int> characters)
	{
		List<int> calledCharacters = _calledCharacters;
		if (calledCharacters == null || calledCharacters.Count <= 0)
		{
			return;
		}
		foreach (int charId in _calledCharacters)
		{
			characters.Add(charId);
		}
	}

	public bool DynamicBindPrecheck(AdventureElement element, int charId)
	{
		if (StatusType == EAdventureStatusType.Releasing)
		{
			return false;
		}
		if (_calledCharacters != null && _calledCharacters.Contains(charId))
		{
			return false;
		}
		if (_temporaryCharacters != null && _temporaryCharacters.Contains(charId))
		{
			return false;
		}
		return element.CharacterId < 0;
	}

	public AdventureElement DynamicBindPreCheckKey(string characterKey, int charId)
	{
		List<AdventureElement> elements = _elements;
		if (elements == null || elements.Count <= 0 || string.IsNullOrEmpty(characterKey))
		{
			return null;
		}
		AdventureElement keyElement = _elements.FirstOrDefault((AdventureElement x) => x.CharacterId < 0 && x.Core.CharacterKey == characterKey);
		if (keyElement == null)
		{
			return null;
		}
		if (!DynamicBindPrecheck(keyElement, charId))
		{
			return null;
		}
		return keyElement;
	}

	public void DynamicBindCalledCharacter(AdventureElement element, int charId)
	{
		if (!DynamicBindPrecheck(element, charId))
		{
			AdaptableLog.Warning($"Bind called failed by {element.CoreId} {element.CharacterId} {charId}", appendWarningMessage: true);
			return;
		}
		element.BindCharacter(charId);
		if (_calledCharacters == null)
		{
			_calledCharacters = new List<int>();
		}
		_calledCharacters.Add(charId);
	}

	public void DynamicBindTemporaryCharacter(AdventureElement element, int charId)
	{
		if (!DynamicBindPrecheck(element, charId))
		{
			AdaptableLog.Warning($"Bind temporary failed by {element.CoreId} {element.CharacterId} {charId}", appendWarningMessage: true);
			return;
		}
		element.BindCharacter(charId);
		if (_temporaryCharacters == null)
		{
			_temporaryCharacters = new List<int>();
		}
		_temporaryCharacters.Add(charId);
	}

	public EAdventureUnbindType DynamicUnbindCharacterAndRemoveElement(AdventureElement element)
	{
		if (StatusType == EAdventureStatusType.Releasing || element.CharacterId < 0 || !RemoveElement(element.Id))
		{
			return EAdventureUnbindType.None;
		}
		List<int> calledCharacters = _calledCharacters;
		if (calledCharacters != null && calledCharacters.Contains(element.CharacterId))
		{
			_calledCharacters.Remove(element.CharacterId);
			return EAdventureUnbindType.Called;
		}
		List<int> temporaryCharacters = _temporaryCharacters;
		if (temporaryCharacters != null && temporaryCharacters.Contains(element.CharacterId))
		{
			_temporaryCharacters.Remove(element.CharacterId);
			return EAdventureUnbindType.Temporary;
		}
		return EAdventureUnbindType.None;
	}

	public EAdventureUnbindType DynamicUnbindCharacterAndRemoveElement(int charId)
	{
		if (StatusType != EAdventureStatusType.Releasing)
		{
			List<AdventureElement> elements = _elements;
			if (elements != null && elements.Count > 0)
			{
				EAdventureUnbindType result = EAdventureUnbindType.None;
				List<int> calledCharacters = _calledCharacters;
				if (calledCharacters != null && calledCharacters.Remove(charId))
				{
					result = EAdventureUnbindType.Called;
				}
				else
				{
					List<int> temporaryCharacters = _temporaryCharacters;
					if (temporaryCharacters == null || !temporaryCharacters.Remove(charId))
					{
						return result;
					}
					result = EAdventureUnbindType.Temporary;
				}
				for (int i = _elements.Count - 1; i >= 0; i--)
				{
					if (_elements[i].CharacterId == charId)
					{
						RemoveElementAtIndex(i);
					}
				}
				return result;
			}
		}
		return EAdventureUnbindType.None;
	}

	bool IAdventureRuntime.CallCharacters(IAdventureContextBridge context, EAdventureCharacterType type)
	{
		foreach (AdventureElement element in GetAllElements())
		{
			if (element.CharacterId < 0 && element.Core.CharacterId < 0 && element.Core.CharacterData != null)
			{
				AdventureCharacterData data = element.Core.CharacterData;
				if (data.Type == type)
				{
					FilterElements.GetOrNew(data.FilterKey).Add(element);
				}
			}
		}
		bool allSatisfied = true;
		int limit = this.GetParameterOrDefault("ConchShipPresetKey_CallCharacterCountLimit", int.MaxValue).Current;
		foreach (var (filterKey, elements) in FilterElements)
		{
			if (elements.Count != 0)
			{
				int maxCount = Math.Min(elements.Count, limit);
				List<int> calledCharacters = ObjectPool<List<int>>.Instance.Get();
				context.CallCharacters(calledCharacters, filterKey, MapLocation, maxCount);
				if (calledCharacters.Count < elements.Count)
				{
					allSatisfied = false;
				}
				for (int i = 0; i < calledCharacters.Count; i++)
				{
					AdventureElement element2 = elements[i];
					int charId = calledCharacters[i];
					DynamicBindCalledCharacter(element2, charId);
				}
				ObjectPool<List<int>>.Instance.Return(calledCharacters);
			}
		}
		foreach (List<AdventureElement> value in FilterElements.Values)
		{
			value.Clear();
		}
		return allSatisfied;
	}

	public bool GenerateCharacters(IAdventureContextBridge context)
	{
		if ((int)StatusType >= 2)
		{
			return false;
		}
		DisplayRandomSeed = context.Random.NextInt();
		SetStatusType(context, EAdventureStatusType.Entered);
		List<AdventureElement> elements = _elements;
		if (elements == null || elements.Count <= 0)
		{
			return true;
		}
		for (int i = _elements.Count - 1; i >= 0; i--)
		{
			AdventureElement element = _elements[i];
			if (!GenerateAndBindCharacterImmediate(context, element))
			{
				RemoveElementAtIndex(i);
			}
		}
		return true;
	}

	private bool GenerateAndBindCharacterImmediate(IAdventureContextBridge context, AdventureElement element)
	{
		if (element.CharacterId >= 0)
		{
			return true;
		}
		AdventureElementData elementCore = element.Core;
		if (elementCore.CharacterId < 0 && elementCore.CharacterData.Type == EAdventureCharacterType.Invalid)
		{
			return true;
		}
		bool success = true;
		if (elementCore.CharacterId >= 0)
		{
			short templateId = (short)elementCore.CharacterId;
			int charId = context.GenerateTemporaryCharacter(templateId, MapLocation);
			if (charId < 0)
			{
				success = false;
				AdaptableLog.Warning($"Adv element {element.CoreId} bind failed by {templateId}", appendWarningMessage: true);
			}
			else
			{
				DynamicBindTemporaryCharacter(element, charId);
			}
		}
		else if (elementCore.CharacterData.Type == EAdventureCharacterType.NecessaryAutoCreate)
		{
			int charId2 = context.GenerateTemporaryCharacter(elementCore.CharacterData.FilterKey, MapLocation);
			DynamicBindTemporaryCharacter(element, charId2);
		}
		else
		{
			success = false;
		}
		return success;
	}

	public void ReleaseData(IAdventureContextBridge context)
	{
		SetStatusType(context, EAdventureStatusType.Releasing);
		List<int> calledCharacters = _calledCharacters;
		if (calledCharacters != null && calledCharacters.Count > 0)
		{
			context.ReleaseCalledCharacters(_calledCharacters);
		}
		calledCharacters = _temporaryCharacters;
		if (calledCharacters != null && calledCharacters.Count > 0)
		{
			context.ReleaseTemporaryCharacters(_temporaryCharacters);
		}
		List<AdventureItem> temporaryItems = _temporaryItems;
		if (temporaryItems != null && temporaryItems.Count > 0)
		{
			context.ReleaseTemporaryItems(_temporaryItems);
		}
	}

	public bool InActionTaiwu()
	{
		return QueryTaiwuActionId() >= 1;
	}

	public bool InActionElement(AdventureElement element)
	{
		return QueryElementActionId(element) >= 1;
	}

	public int QueryTaiwuActionId()
	{
		return QueryTaiwuAction()?.Id ?? 0;
	}

	public AdventureActionData QueryTaiwuActionData(out int remainTime)
	{
		remainTime = 0;
		AdventureAction action = QueryTaiwuAction();
		if (action == null)
		{
			return null;
		}
		remainTime = action.RemainTime;
		return QueryActionData(action.Key);
	}

	public int QueryElementActionId(AdventureElement element)
	{
		return QueryElementAction(element)?.Id ?? 0;
	}

	public AdventureActionData QueryElementActionData(AdventureElement element, out int remainTime)
	{
		remainTime = 0;
		AdventureAction action = QueryElementAction(element);
		if (action == null)
		{
			return null;
		}
		remainTime = action.RemainTime;
		return QueryActionData(action.Key);
	}

	public IEnumerable<AdventureElement> QueryTaiwuActionGroupElements()
	{
		AdventureAction action = QueryTaiwuAction();
		if (action != null)
		{
			return QueryActionGroupElements(action);
		}
		return Enumerable.Empty<AdventureElement>();
	}

	public IEnumerable<AdventureElement> QueryElementActionGroupElements(AdventureElement actionElement)
	{
		AdventureAction action = QueryElementAction(actionElement);
		if (action != null)
		{
			return QueryActionGroupElements(action);
		}
		return Enumerable.Empty<AdventureElement>();
	}

	private AdventureAction QueryTaiwuAction()
	{
		List<AdventureAction> actions = _actions;
		if (actions == null || actions.Count <= 0)
		{
			return null;
		}
		foreach (AdventureAction action in _actions)
		{
			if (action.ContainsTaiwu)
			{
				return action;
			}
		}
		return null;
	}

	private AdventureAction QueryElementAction(AdventureElement element)
	{
		List<AdventureAction> actions = _actions;
		if (actions == null || actions.Count <= 0)
		{
			return null;
		}
		foreach (AdventureAction action in _actions)
		{
			List<int> elements = action.Elements;
			if (elements != null && elements.Count > 0 && action.Elements.Contains(element.Id))
			{
				return action;
			}
		}
		return null;
	}

	private AdventureActionData QueryActionData(string key)
	{
		RepeatedField<AdventureActionData> actions = Core.Actions;
		if (actions == null || actions.Count <= 0 || string.IsNullOrEmpty(key))
		{
			return null;
		}
		foreach (AdventureActionData data in Core.Actions)
		{
			if (data.Key == key)
			{
				return data;
			}
		}
		return null;
	}

	private IEnumerable<AdventureElement> QueryActionGroupElements(AdventureAction action)
	{
		List<int> elements = action.Elements;
		if (elements == null || elements.Count <= 0)
		{
			yield break;
		}
		List<AdventureElement> elements2 = _elements;
		if (elements2 == null || elements2.Count <= 0)
		{
			yield break;
		}
		foreach (AdventureElement element in _elements)
		{
			if (action.Elements.Contains(element.Id))
			{
				yield return element;
			}
		}
	}

	public bool StartAction(string key, AdventureElement element)
	{
		return StartAction(key, containsTaiwu: false, element);
	}

	public bool StartAction(string key, IReadOnlyList<AdventureElement> elements)
	{
		return StartAction(key, containsTaiwu: false, elements);
	}

	public bool StartActionWithTaiwu(string key)
	{
		return StartAction(key, containsTaiwu: true, Array.Empty<AdventureElement>());
	}

	public bool StartActionWithTaiwu(string key, AdventureElement element)
	{
		return StartAction(key, containsTaiwu: true, element);
	}

	public bool StartActionWithTaiwu(string key, IReadOnlyList<AdventureElement> elements)
	{
		return StartAction(key, containsTaiwu: true, elements);
	}

	private bool StartAction(string key, bool containsTaiwu, AdventureElement element)
	{
		List<AdventureElement> elements = ObjectPool<List<AdventureElement>>.Instance.Get();
		elements.Add(element);
		bool result = StartAction(key, containsTaiwu, elements);
		ObjectPool<List<AdventureElement>>.Instance.Return(elements);
		return result;
	}

	private bool StartAction(string key, bool containsTaiwu, IReadOnlyList<AdventureElement> elements)
	{
		AdventureActionData data = QueryActionData(key);
		return StartAction(data, containsTaiwu, elements);
	}

	private bool StartAction(AdventureActionData data, bool containsTaiwu, IReadOnlyList<AdventureElement> elements)
	{
		if (data == null || data.Time <= 0)
		{
			return false;
		}
		foreach (AdventureElement element in elements)
		{
			if (!IsElementAlive(element))
			{
				return false;
			}
		}
		int newActionId = 1;
		if (_actions == null)
		{
			_actions = new List<AdventureAction>();
		}
		foreach (AdventureAction action in _actions)
		{
			newActionId = Math.Max(newActionId, action.Id + 1);
			if (action.ContainsTaiwu && containsTaiwu)
			{
				return false;
			}
			foreach (AdventureElement element2 in elements)
			{
				List<int> elements2 = action.Elements;
				if (elements2 != null && elements2.Count > 0 && action.Elements.Contains(element2.Id))
				{
					return false;
				}
			}
		}
		AdventureAction newAction = new AdventureAction
		{
			Id = newActionId,
			Key = data.Key,
			RemainTime = data.Time,
			ContainsTaiwu = containsTaiwu,
			Elements = ((elements == null || elements.Count <= 0) ? null : new List<int>(elements.Select((AdventureElement x) => x.Id)))
		};
		_actions.Add(newAction);
		return true;
	}

	public bool InterruptTaiwuAction()
	{
		int actionId = QueryTaiwuActionId();
		if (actionId >= 1)
		{
			return InterruptAction(actionId);
		}
		return false;
	}

	public bool InterruptElementAction(AdventureElement element)
	{
		int actionId = QueryElementActionId(element);
		if (actionId >= 1)
		{
			return InterruptAction(actionId);
		}
		return false;
	}

	public bool InterruptJustRemovedElementActions()
	{
		List<int> justRemovedElementIds = _justRemovedElementIds;
		if (justRemovedElementIds != null && justRemovedElementIds.Count > 0)
		{
			List<AdventureAction> actions = _actions;
			if (actions != null && actions.Count > 0)
			{
				bool anyChanged = false;
				for (int i = _actions.Count - 1; i >= 0; i--)
				{
					AdventureAction action = _actions[i];
					justRemovedElementIds = action.Elements;
					if (justRemovedElementIds != null && justRemovedElementIds.Count > 0 && action.Elements.Any(_justRemovedElementIds.Contains))
					{
						_actions.RemoveAt(i);
						anyChanged = true;
					}
				}
				_justRemovedElementIds.Clear();
				return anyChanged;
			}
		}
		return false;
	}

	public bool InterruptAction(int actionId)
	{
		List<AdventureAction> actions = _actions;
		if (actions == null || actions.Count <= 0)
		{
			return false;
		}
		for (int i = 0; i < _actions.Count; i++)
		{
			if (_actions[i].Id == actionId)
			{
				_actions.RemoveAt(i);
				return true;
			}
		}
		return false;
	}

	public void InterruptAllActions()
	{
		List<AdventureAction> actions = _actions;
		if (actions != null && actions.Count > 0)
		{
			_actions.Clear();
		}
	}

	public void CacheActions(IList<int> actionIds)
	{
		actionIds.Clear();
		List<AdventureAction> actions = _actions;
		if (actions != null && actions.Count > 0)
		{
			for (int i = _actions.Count - 1; i >= 0; i--)
			{
				actionIds.Add(_actions[i].Id);
			}
		}
	}

	public bool ChangeAction(int actionId, int deltaTime, out AdventureAction finishedAction)
	{
		finishedAction = null;
		List<AdventureAction> actions = _actions;
		if (actions == null || actions.Count <= 0)
		{
			return false;
		}
		for (int i = _actions.Count - 1; i >= 0; i--)
		{
			AdventureAction action = _actions[i];
			if (action.Id == actionId)
			{
				List<int> elements = action.Elements;
				if (elements == null || elements.Count <= 0 || action.Elements.All(IsElementAlive))
				{
					action.RemainTime -= deltaTime;
					if (action.RemainTime > 0)
					{
						return true;
					}
					finishedAction = action;
				}
				_actions.RemoveAt(i);
				return true;
			}
		}
		return false;
	}

	public AdventureRuntime()
	{
	}

	public AdventureRuntime(AdventureRuntime other)
	{
		Id = other.Id;
		MapLocation = other.MapLocation;
		CoreId = other.CoreId;
		if (other._blocks != null)
		{
			List<AdventureBlock> item = other._blocks;
			int elementsCount = item.Count;
			_blocks = new List<AdventureBlock>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				_blocks.Add(new AdventureBlock(item[i]));
			}
		}
		else
		{
			_blocks = null;
		}
		if (other._elements != null)
		{
			List<AdventureElement> item2 = other._elements;
			int elementsCount2 = item2.Count;
			_elements = new List<AdventureElement>(elementsCount2);
			for (int j = 0; j < elementsCount2; j++)
			{
				_elements.Add(new AdventureElement(item2[j]));
			}
		}
		else
		{
			_elements = null;
		}
		_parameterValues = ((other._parameterValues == null) ? null : new Dictionary<AdventureParameterKey, AdventureParameterValue>(other._parameterValues));
		_invokedOnceAutoEvents = ((other._invokedOnceAutoEvents == null) ? null : new List<int>(other._invokedOnceAutoEvents));
		if (other._invokedOnceElementEvents != null)
		{
			Dictionary<int, IntList> invokedOnceElementEvents = other._invokedOnceElementEvents;
			int elementsCount3 = invokedOnceElementEvents.Count;
			_invokedOnceElementEvents = new Dictionary<int, IntList>(elementsCount3);
			foreach (KeyValuePair<int, IntList> pair in invokedOnceElementEvents)
			{
				_invokedOnceElementEvents.Add(pair.Key, new IntList(pair.Value));
			}
		}
		else
		{
			_invokedOnceElementEvents = null;
		}
		if (other._temporaryItems != null)
		{
			List<AdventureItem> item3 = other._temporaryItems;
			int elementsCount4 = item3.Count;
			_temporaryItems = new List<AdventureItem>(elementsCount4);
			for (int k = 0; k < elementsCount4; k++)
			{
				_temporaryItems.Add(new AdventureItem(item3[k]));
			}
		}
		else
		{
			_temporaryItems = null;
		}
		_calledCharacters = ((other._calledCharacters == null) ? null : new List<int>(other._calledCharacters));
		_temporaryCharacters = ((other._temporaryCharacters == null) ? null : new List<int>(other._temporaryCharacters));
		_internalStatusType = other._internalStatusType;
		_autoDeleteDate = other._autoDeleteDate;
		DisplayRandomSeed = other.DisplayRandomSeed;
		if (other._actions != null)
		{
			List<AdventureAction> item4 = other._actions;
			int elementsCount5 = item4.Count;
			_actions = new List<AdventureAction>(elementsCount5);
			for (int l = 0; l < elementsCount5; l++)
			{
				_actions.Add(new AdventureAction(item4[l]));
			}
		}
		else
		{
			_actions = null;
		}
		_nextElementId = other._nextElementId;
		_blockGroupIndex = other._blockGroupIndex;
		Version = other.Version;
	}

	public void Assign(AdventureRuntime other)
	{
		Id = other.Id;
		MapLocation = other.MapLocation;
		CoreId = other.CoreId;
		if (other._blocks != null)
		{
			List<AdventureBlock> item = other._blocks;
			int elementsCount = item.Count;
			_blocks = new List<AdventureBlock>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				_blocks.Add(new AdventureBlock(item[i]));
			}
		}
		else
		{
			_blocks = null;
		}
		if (other._elements != null)
		{
			List<AdventureElement> item2 = other._elements;
			int elementsCount2 = item2.Count;
			_elements = new List<AdventureElement>(elementsCount2);
			for (int j = 0; j < elementsCount2; j++)
			{
				_elements.Add(new AdventureElement(item2[j]));
			}
		}
		else
		{
			_elements = null;
		}
		_parameterValues = ((other._parameterValues == null) ? null : new Dictionary<AdventureParameterKey, AdventureParameterValue>(other._parameterValues));
		_invokedOnceAutoEvents = ((other._invokedOnceAutoEvents == null) ? null : new List<int>(other._invokedOnceAutoEvents));
		if (other._invokedOnceElementEvents != null)
		{
			Dictionary<int, IntList> invokedOnceElementEvents = other._invokedOnceElementEvents;
			int elementsCount3 = invokedOnceElementEvents.Count;
			_invokedOnceElementEvents = new Dictionary<int, IntList>(elementsCount3);
			foreach (KeyValuePair<int, IntList> pair in invokedOnceElementEvents)
			{
				_invokedOnceElementEvents.Add(pair.Key, new IntList(pair.Value));
			}
		}
		else
		{
			_invokedOnceElementEvents = null;
		}
		if (other._temporaryItems != null)
		{
			List<AdventureItem> item3 = other._temporaryItems;
			int elementsCount4 = item3.Count;
			_temporaryItems = new List<AdventureItem>(elementsCount4);
			for (int k = 0; k < elementsCount4; k++)
			{
				_temporaryItems.Add(new AdventureItem(item3[k]));
			}
		}
		else
		{
			_temporaryItems = null;
		}
		_calledCharacters = ((other._calledCharacters == null) ? null : new List<int>(other._calledCharacters));
		_temporaryCharacters = ((other._temporaryCharacters == null) ? null : new List<int>(other._temporaryCharacters));
		_internalStatusType = other._internalStatusType;
		_autoDeleteDate = other._autoDeleteDate;
		DisplayRandomSeed = other.DisplayRandomSeed;
		if (other._actions != null)
		{
			List<AdventureAction> item4 = other._actions;
			int elementsCount5 = item4.Count;
			_actions = new List<AdventureAction>(elementsCount5);
			for (int l = 0; l < elementsCount5; l++)
			{
				_actions.Add(new AdventureAction(item4[l]));
			}
		}
		else
		{
			_actions = null;
		}
		_nextElementId = other._nextElementId;
		_blockGroupIndex = other._blockGroupIndex;
		Version = other.Version;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 39;
		if (_blocks != null)
		{
			totalSize += 2;
			int elementsCount = _blocks.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				AdventureBlock element = _blocks[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (_elements != null)
		{
			totalSize += 2;
			int elementsCount2 = _elements.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				AdventureElement element2 = _elements[j];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + element2.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += SerializationHelper.DictionaryOfCustomTypePair.GetSerializedSize(_parameterValues);
		totalSize = ((_invokedOnceAutoEvents == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _invokedOnceAutoEvents.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(_invokedOnceElementEvents);
		if (_temporaryItems != null)
		{
			totalSize += 2;
			int elementsCount3 = _temporaryItems.Count;
			for (int k = 0; k < elementsCount3; k++)
			{
				AdventureItem element3 = _temporaryItems[k];
				totalSize = ((element3 == null) ? (totalSize + 2) : (totalSize + (2 + element3.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((_calledCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _calledCharacters.Count)));
		totalSize = ((_temporaryCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _temporaryCharacters.Count)));
		if (_actions != null)
		{
			totalSize += 2;
			int elementsCount4 = _actions.Count;
			for (int l = 0; l < elementsCount4; l++)
			{
				AdventureAction element4 = _actions[l];
				totalSize = ((element4 == null) ? (totalSize + 2) : (totalSize + (2 + element4.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 18;
		pCurrData += 2;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		pCurrData += MapLocation.Serialize(pCurrData);
		*(int*)pCurrData = CoreId;
		pCurrData += 4;
		if (_blocks != null)
		{
			int elementsCount = _blocks.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				AdventureBlock element = _blocks[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_elements != null)
		{
			int elementsCount2 = _elements.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				AdventureElement element2 = _elements[j];
				if (element2 != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int subDataSize2 = element2.Serialize(pCurrData);
					pCurrData += subDataSize2;
					Tester.Assert(subDataSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)subDataSize2;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Serialize(pCurrData, ref _parameterValues);
		if (_invokedOnceAutoEvents != null)
		{
			int elementsCount3 = _invokedOnceAutoEvents.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((int*)pCurrData)[k] = _invokedOnceAutoEvents[k];
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref _invokedOnceElementEvents);
		if (_temporaryItems != null)
		{
			int elementsCount4 = _temporaryItems.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				AdventureItem element3 = _temporaryItems[l];
				if (element3 != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int subDataSize3 = element3.Serialize(pCurrData);
					pCurrData += subDataSize3;
					Tester.Assert(subDataSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)subDataSize3;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_calledCharacters != null)
		{
			int elementsCount5 = _calledCharacters.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				((int*)pCurrData)[m] = _calledCharacters[m];
			}
			pCurrData += 4 * elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_temporaryCharacters != null)
		{
			int elementsCount6 = _temporaryCharacters.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				((int*)pCurrData)[n] = _temporaryCharacters[n];
			}
			pCurrData += 4 * elementsCount6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = _internalStatusType;
		pCurrData++;
		*(int*)pCurrData = _autoDeleteDate;
		pCurrData += 4;
		*(int*)pCurrData = DisplayRandomSeed;
		pCurrData += 4;
		if (_actions != null)
		{
			int elementsCount7 = _actions.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				AdventureAction element4 = _actions[num];
				if (element4 != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int subDataSize4 = element4.Serialize(pCurrData);
					pCurrData += subDataSize4;
					Tester.Assert(subDataSize4 <= 65535);
					*(ushort*)intPtr4 = (ushort)subDataSize4;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = _nextElementId;
		pCurrData += 4;
		*(int*)pCurrData = _blockGroupIndex;
		pCurrData += 4;
		*(ulong*)pCurrData = Version;
		pCurrData += 8;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			Id = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			pCurrData += MapLocation.Deserialize(pCurrData);
		}
		if (fieldCount > 2)
		{
			CoreId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (_blocks == null)
				{
					_blocks = new List<AdventureBlock>(elementsCount);
				}
				else
				{
					_blocks.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num > 0)
					{
						AdventureBlock element = new AdventureBlock();
						pCurrData += element.Deserialize(pCurrData);
						_blocks.Add(element);
					}
					else
					{
						_blocks.Add(null);
					}
				}
			}
			else
			{
				_blocks?.Clear();
			}
		}
		if (fieldCount > 4)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (_elements == null)
				{
					_elements = new List<AdventureElement>(elementsCount2);
				}
				else
				{
					_elements.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					ushort num2 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num2 > 0)
					{
						AdventureElement element2 = new AdventureElement();
						pCurrData += element2.Deserialize(pCurrData);
						_elements.Add(element2);
					}
					else
					{
						_elements.Add(null);
					}
				}
			}
			else
			{
				_elements?.Clear();
			}
		}
		if (fieldCount > 5)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Deserialize(pCurrData, ref _parameterValues);
		}
		if (fieldCount > 6)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (_invokedOnceAutoEvents == null)
				{
					_invokedOnceAutoEvents = new List<int>(elementsCount3);
				}
				else
				{
					_invokedOnceAutoEvents.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					_invokedOnceAutoEvents.Add(((int*)pCurrData)[k]);
				}
				pCurrData += 4 * elementsCount3;
			}
			else
			{
				_invokedOnceAutoEvents?.Clear();
			}
		}
		if (fieldCount > 7)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref _invokedOnceElementEvents);
		}
		if (fieldCount > 8)
		{
			ushort elementsCount4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount4 > 0)
			{
				if (_temporaryItems == null)
				{
					_temporaryItems = new List<AdventureItem>(elementsCount4);
				}
				else
				{
					_temporaryItems.Clear();
				}
				for (int l = 0; l < elementsCount4; l++)
				{
					ushort num3 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num3 > 0)
					{
						AdventureItem element3 = new AdventureItem();
						pCurrData += element3.Deserialize(pCurrData);
						_temporaryItems.Add(element3);
					}
					else
					{
						_temporaryItems.Add(null);
					}
				}
			}
			else
			{
				_temporaryItems?.Clear();
			}
		}
		if (fieldCount > 9)
		{
			ushort elementsCount5 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount5 > 0)
			{
				if (_calledCharacters == null)
				{
					_calledCharacters = new List<int>(elementsCount5);
				}
				else
				{
					_calledCharacters.Clear();
				}
				for (int m = 0; m < elementsCount5; m++)
				{
					_calledCharacters.Add(((int*)pCurrData)[m]);
				}
				pCurrData += 4 * elementsCount5;
			}
			else
			{
				_calledCharacters?.Clear();
			}
		}
		if (fieldCount > 10)
		{
			ushort elementsCount6 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount6 > 0)
			{
				if (_temporaryCharacters == null)
				{
					_temporaryCharacters = new List<int>(elementsCount6);
				}
				else
				{
					_temporaryCharacters.Clear();
				}
				for (int n = 0; n < elementsCount6; n++)
				{
					_temporaryCharacters.Add(((int*)pCurrData)[n]);
				}
				pCurrData += 4 * elementsCount6;
			}
			else
			{
				_temporaryCharacters?.Clear();
			}
		}
		if (fieldCount > 11)
		{
			_internalStatusType = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 12)
		{
			_autoDeleteDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 13)
		{
			DisplayRandomSeed = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 14)
		{
			ushort elementsCount7 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount7 > 0)
			{
				if (_actions == null)
				{
					_actions = new List<AdventureAction>(elementsCount7);
				}
				else
				{
					_actions.Clear();
				}
				for (int num4 = 0; num4 < elementsCount7; num4++)
				{
					ushort num5 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num5 > 0)
					{
						AdventureAction element4 = new AdventureAction();
						pCurrData += element4.Deserialize(pCurrData);
						_actions.Add(element4);
					}
					else
					{
						_actions.Add(null);
					}
				}
			}
			else
			{
				_actions?.Clear();
			}
		}
		if (fieldCount > 15)
		{
			_nextElementId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 16)
		{
			_blockGroupIndex = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 17)
		{
			Version = (AdventureVersion)(*(ulong*)pCurrData);
			pCurrData += 8;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
