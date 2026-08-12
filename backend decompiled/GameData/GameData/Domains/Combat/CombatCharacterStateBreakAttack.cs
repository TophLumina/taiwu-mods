using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Item;

namespace GameData.Domains.Combat;

public class CombatCharacterStateBreakAttack : CombatCharacterStateBase
{
	private const string CommonParticle = "Particle_A_B0";

	private const string CommonAudio = "se_a_b0";

	private int _leftPrepareFrame;

	private int _leftParticleFrame;

	private int _leftAudioFrame;

	public CombatCharacterStateBreakAttack(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.BreakAttack)
	{
		IsUpdateOnPause = true;
		RequireDelayFallen = true;
	}

	public override void OnEnter()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatChar.NeedBreakAttack = false;
		CombatChar.IsBreakAttacking = true;
		CombatChar.IsAutoNormalAttacking = true;
		Weapon weapon = DomainManager.Item.GetElement_Weapons(CurrentCombatDomain.GetUsingWeaponKey(CombatChar).Id);
		sbyte aniIndex = weapon.GetWeaponAction();
		sbyte trickType = CombatChar.GetWeaponTricks()[CombatChar.GetWeaponTrickIndex()];
		trickType = (sbyte)DomainManager.SpecialEffect.ModifyData(CombatChar.GetId(), -1, 83, trickType);
		CombatChar.SetAttackingTrickType(trickType, context);
		var (aniName, fullAniName) = (PrepareAttackEffect)(ref CombatChar.GetPrepareAttackAni(trickType, aniIndex));
		if (string.IsNullOrEmpty(aniName))
		{
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.Attack);
			return;
		}
		_leftPrepareFrame = AnimDataCollection.GetDurationFrame(fullAniName);
		_leftParticleFrame = AnimDataCollection.GetEventFrame(fullAniName, "break_p0");
		_leftAudioFrame = AnimDataCollection.GetEventFrame(fullAniName, "break_a0");
		CombatChar.SetAnimationToPlayOnce(aniName, context);
		CombatChar.SetAnimationToLoop(null, context);
		DomainManager.Combat.ShowSpecialEffectTips(CombatChar.GetId(), 1662, 0);
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		DataContext context = CombatChar.GetDataContext();
		if (_leftParticleFrame == 0)
		{
			CombatChar.SetParticleToPlay("Particle_A_B0", context);
		}
		_leftParticleFrame--;
		if (_leftAudioFrame == 0)
		{
			CombatChar.SetAttackSoundToPlay("se_a_b0", context);
		}
		_leftAudioFrame--;
		_leftPrepareFrame--;
		if (_leftPrepareFrame > 0)
		{
			return false;
		}
		Events.RaiseNormalAttackPrepareEnd(context, CombatChar.GetId(), CombatChar.IsAlly);
		CombatChar.StateMachine.TranslateState(CombatCharacterStateType.Attack);
		return false;
	}
}
