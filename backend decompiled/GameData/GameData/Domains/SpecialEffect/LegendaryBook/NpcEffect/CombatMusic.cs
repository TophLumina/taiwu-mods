using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class CombatMusic : FeatureEffectBase
{
	private const short AddDamageUnit = 30;

	private const short MaxAddDamage = 180;

	public CombatMusic()
	{
	}

	public CombatMusic(int charId, short featureId)
		: base(charId, featureId, 41413)
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

	private unsafe void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (!DomainManager.Combat.IsCharInCombat(base.CharacterId) || attacker.GetId() != base.CharacterId || !hit || isFightBack)
		{
			return;
		}
		ItemKey currWeapon = DomainManager.Combat.GetUsingWeaponKey(base.CombatChar);
		short subType = ItemTemplateHelper.GetItemSubType(currWeapon.ItemType, currWeapon.TemplateId);
		if (!CombatSkillType.Instance[(sbyte)13].LegendaryBookWeaponSlotItemSubTypes.Contains(subType))
		{
			return;
		}
		NeiliAllocation neiliAllocation = base.CurrEnemyChar.GetNeiliAllocation();
		List<byte> typeRandomPool = ObjectPool<List<byte>>.Instance.Get();
		typeRandomPool.Clear();
		for (byte type = 0; type < 4; type++)
		{
			if (neiliAllocation.Items[(int)type] > 0)
			{
				typeRandomPool.Add(type);
			}
		}
		if (typeRandomPool.Count > 0)
		{
			base.CurrEnemyChar.ChangeNeiliAllocation(context, typeRandomPool.GetRandom(context.Random), -1);
		}
		ObjectPool<List<byte>>.Instance.Return(typeRandomPool);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0 || base.CombatChar.GetAutoCastingSkill() || Config.CombatSkill.Instance[dataKey.CombatSkillId].Type != 13)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			int addDamage = 30 * base.CombatChar.GetTrickCount(9);
			return Math.Min(addDamage, 180);
		}
		return 0;
	}
}
