using Config;
using GameData.Domains.Combat;

namespace GameData.Domains.Character.Ai;

public readonly ref struct SimulateCombatArgs
{
	public readonly CombatType CombatType;

	public readonly int KillBaseChance;

	public readonly int KidnapBaseChance;

	public readonly int ReleaseBaseChance;

	public SimulateCombatArgs(CombatType combatType, int killBaseChance, int kidnapBaseChance, int releaseBaseChance)
	{
		CombatType = combatType;
		KillBaseChance = killBaseChance;
		KidnapBaseChance = kidnapBaseChance;
		ReleaseBaseChance = releaseBaseChance;
	}

	public SimulateCombatArgs(PlanningActionItem actionCfg)
	{
		CombatType = (CombatType)actionCfg.CombatType;
		KillBaseChance = actionCfg.KillBaseChance;
		KidnapBaseChance = actionCfg.KidnapBaseChance;
		ReleaseBaseChance = actionCfg.ReleaseBaseChance;
	}
}
