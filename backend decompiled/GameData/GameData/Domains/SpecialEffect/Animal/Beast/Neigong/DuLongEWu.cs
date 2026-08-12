using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Neigong;

public class DuLongEWu : AnimalEffectBase
{
	public DuLongEWu()
	{
	}

	public DuLongEWu(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 77, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 78, -1), EDataModifyType.Custom);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 77) <= 1u)
		{
			ShowSpecialEffectTipsOnceInFrame((dataKey.FieldId != 77) ? ((byte)1) : ((byte)0));
			return true;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
