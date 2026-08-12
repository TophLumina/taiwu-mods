using System;
using Config;

namespace GameData.Domains.Adventure;

public static class SharedMethods
{
	/// <summary>
	/// 获得奇遇的战斗难度
	/// </summary>
	/// <param name="adventureId"></param>
	/// <param name="xiangshuLevel"></param>
	/// <returns></returns>
	public static sbyte GetAdventureCombatDifficulty(short adventureId, sbyte xiangshuLevel)
	{
		Config.AdventureItem config = Config.Adventure.Instance[adventureId];
		return (sbyte)Math.Min(9, config.CombatDifficulty + (config.DifficultyAddXiangshuLevel ? xiangshuLevel : 0));
	}

	/// <summary>
	/// 获得奇遇的技艺难度
	/// </summary>
	/// <param name="adventureId"></param>
	/// <param name="xiangshuLevel"></param>
	/// <returns></returns>
	public static sbyte GetAdventureLifeSkillDifficulty(short adventureId, sbyte xiangshuLevel)
	{
		Config.AdventureItem config = Config.Adventure.Instance[adventureId];
		return (sbyte)Math.Min(9, config.LifeSkillDifficulty + (config.DifficultyAddXiangshuLevel ? xiangshuLevel : 0));
	}
}
