using Config;
using GameData.Domains.Organization;
using Redzen.Random;

namespace GameData.Domains.Character.Mission;

public class SectMissionCollection : ICharacterMissionCollection
{
	private readonly CharacterMissionItem[] _missions = new CharacterMissionItem[15];

	public void RegisterMission(CharacterMissionItem mission)
	{
		sbyte index = OrganizationDomain.GetLargeSectIndex(mission.RequiredOrganization);
		_missions[index] = mission;
	}

	public CharacterMissionItem GetMission(IRandomSource random, Character character)
	{
		sbyte orgTemplateId = character.GetOrganizationInfo().OrgTemplateId;
		sbyte index = OrganizationDomain.GetLargeSectIndex(orgTemplateId);
		return (index < 0) ? null : _missions[index];
	}
}
