using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Finger;

public class SheGuShou : CombatSkillEffectBase
{
	private const int AddWugCount = 9;

	private const int ToxicologyAddWugUnit = 20;

	private int _addPower;

	public SheGuShou()
	{
	}

	public SheGuShou(CombatSkillKey skillKey)
		: base(skillKey, 12200, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_addPower = base.CombatChar.GetWugCount() / 2;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		if (_addPower > 0)
		{
			ShowSpecialEffectTips(0);
		}
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
			short selfToxicology = context.Attacker.GetCharacter().GetLifeSkillAttainment(9);
			short enemyToxicology = context.Defender.GetCharacter().GetLifeSkillAttainment(9);
			int toxicologyDifference = (base.IsDirect ? (selfToxicology - enemyToxicology) : (enemyToxicology - selfToxicology));
			int addWugCount = 9 + Math.Max(0, toxicologyDifference / 20);
			if (base.CombatChar.ChangeWugCount(context, addWugCount))
			{
				ShowSpecialEffectTips(1);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}
}
