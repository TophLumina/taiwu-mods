using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Throw;

public class QingJiaoXue : PoisonAddInjury
{
	private const int CostDurabilityPercent = 10;

	private sbyte _affectedBodyPart;

	public QingJiaoXue()
	{
	}

	public QingJiaoXue(CombatSkillKey skillKey)
		: base(skillKey, 10407)
	{
		RequirePoisonType = 4;
	}

	protected override void OnCastOwnBegin(DataContext context)
	{
		_affectedBodyPart = -1;
		AppendAffectedData(context, 325, EDataModifyType.Custom, base.SkillTemplateId);
	}

	protected override void OnCastMaxPower(DataContext context)
	{
		if (_affectedBodyPart < 0)
		{
			return;
		}
		byte poisonMarkCount = (base.IsDirect ? base.CurrEnemyChar : base.CombatChar).GetDefeatMarkCollection().PoisonMarkList[RequirePoisonType];
		int costDurabilityPercent = poisonMarkCount * 10;
		if (costDurabilityPercent == 0)
		{
			return;
		}
		bool anyChanged = false;
		foreach (ItemKey armorKey in IterEnemyArmors())
		{
			Armor armor = (armorKey.IsValid() ? DomainManager.Item.GetElement_Armors(armorKey.Id) : null);
			if (armor != null && armor.GetCurrDurability() != 0)
			{
				int costDurability = armor.GetMaxDurability() * costDurabilityPercent / 100;
				ChangeDurability(context, base.CurrEnemyChar, armorKey, -costDurability);
				anyChanged = true;
			}
		}
		if (anyChanged)
		{
			ShowSpecialEffectTips(1);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 325)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam2;
		if (damageType != EDamageType.Direct)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		sbyte bodyPart = (_affectedBodyPart = (sbyte)dataKey.CustomParam1);
		ItemKey armorKey = base.CurrEnemyChar.Armors[bodyPart];
		Armor armor = (armorKey.IsValid() ? DomainManager.Item.GetElement_Armors(armorKey.Id) : null);
		if (armor != null && armor.GetCurrDurability() > 0)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		return false;
	}

	private IEnumerable<ItemKey> IterEnemyArmors()
	{
		ItemKey[] enemyArmors = base.CurrEnemyChar.Armors;
		yield return enemyArmors[2];
		yield return enemyArmors[0];
		yield return enemyArmors[3];
		yield return enemyArmors[5];
	}
}
