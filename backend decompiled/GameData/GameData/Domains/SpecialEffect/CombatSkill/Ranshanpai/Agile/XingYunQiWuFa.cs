using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Agile;

public class XingYunQiWuFa : AgileSkillBase
{
	private const sbyte ReduceDamage = -60;

	public XingYunQiWuFa()
	{
	}

	public XingYunQiWuFa(CombatSkillKey skillKey)
		: base(skillKey, 7403)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		int[] charList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		for (int i = 0; i < charList.Length; i++)
		{
			if (charList[i] >= 0)
			{
				AffectDatas.Add(new AffectedDataKey(charList[i], (ushort)(base.IsDirect ? 71 : 70), -1), EDataModifyType.TotalPercent);
			}
		}
		ShowSpecialEffectTips(0);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!base.CanAffect)
		{
			return 0;
		}
		return -60;
	}
}
