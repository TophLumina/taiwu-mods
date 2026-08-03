using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Agile;

public class ChengLongShu : AgileSkillBase
{
	private bool _affecting;

	public ChengLongShu()
	{
	}

	public ChengLongShu(CombatSkillKey skillKey)
		: base(skillKey, 9505)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_affecting = false;
		OnMoveSkillCanAffectChanged(context, default(DataUid));
		CreateAffectedData(149, EDataModifyType.Custom, -1);
		CreateAffectedData((ushort)(base.IsDirect ? 230 : 229), EDataModifyType.Custom, -1);
		ShowSpecialEffectTips(0);
		ShowSpecialEffectTips(1);
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect;
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar);
		}
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
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 229) <= 1u)
		{
			return true;
		}
		return dataValue;
	}
}
