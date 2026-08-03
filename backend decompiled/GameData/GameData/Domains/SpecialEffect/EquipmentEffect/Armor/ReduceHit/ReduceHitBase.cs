using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Armor.ReduceHit;

public abstract class ReduceHitBase : EquipmentEffectBase
{
	private const sbyte ReducePercent = -25;

	protected virtual bool RequireIsCurrArmor => true;

	protected virtual EDataModifyType ModifyType => EDataModifyType.AddPercent;

	protected abstract bool IsRequireWeaponSubType(short weaponSubType);

	protected ReduceHitBase()
	{
	}

	protected ReduceHitBase(int charId, ItemKey itemKey, int type)
		: base(charId, itemKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		for (sbyte type = 0; type < 4; type++)
		{
			CreateAffectedData((ushort)(90 + type), ModifyType, -1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (RequireIsCurrArmor && !IsCurrArmor((sbyte)dataKey.CustomParam2))
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
