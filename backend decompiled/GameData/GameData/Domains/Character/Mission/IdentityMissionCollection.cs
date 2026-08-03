using System.Collections.Generic;
using Config;
using Redzen.Random;

namespace GameData.Domains.Character.Mission;

public class IdentityMissionCollection : ICharacterMissionCollection
{
	private readonly Dictionary<short, CharacterMissionItem> _missions = new Dictionary<short, CharacterMissionItem>();

	public void RegisterMission(CharacterMissionItem mission)
	{
		_missions.Add(mission.RequiredOrgMember, mission);
	}

	public CharacterMissionItem GetMission(IRandomSource random, Character character)
	{
		OrganizationMemberItem memberConfig = character.GetOrganizationInfo().GetOrgMemberConfig();
		return _missions.GetValueOrDefault(memberConfig.TemplateId);
	}
}
