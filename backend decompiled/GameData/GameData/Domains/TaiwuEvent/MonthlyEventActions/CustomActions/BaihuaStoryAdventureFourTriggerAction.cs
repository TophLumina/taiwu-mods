using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.Creation;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions.CustomActions;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class BaihuaStoryAdventureFourTriggerAction : MonthlyActionBase, IDynamicAction, ISerializableGameData
{
	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	private int _leaderId;

	public const string CharacterNameStr = "MajorCharacter_0_0";

	public short DynamicActionType => 4;

	public BaihuaStoryAdventureFourTriggerAction()
	{
		_leaderId = -1;
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
			Settlement settlement = GetVillageSettlement();
			Location = settlement.GetLocation();
			if (DomainManager.Adventure.TryCreateAdventureSite(context, Location.AreaId, Location.BlockId, 26, Key))
			{
				DomainManager.Adventure.ActivateAdventureSite(context, Location.AreaId, Location.BlockId);
				CallVillageLeader(context);
			}
		}
	}

	public override void CollectCalledCharacters(HashSet<int> calledCharacters)
	{
		if (_leaderId >= 0)
		{
			calledCharacters.Add(_leaderId);
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
		_leaderId = -1;
		if (!isComplete)
		{
			int nextAppearDate = LastFinishDate + 1;
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 3, SectMainStoryEventArgKey.DefValue.BaihuaAdventureFourAppearDate, nextAppearDate);
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
			CallVillageLeader(context);
		}
	}

	private Settlement GetVillageSettlement()
	{
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(3);
		short settlementId = -1;
		argBox.Get(SectMainStoryEventArgKey.DefValue.BaihuaVillageSettlementIdSelection, ref settlementId);
		return DomainManager.Organization.GetSettlement(settlementId);
	}

	public override void FillEventArgBox(EventArgBox eventArgBox)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		if (_leaderId < 0 || !DomainManager.Character.TryGetElement_Objects(_leaderId, out var leader))
		{
			Settlement settlement = GetVillageSettlement();
			OrganizationItem orgTemplate = null;
			orgTemplate = ((settlement.GetOrgTemplateId() == 37) ? Config.Organization.Instance[(sbyte)37] : ((settlement.GetOrgTemplateId() != 36) ? Config.Organization.Instance[(sbyte)38] : Config.Organization.Instance[(sbyte)36]));
			sbyte gender = orgTemplate.GenderRestriction;
			if (gender < 0)
			{
				gender = Gender.GetRandom(context.Random);
			}
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(settlement.GetLocation().AreaId);
			short charTemplateId = OrganizationDomain.GetCharacterTemplateId(orgTemplate.TemplateId, stateTemplateId, gender);
			sbyte grade = (sbyte)((context.Random.Next(0, 2) == 0) ? 6 : 7);
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
			eventArgBox.Set("MajorCharacter_0_0", charId);
		}
		else
		{
			AdaptableLog.Info($"Adding 1 major characters {leader} to adventure.");
			eventArgBox.Set("MajorCharacter_0_0", _leaderId);
		}
		eventArgBox.Set("MajorCharacter_0_Count", 1);
	}

	private void CallVillageLeader(DataContext context)
	{
		Tester.Assert(_leaderId < 0);
		Settlement settlement = GetVillageSettlement();
		GameData.Domains.Character.Character leader = settlement.GetAvailableHighMember(8, 6);
		if (leader != null)
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
		OrganizationInfo orgInfo = leader.GetOrganizationInfo();
		if (orgInfo.OrgTemplateId != 36 || orgInfo.OrgTemplateId != 37 || orgInfo.OrgTemplateId != 38)
		{
			return true;
		}
		if (orgInfo.Grade < 6)
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

	public override bool IsSerializedSizeFixed()
	{
		return true;
	}

	public override int GetSerializedSize()
	{
		int totalSize = 22;
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
