using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.DefenseAndAssist;

public class JinDaoHuanZhangGong : DefenseSkillBase
{
	private const int InevitableAvoidOdds = 75;

	public JinDaoHuanZhangGong()
	{
	}

	public JinDaoHuanZhangGong(CombatSkillKey skillKey)
		: base(skillKey, 5503)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(290, EDataModifyType.Custom, -1);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 290 || dataValue)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		int attackerId = dataKey.CustomParam2;
		CombatCharacter attacker = DomainManager.Combat.GetElement_CombatCharacterDict(attackerId);
		if (base.IsDirect ? (!attacker.GetChangeTrickAttack()) : (attacker.PursueAttackCount == 0))
		{
			return false;
		}
		DataContext context = DomainManager.Combat.Context;
		bool affected = context.Random.CheckPercentProb(75);
		if (affected)
		{
			ShowSpecialEffectTipsOnceInFrame(0);
		}
		return affected;
	}
}
