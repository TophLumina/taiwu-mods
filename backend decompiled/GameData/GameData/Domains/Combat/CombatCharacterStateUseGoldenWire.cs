using GameData.Common;

namespace GameData.Domains.Combat;

public class CombatCharacterStateUseGoldenWire : CombatCharacterStateBase
{
	private const string SoundName = "se_boss16_D_002";

	private int _deltaDistance;

	private string AniName => Forward ? "D_002_1" : "D_002_2";

	private string FullAniName => CombatChar.GetWrappedFullAnimationName(AniName);

	private string ParticleName => Forward ? "Particle_boss16_D_002_1" : "Particle_boss16_D_002_2";

	private bool Forward => _deltaDistance <= 0;

	public CombatCharacterStateUseGoldenWire(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.UseGoldenWire)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		base.OnEnter();
		CombatChar.NeedUseGoldenWire = false;
		short attackRangeCenter = CombatChar.GetAttackRange().Average;
		short currentDistance = DomainManager.Combat.GetCurrentDistance();
		_deltaDistance = attackRangeCenter - currentDistance;
		DataContext context = CombatChar.GetDataContext();
		CombatChar.SetAnimationToPlayOnce(AniName, context);
		CombatChar.SetParticleToPlay(ParticleName, context);
		CombatChar.SetSkillSoundToPlay("se_boss16_D_002", context);
		DelayCall(ChangeDistance, AnimDataCollection.GetEventFrame(FullAniName, "hit"));
		DelayCall(CombatChar.StateMachine.TranslateState, AnimDataCollection.GetDurationFrame(FullAniName));
	}

	private void ChangeDistance()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatCharacter mover = DomainManager.Combat.GetCombatCharacter(!CombatChar.IsAlly);
		DomainManager.Combat.ChangeDistance(context, mover, _deltaDistance, isForced: true, canStop: true);
	}
}
