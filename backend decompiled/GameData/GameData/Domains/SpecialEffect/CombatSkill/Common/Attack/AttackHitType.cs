using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class AttackHitType : CombatSkillEffectBase
{
	private const sbyte AddDamage = 40;

	protected sbyte AffectHitType;

	private bool _affecting;

	protected AttackHitType()
	{
	}

	protected AttackHitType(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_affecting = false;
		CreateAffectedData(69, EDataModifyType.AddPercent, base.SkillTemplateId);
		CreateAffectedData(325, EDataModifyType.Custom, base.SkillTemplateId);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (!(context.SkillKey != SkillKey) && hit && index <= 2 && hitType == AffectHitType)
		{
			_affecting = true;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!_affecting || dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId || dataKey.CustomParam0 != ((!base.IsDirect) ? 1 : 0))
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			return 40;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey == SkillKey && dataKey.FieldId == 325 && dataKey.CustomParam2 == 1)
		{
			return false;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
