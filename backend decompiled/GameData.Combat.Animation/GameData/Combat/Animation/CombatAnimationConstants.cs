using System.Collections.Generic;

namespace GameData.Combat.Animation;

public static class CombatAnimationConstants
{
	public const string IdleAni = "C_000";

	public const string WeakIdleAni = "C_000";

	public const string WalkForwardAni = "M_001";

	public const string WalkBackwardAni = "M_002";

	public const string WalkForwardFastAni = "MR_001";

	public const string WalkBackwardFastAni = "MR_002";

	public static readonly IReadOnlyList<string> InjuryAni = new string[3] { "H_003", "H_004", "H_005" };

	public static readonly IReadOnlyList<string> AvoidAni = new string[4] { "H_002", "H_001", "H_000", "H_002" };

	public static readonly IReadOnlyList<string> SpecialCharBlockAni = new string[2] { "T_001_0_1", "T_001_0_2" };

	public static readonly IReadOnlyList<string> WinAni = new string[2] { "C_017_female", "C_017" };

	public static readonly IReadOnlyList<string> WinAniLoop = new string[2] { "C_018_female", "C_018" };

	public static readonly IReadOnlyList<string> SelfAvoidParticle = new string[4] { "Particle_H_xieli", "Particle_H_chaizhao", "Particle_H_shanbi", "Particle_H_shouxin" };

	public static readonly IReadOnlyList<string> EnemyAvoidParticle = new string[4] { "Particle_H_xieli_1", "Particle_H_chaizhao_1", "Particle_H_shanbi_1", "Particle_H_shouxin_1" };

	public static string GetAvoidParticle(bool ally, sbyte hitType)
	{
		return (ally ? SelfAvoidParticle : EnemyAvoidParticle)[hitType];
	}
}
