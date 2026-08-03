using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReducePenetrateResist;

public class ReducePenetrateResistBase : EquipmentEffectBase
{
	private const sbyte ReducePercent = -25;

	protected sbyte RequireArmorResourceType;

	protected ReducePenetrateResistBase()
	{
	}

	protected ReducePenetrateResistBase(int charId, ItemKey itemKey, int type)
		: base(charId, itemKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 66, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 67, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !IsCurrWeapon() || dataKey.CustomParam0 < 0)
		{
			return 0;
		}
		ItemKey armorKey = base.CurrEnemyChar.Armors[dataKey.CustomParam0];
		if (!armorKey.IsValid())
		{
			return 0;
		}
		ItemBase armor = DomainManager.Item.GetBaseItem(armorKey);
		if (armor.GetCurrDurability() <= 0 || armor.GetResourceType() != RequireArmorResourceType)
		{
			return 0;
		}
		return -25;
	}
}
