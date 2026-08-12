using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class Throw : FeatureEffectBase
{
	private const short MinDistance = 50;

	private const short BaseAddDamage = 40;

	private const short AddDamageUnit = 20;

	private const short MaxAddDamage = 180;

	public Throw()
	{
	}

	public Throw(int charId, short featureId)
		: base(charId, featureId, 41406)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 280, -1), EDataModifyType.Custom);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0 || base.CombatChar.GetAutoCastingSkill() || Config.CombatSkill.Instance[dataKey.CombatSkillId].Type != 6)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			short distance = DomainManager.Combat.GetCurrentDistance();
			int addDamage = ((distance >= 50) ? (40 + (distance - 50) / 10 * 20) : 0);
			return Math.Min(addDamage, 180);
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		ItemKey currWeapon = DomainManager.Combat.GetUsingWeaponKey(base.CombatChar);
		short subType = ItemTemplateHelper.GetItemSubType(currWeapon.ItemType, currWeapon.TemplateId);
		if (!CombatSkillType.Instance[(sbyte)6].LegendaryBookWeaponSlotItemSubTypes.Contains(subType))
		{
			return dataValue;
		}
		if (dataKey.FieldId == 280)
		{
			return true;
		}
		return dataValue;
	}
}
