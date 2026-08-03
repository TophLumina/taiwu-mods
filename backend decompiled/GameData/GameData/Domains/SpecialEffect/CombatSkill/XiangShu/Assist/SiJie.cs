using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class SiJie : AssistSkillBase
{
	private const sbyte ChangeDamage = 50;

	private bool _affected;

	public SiJie()
	{
	}

	public SiJie(CombatSkillKey skillKey)
		: base(skillKey, 16416)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (_affected)
		{
			_affected = false;
			ShowEffectTips(context);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (_affected)
		{
			_affected = false;
			ShowEffectTips(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		bool hasGodTrick = base.CombatChar.GetTricks().ContainsTrick(21);
		_affected = true;
		if (dataKey.FieldId == 69)
		{
			return hasGodTrick ? 50 : (-50);
		}
		if (dataKey.FieldId == 102)
		{
			return hasGodTrick ? (-50) : 50;
		}
		return 0;
	}
}
