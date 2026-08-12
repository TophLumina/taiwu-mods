using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.EquipmentEffect.RawCreate;

public class GuiYanLingZhuo : RawCreateEquipmentBase
{
	private const int AddEquipmentBonus = 100;

	private const int ChangeNeiliAllocationUnit = 1;

	private const int AffectFrame = 240;

	protected override int ReduceDurabilityValue => 2;

	public GuiYanLingZhuo()
	{
	}

	public GuiYanLingZhuo(int charId, ItemKey itemKey)
		: base(charId, itemKey, 30202)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(308, EDataModifyType.AddPercent, -1);
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		foreach (int item in base.CalcFrameCounterPeriods())
		{
			yield return item;
		}
		yield return 240;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		base.OnProcess(context, counterType);
		if (counterType == 1)
		{
			base.CombatChar.ChangeNeiliAllocationRandom(context, 1, 1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 308 || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.CustomParam0 != 2 || dataKey.CustomParam1 != EquipItemKey.Id)
		{
			return 0;
		}
		ECharacterPropertyReferencedType propertyType = (ECharacterPropertyReferencedType)dataKey.CustomParam2;
		if (!GameData.Domains.Character.Character.CombatPropertyTypes.Contains(propertyType))
		{
			return 0;
		}
		return 100;
	}
}
