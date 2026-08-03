using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Shot;

public class HuangLongMuYuan : CombatSkillEffectBase
{
	public HuangLongMuYuan()
	{
	}

	public HuangLongMuYuan(CombatSkillKey skillKey)
		: base(skillKey, 9406, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (attackerId == base.CharacterId && (base.IsDirect ? outerMarkCount : innerMarkCount) > 0 && base.CombatChar.GetTrickCount(12) > 0 && base.EffectCount > 0)
		{
			DomainManager.Combat.RemoveTrick(context, base.CombatChar, 12, 1);
			AddPowerDamageInjury(context, base.CurrEnemyChar, !base.IsDirect, 1, 0, changeToOld: true);
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
		}
	}
}
