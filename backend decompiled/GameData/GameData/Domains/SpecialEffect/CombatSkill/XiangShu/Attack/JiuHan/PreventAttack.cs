using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JiuHan;

public class PreventAttack : CombatSkillEffectBase
{
	private const int EffectFrame = 120;

	private const int AttackHitOddsAddPercent = -50;

	private const int AttackPrepareFrameAddPercent = 100;

	protected PreventAttack()
	{
	}

	protected PreventAttack(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(107, EDataModifyType.TotalPercent, -1);
		CreateAffectedAllEnemyData(282, EDataModifyType.TotalPercent, -1);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		base.OnDisable(context);
	}

	public override bool IsOn(int counterType)
	{
		return base.EffectCount > 0;
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 120;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		ReduceEffectCount();
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!(context.SkillKey != SkillKey))
		{
			AddMaxEffectCount();
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!dataKey.IsNormalAttack || base.EffectCount <= 0)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = fieldId switch
		{
			107 => -50, 
			282 => 100, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
