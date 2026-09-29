using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Adventure;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using Google.Protobuf.Collections;

namespace GameData.Domains.Adventure;

[SerializableGameData(IsExtensible = true)]
public class AdventureMajorEvent : IAdventureRuntime, IAdventureParameterProvider, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort CoreId = 1;

		public const ushort MapLocation = 2;

		public const ushort AutoDeleteDate = 3;

		public const ushort InternalStatusType = 4;

		public const ushort CalledCharacters = 5;

		public const ushort TemporaryCharacters = 6;

		public const ushort ParameterValues = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "Id", "CoreId", "MapLocation", "AutoDeleteDate", "InternalStatusType", "CalledCharacters", "TemporaryCharacters", "ParameterValues" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int Id;

	[SerializableGameDataField(FieldIndex = 1)]
	public int CoreId;

	[SerializableGameDataField(FieldIndex = 2)]
	public Location MapLocation;

	[SerializableGameDataField(FieldIndex = 3)]
	private int _autoDeleteDate = -1;

	[SerializableGameDataField(FieldIndex = 4)]
	private byte _internalStatusType;

	[SerializableGameDataField(FieldIndex = 5)]
	private List<IntList> _calledCharacters;

	[SerializableGameDataField(FieldIndex = 6)]
	private List<int> _temporaryCharacters;

	[SerializableGameDataField(FieldIndex = 7)]
	private Dictionary<AdventureParameterKey, AdventureParameterValue> _parameterValues;

	private static readonly Dictionary<CharacterFilterKey, List<int>> FilterGroupIndexes = new Dictionary<CharacterFilterKey, List<int>>();

	public AdventureMajorEventData Core => ExternalDataBridge.Context.AdventureCore.GetAdventureMajorEventData(CoreId);

	public EAdventureStatusType StatusType => (EAdventureStatusType)_internalStatusType;

	public int RemainMonths => CalcRemainMonths(ExternalDataBridge.Context.CurrDate);

	int IAdventureRuntime.Id => Id;

	int IAdventureRuntime.CoreId => CoreId;

	Location IAdventureRuntime.MapLocation => MapLocation;

	bool IAdventureRuntime.Satisfied => AllSatisfied();

	IReadOnlyList<AdventureParameterData> IAdventureParameterProvider.Parameters => Core.Parameters;

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
				return RemainMonths != 0;
			}
			return true;
		}
	}

	public override string ToString()
	{
		return $"{Core.Name}({Id})";
	}

	public int CalcRemainMonths(int currDate)
	{
		if (_autoDeleteDate < 0)
		{
			return -1;
		}
		return Math.Max(_autoDeleteDate - currDate, 0);
	}

	public AdventureMajorEvent(int id, int coreId, Location location)
	{
		Id = id;
		CoreId = coreId;
		MapLocation = location;
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

	public bool InitStatusType(IAdventureContextBridge context)
	{
		bool num = AllSatisfied();
		if (num)
		{
			SetStatusType(context, EAdventureStatusType.Ready);
		}
		return num;
	}

	private bool AllSatisfied()
	{
		RepeatedField<AdventureCharacterGroup> characters = Core.Characters;
		if (characters == null || characters.Count <= 0)
		{
			return true;
		}
		foreach (AdventureCharacterGroup item in characters)
		{
			if (item.Data.Type == EAdventureCharacterType.Necessary)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsTemporaryCharacter(int charId)
	{
		return _temporaryCharacters?.Contains(charId) ?? false;
	}

	public bool IsCalledCharacter(int charId)
	{
		List<IntList> calledCharacters = _calledCharacters;
		if (calledCharacters == null || calledCharacters.Count <= 0)
		{
			return false;
		}
		foreach (IntList calledCharacter in _calledCharacters)
		{
			List<int> calledCharacters2 = calledCharacter.Items;
			if (calledCharacters2 != null && calledCharacters2.Count > 0 && calledCharacters2.Contains(charId))
			{
				return true;
			}
		}
		return false;
	}

	public void CollectCharacters(ICollection<int> characters)
	{
		List<IntList> calledCharacters = _calledCharacters;
		if (calledCharacters == null || calledCharacters.Count <= 0)
		{
			return;
		}
		foreach (IntList charList in _calledCharacters)
		{
			List<int> items = charList.Items;
			if (items == null || items.Count <= 0)
			{
				continue;
			}
			foreach (int charId in charList.Items)
			{
				characters.Add(charId);
			}
		}
	}

	public IReadOnlyList<int> QueryCalledCharacters(int index)
	{
		return _calledCharacters?.GetOrDefault(index).Items;
	}

	public bool MarkTemporaryCharacterAsCalled(int charId)
	{
		return _temporaryCharacters?.Remove(charId) ?? false;
	}

	public EAdventureUnbindType DynamicUnbindCharacter(IAdventureContextBridge context, int charId)
	{
		List<IntList> calledCharacters = _calledCharacters;
		if (calledCharacters == null || calledCharacters.Count <= 0 || StatusType == EAdventureStatusType.Releasing)
		{
			return EAdventureUnbindType.None;
		}
		bool anyChanged = false;
		for (int i = 0; i < _calledCharacters.Count; i++)
		{
			List<int> charIds = _calledCharacters[i].Items;
			if (charIds == null || charIds.Count <= 0)
			{
				continue;
			}
			bool groupChanged = false;
			for (int ii = charIds.Count - 1; ii >= 0; ii--)
			{
				if (charIds[ii] == charId)
				{
					charIds.RemoveAt(ii);
					groupChanged = true;
				}
			}
			if (groupChanged)
			{
				anyChanged = true;
				if (Core.Characters[i].Data.Type == EAdventureCharacterType.Necessary)
				{
					SetStatusType(context, EAdventureStatusType.Preparing);
				}
			}
		}
		if (!anyChanged)
		{
			return EAdventureUnbindType.None;
		}
		return EAdventureUnbindType.Called;
	}

	bool IAdventureRuntime.CallCharacters(IAdventureContextBridge context, EAdventureCharacterType type)
	{
		RepeatedField<AdventureCharacterGroup> characters = Core.Characters;
		if (characters == null || characters.Count <= 0)
		{
			return true;
		}
		if (_calledCharacters == null)
		{
			_calledCharacters = new List<IntList>();
		}
		List<int> value;
		for (int i = 0; i < Core.Characters.Count; i++)
		{
			AdventureCharacterGroup group = Core.Characters[i];
			if (group.Data.Type == type && group.Count > 0)
			{
				IntList calledCharacters = _calledCharacters.GetOrDefault(i);
				value = calledCharacters.Items;
				if (value == null || value.Count <= 0 || calledCharacters.Items.Count != group.Count)
				{
					FilterGroupIndexes.GetOrNew(group.Data.FilterKey).Add(i);
				}
			}
		}
		bool allSatisfied = true;
		int limit = this.GetParameterOrDefault("ConchShipPresetKey_CallCharacterCountLimit", int.MaxValue).Current;
		foreach (KeyValuePair<CharacterFilterKey, List<int>> filterGroupIndex in FilterGroupIndexes)
		{
			filterGroupIndex.Deconstruct(out var key, out value);
			CharacterFilterKey filterKey = key;
			List<int> groupIndexes = value;
			if (groupIndexes.Count == 0)
			{
				continue;
			}
			int maxCount = 0;
			foreach (int groupIndex in groupIndexes)
			{
				IntList groupCharacters = _calledCharacters.GetOrDefault(groupIndex);
				ref List<int> items = ref groupCharacters.Items;
				if (items == null)
				{
					items = new List<int>();
				}
				_calledCharacters.SetOrAdd(groupIndex, groupCharacters);
				maxCount += Core.Characters[groupIndex].Count - groupCharacters.Items.Count;
			}
			maxCount = Math.Min(maxCount, limit);
			List<int> calledCharacters2 = ObjectPool<List<int>>.Instance.Get();
			context.CallCharacters(calledCharacters2, filterKey, MapLocation, maxCount);
			if (calledCharacters2.Count < maxCount)
			{
				allSatisfied = false;
			}
			for (int j = 0; j < calledCharacters2.Count; j++)
			{
				int groupIndex2 = groupIndexes[0];
				IntList intList = _calledCharacters[groupIndex2];
				intList.Items.Add(calledCharacters2[j]);
				if (intList.Items.Count == Core.Characters[groupIndex2].Count)
				{
					groupIndexes.RemoveAt(0);
				}
			}
			ObjectPool<List<int>>.Instance.Return(calledCharacters2);
		}
		foreach (List<int> value2 in FilterGroupIndexes.Values)
		{
			value2.Clear();
		}
		return allSatisfied;
	}

	public bool GenerateCharacters(IAdventureContextBridge context)
	{
		if ((int)StatusType >= 2)
		{
			return false;
		}
		SetStatusType(context, EAdventureStatusType.Entered);
		for (int i = 0; i < Core.Characters.Count; i++)
		{
			AdventureCharacterGroup characterGroup = Core.Characters[i];
			if (characterGroup.Data.Type != EAdventureCharacterType.NecessaryAutoCreate)
			{
				continue;
			}
			if (_calledCharacters == null)
			{
				_calledCharacters = new List<IntList>();
			}
			IntList calledCharacters = _calledCharacters.GetOrDefault(i);
			ref List<int> items = ref calledCharacters.Items;
			if (items == null)
			{
				items = new List<int>();
			}
			_calledCharacters.SetOrAdd(i, calledCharacters);
			while (calledCharacters.Items.Count < characterGroup.Count)
			{
				int charId = context.GenerateTemporaryCharacter(characterGroup.Data.FilterKey, MapLocation);
				calledCharacters.Items.Add(charId);
				if (_temporaryCharacters == null)
				{
					_temporaryCharacters = new List<int>();
				}
				_temporaryCharacters.Add(charId);
			}
		}
		return true;
	}

	public void ReleaseData(IAdventureContextBridge context)
	{
		List<IntList> calledCharacters = _calledCharacters;
		if (calledCharacters == null || calledCharacters.Count <= 0)
		{
			return;
		}
		SetStatusType(context, EAdventureStatusType.Releasing);
		foreach (IntList characters in _calledCharacters)
		{
			List<int> items = characters.Items;
			if (items != null && items.Count > 0)
			{
				items = _temporaryCharacters;
				if (items != null && items.Count > 0)
				{
					context.ReleaseTemporaryCharacters(characters.Items.Where(_temporaryCharacters.Contains));
					characters.Items.RemoveAll(_temporaryCharacters.Contains);
				}
				context.ReleaseCalledCharacters(characters.Items);
			}
		}
	}

	public AdventureMajorEvent()
	{
	}

	public AdventureMajorEvent(AdventureMajorEvent other)
	{
		Id = other.Id;
		CoreId = other.CoreId;
		MapLocation = other.MapLocation;
		_autoDeleteDate = other._autoDeleteDate;
		_internalStatusType = other._internalStatusType;
		if (other._calledCharacters != null)
		{
			List<IntList> item = other._calledCharacters;
			int elementsCount = item.Count;
			_calledCharacters = new List<IntList>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				_calledCharacters.Add(new IntList(item[i]));
			}
		}
		else
		{
			_calledCharacters = null;
		}
		_temporaryCharacters = ((other._temporaryCharacters == null) ? null : new List<int>(other._temporaryCharacters));
		_parameterValues = ((other._parameterValues == null) ? null : new Dictionary<AdventureParameterKey, AdventureParameterValue>(other._parameterValues));
	}

	public void Assign(AdventureMajorEvent other)
	{
		Id = other.Id;
		CoreId = other.CoreId;
		MapLocation = other.MapLocation;
		_autoDeleteDate = other._autoDeleteDate;
		_internalStatusType = other._internalStatusType;
		if (other._calledCharacters != null)
		{
			List<IntList> item = other._calledCharacters;
			int elementsCount = item.Count;
			_calledCharacters = new List<IntList>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				_calledCharacters.Add(new IntList(item[i]));
			}
		}
		else
		{
			_calledCharacters = null;
		}
		_temporaryCharacters = ((other._temporaryCharacters == null) ? null : new List<int>(other._temporaryCharacters));
		_parameterValues = ((other._parameterValues == null) ? null : new Dictionary<AdventureParameterKey, AdventureParameterValue>(other._parameterValues));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 19;
		if (_calledCharacters != null)
		{
			totalSize += 2;
			int elementsCount = _calledCharacters.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += _calledCharacters[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((_temporaryCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _temporaryCharacters.Count)));
		totalSize += SerializationHelper.DictionaryOfCustomTypePair.GetSerializedSize(_parameterValues);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 8;
		pCurrData += 2;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(int*)pCurrData = CoreId;
		pCurrData += 4;
		pCurrData += MapLocation.Serialize(pCurrData);
		*(int*)pCurrData = _autoDeleteDate;
		pCurrData += 4;
		*pCurrData = _internalStatusType;
		pCurrData++;
		if (_calledCharacters != null)
		{
			int elementsCount = _calledCharacters.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = _calledCharacters[i].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_temporaryCharacters != null)
		{
			int elementsCount2 = _temporaryCharacters.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = _temporaryCharacters[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Serialize(pCurrData, ref _parameterValues);
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
			CoreId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			pCurrData += MapLocation.Deserialize(pCurrData);
		}
		if (fieldCount > 3)
		{
			_autoDeleteDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 4)
		{
			_internalStatusType = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 5)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (_calledCharacters == null)
				{
					_calledCharacters = new List<IntList>(elementsCount);
				}
				else
				{
					_calledCharacters.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					IntList element = default(IntList);
					pCurrData += element.Deserialize(pCurrData);
					_calledCharacters.Add(element);
				}
			}
			else
			{
				_calledCharacters?.Clear();
			}
		}
		if (fieldCount > 6)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (_temporaryCharacters == null)
				{
					_temporaryCharacters = new List<int>(elementsCount2);
				}
				else
				{
					_temporaryCharacters.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					_temporaryCharacters.Add(((int*)pCurrData)[j]);
				}
				pCurrData += 4 * elementsCount2;
			}
			else
			{
				_temporaryCharacters?.Clear();
			}
		}
		if (fieldCount > 7)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Deserialize(pCurrData, ref _parameterValues);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
