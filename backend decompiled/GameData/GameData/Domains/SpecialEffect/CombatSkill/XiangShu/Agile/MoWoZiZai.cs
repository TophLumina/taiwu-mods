using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Agile;

public class MoWoZiZai : AgileSkillBase
{
	public MoWoZiZai()
	{
	}

	public MoWoZiZai(CombatSkillKey skillKey)
		: base(skillKey, 16209)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 145, -1), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 146, -1), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(-1, 244, -1), EDataModifyType.Custom);
		short aiTargetDist = base.CombatChar.GetTargetDistance();
		if (aiTargetDist >= 0)
		{
			DomainManager.Combat.ChangeDistance(context, base.CombatChar, aiTargetDist - DomainManager.Combat.GetCurrentDistance(), isForced: false, canStop: false);
		}
		ShowSpecialEffectTips(0);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (base.CombatChar.GetAffectingMoveSkillId() != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 244)
		{
			return true;
		}
		return dataValue;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 145) <= 1u)
		{
			return 10000;
		}
		return 0;
	}
}
