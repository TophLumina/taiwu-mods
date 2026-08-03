using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.TaiwuEvent.EventManager;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions.CustomActions;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class MarriageTriggerAction : MonthlyActionBase, IDynamicAction, ISerializableGameData
{
	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	public int SpouseCharId;

	[SerializableGameDataField]
	public List<CharacterSet> ParticipatingCharacterSets;

	public short DynamicActionType => 0;

	public MarriageTriggerAction()
	{
		Key = MonthlyActionKey.Invalid;
		ParticipatingCharacterSets = new List<CharacterSet>();
		Location = Location.Invalid;
		SpouseCharId = -1;
	}

	public override void TriggerAction()
	{
		if (Location.IsValid() && SpouseCharId >= 0 && DomainManager.Character.TryGetElement_Objects(SpouseCharId, out var spouseChar) && !spouseChar.IsCompletelyInfected())
		{
			if (DomainManager.Adventure.TryCreateAdventureSite(DomainManager.TaiwuEvent.MainThreadDataContext, Location.AreaId, Location.BlockId, 53, Key))
			{
				MonthlyEventActionsManager.NewlyTriggered++;
				State = 1;
				CallSpouse();
			}
			else
			{
				Location = Location.Invalid;
			}
		}
	}

	public override void MonthlyHandler()
	{
		if (State != 0)
		{
			DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
			int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
			if (DomainManager.Character.GetAliveSpouse(taiwuCharId) >= 0)
			{
				DomainManager.Adventure.RemoveAdventureSite(context, Location.AreaId, Location.BlockId, isTimeout: false, isComplete: false);
				return;
			}
		}
		if (State == 1)
		{
			CallParticipateCharacters();
			Activate();
			State = 5;
		}
	}

	public override void Activate()
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		MonthlyEventActionsManager.NewlyActivated++;
		DomainManager.Adventure.ActivateAdventureSite(context, Location.AreaId, Location.BlockId);
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		monthlyNotifications.AddMarryNotice(taiwuCharId, SpouseCharId, Location);
	}

	public override void Deactivate(bool isComplete)
	{
		if (!isComplete)
		{
			int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
			MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
			if (DomainManager.Character.GetAliveSpouse(taiwuCharId) >= 0)
			{
				monthlyEventCollection.AddTaiwuAlreadyMarried(taiwuCharId, SpouseCharId);
			}
			else
			{
				monthlyEventCollection.AddTaiwuNotAttendingWedding(taiwuCharId, SpouseCharId);
			}
		}
		State = 0;
		Month = 0;
		LastFinishDate = DomainManager.World.GetCurrDate();
		Location = Location.Invalid;
		ClearCalledCharacters();
	}

	public override MonthlyActionBase CreateCopy()
	{
		return GameData.Serializer.Serializer.CreateCopy(this);
	}

	public override void CollectCalledCharacters(HashSet<int> calledCharacters)
	{
		calledCharacters.Add(SpouseCharId);
		foreach (CharacterSet participatingCharacterSet in ParticipatingCharacterSets)
		{
			calledCharacters.UnionWith(participatingCharacterSet.GetCollection());
		}
	}

	public override void FillEventArgBox(EventArgBox eventArgBox)
	{
		AdaptableLog.Info("Adding major characters to adventure.");
		eventArgBox.Set("MajorCharacter_0_0", SpouseCharId);
		eventArgBox.Set("MajorCharacter_0_Count", 1);
		AdaptableLog.Info("Adding participating characters to adventure.");
		for (int participateCharSetIndex = 0; participateCharSetIndex < ParticipatingCharacterSets.Count; participateCharSetIndex++)
		{
			CharacterSet participateCharSet = ((participateCharSetIndex < ParticipatingCharacterSets.Count) ? ParticipatingCharacterSets[participateCharSetIndex] : default(CharacterSet));
			FillIntelligentCharactersToArgBox(eventArgBox, $"ParticipateCharacter_{participateCharSetIndex}", participateCharSet);
			AdventureCharacterSortUtils.Sort(eventArgBox, isMajorChar: false, participateCharSetIndex, CharacterSortType.CombatPower, ascendingOrder: false);
		}
	}

	private void FillIntelligentCharactersToArgBox(EventArgBox eventArgBox, string keyPrefix, CharacterSet charSet)
	{
		int amountAdded = 0;
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		foreach (int charId in charSet.GetCollection())
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				if (character.IsCrossAreaTraveling())
				{
					DomainManager.Character.GroupMove(context, character, Location);
				}
				if (character.GetLocation().Equals(Location))
				{
					eventArgBox.Set($"{keyPrefix}_{amountAdded}", charId);
					amountAdded++;
				}
			}
		}
		AdaptableLog.Info($"Adding {amountAdded} real characters to adventure.");
		eventArgBox.Set(keyPrefix + "_Count", amountAdded);
	}

	private void ClearCalledCharacters()
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		if (DomainManager.Character.TryGetElement_Objects(SpouseCharId, out var spouseChar))
		{
			spouseChar.DeactivateExternalRelationState(context, 4uL);
			if (spouseChar.GetLeaderId() != DomainManager.Taiwu.GetTaiwuCharId())
			{
				if (spouseChar.IsCompletelyInfected())
				{
					Events.RaiseInfectedCharacterLocationChanged(context, SpouseCharId, Location.Invalid, spouseChar.GetLocation());
				}
				else
				{
					Events.RaiseCharacterLocationChanged(context, SpouseCharId, Location.Invalid, spouseChar.GetLocation());
				}
			}
			short settlementId = spouseChar.GetOrganizationInfo().SettlementId;
			if (settlementId >= 0)
			{
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
				spouseChar.AddTravelTarget(context, new NpcTravelTarget(settlement.GetLocation(), 12));
			}
			SpouseCharId = -1;
		}
		CallCharacterHelper.ClearCalledCharacters(ParticipatingCharacterSets, unHideCharacters: true, removeExternalState: true);
	}

	private void CallSpouse()
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		GameData.Domains.Character.Character spouseChar = DomainManager.Character.GetElement_Objects(SpouseCharId);
		DomainManager.Character.LeaveGroup(context, spouseChar);
		DomainManager.Character.GroupMove(context, spouseChar, Location);
		Events.RaiseCharacterLocationChanged(context, SpouseCharId, Location, Location.Invalid);
		spouseChar.ActiveExternalRelationState(context, 4uL);
	}

	private void CallParticipateCharacters()
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (ParticipatingCharacterSets.Count <= 0)
		{
			ParticipatingCharacterSets.Add(default(CharacterSet));
		}
		CharacterSet taiwuFriendsAndFamilyMembers = ParticipatingCharacterSets[0];
		CallFriendsAndFamilyMembers(context, taiwuCharId, ref taiwuFriendsAndFamilyMembers, 10);
		ParticipatingCharacterSets[0] = taiwuFriendsAndFamilyMembers;
		if (ParticipatingCharacterSets.Count <= 1)
		{
			ParticipatingCharacterSets.Add(default(CharacterSet));
		}
		CharacterSet spouseFriendsAndFamilyMembers = ParticipatingCharacterSets[1];
		CallFriendsAndFamilyMembers(context, SpouseCharId, ref spouseFriendsAndFamilyMembers, 10);
		ParticipatingCharacterSets[1] = spouseFriendsAndFamilyMembers;
		if (ParticipatingCharacterSets.Count <= 2)
		{
			ParticipatingCharacterSets.Add(default(CharacterSet));
		}
		CharacterSet taiwuTwoWayAdoredCharacters = ParticipatingCharacterSets[2];
		CallTwoWayAdoredCharacters(context, taiwuCharId, ref taiwuTwoWayAdoredCharacters, 5);
		ParticipatingCharacterSets[2] = taiwuTwoWayAdoredCharacters;
		if (ParticipatingCharacterSets.Count <= 3)
		{
			ParticipatingCharacterSets.Add(default(CharacterSet));
		}
		CharacterSet spouseTwoWayAdoredCharacters = ParticipatingCharacterSets[3];
		CallTwoWayAdoredCharacters(context, SpouseCharId, ref spouseTwoWayAdoredCharacters, 5);
		ParticipatingCharacterSets[3] = spouseTwoWayAdoredCharacters;
	}

	private void CallFriendsAndFamilyMembers(DataContext context, int charId, ref CharacterSet characterSet, int estimateAmount)
	{
		HashSet<int> relatedCharIds = context.AdvanceMonthRelatedData.RelatedCharIds.Occupy();
		RelatedCharacters relatedChars = DomainManager.Character.GetRelatedCharacters(charId);
		relatedCharIds.UnionWith(relatedChars.BloodParents.GetCollection());
		relatedCharIds.UnionWith(relatedChars.AdoptiveParents.GetCollection());
		relatedCharIds.UnionWith(relatedChars.StepParents.GetCollection());
		relatedCharIds.UnionWith(relatedChars.BloodBrothersAndSisters.GetCollection());
		relatedCharIds.UnionWith(relatedChars.AdoptiveBrothersAndSisters.GetCollection());
		relatedCharIds.UnionWith(relatedChars.StepBrothersAndSisters.GetCollection());
		relatedCharIds.UnionWith(relatedChars.Mentors.GetCollection());
		relatedCharIds.UnionWith(relatedChars.Mentees.GetCollection());
		relatedCharIds.UnionWith(relatedChars.SwornBrothersAndSisters.GetCollection());
		relatedCharIds.UnionWith(relatedChars.Friends.GetCollection());
		relatedCharIds.UnionWith(relatedChars.BloodParents.GetCollection());
		relatedCharIds.UnionWith(relatedChars.AdoptiveParents.GetCollection());
		relatedCharIds.UnionWith(relatedChars.StepParents.GetCollection());
		int calledAmount = 0;
		foreach (int relatedCharId in relatedCharIds)
		{
			if (calledAmount > estimateAmount)
			{
				break;
			}
			if (DomainManager.Character.TryGetElement_Objects(relatedCharId, out var character) && CheckCharacterAvailable(character) && !DomainManager.Character.HasRelation(relatedCharId, charId, 16384))
			{
				if (character.GetLeaderId() >= 0)
				{
					DomainManager.Character.LeaveGroup(context, character);
				}
				DomainManager.Character.GroupMove(context, character, Location);
				character.ActiveExternalRelationState(context, 4uL);
				characterSet.Add(relatedCharId);
				calledAmount++;
			}
		}
		context.AdvanceMonthRelatedData.RelatedCharIds.Release(ref relatedCharIds);
	}

	private void CallTwoWayAdoredCharacters(DataContext context, int charId, ref CharacterSet characterSet, int estimateAmount)
	{
		RelatedCharacters relatedChars = DomainManager.Character.GetRelatedCharacters(charId);
		HashSet<int> adoredCharIds = relatedChars.Adored.GetCollection();
		int calledAmount = 0;
		foreach (int relatedCharId in adoredCharIds)
		{
			if (calledAmount > estimateAmount)
			{
				break;
			}
			if (DomainManager.Character.TryGetElement_Objects(relatedCharId, out var character) && CheckCharacterAvailable(character) && DomainManager.Character.HasRelation(relatedCharId, charId, 16384))
			{
				if (character.GetLeaderId() >= 0)
				{
					DomainManager.Character.LeaveGroup(context, character);
				}
				DomainManager.Character.GroupMove(context, character, Location);
				character.ActiveExternalRelationState(context, 4uL);
				characterSet.Add(relatedCharId);
				calledAmount++;
			}
		}
	}

	private bool CheckCharacterAvailable(GameData.Domains.Character.Character character)
	{
		if (character.IsCompletelyInfected())
		{
			return false;
		}
		if (character.GetLegendaryBookOwnerState() >= 1)
		{
			return false;
		}
		if (character.GetAgeGroup() == 0)
		{
			return false;
		}
		if (!character.GetLocation().IsValid())
		{
			return false;
		}
		if (character.GetCreatingType() != 1)
		{
			return false;
		}
		if (character.GetKidnapperId() >= 0)
		{
			return false;
		}
		if (character.IsActiveExternalRelationState(188uL))
		{
			return false;
		}
		if (DomainManager.Taiwu.IsInGroup(character.GetId()))
		{
			return false;
		}
		return true;
	}

	public override bool IsSerializedSizeFixed()
	{
		return false;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 22;
		if (ParticipatingCharacterSets != null)
		{
			totalSize += 2;
			int elementsCount = ParticipatingCharacterSets.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += ParticipatingCharacterSets[i].GetSerializedSize();
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
		*(short*)pCurrData = DynamicActionType;
		pCurrData += 2;
		pCurrData += Location.Serialize(pCurrData);
		*(int*)pCurrData = SpouseCharId;
		pCurrData += 4;
		if (ParticipatingCharacterSets != null)
		{
			int elementsCount = ParticipatingCharacterSets.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = ParticipatingCharacterSets[i].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
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
		pCurrData += 2;
		pCurrData += Location.Deserialize(pCurrData);
		SpouseCharId = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ParticipatingCharacterSets == null)
			{
				ParticipatingCharacterSets = new List<CharacterSet>(elementsCount);
			}
			else
			{
				ParticipatingCharacterSets.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterSet element = default(CharacterSet);
				pCurrData += element.Deserialize(pCurrData);
				ParticipatingCharacterSets.Add(element);
			}
		}
		else
		{
			ParticipatingCharacterSets?.Clear();
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
