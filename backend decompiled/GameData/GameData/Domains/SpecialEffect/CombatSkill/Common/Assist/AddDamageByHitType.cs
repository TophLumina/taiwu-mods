using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

public class AddDamageByHitType : AssistSkillBase
{
	private const sbyte AddDamage = 50;

	protected sbyte HitType;

	private bool _affected;

	protected AddDamageByHitType()
	{
	}

	protected AddDamageByHitType(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
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

	public unsafe override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		GameData.Domains.Character.Character enemyChar = base.CurrEnemyChar.GetCharacter();
		HitOrAvoidInts selfHit = CharObj.GetHitValues();
		HitOrAvoidInts selfAvoid = CharObj.GetAvoidValues();
		HitOrAvoidInts enemyHit = enemyChar.GetHitValues();
		HitOrAvoidInts enemyAvoid = enemyChar.GetAvoidValues();
		if (((selfHit.Items[HitType] > enemyHit.Items[HitType] || selfAvoid.Items[HitType] > enemyAvoid.Items[HitType]) && dataKey.FieldId == 69) || ((selfHit.Items[HitType] < enemyHit.Items[HitType] || selfAvoid.Items[HitType] < enemyAvoid.Items[HitType]) && dataKey.FieldId == 102))
		{
			_affected = true;
			return 50;
		}
		return 0;
	}
}
