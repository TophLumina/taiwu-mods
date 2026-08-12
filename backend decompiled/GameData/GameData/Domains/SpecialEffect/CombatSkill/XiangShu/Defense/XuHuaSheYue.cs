using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class XuHuaSheYue : DefenseSkillBase
{
	private const sbyte ChangeDamagePercent = 15;

	private int _effectTipsIndex;

	public XuHuaSheYue()
	{
	}

	public XuHuaSheYue(CombatSkillKey skillKey)
		: base(skillKey, 16312)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_effectTipsIndex = -1;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 71, -1), EDataModifyType.AddPercent);
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
		if (_effectTipsIndex >= 0)
		{
			ShowSpecialEffectTips((byte)_effectTipsIndex);
			_effectTipsIndex = -1;
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (_effectTipsIndex >= 0)
		{
			ShowSpecialEffectTips((byte)_effectTipsIndex);
			_effectTipsIndex = -1;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		int dieMarkCount = base.CurrEnemyChar.GetDefeatMarkCollection().DieMarkList.Count;
		if (dieMarkCount == 0)
		{
			return 0;
		}
		_effectTipsIndex = ((dataKey.FieldId != 102) ? 1 : 0);
		return ((dataKey.FieldId == 102) ? (-15) : 15) * dieMarkCount;
	}
}
