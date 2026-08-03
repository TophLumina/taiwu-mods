using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class Blade : FeatureEffectBase
{
	private const short AddDamageUnit = 20;

	private const short MaxAddDamage = 180;

	private const int DirectDamageAddPercent = 33;

	public Blade()
	{
	}

	public Blade(int charId, short featureId)
		: base(charId, featureId, 41408)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 69)
		{
			return 0;
		}
		bool critical = dataKey.CustomParam2 == 1;
		int addDamage = 0;
		Weapon usingWeapon = DomainManager.Combat.GetUsingWeapon(base.CombatChar);
		if (usingWeapon.GetItemSubType() == 9 && critical)
		{
			addDamage += 33;
		}
		if (!dataKey.IsNormalAttack && !base.CombatChar.GetAutoCastingSkill() && dataKey.SkillTemplate.Type == 8)
		{
			addDamage += Math.Min(base.CurrEnemyChar.GetFlawCount().Sum() * 20, 180);
		}
		return addDamage;
	}
}
