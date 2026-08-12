using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.DefenseAndAssist;

public class JingHuaShuiYue : DefenseSkillBase
{
	private const sbyte AvoidOddsPerTrick = 10;

	private const sbyte AvoidOddsPerMark = 5;

	public JingHuaShuiYue()
	{
	}

	public JingHuaShuiYue(CombatSkillKey skillKey)
		: base(skillKey, 8505)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 107, -1), EDataModifyType.Custom);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect || dataValue < 0)
		{
			return dataValue;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		if (RedzenHelper.CheckPercentProb(percentProb: (!base.IsDirect) ? (5 * (enemyChar.GetMindMarkTime().MarkList?.Count ?? 0)) : (10 * enemyChar.GetTrickCount(20)), randomSource: DomainManager.Combat.Context.Random))
		{
			dataValue = 0;
			ShowSpecialEffectTips(0);
		}
		return dataValue;
	}
}
