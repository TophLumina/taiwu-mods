using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

public abstract class SwordAddFatalEffectBase : SwordUnlockEffectBase
{
	private const int EffectFatalDamagePercent = 5;

	private int _directDamageValue;

	private int SelfFatalDamagePercent => base.IsDirectOrReverseEffectDoubling ? 10 : 5;

	protected abstract CValueMultiplier FlawOrAcupointCount { get; }

	protected virtual CValueMultiplier CalcExtraFlawOrAcupointCount(short skillId)
	{
		return 0;
	}

	protected SwordAddFatalEffectBase()
	{
	}

	protected SwordAddFatalEffectBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_AddDirectDamageValue(AddDirectDamageValue);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_AddDirectDamageValue(AddDirectDamageValue);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() == base.CharacterId)
		{
			_directDamageValue = 0;
		}
	}

	private void AddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (attackerId == base.CharacterId)
		{
			_directDamageValue += damageValue;
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || _directDamageValue <= 0)
		{
			return;
		}
		CValuePercent percent = 0;
		if (skillId == base.SkillTemplateId && base.IsReverseOrUsingDirectWeapon)
		{
			percent += (CValuePercent)SelfFatalDamagePercent;
		}
		if (base.EffectCount > 0)
		{
			percent += (CValuePercent)5;
		}
		percent *= FlawOrAcupointCount + CalcExtraFlawOrAcupointCount(skillId);
		int fatalDamageValue = _directDamageValue * percent;
		_directDamageValue = 0;
		if (fatalDamageValue > 0)
		{
			if (base.EffectCount > 0)
			{
				ReduceEffectCount();
			}
			base.CurrEnemyChar.AddFatalDamage(context, fatalDamageValue, -1, -1, -1);
			ShowSpecialEffectTips(base.IsDirect, 1, 0);
		}
	}
}
