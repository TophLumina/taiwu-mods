using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Agile;

public class XuanJiaDing : AgileSkillBase
{
	private const int ReduceCostPercent = -50;

	private bool _affecting;

	private bool IsLeg(short skillTemplateId)
	{
		return DomainManager.CombatSkill.GetSkillType(base.CharacterId, skillTemplateId) == 5;
	}

	public XuanJiaDing()
	{
	}

	public XuanJiaDing(CombatSkillKey skillKey)
		: base(skillKey, 5403)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_affecting = false;
		OnMoveSkillCanAffectChanged(context, default(DataUid));
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 149, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 215, -1), EDataModifyType.Custom);
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 207, -1), EDataModifyType.TotalPercent);
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 205, -1), EDataModifyType.TotalPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 206, -1), EDataModifyType.TotalPercent);
		}
		ShowSpecialEffectTips(0);
		ShowSpecialEffectTips(1);
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect;
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			if (base.IsDirect)
			{
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 207);
				return;
			}
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 205);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 206);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!_affecting || !IsLeg(dataKey.CombatSkillId))
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 205) <= 2u)
		{
			return -50;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (!_affecting)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 149 && dataKey.CustomParam0 >= 0 && DomainManager.Combat.GetElement_CombatCharacterDict(dataKey.CustomParam0).IsAlly != base.CombatChar.IsAlly)
		{
			return false;
		}
		if (dataKey.FieldId == 215 && dataKey.CharId == base.CharacterId && IsLeg(dataKey.CombatSkillId))
		{
			return false;
		}
		return dataValue;
	}
}
