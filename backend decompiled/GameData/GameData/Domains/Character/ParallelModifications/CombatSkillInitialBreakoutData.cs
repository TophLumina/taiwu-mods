using GameData.Domains.CombatSkill;

namespace GameData.Domains.Character.ParallelModifications;

public struct CombatSkillInitialBreakoutData(GameData.Domains.CombatSkill.CombatSkill combatSkill, ushort activationState, sbyte breakoutStepsCount, sbyte forceBreakoutStepsCount)
{
	public readonly GameData.Domains.CombatSkill.CombatSkill CombatSkill = combatSkill;

	public readonly ushort ActivationState = activationState;

	public readonly sbyte BreakoutStepsCount = breakoutStepsCount;

	public readonly sbyte ForceBreakoutStepsCount = forceBreakoutStepsCount;

	public short ObtainedNeili = 0;
}
