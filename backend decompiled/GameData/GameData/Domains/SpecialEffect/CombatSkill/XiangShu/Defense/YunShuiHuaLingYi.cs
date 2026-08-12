using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class YunShuiHuaLingYi : DefenseSkillBase
{
	private const sbyte AvoidOddsPerMark = 10;

	public YunShuiHuaLingYi()
	{
	}

	public YunShuiHuaLingYi(CombatSkillKey skillKey)
		: base(skillKey, 16300)
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
		int avoidOdds = 10 * base.CurrEnemyChar.GetDefeatMarkCollection().PoisonMarkList.Sum();
		if (DomainManager.Combat.Context.Random.CheckPercentProb(avoidOdds))
		{
			dataValue = 0;
			ShowSpecialEffectTips(0);
		}
		return dataValue;
	}
}
