using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Neigong;

public class WuShangYuJiaFa : CombatSkillEffectBase
{
	private const sbyte DirectChangePercent = 60;

	private const sbyte ReverseChangePercent = -30;

	public WuShangYuJiaFa()
	{
	}

	public WuShangYuJiaFa(CombatSkillKey skillKey)
		: base(skillKey, 11008, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 135, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 126, -1), EDataModifyType.Custom);
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 136, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 131, -1), EDataModifyType.Custom);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 126 || fieldId == 131) ? true : false)
		{
			bool canAffecting = CanAffecting();
			if (canAffecting)
			{
				ShowSpecialEffectTipsOnceInFrame(0);
			}
			return !canAffecting;
		}
		return dataValue;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !CanAffecting())
		{
			return 0;
		}
		if (dataKey.FieldId == 135)
		{
			return 60;
		}
		if (dataKey.FieldId == 136)
		{
			return -30;
		}
		return 0;
	}

	private bool CanAffecting()
	{
		return DomainManager.Combat.IsCharacterHalfFallen(base.CombatChar);
	}
}
