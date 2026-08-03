using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.SectStory.Yuanshan;

public class VitalDemonA : VitalDemonEffectBase
{
	private const int AbsorbNeiliAllocationValue = 3;

	private const int SilenceFrame = 240;

	private bool _anyHit;

	public VitalDemonA(int charId)
		: base(charId, 1748)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightback, bool isMind)
	{
		if (attacker.IsAlly == base.CombatChar.IsAlly && defender.IsAlly != base.CombatChar.IsAlly)
		{
			_anyHit = true;
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (attacker.IsAlly == base.CombatChar.IsAlly && defender.IsAlly != base.CombatChar.IsAlly && _anyHit)
		{
			_anyHit = false;
			ShowSpecialEffect(0);
			for (byte i = 0; i < 4; i++)
			{
				attacker.AbsorbNeiliAllocation(context, defender, i, 3);
			}
			short banableSkillId = defender.GetRandomBanableSkillId(context.Random, null, -1);
			if (banableSkillId >= 0)
			{
				DomainManager.Combat.SilenceSkill(context, defender, banableSkillId, 240);
				ShowSpecialEffect(1);
			}
		}
	}
}
