using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.ReduceAvoid;

public abstract class ReduceAvoidBase : EquipmentEffectBase
{
	private const sbyte ReducePercent = -25;

	protected abstract bool IsRequireWeaponSubType(short weaponSubType);

	protected ReduceAvoidBase()
	{
	}

	protected ReduceAvoidBase(int charId, ItemKey itemKey, int type)
		: base(charId, itemKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		for (sbyte type = 0; type < 4; type++)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(60 + type), -1), EDataModifyType.AddPercent);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !IsCurrWeapon())
		{
			return 0;
		}
		ItemKey enemyWeaponKey = DomainManager.Combat.GetUsingWeaponKey(base.CurrEnemyChar);
		short enemyWeaponSubType = DomainManager.Item.GetElement_Weapons(enemyWeaponKey.Id).GetItemSubType();
		if (!IsRequireWeaponSubType(enemyWeaponSubType))
		{
			return 0;
		}
		return -25;
	}
}
