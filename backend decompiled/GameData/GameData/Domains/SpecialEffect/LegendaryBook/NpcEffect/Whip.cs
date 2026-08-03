using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class Whip : FeatureEffectBase
{
	private const short MaxAddDamage = 180;

	private const sbyte AddAttackRange = 10;

	public Whip()
	{
	}

	public Whip(int charId, short featureId)
		: base(charId, featureId, 41411)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 29, -1), EDataModifyType.Add);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			if (base.CombatChar.GetAutoCastingSkill() || dataKey.CombatSkillId < 0 || Config.CombatSkill.Instance[dataKey.CombatSkillId].Type != 11)
			{
				return 0;
			}
			int addDamage = 180 * (30000 - base.CurrEnemyChar.GetBreathValue()) / 30000;
			return Math.Min(addDamage, 180);
		}
		if (dataKey.FieldId == 29)
		{
			short subType = ItemTemplateHelper.GetItemSubType((sbyte)dataKey.CustomParam0, (short)dataKey.CustomParam1);
			if (!CombatSkillType.Instance[(sbyte)11].LegendaryBookWeaponSlotItemSubTypes.Contains(subType))
			{
				return 0;
			}
			return 10;
		}
		return 0;
	}
}
