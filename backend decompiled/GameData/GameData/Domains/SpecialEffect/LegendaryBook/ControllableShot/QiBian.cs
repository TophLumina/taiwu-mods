using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.EquipmentEffect;

namespace GameData.Domains.SpecialEffect.LegendaryBook.ControllableShot;

public class QiBian : EquipmentEffectBase
{
	private const short AddPursueOddsPercent = 100;

	public QiBian()
	{
	}

	public QiBian(int charId, ItemKey itemKey)
		: base(charId, itemKey, 41200, autoRemoveAfterCombat: false)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 76, -1), EDataModifyType.TotalPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !IsCurrWeapon() || !base.CombatChar.GetChangeTrickAttack())
		{
			return 0;
		}
		if (dataKey.FieldId == 76)
		{
			return 100;
		}
		return 0;
	}
}
