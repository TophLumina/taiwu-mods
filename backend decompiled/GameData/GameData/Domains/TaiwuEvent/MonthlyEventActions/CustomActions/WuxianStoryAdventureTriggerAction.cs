using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions.CustomActions;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true, IsExtensible = true)]
public class WuxianStoryAdventureTriggerAction : MonthlyActionBase, IDynamicAction, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort HighGradeCharacters = 0;

		public const ushort NormalCharacters = 1;

		public const ushort Location = 2;

		public const ushort Key = 3;

		public const ushort State = 4;

		public const ushort Month = 5;

		public const ushort LastFinishDate = 6;

		public const ushort Count = 7;

		public static readonly string[] FieldId2FieldName = new string[7] { "HighGradeCharacters", "NormalCharacters", "Location", "Key", "State", "Month", "LastFinishDate" };
	}

	private const int MaxMenteeCountInAdventure = 15;

	private int _currMenteeCountInAdventure = 0;

	[SerializableGameDataField]
	private List<int> _highGradeCharacters;

	[SerializableGameDataField]
	private List<int> _normalCharacters;

	[SerializableGameDataField]
	private Location _location;

	public short DynamicActionType => 3;

	public WuxianStoryAdventureTriggerAction()
	{
		_highGradeCharacters = new List<int>();
		_normalCharacters = new List<int>();
		_location = Location.Invalid;
	}

	public override void MonthlyHandler()
	{
	}

	public override void TriggerAction()
	{
		if (State != 0)
		{
			return;
		}
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(12);
		Location rootLocation = settlement.GetLocation();
		List<short> blockIdList = new List<short>();
		DomainManager.Map.GetSettlementBlocks(rootLocation.AreaId, rootLocation.BlockId, blockIdList);
		CollectionUtils.Shuffle(context.Random, blockIdList);
		foreach (short blockId in blockIdList)
		{
			if (DomainManager.Adventure.TryCreateAdventureSite(context, rootLocation.AreaId, blockId, 25, Key))
			{
				_location = new Location(rootLocation.AreaId, blockId);
				DomainManager.Adventure.ActivateAdventureSite(context, rootLocation.AreaId, blockId);
				CallCharacters();
				break;
			}
		}
	}

	public override void CollectCalledCharacters(HashSet<int> calledCharacters)
	{
		GameData.Domains.Character.Character character;
		foreach (int charId in _highGradeCharacters)
		{
			if (IsCharacterStillValid(charId, out character))
			{
				calledCharacters.Add(charId);
			}
		}
		foreach (int charId2 in _normalCharacters)
		{
			if (IsCharacterStillValid(charId2, out character))
			{
				calledCharacters.Add(charId2);
			}
		}
	}

	public override void Deactivate(bool isComplete)
	{
		State = 0;
		Month = 0;
		LastFinishDate = DomainManager.World.GetCurrDate();
		_location = Location.Invalid;
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		foreach (int charId in _highGradeCharacters)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				character.DeactivateExternalRelationState(context, 4uL);
				if (character.IsCompletelyInfected())
				{
					Events.RaiseInfectedCharacterLocationChanged(context, charId, Location.Invalid, character.GetLocation());
				}
				else
				{
					Events.RaiseCharacterLocationChanged(context, charId, Location.Invalid, character.GetLocation());
				}
			}
		}
		foreach (int charId2 in _normalCharacters)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId2, out var character2))
			{
				character2.DeactivateExternalRelationState(context, 4uL);
				if (character2.IsCompletelyInfected())
				{
					Events.RaiseInfectedCharacterLocationChanged(context, charId2, Location.Invalid, character2.GetLocation());
				}
				else
				{
					Events.RaiseCharacterLocationChanged(context, charId2, Location.Invalid, character2.GetLocation());
				}
			}
		}
		if (!isComplete)
		{
			DomainManager.Story.WuxianEndingFailing1(context, isComplete: false);
		}
		_highGradeCharacters.Clear();
		_normalCharacters.Clear();
	}

	public override MonthlyActionBase CreateCopy()
	{
		return GameData.Serializer.Serializer.CreateCopy(this);
	}

	public override void EnsurePrerequisites()
	{
		List<int> temp = new List<int>();
		GameData.Domains.Character.Character character;
		foreach (int charId in _highGradeCharacters)
		{
			if (IsCharacterStillValid(charId, out character))
			{
				temp.Add(charId);
			}
		}
		_highGradeCharacters = temp;
		temp = new List<int>();
		foreach (int charId2 in _normalCharacters)
		{
			if (IsCharacterStillValid(charId2, out character))
			{
				temp.Add(charId2);
			}
		}
		_normalCharacters = temp;
	}

	public override void FillEventArgBox(EventArgBox eventArgBox)
	{
		int leaderId = -1;
		int grade = -1;
		for (int i = 0; i < _highGradeCharacters.Count; i++)
		{
			int charId = _highGradeCharacters[i];
			OrganizationInfo orgInfo = DomainManager.Character.GetElement_Objects(charId).GetOrganizationInfo();
			if (orgInfo.Grade > grade)
			{
				grade = orgInfo.Grade;
				leaderId = charId;
			}
			AdaptableLog.Info("Adding 1 major character to adventure.");
			eventArgBox.Set($"MajorCharacter_0_{i}", charId);
		}
		eventArgBox.Set("MajorCharacter_0_Count", _highGradeCharacters.Count);
		for (int j = 0; j < _normalCharacters.Count; j++)
		{
			int charId2 = _normalCharacters[j];
			AdaptableLog.Info("Adding 1 participate character to adventure.");
			eventArgBox.Set($"ParticipateCharacter_0_{j}", charId2);
		}
		eventArgBox.Set("ParticipateCharacter_0_Count", _normalCharacters.Count);
		AdaptableLog.Info("Adding leader to adventure.");
		if (leaderId >= 0)
		{
			eventArgBox.Set("SectLeader", leaderId);
		}
	}

	private bool IsCharacterValidToCall(int charId, out GameData.Domains.Character.Character character)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out character))
		{
			return false;
		}
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (character.IsActiveExternalRelationState(188uL))
		{
			return false;
		}
		if (character.GetAgeGroup() != 2)
		{
			return false;
		}
		if (character.GetKidnapperId() >= 0)
		{
			return false;
		}
		if (orgInfo.OrgTemplateId != 12)
		{
			return false;
		}
		if (orgInfo.Grade >= 6)
		{
			return true;
		}
		if (_currMenteeCountInAdventure >= 15)
		{
			return false;
		}
		_currMenteeCountInAdventure++;
		return true;
	}

	private bool IsCharacterStillValid(int charId, out GameData.Domains.Character.Character character)
	{
		if (!DomainManager.Character.TryGetElement_Objects(charId, out character))
		{
			return false;
		}
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (character.GetKidnapperId() >= 0)
		{
			return false;
		}
		if (orgInfo.OrgTemplateId != 12)
		{
			return false;
		}
		return true;
	}

	private void CallCharacters()
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(12);
		Location rootLocation = settlement.GetLocation();
		List<short> blockIdList = new List<short>();
		HashSet<int> test = new HashSet<int>();
		DomainManager.Map.GetSettlementBlocks(rootLocation.AreaId, rootLocation.BlockId, blockIdList);
		_currMenteeCountInAdventure = 0;
		foreach (short blockId in blockIdList)
		{
			MapBlockData block = DomainManager.Map.GetBlockData(rootLocation.AreaId, blockId);
			HashSet<int> charIds = block.CharacterSet;
			if (charIds == null)
			{
				continue;
			}
			foreach (int charId in charIds)
			{
				if (IsCharacterValidToCall(charId, out var character))
				{
					if (character.GetOrganizationInfo().Grade >= 6)
					{
						_highGradeCharacters.Add(charId);
					}
					else
					{
						_normalCharacters.Add(charId);
					}
				}
			}
		}
		foreach (int charId2 in _highGradeCharacters)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId2, out var character2))
			{
				DomainManager.Character.LeaveGroup(context, character2);
				DomainManager.Character.GroupMove(context, character2, _location);
				Events.RaiseCharacterLocationChanged(context, charId2, _location, Location.Invalid);
				character2.ActiveExternalRelationState(context, 4uL);
			}
		}
		foreach (int charId3 in _normalCharacters)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId3, out var character3))
			{
				DomainManager.Character.LeaveGroup(context, character3);
				DomainManager.Character.GroupMove(context, character3, _location);
				Events.RaiseCharacterLocationChanged(context, charId3, _location, Location.Invalid);
				character3.ActiveExternalRelationState(context, 4uL);
			}
		}
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 20;
		totalSize = ((_highGradeCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _highGradeCharacters.Count)));
		totalSize = ((_normalCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _normalCharacters.Count)));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = DynamicActionType;
		pCurrData += 2;
		*(short*)pCurrData = 7;
		pCurrData += 2;
		if (_highGradeCharacters != null)
		{
			int elementsCount = _highGradeCharacters.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _highGradeCharacters[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_normalCharacters != null)
		{
			int elementsCount2 = _normalCharacters.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = _normalCharacters[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += _location.Serialize(pCurrData);
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
		pCurrData += 2;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (_highGradeCharacters == null)
				{
					_highGradeCharacters = new List<int>(elementsCount);
				}
				else
				{
					_highGradeCharacters.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					_highGradeCharacters.Add(((int*)pCurrData)[i]);
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				_highGradeCharacters?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (_normalCharacters == null)
				{
					_normalCharacters = new List<int>(elementsCount2);
				}
				else
				{
					_normalCharacters.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					_normalCharacters.Add(((int*)pCurrData)[j]);
				}
				pCurrData += 4 * elementsCount2;
			}
			else
			{
				_normalCharacters?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			pCurrData += _location.Deserialize(pCurrData);
		}
		if (fieldCount > 3)
		{
			pCurrData += Key.Deserialize(pCurrData);
		}
		if (fieldCount > 4)
		{
			State = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 5)
		{
			Month = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 6)
		{
			LastFinishDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
