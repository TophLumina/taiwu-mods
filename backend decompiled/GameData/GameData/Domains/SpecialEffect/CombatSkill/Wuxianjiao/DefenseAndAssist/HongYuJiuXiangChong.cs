using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.DefenseAndAssist;

public class HongYuJiuXiangChong : AssistSkillBase
{
	private const sbyte AddDamageUnit = 5;

	private bool _affected;

	public HongYuJiuXiangChong()
	{
	}

	public HongYuJiuXiangChong(CombatSkillKey skillKey)
		: base(skillKey, 12802)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (_affected && attacker == base.CombatChar)
		{
			_affected = false;
			if (pursueIndex == 0)
			{
				ShowEffectTips(context);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (_affected && context.Attacker == base.CombatChar)
		{
			_affected = false;
			ShowEffectTips(context);
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			int addDamage = 5 * (base.IsDirect ? base.CurrEnemyChar : base.CombatChar).GetDefeatMarkCollection().PoisonMarkList.Sum();
			if (addDamage > 0)
			{
				_affected = true;
			}
			return addDamage;
		}
		return 0;
	}
}
