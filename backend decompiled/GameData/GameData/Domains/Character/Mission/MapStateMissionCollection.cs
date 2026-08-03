using Config;
using GameData.Domains.Organization;
using Redzen.Random;

namespace GameData.Domains.Character.Mission;

public class MapStateMissionCollection : ICharacterMissionCollection
{
	private readonly CharacterMissionItem[] _missions = new CharacterMissionItem[15];

	public void RegisterMission(CharacterMissionItem mission)
	{
		sbyte stateId = DomainManager.Map.GetStateIdByStateTemplateId(mission.RequiredMapState);
		_missions[stateId] = mission;
	}

	public CharacterMissionItem GetMission(IRandomSource random, Character character)
	{
		short settlementId = character.GetOrganizationInfo().SettlementId;
		if (settlementId < 0)
		{
			return null;
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		short areaId = settlement.GetLocation().AreaId;
		sbyte stateId = DomainManager.Map.GetStateIdByAreaId(areaId);
		return (stateId < 0) ? null : _missions[stateId];
	}
}
