using Config;
using Redzen.Random;

namespace GameData.Domains.Character.Mission;

public class RelationMissionCollection : ICharacterMissionCollection
{
	private readonly CharacterMissionItem[] _missions = new CharacterMissionItem[5];

	public void RegisterMission(CharacterMissionItem mission)
	{
		_missions[mission.RequiredBehaviorType] = mission;
	}

	public CharacterMissionItem GetMission(IRandomSource random, Character character)
	{
		return _missions[character.GetBehaviorType()];
	}
}
