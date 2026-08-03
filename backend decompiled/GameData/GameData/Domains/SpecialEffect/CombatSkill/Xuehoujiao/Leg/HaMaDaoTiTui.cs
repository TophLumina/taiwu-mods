using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Leg;

public class HaMaDaoTiTui : CombatSkillEffectBase
{
	private const sbyte ChangeDistance = 20;

	private const sbyte BreathStanceReduceUnit = -30;

	private const sbyte BreathStanceReduceMaxCount = 3;

	private int _reduceBreathStanceCount;

	public HaMaDaoTiTui()
	{
	}

	public HaMaDaoTiTui(CombatSkillKey skillKey)
		: base(skillKey, 15301, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_reduceBreathStanceCount = 0;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 204, base.SkillTemplateId), EDataModifyType.AddPercent);
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
		if (index == 3 && !(context.SkillKey != SkillKey) && CombatCharPowerMatchAffectRequire())
		{
			DomainManager.Combat.ChangeDistance(context, base.CombatChar, base.IsDirect ? 20 : (-20));
			ShowSpecialEffectTips(0);
			DomainManager.Combat.SetDisplayPosition(context, base.CombatChar.IsAlly, base.IsDirect ? int.MinValue : DomainManager.Combat.GetDisplayPosition(base.CombatChar.IsAlly, DomainManager.Combat.GetCurrentDistance()));
			if (!base.IsDirect)
			{
				CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
				base.CombatChar.SetCurrentPosition(base.CombatChar.GetDisplayPosition(), context);
				enemyChar.SetCurrentPosition(enemyChar.GetDisplayPosition(), context);
			}
			if (_reduceBreathStanceCount < 3)
			{
				_reduceBreathStanceCount++;
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 204);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!(charId != base.CharacterId || interrupted) && skillId != base.SkillTemplateId)
		{
			_reduceBreathStanceCount = 0;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 204);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 204)
		{
			return -30 * _reduceBreathStanceCount;
		}
		return 0;
	}
}
