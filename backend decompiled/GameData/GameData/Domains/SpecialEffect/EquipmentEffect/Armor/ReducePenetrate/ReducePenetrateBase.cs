using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReducePenetrate;

public class ReducePenetrateBase : EquipmentEffectBase
{
	private const sbyte ReducePercent = -25;

	protected sbyte RequireWeaponResourceType;

	protected ReducePenetrateBase()
	{
	}

	protected ReducePenetrateBase(int charId, ItemKey itemKey, int type)
		: base(charId, itemKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 98, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 99, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !IsCurrArmor((sbyte)dataKey.CustomParam0))
		{
			return 0;
		}
		ItemKey enemyWeaponKey = DomainManager.Combat.GetUsingWeaponKey(base.CurrEnemyChar);
		if (DomainManager.Item.GetBaseItem(enemyWeaponKey).GetResourceType() != RequireWeaponResourceType)
		{
			return 0;
		}
		return -25;
	}
}
