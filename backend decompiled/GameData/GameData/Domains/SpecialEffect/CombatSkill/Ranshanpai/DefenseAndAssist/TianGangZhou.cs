using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.DefenseAndAssist;

public class TianGangZhou : DefenseSkillBase
{
	private const sbyte ReduceDamage = -40;

	public TianGangZhou()
	{
	}

	public TianGangZhou(CombatSkillKey skillKey)
		: base(skillKey, 7505)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.TotalPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0 || !base.CanAffect || DomainManager.CombatSkill.GetSkillDirection(base.CurrEnemyChar.GetId(), dataKey.CombatSkillId) != (base.IsDirect ? 1 : 0))
		{
			return 0;
		}
		if (dataKey.FieldId == 102)
		{
			ShowSpecialEffectTips(0);
			return -40;
		}
		return 0;
	}
}
