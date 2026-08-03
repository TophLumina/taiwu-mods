using System;
using System.Collections.Generic;
using Config;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.Display;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class OrganizationFunctions
{
	[EventFunction(325)]
	private static void SetSectFunctionStatus(EventScriptRuntime runtime, sbyte orgTemplateId, SectFunctionStatuses.SectFunctionStatusType functionStatusFunctionType, bool isOn)
	{
		DomainManager.Organization.SetSectFunctionStatus(runtime.Context, orgTemplateId, functionStatusFunctionType, isOn);
	}

	[EventFunction(58)]
	private static void SetSectAllowLearning(EventScriptRuntime runtime, Settlement settlement)
	{
		if (settlement is Sect sect)
		{
			byte prevStatus = sect.GetTaiwuExploreStatus();
			if (prevStatus != 2)
			{
				sect.SetTaiwuExploreStatus(2, runtime.Context);
				Events.RaiseTaiwuExploreStatusChanged(runtime.Context, settlement.GetOrgTemplateId(), prevStatus, 2);
			}
		}
	}

	[EventFunction(59)]
	private static void JoinOrganization(EventScriptRuntime runtime, GameData.Domains.Character.Character character, Settlement settlement, sbyte grade)
	{
		OrganizationInfo targetOrgInfo = new OrganizationInfo
		{
			OrgTemplateId = settlement.GetOrgTemplateId(),
			Grade = grade,
			SettlementId = settlement.GetId(),
			Principal = true
		};
		if (character.GetCreatingType() == 2)
		{
			DomainManager.Character.ConvertRandomEnemy(runtime.Context, character, character.GetLocation());
		}
		else if (DomainManager.Character.IsTemporaryIntelligentCharacter(character.GetId()))
		{
			DomainManager.Character.ConvertTemporaryIntelligentCharacter(runtime.Context, character);
		}
		DomainManager.Organization.ChangeOrganization(runtime.Context, character, targetOrgInfo);
		if (16 == settlement.GetOrgTemplateId())
		{
			runtime.Current.RegisterToShowGetCharacter(character.GetId(), EObtainType.Villager);
		}
	}

	[EventFunction(60)]
	private static void SetSectCharApprovedTaiwu(EventScriptRuntime runtime, GameData.Domains.Character.Character character, bool approved)
	{
		int charId = character.GetId();
		if (!DomainManager.Character.IsTemporaryIntelligentCharacter(charId))
		{
			DomainManager.Character.TryCreateRelation(runtime.Context, charId, DomainManager.Taiwu.GetTaiwuCharId());
			SectCharacter sectChar = DomainManager.Organization.GetElement_SectCharacters(charId);
			sectChar.SetApprovedTaiwu(runtime.Context, approved);
		}
	}

	[EventFunction(55)]
	private static void ChangeSafetyForSettlement(EventScriptRuntime runtime, Settlement settlement, int delta)
	{
		settlement.ChangeSafety(runtime.Context, delta);
	}

	[EventFunction(56)]
	private static void ChangeCultureForSettlement(EventScriptRuntime runtime, Settlement settlement, int delta)
	{
		settlement.ChangeCulture(runtime.Context, delta);
	}

	[EventFunction(227)]
	private static void RegisterSettlementMemberFeature(EventScriptRuntime runtime, Settlement settlement, short featureId, sbyte minGrade = 0, sbyte maxGrade = 8)
	{
		OrgMemberCollection members = settlement.GetMembers();
		for (sbyte grade = 0; grade <= 8; grade++)
		{
			HashSet<int> gradeMembers = members.GetMembers(grade);
			if (grade >= minGrade && grade <= maxGrade)
			{
				foreach (int charId in gradeMembers)
				{
					GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
					character.AddFeature(runtime.Context, featureId);
				}
			}
		}
		DomainManager.Organization.RegisterSettlementMemberFeature(runtime.Context, settlement.GetId(), new SettlementMemberFeature
		{
			FeatureId = featureId,
			MinGrade = minGrade,
			MaxGrade = maxGrade
		});
	}

	[EventFunction(226)]
	private static void SetSectSpiritualDebtInteractionOccurred(EventScriptRuntime runtime, sbyte orgTemplateId)
	{
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(orgTemplateId);
		if (!(settlement is Sect sect))
		{
			throw new InvalidCastException($"Unable to cast {settlement} to Sect.");
		}
		sect.SetSpiritualDebtInteractionOccurred(spiritualDebtInteractionOccurred: true, runtime.Context);
	}

	[EventFunction(243)]
	private static short GetMapBlockSettlement(EventScriptRuntime runtime, MapBlockData mapBlock)
	{
		Location rootLocation = mapBlock.GetRootBlock().GetLocation();
		Settlement settlement = DomainManager.Organization.GetSettlementByLocation(rootLocation);
		return settlement.GetId();
	}

	[EventFunction(192)]
	private static short GetRandomSettlementInState(EventScriptRuntime runtime, sbyte stateTemplateId, EOrganizationSettlementType settlementType)
	{
		sbyte stateId = DomainManager.Map.GetStateIdByStateTemplateId(stateTemplateId);
		List<short> settlementIds = ObjectPool<List<short>>.Instance.Get();
		DomainManager.Map.GetStateSettlementIds(stateId, settlementIds, containsMainCity: true, containsSect: true);
		if (settlementType != EOrganizationSettlementType.Invalid)
		{
			for (int i = settlementIds.Count - 1; i >= 0; i--)
			{
				short settlementId = settlementIds[i];
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
				if (settlement.OrganizationConfig.SettlementType != settlementType)
				{
					CollectionUtils.SwapAndRemove(settlementIds, i);
				}
			}
		}
		if (settlementIds.Count == 0)
		{
			return -1;
		}
		short randomSettlementId = settlementIds.GetRandom(runtime.Context.Random);
		ObjectPool<List<short>>.Instance.Return(settlementIds);
		return randomSettlementId;
	}

	[EventFunction(217)]
	private static GameData.Utilities.ShortList GetSettlementListInState(EventScriptRuntime runtime, sbyte stateTemplateId, EOrganizationSettlementType settlementType)
	{
		sbyte stateId = DomainManager.Map.GetStateIdByStateTemplateId(stateTemplateId);
		GameData.Utilities.ShortList shortList = GameData.Utilities.ShortList.Create();
		List<short> settlementIds = shortList.Items;
		DomainManager.Map.GetStateSettlementIds(stateId, settlementIds, containsMainCity: true, containsSect: true);
		if (settlementType != EOrganizationSettlementType.Invalid)
		{
			for (int i = settlementIds.Count - 1; i >= 0; i--)
			{
				short settlementId = settlementIds[i];
				Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
				if (settlement.OrganizationConfig.SettlementType != settlementType)
				{
					CollectionUtils.SwapAndRemove(settlementIds, i);
				}
			}
		}
		return shortList;
	}

	[EventFunction(263)]
	private static short GetCharacterSettlement(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return character.GetOrganizationInfo().SettlementId;
	}

	[EventFunction(481)]
	private static int GetSectSettlement(EventScriptRuntime runtime, sbyte orgTemplateId)
	{
		return DomainManager.Organization.GetSettlementIdByOrgTemplateId(orgTemplateId);
	}

	[EventFunction(154)]
	private static int GetOtherSmallSettlement(EventScriptRuntime runtime, short areaTemplateId, Settlement settlement)
	{
		short areaId = DomainManager.Map.GetAreaIdByAreaTemplateId(areaTemplateId);
		List<short> settlementIds = new List<short>();
		DomainManager.Map.GetAreaSettlementIds(areaId, settlementIds);
		foreach (short item in settlementIds)
		{
			if (item != settlement.GetId())
			{
				return item;
			}
		}
		throw new InvalidOperationException("no available settlement in current area.");
	}

	[EventFunction(475)]
	private static sbyte QuerySettlementSect(EventScriptRuntime runtime, Settlement settlement)
	{
		Location location = settlement.GetLocation();
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(location.AreaId);
		return MapState.Instance[areaData.GetConfig().StateID].SectID;
	}

	[EventFunction(535)]
	private static void AddMaxApprovingRateBonus(EventScriptRuntime runtime, Settlement settlement, short bonus, int duration)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddMaxApprovingRateBonus(settlement.GetId(), bonus, duration);
	}

	[EventFunction(860)]
	private static int GetSettlementLeader(EventScriptRuntime runtime, Settlement settlement, bool createWhenNotExist)
	{
		GameData.Domains.Character.Character leader = settlement.GetLeader();
		if (leader == null && createWhenNotExist)
		{
			leader = settlement.CreateCoreCharacter(runtime.Context, 8);
		}
		return leader?.GetId() ?? (-1);
	}
}
