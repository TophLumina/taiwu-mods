using System;
using Config;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character.Mission;

public class LifeSkillMissionCollection : ICharacterMissionCollection
{
	private readonly CharacterMissionItem[] _missions = new CharacterMissionItem[16];

	public void RegisterMission(CharacterMissionItem mission)
	{
		_missions[mission.LifeSkillType] = mission;
	}

	public CharacterMissionItem GetMission(IRandomSource random, Character character)
	{
		Span<(sbyte, int)> span = stackalloc(sbyte, int)[3];
		SpanList<(sbyte, int)> top3 = span;
		LifeSkillShorts attainments = character.GetLifeSkillAttainments();
		for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
		{
			top3.TryInsertTopK<sbyte>(3, lifeSkillType, (int)attainments[lifeSkillType]);
		}
		sbyte selectedLifeSkillType = top3.GetRandom(random).Item1;
		return _missions[selectedLifeSkillType];
	}
}
