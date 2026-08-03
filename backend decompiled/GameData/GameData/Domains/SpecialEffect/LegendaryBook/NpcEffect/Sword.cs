using System;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class Sword : FeatureEffectBase
{
	private const int AddPursueOdds = 200;

	private const short AddDamageUnit = 20;

	private const short MaxAddDamage = 180;

	public Sword()
	{
	}

	public Sword(int charId, short featureId)
		: base(charId, featureId, 41407)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(76, EDataModifyType.AddPercent, -1);
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 76)
		{
			GameData.Domains.Item.Weapon currWeapon = DomainManager.Combat.GetUsingWeapon(base.CombatChar);
			if (currWeapon.GetItemSubType() != 8)
			{
				return 0;
			}
			return (dataKey.CustomParam1 == 1) ? 200 : 0;
		}
		if (dataKey.FieldId == 69)
		{
			if (!dataKey.IsNormalAttack && !base.CombatChar.GetAutoCastingSkill())
			{
				CombatSkillItem skillTemplate = dataKey.SkillTemplate;
				if (skillTemplate != null && skillTemplate.Type == 7)
				{
					int trickCount = base.EnemyChar.UsableTrickCount;
					int addDamage = 20 * (9 - trickCount);
					return Math.Min(addDamage, 180);
				}
			}
			return 0;
		}
		return 0;
	}
}
