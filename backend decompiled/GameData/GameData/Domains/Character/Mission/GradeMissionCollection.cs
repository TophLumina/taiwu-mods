using Config;
using Redzen.Random;

namespace GameData.Domains.Character.Mission;

public class GradeMissionCollection : ICharacterMissionCollection
{
	private readonly CharacterMissionItem[][] _missions = new CharacterMissionItem[3][]
	{
		new CharacterMissionItem[3],
		new CharacterMissionItem[3],
		new CharacterMissionItem[3]
	};

	public void RegisterMission(CharacterMissionItem mission)
	{
		_missions[mission.RequiredGoodness - -1][mission.RequiredGradeGroup] = mission;
	}

	public CharacterMissionItem GetMission(IRandomSource random, Character character)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		OrganizationItem orgCfg = Config.Organization.Instance[orgInfo.OrgTemplateId];
		sbyte gradeGroup = Grade.GetGroup(orgInfo.Grade);
		return _missions[orgCfg.Goodness - -1][gradeGroup];
	}
}
