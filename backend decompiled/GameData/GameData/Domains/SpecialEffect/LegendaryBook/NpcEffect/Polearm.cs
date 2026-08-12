using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class Polearm : FeatureEffectBase
{
	private const int NeedPursueIndex = 5;

	private static readonly CValuePercent DeltaFrame = -50;

	private const short MaxAddDamage = 180;

	public Polearm()
	{
	}

	public Polearm(int charId, short featureId)
		: base(charId, featureId, 41409)
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

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightback)
	{
		if (attacker.GetId() == base.CharacterId && pursueIndex == 5)
		{
			GameData.Domains.Item.Weapon usingWeapon = DomainManager.Combat.GetUsingWeapon(attacker);
			if (usingWeapon.GetItemSubType() == 10)
			{
				defender.ChangeAffectingDefenseSkillLeftFrame(context, DeltaFrame);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			if (base.CombatChar.GetAutoCastingSkill() || dataKey.CombatSkillId < 0 || Config.CombatSkill.Instance[dataKey.CombatSkillId].Type != 9)
			{
				return 0;
			}
			int markCount = base.CombatChar.GetDefeatMarkCollection().GetTotalCount();
			int maxDamageMarkCount = GlobalConfig.NeedDefeatMarkCount[DomainManager.Combat.GetCombatType()] / 2;
			int addDamage = 180 * markCount / maxDamageMarkCount;
			return Math.Min(addDamage, 180);
		}
		return 0;
	}
}
