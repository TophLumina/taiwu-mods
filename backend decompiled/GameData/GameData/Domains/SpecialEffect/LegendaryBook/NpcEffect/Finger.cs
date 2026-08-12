using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class Finger : FeatureEffectBase
{
	private const short AddDamageUnit = 20;

	private const short MaxAddDamage = 180;

	private const short SilenceFrame = 1200;

	public Finger()
	{
	}

	public Finger(int charId, short featureId)
		: base(charId, featureId, 41404)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (!DomainManager.Combat.IsCharInCombat(base.CharacterId) || attacker != base.CombatChar || pursueIndex != 4)
		{
			return;
		}
		ItemKey currWeapon = DomainManager.Combat.GetUsingWeaponKey(base.CombatChar);
		if (ItemTemplateHelper.GetItemSubType(currWeapon.ItemType, currWeapon.TemplateId) == 4)
		{
			CombatCharacter enemyChar = base.CurrEnemyChar;
			short skillId = enemyChar.GetRandomBanableSkillId(context.Random, null, -1);
			if (skillId >= 0)
			{
				DomainManager.Combat.SilenceSkill(context, enemyChar, skillId, 1200);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0 || base.CombatChar.GetAutoCastingSkill() || Config.CombatSkill.Instance[dataKey.CombatSkillId].Type != 4)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			int acupointCount = base.CurrEnemyChar.GetAcupointCount().Sum();
			int addDamage = 20 * acupointCount;
			return Math.Min(addDamage, 180);
		}
		return 0;
	}
}
