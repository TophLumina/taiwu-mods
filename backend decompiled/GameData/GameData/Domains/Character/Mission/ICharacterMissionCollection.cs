using Config;
using Redzen.Random;

namespace GameData.Domains.Character.Mission;

public interface ICharacterMissionCollection
{
	void RegisterMission(CharacterMissionItem mission);

	CharacterMissionItem GetMission(IRandomSource random, Character character);
}
