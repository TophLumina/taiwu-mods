using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.Creation;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions.CustomActions;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class FulongStoryAdventureThreeTriggerAction : MonthlyActionBase, IDynamicAction, ISerializableGameData
{
	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	private int _leaderId;

	[SerializableGameDataField]
	private int _participant1;

	[SerializableGameDataField]
	private int _participant2;

	[SerializableGameDataField]
	private int _participant3;

	[SerializableGameDataField]
	private int _participant4;

	[SerializableGameDataField]
	private int _participant5;

	[SerializableGameDataField]
	private int _participant6;

	[SerializableGameDataField]
	private int _participant7;

	public const string LeaderNameStr = "MajorCharacter_0_0";

	public const string Participant1NameStr = "MajorCharacter_0_1";

	public const string Participant2NameStr = "MajorCharacter_0_2";

	public const string Participant3NameStr = "MajorCharacter_0_3";

	public const string Participant4NameStr = "MajorCharacter_0_4";

	public const string Participant5NameStr = "MajorCharacter_0_5";

	public const string Participant6NameStr = "MajorCharacter_0_6";

	public const string Participant7NameStr = "MajorCharacter_0_7";

	public short DynamicActionType => 6;

	public FulongStoryAdventureThreeTriggerAction()
	{
		InitCharacterId();
		Location = Location.Invalid;
	}

	public override void MonthlyHandler()
	{
	}

	public override void TriggerAction()
	{
		if (State == 0)
		{
			DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
			Settlement settlement = GetSettlement();
			Location = settlement.GetLocation();
			if (DomainManager.Adventure.TryCreateAdventureSite(context, Location.AreaId, Location.BlockId, 13, Key))
			{
				DomainManager.Adventure.ActivateAdventureSite(context, Location.AreaId, Location.BlockId);
				DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 14, SectMainStoryEventArgKey.DefValue.FulongAdventureThreeCountDown, 3);
				DomainManager.World.TriggerExtraTask(context, 47, 305);
				CallLeader(context);
				CallParticipant(context, ref _participant1);
				CallParticipant(context, ref _participant2);
				CallParticipant(context, ref _participant3);
				CallParticipant(context, ref _participant4);
				CallParticipant(context, ref _participant5);
				CallParticipant(context, ref _participant6);
				CallParticipant(context, ref _participant7);
			}
		}
	}

	public override void CollectCalledCharacters(HashSet<int> calledCharacters)
	{
		if (_leaderId >= 0)
		{
			calledCharacters.Add(_leaderId);
		}
		if (_participant1 >= 0)
		{
			calledCharacters.Add(_participant1);
		}
		if (_participant2 >= 0)
		{
			calledCharacters.Add(_participant2);
		}
		if (_participant3 >= 0)
		{
			calledCharacters.Add(_participant3);
		}
		if (_participant4 >= 0)
		{
			calledCharacters.Add(_participant4);
		}
		if (_participant5 >= 0)
		{
			calledCharacters.Add(_participant5);
		}
		if (_participant6 >= 0)
		{
			calledCharacters.Add(_participant6);
		}
		if (_participant7 >= 0)
		{
			calledCharacters.Add(_participant7);
		}
	}

	public override void Deactivate(bool isComplete)
	{
		State = 0;
		Month = 0;
		LastFinishDate = DomainManager.World.GetCurrDate();
		Location = Location.Invalid;
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		ReleaseCharacter(context, _leaderId);
		ReleaseCharacter(context, _participant1);
		ReleaseCharacter(context, _participant2);
		ReleaseCharacter(context, _participant3);
		ReleaseCharacter(context, _participant4);
		ReleaseCharacter(context, _participant5);
		ReleaseCharacter(context, _participant6);
		ReleaseCharacter(context, _participant7);
		InitCharacterId();
		if (!isComplete)
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.FulongEndEffect(goodEnd: false, adventureComplete: false);
		}
	}

	public override MonthlyActionBase CreateCopy()
	{
		return GameData.Serializer.Serializer.CreateCopy(this);
	}

	public override void EnsurePrerequisites()
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		if (IsLeaderOutdated())
		{
			ReleaseCharacter(context, _leaderId);
			_leaderId = -1;
			CallLeader(context);
		}
		HandleParticipantOutdated(context, ref _participant1);
		HandleParticipantOutdated(context, ref _participant2);
		HandleParticipantOutdated(context, ref _participant3);
		HandleParticipantOutdated(context, ref _participant4);
		HandleParticipantOutdated(context, ref _participant5);
		HandleParticipantOutdated(context, ref _participant6);
		HandleParticipantOutdated(context, ref _participant7);
	}

	private Settlement GetSettlement()
	{
		return DomainManager.Organization.GetSettlementByOrgTemplateId(14);
	}

	public override void FillEventArgBox(EventArgBox eventArgBox)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		if (_leaderId > 0 && DomainManager.Character.TryGetElement_Objects(_leaderId, out var leader))
		{
			AdaptableLog.Info($"Adding 1 major characters {leader} to adventure.");
			eventArgBox.Set("MajorCharacter_0_0", _leaderId);
		}
		FillParticipantEventArgBox(context, eventArgBox, _participant1, "MajorCharacter_0_1", 0, 2);
		FillParticipantEventArgBox(context, eventArgBox, _participant2, "MajorCharacter_0_2", 3, 5);
		FillParticipantEventArgBox(context, eventArgBox, _participant3, "MajorCharacter_0_3", 3, 5);
		FillParticipantEventArgBox(context, eventArgBox, _participant4, "MajorCharacter_0_4", 0, 2);
		FillParticipantEventArgBox(context, eventArgBox, _participant5, "MajorCharacter_0_5", 3, 5);
		FillParticipantEventArgBox(context, eventArgBox, _participant6, "MajorCharacter_0_6", 3, 5);
		FillParticipantEventArgBox(context, eventArgBox, _participant7, "MajorCharacter_0_7", 3, 5);
		eventArgBox.Set("MajorCharacter_0_Count", 8);
	}

	private GameData.Domains.Character.Character CreateTemporaryIntelligentParticipant(DataContext context, EventArgBox eventArgBox, string participant1NameStr, sbyte grade)
	{
		Settlement settlement = GetSettlement();
		OrganizationItem orgTemplate = Config.Organization.Instance[(sbyte)14];
		sbyte gender = orgTemplate.GenderRestriction;
		if (gender < 0)
		{
			gender = Gender.GetRandom(context.Random);
		}
		sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(settlement.GetLocation().AreaId);
		short charTemplateId = OrganizationDomain.GetCharacterTemplateId(orgTemplate.TemplateId, stateTemplateId, gender);
		TemporaryIntelligentCharacterCreationInfo tempCreationInfo = new TemporaryIntelligentCharacterCreationInfo
		{
			Location = Location,
			CharTemplateId = charTemplateId,
			OrgInfo = new OrganizationInfo(orgTemplate.TemplateId, grade, principal: true, settlement.GetId())
		};
		GameData.Domains.Character.Character character = DomainManager.Character.CreateTemporaryIntelligentCharacter(context, ref tempCreationInfo);
		OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(tempCreationInfo.OrgInfo);
		var (surname, givenName) = CharacterDomain.GetRealName(character);
		AdaptableLog.TagInfo("MartialArtTournamentMonthlyAction", $"Creating temporary character {orgTemplate.Name}-{orgMemberCfg.GradeName} {surname}{givenName}({character.GetId()})");
		int charId = character.GetId();
		AdaptableLog.Info($"Adding 1 temporary major characters {character} to adventure.");
		eventArgBox.Set(participant1NameStr, charId);
		return character;
	}

	private void CallLeader(DataContext context)
	{
		Tester.Assert(_leaderId < 0);
		Settlement settlement = GetSettlement();
		GameData.Domains.Character.Character leader = settlement.GetLeader();
		if (leader != null && leader.GetAgeGroup() == 2)
		{
			_leaderId = leader.GetId();
			DomainManager.Character.LeaveGroup(context, leader);
			DomainManager.Character.GroupMove(context, leader, Location);
			Events.RaiseCharacterLocationChanged(context, _leaderId, Location, Location.Invalid);
			leader.ActiveExternalRelationState(context, 4uL);
		}
	}

	private bool IsLeaderOutdated()
	{
		if (_leaderId < 0)
		{
			return true;
		}
		if (!DomainManager.Character.TryGetElement_Objects(_leaderId, out var leader))
		{
			return true;
		}
		if (leader.GetOrganizationInfo().Grade != 8)
		{
			return true;
		}
		if (leader.GetKidnapperId() >= 0)
		{
			return true;
		}
		if (leader.GetAgeGroup() < 2)
		{
			return true;
		}
		if (leader.GetLocation() != Location)
		{
			return true;
		}
		return false;
	}

	private static void ReleaseCharacter(DataContext context, int charId)
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

	private void CallParticipant(DataContext context, ref int participantId)
	{
		Tester.Assert(participantId < 0);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Settlement settlement = GetSettlement();
		List<int> charIds = new List<int>();
		settlement.GetMembers().GetAllMembers(charIds);
		short maxFavorType = 1;
		for (int i = 0; i < charIds.Count; i++)
		{
			int charId = charIds[i];
			if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				continue;
			}
			OrganizationInfo orgInfo = character.GetOrganizationInfo();
			if ((orgInfo.Grade == 8 && orgInfo.Principal) || character.GetAgeGroup() < 2 || character.IsActiveExternalRelationState(4uL))
			{
				continue;
			}
			sbyte favorType = DomainManager.Character.GetFavorabilityType(charId, taiwu.GetId());
			if (favorType >= 2)
			{
				if (DomainManager.Character.HasRelation(taiwu.GetId(), charId, 1) || DomainManager.Character.HasRelation(taiwu.GetId(), charId, 8) || DomainManager.Character.HasRelation(taiwu.GetId(), charId, 2) || DomainManager.Character.HasRelation(taiwu.GetId(), charId, 16) || DomainManager.Character.HasRelation(taiwu.GetId(), charId, 1024) || DomainManager.Character.HasRelation(taiwu.GetId(), charId, 4) || DomainManager.Character.HasRelation(taiwu.GetId(), charId, 32))
				{
					participantId = charId;
					break;
				}
				if (DomainManager.Character.HasRelation(taiwu.GetId(), charId, 512) || (DomainManager.Character.HasRelation(taiwu.GetId(), charId, 16384) && DomainManager.Character.HasRelation(charId, taiwu.GetId(), 16384)))
				{
					participantId = charId;
					break;
				}
				if (DomainManager.Character.HasRelation(taiwu.GetId(), charId, 8192) || DomainManager.Character.HasRelation(taiwu.GetId(), charId, 2048) || DomainManager.Character.HasRelation(taiwu.GetId(), charId, 4096))
				{
					participantId = charId;
					break;
				}
				if (favorType > maxFavorType)
				{
					maxFavorType = favorType;
					participantId = charId;
				}
			}
		}
		if (participantId >= 0)
		{
			GameData.Domains.Character.Character participant = DomainManager.Character.GetElement_Objects(participantId);
			DomainManager.Character.LeaveGroup(context, participant);
			DomainManager.Character.GroupMove(context, participant, Location);
			Events.RaiseCharacterLocationChanged(context, _leaderId, Location, Location.Invalid);
			participant.ActiveExternalRelationState(context, 4uL);
		}
	}

	private bool IsParticipantOutdated(int participantId)
	{
		if (participantId < 0)
		{
			return true;
		}
		if (!DomainManager.Character.TryGetElement_Objects(participantId, out var participant))
		{
			return true;
		}
		if (participant.GetKidnapperId() >= 0)
		{
			return true;
		}
		if (participant.GetLocation() != Location)
		{
			return true;
		}
		return false;
	}

	private void InitCharacterId()
	{
		_leaderId = -1;
		_participant1 = -1;
		_participant2 = -1;
		_participant3 = -1;
		_participant4 = -1;
		_participant5 = -1;
		_participant6 = -1;
		_participant7 = -1;
	}

	private void HandleParticipantOutdated(DataContext context, ref int characterId)
	{
		if (IsParticipantOutdated(characterId))
		{
			ReleaseCharacter(context, characterId);
			characterId = -1;
			CallParticipant(context, ref characterId);
		}
	}

	private void FillParticipantEventArgBox(DataContext context, EventArgBox eventArgBox, int characterId, string nameStr, sbyte gradeLow, sbyte gradeHigh)
	{
		if (characterId < 0 || !DomainManager.Character.TryGetElement_Objects(characterId, out var character))
		{
			CreateTemporaryIntelligentParticipant(context, eventArgBox, nameStr, (sbyte)context.Random.Next(gradeLow, gradeHigh + 1));
			return;
		}
		AdaptableLog.Info($"Adding 1 major characters {character} to adventure.");
		eventArgBox.Set(nameStr, characterId);
	}

	public override bool IsSerializedSizeFixed()
	{
		return true;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 50;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = DynamicActionType;
		pCurrData += 2;
		pCurrData += Location.Serialize(pCurrData);
		*(int*)pCurrData = _leaderId;
		pCurrData += 4;
		*(int*)pCurrData = _participant1;
		pCurrData += 4;
		*(int*)pCurrData = _participant2;
		pCurrData += 4;
		*(int*)pCurrData = _participant3;
		pCurrData += 4;
		*(int*)pCurrData = _participant4;
		pCurrData += 4;
		*(int*)pCurrData = _participant5;
		pCurrData += 4;
		*(int*)pCurrData = _participant6;
		pCurrData += 4;
		*(int*)pCurrData = _participant7;
		pCurrData += 4;
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
		_leaderId = *(int*)pCurrData;
		pCurrData += 4;
		_participant1 = *(int*)pCurrData;
		pCurrData += 4;
		_participant2 = *(int*)pCurrData;
		pCurrData += 4;
		_participant3 = *(int*)pCurrData;
		pCurrData += 4;
		_participant4 = *(int*)pCurrData;
		pCurrData += 4;
		_participant5 = *(int*)pCurrData;
		pCurrData += 4;
		_participant6 = *(int*)pCurrData;
		pCurrData += 4;
		_participant7 = *(int*)pCurrData;
		pCurrData += 4;
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
