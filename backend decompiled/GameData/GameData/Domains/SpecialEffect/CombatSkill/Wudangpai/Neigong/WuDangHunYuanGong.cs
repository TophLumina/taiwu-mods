using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Neigong;

public class WuDangHunYuanGong : CombatSkillEffectBase
{
	private const sbyte ReduceDamagePercent = -60;

	public WuDangHunYuanGong()
	{
	}

	public WuDangHunYuanGong(CombatSkillKey skillKey)
		: base(skillKey, 4005, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 102, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 102 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0))
		{
			sbyte innerRatio = ((dataKey.CombatSkillId >= 0) ? DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(base.CurrEnemyChar.GetId(), dataKey.CombatSkillId)).GetCurrInnerRatio() : base.CurrEnemyChar.GetWeaponData().GetInnerRatio());
			if (innerRatio > 0 && innerRatio < 100)
			{
				ShowSpecialEffectTips(0);
				return -60;
			}
		}
		return 0;
	}
}
