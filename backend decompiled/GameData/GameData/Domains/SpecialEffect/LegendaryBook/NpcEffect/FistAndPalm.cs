using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class FistAndPalm : FeatureEffectBase
{
	private const int NeedPursueIndex = 5;

	private const short MaxDistance = 50;

	private const short BaseAddDamage = 60;

	private const short AddDamageUnit = 40;

	private const short MaxAddDamage = 180;

	public FistAndPalm()
	{
	}

	public FistAndPalm(int charId, short featureId)
		: base(charId, featureId, 41403)
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
		if (attacker.GetId() == base.CharacterId && pursueIndex == 5)
		{
			GameData.Domains.Item.Weapon usingWeapon = DomainManager.Combat.GetUsingWeapon(attacker);
			if (usingWeapon.GetItemSubType() == 4)
			{
				defender.ChangeToEmptyHandOrOther(context);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0 || base.CombatChar.GetAutoCastingSkill() || Config.CombatSkill.Instance[dataKey.CombatSkillId].Type != 3)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			short distance = DomainManager.Combat.GetCurrentDistance();
			int addDamage = ((distance <= 50) ? (60 + (50 - distance) / 10 * 40) : 0);
			return Math.Min(addDamage, 180);
		}
		return 0;
	}
}
