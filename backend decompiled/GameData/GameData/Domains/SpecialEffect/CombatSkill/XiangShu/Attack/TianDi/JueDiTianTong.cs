using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Helper;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.TianDi;

public class JueDiTianTong : CombatSkillEffectBase, IHeavenlyEmperorHandler
{
	private const int ChangeEffectCount = 3;

	private readonly HeavenlyEmperorHelper _handler;

	private int _castBeginEffectCount;

	public JueDiTianTong()
	{
		_handler = new HeavenlyEmperorHelper(this);
	}

	public JueDiTianTong(CombatSkillKey skillKey)
		: base(skillKey, -1, -1)
	{
		_handler = new HeavenlyEmperorHelper(this);
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_ApplyMixedDamageResult(OnApplyMixedDamageResult);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_ApplyMixedDamageResult(OnApplyMixedDamageResult);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter _, short skillId)
	{
		if (SkillKey.IsMatch(attacker.GetId(), skillId))
		{
			_castBeginEffectCount = _handler.AcceptDamageEffectCount;
		}
	}

	private void OnApplyMixedDamageResult(CombatContext context, CombatDamageResultMixed damage)
	{
		if (!(SkillKey != context.SkillKey) && context.DamageType == EDamageType.Direct && _castBeginEffectCount > 0)
		{
			int totalDamage = damage.Outer.TotalDamage + damage.Inner.TotalDamage * _castBeginEffectCount;
			if (totalDamage > 0)
			{
				context.Defender.AddFatalDamage(context, totalDamage, -1, -1, base.SkillTemplateId);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool _, short skillId, sbyte power, bool interrupted)
	{
		if (!(!SkillKey.IsMatch(charId, skillId) || interrupted))
		{
			_handler.ChangeAcceptDamageEffectCount(context, 3);
			ShowSpecialEffectTips(1);
		}
	}
}
