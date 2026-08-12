using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.Creation;
using GameData.Domains.Character.Filters;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.MonthlyEventActions.CustomActions;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ShixiangStoryAdventureTriggerAction : MonthlyActionBase, IDynamicAction, ISerializableGameData
{
	[SerializableGameDataField]
	public Location Location;

	[SerializableGameDataField]
	private int _sectLeaderId;

	[SerializableGameDataField]
	private int _literatiId;

	public short DynamicActionType => 2;

	public ShixiangStoryAdventureTriggerAction()
	{
		_sectLeaderId = -1;
		_literatiId = -1;
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
			if (DomainManager.Adventure.TryCreateAdventureSite(context, Location.AreaId, Location.BlockId, 21, Key))
			{
				DomainManager.Adventure.ActivateAdventureSite(context, Location.AreaId, Location.BlockId);
				CallShixiangLeader(context);
				CallLiterati(context);
				DomainManager.World.GetMonthlyNotificationCollection().AddSectMainStoryShixiangAdventure();
				DomainManager.World.TriggerExtraTask(context, 31, 186);
			}
		}
	}

	public override void CollectCalledCharacters(HashSet<int> calledCharacters)
	{
		if (_sectLeaderId >= 0)
		{
			calledCharacters.Add(_sectLeaderId);
		}
		if (_literatiId >= 0)
		{
			calledCharacters.Add(_literatiId);
		}
	}

	public override void Deactivate(bool isComplete)
	{
		State = 0;
		Month = 0;
		LastFinishDate = DomainManager.World.GetCurrDate();
		Location = Location.Invalid;
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		ReleaseCharacter(context, _sectLeaderId);
		ReleaseCharacter(context, _literatiId);
		_sectLeaderId = -1;
		_literatiId = -1;
		if (!isComplete)
		{
			int nextAppearDate = LastFinishDate + 3;
			DomainManager.Extra.SaveArgToSectMainStoryEventArgBox(context, 6, SectMainStoryEventArgKey.DefValue.ShixiangAdventureAppearDate, nextAppearDate);
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
			ReleaseCharacter(context, _sectLeaderId);
			_sectLeaderId = -1;
			CallShixiangLeader(context);
		}
		if (IsLiteratiOutdated())
		{
			ReleaseCharacter(context, _literatiId);
			_literatiId = -1;
			CallLiterati(context);
		}
	}

	public override void FillEventArgBox(EventArgBox eventArgBox)
	{
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		if (_sectLeaderId < 0 || !DomainManager.Character.TryGetElement_Objects(_sectLeaderId, out var leader))
		{
			Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(6);
			OrganizationItem orgTemplate = Config.Organization.Instance[(sbyte)6];
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
				OrgInfo = new OrganizationInfo(orgTemplate.TemplateId, 8, principal: true, settlement.GetId())
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
			eventArgBox.Set("MajorCharacter_0_0", _sectLeaderId);
		}
		if (_literatiId < 0 || !DomainManager.Character.TryGetElement_Objects(_literatiId, out var literati))
		{
			Settlement settlement2 = DomainManager.Organization.GetSettlementByOrgTemplateId(26);
			OrganizationItem orgTemplate2 = Config.Organization.Instance[(sbyte)26];
			sbyte gender2 = 1;
			sbyte stateTemplateId2 = DomainManager.Map.GetStateTemplateIdByAreaId(settlement2.GetLocation().AreaId);
			short charTemplateId2 = OrganizationDomain.GetCharacterTemplateId(orgTemplate2.TemplateId, stateTemplateId2, gender2);
			TemporaryIntelligentCharacterCreationInfo tempCreationInfo2 = new TemporaryIntelligentCharacterCreationInfo
			{
				Location = Location,
				CharTemplateId = charTemplateId2,
				OrgInfo = new OrganizationInfo(orgTemplate2.TemplateId, 5, principal: true, settlement2.GetId())
			};
			GameData.Domains.Character.Character character2 = DomainManager.Character.CreateTemporaryIntelligentCharacter(context, ref tempCreationInfo2);
			OrganizationMemberItem orgMemberCfg2 = OrganizationDomain.GetOrgMemberConfig(tempCreationInfo2.OrgInfo);
			var (surname2, givenName2) = CharacterDomain.GetRealName(character2);
			AdaptableLog.TagInfo("MartialArtTournamentMonthlyAction", $"Creating temporary character {orgTemplate2.Name}-{orgMemberCfg2.GradeName} {surname2}{givenName2}({character2.GetId()})");
			int charId2 = character2.GetId();
			AdaptableLog.Info($"Adding 1 temporary major characters {character2} to adventure.");
			eventArgBox.Set("MajorCharacter_0_1", charId2);
		}
		else
		{
			AdaptableLog.Info($"Adding 1 major characters {literati} to adventure.");
			eventArgBox.Set("MajorCharacter_0_1", _literatiId);
		}
		eventArgBox.Set("MajorCharacter_0_Count", 2);
	}

	private void CallShixiangLeader(DataContext context)
	{
		Tester.Assert(_sectLeaderId < 0);
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(6);
		GameData.Domains.Character.Character leader = settlement.GetLeader();
		if (leader != null && !leader.IsActiveExternalRelationState(188uL) && leader.GetKidnapperId() < 0 && leader.GetAgeGroup() != 0)
		{
			_sectLeaderId = leader.GetId();
			DomainManager.Character.LeaveGroup(context, leader);
			DomainManager.Character.GroupMove(context, leader, Location);
			Events.RaiseCharacterLocationChanged(context, _sectLeaderId, Location, Location.Invalid);
			leader.ActiveExternalRelationState(context, 4uL);
		}
	}

	private void CallLiterati(DataContext context)
	{
		List<GameData.Domains.Character.Character> targetList = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		List<short> areaList = ObjectPool<List<short>>.Instance.Get();
		targetList.Clear();
		areaList.Clear();
		sbyte stateId = DomainManager.Map.GetStateIdByAreaId(Location.AreaId);
		DomainManager.Map.GetAllAreaInState(stateId, areaList);
		MapCharacterFilter.ParallelFind(IsLiteratiValid, targetList, areaList);
		if (targetList.Count > 0)
		{
			GameData.Domains.Character.Character selectedChar = targetList.GetRandom(context.Random);
			_literatiId = selectedChar.GetId();
			DomainManager.Character.LeaveGroup(context, selectedChar);
			DomainManager.Character.GroupMove(context, selectedChar, Location);
			Events.RaiseCharacterLocationChanged(context, _sectLeaderId, Location, Location.Invalid);
			selectedChar.ActiveExternalRelationState(context, 4uL);
		}
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(targetList);
		ObjectPool<List<short>>.Instance.Return(areaList);
	}

	private static bool IsLiteratiValid(GameData.Domains.Character.Character character)
	{
		if (character.GetAgeGroup() != 2)
		{
			return false;
		}
		if (character.GetGender() != 1)
		{
			return false;
		}
		if (character.IsActiveExternalRelationState(188uL))
		{
			return false;
		}
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (!Config.Organization.Instance[orgInfo.OrgTemplateId].IsCivilian)
		{
			return false;
		}
		if (orgInfo.Grade != 5)
		{
			return false;
		}
		if (character.GetKidnapperId() >= 0)
		{
			return false;
		}
		return true;
	}

	private bool IsLeaderOutdated()
	{
		if (_sectLeaderId < 0)
		{
			return true;
		}
		if (!DomainManager.Character.TryGetElement_Objects(_sectLeaderId, out var leader))
		{
			return true;
		}
		OrganizationInfo orgInfo = leader.GetOrganizationInfo();
		if (orgInfo.OrgTemplateId != 6)
		{
			return true;
		}
		if (orgInfo.Grade != 8)
		{
			return true;
		}
		if (!orgInfo.Principal)
		{
			return true;
		}
		if (leader.GetKidnapperId() >= 0)
		{
			return true;
		}
		if (leader.GetAgeGroup() == 0)
		{
			return true;
		}
		if (leader.GetLocation() != Location)
		{
			return true;
		}
		return false;
	}

	private bool IsLiteratiOutdated()
	{
		if (_literatiId < 0)
		{
			return true;
		}
		if (!DomainManager.Character.TryGetElement_Objects(_literatiId, out var character))
		{
			return true;
		}
		if (character.GetAgeGroup() != 2)
		{
			return true;
		}
		if (character.GetGender() != 1)
		{
			return true;
		}
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (!Config.Organization.Instance[orgInfo.OrgTemplateId].IsCivilian)
		{
			return true;
		}
		if (orgInfo.Grade != 5)
		{
			return true;
		}
		if (character.GetLocation() != Location)
		{
			return true;
		}
		if (character.GetKidnapperId() >= 0)
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
		int totalSize = 26;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe override int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = DynamicActionType;
		pCurrData += 2;
		pCurrData += Location.Serialize(pCurrData);
		*(int*)pCurrData = _sectLeaderId;
		pCurrData += 4;
		*(int*)pCurrData = _literatiId;
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
		_sectLeaderId = *(int*)pCurrData;
		pCurrData += 4;
		_literatiId = *(int*)pCurrData;
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
