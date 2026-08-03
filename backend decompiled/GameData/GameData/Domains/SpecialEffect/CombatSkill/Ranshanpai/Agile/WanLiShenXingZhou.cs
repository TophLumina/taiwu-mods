using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Agile;

public class WanLiShenXingZhou : AgileSkillBase
{
	private const int DirectRequireDistance = 50;

	private const int ReverseRequireDistance = 70;

	public WanLiShenXingZhou()
	{
	}

	public WanLiShenXingZhou(CombatSkillKey skillKey)
		: base(skillKey, 7405)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 149, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 175, -1), EDataModifyType.Custom);
		ShowSpecialEffectTips(0);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 149 && dataKey.CustomParam0 >= 0 && DomainManager.Combat.GetElement_CombatCharacterDict(dataKey.CustomParam0).IsAlly != base.CombatChar.IsAlly)
		{
			return false;
		}
		return dataValue;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0 || !base.CanAffect)
		{
			return dataValue;
		}
		short currDistance = DomainManager.Combat.GetCurrentDistance();
		if (base.IsDirect ? (currDistance < 50) : (currDistance > 70))
		{
			return dataValue;
		}
		if (dataKey.FieldId == 175)
		{
			return 0;
		}
		return dataValue;
	}
}
