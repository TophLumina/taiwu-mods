using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Agile;

public class TaXueXunMei : AgileSkillBase
{
	public TaXueXunMei()
	{
	}

	public TaXueXunMei(CombatSkillKey skillKey)
		: base(skillKey, 3404)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			int[] charList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
			for (int i = 0; i < charList.Length; i++)
			{
				if (charList[i] >= 0)
				{
					AffectDatas.Add(new AffectedDataKey(charList[i], 132, -1), EDataModifyType.Add);
				}
			}
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 132, -1), EDataModifyType.Add);
		}
		ShowSpecialEffectTips(0);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 132)
		{
			return base.IsDirect ? 1 : (-1);
		}
		return 0;
	}
}
