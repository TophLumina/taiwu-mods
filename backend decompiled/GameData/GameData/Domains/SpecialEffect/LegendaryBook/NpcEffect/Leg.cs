using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class Leg : FeatureEffectBase
{
	private const short MaxDamageMobilityPercent = 50;

	private const short MaxAddDamage = 180;

	public Leg()
	{
	}

	public Leg(int charId, short featureId)
		: base(charId, featureId, 41405)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 88, -1), EDataModifyType.Custom);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0 || base.CombatChar.GetAutoCastingSkill() || Config.CombatSkill.Instance[dataKey.CombatSkillId].Type != 5)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			int mobilityPercent = base.CurrEnemyChar.GetMobilityValue() * 100 / MoveSpecialConstants.MaxMobility;
			int addDamage = ((mobilityPercent < 50) ? 180 : (180 * (100 - mobilityPercent) / 50));
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
		if (dataKey.FieldId == 88)
		{
			return false;
		}
		return dataValue;
	}
}
