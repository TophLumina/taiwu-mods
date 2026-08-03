using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

public abstract class RawCreateUnlockEffectBase : PolearmUnlockEffectBase
{
	protected RawCreateUnlockEffectBase()
	{
	}

	protected RawCreateUnlockEffectBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(310, EDataModifyType.Custom, -1);
	}

	protected override void DoAffect(DataContext context, int weaponIndex)
	{
		base.CombatChar.InvokeRawCreate(context, base.EffectId);
	}

	public override List<int> GetModifiedValue(AffectedDataKey dataKey, List<int> dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 310)
		{
			return dataValue;
		}
		int weaponIndex = dataKey.CustomParam0;
		ItemKey weapon = base.CombatChar.GetWeapons()[weaponIndex];
		bool num;
		if (!base.IsDirect)
		{
			if (!IsMatchWeaponType(weapon))
			{
				goto IL_0079;
			}
			num = ReverseEffectDoubling;
		}
		else
		{
			num = IsDirectWeapon(weapon);
		}
		if (num)
		{
			dataValue.Add(base.EffectId);
		}
		goto IL_0079;
		IL_0079:
		return dataValue;
	}
}
