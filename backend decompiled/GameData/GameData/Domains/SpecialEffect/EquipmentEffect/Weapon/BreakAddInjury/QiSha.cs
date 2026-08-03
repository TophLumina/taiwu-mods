using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.Weapon.BreakAddInjury;

public class QiSha : EquipmentEffectBase
{
	private const sbyte AddDamagePercent = 25;

	public QiSha()
	{
	}

	public QiSha(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30016)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (base.CombatChar.NeedReduceWeaponDurability <= 0 || dataKey.CustomParam0 != 1 || !IsCurrWeapon())
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			return 25;
		}
		return 0;
	}
}
