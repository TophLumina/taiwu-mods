using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Agile;

public class FeiTouShu : AgileSkillBase
{
	private const sbyte DirectRequireDistance = 50;

	private const sbyte ReverseRequireDistance = 70;

	public FeiTouShu()
	{
	}

	public FeiTouShu(CombatSkillKey skillKey)
		: base(skillKey, 12603)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 126, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 131, -1), EDataModifyType.Custom);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return dataValue;
		}
		short distance = DomainManager.Combat.GetCurrentDistance();
		if (base.IsDirect ? (distance < 50) : (distance > 70))
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 126 || fieldId == 131) ? true : false)
		{
			ShowSpecialEffectTips(0);
			return false;
		}
		return dataValue;
	}
}
