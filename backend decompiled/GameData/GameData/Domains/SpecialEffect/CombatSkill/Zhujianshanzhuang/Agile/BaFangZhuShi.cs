using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Agile;

public class BaFangZhuShi : AgileSkillBase
{
	private const int ChangeHitOdds = 50;

	private bool _changingHitOdds;

	public BaFangZhuShi()
	{
	}

	public BaFangZhuShi(CombatSkillKey skillKey)
		: base(skillKey, 9502)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(74, EDataModifyType.TotalPercent, -1);
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightback, bool isMind)
	{
		if (attacker.GetId() == base.CharacterId && hit == base.IsDirect && !attacker.IsAutoNormalAttacking && base.CanAffect && pursueIndex <= 0 && !_changingHitOdds)
		{
			_changingHitOdds = true;
			base.CombatChar.NormalAttackFree();
			ShowSpecialEffectTips(0);
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (attacker.GetId() == base.CharacterId && (attacker.IsAutoNormalAttacking || !attacker.NeedFreeAttack))
		{
			_changingHitOdds = false;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 74 || !_changingHitOdds)
		{
			return 0;
		}
		return base.IsDirect ? (-50) : 50;
	}
}
