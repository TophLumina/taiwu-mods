using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Helper;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class ShenGuangHuanJing : DefenseSkillBase, IHeavenlyEmperorHandler
{
	private const int PoisonValue = 1000;

	private const sbyte PoisonLevel = 3;

	private readonly HeavenlyEmperorHelper _handler;

	public ShenGuangHuanJing()
	{
		_handler = new HeavenlyEmperorHelper(this);
	}

	public ShenGuangHuanJing(CombatSkillKey skillKey)
		: base(skillKey, -1)
	{
		_handler = new HeavenlyEmperorHelper(this);
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightBack, bool isMind)
	{
		if (defender.GetId() != base.CharacterId || !hit || pursueIndex > 0 || _handler.AcceptDamageEffectCount <= 0)
		{
			return;
		}
		int value = 1000 * _handler.AcceptDamageEffectCount;
		foreach (sbyte type in PoisonType.InnerPoison)
		{
			DomainManager.Combat.AddPoison(context, defender, attacker, type, 3, value, base.SkillTemplateId);
		}
		ShowSpecialEffectTips(0);
	}
}
