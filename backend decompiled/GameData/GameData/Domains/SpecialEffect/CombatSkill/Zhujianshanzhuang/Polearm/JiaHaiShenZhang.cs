using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Polearm;

public class JiaHaiShenZhang : PolearmUnlockEffectBase
{
	private readonly List<ItemKey> _addedEffectKeys = new List<ItemKey>();

	private static CValuePercent AddDurabilityPercent => 50;

	private CValuePercent CastAddUnlockPercent => base.IsDirectOrReverseEffectDoubling ? 16 : 8;

	protected override IEnumerable<sbyte> RequireMainAttributeTypes { get; } = new sbyte[3] { 3, 4, 2 };

	protected override int RequireMainAttributeValue => 55;

	public JiaHaiShenZhang()
	{
	}

	public JiaHaiShenZhang(CombatSkillKey skillKey)
		: base(skillKey, 9306)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		base.OnDisable(context);
	}

	protected override void OnCastAddUnlockAttackValue(DataContext context, CValuePercent power)
	{
		base.OnCastAddUnlockAttackValue(context, power);
		if (base.IsReverseOrUsingDirectWeapon)
		{
			base.CombatChar.ChangeAllUnlockAttackValue(context, CastAddUnlockPercent * power);
			ShowSpecialEffectTipsOnceInFrame(0);
		}
	}

	protected override void DoAffect(DataContext context, int weaponIndex)
	{
		ItemKey[] equipment = base.CombatChar.GetCharacter().GetEquipment();
		for (int i = 0; i < equipment.Length; i++)
		{
			ItemKey key = equipment[i];
			if (key.IsValid() && DomainManager.Combat.EquipmentOldDurability.TryGetValue(key, out var old))
			{
				short current = DomainManager.Item.GetBaseItem(key).GetCurrDurability();
				if (current < old)
				{
					int addValue = Math.Max((old - current) * AddDurabilityPercent, 1);
					ChangeDurability(context, base.CombatChar, key, addValue);
					ShowSpecialEffectTipsOnceInFrame(1);
				}
			}
		}
		List<ItemKey> pool = ObjectPool<List<ItemKey>>.Instance.Get();
		ItemKey[] equipment2 = base.EnemyChar.GetCharacter().GetEquipment();
		foreach (ItemKey key2 in equipment2)
		{
			if (!pool.Contains(key2) && IsKeyCanCrippledCreate(key2))
			{
				pool.Add(key2);
			}
		}
		if (pool.Count > 0)
		{
			ItemKey key3 = pool.GetRandom(context.Random);
			SpecialEffectItem effectConfig = Config.SpecialEffect.Instance[base.EffectId];
			short effectId = effectConfig.RawCreateEffect;
			DomainManager.Item.AddExternEquipmentEffect(context, key3, effectId);
			DomainManager.SpecialEffect.AddEquipmentEffect(context, base.EnemyChar.GetId(), key3, effectId);
			base.EnemyChar.GetCharacter().SetEquipment(base.EnemyChar.GetCharacter().GetEquipment(), context);
			_addedEffectKeys.Add(key3);
			DomainManager.Combat.ShowSpecialEffectTips(base.CharacterId, effectConfig.RawCreateTips, 0);
		}
		ObjectPool<List<ItemKey>>.Instance.Return(pool);
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		short effectId = Config.SpecialEffect.Instance[base.EffectId].RawCreateEffect;
		foreach (ItemKey key in _addedEffectKeys)
		{
			DomainManager.Item.RemoveExternEquipmentEffect(context, key, effectId);
		}
		_addedEffectKeys.Clear();
	}

	private bool IsKeyCanCrippledCreate(ItemKey key)
	{
		if (!key.IsValid() || _addedEffectKeys.Contains(key))
		{
			return false;
		}
		sbyte itemType = key.ItemType;
		if (1 == 0)
		{
		}
		bool result = itemType switch
		{
			0 => Config.Weapon.Instance[key.TemplateId].AllowCrippledCreate, 
			1 => Config.Armor.Instance[key.TemplateId].AllowCrippledCreate, 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
