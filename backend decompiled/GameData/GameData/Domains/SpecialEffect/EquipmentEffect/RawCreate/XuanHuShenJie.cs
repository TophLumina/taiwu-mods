using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.RawCreate;

public class XuanHuShenJie : RawCreateEquipmentBase
{
	private const int AddDirectDamagePercent = 50;

	protected override int ReduceDurabilityValue => 8;

	public XuanHuShenJie()
	{
	}

	public XuanHuShenJie(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30203)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 69 || !base.CanAffect)
		{
			return 0;
		}
		if (DomainManager.Combat.GetUsingWeaponKey(base.CombatChar) != EquipItemKey)
		{
			return 0;
		}
		return 50;
	}
}
