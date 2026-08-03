using Config;
using Redzen.Random;

namespace GameData.Domains.Character.Mission;

public class TaiwuMissionCollection : ICharacterMissionCollection
{
	private CharacterMissionItem _mission;

	public void RegisterMission(CharacterMissionItem mission)
	{
		_mission = mission;
	}

	public CharacterMissionItem GetMission(IRandomSource random, Character character)
	{
		return _mission;
	}
}
